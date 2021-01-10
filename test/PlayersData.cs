using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    
    class PlayersData
    {
        private SortedList<int, Player> _players;
        private SortedList<int, SortedSet<int>> _playersByWinnings;

        public PlayersData(SortedList<int, Player> players)
        {
            _players = players;
            _playersByWinnings = new SortedList<int, SortedSet<int>>();
            _playersByWinnings.Add(0, new SortedSet<int>());
            foreach (var player in _players)
            {
                _playersByWinnings[0].Add(player.Key);
            }
        }

        public Player GetPlayerById(int id)
        {
            return _players[id];
        }

        public ref readonly SortedList<int, Player> PlayerMapById()
        {
            return ref _players;
        }

        public ref readonly SortedList<int, SortedSet<int>> PlayerMapByWinnings()
        {
            return ref _playersByWinnings;
        }

        public void AddWinnings(int id)
        {
            _playersByWinnings[_players[id].GetWinnings()].Remove(id);
            _players[id].IncWinnings();
            
            if (!_playersByWinnings.ContainsKey(_players[id].GetWinnings()))
            {
                _playersByWinnings.Add(_players[id].GetWinnings(), new SortedSet<int>());
            }
            
            _playersByWinnings[_players[id].GetWinnings()].Add(id);
        }

        public int GetNumberOfPlayers() {
            return _players.Count;
        }

        
    }
}
