using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

//---------------------------------------------------------------------------
//
//  The main class does not allow for setting 
//  and also implements setting via the Harmonoise tables using wind speed, 
//  wind direction and stability class.  Use of these is not recommended.
//  Class PointToPoint uses algorithms from AERMOD to set a and b. 
//
//  Copyright R Bullen 2012
//  Version 1.0, 4 Feb 2012
//
//---------------------------------------------------------------------------

namespace HarmonoiseInCSharp
{
    #region " Auxiliary classes and enums"

    public class MeteoParameters
    {
        public double A;
        public double B;
        public double C;
        public double D;
        public MeteoParameters() { ;}
        public MeteoParameters(double a, double b, double c, double d)
        {
            A = a; B = b; C = c; D = d;
        }
    }

    public enum StabClass
    {
        Class1, Class2, Class3, Class4, Class5
    }
    #endregion

    #region " Main class"

    public class PointToPoint_HarmMet : PointToPoint_Base
    {
        #region " Link to C++ interface"

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetSoundSpeedProfile",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetSoundSpeedProfile(IntPtr x, double a, double b, double c, double d);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_GetSoundSpeedProfile",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_GetSoundSpeedProfile(IntPtr x, ref double a, ref double b, ref double c, ref double d);

        [DllImport("HarmonoiseDLL.dll", EntryPoint = "P2P_SetupMeteoParameters",
        SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int P2P_SetupMeteoParameters(IntPtr x, double windSpeed, double cosWind, int stabilityClass);

        #endregion

        #region " Met parameters"

        public MeteoParameters MetParameters
        {
            get
            {
                MeteoParameters p = new MeteoParameters();
                int i = P2P_GetSoundSpeedProfile(_p2pStruct, ref p.A, ref p.B, ref p.C, ref p.D);
                return p;
            }
            set
            {
                P2P_SetSoundSpeedProfile(_p2pStruct, value.A, value.B, value.C, value.D);
            }
        }
        public void SetMetParameters(double WindSpeed, double CosWind, StabClass StabilityClass)
        {
            if (CosWind < -1 || CosWind > 1) { throw new Exception("Invalid value for CosWind"); }
            P2P_SetupMeteoParameters(_p2pStruct, WindSpeed, CosWind, (int)StabilityClass);
        }
        public void SetMetParameters(double WindSpeed, double CosWind, StabClass StabilityClass,
            double TurbulenceStrength, double DisplacementHeight)
        {
            SetMetParameters(WindSpeed, CosWind, StabilityClass);
            MeteoParameters M = MetParameters;
            M.C = TurbulenceStrength;
            M.D = DisplacementHeight;
            MetParameters = M;
        }
        #endregion
    }
    #endregion
}
