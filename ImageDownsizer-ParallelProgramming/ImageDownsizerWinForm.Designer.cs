namespace ImageDownsizer
{
    partial class ImageDownsizerWinForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uploadBtn = new Button();
            imageLbl = new Label();
            label2 = new Label();
            timeLbl = new Label();
            sequentialButton = new Button();
            parallelButton = new Button();
            label3 = new Label();
            downsizeFactorUpDown = new NumericUpDown();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)downsizeFactorUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // uploadBtn
            // 
            uploadBtn.BackColor = Color.Wheat;
            uploadBtn.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uploadBtn.Location = new Point(34, 21);
            uploadBtn.Margin = new Padding(2, 3, 2, 3);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(113, 39);
            uploadBtn.TabIndex = 0;
            uploadBtn.Text = "Upload Image";
            uploadBtn.UseVisualStyleBackColor = false;
            uploadBtn.Click += uploadButton_Click;
            // 
            // imageLbl
            // 
            imageLbl.AutoSize = true;
            imageLbl.Location = new Point(362, 44);
            imageLbl.Margin = new Padding(2, 0, 2, 0);
            imageLbl.Name = "imageLbl";
            imageLbl.Size = new Size(0, 16);
            imageLbl.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiCondensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(105, 302);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(187, 18);
            label2.TabIndex = 3;
            label2.Text = "The downsizing operation took:";
            // 
            // timeLbl
            // 
            timeLbl.AutoSize = true;
            timeLbl.Location = new Point(296, 304);
            timeLbl.Margin = new Padding(2, 0, 2, 0);
            timeLbl.Name = "timeLbl";
            timeLbl.Size = new Size(0, 16);
            timeLbl.TabIndex = 4;
            // 
            // sequentialButton
            // 
            sequentialButton.BackColor = Color.Wheat;
            sequentialButton.Enabled = false;
            sequentialButton.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sequentialButton.Location = new Point(34, 152);
            sequentialButton.Margin = new Padding(2, 3, 2, 3);
            sequentialButton.Name = "sequentialButton";
            sequentialButton.Size = new Size(113, 40);
            sequentialButton.TabIndex = 5;
            sequentialButton.Text = "Sequential";
            sequentialButton.UseVisualStyleBackColor = false;
            sequentialButton.Click += sequentialButton_Click;
            // 
            // parallelButton
            // 
            parallelButton.BackColor = Color.Wheat;
            parallelButton.Enabled = false;
            parallelButton.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            parallelButton.Location = new Point(34, 213);
            parallelButton.Margin = new Padding(2, 3, 2, 3);
            parallelButton.Name = "parallelButton";
            parallelButton.Size = new Size(113, 40);
            parallelButton.TabIndex = 6;
            parallelButton.Text = "Parallel";
            parallelButton.UseVisualStyleBackColor = false;
            parallelButton.Click += parallelButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiCondensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 74);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 23);
            label3.TabIndex = 8;
            label3.Text = " Downsizing %: ";
            // 
            // downsizeFactorUpDown
            // 
            downsizeFactorUpDown.BackColor = Color.FloralWhite;
            downsizeFactorUpDown.Enabled = false;
            downsizeFactorUpDown.Font = new Font("Bahnschrift SemiCondensed", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            downsizeFactorUpDown.ImeMode = ImeMode.NoControl;
            downsizeFactorUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            downsizeFactorUpDown.Location = new Point(26, 109);
            downsizeFactorUpDown.Margin = new Padding(3, 2, 3, 2);
            downsizeFactorUpDown.Name = "downsizeFactorUpDown";
            downsizeFactorUpDown.Size = new Size(131, 23);
            downsizeFactorUpDown.TabIndex = 9;
            downsizeFactorUpDown.Tag = "95";
            downsizeFactorUpDown.ValueChanged += downsizeFactor_Change;
            downsizeFactorUpDown.KeyDown += downsizeFactorUpDown_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(180, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(530, 238);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // ImageDownsizerWinForm
            // 
            AutoScaleDimensions = new SizeF(6F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(722, 336);
            Controls.Add(pictureBox1);
            Controls.Add(downsizeFactorUpDown);
            Controls.Add(label3);
            Controls.Add(parallelButton);
            Controls.Add(sequentialButton);
            Controls.Add(timeLbl);
            Controls.Add(label2);
            Controls.Add(imageLbl);
            Controls.Add(uploadBtn);
            Font = new Font("Bahnschrift SemiCondensed", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(2, 3, 2, 3);
            Name = "ImageDownsizerWinForm";
            Text = "ImageDownsizer";
            ((System.ComponentModel.ISupportInitialize)downsizeFactorUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button uploadBtn;
        private Label imageLbl;
        private Label label2;
        private Label timeLbl;
        private Button sequentialButton;
        private Button parallelButton;
        private Label label3;
        private NumericUpDown downsizeFactorUpDown;
        private PictureBox pictureBox1;
    }
}