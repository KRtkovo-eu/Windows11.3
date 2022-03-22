using Win113.Shell.Components;

namespace Win113.Shell.Windows.Special
{
    partial class BootImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BootImageForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.windowsBrandingPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.noSelectButton1 = new NoSelectButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsBrandingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.windowsBrandingPictureBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 137);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Win113.Shell.Properties.Resources.windows113gradient;
            this.pictureBox1.Location = new System.Drawing.Point(0, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 5);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // windowsBrandingPictureBox
            // 
            this.windowsBrandingPictureBox.Image = global::Win113.Shell.Properties.Resources.win113;
            this.windowsBrandingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.windowsBrandingPictureBox.Name = "windowsBrandingPictureBox";
            this.windowsBrandingPictureBox.Size = new System.Drawing.Size(458, 80);
            this.windowsBrandingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.windowsBrandingPictureBox.TabIndex = 9;
            this.windowsBrandingPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // noSelectButton1
            // 
            this.noSelectButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.noSelectButton1.BackgroundImage = global::Win113.Shell.Properties.Resources.main;
            this.noSelectButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.noSelectButton1.Enabled = false;
            this.noSelectButton1.FlatAppearance.BorderSize = 0;
            this.noSelectButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noSelectButton1.Location = new System.Drawing.Point(4, 4);
            this.noSelectButton1.Name = "noSelectButton1";
            this.noSelectButton1.Size = new System.Drawing.Size(20, 20);
            this.noSelectButton1.TabIndex = 2;
            this.noSelectButton1.UseVisualStyleBackColor = false;
            this.noSelectButton1.Click += new System.EventHandler(this.noSelectButton1_Click);
            this.noSelectButton1.Paint += new System.Windows.Forms.PaintEventHandler(this.noSelectButton1_Paint);
            // 
            // BootImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 164);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.noSelectButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BootImageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logging in...";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Form1_Deactivate);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Shown += new System.EventHandler(this.BootImageForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsBrandingPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox windowsBrandingPictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NoSelectButton noSelectButton1;
    }
}

