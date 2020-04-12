﻿using System;
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
        private PictureBox[] slots = new PictureBox[4];
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
        private int linesNum;
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
            for(int i = 0 ; i < 52 ; i++)
            {
                cards[i] = new PictureBox();
                Image img = Image.FromFile("..\\..\\..\\PNG\\" + deck.getCard(i).getNum().ToString() + deck.getCard(i).getType()[0] + ".png" );
                img = Resize(img, 86, 132);
                cards[i].Size = img.Size;
                cards[i].Image = img;
                cards[i].Tag = deck.getCard(i);
                cards[i].Click += cardClick;
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
                slots[i] = new PictureBox();
                slots[i].Location = new Point(860 + 130*i, 52);
                Image img = Image.FromFile("..\\..\\..\\PNG\\Nword.jpg");
                img = Resize(img, 86, 132);
                slots[i].Size = img.Size;
                slots[i].Image = img;
                Controls.Add(slots[i]);
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
        private void Dealer_Click(object sender, EventArgs e)
        {
            //Remove Glow
            foreach(Control shem in Controls)
            {
                if(shem.Location.X == 595 && shem.Location.Y == 45)
                {
                    Controls.Remove(shem);
                    glowingC = null;
                    isSelected = false;
                }
            }
            //Dealer Click
            PictureBox openDealer = (PictureBox)sender;       
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

            if(selectedC.Image != Image.FromFile("..\\..\\..\\PNG\\yellow_back.png"))
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
                    }
                    else if(deck.areDifferentcolors((Card)selectedC.Tag,(Card)glowingC.Tag) && deck.areFollowingNum((Card)glowingC.Tag, (Card)selectedC.Tag))
                    {
                        Controls.Remove(glowPB);
                        glowingC.Location = new Point(selectedC.Location.X, selectedC.Location.Y + 20);
                        for(int i = 0; i < 7; i++)
                        {
                            if (lines[i].Contains(glowingC))
                            {
                                lines[i].Remove(glowingC);
                            }
                            else if (lines[i].Contains(selectedC))
                            {
                                lines[i].Add(glowingC);
                            }
                        }
                        glowingC = null;
                    }
                }
            }
            
        }
        public void glowClick(object sender, EventArgs e)
        {
            PictureBox glowPB = (PictureBox)sender;
            Controls.Remove(glowPB);
            isSelected = false;
            glowingC = null;
        }
        //public void pictureBox1_Click(object sender, EventArgs e) { }
        //public void pictureBox7_Click(object sender, EventArgs e) { }
    }
}