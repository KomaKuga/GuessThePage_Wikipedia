namespace GuessThePage_Wikipedia.Forms
{
    partial class mainPage
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
            playerLabel = new Label();
            textBodyLabel = new Label();
            personLabel = new Label();
            SuspendLayout();
            // 
            // playerLabel
            // 
            playerLabel.AutoSize = true;
            playerLabel.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playerLabel.Location = new Point(22, 19);
            playerLabel.Name = "playerLabel";
            playerLabel.Size = new Size(203, 86);
            playerLabel.TabIndex = 0;
            playerLabel.Text = "Hello ";
            playerLabel.Click += playerLabel_Click;
            // 
            // textBodyLabel
            // 
            textBodyLabel.Font = new Font("Segoe UI", 20F);
            textBodyLabel.Location = new Point(37, 179);
            textBodyLabel.Name = "textBodyLabel";
            textBodyLabel.Size = new Size(1737, 573);
            textBodyLabel.TabIndex = 1;
            textBodyLabel.Text = "BodyText";
            textBodyLabel.Click += textBodyLabel_Click;
            // 
            // personLabel
            // 
            personLabel.AutoSize = true;
            personLabel.Location = new Point(70, 849);
            personLabel.Name = "personLabel";
            personLabel.Size = new Size(43, 15);
            personLabel.TabIndex = 2;
            personLabel.Text = "Person";
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1854, 1041);
            Controls.Add(personLabel);
            Controls.Add(textBodyLabel);
            Controls.Add(playerLabel);
            Name = "mainPage";
            Text = "mainPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label playerLabel;
        private Label textBodyLabel;
        private Label personLabel;
    }
}