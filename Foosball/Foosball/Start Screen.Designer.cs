namespace Foosball
{
    partial class Start_Screen
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TextBoxTeam1NameInput = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.TextBoxTeam2NameInput = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(483, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Team 1 name:";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TextBoxTeam1NameInput
            // 
            this.TextBoxTeam1NameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTeam1NameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTeam1NameInput.Location = new System.Drawing.Point(100, 50);
            this.TextBoxTeam1NameInput.Name = "TextBoxTeam1NameInput";
            this.TextBoxTeam1NameInput.Size = new System.Drawing.Size(300, 38);
            this.TextBoxTeam1NameInput.TabIndex = 0;
            this.TextBoxTeam1NameInput.Tag = "";
            this.TextBoxTeam1NameInput.TextChanged += new System.EventHandler(this.TeamNameInput_TextChanged);
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(200, 185);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 35);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // TextBoxTeam2NameInput
            // 
            this.TextBoxTeam2NameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTeam2NameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTeam2NameInput.Location = new System.Drawing.Point(101, 136);
            this.TextBoxTeam2NameInput.Name = "TextBoxTeam2NameInput";
            this.TextBoxTeam2NameInput.Size = new System.Drawing.Size(300, 38);
            this.TextBoxTeam2NameInput.TabIndex = 1;
            this.TextBoxTeam2NameInput.Tag = "";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(1, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(483, 24);
            this.textBox3.TabIndex = 4;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Team 2 name:";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Start_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.TextBoxTeam2NameInput);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.TextBoxTeam1NameInput);
            this.Controls.Add(this.textBox1);
            this.Name = "Start_Screen";
            this.Text = "Start Screen";
            this.Load += new System.EventHandler(this.Start_Screen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox TextBoxTeam1NameInput;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox TextBoxTeam2NameInput;
        private System.Windows.Forms.TextBox textBox3;
    }
}