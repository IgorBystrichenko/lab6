using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class RandomCardPlayer : Player
    {
        public RandomCardPlayer(string name) : base(name, 'r') {  }

        public override Card TakeGameCard()
        {
            return TakeCard(IntUtil.Random(0, _cards.Count - 1));
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

            int rand = IntUtil.Random(1, count);
            int index = -1;
            for (int i = 0; i < _cards.Count && rand > 0; i++)
            {
                if (_cards[i].GetSuit() == suit)
                {
                    rand--;
                    if (rand == 0)
                    {
                        index = i;
                    }
                }
            }

            return TakeCard(index);
        }
    }
}
