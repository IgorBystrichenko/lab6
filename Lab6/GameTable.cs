using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    class GameTable
    {
        private List<Card> _deck;
        private PlayersData _data;

        public GameTable(PlayersData data, List<Card> deck)
        {
            _data = data;
            _deck = deck;
        }

        public void ShuffleDeck()
        {
            _deck.Sort((x, y) => IntUtil.Random(-1, 1));
        }

        public static int CompareCards(Card card1, Card card2)
        {
            if (card1.GetSuit() == card2.GetSuit())
            {
                return CompareCardRanks(card1, card2);
            }
            else
            {
                throw new Exception("Сomparison of cards of different suits");
            }
        }

        public static int CompareCardRanks(Card card1, Card card2)
        {
            return card1.GetRank() - card2.GetRank();
        }

        public void GiveCards(int number)
        {
            if (number < 0 || number > _deck.Count / _data.GetNumberOfPlayers())
            {
                throw new Exception("Wrong number of cards!");
            }
            SortedList<int, Player> map = _data.PlayerMapById();
            foreach (var i in map)
            {
                for (int j = 0; j < number; j++)
                {
                    i.Value.AddCard(_deck[0]);
                    _deck.RemoveAt(0);
                }
            }
        }

        public int GetNumberOfPlayers()
        {
            return _data.GetNumberOfPlayers();
        }

        public ref readonly PlayersData GetPlayersData()
        {
            return ref _data;
        }

        public ref readonly List<Card> GetDeck()
        {
            return ref _deck; 
        }
        public int Play(int firstPlayerIndex, TableLayoutPanel panel)
        {
            if (_data.PlayerMapById().ToList()[firstPlayerIndex].Value.GetDeck().Count == 0)
            {
                throw new Exception("Players don't have cards");
            }

            return DoPlay(firstPlayerIndex, panel);
            
        }
        private int DoPlay(int firstPlayerIndex, TableLayoutPanel panel)
        {
            List<KeyValuePair<int, Player>> list = _data.PlayerMapById().ToList();
            ManualResetEvent e = new ManualResetEvent(false);

            Card biggestCard = list[firstPlayerIndex].Value.TakeGameCard();
            char suit = biggestCard.GetSuit();
            int winner = firstPlayerIndex;
            e.Reset();
            panel.BeginInvoke((MethodInvoker)(() =>
            {
                biggestCard.Show();
                Label l1 = new Label();
                l1.Size = biggestCard.Size;
                l1.Image = biggestCard.Image;
                panel.Controls.Add(l1, 0, list.Count - firstPlayerIndex - 1);
                e.Set();
            }));
            e.WaitOne();
            int i = (firstPlayerIndex + 1) % list.Count;
            

            while (i != firstPlayerIndex)
            {
                
                Card playerCard = list[i].Value.TakeGameCardBySuit(suit);
                e.Reset();
                panel.BeginInvoke((MethodInvoker)(() =>
                {
                    playerCard.Show();
                    Label l2 = new Label();
                    l2.Size = playerCard.Size;
                    l2.Image = playerCard.Image;
                    panel.Controls.Add(l2, 0, list.Count - i - 1);
                    e.Set();
                }));
                
                e.WaitOne();
                if (playerCard.GetSuit() == suit && CompareCards(playerCard, biggestCard) > 0)
                {
                    biggestCard = playerCard;
                    winner = i;
                }
                i++;
                if (i == list.Count)
                {
                    i = 0;
                }
                
            }

            _data.AddWinnings(list[winner].Key);
            return list[winner].Key;
        }
    }
}
