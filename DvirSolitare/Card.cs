using System;
using System.Collections.Generic;
using System.Text;

namespace DvirSolitare
{
    class Card
    {
        private int num;
        private String type;

        public Card(int num, string type)
        {
            this.num = num;
            this.type = type;
        }
        public int getNum() { return num; }
        public String getType() { return type; }
        public void setNum(int num) { this.num = num; }
        public void setType(String type) { this.type = type; }
        public override string ToString()
        {
            return $"{type} || {num}";
        }
        //public bool areFollowingNum(Card c1, Card c2)
        ////are the Cards one after the other
        //{
        //    if (c1.getNum() == c2.getNum() - 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //public bool areDifferentcolors(Card c1, Card c2)
        ////are the Cards diffrent colors
        //{
        //    if ((c1.getType() == "spade" || c1.getType() == "Club") && (c2.getType() == "Heart" || c2.getType() == "Diamond"))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
