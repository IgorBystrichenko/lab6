using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class SmallestCardPlayer : Player
    {
        public SmallestCardPlayer(string name) : base(name, 's') {  }

        public override Card TakeGameCard()
        {
            int index = 0;
            for (int i = 1; i < _cards.Count; i++)
            {
                if (_cards[i].GetRank() < _cards[index].GetRank())
                {
                    index = i;
                }
            }
            return TakeCard(index);
        }

        public override Card TakeGameCardBySuit(int suit)
        {
            int index = -1;
            for (int i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].GetSuit() == suit && (index == -1 || _cards[i].GetRank() < _cards[index].GetRank()))
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                return TakeGameCard();
            }

            return TakeCard(index);

        }
    }
}
