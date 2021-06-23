using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackSimulator
{
    public partial class SinglePlayer : Form
    {
        int startingDeckCount;
        int runningCount = 0;
        int startingCash;
        int betAmount = 0;
        List<int> bets = new List<int>();

        bool standOnSoftSeventeen;
        bool? playerWon = null;
        bool isSplit = false;

        Deck shoe;
        Hand player;
        Hand dealer;
        Hand currentPlayerHand;
        List<Hand> splitHands = new List<Hand>();

        public SinglePlayer(int decks, bool stand, int money)
        {
            InitializeComponent();
            startingDeckCount = decks;
            standOnSoftSeventeen = stand;
            startingCash = money;
            doubleButton.Visible = false;
            hitButton.Visible = false;
            standButton.Visible = false;
            splitButton.Visible = false;
        }

        private void SinglePlayer_Load(object sender, EventArgs e)
        {
            shoe = new Deck(startingDeckCount);
            shoe.shuffle();
            updateLabels();
        }
        private void SinglePlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void splitButton_Click(object sender, EventArgs e)
        {
            isSplit = true;
            foreach (PictureBox pb in currentPlayerHand.getHand())
            {
                pb.Visible = false;
                Controls.Remove(pb);
            }

            Hand p1 = new Hand();
            p1.addCard(stringToImage(currentPlayerHand.copy().getHandString()[0]));
            p1.addString(currentPlayerHand.copy().getHandString()[0]);

            Hand p2 = new Hand();
            p2.addCard(stringToImage(currentPlayerHand.copy().getHandString()[1]));
            p2.addString(currentPlayerHand.copy().getHandString()[1]);

            splitHands.Insert(0, p2);
            splitHands.Insert(0, p1);
            bets.Insert(0, betAmount);
            bets.Insert(0, betAmount);

            currentPlayerHand = splitHands[0];

            showPlayerHands(splitHands);
            updateLabels();
        }

        private void dealCards_Click(object sender, EventArgs e)
        {
            bool isNumeric = int.TryParse(betTextBox.Text, out int n);
            if (isNumeric && int.Parse(betTextBox.Text) < startingCash)
            {
                warningLabel.Text = "";
                betAmount = int.Parse(betTextBox.Text);
                if (player != null)
                {
                    while (Controls.OfType<PictureBox>().Count() > 0)
                    {
                        Controls.Remove(Controls.OfType<PictureBox>().First());
                    }
                    player.clear();
                    dealer.clear();
                    playerWon = null;
                    winnerLabel.Text = "Dealer";
                }
                playGame();
                updateLabels();
                betLabel.Visible = false;
                betTextBox.Visible = false;
                dealCards.Visible = false;
                splitButton.Visible = true;
                splitButton.Enabled = false;
                doubleButton.Visible = true;
                doubleButton.Enabled = true;
                hitButton.Visible = true;
                hitButton.Enabled = true;
                standButton.Visible = true;
                standButton.Enabled = true;
            }
            else if(isNumeric && int.Parse(betTextBox.Text) > startingCash)
            {
                warningLabel.Text = "Please enter a valid number. You cannot bet more money than what you have";
            }
            else
            {
                warningLabel.Text = "Please enter a number. Just one. Nothing but digit(s).";
            }
            if (player.getHandString()[0][0] == player.getHandString()[1][0] && player.getHandString().Count == 2)
            {
                splitButton.Enabled = true;
            }
        }

        private void doubleButton_Click(object sender, EventArgs e)
        {
            drawCard(currentPlayerHand);
            if (!isSplit)
            {
                showPlayerHand(currentPlayerHand);
            }
            else
            {
                bets[splitHands.IndexOf(currentPlayerHand)] *= 2;
                showPlayerHands(splitHands);
            }
            betAmount *= 2;
            standButton_Click(sender, e);
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            drawCard(currentPlayerHand);
            doubleButton.Enabled = false;
            if (!isSplit)
            {
                showPlayerHand(currentPlayerHand);
            }
            else
            {
                showPlayerHands(splitHands);
            }
            if(valuesOfHand(currentPlayerHand)[1] > 21)
            {
                if (!isSplit)
                {
                    standButton_Click(sender, e);
                }
                else
                {
                    int i = splitHands.IndexOf(currentPlayerHand);
                    if (i < splitHands.Count - 1)
                    {
                        currentPlayerHand = splitHands[i+1];
                        doubleButton.Enabled = true;
                    }
                    else
                    {
                        standButton_Click(sender, e);
                    }
                }
            }
            updateLabels();
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            if ((isSplit && splitHands.IndexOf(currentPlayerHand) == splitHands.Count - 1) || !isSplit)
            {
                revealDealerCard();
                dealerPlay();
                splitButton.Enabled = false;
                hitButton.Enabled = false;
                standButton.Enabled = false;
                doubleButton.Enabled = false;
                dealCards.Visible = true;
                betLabel.Visible = true;
                betTextBox.Visible = true;
                updateLabels();
            }
            else
            {
                int i = splitHands.IndexOf(currentPlayerHand);
                if (i < splitHands.Count - 1)
                {
                    currentPlayerHand = splitHands[i + 1];
                }
                else
                {
                    standButton_Click(sender, e);
                }
            }
        }

        public void playGame()
        {
            player = new Hand();
            dealer = new Hand();

            drawCard(player);
            drawCard(player);
            //player.addCard(stringToImage("AC"));
            //player.addString("AC");
            //runningCount += stringToTrueCountValue("AC");
            //player.addCard(stringToImage("AS"));
            //player.addString("AS");
            //runningCount += stringToTrueCountValue("AS");

            dealer.addCard(Properties.Resources.BACK);
            drawCard(dealer);

            showPlayerHand(player);
            showDealerHand(dealer, false);

            currentPlayerHand = player;
        }

        public void dealerPlay()
        {
            if(!isSplit)
            {
                if (standOnSoftSeventeen)
                {
                    while (valuesOfHand(dealer)[0] < 17)
                    {
                        drawCard(dealer);
                    }
                }
                else
                {
                    while (valuesOfHand(dealer)[1] < 17)
                    {
                        drawCard(dealer);
                    }
                }
            }
            else
            {
                foreach (Hand h in splitHands)
                {
                    if (standOnSoftSeventeen)
                    {
                        while (valuesOfHand(dealer)[0] < 17 && evaluateWinner(h, dealer) == h)
                        {
                            drawCard(dealer);
                        }
                    }
                    else
                    {
                        while (valuesOfHand(dealer)[1] < 17 && evaluateWinner(h, dealer) == h)
                        {
                            drawCard(dealer);
                        }
                    }                    
                }
            }
            playerWon = null;
            formatDealerCards(dealer);
            foreach (PictureBox pb in dealer.getHand())
            {
                pb.Visible = true;
                this.Controls.Add(pb);
                pb.BringToFront();
            }

            if (!isSplit)
            {
                if (evaluateWinner(player, dealer) == dealer)
                {
                    startingCash -= betAmount;
                    winnerLabel.Text = "Dealer wins";
                }
                else
                {
                    startingCash += 2 * betAmount;
                    winnerLabel.Text = "Player wins";
                }
            }
            else
            {
                foreach (Hand h in splitHands)
                {
                    if (evaluateWinner(player, dealer) == dealer)
                    {
                        startingCash -= bets[splitHands.IndexOf(h)];
                        winnerLabel.Text = "Dealer wins";
                    }
                    else
                    {
                        startingCash += 2 * bets[splitHands.IndexOf(h)];
                        winnerLabel.Text = "Player wins";
                    }
                }
            }
        }

        public void updateLabels()
        {
            if (!isSplit)
            {
                if (dealCards.Visible == false)
                {
                    moneyLabel.Text = "Money: " + (startingCash - betAmount);
                }
                else
                {
                    moneyLabel.Text = "Money: " + startingCash;
                }
            }
            else
            {
                int totalBet = 0;
                for(int i = 0; i < bets.Count; i++)
                {
                    totalBet += bets[i];
                }
                if (dealCards.Visible == false)
                {
                    moneyLabel.Text = "Money: " + (startingCash - totalBet);
                }
                else
                {
                    moneyLabel.Text = "Money: " + startingCash;
                }
            }
            runningCountLabel.Text = "Running Count: " + runningCount;
            trueCountLabel.Text = "True Count: " + (runningCount / cardsRemainingToDecks(shoe.getCards().Count())).ToString("0.0") ;
            decksRemainingLabel.Text = "Total Decks Reamining: " + cardsRemainingToDecks(shoe.getCards().Count);
            cardsRemainingLabel.Text = "Total Cards Remaining: " + shoe.getCards().Count;
            if (player != null)
            {
                softValueLabel.Text = "Soft Value: " + valuesOfHand(currentPlayerHand)[0];
                hardValueLabel.Text = "Hard Value: " + valuesOfHand(currentPlayerHand)[1];
            }
        }
        public void drawCard(Hand h)
        {
            string card = shoe.Draw();
            h.addCard(stringToImage(card));
            h.addString(card);
            runningCount += stringToTrueCountValue(card);
        }
        public Hand evaluateWinner(Hand player, Hand dealer)
        {
            int dealerSoft = valuesOfHand(dealer)[0];
            int dealerHard = valuesOfHand(dealer)[1];
            int playerSoft = valuesOfHand(player)[0];
            int playerHard = valuesOfHand(player)[1];

            int dealerValue = -1;
            int playerValue = -1;

            if(dealerHard > 21)
            {
                playerWon = true;
            }
            if(playerHard > 21)
            {
                playerWon = false;
            }

            if (playerWon == null)
            {
                if (dealerSoft > dealerHard && dealerSoft < 21)
                {
                    dealerValue = dealerSoft;
                }
                else
                {
                    dealerValue = dealerHard;
                }

                if (playerSoft > playerHard && playerSoft < 21)
                {
                    playerValue = playerSoft;
                }
                else
                {
                    playerValue = playerHard;
                }

                if (playerValue > 0 && dealerValue > 0 && playerValue > dealerValue)
                {
                    playerWon = true;
                }
                else
                {
                    playerWon = false;
                }
            }

            if(playerWon == true)
            {
                return player;
            }
            else
            {
                return dealer;
            }
        }

        public void showPlayerHand(Hand h)
        {
            formatPlayerCards(h);
            foreach (PictureBox pb in h.getHand())
            {                
                pb.Visible = true;
                this.Controls.Add(pb);
                pb.BringToFront();
            }
        }
        public void formatPlayerCards(Hand h)
        {
            //Center location is new Point(Form.Width/2 - pictureBox.Image.Width/2, Form.Height/3 + Form.Height/4);
            List<PictureBox> cards = h.getHand();
            cards[0].Location = new Point(Width / 2 - cards[0].Image.Width / 2, Height / 3 + Height / 4);
            for(int i = 1; i < cards.Count; i++)
            {
                cards[i].Location = new Point(cards[0].Location.X + (50 * i), cards[0].Location.Y);
            }
        }
        public void showPlayerHands(List<Hand> hands)
        {
            formatSplitPlayerCard(hands);
            foreach(Hand h in hands)
            {
                foreach(PictureBox pb in h.getHand())
                {
                    pb.Visible = true;
                    this.Controls.Add(pb);
                    pb.BringToFront();
                }
            }
        }
        public void formatSplitPlayerCard(List<Hand> hands)
        {
            int handCount = hands.Count;
            foreach (Hand h in hands)
            {
                h.getHand()[0].Location = new Point(Width / 2 - 2*h.getHand()[0].Image.Width + 400 * hands.IndexOf(h), Height / 3 + Height / 4);
                for (int i = 1; i < h.getHand().Count; i++)
                {
                    h.getHand()[i].Location = new Point(h.getHand()[0].Location.X + (50 * i), h.getHand()[0].Location.Y);
                }
            }
        }

        public void showDealerHand(Hand h, bool isPlayerStanding)
        {
            if (isPlayerStanding)
            {
                h.removeCard(0);
            }
            formatDealerCards(h);
            foreach (PictureBox pb in h.getHand())
            {
                pb.Visible = true;
                this.Controls.Add(pb);
                pb.BringToFront();
            }

        }
        public void formatDealerCards(Hand h)
        {
            //Center location is new Point(Form.Width/2 - pictureBox.Image.Width/2, Form.Height/4);
            List<PictureBox> cards = h.getHand();
            cards[0].Location = new Point(Width / 2 - cards[0].Image.Width / 2, Height / 12);
            for (int i = 1; i < cards.Count; i++)
            {
                cards[i].Location = new Point(cards[0].Location.X + (50 * i), cards[0].Location.Y);
            }
        }
        public void revealDealerCard()
        {
            drawCard(dealer);
            showDealerHand(dealer, true);
        }

        public double cardsRemainingToDecks(int numOfCardsRemaining)
        {
            //For now, only do half decks.
            int n = numOfCardsRemaining;
            int wholeDecksRemaining = n / 52;
            int leftover = n % 52;
            double dec = 0;
            if(leftover >= 39)
            {
                wholeDecksRemaining++;
            }
            else if(leftover >= 13)
            {
                dec = 0.5;
            }
            return wholeDecksRemaining + dec;
        }

        public List<int> valuesOfHand(Hand h)
        {
            List<int> value = new List<int>();
            int softCount = 0;
            int hardCount = 0;
            foreach (string s in h.getHandString())
            {
                if (s[0].ToString() == "A")
                {
                    softCount += 11;
                    hardCount++;
                }
                else
                {
                    softCount += stringToCardValue(s);
                    hardCount += stringToCardValue(s);
                }
            }
            value.Add(softCount);
            value.Add(hardCount);
            return value;
        }
        public int stringToCardValue(string str)
        {
            string b = str[0].ToString();
            switch (b)
            {
                case "1":
                    return 1;

                case "2":
                    return 2;

                case "3":
                    return 3;

                case "4":
                    return 4;

                case "5":
                    return 5;

                case "6":
                    return 6;

                case "7":
                    return 7;

                case "8":
                    return 8;

                case "9":
                    return 9;

                case "T":
                    return 10;

                case "J":
                    return 10;

                case "Q":
                    return 10;

                case "K":
                    return 10;
            }
            return 0;
        }
        public int evaluteTrueCount(Hand h)
        {
            if (h != null)
            {
                int count = 0;
                foreach (string s in h.getHandString())
                {
                    count += stringToTrueCountValue(s);
                }
                return count;
            }
            return 0;
        }
        public int stringToTrueCountValue(string str)
        {
            string b = str[0].ToString();
            switch (b)
            {
                case "A":
                    return -1;

                case "1":
                    return 1;

                case "2":
                    return 1;

                case "3":
                    return 1;

                case "4":
                    return 1;

                case "5":
                    return 1;

                case "6":
                    return 1;

                case "7":
                    return 0;

                case "8":
                    return 0;

                case "9":
                    return 0;

                case "T":
                    return -1;

                case "J":
                    return -1;

                case "Q":
                    return -1;

                case "K":
                    return -1;

                default:
                    return 0;
            }

        }
        
        public Bitmap stringToImage(string s)
        {   
            Bitmap image = new Bitmap(Properties.Resources._2C);
            image = (Bitmap)Bitmap.FromFile(@"..\..\Resources\" + s + ".JPG");          
            return image;
        }

        
    }
}
