using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace BlackjackSimulator
{
    public class Hand
    {
        //Size of images is 467, 569
        List<PictureBox> cards;
        List<string> cardString;
        public Hand()
        {
            cards = new List<PictureBox>();
            cardString = new List<string>();
        }

        public void addCard(Bitmap image)
        {
            PictureBox pb = new PictureBox();
            pb.Image = image;
            pb.Size = pb.Image.Size;
            pb.Visible = false;
            cards.Add(pb);            
        }
        public void addString(string str)
        {
            cardString.Add(str);
        }
        public void removeCard(int index)
        {
            cards.RemoveAt(index);
        }
        public void clear()
        {
            cards.Clear();
            cardString.Clear();
        }

        public List<PictureBox> getHand()
        {
            return cards;
        }
        public List<string> getHandString()
        {
            return cardString;
        }
        public Hand copy()
        {
            Hand h = (Hand)this.MemberwiseClone();
            h.cards = new List<PictureBox>(cards);
            h.cardString = new List<string>(cardString);
            return h;
        }
    }
}
