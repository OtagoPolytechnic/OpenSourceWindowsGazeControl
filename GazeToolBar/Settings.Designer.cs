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
            this.lblPrecision = new System.Windows.Forms.Label();
            this.trackBarPrecision = new System.Windows.Forms.TrackBar();
            this.panelPrecision = new System.Windows.Forms.Panel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.panelSpeed = new System.Windows.Forms.Panel();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIndicationLeftOrRight = new System.Windows.Forms.Label();
            this.panelOther = new System.Windows.Forms.Panel();
            this.panelGazeTypingSpeed = new System.Windows.Forms.Panel();
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
            this.panelSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).BeginInit();
            this.panelPrecision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.panelSpeed.SuspendLayout();
            this.panelOther.SuspendLayout();
            this.panelGazeTypingSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGazeTypingSpeed)).BeginInit();
            this.panelSize.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.panelSaveAndCancel.SuspendLayout();
            this.pnlPageKeyboard.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.BackColor = System.Drawing.Color.Black;
            this.btnAutoStart.FlatAppearance.BorderSize = 5;
            this.btnAutoStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoStart.ForeColor = System.Drawing.Color.White;
            this.btnAutoStart.Location = new System.Drawing.Point(287, 66);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Size = new System.Drawing.Size(55, 55);
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
            this.btnChangeSide.Location = new System.Drawing.Point(157, 66);
            this.btnChangeSide.Name = "btnChangeSide";
            this.btnChangeSide.Size = new System.Drawing.Size(55, 55);
            this.btnChangeSide.TabIndex = 3;
            this.btnChangeSide.UseVisualStyleBackColor = false;
            this.btnChangeSide.Click += new System.EventHandler(this.btnChangeSide_Click);
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSelection.ForeColor = System.Drawing.Color.White;
            this.lblSelection.Location = new System.Drawing.Point(14, 82);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(80, 16);
            this.lblSelection.TabIndex = 5;
            this.lblSelection.Text = "Selection";
            // 
            // btnGaze
            // 
            this.btnGaze.BackColor = System.Drawing.Color.Black;
            this.btnGaze.FlatAppearance.BorderSize = 5;
            this.btnGaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaze.ForeColor = System.Drawing.Color.White;
            this.btnGaze.Location = new System.Drawing.Point(156, 70);
            this.btnGaze.Name = "btnGaze";
            this.btnGaze.Size = new System.Drawing.Size(55, 55);
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
            this.btnSwitch.Location = new System.Drawing.Point(255, 70);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(55, 55);
            this.btnSwitch.TabIndex = 7;
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // lblGaze
            // 
            this.lblGaze.AutoSize = true;
            this.lblGaze.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblGaze.ForeColor = System.Drawing.Color.White;
            this.lblGaze.Location = new System.Drawing.Point(153, 19);
            this.lblGaze.Name = "lblGaze";
            this.lblGaze.Size = new System.Drawing.Size(40, 16);
            this.lblGaze.TabIndex = 8;
            this.lblGaze.Text = "Gaze";
            // 
            // lblSwitch
            // 
            this.lblSwitch.AutoSize = true;
            this.lblSwitch.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSwitch.ForeColor = System.Drawing.Color.White;
            this.lblSwitch.Location = new System.Drawing.Point(241, 17);
            this.lblSwitch.Name = "lblSwitch";
            this.lblSwitch.Size = new System.Drawing.Size(56, 16);
            this.lblSwitch.TabIndex = 9;
            this.lblSwitch.Text = "Switch";
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.btnSwitch);
            this.panelSelection.Controls.Add(this.lblSwitch);
            this.panelSelection.Controls.Add(this.lblSelection);
            this.panelSelection.Controls.Add(this.lblGaze);
            this.panelSelection.Controls.Add(this.btnGaze);
            this.panelSelection.Location = new System.Drawing.Point(3, 3);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(341, 146);
            this.panelSelection.TabIndex = 10;
            // 
            // lblPrecision
            // 
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblPrecision.ForeColor = System.Drawing.Color.White;
            this.lblPrecision.Location = new System.Drawing.Point(14, 49);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(80, 16);
            this.lblPrecision.TabIndex = 11;
            this.lblPrecision.Text = "Precision";
            // 
            // trackBarPrecision
            // 
            this.trackBarPrecision.Location = new System.Drawing.Point(156, 31);
            this.trackBarPrecision.Maximum = 8;
            this.trackBarPrecision.Name = "trackBarPrecision";
            this.trackBarPrecision.Size = new System.Drawing.Size(1074, 45);
            this.trackBarPrecision.TabIndex = 12;
            this.trackBarPrecision.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarPrecision.Scroll += new System.EventHandler(this.trackBarPrecision_Scroll);
            // 
            // panelPrecision
            // 
            this.panelPrecision.Controls.Add(this.trackBarPrecision);
            this.panelPrecision.Controls.Add(this.lblPrecision);
            this.panelPrecision.Location = new System.Drawing.Point(3, 167);
            this.panelPrecision.Name = "panelPrecision";
            this.panelPrecision.Size = new System.Drawing.Size(1243, 115);
            this.panelPrecision.TabIndex = 13;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSpeed.ForeColor = System.Drawing.Color.White;
            this.lblSpeed.Location = new System.Drawing.Point(62, 43);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(48, 16);
            this.lblSpeed.TabIndex = 14;
            this.lblSpeed.Text = "Speed";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(156, 22);
            this.trackBarSpeed.Maximum = 8;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarSpeed.Size = new System.Drawing.Size(1074, 45);
            this.trackBarSpeed.TabIndex = 15;
            this.trackBarSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // panelSpeed
            // 
            this.panelSpeed.Controls.Add(this.trackBarSpeed);
            this.panelSpeed.Controls.Add(this.lblSpeed);
            this.panelSpeed.Location = new System.Drawing.Point(3, 300);
            this.panelSpeed.Name = "panelSpeed";
            this.panelSpeed.Size = new System.Drawing.Size(1243, 118);
            this.panelSpeed.TabIndex = 16;
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblOther.ForeColor = System.Drawing.Color.White;
            this.lblOther.Location = new System.Drawing.Point(62, 78);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(48, 16);
            this.lblOther.TabIndex = 17;
            this.lblOther.Text = "Other";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(140, 9);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(72, 16);
            this.lblPosition.TabIndex = 18;
            this.lblPosition.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(273, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Auto start";
            // 
            // lblIndicationLeftOrRight
            // 
            this.lblIndicationLeftOrRight.AutoSize = true;
            this.lblIndicationLeftOrRight.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblIndicationLeftOrRight.ForeColor = System.Drawing.Color.White;
            this.lblIndicationLeftOrRight.Location = new System.Drawing.Point(140, 150);
            this.lblIndicationLeftOrRight.Name = "lblIndicationLeftOrRight";
            this.lblIndicationLeftOrRight.Size = new System.Drawing.Size(72, 16);
            this.lblIndicationLeftOrRight.TabIndex = 20;
            this.lblIndicationLeftOrRight.Text = "On Right";
            // 
            // panelOther
            // 
            this.panelOther.Controls.Add(this.btnAutoStart);
            this.panelOther.Controls.Add(this.lblIndicationLeftOrRight);
            this.panelOther.Controls.Add(this.btnChangeSide);
            this.panelOther.Controls.Add(this.label2);
            this.panelOther.Controls.Add(this.lblOther);
            this.panelOther.Controls.Add(this.lblPosition);
            this.panelOther.Location = new System.Drawing.Point(3, 440);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(421, 192);
            this.panelOther.TabIndex = 21;
            // 
            // panelGazeTypingSpeed
            // 
            this.panelGazeTypingSpeed.Controls.Add(this.trackBarGazeTypingSpeed);
            this.panelGazeTypingSpeed.Controls.Add(this.lblGazeTypingSpeed);
            this.panelGazeTypingSpeed.ForeColor = System.Drawing.Color.White;
            this.panelGazeTypingSpeed.Location = new System.Drawing.Point(14, 472);
            this.panelGazeTypingSpeed.Name = "panelGazeTypingSpeed";
            this.panelGazeTypingSpeed.Size = new System.Drawing.Size(1057, 105);
            this.panelGazeTypingSpeed.TabIndex = 18;
            // 
            // trackBarGazeTypingSpeed
            // 
            this.trackBarGazeTypingSpeed.Location = new System.Drawing.Point(245, 23);
            this.trackBarGazeTypingSpeed.Maximum = 8;
            this.trackBarGazeTypingSpeed.Name = "trackBarGazeTypingSpeed";
            this.trackBarGazeTypingSpeed.Size = new System.Drawing.Size(798, 45);
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
            this.lblGazeTypingSpeed.Size = new System.Drawing.Size(144, 16);
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
            this.panelSize.Location = new System.Drawing.Point(128, 226);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(929, 149);
            this.panelSize.TabIndex = 15;
            // 
            // btnSoundFeedback
            // 
            this.btnSoundFeedback.FlatAppearance.BorderSize = 5;
            this.btnSoundFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoundFeedback.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnSoundFeedback.Location = new System.Drawing.Point(845, 72);
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
            this.lblSoundFeedbackOnOff.Location = new System.Drawing.Point(848, 26);
            this.lblSoundFeedbackOnOff.Name = "lblSoundFeedbackOnOff";
            this.lblSoundFeedbackOnOff.Size = new System.Drawing.Size(32, 16);
            this.lblSoundFeedbackOnOff.TabIndex = 14;
            this.lblSoundFeedbackOnOff.Text = "Off";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSize.Location = new System.Drawing.Point(63, 92);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(40, 16);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "Size";
            // 
            // btnSizeSmall
            // 
            this.btnSizeSmall.FlatAppearance.BorderSize = 5;
            this.btnSizeSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeSmall.Location = new System.Drawing.Point(236, 72);
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
            this.lblSoundFeedback.Location = new System.Drawing.Point(618, 92);
            this.lblSoundFeedback.Name = "lblSoundFeedback";
            this.lblSoundFeedback.Size = new System.Drawing.Size(120, 16);
            this.lblSoundFeedback.TabIndex = 12;
            this.lblSoundFeedback.Text = "Sound Feedback";
            // 
            // lblSizeSmall
            // 
            this.lblSizeSmall.AutoSize = true;
            this.lblSizeSmall.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblSizeSmall.Location = new System.Drawing.Point(232, 26);
            this.lblSizeSmall.Name = "lblSizeSmall";
            this.lblSizeSmall.Size = new System.Drawing.Size(48, 16);
            this.lblSizeSmall.TabIndex = 9;
            this.lblSizeSmall.Text = "Small";
            // 
            // lblLarge
            // 
            this.lblLarge.AutoSize = true;
            this.lblLarge.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblLarge.Location = new System.Drawing.Point(416, 26);
            this.lblLarge.Name = "lblLarge";
            this.lblLarge.Size = new System.Drawing.Size(48, 16);
            this.lblLarge.TabIndex = 11;
            this.lblLarge.Text = "Large";
            // 
            // btnSizeLarge
            // 
            this.btnSizeLarge.FlatAppearance.BorderSize = 5;
            this.btnSizeLarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSizeLarge.Location = new System.Drawing.Point(420, 72);
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
            this.panelLanguage.Location = new System.Drawing.Point(128, 9);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(929, 129);
            this.panelLanguage.TabIndex = 6;
            // 
            // btnChangeLanguage
            // 
            this.btnChangeLanguage.FlatAppearance.BorderSize = 2;
            this.btnChangeLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLanguage.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnChangeLanguage.Location = new System.Drawing.Point(323, 41);
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
            this.lblWordPredictionOnOffIndiction.Location = new System.Drawing.Point(848, 10);
            this.lblWordPredictionOnOffIndiction.Name = "lblWordPredictionOnOffIndiction";
            this.lblWordPredictionOnOffIndiction.Size = new System.Drawing.Size(32, 16);
            this.lblWordPredictionOnOffIndiction.TabIndex = 5;
            this.lblWordPredictionOnOffIndiction.Text = "Off";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblLanguage.ForeColor = System.Drawing.Color.White;
            this.lblLanguage.Location = new System.Drawing.Point(15, 64);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(72, 16);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "Language";
            // 
            // btnWordPredictionOnOff
            // 
            this.btnWordPredictionOnOff.FlatAppearance.BorderSize = 5;
            this.btnWordPredictionOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWordPredictionOnOff.Font = new System.Drawing.Font("SimSun", 12F);
            this.btnWordPredictionOnOff.Location = new System.Drawing.Point(845, 49);
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
            this.lblCurrentLanguage.Location = new System.Drawing.Point(127, 52);
            this.lblCurrentLanguage.Name = "lblCurrentLanguage";
            this.lblCurrentLanguage.Size = new System.Drawing.Size(128, 32);
            this.lblCurrentLanguage.TabIndex = 1;
            this.lblCurrentLanguage.Text = "    English\r\n(United States)";
            // 
            // lblWordPrediction
            // 
            this.lblWordPrediction.AutoSize = true;
            this.lblWordPrediction.Font = new System.Drawing.Font("SimSun", 12F);
            this.lblWordPrediction.Location = new System.Drawing.Point(606, 64);
            this.lblWordPrediction.Name = "lblWordPrediction";
            this.lblWordPrediction.Size = new System.Drawing.Size(128, 16);
            this.lblWordPrediction.TabIndex = 3;
            this.lblWordPrediction.Text = "Word Prediction";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 3;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(17, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 40);
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
            this.btnCancel.Location = new System.Drawing.Point(217, 17);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 40);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelSaveAndCancel
            // 
            this.panelSaveAndCancel.Controls.Add(this.btnSave);
            this.panelSaveAndCancel.Controls.Add(this.btnCancel);
            this.panelSaveAndCancel.Location = new System.Drawing.Point(309, 638);
            this.panelSaveAndCancel.Margin = new System.Windows.Forms.Padding(2);
            this.panelSaveAndCancel.Name = "panelSaveAndCancel";
            this.panelSaveAndCancel.Size = new System.Drawing.Size(364, 72);
            this.panelSaveAndCancel.TabIndex = 25;
            // 
            // pnlPageKeyboard
            // 
            this.pnlPageKeyboard.Controls.Add(this.panelLanguage);
            this.pnlPageKeyboard.Controls.Add(this.panelGazeTypingSpeed);
            this.pnlPageKeyboard.Controls.Add(this.panelSize);
            this.pnlPageKeyboard.Location = new System.Drawing.Point(12, 84);
            this.pnlPageKeyboard.Name = "pnlPageKeyboard";
            this.pnlPageKeyboard.Size = new System.Drawing.Size(1147, 589);
            this.pnlPageKeyboard.TabIndex = 26;
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.panelSelection);
            this.pnlGeneral.Controls.Add(this.panelSpeed);
            this.pnlGeneral.Controls.Add(this.panelOther);
            this.pnlGeneral.Controls.Add(this.panelPrecision);
            this.pnlGeneral.Location = new System.Drawing.Point(12, 84);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(1260, 648);
            this.pnlGeneral.TabIndex = 27;
            // 
            // btnGeneralSetting
            // 
            this.btnGeneralSetting.BackColor = System.Drawing.Color.Black;
            this.btnGeneralSetting.FlatAppearance.BorderSize = 5;
            this.btnGeneralSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralSetting.ForeColor = System.Drawing.Color.White;
            this.btnGeneralSetting.Location = new System.Drawing.Point(8, 9);
            this.btnGeneralSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneralSetting.Name = "btnGeneralSetting";
            this.btnGeneralSetting.Size = new System.Drawing.Size(147, 48);
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
            this.btnKeyBoardSetting.Location = new System.Drawing.Point(159, 9);
            this.btnKeyBoardSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnKeyBoardSetting.Name = "btnKeyBoardSetting";
            this.btnKeyBoardSetting.Size = new System.Drawing.Size(147, 48);
            this.btnKeyBoardSetting.TabIndex = 29;
            this.btnKeyBoardSetting.Text = "Keyboard Setting";
            this.btnKeyBoardSetting.UseVisualStyleBackColor = true;
            this.btnKeyBoardSetting.Click += new System.EventHandler(this.btnKeyBoardSetting_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1171, 739);
            this.Controls.Add(this.btnKeyBoardSetting);
            this.Controls.Add(this.btnGeneralSetting);
            this.Controls.Add(this.panelSaveAndCancel);
            this.Controls.Add(this.pnlGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPrecision)).EndInit();
            this.panelPrecision.ResumeLayout(false);
            this.panelPrecision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
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
        private Label lblPrecision;
        private TrackBar trackBarPrecision;
        private Panel panelPrecision;
        private Label lblSpeed;
        private TrackBar trackBarSpeed;
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
    }
}