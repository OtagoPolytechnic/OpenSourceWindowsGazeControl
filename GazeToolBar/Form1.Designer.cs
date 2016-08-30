namespace GazeToolBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bhavMap = new EyeXFramework.Forms.BehaviorMap(this.components);
            this.pnlHighLightDragAndDrop = new System.Windows.Forms.Panel();
            this.btnDragAndDrop = new System.Windows.Forms.Button();
            this.pnlHighLightKeyboard = new System.Windows.Forms.Panel();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.pnlHighLightScrol = new System.Windows.Forms.Panel();
            this.btnScoll = new System.Windows.Forms.Button();
            this.pnlHighLightSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlHighLightDoubleClick = new System.Windows.Forms.Panel();
            this.btnDoubleClick = new System.Windows.Forms.Button();
            this.pnlHighLightSingleLeft = new System.Windows.Forms.Panel();
            this.btnSingleLeftClick = new System.Windows.Forms.Button();
            this.pnlHiLteRightClick = new System.Windows.Forms.Panel();
            this.btnRightClick = new System.Windows.Forms.Button();
            this.bhavMapHLCurrentGazeOnBT = new EyeXFramework.Forms.BehaviorMap(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlHighLightDragAndDrop.SuspendLayout();
            this.pnlHighLightKeyboard.SuspendLayout();
            this.pnlHighLightScrol.SuspendLayout();
            this.pnlHighLightSettings.SuspendLayout();
            this.pnlHighLightDoubleClick.SuspendLayout();
            this.pnlHighLightSingleLeft.SuspendLayout();
            this.pnlHiLteRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHighLightDragAndDrop
            // 
            this.pnlHighLightDragAndDrop.Controls.Add(this.btnDragAndDrop);
            this.pnlHighLightDragAndDrop.Location = new System.Drawing.Point(12, 340);
            this.pnlHighLightDragAndDrop.Name = "pnlHighLightDragAndDrop";
            this.pnlHighLightDragAndDrop.Size = new System.Drawing.Size(80, 80);
            this.pnlHighLightDragAndDrop.TabIndex = 12;
            // 
            // btnDragAndDrop
            // 
            this.btnDragAndDrop.BackColor = System.Drawing.Color.Black;
            this.btnDragAndDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDragAndDrop.Image = global::GazeToolBar.Properties.Resources.Drag_and_drop_icon;
            this.btnDragAndDrop.Location = new System.Drawing.Point(3, 3);
            this.btnDragAndDrop.Name = "btnDragAndDrop";
            this.btnDragAndDrop.Size = new System.Drawing.Size(75, 75);
            this.btnDragAndDrop.TabIndex = 5;
            this.btnDragAndDrop.UseVisualStyleBackColor = false;
            this.btnDragAndDrop.Click += new System.EventHandler(this.btnDragAndDrop_Click);
            // 
            // pnlHighLightKeyboard
            // 
            this.pnlHighLightKeyboard.Controls.Add(this.btnKeyboard);
            this.pnlHighLightKeyboard.Location = new System.Drawing.Point(15, 564);
            this.pnlHighLightKeyboard.Name = "pnlHighLightKeyboard";
            this.pnlHighLightKeyboard.Size = new System.Drawing.Size(80, 80);
            this.pnlHighLightKeyboard.TabIndex = 11;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackColor = System.Drawing.Color.Black;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Image = global::GazeToolBar.Properties.Resources.Keyboard_icon;
            this.btnKeyboard.Location = new System.Drawing.Point(3, 3);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(75, 75);
            this.btnKeyboard.TabIndex = 5;
            this.btnKeyboard.UseVisualStyleBackColor = false;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // pnlHighLightScrol
            // 
            this.pnlHighLightScrol.Controls.Add(this.btnScoll);
            this.pnlHighLightScrol.Location = new System.Drawing.Point(15, 455);
            this.pnlHighLightScrol.Name = "pnlHighLightScrol";
            this.pnlHighLightScrol.Size = new System.Drawing.Size(80, 80);
            this.pnlHighLightScrol.TabIndex = 10;
            // 
            // btnScoll
            // 
            this.btnScoll.BackColor = System.Drawing.Color.Black;
            this.btnScoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScoll.Image = global::GazeToolBar.Properties.Resources.Scroll_icon;
            this.btnScoll.Location = new System.Drawing.Point(3, 3);
            this.btnScoll.Name = "btnScoll";
            this.btnScoll.Size = new System.Drawing.Size(75, 75);
            this.btnScoll.TabIndex = 5;
            this.btnScoll.UseVisualStyleBackColor = false;
            this.btnScoll.Click += new System.EventHandler(this.btnScoll_Click);
            // 
            // pnlHighLightSettings
            // 
            this.pnlHighLightSettings.Controls.Add(this.btnSettings);
            this.pnlHighLightSettings.Location = new System.Drawing.Point(15, 682);
            this.pnlHighLightSettings.Name = "pnlHighLightSettings";
            this.pnlHighLightSettings.Size = new System.Drawing.Size(80, 80);
            this.pnlHighLightSettings.TabIndex = 9;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Black;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Image = global::GazeToolBar.Properties.Resources.settings_icon;
            this.btnSettings.Location = new System.Drawing.Point(3, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 75);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlHighLightDoubleClick
            // 
            this.pnlHighLightDoubleClick.Controls.Add(this.btnDoubleClick);
            this.pnlHighLightDoubleClick.Location = new System.Drawing.Point(15, 239);
            this.pnlHighLightDoubleClick.Name = "pnlHighLightDoubleClick";
            this.pnlHighLightDoubleClick.Size = new System.Drawing.Size(80, 80);
            this.pnlHighLightDoubleClick.TabIndex = 8;
            // 
            // btnDoubleClick
            // 
            this.btnDoubleClick.BackColor = System.Drawing.Color.Black;
            this.btnDoubleClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoubleClick.Image = global::GazeToolBar.Properties.Resources.Double_Click_icon;
            this.btnDoubleClick.Location = new System.Drawing.Point(3, 3);
            this.btnDoubleClick.Name = "btnDoubleClick";
            this.btnDoubleClick.Size = new System.Drawing.Size(75, 75);
            this.btnDoubleClick.TabIndex = 4;
            this.btnDoubleClick.UseVisualStyleBackColor = false;
            this.btnDoubleClick.Click += new System.EventHandler(this.btnDoubleClick_Click);
            // 
            // pnlHighLightSingleLeft
            // 
            this.pnlHighLightSingleLeft.Controls.Add(this.btnSingleLeftClick);
            this.pnlHighLightSingleLeft.Location = new System.Drawing.Point(15, 127);
            this.pnlHighLightSingleLeft.Name = "pnlHighLightSingleLeft";
            this.pnlHighLightSingleLeft.Size = new System.Drawing.Size(80, 80);
            this.pnlHighLightSingleLeft.TabIndex = 7;
            // 
            // btnSingleLeftClick
            // 
            this.btnSingleLeftClick.BackColor = System.Drawing.Color.Black;
            this.btnSingleLeftClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingleLeftClick.Image = ((System.Drawing.Image)(resources.GetObject("btnSingleLeftClick.Image")));
            this.btnSingleLeftClick.Location = new System.Drawing.Point(3, 3);
            this.btnSingleLeftClick.Name = "btnSingleLeftClick";
            this.btnSingleLeftClick.Size = new System.Drawing.Size(75, 75);
            this.btnSingleLeftClick.TabIndex = 3;
            this.btnSingleLeftClick.UseVisualStyleBackColor = false;
            this.btnSingleLeftClick.Click += new System.EventHandler(this.btnSingleLeftClick_Click);
            // 
            // pnlHiLteRightClick
            // 
            this.pnlHiLteRightClick.Controls.Add(this.btnRightClick);
            this.pnlHiLteRightClick.Location = new System.Drawing.Point(15, 30);
            this.pnlHiLteRightClick.Name = "pnlHiLteRightClick";
            this.pnlHiLteRightClick.Size = new System.Drawing.Size(80, 80);
            this.pnlHiLteRightClick.TabIndex = 6;
            // 
            // btnRightClick
            // 
            this.btnRightClick.BackColor = System.Drawing.Color.Black;
            this.btnRightClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightClick.Image = ((System.Drawing.Image)(resources.GetObject("btnRightClick.Image")));
            this.btnRightClick.Location = new System.Drawing.Point(3, 3);
            this.btnRightClick.Name = "btnRightClick";
            this.btnRightClick.Size = new System.Drawing.Size(75, 75);
            this.btnRightClick.TabIndex = 3;
            this.btnRightClick.UseVisualStyleBackColor = false;
            this.btnRightClick.Click += new System.EventHandler(this.btnRightClick_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(120, 1092);
            this.ControlBox = false;
            this.Controls.Add(this.pnlHighLightDragAndDrop);
            this.Controls.Add(this.pnlHighLightKeyboard);
            this.Controls.Add(this.pnlHiLteRightClick);
            this.Controls.Add(this.pnlHighLightScrol);
            this.Controls.Add(this.pnlHighLightSingleLeft);
            this.Controls.Add(this.pnlHighLightSettings);
            this.Controls.Add(this.pnlHighLightDoubleClick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHighLightDragAndDrop.ResumeLayout(false);
            this.pnlHighLightKeyboard.ResumeLayout(false);
            this.pnlHighLightScrol.ResumeLayout(false);
            this.pnlHighLightSettings.ResumeLayout(false);
            this.pnlHighLightDoubleClick.ResumeLayout(false);
            this.pnlHighLightSingleLeft.ResumeLayout(false);
            this.pnlHiLteRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EyeXFramework.Forms.BehaviorMap bhavMap;
        private System.Windows.Forms.Button btnRightClick;
        private System.Windows.Forms.Button btnSingleLeftClick;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnScoll;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Button btnDragAndDrop;
        private System.Windows.Forms.Button btnDoubleClick;
        private EyeXFramework.Forms.BehaviorMap bhavMapHLCurrentGazeOnBT;
        private System.Windows.Forms.Panel pnlHiLteRightClick;
        private System.Windows.Forms.Panel pnlHighLightDoubleClick;
        private System.Windows.Forms.Panel pnlHighLightSettings;
        private System.Windows.Forms.Panel pnlHighLightSingleLeft;
        private System.Windows.Forms.Panel pnlHighLightDragAndDrop;
        private System.Windows.Forms.Panel pnlHighLightKeyboard;
        private System.Windows.Forms.Panel pnlHighLightScrol;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

