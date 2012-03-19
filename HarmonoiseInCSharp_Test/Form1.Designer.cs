namespace HarmonoiseInCSharp_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdGo = new System.Windows.Forms.Button();
            this.chkCreate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNbOfFreqs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstFreqs = new System.Windows.Forms.ListBox();
            this.chkSetFreqs = new System.Windows.Forms.CheckBox();
            this.chkSetBW = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBW = new System.Windows.Forms.TextBox();
            this.txtSourceHt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSetSourceHt = new System.Windows.Forms.CheckBox();
            this.txtReceiverHt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSetReceiverHt = new System.Windows.Forms.CheckBox();
            this.txtSoundSpeed = new System.Windows.Forms.TextBox();
            this.chkSetSoundSpeed = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRandomTerrain = new System.Windows.Forms.CheckBox();
            this.chkDifHaddenPierce = new System.Windows.Forms.CheckBox();
            this.chkEnableAirAbsorption = new System.Windows.Forms.CheckBox();
            this.chkEnableAveraging = new System.Windows.Forms.CheckBox();
            this.chkInvRayTracing = new System.Windows.Forms.CheckBox();
            this.chkSetAbs = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstAbs = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkSetProf = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstSpeedProfile = new System.Windows.Forms.ListBox();
            this.lstImpedances = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstPath = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSplit = new System.Windows.Forms.TextBox();
            this.chkSetSplit = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lstAttenuations = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCalcTime = new System.Windows.Forms.TextBox();
            this.lstMetsIndirect = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(60, 19);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(89, 34);
            this.cmdGo.TabIndex = 0;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // chkCreate
            // 
            this.chkCreate.AutoSize = true;
            this.chkCreate.Location = new System.Drawing.Point(295, 25);
            this.chkCreate.Name = "chkCreate";
            this.chkCreate.Size = new System.Drawing.Size(63, 17);
            this.chkCreate.TabIndex = 1;
            this.chkCreate.Text = "Created";
            this.chkCreate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(339, 57);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(48, 20);
            this.txtVersion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Freqs:";
            // 
            // txtNbOfFreqs
            // 
            this.txtNbOfFreqs.Location = new System.Drawing.Point(259, 112);
            this.txtNbOfFreqs.Name = "txtNbOfFreqs";
            this.txtNbOfFreqs.Size = new System.Drawing.Size(48, 20);
            this.txtNbOfFreqs.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Freqs:";
            // 
            // lstFreqs
            // 
            this.lstFreqs.FormattingEnabled = true;
            this.lstFreqs.Location = new System.Drawing.Point(259, 138);
            this.lstFreqs.Name = "lstFreqs";
            this.lstFreqs.Size = new System.Drawing.Size(64, 43);
            this.lstFreqs.TabIndex = 7;
            // 
            // chkSetFreqs
            // 
            this.chkSetFreqs.AutoSize = true;
            this.chkSetFreqs.Location = new System.Drawing.Point(25, 112);
            this.chkSetFreqs.Name = "chkSetFreqs";
            this.chkSetFreqs.Size = new System.Drawing.Size(93, 17);
            this.chkSetFreqs.TabIndex = 8;
            this.chkSetFreqs.Text = "Can Set Freqs";
            this.chkSetFreqs.UseVisualStyleBackColor = true;
            // 
            // chkSetBW
            // 
            this.chkSetBW.AutoSize = true;
            this.chkSetBW.Location = new System.Drawing.Point(25, 219);
            this.chkSetBW.Name = "chkSetBW";
            this.chkSetBW.Size = new System.Drawing.Size(117, 17);
            this.chkSetBW.TabIndex = 9;
            this.chkSetBW.Text = "Can Set Bandwidth";
            this.chkSetBW.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bandwidth, octaves:";
            // 
            // txtBW
            // 
            this.txtBW.Location = new System.Drawing.Point(259, 219);
            this.txtBW.Name = "txtBW";
            this.txtBW.Size = new System.Drawing.Size(48, 20);
            this.txtBW.TabIndex = 11;
            // 
            // txtSourceHt
            // 
            this.txtSourceHt.Location = new System.Drawing.Point(259, 255);
            this.txtSourceHt.Name = "txtSourceHt";
            this.txtSourceHt.Size = new System.Drawing.Size(64, 20);
            this.txtSourceHt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Receiver Ht, del:";
            // 
            // chkSetSourceHt
            // 
            this.chkSetSourceHt.AutoSize = true;
            this.chkSetSourceHt.Location = new System.Drawing.Point(25, 255);
            this.chkSetSourceHt.Name = "chkSetSourceHt";
            this.chkSetSourceHt.Size = new System.Drawing.Size(115, 17);
            this.chkSetSourceHt.TabIndex = 12;
            this.chkSetSourceHt.Text = "Can Set Source Ht";
            this.chkSetSourceHt.UseVisualStyleBackColor = true;
            // 
            // txtReceiverHt
            // 
            this.txtReceiverHt.Location = new System.Drawing.Point(259, 293);
            this.txtReceiverHt.Name = "txtReceiverHt";
            this.txtReceiverHt.Size = new System.Drawing.Size(64, 20);
            this.txtReceiverHt.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Source H, delt:";
            // 
            // chkSetReceiverHt
            // 
            this.chkSetReceiverHt.AutoSize = true;
            this.chkSetReceiverHt.Location = new System.Drawing.Point(25, 292);
            this.chkSetReceiverHt.Name = "chkSetReceiverHt";
            this.chkSetReceiverHt.Size = new System.Drawing.Size(124, 17);
            this.chkSetReceiverHt.TabIndex = 15;
            this.chkSetReceiverHt.Text = "Can Set Receiver Ht";
            this.chkSetReceiverHt.UseVisualStyleBackColor = true;
            // 
            // txtSoundSpeed
            // 
            this.txtSoundSpeed.Location = new System.Drawing.Point(259, 332);
            this.txtSoundSpeed.Name = "txtSoundSpeed";
            this.txtSoundSpeed.Size = new System.Drawing.Size(48, 20);
            this.txtSoundSpeed.TabIndex = 20;
            // 
            // chkSetSoundSpeed
            // 
            this.chkSetSoundSpeed.AutoSize = true;
            this.chkSetSoundSpeed.Location = new System.Drawing.Point(25, 331);
            this.chkSetSoundSpeed.Name = "chkSetSoundSpeed";
            this.chkSetSoundSpeed.Size = new System.Drawing.Size(129, 17);
            this.chkSetSoundSpeed.TabIndex = 19;
            this.chkSetSoundSpeed.Text = "Can Set SoundSpeed";
            this.chkSetSoundSpeed.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Sound speed:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRandomTerrain);
            this.groupBox1.Controls.Add(this.chkDifHaddenPierce);
            this.groupBox1.Controls.Add(this.chkEnableAirAbsorption);
            this.groupBox1.Controls.Add(this.chkEnableAveraging);
            this.groupBox1.Controls.Add(this.chkInvRayTracing);
            this.groupBox1.Location = new System.Drawing.Point(28, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 131);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkRandomTerrain
            // 
            this.chkRandomTerrain.AutoSize = true;
            this.chkRandomTerrain.Location = new System.Drawing.Point(166, 80);
            this.chkRandomTerrain.Name = "chkRandomTerrain";
            this.chkRandomTerrain.Size = new System.Drawing.Size(102, 17);
            this.chkRandomTerrain.TabIndex = 4;
            this.chkRandomTerrain.Text = "Random Terrain";
            this.chkRandomTerrain.UseVisualStyleBackColor = true;
            // 
            // chkDifHaddenPierce
            // 
            this.chkDifHaddenPierce.AutoSize = true;
            this.chkDifHaddenPierce.Location = new System.Drawing.Point(166, 44);
            this.chkDifHaddenPierce.Name = "chkDifHaddenPierce";
            this.chkDifHaddenPierce.Size = new System.Drawing.Size(130, 17);
            this.chkDifHaddenPierce.TabIndex = 3;
            this.chkDifHaddenPierce.Text = "Diff by Hadden-Pierce";
            this.chkDifHaddenPierce.UseVisualStyleBackColor = true;
            // 
            // chkEnableAirAbsorption
            // 
            this.chkEnableAirAbsorption.AutoSize = true;
            this.chkEnableAirAbsorption.Location = new System.Drawing.Point(21, 97);
            this.chkEnableAirAbsorption.Name = "chkEnableAirAbsorption";
            this.chkEnableAirAbsorption.Size = new System.Drawing.Size(95, 17);
            this.chkEnableAirAbsorption.TabIndex = 2;
            this.chkEnableAirAbsorption.Text = "Enable Air Abs";
            this.chkEnableAirAbsorption.UseVisualStyleBackColor = true;
            // 
            // chkEnableAveraging
            // 
            this.chkEnableAveraging.AutoSize = true;
            this.chkEnableAveraging.Location = new System.Drawing.Point(25, 60);
            this.chkEnableAveraging.Name = "chkEnableAveraging";
            this.chkEnableAveraging.Size = new System.Drawing.Size(110, 17);
            this.chkEnableAveraging.TabIndex = 1;
            this.chkEnableAveraging.Text = "Enable Averaging";
            this.chkEnableAveraging.UseVisualStyleBackColor = true;
            // 
            // chkInvRayTracing
            // 
            this.chkInvRayTracing.AutoSize = true;
            this.chkInvRayTracing.Location = new System.Drawing.Point(25, 23);
            this.chkInvRayTracing.Name = "chkInvRayTracing";
            this.chkInvRayTracing.Size = new System.Drawing.Size(102, 17);
            this.chkInvRayTracing.TabIndex = 0;
            this.chkInvRayTracing.Text = "Inv Ray Tracing";
            this.chkInvRayTracing.UseVisualStyleBackColor = true;
            // 
            // chkSetAbs
            // 
            this.chkSetAbs.AutoSize = true;
            this.chkSetAbs.Location = new System.Drawing.Point(439, 36);
            this.chkSetAbs.Name = "chkSetAbs";
            this.chkSetAbs.Size = new System.Drawing.Size(117, 17);
            this.chkSetAbs.TabIndex = 22;
            this.chkSetAbs.Text = "Can Set Absorption";
            this.chkSetAbs.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(436, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Absorption (15 deg, 70%RH)";
            // 
            // lstAbs
            // 
            this.lstAbs.FormattingEnabled = true;
            this.lstAbs.Location = new System.Drawing.Point(438, 90);
            this.lstAbs.Name = "lstAbs";
            this.lstAbs.Size = new System.Drawing.Size(118, 69);
            this.lstAbs.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "db per km:";
            // 
            // chkSetProf
            // 
            this.chkSetProf.AutoSize = true;
            this.chkSetProf.Location = new System.Drawing.Point(375, 192);
            this.chkSetProf.Name = "chkSetProf";
            this.chkSetProf.Size = new System.Drawing.Size(121, 17);
            this.chkSetProf.TabIndex = 26;
            this.chkSetProf.Text = "Can Set Mets Direct";
            this.chkSetProf.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(447, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Profile A, B, C, D";
            // 
            // lstSpeedProfile
            // 
            this.lstSpeedProfile.FormattingEnabled = true;
            this.lstSpeedProfile.Location = new System.Drawing.Point(375, 228);
            this.lstSpeedProfile.Name = "lstSpeedProfile";
            this.lstSpeedProfile.Size = new System.Drawing.Size(102, 56);
            this.lstSpeedProfile.TabIndex = 28;
            // 
            // lstImpedances
            // 
            this.lstImpedances.FormattingEnabled = true;
            this.lstImpedances.Location = new System.Drawing.Point(410, 338);
            this.lstImpedances.Name = "lstImpedances";
            this.lstImpedances.Size = new System.Drawing.Size(203, 147);
            this.lstImpedances.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(407, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Impedances (two user-defined)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(686, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Propagation Path:";
            // 
            // lstPath
            // 
            this.lstPath.FormattingEnabled = true;
            this.lstPath.Location = new System.Drawing.Point(689, 112);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(144, 134);
            this.lstPath.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(782, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Split factor:";
            // 
            // txtSplit
            // 
            this.txtSplit.Location = new System.Drawing.Point(848, 29);
            this.txtSplit.Name = "txtSplit";
            this.txtSplit.Size = new System.Drawing.Size(57, 20);
            this.txtSplit.TabIndex = 35;
            // 
            // chkSetSplit
            // 
            this.chkSetSplit.AutoSize = true;
            this.chkSetSplit.Location = new System.Drawing.Point(661, 32);
            this.chkSetSplit.Name = "chkSetSplit";
            this.chkSetSplit.Size = new System.Drawing.Size(113, 17);
            this.chkSetSplit.TabIndex = 36;
            this.chkSetSplit.Text = "Can set split factor";
            this.chkSetSplit.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(845, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Attenuations:";
            // 
            // lstAttenuations
            // 
            this.lstAttenuations.FormattingEnabled = true;
            this.lstAttenuations.Location = new System.Drawing.Point(848, 112);
            this.lstAttenuations.Name = "lstAttenuations";
            this.lstAttenuations.Size = new System.Drawing.Size(96, 134);
            this.lstAttenuations.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(686, 271);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Details:";
            // 
            // lstDetails
            // 
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.Location = new System.Drawing.Point(689, 293);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(288, 173);
            this.lstDetails.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(686, 489);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Calculation time:";
            // 
            // txtCalcTime
            // 
            this.txtCalcTime.Location = new System.Drawing.Point(776, 486);
            this.txtCalcTime.Name = "txtCalcTime";
            this.txtCalcTime.Size = new System.Drawing.Size(57, 20);
            this.txtCalcTime.TabIndex = 43;
            // 
            // lstMetsIndirect
            // 
            this.lstMetsIndirect.FormattingEnabled = true;
            this.lstMetsIndirect.Location = new System.Drawing.Point(521, 228);
            this.lstMetsIndirect.Name = "lstMetsIndirect";
            this.lstMetsIndirect.Size = new System.Drawing.Size(102, 56);
            this.lstMetsIndirect.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(527, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "Mets Set Indirectly";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(265, 258);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 13);
            this.label18.TabIndex = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 534);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lstMetsIndirect);
            this.Controls.Add(this.txtCalcTime);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lstAttenuations);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkSetSplit);
            this.Controls.Add(this.txtSplit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lstPath);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstImpedances);
            this.Controls.Add(this.lstSpeedProfile);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkSetProf);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lstAbs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkSetAbs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSoundSpeed);
            this.Controls.Add(this.chkSetSoundSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReceiverHt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkSetReceiverHt);
            this.Controls.Add(this.txtSourceHt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkSetSourceHt);
            this.Controls.Add(this.txtBW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSetBW);
            this.Controls.Add(this.chkSetFreqs);
            this.Controls.Add(this.lstFreqs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNbOfFreqs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCreate);
            this.Controls.Add(this.cmdGo);
            this.Name = "Form1";
            this.Text = "HarmonoiseInCSharp - Tester";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.CheckBox chkCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNbOfFreqs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstFreqs;
        private System.Windows.Forms.CheckBox chkSetFreqs;
        private System.Windows.Forms.CheckBox chkSetBW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBW;
        private System.Windows.Forms.TextBox txtSourceHt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSetSourceHt;
        private System.Windows.Forms.TextBox txtReceiverHt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSetReceiverHt;
        private System.Windows.Forms.TextBox txtSoundSpeed;
        private System.Windows.Forms.CheckBox chkSetSoundSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRandomTerrain;
        private System.Windows.Forms.CheckBox chkDifHaddenPierce;
        private System.Windows.Forms.CheckBox chkEnableAirAbsorption;
        private System.Windows.Forms.CheckBox chkEnableAveraging;
        private System.Windows.Forms.CheckBox chkInvRayTracing;
        private System.Windows.Forms.CheckBox chkSetAbs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstAbs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSetProf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstSpeedProfile;
        private System.Windows.Forms.ListBox lstImpedances;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSplit;
        private System.Windows.Forms.CheckBox chkSetSplit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lstAttenuations;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lstDetails;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCalcTime;
        private System.Windows.Forms.ListBox lstMetsIndirect;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}

