using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitare_WF
{
    public partial class Form1 : Form
    {
        private bool isSelected = false;
        private PictureBox[] slotsPB = new PictureBox[4];
        private Deck deck = new Deck();
        private PictureBox[] cards = new PictureBox[52];
        private PictureBox[] dealer = new PictureBox[24];
        private List<PictureBox>[] lines = new List<PictureBox>[7];
        private bool win;
        private PictureBox[] hidCards = new PictureBox[27];
        private Image hiddenCardImg = Image.FromFile("..\\..\\..\\PNG\\yellow_back.png");
        private Image glowImg = Image.FromFile("..\\..\\..\\PNG\\glow.png");
        private PictureBox glowingC = new PictureBox();
        private PictureBox glowPB = new PictureBox();
        private PictureBox openDealer = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            slotim();
            Deck();
            //if (win)
            //{
            //    win();
            //}
        }
        public void Deck()
        {
            hiddenCardImg = Resize(hiddenCardImg, 86, 132);
            Random rnd = new Random();
            for (int i = 0; i < 51; i++)
            {
                Card tempC = deck.getCard(i);
                int tempNum = rnd.Next(i, 52);
                deck.setCard(deck.getCard(tempNum), i);
                deck.setCard(tempC, tempNum);
                //MessageBox.Show(deck.getCard(i).ToString());
            } //Shuffle
            for (int i = 0; i <7; i++)
            {
                lines[i] = new List<PictureBox>();
            }
            for (int i = 0; i < 52; i++)
            {
                cards[i] = new PictureBox();
                Image img = Image.FromFile("..\\..\\..\\PNG\\" + deck.getCard(i).getNum().ToString() + deck.getCard(i).getType()[0] + ".png");
                img = Resize(img, 86, 132);
                cards[i].Size = img.Size;
                cards[i].Image = img;
                cards[i].Tag = deck.getCard(i);
                //if (((Card)cards[i].Tag).getNum() == 1)
                //{
                //    cards[i].Click += aceClick; 
                //}
                //else if(((Card)cards[i].Tag).getNum() == 13)
                //{
                //    cards[i].Click += kingClick;
                //}
//                else
//                {
                    cards[i].Click += cardClick;
//                }
                if (i > 27)
                {
                    dealer[i-28] = new PictureBox();
                    dealer[i-28].Location = new Point(470, 50);
                    dealer[i-28].Size = hiddenCardImg.Size;
                    dealer[i-28].Image = hiddenCardImg;
                    dealer[i-28].Tag = cards[i];
                    dealer[i-28].Click += Dealer_Click;
                    Controls.Add(dealer[i-28]);
                }
                else
                {
                    if(i < 27 && i != 0 && i != 2 && i != 5 && i != 9 && i != 14 && i != 20)
                    {
                        hidCards[i] = new PictureBox();
                        Image img2 = Image.FromFile("..\\..\\..\\PNG\\yellow_back.png");
                        img2 = Resize(img2, 86, 132);
                        hidCards[i].Size = img2.Size;
                        hidCards[i].Image = img2;
                        hidCards[i].Tag = cards[i];
                    }
                }
            }
            for(int i = 0; i < 28; i++)
            {
                if (i == 0)
                {

                    lines[0].Add(cards[0]);
                    lines[0][0].Location = new Point(470, 300);
//                    Controls.Add(lines[0][0]);
                }
                if (i == 1 || i == 2)
                {
                    if (i != 2)
                    {
                        lines[1].Add(hidCards[i]);
                    }
                    else
                    {
                        lines[1].Add(cards[i]);
                    }
                    lines[1][i - 1].Location = new Point(600, 300 + (i - 1) * 20);
//                    Controls.Add(lines[1][i - 1]);
                }
                if (i >= 3 && i <= 5)
                {
                    if (i != 5)
                    {
                        lines[2].Add(hidCards[i]);
                    }
                    else
                    {
                        lines[2].Add(cards[i]);
                    }
                    lines[2][i - 3].Location = new Point(730, 300 + (i - 3) * 20);
//                    Controls.Add(lines[2][i - 3]);
                }
                if (i >= 6 && i <= 9)
                {
                    if (i != 9)
                    {
                        lines[3].Add(hidCards[i]);
                    }
                    else
                    {
                        lines[3].Add(cards[i]);
                    }
                    lines[3][i - 6].Location = new Point(860, 300 + (i - 6) * 20);
//                    Controls.Add(lines[3][i - 6]);
                }
                if (i >= 10 && i <= 14)
                {
                    if (i != 14)
                    {
                        lines[4].Add(hidCards[i]);
                    }
                    else
                    {
                        lines[4].Add(cards[i]);
                    }
                    lines[4][i - 10].Location = new Point(990, 300 + (i - 10) * 20);
//                    Controls.Add(lines[4][i - 10]);
                }
                if (i >= 15 && i <= 20)
                {
                    if (i != 20)
                    {
                        lines[5].Add(hidCards[i]);
                    }
                    else
                    {
                        lines[5].Add(cards[i]);
                    }
                    lines[5][i - 15].Location = new Point(1120, 300 + (i - 15) * 20);
//                    Controls.Add(lines[5][i - 15]);
                }
                if (i >= 21 && i <= 27)
                {
                    if (i != 27)
                    {
                        lines[6].Add(hidCards[i]);
                    }
                    else
                    {
                        lines[6].Add(cards[i]);
                    }
                    lines[6][i - 21].Location = new Point(1250, 300 + (i - 21) * 20);
//                    Controls.Add(lines[6][i - 21]);

                }
            }
            for(int i = 0; i < 7; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    Controls.Add(lines[i][j]);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        public void slotim()
        {
            for(int i = 0; i < 4; i++)
            {
                slotsPB[i] = new PictureBox();
                slotsPB[i].Tag = deck.getSlot(i);
                slotsPB[i].Location = new Point(860 + 130*i, 52);
                Image img = Image.FromFile($"..\\..\\..\\PNG\\slot{slotsPB[i].Tag}.png");
                img = Resize(img, 86, 132);
                slotsPB[i].Size = img.Size;
                slotsPB[i].Image = img;
                //slotsPB[i].Click += slotClick;
                Controls.Add(slotsPB[i]);
            }
        }
        public Image Resize(Image image, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics grp = Graphics.FromImage(bmp);
            grp.DrawImage(image, 0, 0, w, h);
            grp.Dispose();

            return bmp;
        }
        public void slotClick(object sender, EventArgs e)
        {

        }
        private void Dealer_Click(object sender, EventArgs e)
        {
            //Remove Glow
            foreach(Control shem in Controls)
            {
                if(shem.Location.X == 595 && shem.Location.Y == 45 && glowingC != null)
                {
                    Controls.Remove(shem);
                    glowingC = null;
                }
            }
            //Dealer Click
            openDealer = (PictureBox)sender;       
            PictureBox openCard = (PictureBox)openDealer.Tag;
            openCard.Location = new Point(600, 50);
            Controls.Add(openCard);
            Controls.Remove(openDealer);
            if (!dealer[0].Equals(openDealer))
            {
                for(int i = 0; i < 24; i++)
                {
                    if(dealer[i].Equals(openDealer))
                    {
                        Controls.Add(dealer[i - 1]);
                        Controls.Remove((PictureBox)dealer[i - 1].Tag);
                    }
                }
            }
            else
            {
                Controls.Add(dealer[23]);
                Controls.Remove((PictureBox)dealer[23].Tag);
            }
        }
        public void cardClick(object sender, EventArgs e)
        {
            PictureBox selectedC = (PictureBox)sender;
            //            PictureBox glowPB = new PictureBox();
            //            glowPB.Click += glowClick; 
            Console.WriteLine($"You clicked {(Card)selectedC.Tag}");
            
            if(selectedC.Image != Image.FromFile("..\\..\\..\\PNG\\yellow_back.png") || selectedC.Image == Image.FromFile("..\\..\\..\\PNG\\Nword.jpg"))
            {
                if(glowingC == null || glowingC.Tag == null)
                {
                    glowImg = Resize(glowImg, 95, 145);
                    glowPB.Location = new Point(selectedC.Location.X - 5, selectedC.Location.Y - 5);
                    glowPB.Image = glowImg;
                    glowPB.Size = glowImg.Size;
                    Controls.Add(glowPB);
                    glowingC = selectedC;
                }
                else
                {
                    if(selectedC == glowingC)
                    {
                        Controls.Remove(glowPB);
                        glowingC = null;
                        Console.WriteLine($"You removed the glow from {(Card)selectedC.Tag}");
                    }
                    else if(((Card)glowingC.Tag).getNum() == 1 && selectedC.Image == Image.FromFile("..\\..\\..\\PNG\\Nword.jpg"))
                    {
                        Controls.Remove(glowPB);
                        glowingC.Location = new Point(selectedC.Location.X, selectedC.Location.Y + 20);
                        glowingC = null;
                    }
                    //deck.areDifferentcolors((Card)selectedC.Tag,(Card)glowingC.Tag) && 
                    else if (deck.areFollowingNum((Card)glowingC.Tag, (Card)selectedC.Tag))
                    {
                        Controls.Remove(glowPB);
                        if(dealer.Contains(glowingC))
                        {
                            for(int i = 0; i < dealer.Length; i++)
                            {
                                if(dealer[i] == glowingC)
                                {
                                    for(int p = i; p < dealer.Length - 1; p++)
                                    {
                                        dealer[p] = dealer[p + 1];
                                    }
                                    dealer[dealer.Length - 1] = null;
                                    break;
                                }
                            }
                            openDealer = null;
                            glowingC.Location = new Point(selectedC.Location.X, selectedC.Location.Y + 20);
                        }
                        int j, k = 0;
                        PictureBox[] tempCs = new PictureBox[0];
                        for (int i = 0; i < 7; i++)
                        {
                            if (lines[i].Contains(glowingC))
                            {
                                for(j = 0; j < lines[i].Count; j++)
                                {
                                    if (lines[i][j] == glowingC)
                                    {
                                        tempCs = new PictureBox[lines[i].Count - j];
                                        for(k = 0; k < tempCs.Length; k++)
                                        {
                                            tempCs[k] = lines[i][j+k];
                                        }
                                    }
                                } 
                                for(int u = 0; u < tempCs.Length; u++)
                                {
                                    tempCs[u].Location = new Point(selectedC.Location.X, selectedC.Location.Y + (u + 1) * 20);
                                    lines[i].Remove(tempCs[u]);
                                }
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            if (lines[i].Contains(selectedC))
                            {
                                for (int r = 0; r < tempCs.Length; r++)
                                {
                                    lines[i].Add(tempCs[r]);
                                }
                            }
                        }
                        Console.WriteLine($"You moved {(Card)glowingC.Tag} and {tempCs.Length - 1} other Cards to under {(Card)selectedC.Tag}");
                        glowingC = null;
                        k = 0;
                    }
                }
            }
            if (glowingC != null) { Console.WriteLine($"GlowingC is {(Card)glowingC.Tag}"); }
        }
        public void moveCardsToSlots(PictureBox c1, PictureBox slot)
        {
            
        }
        public void aceClick(object sender, EventArgs e)
        {
            PictureBox selectedAce = (PictureBox)sender;
        }
        public void kingClick(object sender, EventArgs e)
        {

        }
        public void moveAceToSlot(PictureBox Ace, PictureBox slot)
        {
            slot.Tag = (Card)Ace.Tag;

        }
        public void glowClick(object sender, EventArgs e)
        {
            PictureBox glowPB = (PictureBox)sender;
            Controls.Remove(glowPB);
            isSelected = false;
            glowingC = null;
        }
    }
}
//TODO:
//can't move a card if there's already a card there.
//move a couple of cards at the same time
//move to the slots
//add dealer counter
//
//Bugs:
//When you press the deck, the card you pulled out of the deck disapears
//newer bug: you can't even pull cards out of the deck