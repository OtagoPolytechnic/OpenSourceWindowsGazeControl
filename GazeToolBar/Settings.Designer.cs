using System.Windows.Forms;

namespace GazeToolBar
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.bhavSettingMap = new EyeXFramework.Forms.BehaviorMap(this.components);
            this.btnAutoStart = new System.Windows.Forms.Button();
            this.btnChangeSide = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Label();
            this.btnGaze = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.lblGaze = new System.Windows.Forms.Label();
            this.lblSwitch = new System.Windows.Forms.Label();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.lblFixationDetectionTimeLength = new System.Windows.Forms.Label();
            this.trackBarFixTimeLength = new System.Windows.Forms.TrackBar();
            this.panelPrecision = new System.Windows.Forms.Panel();
            this.btnFixTimeLengthMins = new System.Windows.Forms.Button();
            this.btnFixTimeLengthPlus = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trackBarFixTimeOut = new System.Windows.Forms.TrackBar();
            this.panelSpeed = new System.Windows.Forms.Panel();
            this.btnFixTimeOutMins = new System.Windows.Forms.Button();
            this.btnFixTimeOutPlus = new System.Windows.Forms.Button();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIndicationLeftOrRight = new System.Windows.Forms.Label();
            this.panelOther = new System.Windows.Forms.Panel();
            this.panelGazeTypingSpeed = new System.Windows.Forms.Panel();
            this.btnGzeTypingSpeedPlus = new System.Windows.Forms.Button();
            this.btnGzeTypingSpeedMins = new System.Windows.Forms.Button();
            this.trackBarGazeTypingSpeed = new System.Windows.Forms.TrackBar();
            this.lblGazeTypingSpeed = new System.Windows.Forms.Label();
            this.panelSize = new System.Windows.Forms.Panel();
            this.btnSoundFeedback = new System.Windows.Forms.Button();
            this.lblSoundFeedbackOnOff = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnSizeSmall = new System.Windows.Forms.Button();
            this.lblSoundFeedback = new System.Windows.Forms.Label();
            this.lblSizeSmall = new System.Windows.Forms.Label();
            this.lblLarge = new System.Windows.Forms.Label();
            this.btnSizeLarge = new System.Windows.Forms.Button();
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.btnChangeLanguage = new System.Windows.Forms.Button();
            this.lblWordPredictionOnOffIndiction = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnWordPredictionOnOff = new System.Windows.Forms.Button();
            this.lblCurrentLanguage = new System.Windows.Forms.Label();
            this.lblWordPrediction = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelSaveAndCancel = new System.Windows.Forms.Panel();
            this.pnlPageKeyboard = new System.Windows.Forms.Panel();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.btnGeneralSetting = new System.Windows.Forms.Button();
            this.btnKeyBoardSetting = new System.Windows.Forms.Button();
            this.pnlFixTimeOutContent = new System.Windows.Forms.Panel();
            this.pnlFixTimeLengthContent = new System.Windows.Forms.Panel();
            this.pnlSelectionGaze = new System.Windows.Forms.Panel();
            this.pnlSelectionSwitch = new System.Windows.Forms.Panel();
            this.pnlOtherPosition = new System.Windows.Forms.Panel();
            this.pnlOtherAuto = new System.Windows.Forms.Panel();
            this.panelSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFixTimeLength)).BeginInit();
            this.panelPrecision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFixTimeOut)).BeginInit();
            this.panelSpeed.SuspendLayout();
            this.panelOther.SuspendLayout();
            this.panelGazeTypingSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGazeTypingSpeed)).BeginInit();
            this.panelSize.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.panelSaveAndCancel.SuspendLayout();
            this.pnlPageKeyboard.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.pnlFixTimeOutContent.SuspendLayout();
            this.pnlFixTimeLengthContent.SuspendLayout();
            this.pnlSelectionGaze.SuspendLayout();
            this.pnlSelectionSwitch.SuspendLayout();
            this.pnlOtherPosition.SuspendLayout();
            this.pnlOtherAuto.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.BackColor = System.Drawing.Color.Black;
            this.btnAutoStart.FlatAppearance.BorderSize = 5;
            this.btnAutoStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoStart.ForeColor = System.Drawing.Color.White;
            this.btnAutoStart.Location = new System.Drawing.Point(60, 96);
            this.btnAutoStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Size = new System.Drawing.Size(82, 76);
            this.btnAutoStart.TabIndex = 4;
            this.btnAutoStart.UseVisualStyleBackColor = false;
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // btnChangeSide
            // 
            this.btnChangeSide.BackColor = System.Drawing.Color.Black;
            this.btnChangeSide.FlatAppearance.BorderSize = 5;
            this.btnChangeSide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeSide.ForeColor = System.Drawing.Color.White;
            this.btnChangeSide.Location = new System.Drawing.Point(60, 90);
            this.btnChangeSide.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeSide.Name = "btnChangeSide";
            this.btnChangeSide.Size = new System.Drawing.Size(82, 76);
            this.btnChangeSide.TabIndex = 3;
            this.btnChangeSide.UseVisualStyleBackColor = false;
            this.btnChangeSide.Click += new System.EventHandler(this.btnChangeSide_Click);
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSelection.ForeColor = System.Drawing.Color.White;
            this.lblSelection.Location = new System.Drawing.Point(21, 114);
            this.lblSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(118, 24);
            this.lblSelection.TabIndex = 5;
            this.lblSelection.Text = "Selection";
            // 
            // btnGaze
            // 
            this.btnGaze.BackColor = System.Drawing.Color.Black;
            this.btnGaze.FlatAppearance.BorderSize = 5;
            this.btnGaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaze.ForeColor = System.Drawing.Color.White;
            this.btnGaze.Location = new System.Drawing.Point(60, 74);
            this.btnGaze.Margin = new System.Windows.Forms.Padding(4);
            this.btnGaze.Name = "btnGaze";
            this.btnGaze.Size = new System.Drawing.Size(82, 76);
            this.btnGaze.TabIndex = 6;
            this.btnGaze.UseVisualStyleBackColor = false;
            this.btnGaze.Click += new System.EventHandler(this.btnGaze_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.BackColor = System.Drawing.Color.Black;
            this.btnSwitch.FlatAppearance.BorderSize = 5;
            this.btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitch.ForeColor = System.Drawing.Color.White;
            this.btnSwitch.Location = new System.Drawing.Point(60, 76);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(82, 76);
            this.btnSwitch.TabIndex = 7;
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // lblGaze
            // 
            this.lblGaze.AutoSize = true;
            this.lblGaze.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblGaze.ForeColor = System.Drawing.Color.White;
            this.lblGaze.Location = new System.Drawing.Point(72, 30);
            this.lblGaze.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGaze.Name = "lblGaze";
            this.lblGaze.Size = new System.Drawing.Size(58, 24);
            this.lblGaze.TabIndex = 8;
            this.lblGaze.Text = "Gaze";
            // 
            // lblSwitch
            // 
            this.lblSwitch.AutoSize = true;
            this.lblSwitch.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSwitch.ForeColor = System.Drawing.Color.White;
            this.lblSwitch.Location = new System.Drawing.Point(59, 31);
            this.lblSwitch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSwitch.Name = "lblSwitch";
            this.lblSwitch.Size = new System.Drawing.Size(82, 24);
            this.lblSwitch.TabIndex = 9;
            this.lblSwitch.Text = "Switch";
            // 
            // panelSelection
            // 
            this.panelSelection.BackColor = System.Drawing.Color.Black;
            this.panelSelection.Controls.Add(this.pnlSelectionSwitch);
            this.panelSelection.Controls.Add(this.pnlSelectionGaze);
            this.panelSelection.Controls.Add(this.lblSelection);
            this.panelSelection.Location = new System.Drawing.Point(0, 0);
            this.panelSelection.Margin = new System.Windows.Forms.Padding(4);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(1864, 202);
            this.panelSelection.TabIndex = 10;
            // 
            // lblFixationDetectionTimeLength
            // 
            this.lblFixationDetectionTimeLength.AutoSize = true;
            this.lblFixationDetectionTimeLength.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblFixationDetectionTimeLength.ForeColor = System.Drawing.Color.White;
            this.lblFixationDetectionTimeLength.Location = new System.Drawing.Point(21, 46);
            this.lblFixationDetectionTimeLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixationDetectionTimeLength.Name = "lblFixationDetectionTimeLength";
            this.lblFixationDetectionTimeLength.Size = new System.Drawing.Size(142, 48);
            this.lblFixationDetectionTimeLength.TabIndex = 11;
            this.lblFixationDetectionTimeLength.Text = "Fixation \r\nTime Length";
            // 
            // trackBarFixTimeLength
            // 
            this.trackBarFixTimeLength.Location = new System.Drawing.Point(69, 13);
            this.trackBarFixTimeLength.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarFixTimeLength.Maximum = 8;
            this.trackBarFixTimeLength.Name = "trackBarFixTimeLength";
            this.trackBarFixTimeLength.Size = new System.Drawing.Size(1362, 69);
            this.trackBarFixTimeLength.TabIndex = 12;
            this.trackBarFixTimeLength.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarFixTimeLength.Scroll += new System.EventHandler(this.trackBarPrecision_Scroll);
            // 
            // panelPrecision
            // 
            this.panelPrecision.BackColor = System.Drawing.Color.Black;
            this.panelPrecision.Controls.Add(this.pnlFixTimeLengthContent);
            this.panelPrecision.Controls.Add(this.lblFixationDetectionTimeLength);
            this.panelPrecision.Location = new System.Drawing.Point(0, 231);
            this.panelPrecision.Margin = new System.Windows.Forms.Padding(4);
            this.panelPrecision.Name = "panelPrecision";
            this.panelPrecision.Size = new System.Drawing.Size(1864, 159);
            this.panelPrecision.TabIndex = 13;
            // 
            // btnFixTimeLengthMins
            // 
            this.btnFixTimeLengthMins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFixTimeLengthMins.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFixTimeLengthMins.ForeColor = System.Drawing.Color.White;
            this.btnFixTimeLengthMins.Location = new System.Drawing.Point(0, 13);
            this.btnFixTimeLengthMins.Name = "btnFixTimeLengthMins";
            this.btnFixTimeLengthMins.Size = new System.Drawing.Size(62, 57);
            this.btnFixTimeLengthMins.TabIndex = 14;
            this.btnFixTimeLengthMins.Text = "-";
            this.btnFixTimeLengthMins.UseVisualStyleBackColor = true;
            this.btnFixTimeLengthMins.Click += new System.EventHandler(this.btnFixTimeLengthMins_Click);
            // 
            // btnFixTimeLengthPlus
            // 
            this.btnFixTimeLengthPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFixTimeLengthPlus.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFixTimeLengthPlus.ForeColor = System.Drawing.Color.White;
            this.btnFixTimeLengthPlus.Location = new System.Drawing.Point(1438, 15);
            this.btnFixTimeLengthPlus.Name = "btnFixTimeLengthPlus";
            this.btnFixTimeLengthPlus.Size = new System.Drawing.Size(62, 57);
            this.btnFixTimeLengthPlus.TabIndex = 13;
            this.btnFixTimeLengthPlus.Text = "+";
            this.btnFixTimeLengthPlus.UseVisualStyleBackColor = true;
            this.btnFixTimeLengthPlus.Click += new System.EventHandler(this.btnFixTimeLengthPlus_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSpeed.ForeColor = System.Drawing.Color.White;
            this.lblSpeed.Location = new System.Drawing.Point(21, 43);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(118, 48);
            this.lblSpeed.TabIndex = 14;
            this.lblSpeed.Text = "Fixation \r\nTime Out";
            // 
            // trackBarFixTimeOut
            // 
            this.trackBarFixTimeOut.Location = new System.Drawing.Point(69, 18);
            this.trackBarFixTimeOut.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarFixTimeOut.Maximum = 8;
            this.trackBarFixTimeOut.Name = "trackBarFixTimeOut";
            this.trackBarFixTimeOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarFixTimeOut.Size = new System.Drawing.Size(1362, 69);
            this.trackBarFixTimeOut.TabIndex = 15;
            this.trackBarFixTimeOut.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarFixTimeOut.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // panelSpeed
            // 
            this.panelSpeed.BackColor = System.Drawing.Color.Black;
            this.panelSpeed.Controls.Add(this.pnlFixTimeOutContent);
            this.panelSpeed.Controls.Add(this.lblSpeed);
            this.panelSpeed.Location = new System.Drawing.Point(0, 415);
            this.panelSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.panelSpeed.Name = "panelSpeed";
            this.panelSpeed.Size = new System.Drawing.Size(1864, 163);
            this.panelSpeed.TabIndex = 16;
            // 
            // btnFixTimeOutMins
            // 
            this.btnFixTimeOutMins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFixTimeOutMins.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFixTimeOutMins.ForeColor = System.Drawing.Color.White;
            this.btnFixTimeOutMins.Location = new System.Drawing.Point(0, 20);
            this.btnFixTimeOutMins.Name = "btnFixTimeOutMins";
            this.btnFixTimeOutMins.Size = new System.Drawing.Size(62, 57);
            this.btnFixTimeOutMins.TabIndex = 17;
            this.btnFixTimeOutMins.Text = "-";
            this.btnFixTimeOutMins.UseVisualStyleBackColor = true;
            this.btnFixTimeOutMins.Click += new System.EventHandler(this.btnFixTimeOutMins_Click);
            // 
            // btnFixTimeOutPlus
            // 
            this.btnFixTimeOutPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFixTimeOutPlus.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFixTimeOutPlus.ForeColor = System.Drawing.Color.White;
            this.btnFixTimeOutPlus.Location = new System.Drawing.Point(1438, 20);
            this.btnFixTimeOutPlus.Name = "btnFixTimeOutPlus";
            this.btnFixTimeOutPlus.Size = new System.Drawing.Size(62, 57);
            this.btnFixTimeOutPlus.TabIndex = 16;
            this.btnFixTimeOutPlus.Text = "+";
            this.btnFixTimeOutPlus.UseVisualStyleBackColor = true;
            this.btnFixTimeOutPlus.Click += new System.EventHandler(this.btnFixTimeOutPlus_Click);
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblOther.ForeColor = System.Drawing.Color.White;
            this.lblOther.Location = new System.Drawing.Point(29, 108);
            this.lblOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(70, 24);
            this.lblOther.TabIndex = 17;
            this.lblOther.Text = "Other";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(49, 20);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(106, 24);
            this.lblPosition.TabIndex = 18;
            this.lblPosition.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Auto start";
            // 
            // lblIndicationLeftOrRight
            // 
            this.lblIndicationLeftOrRight.AutoSize = true;
            this.lblIndicationLeftOrRight.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblIndicationLeftOrRight.ForeColor = System.Drawing.Color.White;
            this.lblIndicationLeftOrRight.Location = new System.Drawing.Point(49, 201);
            this.lblIndicationLeftOrRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIndicationLeftOrRight.Name = "lblIndicationLeftOrRight";
            this.lblIndicationLeftOrRight.Size = new System.Drawing.Size(106, 24);
            this.lblIndicationLeftOrRight.TabIndex = 20;
            this.lblIndicationLeftOrRight.Text = "On Right";
            // 
            // panelOther
            // 
            this.panelOther.BackColor = System.Drawing.Color.Black;
            this.panelOther.Controls.Add(this.pnlOtherAuto);
            this.panelOther.Controls.Add(this.pnlOtherPosition);
            this.panelOther.Controls.Add(this.lblOther);
            this.panelOther.Location = new System.Drawing.Point(0, 609);
            this.panelOther.Margin = new System.Windows.Forms.Padding(4);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(1864, 266);
            this.panelOther.TabIndex = 21;
            // 
            // panelGazeTypingSpeed
            // 
            this.panelGazeTypingSpeed.Controls.Add(this.btnGzeTypingSpeedPlus);
            this.panelGazeTypingSpeed.Controls.Add(this.btnGzeTypingSpeedMins);
            this.panelGazeTypingSpeed.Controls.Add(this.trackBarGazeTypingSpeed);
            this.panelGazeTypingSpeed.Controls.Add(this.lblGazeTypingSpeed);
            this.panelGazeTypingSpeed.ForeColor = System.Drawing.Color.White;
            this.panelGazeTypingSpeed.Location = new System.Drawing.Point(14, 472);
            this.panelGazeTypingSpeed.Name = "panelGazeTypingSpeed";
            this.panelGazeTypingSpeed.Size = new System.Drawing.Size(1312, 105);
            this.panelGazeTypingSpeed.TabIndex = 18;
            // 
            // btnGzeTypingSpeedPlus
            // 
            this.btnGzeTypingSpeedPlus.BackColor = System.Drawing.Color.Black;
            this.btnGzeTypingSpeedPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGzeTypingSpeedPlus.Font = new System.Drawing.Font("SimSun", 24F);
            this.btnGzeTypingSpeedPlus.ForeColor = System.Drawing.Color.White;
            this.btnGzeTypingSpeedPlus.Location = new System.Drawing.Point(1221, 20);
            this.btnGzeTypingSpeedPlus.Name = "btnGzeTypingSpeedPlus";
            this.btnGzeTypingSpeedPlus.Size = new System.Drawing.Size(62, 57);
            this.btnGzeTypingSpeedPlus.TabIndex = 19;
            this.btnGzeTypingSpeedPlus.Text = "+";
            this.btnGzeTypingSpeedPlus.UseVisualStyleBackColor = false;
            this.btnGzeTypingSpeedPlus.Click += new System.EventHandler(this.btnGzeTypingSpeedPlus_Click);
            // 
            // btnGzeTypingSpeedMins
            // 
            this.btnGzeTypingSpeedMins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGzeTypingSpeedMins.Font = new System.Drawing.Font("SimSun", 24F);
            this.btnGzeTypingSpeedMins.ForeColor = System.Drawing.Color.White;
            this.btnGzeTypingSpeedMins.Location = new System.Drawing.Point(308, 18);
            this.btnGzeTypingSpeedMins.Name = "btnGzeTypingSpeedMins";
            this.btnGzeTypingSpeedMins.Size = new System.Drawing.Size(62, 57);
            this.btnGzeTypingSpeedMins.TabIndex = 20;
            this.btnGzeTypingSpeedMins.Text = "-";
            this.btnGzeTypingSpeedMins.UseVisualStyleBackColor = true;
            this.btnGzeTypingSpeedMins.Click += new System.EventHandler(this.btnGzeTypingSpeedMins_Click);
            // 
            // trackBarGazeTypingSpeed
            // 
            this.trackBarGazeTypingSpeed.Location = new System.Drawing.Point(399, 20);
            this.trackBarGazeTypingSpeed.Maximum = 8;
            this.trackBarGazeTypingSpeed.Name = "trackBarGazeTypingSpeed";
            this.trackBarGazeTypingSpeed.Size = new System.Drawing.Size(798, 69);
            this.trackBarGazeTypingSpeed.TabIndex = 17;
            this.trackBarGazeTypingSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarGazeTypingSpeed.Scroll += new System.EventHandler(this.trackBarGazeTypingSpeed_Scroll);
            // 
            // lblGazeTypingSpeed
            // 
            this.lblGazeTypingSpeed.AutoSize = true;
            this.lblGazeTypingSpeed.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblGazeTypingSpeed.Location = new System.Drawing.Point(21, 42);
            this.lblGazeTypingSpeed.Name = "lblGazeTypingSpeed";
            this.lblGazeTypingSpeed.Size = new System.Drawing.Size(214, 24);
            this.lblGazeTypingSpeed.TabIndex = 16;
            this.lblGazeTypingSpeed.Text = "Gaze Typing Speed";
            // 
            // panelSize
            // 
            this.panelSize.Controls.Add(this.btnSoundFeedback);
            this.panelSize.Controls.Add(this.lblSoundFeedbackOnOff);
            this.panelSize.Controls.Add(this.lblSize);
            this.panelSize.Controls.Add(this.btnSizeSmall);
            this.panelSize.Controls.Add(this.lblSoundFeedback);
            this.panelSize.Controls.Add(this.lblSizeSmall);
            this.panelSize.Controls.Add(this.lblLarge);
            this.panelSize.Controls.Add(this.btnSizeLarge);
            this.panelSize.ForeColor = System.Drawing.Color.White;
            this.panelSize.Location = new System.Drawing.Point(14, 233);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(1312, 149);
            this.panelSize.TabIndex = 15;
            // 
            // btnSoundFeedback
            // 
            this.btnSoundFeedback.FlatAppearance.BorderSize = 5;
            this.btnSoundFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoundFeedback.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnSoundFeedback.Location = new System.Drawing.Point(1142, 77);
            this.btnSoundFeedback.Name = "btnSoundFeedback";
            this.btnSoundFeedback.Size = new System.Drawing.Size(55, 55);
            this.btnSoundFeedback.TabIndex = 13;
            this.btnSoundFeedback.UseVisualStyleBackColor = true;
            this.btnSoundFeedback.Click += new System.EventHandler(this.btnSoundFeedback_Click);
            // 
            // lblSoundFeedbackOnOff
            // 
            this.lblSoundFeedbackOnOff.AutoSize = true;
            this.lblSoundFeedbackOnOff.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSoundFeedbackOnOff.Location = new System.Drawing.Point(1145, 31);
            this.lblSoundFeedbackOnOff.Name = "lblSoundFeedbackOnOff";
            this.lblSoundFeedbackOnOff.Size = new System.Drawing.Size(46, 24);
            this.lblSoundFeedbackOnOff.TabIndex = 14;
            this.lblSoundFeedbackOnOff.Text = "Off";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSize.Location = new System.Drawing.Point(63, 92);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(58, 24);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "Size";
            // 
            // btnSizeSmall
            // 
            this.btnSizeSmall.FlatAppearance.BorderSize = 5;
            this.btnSizeSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeSmall.Location = new System.Drawing.Point(294, 77);
            this.btnSizeSmall.Name = "btnSizeSmall";
            this.btnSizeSmall.Size = new System.Drawing.Size(55, 55);
            this.btnSizeSmall.TabIndex = 8;
            this.btnSizeSmall.UseVisualStyleBackColor = true;
            this.btnSizeSmall.Click += new System.EventHandler(this.btnSizeSmall_Click);
            // 
            // lblSoundFeedback
            // 
            this.lblSoundFeedback.AutoSize = true;
            this.lblSoundFeedback.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSoundFeedback.Location = new System.Drawing.Point(915, 97);
            this.lblSoundFeedback.Name = "lblSoundFeedback";
            this.lblSoundFeedback.Size = new System.Drawing.Size(178, 24);
            this.lblSoundFeedback.TabIndex = 12;
            this.lblSoundFeedback.Text = "Sound Feedback";
            // 
            // lblSizeSmall
            // 
            this.lblSizeSmall.AutoSize = true;
            this.lblSizeSmall.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSizeSmall.Location = new System.Drawing.Point(290, 31);
            this.lblSizeSmall.Name = "lblSizeSmall";
            this.lblSizeSmall.Size = new System.Drawing.Size(70, 24);
            this.lblSizeSmall.TabIndex = 9;
            this.lblSizeSmall.Text = "Small";
            // 
            // lblLarge
            // 
            this.lblLarge.AutoSize = true;
            this.lblLarge.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblLarge.Location = new System.Drawing.Point(549, 28);
            this.lblLarge.Name = "lblLarge";
            this.lblLarge.Size = new System.Drawing.Size(70, 24);
            this.lblLarge.TabIndex = 11;
            this.lblLarge.Text = "Large";
            // 
            // btnSizeLarge
            // 
            this.btnSizeLarge.FlatAppearance.BorderSize = 5;
            this.btnSizeLarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeLarge.Location = new System.Drawing.Point(553, 74);
            this.btnSizeLarge.Name = "btnSizeLarge";
            this.btnSizeLarge.Size = new System.Drawing.Size(55, 55);
            this.btnSizeLarge.TabIndex = 10;
            this.btnSizeLarge.UseVisualStyleBackColor = true;
            this.btnSizeLarge.Click += new System.EventHandler(this.btnSizeLarge_Click);
            // 
            // panelLanguage
            // 
            this.panelLanguage.Controls.Add(this.btnChangeLanguage);
            this.panelLanguage.Controls.Add(this.lblWordPredictionOnOffIndiction);
            this.panelLanguage.Controls.Add(this.lblLanguage);
            this.panelLanguage.Controls.Add(this.btnWordPredictionOnOff);
            this.panelLanguage.Controls.Add(this.lblCurrentLanguage);
            this.panelLanguage.Controls.Add(this.lblWordPrediction);
            this.panelLanguage.ForeColor = System.Drawing.Color.White;
            this.panelLanguage.Location = new System.Drawing.Point(14, 26);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(1312, 129);
            this.panelLanguage.TabIndex = 6;
            // 
            // btnChangeLanguage
            // 
            this.btnChangeLanguage.FlatAppearance.BorderSize = 2;
            this.btnChangeLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLanguage.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnChangeLanguage.Location = new System.Drawing.Point(508, 41);
            this.btnChangeLanguage.Name = "btnChangeLanguage";
            this.btnChangeLanguage.Size = new System.Drawing.Size(152, 71);
            this.btnChangeLanguage.TabIndex = 2;
            this.btnChangeLanguage.Text = "Change";
            this.btnChangeLanguage.UseVisualStyleBackColor = true;
            this.btnChangeLanguage.Click += new System.EventHandler(this.btnChangeLanguage_Click);
            // 
            // lblWordPredictionOnOffIndiction
            // 
            this.lblWordPredictionOnOffIndiction.AutoSize = true;
            this.lblWordPredictionOnOffIndiction.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblWordPredictionOnOffIndiction.Location = new System.Drawing.Point(1145, 10);
            this.lblWordPredictionOnOffIndiction.Name = "lblWordPredictionOnOffIndiction";
            this.lblWordPredictionOnOffIndiction.Size = new System.Drawing.Size(46, 24);
            this.lblWordPredictionOnOffIndiction.TabIndex = 5;
            this.lblWordPredictionOnOffIndiction.Text = "Off";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblLanguage.ForeColor = System.Drawing.Color.White;
            this.lblLanguage.Location = new System.Drawing.Point(153, 68);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(106, 24);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "Language";
            // 
            // btnWordPredictionOnOff
            // 
            this.btnWordPredictionOnOff.FlatAppearance.BorderSize = 5;
            this.btnWordPredictionOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWordPredictionOnOff.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnWordPredictionOnOff.Location = new System.Drawing.Point(1142, 49);
            this.btnWordPredictionOnOff.Name = "btnWordPredictionOnOff";
            this.btnWordPredictionOnOff.Size = new System.Drawing.Size(55, 55);
            this.btnWordPredictionOnOff.TabIndex = 4;
            this.btnWordPredictionOnOff.UseVisualStyleBackColor = true;
            this.btnWordPredictionOnOff.Click += new System.EventHandler(this.btnWordPredictionOnOff_Click);
            // 
            // lblCurrentLanguage
            // 
            this.lblCurrentLanguage.AutoSize = true;
            this.lblCurrentLanguage.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblCurrentLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblCurrentLanguage.Location = new System.Drawing.Point(265, 56);
            this.lblCurrentLanguage.Name = "lblCurrentLanguage";
            this.lblCurrentLanguage.Size = new System.Drawing.Size(190, 48);
            this.lblCurrentLanguage.TabIndex = 1;
            this.lblCurrentLanguage.Text = "    English\r\n(United States)";
            // 
            // lblWordPrediction
            // 
            this.lblWordPrediction.AutoSize = true;
            this.lblWordPrediction.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblWordPrediction.Location = new System.Drawing.Point(903, 64);
            this.lblWordPrediction.Name = "lblWordPrediction";
            this.lblWordPrediction.Size = new System.Drawing.Size(190, 24);
            this.lblWordPrediction.TabIndex = 3;
            this.lblWordPrediction.Text = "Word Prediction";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 3;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(26, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 55);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 3;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(326, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(196, 55);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelSaveAndCancel
            // 
            this.panelSaveAndCancel.Controls.Add(this.btnSave);
            this.panelSaveAndCancel.Controls.Add(this.btnCancel);
            this.panelSaveAndCancel.Location = new System.Drawing.Point(464, 883);
            this.panelSaveAndCancel.Name = "panelSaveAndCancel";
            this.panelSaveAndCancel.Size = new System.Drawing.Size(546, 100);
            this.panelSaveAndCancel.TabIndex = 25;
            // 
            // pnlPageKeyboard
            // 
            this.pnlPageKeyboard.Controls.Add(this.panelLanguage);
            this.pnlPageKeyboard.Controls.Add(this.panelGazeTypingSpeed);
            this.pnlPageKeyboard.Controls.Add(this.panelSize);
            this.pnlPageKeyboard.Location = new System.Drawing.Point(12, 84);
            this.pnlPageKeyboard.Name = "pnlPageKeyboard";
            this.pnlPageKeyboard.Size = new System.Drawing.Size(1394, 589);
            this.pnlPageKeyboard.TabIndex = 26;
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.Color.Black;
            this.pnlGeneral.Controls.Add(this.panelSelection);
            this.pnlGeneral.Controls.Add(this.panelSpeed);
            this.pnlGeneral.Controls.Add(this.panelOther);
            this.pnlGeneral.Controls.Add(this.panelPrecision);
            this.pnlGeneral.Location = new System.Drawing.Point(18, 116);
            this.pnlGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(1989, 897);
            this.pnlGeneral.TabIndex = 27;
            // 
            // btnGeneralSetting
            // 
            this.btnGeneralSetting.BackColor = System.Drawing.Color.Black;
            this.btnGeneralSetting.FlatAppearance.BorderSize = 5;
            this.btnGeneralSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralSetting.ForeColor = System.Drawing.Color.White;
            this.btnGeneralSetting.Location = new System.Drawing.Point(12, 12);
            this.btnGeneralSetting.Name = "btnGeneralSetting";
            this.btnGeneralSetting.Size = new System.Drawing.Size(220, 66);
            this.btnGeneralSetting.TabIndex = 28;
            this.btnGeneralSetting.Text = "General Setting";
            this.btnGeneralSetting.UseVisualStyleBackColor = false;
            this.btnGeneralSetting.Click += new System.EventHandler(this.btnGeneralSetting_Click);
            // 
            // btnKeyBoardSetting
            // 
            this.btnKeyBoardSetting.FlatAppearance.BorderSize = 5;
            this.btnKeyBoardSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBoardSetting.ForeColor = System.Drawing.Color.White;
            this.btnKeyBoardSetting.Location = new System.Drawing.Point(238, 12);
            this.btnKeyBoardSetting.Name = "btnKeyBoardSetting";
            this.btnKeyBoardSetting.Size = new System.Drawing.Size(220, 66);
            this.btnKeyBoardSetting.TabIndex = 29;
            this.btnKeyBoardSetting.Text = "Keyboard Setting";
            this.btnKeyBoardSetting.UseVisualStyleBackColor = true;
            this.btnKeyBoardSetting.Click += new System.EventHandler(this.btnKeyBoardSetting_Click);
            // 
            // pnlFixTimeOutContent
            // 
            this.pnlFixTimeOutContent.BackColor = System.Drawing.Color.Black;
            this.pnlFixTimeOutContent.Controls.Add(this.btnFixTimeOutMins);
            this.pnlFixTimeOutContent.Controls.Add(this.btnFixTimeOutPlus);
            this.pnlFixTimeOutContent.Controls.Add(this.trackBarFixTimeOut);
            this.pnlFixTimeOutContent.Location = new System.Drawing.Point(261, 25);
            this.pnlFixTimeOutContent.Name = "pnlFixTimeOutContent";
            this.pnlFixTimeOutContent.Size = new System.Drawing.Size(1500, 100);
            this.pnlFixTimeOutContent.TabIndex = 22;
            // 
            // pnlFixTimeLengthContent
            // 
            this.pnlFixTimeLengthContent.BackColor = System.Drawing.Color.Black;
            this.pnlFixTimeLengthContent.Controls.Add(this.btnFixTimeLengthMins);
            this.pnlFixTimeLengthContent.Controls.Add(this.btnFixTimeLengthPlus);
            this.pnlFixTimeLengthContent.Controls.Add(this.trackBarFixTimeLength);
            this.pnlFixTimeLengthContent.Location = new System.Drawing.Point(258, 28);
            this.pnlFixTimeLengthContent.Name = "pnlFixTimeLengthContent";
            this.pnlFixTimeLengthContent.Size = new System.Drawing.Size(1500, 100);
            this.pnlFixTimeLengthContent.TabIndex = 22;
            // 
            // pnlSelectionGaze
            // 
            this.pnlSelectionGaze.BackColor = System.Drawing.Color.Black;
            this.pnlSelectionGaze.Controls.Add(this.btnGaze);
            this.pnlSelectionGaze.Controls.Add(this.lblGaze);
            this.pnlSelectionGaze.Location = new System.Drawing.Point(570, 16);
            this.pnlSelectionGaze.Name = "pnlSelectionGaze";
            this.pnlSelectionGaze.Size = new System.Drawing.Size(200, 175);
            this.pnlSelectionGaze.TabIndex = 22;
            // 
            // pnlSelectionSwitch
            // 
            this.pnlSelectionSwitch.BackColor = System.Drawing.Color.Black;
            this.pnlSelectionSwitch.Controls.Add(this.btnSwitch);
            this.pnlSelectionSwitch.Controls.Add(this.lblSwitch);
            this.pnlSelectionSwitch.Location = new System.Drawing.Point(1649, 14);
            this.pnlSelectionSwitch.Name = "pnlSelectionSwitch";
            this.pnlSelectionSwitch.Size = new System.Drawing.Size(200, 177);
            this.pnlSelectionSwitch.TabIndex = 22;
            // 
            // pnlOtherPosition
            // 
            this.pnlOtherPosition.BackColor = System.Drawing.Color.Black;
            this.pnlOtherPosition.Controls.Add(this.btnChangeSide);
            this.pnlOtherPosition.Controls.Add(this.lblIndicationLeftOrRight);
            this.pnlOtherPosition.Controls.Add(this.lblPosition);
            this.pnlOtherPosition.Location = new System.Drawing.Point(1077, 12);
            this.pnlOtherPosition.Name = "pnlOtherPosition";
            this.pnlOtherPosition.Size = new System.Drawing.Size(159, 246);
            this.pnlOtherPosition.TabIndex = 22;
            // 
            // pnlOtherAuto
            // 
            this.pnlOtherAuto.BackColor = System.Drawing.Color.Black;
            this.pnlOtherAuto.Controls.Add(this.label2);
            this.pnlOtherAuto.Controls.Add(this.btnAutoStart);
            this.pnlOtherAuto.Location = new System.Drawing.Point(1690, 12);
            this.pnlOtherAuto.Name = "pnlOtherAuto";
            this.pnlOtherAuto.Size = new System.Drawing.Size(174, 246);
            this.pnlOtherAuto.TabIndex = 22;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2020, 1141);
            this.Controls.Add(this.btnKeyBoardSetting);
            this.Controls.Add(this.btnGeneralSetting);
            this.Controls.Add(this.panelSaveAndCancel);
            this.Controls.Add(this.pnlGeneral);
            this.Controls.Add(this.pnlPageKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFixTimeLength)).EndInit();
            this.panelPrecision.ResumeLayout(false);
            this.panelPrecision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFixTimeOut)).EndInit();
            this.panelSpeed.ResumeLayout(false);
            this.panelSpeed.PerformLayout();
            this.panelOther.ResumeLayout(false);
            this.panelOther.PerformLayout();
            this.panelGazeTypingSpeed.ResumeLayout(false);
            this.panelGazeTypingSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGazeTypingSpeed)).EndInit();
            this.panelSize.ResumeLayout(false);
            this.panelSize.PerformLayout();
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguage.PerformLayout();
            this.panelSaveAndCancel.ResumeLayout(false);
            this.pnlPageKeyboard.ResumeLayout(false);
            this.pnlGeneral.ResumeLayout(false);
            this.pnlFixTimeOutContent.ResumeLayout(false);
            this.pnlFixTimeOutContent.PerformLayout();
            this.pnlFixTimeLengthContent.ResumeLayout(false);
            this.pnlFixTimeLengthContent.PerformLayout();
            this.pnlSelectionGaze.ResumeLayout(false);
            this.pnlSelectionGaze.PerformLayout();
            this.pnlSelectionSwitch.ResumeLayout(false);
            this.pnlSelectionSwitch.PerformLayout();
            this.pnlOtherPosition.ResumeLayout(false);
            this.pnlOtherPosition.PerformLayout();
            this.pnlOtherAuto.ResumeLayout(false);
            this.pnlOtherAuto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutoStart;
        private System.Windows.Forms.Button btnChangeSide;
        private Label lblSelection;
        private Button btnGaze;
        private Button btnSwitch;
        private Label lblGaze;
        private Label lblSwitch;
        private Panel panelSelection;
        private Label lblFixationDetectionTimeLength;
        private TrackBar trackBarFixTimeLength;
        private Panel panelPrecision;
        private Label lblSpeed;
        private TrackBar trackBarFixTimeOut;
        private Panel panelSpeed;
        private Label lblOther;
        private Label lblPosition;
        private Label label2;
        private Label lblIndicationLeftOrRight;
        private Panel panelOther;
        private Label lblLarge;
        private Button btnSizeLarge;
        private Label lblSizeSmall;
        private Button btnSizeSmall;
        private Label lblSize;
        private Panel panelLanguage;
        private Button btnChangeLanguage;
        private Label lblWordPredictionOnOffIndiction;
        private Label lblLanguage;
        private Button btnWordPredictionOnOff;
        private Label lblCurrentLanguage;
        private Label lblWordPrediction;
        private Panel panelGazeTypingSpeed;
        private TrackBar trackBarGazeTypingSpeed;
        private Label lblGazeTypingSpeed;
        private Panel panelSize;
        private Button btnSoundFeedback;
        private Label lblSoundFeedbackOnOff;
        private Label lblSoundFeedback;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelSaveAndCancel;
        private EyeXFramework.Forms.BehaviorMap bhavSettingMap;
        private Panel pnlPageKeyboard;
        private Panel pnlGeneral;
        private Button btnGeneralSetting;
        private Button btnKeyBoardSetting;
        private Button btnFixTimeLengthMins;
        private Button btnFixTimeLengthPlus;
        private Button btnFixTimeOutMins;
        private Button btnFixTimeOutPlus;
        private Button btnGzeTypingSpeedMins;
        private Button btnGzeTypingSpeedPlus;
        private Panel pnlSelectionSwitch;
        private Panel pnlSelectionGaze;
        private Panel pnlFixTimeLengthContent;
        private Panel pnlFixTimeOutContent;
        private Panel pnlOtherAuto;
        private Panel pnlOtherPosition;
    }
}