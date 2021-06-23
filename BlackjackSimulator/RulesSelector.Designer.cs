namespace BlackjackSimulator
{
    partial class RulesSelector
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
            this.deckNumberLabel = new System.Windows.Forms.Label();
            this.deckNumberText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deckNumberLabel
            // 
            this.deckNumberLabel.AutoSize = true;
            this.deckNumberLabel.Location = new System.Drawing.Point(191, 178);
            this.deckNumberLabel.Name = "deckNumberLabel";
            this.deckNumberLabel.Size = new System.Drawing.Size(235, 32);
            this.deckNumberLabel.TabIndex = 0;
            this.deckNumberLabel.Text = "Number of decks:";
            // 
            // deckNumberText
            // 
            this.deckNumberText.Location = new System.Drawing.Point(433, 171);
            this.deckNumberText.Name = "deckNumberText";
            this.deckNumberText.Size = new System.Drawing.Size(67, 38);
            this.deckNumberText.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(395, 636);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(821, 132);
            this.button1.TabIndex = 2;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RulesSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 1046);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deckNumberText);
            this.Controls.Add(this.deckNumberLabel);
            this.Name = "RulesSelector";
            this.Text = "Blackjack Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RulesSelector_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deckNumberLabel;
        private System.Windows.Forms.TextBox deckNumberText;
        private System.Windows.Forms.Button button1;
    }
}