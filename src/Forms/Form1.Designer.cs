namespace GuessThePage_Wikipedia
{
    partial class Form1
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
            label1 = new Label();
            nameTextBox = new TextBox();
            label2 = new Label();
            errorLabel = new Label();
            startButton = new Button();
            difficultyButton = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 125.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 72);
            label1.Name = "label1";
            label1.Size = new Size(1313, 215);
            label1.TabIndex = 0;
            label1.Text = "GuessThePage";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTextBox.Location = new Point(64, 512);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(1181, 135);
            nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(64, 322);
            label2.Name = "label2";
            label2.Size = new Size(355, 124);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            label2.Click += label2_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(114, 825);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 86);
            errorLabel.TabIndex = 3;
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 150F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.Location = new Point(1211, 752);
            startButton.Name = "startButton";
            startButton.Size = new Size(681, 267);
            startButton.TabIndex = 4;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startClick;
            // 
            // difficultyButton
            // 
            difficultyButton.AutoSize = true;
            difficultyButton.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            difficultyButton.Location = new Point(1252, 667);
            difficultyButton.Name = "difficultyButton";
            difficultyButton.Size = new Size(640, 69);
            difficultyButton.TabIndex = 5;
            difficultyButton.TabStop = true;
            difficultyButton.Text = "HARD Mode (coming soon!)";
            difficultyButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(difficultyButton);
            Controls.Add(startButton);
            Controls.Add(errorLabel);
            Controls.Add(label2);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameTextBox;
        private Label label2;
        private Label errorLabel;
        private Button startButton;
        private RadioButton difficultyButton;
    }
}
