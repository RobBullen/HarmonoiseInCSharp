using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HarmonoiseInCSharp;

//---------------------------------------------------------------------------
//
//  This program provides a few simple tests of the HarmonoiseInCSharp
//  dll, just to make sure it is communicating with the underlyng C++
//  dll.
//
//  Copyright R Bullen 2012
//  Version 1.0, 4 Feb 2012
//
//---------------------------------------------------------------------------


namespace HarmonoiseInCSharp_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            PointToPoint p2p = new PointToPoint();
            CommonTests(p2p);

            try
            {
                //   Check met parameters can be changed directly, and also changed using
                //    SetMetParameters
                MeteoParameters pSave = p2p.MetParameters;
                MeteoParameters p = new MeteoParameters(5, 5, 5, 5);
                p2p.MetParameters = p;
                MeteoParameters p1 = p2p.MetParameters;
                bool chkProf = true;
                if (p.A != p1.A | p.B != p1.B | p.C != p1.C | p.D != p1.D) chkProf = false;
                chkSetProf.Checked = chkProf;
                p2p.MetParameters = pSave;
                lstSpeedProfile.Items.Clear();
                lstSpeedProfile.Items.Add(pSave.A);
                lstSpeedProfile.Items.Add(pSave.B);
                lstSpeedProfile.Items.Add(pSave.C);
                lstSpeedProfile.Items.Add(pSave.D);

                p2p.SetMetParameters(3, .5, StabClass.Class3, 3, 3);
                p = p2p.MetParameters;
                lstMetsIndirect.Items.Clear();
                lstMetsIndirect.Items.Add(p.A);
                lstMetsIndirect.Items.Add(p.B);
                lstMetsIndirect.Items.Add(p.C);
                lstMetsIndirect.Items.Add(p.D);
                p2p.MetParameters = pSave;

                DoCalcs(p2p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CommonTests(PointToPoint_Base p2p)
        {
            try
            {
                //  1.  Get Version
                chkCreate.Checked = true;
                double v = p2p.VersionDLL;
                txtVersion.Text = v.ToString();

                // 2.  Check frequencies can be set and returned
                bool chkSetF = true;
                double[] Freqs = p2p.Freqs;

                double[] NewFs = { 20, 40, 60, 80, 100 };
                p2p.Freqs = NewFs;
                double[] TestFs = p2p.Freqs;
                if (TestFs.Length != NewFs.Length)
                {
                    chkSetF = false;
                }
                else
                {
                    for (int i = 0; i < TestFs.Length; i++)
                    {
                        if (NewFs[i] != TestFs[i]) chkSetF = false;
                    }
                }
                chkSetFreqs.Checked = chkSetF;

                p2p.Freqs = Freqs;
                int NF = p2p.NbFreq;
                txtNbOfFreqs.Text = NF.ToString();
                lstFreqs.Items.Clear();
                for (int i = 0; i < Freqs.Length; i++)
                {
                    lstFreqs.Items.Add(Freqs[i].ToString());
                }

                // 3.  Check bandwidth can be changed and returned
                bool chkBW = false;
                double bw = p2p.Bandwidth_Octaves;
                p2p.Bandwidth_Octaves = 3.6;
                if (p2p.Bandwidth_Octaves == 3.6) chkBW = true;
                p2p.Bandwidth_Octaves = bw;
                chkSetBW.Checked = chkBW;
                txtBW.Text = p2p.Bandwidth_Octaves.ToString();


                // 4.  Check source height and source height delta can
                //       be changed and returned.  Leave height = 0.1, delta = 0.05
                bool chkSrcHt = false;
                double srcHt = p2p.SourceHeight;
                double srcHtDel = p2p.SourceHeightDelta;
                p2p.SourceHeight = 25;
                p2p.SourceHeightDelta = 30;
                if (p2p.SourceHeight == 25 && p2p.SourceHeightDelta == 30) chkSrcHt = true;
                //p2p.SourceHeight = srcHt;
                p2p.SourceHeight = 0.1;
                p2p.SourceHeightDelta = 0.05;
                chkSetSourceHt.Checked = chkSrcHt;
                txtSourceHt.Text = p2p.SourceHeight.ToString() + ", "
                    + p2p.SourceHeightDelta.ToString();


                // 5.  Check receiver height and receiver height delta can
                //       be changed and returned.  Leave height = 5, delta = 1
                bool chkRecHt = false;
                double recHt = p2p.ReceiverHeight;
                double recHtDel = p2p.ReceiverHeightDelta;
                p2p.ReceiverHeight = 25;
                p2p.ReceiverHeightDelta = 30;
                if (p2p.ReceiverHeight == 25 && p2p.ReceiverHeightDelta == 30) chkRecHt = true;
                //p2p.ReceverHeight = recHt;
                p2p.ReceiverHeight = 5;
                p2p.ReceiverHeightDelta = 1;
                chkSetReceiverHt.Checked = chkRecHt;
                txtReceiverHt.Text = p2p.ReceiverHeight.ToString() + ", "
                    + p2p.ReceiverHeightDelta.ToString();


                //  6.  Check sound speed can be changed and returned
                bool chkSndSp = false;
                double sndSp = p2p.SoundSpeed;
                p2p.SoundSpeed = 320;
                if (p2p.SoundSpeed == 320) chkSndSp = true;
                p2p.SoundSpeed = sndSp;
                chkSetSoundSpeed.Checked = chkSndSp;
                txtSoundSpeed.Text = p2p.SoundSpeed.ToString();


                //  7.  Check all options can be changed and returned
                bool x = p2p.Options.InvRayTracing;
                p2p.Options.InvRayTracing = !x;
                if (p2p.Options.InvRayTracing != !x) { chkInvRayTracing.Enabled = false; }
                p2p.Options.InvRayTracing = x;
                chkInvRayTracing.Checked = p2p.Options.InvRayTracing;

                x = p2p.Options.EnableAveraging;
                p2p.Options.EnableAveraging = !x;
                if (p2p.Options.EnableAveraging == !x) { chkEnableAveraging.Enabled = true; }
                p2p.Options.EnableAveraging = x;
                chkEnableAveraging.Checked = p2p.Options.EnableAveraging;

                x = p2p.Options.EnableAirAbsorption;
                p2p.Options.EnableAirAbsorption = !x;
                if (p2p.Options.EnableAirAbsorption == !x) { chkEnableAirAbsorption.Enabled = true; }
                //p2p.Ops.EnableAirAbsorption = x;
                p2p.Options.EnableAirAbsorption = true;
                chkEnableAirAbsorption.Checked = p2p.Options.EnableAirAbsorption;

                x = p2p.Options.DifHaddenPierce;
                p2p.Options.DifHaddenPierce = !x;
                if (p2p.Options.DifHaddenPierce == !x) { chkDifHaddenPierce.Enabled = true; }
                p2p.Options.DifHaddenPierce = x;
                chkDifHaddenPierce.Checked = p2p.Options.DifHaddenPierce;

                x = p2p.Options.RandomTerrain;
                p2p.Options.RandomTerrain = !x;
                if (p2p.Options.RandomTerrain == !x) { chkRandomTerrain.Enabled = true; }
                p2p.Options.RandomTerrain = x;
                chkRandomTerrain.Checked = p2p.Options.RandomTerrain;


                // 8.  Check air absorption can be changed and returned,
                //      and calculate for 25 degrees, 50% RH
                double[] a = new double[p2p.NbFreq];
                for (int i = 0; i < a.Length; i++) { a[i] = 1.9; }
                p2p.AirAbsorption = a;
                double[] a1 = p2p.AirAbsorption;
                bool chkAbs = true;
                if (a1.Length != a.Length)
                {
                    chkAbs = false;
                }
                else
                {
                    for (int i = 0; i < a1.Length; i++)
                    {
                        if (a1[i] != a[i]) chkAbs = false;
                    }
                }
                chkSetAbs.Checked = chkAbs;

                p2p.CalculateAirAbsorption(25, 50);
                a = p2p.AirAbsorption;
                lstAbs.Items.Clear();
                for (int i = 0; i < a.Length; i++) lstAbs.Items.Add(Math.Round(1000 * a[i], 3).ToString());

                // 9.  Check impedances can be read and added to - both using DB and 
                //      directly using real & imaginary parts (which are stored in two
                //      arrays).
                p2p.Impedances.Add(30, 40, "Test#1");
                double[] real = new double[p2p.NbFreq];
                double[] imag = new double[p2p.NbFreq];
                for (int i = 0; i < p2p.NbFreq; i++)
                {
                    real[i] = 5;
                    imag[i] = 6;
                }
                PointToPoint_HarmMet.ImpedanceSet Impedances = p2p.Impedances;
                Impedances.Add(real, imag, "Test#2");
                lstImpedances.Items.Clear();
                string str;
                foreach (Impedance Imp in Impedances)
                {
                    str = Imp.name;
                    if (Imp.isUserDefined) str = str + ": U "; else str = str + ":  ";
                    if (Imp.isDB)
                    {
                        str = str + "DB " + Imp.sigma.ToString() + " " + Imp.thickness.ToString();
                    }
                    else
                    {
                        str = str + "Z  " + Imp.real[0].ToString() + " " + Imp.imag[0].ToString();
                    }
                    lstImpedances.Items.Add(str);
                }


                // 10.  Check segment split factor can be changed and returned
                bool chkSplit = false;
                int f = p2p.SegmentSplitFactor;
                p2p.SegmentSplitFactor = 110;
                if (p2p.SegmentSplitFactor == 110) chkSplit = true;
                p2p.SegmentSplitFactor = f;
                chkSetSplit.Checked = chkSplit;
                txtSplit.Text = p2p.SegmentSplitFactor.ToString();

                // 11.  Add segments to the propagation path - random order.
                p2p.PropagationPath.Add(new Segment(20, 1, 3));
                p2p.PropagationPath.Add(new Segment(50, 5, 3));
                p2p.PropagationPath.Add(new Segment(30, 4, 3));
                p2p.PropagationPath.Add(new Segment(25, 4, 3));

                lstPath.Items.Clear();
                foreach (Segment s in p2p.PropagationPath)
                {
                    lstPath.Items.Add(s.x.ToString() + "; " + s.y.ToString() + "; " + s.impedance.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoCalcs(PointToPoint_Base p2p)
        {
            //   Do calculations, list attenuations and list details

            try
            {

                double[] att = p2p.DoCalcs();

                lstAttenuations.Items.Clear();
                for (int i = 0; i < att.Length; i++)
                {
                    lstAttenuations.Items.Add(Math.Round(att[i], 1).ToString());
                }

                List<Detail> details = p2p.GetDetails();
                lstDetails.Items.Clear();
                for (int i = 0; i < details.Count; i++)
                {
                    Detail d = details[i];
                    string s = d.model.ToString() + "; " + d.srcSegment.ToString() + "; " +
                        d.recSegment.ToString() + "; " + d.difSegment.ToString();
                    for (int j = 0; j < d.att.Length; j++)
                    {
                        s = s + "; " + Math.Round(d.att[j], 1).ToString();
                    }
                    lstDetails.Items.Add(s);
                }


                //   Read time (usually 0)
                double t = p2p.GetTimer(true);
                txtCalcTime.Text = t.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
