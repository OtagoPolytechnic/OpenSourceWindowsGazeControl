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
            this.ntficGaze = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSingleClick = new System.Windows.Forms.Button();
            this.btnDoubleClick = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnRightClick = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.bhavMapRightClick = new EyeXFramework.Forms.BehaviorMap(components);
            this.bhavMapDoubleClick = new EyeXFramework.Forms.BehaviorMap(components);
            this.bhavMapSingleClick = new EyeXFramework.Forms.BehaviorMap(components);
            this.bhavMapSettings = new EyeXFramework.Forms.BehaviorMap(components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntficGaze
            // 
            this.ntficGaze.Icon = ((System.Drawing.Icon)(resources.GetObject("ntficGaze.Icon")));
            this.ntficGaze.Text = "Gaze Toolbar";
            this.ntficGaze.Visible = true;
            // 
            // btnSingleClick
            // 
            this.btnSingleClick.BackColor = System.Drawing.Color.FromArgb(173, 83, 201);
            this.btnSingleClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingleClick.Location = new System.Drawing.Point(43, 80);
            this.btnSingleClick.Name = "btnSingleClick";
            this.btnSingleClick.Size = new System.Drawing.Size(93, 80);
            this.btnSingleClick.TabIndex = 3;
            this.btnSingleClick.UseVisualStyleBackColor = false;
            // 
            // btnDoubleClick
            // 
            this.btnDoubleClick.BackColor = System.Drawing.Color.FromArgb(173, 83, 201);
            this.btnDoubleClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoubleClick.Location = new System.Drawing.Point(43, 160);
            this.btnDoubleClick.Name = "btnDoubleClick";
            this.btnDoubleClick.Size = new System.Drawing.Size(93, 80);
            this.btnDoubleClick.TabIndex = 4;
            this.btnDoubleClick.Text = "";
            this.btnDoubleClick.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(173, 83, 201);
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(43, 240);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(93, 80);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRightClick
            // 
            this.btnRightClick.BackColor = System.Drawing.Color.FromArgb(173, 83, 201);
            this.btnRightClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightClick.Location = new System.Drawing.Point(43, 0);
            this.btnRightClick.Name = "btnRightClick";
            this.btnRightClick.Size = new System.Drawing.Size(93, 80);
            this.btnRightClick.TabIndex = 3;
            this.btnRightClick.UseVisualStyleBackColor = false;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(78, 0, 82);
            this.panel.Controls.Add(this.btnDoubleClick);
            this.panel.Controls.Add(this.btnSettings);
            this.panel.Controls.Add(this.btnSingleClick);
            this.panel.Controls.Add(this.btnRightClick);
            this.panel.Location = new System.Drawing.Point(0, 200);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(200, 320);
            this.panel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(78, 0, 82);
            this.ClientSize = new System.Drawing.Size(200, 1000);
            this.ControlBox = false;
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon ntficGaze;
        private System.Windows.Forms.Button btnSingleClick;
        private System.Windows.Forms.Button btnDoubleClick;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRightClick;
        private System.Windows.Forms.Panel panel;
        private EyeXFramework.Forms.BehaviorMap bhavMapRightClick;
        private EyeXFramework.Forms.BehaviorMap bhavMapSingleClick;
        private EyeXFramework.Forms.BehaviorMap bhavMapDoubleClick;
        private EyeXFramework.Forms.BehaviorMap bhavMapSettings;
    }
}

