namespace Foosball
{
    partial class ScoreInput
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
            this.TextBoxGoalsCount1 = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.TextBoxGoalsCount2 = new System.Windows.Forms.TextBox();
            this.TextBoxTeamName1 = new System.Windows.Forms.TextBox();
            this.TextBoxTeamName2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxGoalsCount1
            // 
            this.TextBoxGoalsCount1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGoalsCount1.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxGoalsCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGoalsCount1.Location = new System.Drawing.Point(162, 39);
            this.TextBoxGoalsCount1.Multiline = true;
            this.TextBoxGoalsCount1.Name = "TextBoxGoalsCount1";
            this.TextBoxGoalsCount1.Size = new System.Drawing.Size(100, 39);
            this.TextBoxGoalsCount1.TabIndex = 0;
            this.TextBoxGoalsCount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxGoalsCount1.TextChanged += new System.EventHandler(this.GoalsCountTextBox_TextChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.Location = new System.Drawing.Point(95, 156);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(100, 32);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // TextBoxGoalsCount2
            // 
            this.TextBoxGoalsCount2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGoalsCount2.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxGoalsCount2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGoalsCount2.Location = new System.Drawing.Point(162, 95);
            this.TextBoxGoalsCount2.Multiline = true;
            this.TextBoxGoalsCount2.Name = "TextBoxGoalsCount2";
            this.TextBoxGoalsCount2.Size = new System.Drawing.Size(100, 39);
            this.TextBoxGoalsCount2.TabIndex = 1;
            this.TextBoxGoalsCount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxTeamName1
            // 
            this.TextBoxTeamName1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTeamName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TextBoxTeamName1.Location = new System.Drawing.Point(12, 43);
            this.TextBoxTeamName1.Name = "TextBoxTeamName1";
            this.TextBoxTeamName1.ReadOnly = true;
            this.TextBoxTeamName1.Size = new System.Drawing.Size(143, 28);
            this.TextBoxTeamName1.TabIndex = 4;
            this.TextBoxTeamName1.TabStop = false;
            this.TextBoxTeamName1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxTeamName2
            // 
            this.TextBoxTeamName2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTeamName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TextBoxTeamName2.Location = new System.Drawing.Point(12, 99);
            this.TextBoxTeamName2.Name = "TextBoxTeamName2";
            this.TextBoxTeamName2.ReadOnly = true;
            this.TextBoxTeamName2.Size = new System.Drawing.Size(143, 28);
            this.TextBoxTeamName2.TabIndex = 5;
            this.TextBoxTeamName2.TabStop = false;
            this.TextBoxTeamName2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ScoreInput
            // 
            this.ClientSize = new System.Drawing.Size(274, 200);
            this.Controls.Add(this.TextBoxTeamName2);
            this.Controls.Add(this.TextBoxTeamName1);
            this.Controls.Add(this.TextBoxGoalsCount2);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.TextBoxGoalsCount1);
            this.Name = "ScoreInput";
            this.Text = "ScoreBoard";
            this.Load += new System.EventHandler(this.ScoreInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxGoalsCount1;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.TextBox TextBoxGoalsCount2;
        private System.Windows.Forms.TextBox TextBoxTeamName1;
        private System.Windows.Forms.TextBox TextBoxTeamName2;
    }
}