﻿using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnAutoStart = new System.Windows.Forms.Button();
            this.btnChangeSide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.BackColor = System.Drawing.Color.White;
            this.btnAutoStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoStart.Location = new System.Drawing.Point(43, 118);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Size = new System.Drawing.Size(93, 80);
            this.btnAutoStart.TabIndex = 4;
            this.btnAutoStart.Text = "Auto Start Is OFF";
            this.btnAutoStart.UseVisualStyleBackColor = false;
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // btnChangeSide
            // 
            this.btnChangeSide.BackColor = System.Drawing.Color.White;
            this.btnChangeSide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeSide.Location = new System.Drawing.Point(43, 12);
            this.btnChangeSide.Name = "btnChangeSide";
            this.btnChangeSide.Size = new System.Drawing.Size(93, 80);
            this.btnChangeSide.TabIndex = 3;
            this.btnChangeSide.Text = "To Left";
            this.btnChangeSide.UseVisualStyleBackColor = false;
            this.btnChangeSide.Click += new System.EventHandler(this.btnChangeSide_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1634, 1053);
            this.Controls.Add(this.btnAutoStart);
            this.Controls.Add(this.btnChangeSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutoStart;
        private System.Windows.Forms.Button btnChangeSide;
    }
}