
namespace Win113.Shell.Windows.Sizable
{
    partial class AnalogClockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalogClockForm));
            this.analogClock1 = new AnalogClockControl.AnalogClock();
            this.SuspendLayout();
            // 
            // analogClock1
            // 
            this.analogClock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analogClock1.Draw1MinuteTicks = true;
            this.analogClock1.Draw5MinuteTicks = true;
            this.analogClock1.HourHandColor = System.Drawing.Color.DarkMagenta;
            this.analogClock1.Location = new System.Drawing.Point(0, 0);
            this.analogClock1.MinuteHandColor = System.Drawing.Color.Green;
            this.analogClock1.Name = "analogClock1";
            this.analogClock1.SecondHandColor = System.Drawing.Color.Red;
            this.analogClock1.Size = new System.Drawing.Size(211, 211);
            this.analogClock1.TabIndex = 0;
            this.analogClock1.TicksColor = System.Drawing.Color.Black;
            // 
            // AnalogClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 211);
            this.Controls.Add(this.analogClock1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(230, 250);
            this.Name = "AnalogClockForm";
            this.Text = "Clock";
            this.ResumeLayout(false);

        }

        #endregion

        private AnalogClockControl.AnalogClock analogClock1;
    }
}