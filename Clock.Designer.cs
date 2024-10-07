namespace ClockApp {
    partial class Clock {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Canvas = new PictureBox();
            RenderTim = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            SuspendLayout();
            // 
            // Canvas
            // 
            Canvas.Location = new Point(-5, 1);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(1920, 1080);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            // 
            // timer1
            // 
            RenderTim.Enabled = true;
            RenderTim.Interval = timeToRender;
            RenderTim.Tick += RenderTim_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 700);
            Controls.Add(Canvas);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Canvas;
        private System.Windows.Forms.Timer RenderTim;
        private int timeToRender = 100;
    }
}
