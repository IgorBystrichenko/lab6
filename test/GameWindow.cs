using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab6.Properties;

namespace lab6
{
    public partial class GameWindow : Form
    {
        private TableLayoutPanel _gamePanel;
        private GameTable _gameTable;
        private int _firstPlayer = 1;
        private bool _isStarted = false;
        private Button _play;
        public GameWindow()
        {
            InitializeComponent();

            _gameTable = CreateGameTable();
            _gameTable.ShuffleDeck();
            try
            {
                _gameTable.GiveCards(6);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _gameTable.GetPlayersData().PlayerMapById()[1].ShowCards();
        }

        private GameTable CreateGameTable()
        {
            PlayersData data = PlayersParser();
            List<Card> deck = DeckLoader.LoadDeck();

            GameTable gameTable = new GameTable(data, deck);

            Card fakeCard = new Card(2, '1');
            _gamePanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                AutoSize = true,
                Location = new Point((Size.Width - fakeCard.Width) / 2, Size.Height / 2 - fakeCard.Height)
            };

            _play = new Button()
            {
                Location = new Point(675, 220),
                Size = new Size(113, 61),
                TabIndex = 0,
                Text = "Play",
                UseVisualStyleBackColor = true
            }; 
            _play.Click += PlayClick;
            
            gameTable.GetPlayersData().PlayerMapById()[1].Location = new Point(Size.Width / 2, Size.Height - fakeCard.Height - 48);
            gameTable.GetPlayersData().PlayerMapById()[2].Location = new Point(Size.Width / 2, 0);
            

            Controls.Add(gameTable.GetPlayersData().PlayerMapById()[1]);
            Controls.Add(gameTable.GetPlayersData().PlayerMapById()[2]);
            Controls.Add(_play);
            Controls.Add(_gamePanel);
            return gameTable;
		}

        private PlayersData PlayersParser()
        {
            SortedList<int, Player> players = new SortedList<int, Player>();
            IdentifierGenerator gen = new IdentifierGenerator();

            players.Add(gen.NextId(), PlayerFactory.getPlayer("Player", 'm'));
            players.Add(gen.NextId(), PlayerFactory.getPlayer("Bot", 'b'));

            return new PlayersData(players);
        }

        private void PlayClick(object sender, EventArgs e)
        {
            SortedList<int, Player> players = _gameTable.GetPlayersData().PlayerMapById();

            if (!_isStarted)
            {
                _isStarted = true;
                _gamePanel.Controls.Clear();
                (new Thread(() =>
                {
                    int winner = _gameTable.Play(_firstPlayer, _gamePanel);
                    _firstPlayer = (_firstPlayer + 1) % _gameTable.GetNumberOfPlayers();

                    switch (winner)
                    {
                        case 1:
                            PlayerScore.BeginInvoke((MethodInvoker) (() =>
                            {
                                PlayerScore.Text = "" + players[winner].GetWinnings();
                            }));
                            break;
                        case 2:
                            EnemyScore.BeginInvoke((MethodInvoker) (() =>
                            {
                                EnemyScore.Text = "" + players[winner].GetWinnings();
                            }));
                            break;
                    }

                    if (players[winner].GetDeck().Count == 0)
                    {
                        _play.BeginInvoke((MethodInvoker) (() => { _play.Hide(); }));
                        if (players[1].GetWinnings() > players[2].GetWinnings())
                        {
                            MessageBox.Show("ОГО!\nТы выиграл!");
                        }
                        else if (players[1].GetWinnings() < players[2].GetWinnings())
                        {
                            MessageBox.Show("О НЕТ!\nТы проиграл(\nПовезет в другой раз");
                        }
                        else
                        {
                            MessageBox.Show("НИЧЬЯ :|");
                        }

                    }

                    _isStarted = false;
                })).Start();
            }

        }


    }
}
