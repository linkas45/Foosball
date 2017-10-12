namespace Foosball
{
    partial class Counting_Goals
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
            this.GoalsCountText = new System.Windows.Forms.TextBox();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.EndGame = new System.Windows.Forms.Button();
            this.textBoxXY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // GoalsCountText
            // 
            this.GoalsCountText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GoalsCountText.BackColor = System.Drawing.SystemColors.Control;
            this.GoalsCountText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GoalsCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalsCountText.Location = new System.Drawing.Point(12, 20);
            this.GoalsCountText.Multiline = true;
            this.GoalsCountText.Name = "GoalsCountText";
            this.GoalsCountText.ReadOnly = true;
            this.GoalsCountText.Size = new System.Drawing.Size(260, 55);
            this.GoalsCountText.TabIndex = 1;
            this.GoalsCountText.TabStop = false;
            this.GoalsCountText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GoalsCountText.TextChanged += new System.EventHandler(this.GoalsCountText_TextChanged);
            // 
            // ibOriginal
            // 
            this.ibOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ibOriginal.Enabled = false;
            this.ibOriginal.Location = new System.Drawing.Point(12, 75);
            this.ibOriginal.Margin = new System.Windows.Forms.Padding(2);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(260, 323);
            this.ibOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibOriginal.TabIndex = 3;
            this.ibOriginal.TabStop = false;
            // 
            // EndGame
            // 
            this.EndGame.Location = new System.Drawing.Point(172, 409);
            this.EndGame.Name = "EndGame";
            this.EndGame.Size = new System.Drawing.Size(100, 40);
            this.EndGame.TabIndex = 0;
            this.EndGame.Text = "End Game";
            this.EndGame.UseVisualStyleBackColor = true;
            this.EndGame.Click += new System.EventHandler(this.EndGame_Click);
            // 
            // textBoxXY
            // 
            this.textBoxXY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxXY.Location = new System.Drawing.Point(13, 410);
            this.textBoxXY.Multiline = true;
            this.textBoxXY.Name = "textBoxXY";
            this.textBoxXY.ReadOnly = true;
            this.textBoxXY.Size = new System.Drawing.Size(153, 39);
            this.textBoxXY.TabIndex = 4;
            this.textBoxXY.TabStop = false;
            this.textBoxXY.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Counting_Goals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.textBoxXY);
            this.Controls.Add(this.EndGame);
            this.Controls.Add(this.ibOriginal);
            this.Controls.Add(this.GoalsCountText);
            this.Name = "Counting_Goals";
            this.Text = "Counting Goals";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Counting_Goals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox GoalsCountText;
        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button EndGame;
        private System.Windows.Forms.TextBox textBoxXY;
    }
}