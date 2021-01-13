namespace Mandel
{
    partial class Form
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
            this.FractalPictureBox = new System.Windows.Forms.PictureBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LoopsTrackBar = new System.Windows.Forms.TrackBar();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.GradientPictureBox = new System.Windows.Forms.PictureBox();
            this.GradientColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.FractalPictureBox)).BeginInit();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoopsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradientPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FractalPictureBox
            // 
            this.FractalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FractalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FractalPictureBox.Location = new System.Drawing.Point(12, 12);
            this.FractalPictureBox.Name = "FractalPictureBox";
            this.FractalPictureBox.Size = new System.Drawing.Size(778, 386);
            this.FractalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FractalPictureBox.TabIndex = 0;
            this.FractalPictureBox.TabStop = false;
            this.FractalPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.FractalPictureBox_Paint);
            this.FractalPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FractalPictureBox_MouseDown);
            this.FractalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FractalPictureBox_MouseMove);
            this.FractalPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FractalPictureBox_MouseUp);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 480);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(802, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StripStatusLabel
            // 
            this.StripStatusLabel.Name = "StripStatusLabel";
            this.StripStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.StripStatusLabel.Text = "Loaded";
            // 
            // LoopsTrackBar
            // 
            this.LoopsTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoopsTrackBar.LargeChange = 10;
            this.LoopsTrackBar.Location = new System.Drawing.Point(12, 424);
            this.LoopsTrackBar.Maximum = 2000;
            this.LoopsTrackBar.Minimum = 1;
            this.LoopsTrackBar.Name = "LoopsTrackBar";
            this.LoopsTrackBar.Size = new System.Drawing.Size(697, 45);
            this.LoopsTrackBar.TabIndex = 2;
            this.LoopsTrackBar.TickFrequency = 10;
            this.LoopsTrackBar.Value = 100;
            // 
            // DrawButton
            // 
            this.DrawButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawButton.Location = new System.Drawing.Point(715, 424);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 3;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Location = new System.Drawing.Point(715, 453);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // GradientPictureBox
            // 
            this.GradientPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradientPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GradientPictureBox.Location = new System.Drawing.Point(12, 404);
            this.GradientPictureBox.Name = "GradientPictureBox";
            this.GradientPictureBox.Size = new System.Drawing.Size(778, 14);
            this.GradientPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GradientPictureBox.TabIndex = 5;
            this.GradientPictureBox.TabStop = false;
            this.GradientPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GradientPictureBox_MouseDown);
            this.GradientPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GradientPictureBox_MouseMove);
            this.GradientPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GradientPictureBox_MouseUp);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 502);
            this.Controls.Add(this.GradientPictureBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.LoopsTrackBar);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.FractalPictureBox);
            this.Name = "Form";
            this.Text = "Mandel";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FractalPictureBox)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoopsTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradientPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FractalPictureBox;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StripStatusLabel;
        private System.Windows.Forms.TrackBar LoopsTrackBar;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.PictureBox GradientPictureBox;
        private System.Windows.Forms.ColorDialog GradientColorDialog;
    }
}

