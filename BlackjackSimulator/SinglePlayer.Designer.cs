namespace BlackjackSimulator
{
    partial class SinglePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePlayer));
            this.playerCardsImage = new System.Windows.Forms.ImageList(this.components);
            this.dealCards = new System.Windows.Forms.Button();
            this.cardsRemainingLabel = new System.Windows.Forms.Label();
            this.decksRemainingLabel = new System.Windows.Forms.Label();
            this.hitButton = new System.Windows.Forms.Button();
            this.standButton = new System.Windows.Forms.Button();
            this.trueCountLabel = new System.Windows.Forms.Label();
            this.softValueLabel = new System.Windows.Forms.Label();
            this.hardValueLabel = new System.Windows.Forms.Label();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.runningCountLabel = new System.Windows.Forms.Label();
            this.doubleButton = new System.Windows.Forms.Button();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.betLabel = new System.Windows.Forms.Label();
            this.betTextBox = new System.Windows.Forms.TextBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.splitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerCardsImage
            // 
            this.playerCardsImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("playerCardsImage.ImageStream")));
            this.playerCardsImage.TransparentColor = System.Drawing.Color.Transparent;
            this.playerCardsImage.Images.SetKeyName(0, "AC.JPG");
            // 
            // dealCards
            // 
            this.dealCards.Location = new System.Drawing.Point(1094, 669);
            this.dealCards.Name = "dealCards";
            this.dealCards.Size = new System.Drawing.Size(241, 121);
            this.dealCards.TabIndex = 1;
            this.dealCards.Text = "Deal";
            this.dealCards.UseVisualStyleBackColor = true;
            this.dealCards.Click += new System.EventHandler(this.dealCards_Click);
            // 
            // cardsRemainingLabel
            // 
            this.cardsRemainingLabel.AutoSize = true;
            this.cardsRemainingLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cardsRemainingLabel.Location = new System.Drawing.Point(0, 1880);
            this.cardsRemainingLabel.Name = "cardsRemainingLabel";
            this.cardsRemainingLabel.Size = new System.Drawing.Size(313, 32);
            this.cardsRemainingLabel.TabIndex = 3;
            this.cardsRemainingLabel.Text = "Total Cards Remaining:";
            // 
            // decksRemainingLabel
            // 
            this.decksRemainingLabel.AutoSize = true;
            this.decksRemainingLabel.Location = new System.Drawing.Point(0, 1839);
            this.decksRemainingLabel.Name = "decksRemainingLabel";
            this.decksRemainingLabel.Size = new System.Drawing.Size(316, 32);
            this.decksRemainingLabel.TabIndex = 4;
            this.decksRemainingLabel.Text = "Total Decks Remaining:";
            // 
            // hitButton
            // 
            this.hitButton.Location = new System.Drawing.Point(3111, 1441);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(381, 85);
            this.hitButton.TabIndex = 5;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // standButton
            // 
            this.standButton.Location = new System.Drawing.Point(3111, 1520);
            this.standButton.Name = "standButton";
            this.standButton.Size = new System.Drawing.Size(381, 85);
            this.standButton.TabIndex = 6;
            this.standButton.Text = "Stand";
            this.standButton.UseVisualStyleBackColor = true;
            this.standButton.Click += new System.EventHandler(this.standButton_Click);
            // 
            // trueCountLabel
            // 
            this.trueCountLabel.AutoSize = true;
            this.trueCountLabel.Location = new System.Drawing.Point(0, 41);
            this.trueCountLabel.Name = "trueCountLabel";
            this.trueCountLabel.Size = new System.Drawing.Size(164, 32);
            this.trueCountLabel.TabIndex = 7;
            this.trueCountLabel.Text = "True Count:";
            // 
            // softValueLabel
            // 
            this.softValueLabel.AutoSize = true;
            this.softValueLabel.Location = new System.Drawing.Point(1518, 1741);
            this.softValueLabel.Name = "softValueLabel";
            this.softValueLabel.Size = new System.Drawing.Size(155, 32);
            this.softValueLabel.TabIndex = 8;
            this.softValueLabel.Text = "Soft Value:";
            // 
            // hardValueLabel
            // 
            this.hardValueLabel.AutoSize = true;
            this.hardValueLabel.Location = new System.Drawing.Point(1518, 1809);
            this.hardValueLabel.Name = "hardValueLabel";
            this.hardValueLabel.Size = new System.Drawing.Size(165, 32);
            this.hardValueLabel.TabIndex = 9;
            this.hardValueLabel.Text = "Hard Value:";
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Location = new System.Drawing.Point(1927, 67);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(99, 32);
            this.winnerLabel.TabIndex = 10;
            this.winnerLabel.Text = "Dealer";
            // 
            // runningCountLabel
            // 
            this.runningCountLabel.AutoSize = true;
            this.runningCountLabel.Location = new System.Drawing.Point(0, 9);
            this.runningCountLabel.Name = "runningCountLabel";
            this.runningCountLabel.Size = new System.Drawing.Size(213, 32);
            this.runningCountLabel.TabIndex = 11;
            this.runningCountLabel.Text = "Running Count:";
            // 
            // doubleButton
            // 
            this.doubleButton.Location = new System.Drawing.Point(3111, 1361);
            this.doubleButton.Name = "doubleButton";
            this.doubleButton.Size = new System.Drawing.Size(381, 85);
            this.doubleButton.TabIndex = 12;
            this.doubleButton.Text = "Double Down";
            this.doubleButton.UseVisualStyleBackColor = true;
            this.doubleButton.Click += new System.EventHandler(this.doubleButton_Click);
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(3501, 9);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(108, 32);
            this.moneyLabel.TabIndex = 13;
            this.moneyLabel.Text = "Money:";
            // 
            // betLabel
            // 
            this.betLabel.AutoSize = true;
            this.betLabel.Location = new System.Drawing.Point(1094, 581);
            this.betLabel.Name = "betLabel";
            this.betLabel.Size = new System.Drawing.Size(66, 32);
            this.betLabel.TabIndex = 14;
            this.betLabel.Text = "Bet:";
            // 
            // betTextBox
            // 
            this.betTextBox.Location = new System.Drawing.Point(1185, 581);
            this.betTextBox.Name = "betTextBox";
            this.betTextBox.Size = new System.Drawing.Size(100, 38);
            this.betTextBox.TabIndex = 15;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(1094, 519);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 32);
            this.warningLabel.TabIndex = 16;
            // 
            // splitButton
            // 
            this.splitButton.Location = new System.Drawing.Point(3111, 1281);
            this.splitButton.Name = "splitButton";
            this.splitButton.Size = new System.Drawing.Size(381, 85);
            this.splitButton.TabIndex = 17;
            this.splitButton.Text = "Split";
            this.splitButton.UseVisualStyleBackColor = true;
            this.splitButton.Click += new System.EventHandler(this.splitButton_Click);
            // 
            // SinglePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3844, 1912);
            this.Controls.Add(this.splitButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.betTextBox);
            this.Controls.Add(this.betLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.doubleButton);
            this.Controls.Add(this.runningCountLabel);
            this.Controls.Add(this.winnerLabel);
            this.Controls.Add(this.hardValueLabel);
            this.Controls.Add(this.softValueLabel);
            this.Controls.Add(this.trueCountLabel);
            this.Controls.Add(this.standButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.decksRemainingLabel);
            this.Controls.Add(this.cardsRemainingLabel);
            this.Controls.Add(this.dealCards);
            this.Name = "SinglePlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blackjack Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SinglePlayer_FormClosing);
            this.Load += new System.EventHandler(this.SinglePlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList playerCardsImage;
        private System.Windows.Forms.Button dealCards;
        private System.Windows.Forms.Label cardsRemainingLabel;
        private System.Windows.Forms.Label decksRemainingLabel;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button standButton;
        private System.Windows.Forms.Label trueCountLabel;
        private System.Windows.Forms.Label softValueLabel;
        private System.Windows.Forms.Label hardValueLabel;
        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Label runningCountLabel;
        private System.Windows.Forms.Button doubleButton;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label betLabel;
        private System.Windows.Forms.TextBox betTextBox;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button splitButton;
    }
}