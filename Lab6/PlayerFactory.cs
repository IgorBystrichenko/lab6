using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    
    class PlayerFactory
    {
        public static Player getPlayer(string name, char type)
        {
            Player player;
            switch (type)
            {
                case 'm': player = new MainPlayer(name); break;
                case 'r': player = new RandomCardPlayer(name); break;
                case 'b': player = new BiggestCardPlayer(name); break;
                case 's': player = new SmallestCardPlayer(name); break;
                default: throw new Exception("Invalid input. Try again!\nFormat: \"Name type\"");
            }
            return player;
        }
    }
}
