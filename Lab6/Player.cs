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
    abstract class Player : FlowLayoutPanel
    {
        protected ManualResetEvent _clickEvent = new ManualResetEvent(false);
        protected Card _pressedCard;
        protected List<Card> _cards;
        protected Card _lastTakedCard;
        protected string _name;
        protected int _winnings;
        protected char _type;
        public Player(string name, char type)
        {
            _name = name;
            _cards = new List<Card>();
            _winnings = 0;
            AutoSize = true;
        }

        public string GetName()
        {
            return _name;
        }

        public List<Card> GetDeck()
        {
            return _cards;
        }

        public char GetType()
        {
            return _type;
        }

        public ManualResetEvent GetClickEvent()
        {
            return _clickEvent;
        }

        public void AddCard(Card card)
        {

            card.Click += (sender, e) =>
            {
                _pressedCard = (Card)sender;
                _clickEvent.Set();
            };

            _cards.Add(card);
            Controls.Add(card);
            Location = new Point(Location.X - (card.Width / 2), Location.Y);
            if (Location.X < 0)
            {
                Location = new Point(0, Location.Y);
            }
        }
        public Card TakeCard(int index)
        {
            _lastTakedCard = _cards[index];
            BeginInvoke((MethodInvoker)(() =>
            {
                Controls.Remove(_cards[index]);
                _cards.RemoveAt(index);
                Location = new Point((Parent.Size.Width - _cards.Count * _lastTakedCard.Width) / 2, Location.Y);
                if (Location.X < 0)
                {
                    Location = new Point(0, Location.Y);
                }
            }));
            
            return _lastTakedCard;
        }

        

        public int GetWinnings()
        {
            return _winnings;
        }

        public void IncWinnings()
        {
            _winnings++;
        }

        public void DecWinnings()
        {
            _winnings--;
        }

        public Card GetLastTakedCard()
        {
            return _lastTakedCard;
        }

        public void ShowCards()
        {
            foreach (var i in _cards)
            {
                i.Show();
            }
        }

        public void HideCards()
        {
            foreach (var i in _cards)
            {
                i.Hide();
            }
        }
        public abstract Card TakeGameCard();
        public abstract Card TakeGameCardBySuit(int suit);
    }
}
