using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    class MainPlayer : Player
    {

        public MainPlayer(string name) : base(name) { ShowCards();}

        public override Card TakeGameCard()
        {
            
            _clickEvent.Reset();
            _clickEvent.WaitOne();
            int index = 0;
            for (int i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].GetRank() == _pressedCard.GetRank() && _cards[i].GetSuit() == _pressedCard.GetSuit())
                {
                    index = i;
                    break;
                }
            }
            return TakeCard(index);
        }

        public override Card TakeGameCardBySuit(int suit)
        {

            int count = 0;
            for (int i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].GetSuit() == suit)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return TakeGameCard();
            }

            foreach (var i in _cards)
            {
                if (i.GetSuit() != suit)
                {
                    i.BeginInvoke((MethodInvoker)(() =>
                    {
                        i.Hide();
                    }));
                    
                }
            }
            _clickEvent.Reset();
            _clickEvent.WaitOne();
            int index = 0;
            for (int i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].GetRank() == _pressedCard.GetRank() && _cards[i].GetSuit() == _pressedCard.GetSuit())
                {
                    index = i;
                    break;
                }
            }

            foreach (var i in _cards)
            {
                if (i.GetSuit() != suit)
                {
                    i.BeginInvoke((MethodInvoker)(() =>
                    {
                        i.Show();
                    }));
                }
            }
            return TakeCard(index);
        }
    }
}
