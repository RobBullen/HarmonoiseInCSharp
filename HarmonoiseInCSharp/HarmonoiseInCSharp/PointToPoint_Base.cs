using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

//---------------------------------------------------------------------------
//
//  This namespace provides a wrapper around the PropagationPath object
//  exposed in the dll file HarmonoiseDLL.dll, version 2.2, which implements
//  point-to-point attenuation calculations according to the Harmonoise
//  model.  It allows almost all functions in the underlying dll to be called 
//  from managed C# code.  It also provides some additional functionality,
//  notably allowing segments to be added to a propagation path in random
//  order.
//  
//  The abstract base class in this file does not implement meteorology.
//  Currently the only implementation is in PointToPoint_HarmMet, which 
//  allows setting a, b, c & d directly as well as setting via the me
//  classes defined in the Harmonoise model.
//
//  Further implementations using different assumptions for meteorology
//  may come in the future.
//
//
//  Copyright R Bullen 2012
//  Version 1.0, 4 Feb 2012
//
//---------------------------------------------------------------------------


namespace HarmonoiseInCSharp
{
    #region " Auxiliary classes and enums"

    public class Impedance
    {
        public bool isNull = true;
        public string name = "";
        public bool isUserDefined = false;
        public bool isDB = false;
        public double sigma;
        public double thickness;
        public double[] real;
        public double[] imag;
    }


    public class Segment
    {
        public double x;
        public double y;
        public int impedance;
        public Segment(double xin, double yin, int impedancein)
        {
            x = xin; y = yin; impedance = impedancein;
        }
    }

    public class Path : System.Collections.IEnumerable
    {
        private List<Segment> _path = new List<Segment>();
        public void Add(Segment seg)
        {
            if (seg.x < 0)
            {
                throw new Exception("x value for segment must be >= 0");
            }
            else
            {
                _path.Add(seg);
                _path.Sort(delegate(Segment s1, Segment s2) { return s1.x.CompareTo(s2.x); });
            }
        }
        public int Count
        {
            get { return _path.Count; }
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            return (_path as IEnumerable<Segment>).GetEnumerator();
        }
        public Segment Item(int Index)
        {
            if (Index < 0 || Index >= _path.Count){
                throw new Exception("Invalid segment number");}
            return _path[Index];
        }
        public void Clear()
        {
            _path.Clear();
        }
        public double Length()
        {
            Segment s = _path[_path.Count-1];
            return Math.Sqrt(s.x * s.x + s.y * s.y);
        }
    }

    public enum Model
    {
        Excess_Global,
        Diffraction,
        Ground,
        Ground_Lin,
        Ground_Log,
        Trans_Lin_Log,
        Diffraction_Blos,
        Ground_Blos,
        Diff_Ground_Blos,
        Ground_Flat,
        Trans_Blos_Flat
    }

    public class Detail
    {
        public Model model;
        public int srcSegment;
        public int recSegment;
        public int difSegment;
        public double[] att;
        public Detail(Model Mod, int Src, int Rec, int Dif, double[] Att)
        {
            model = Mod; srcSegment = Src; recSegment = Rec; difSegment = Dif;
            att = Att;
        }
    }

    #endregion

    #region " Main class"

    public abstract class PointToPoint_Base
    {
    #region " Constructor & destructor"

        public PointToPoint_Base()
        {
            _p2pStruct = P2P_Create();
            _options = new OptionsClass(_p2pStruct);
            _impedances = new ImpedanceSet(_p2pStruct, NbFreq);
            _path = new Path();
        }

        ~PointToPoint_Base()
        {
            try
            {
                P2P_Delete(_p2pStruct);
            }
            catch
            {
            }
        }
        #endregion

        #region " Consts and private variables "

        // Values not exposed by P2P interface
        const int NFIXEDIMPEDANCES = 7;
        const int MAX_SEG = 1001;
        const int MAX_IMPEDANCE = 100;

        double _delSrcHt = 0.1;
        double _delRecHt = 0.5;

        protected IntPtr _p2pStruct;  // reference to C++ P2P object
        OptionsClass _options;
        ImpedanceSet _impedances;
        Path _path;

        #endregion

        #region " Link to C++ interface"

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_Create",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr P2P_Create();

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_Delete",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern void P2P_Delete(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetVersionDLL",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetVersionDLL(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetNbFreq",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetNbFreq(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetFreq",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetFreq(IntPtr x, int Index);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetFreqArray",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetFreqArray(IntPtr x, int NFreq, ref double f);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetBandwidth",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetBandwidth(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetBandwidth",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetBandwidth(IntPtr x, double bw);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetOptions",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 P2P_GetOptions(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetOptions",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 P2P_SetOptions(IntPtr x, UInt32 opt);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetSourceHeight",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetSourceHeight(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetSourceHeight",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetSourceHeight(IntPtr x, double h, double dh);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetReceiverHeight",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetReceiverHeight(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetReceiverHeight",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetReceiverHeight(IntPtr x, double h, double dh);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetSoundSpeed",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetSoundSpeed(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetSoundSpeed",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetSoundSpeed(IntPtr x, double h);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetupAirAbsorption",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetupAirAbsorption(IntPtr x, double temp, double hum);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetAirAbsorption",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetAirAbsorption(IntPtr x, ref double a);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetAirAbsorption",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetAirAbsorption(IntPtr x, ref double a);


        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetImpedanceDB",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetImpedanceDB(IntPtr x, int Index, double sigma, double thickness);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetImpedanceRI",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetImpedanceRI(IntPtr x, int Index, ref double Z);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetImpedanceDB",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetImpedanceDB(IntPtr x, int Index, ref double sigma, ref double thickness);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetImpedanceRI",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetImpedanceRI(IntPtr x, int Index, ref double Z);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetSegmentSplitFactor",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetSegmentSplitFactor(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetSegmentSplitFactor",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetSegmentSplitFactor(IntPtr x, int factor);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_Clear",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_Clear(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_AddSegment",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_AddSegment(IntPtr x, double sx, double sy, int impedanceIndex);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetResults",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetResults(IntPtr x, ref double att);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetNbDetails",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetNbDetails(IntPtr x);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetDetails",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetDetails(IntPtr x, int Index, ref int model,
            ref int src, ref int rec, ref int dif, ref double att);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetTimerCPU",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern double P2P_GetTimerCPU(IntPtr x, bool reset);

        #endregion


        #region " Version, frequencies & bandwidth"

        public double VersionDLL
        {
            get { return P2P_GetVersionDLL(_p2pStruct); }
        }

        public int NbFreq
        {
            get { return P2P_GetNbFreq(_p2pStruct); }
        }

        public double[] Freqs
        {
            get
            {
                int n = NbFreq;
                double[] f = new double[n];
                for (int i = 0; i < n; i++) f[i] = P2P_GetFreq(_p2pStruct, i);
                return f;
            }
            set
            {
                int n = value.Length;
                if (P2P_SetFreqArray(_p2pStruct, n, ref value[0]) < n)
                { throw new Exception("Attempt to set too many frequencies"); }
            }
        }

        public double Bandwidth_Octaves
        {
            get { return P2P_GetBandwidth(_p2pStruct); }
            set
            {
                if (P2P_SetBandwidth(_p2pStruct, value) == 0)
                { throw new Exception("Invalid bandwidth"); }
            }
        }
        #endregion

        #region " Source & Receiver Heights"

        public double SourceHeight
        {
            get { return P2P_GetSourceHeight(_p2pStruct); }
            set
            {
                if (P2P_SetSourceHeight(_p2pStruct, value, _delSrcHt) == 0)
                { throw new Exception("Invalid source height"); }
            }
        }

        public double SourceHeightDelta
        {
            get { return _delSrcHt; }
            set
            {
                double Sht = SourceHeight;
                if (P2P_SetSourceHeight(_p2pStruct, Sht, value) == 0)
                { throw new Exception("Invalid source height delta"); }
                _delSrcHt = value;
            }
        }

        public double ReceiverHeight
        {
            get { return P2P_GetReceiverHeight(_p2pStruct); }
            set
            {
                if (P2P_SetReceiverHeight(_p2pStruct, value, _delRecHt) == 0)
                { throw new Exception("Invalid receiver height"); }
            }
        }

        public double ReceiverHeightDelta
        {
            get { return _delRecHt; }
            set
            {
                double Rht = ReceiverHeight;
                if (P2P_SetReceiverHeight(_p2pStruct, Rht, value) == 0)
                { throw new Exception("Invalid receiver height delta"); }
                _delRecHt = value;
            }
        }
        #endregion

        #region " Options"
        // Options are properties of an internal class, which allows setting
        //  and getting by, e.g., p2p.Options.InvRayTracing = true

        public class OptionsClass
        {
            private IntPtr _p2pStruct;

            public OptionsClass(IntPtr p2p) { _p2pStruct = p2p; }

            public bool InvRayTracing
            {
                get { return GetBitValue(0); }
                set { SetBitValue(0, value); }
            }
            public bool EnableAveraging
            {
                get { return GetBitValue(1); }
                set { SetBitValue(1, value); }
            }
            public bool EnableAirAbsorption
            {
                get { return GetBitValue(2); }
                set { SetBitValue(2, value); }
            }
            public bool EnableScattering
            {
                get { return GetBitValue(3); }
                set { SetBitValue(3, value); }
            }
            public bool DifHaddenPierce
            {
                get { return GetBitValue(4); }
                set { SetBitValue(4, value); }
            }
            public bool RandomTerrain
            {
                get { return GetBitValue(5); }
                set { SetBitValue(5, value); }
            }


            private bool GetBitValue(int Index)
            {
                UInt32 mask = P2P_GetOptions(_p2pStruct);
                return (mask & (1 << Index)) != 0;
            }
            private void SetBitValue(int Index, bool value)
            {
                UInt32 mask = P2P_GetOptions(_p2pStruct);
                if (value)
                {
                    mask |= (UInt32)(1 << Index);
                }
                else
                {
                    mask &= (UInt32)~(1 << Index);
                }
                P2P_SetOptions(_p2pStruct, mask);
            }
        }

        public OptionsClass Options
        {
            get { return _options; }
        }
        #endregion"

        #region " Sound Speed and Absorption"

        public double SoundSpeed
        {
            get { return P2P_GetSoundSpeed(_p2pStruct); }
            set
            {
                if (P2P_SetSoundSpeed(_p2pStruct, value) == 0)
                { throw new Exception("Invalid Sound Speed"); }
            }
        }

        public int CalculateAirAbsorption(double Temperature, double RelHumidity)
        {
            return P2P_SetupAirAbsorption(_p2pStruct, Temperature, RelHumidity);
        }

        public double[] AirAbsorption
        {
            get
            {
                int n = NbFreq;
                double[] a = new double[n];
                int i = P2P_GetAirAbsorption(_p2pStruct, ref a[0]);
                return a;
            }
            set
            {
                int n = value.Length;
                if (n != NbFreq)
                {
                    throw new Exception("Invalid number of absorption values supplied - should be " + NbFreq.ToString());
                }
                P2P_SetAirAbsorption(_p2pStruct, ref value[0]);
            }
        }


        #endregion"

        #region " Impedances"

        // Standard impedances are read into an ImpedanceSet class in its constuctor.
        // More can be added, and when they are they are added to the undelying C++ class as well.

        public class ImpedanceSet : System.Collections.IEnumerable
        {
            private IntPtr _p2pStruct;
            private int _nbFreq;
            private List<Impedance> _impedances = new List<Impedance>();

            public ImpedanceSet(IntPtr p2p, int n)
            {
                _p2pStruct = p2p;
                _nbFreq = n;

                // read in the default impedances
                for (int i = 0; i < NFIXEDIMPEDANCES; i++)
                {
                    Impedance Imp = ReadImpedance(i + 1, _nbFreq);
                    if (!Imp.isNull) _impedances.Add(Imp);
                }
            }

            public void Add(double sigma, double thickness, string name)
            {
                if (Count == MAX_IMPEDANCE)
                {
                    throw new Exception("Number of impedances is limirted to " + MAX_IMPEDANCE.ToString());
                }
                Impedance Imp = new Impedance();
                Imp.isNull = false;
                Imp.isDB = true;
                Imp.isUserDefined = true;
                Imp.sigma = sigma;
                Imp.thickness = thickness;
                Imp.name = name;
                _impedances.Add(Imp);

                int index = _impedances.Count;
                int ret = P2P_SetImpedanceDB(_p2pStruct, index, sigma, thickness);
                if (ret == 0) { throw new Exception("Error adding new impedance value"); }
            }
            public void Add(double[] real, double[] imag, string name)
            {
                if (real.Length != _nbFreq || imag.Length != _nbFreq)
                {
                    throw new Exception("Invalid number of impedance values provided");
                }
                Impedance Imp = new Impedance();
                Imp.isNull = false;
                Imp.isDB = false;
                Imp.isUserDefined = true;
                Imp.real = real;
                Imp.imag = imag;
                Imp.name = name;
                _impedances.Add(Imp);

                int index = _impedances.Count;
                double[] Z = new double[_nbFreq * 2];
                for (int i = 0; i < _nbFreq; i++)
                {
                    Z[2 * i] = real[i];
                    Z[2 * i + 1] = imag[i];
                }
                int ret = P2P_SetImpedanceRI(_p2pStruct, index, ref Z[0]);
                if (ret == 0) { throw new Exception("Error adding new impedance value"); }
            }

            public int Count { get { return _impedances.Count; } }

            public System.Collections.IEnumerator GetEnumerator()
            {
                return (_impedances as IEnumerable<Impedance>).GetEnumerator();
            }

            public Impedance Item(int Index)
            {
                if (Index < 0 || Index >= _impedances.Count)
                {
                    throw new Exception("Invalid impedance number");
                }
                return _impedances[Index];
            }


            private Impedance ReadImpedance(int Index, int NbFreq)
            {
                Impedance Imp = new Impedance();
                double sig = 0;
                double th = 0;
                int res = P2P_GetImpedanceDB(_p2pStruct, Index, ref sig, ref th);
                if (res != 0)
                {
                    Imp.isNull = false;
                    Imp.isDB = true;
                    Imp.sigma = sig;
                    Imp.thickness = th;
                    Imp.name = ImpedanceName(sig);
                }
                else
                {
                    double[] Z = new double[2 * NbFreq];
                    res = P2P_GetImpedanceRI(_p2pStruct, Index, ref Z[0]);
                    if (res != 0)
                    {
                        Imp.isNull = false;
                        Imp.isDB = false;
                        for (int i = 0; i < NbFreq; i++)
                        {
                            Imp.real[i] = Z[2 * i];
                            Imp.imag[i] = Z[2 * i + 1];
                        }
                        Imp.name = "Std impedance #" + Index.ToString();
                    }
                }
                return Imp;
            }
            private string ImpedanceName(double sig)
            // provides reasonable names for fixed impedance values
            {
                switch ((int)(sig))
                {
                    case 12:
                        return "Snow";
                    case 32:
                        return "Forest floor";
                    case 80:
                        return "Loose ground";
                    case 200:
                        return "Uncompacted ground";
                    case 500:
                        return "Compacted ground";
                    case 2000:
                        return "Hard compacted ground";
                    case 20000:
                        return "Asphalt, water, etc";
                    default:
                        return "Standard" + sig.ToString();
                }
            }
        }

        public ImpedanceSet Impedances
        {
            get { return _impedances; }
        }
        #endregion

        #region " Propagation path"
        // Implemented as an enumerable class. Segments are not added to the underlying
        //  C++ as they are added to the class - when a calculation is required, all segments
        //   are immediately added to the underlying class before calculating.

        public int SegmentSplitFactor
        {
            get { return P2P_GetSegmentSplitFactor(_p2pStruct); }
            set
            {
                int f = P2P_SetSegmentSplitFactor(_p2pStruct, value);
                if (f == 0) throw new Exception("Invalid segment split factor");
            }
        }

        public Path PropagationPath
        {
            get { return _path; }
        }

        #endregion

        #region " Calcs"

        public double[] DoCalcs()
        {
            //  First check the path is OK, then add segments to model
            if (_path.Count > MAX_SEG)
            {
                throw new Exception("Path has too many segments - maximum is " + MAX_SEG.ToString());
            }
            foreach (Segment s in _path)
            {
                if (s.impedance < 1 || s.impedance > _impedances.Count)
                {
                    throw new Exception("Unknown impedance value: " + s.impedance.ToString());
                }
            }
            P2P_Clear(_p2pStruct);
            foreach (Segment s in _path)
            {
                P2P_AddSegment(_p2pStruct, s.x, s.y, s.impedance);
            }

            double[] att = new double[NbFreq];
            int ret = P2P_GetResults(_p2pStruct, ref att[0]);
            if (ret == 0) { throw new Exception("Error in calculations"); }
            return att;
        }

        public List<Detail> GetDetails()
        {
            List<Detail> L = new List<Detail>();
            int NbDetail = P2P_GetNbDetails(_p2pStruct);
            int NbFreq = P2P_GetNbFreq(_p2pStruct);
            for (int i = 0; i < NbDetail; i++)
            {
                int m = 0;
                int s = 0;
                int r = 0;
                int d = 0;
                double[] att = new double[NbFreq];
                P2P_GetDetails(_p2pStruct, i, ref m, ref s, ref r, ref d, ref att[0]);
                Detail D = new Detail((Model)m, s, r, d, att);
                L.Add(D);
            }
            return L;
        }

        #endregion

        #region " Utility"

        public double GetTimer(bool Reset)
        {
            return P2P_GetTimerCPU(_p2pStruct, Reset);
        }

        #endregion

    }
    #endregion
}



