using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitare_WF
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
        public Card(Card c)
        {
            num = c.num;
            type = c.type;
        }
        public override string ToString()
        {
            return $"{type} || {num}";
        }
    }
}
