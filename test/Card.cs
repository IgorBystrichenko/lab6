using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab6.Properties;

namespace lab6
{
    class Card : Button
    {
        private int _rank;
        private char _suit;
        private Image _image;
        private bool _isHide;

        public Card(int rank, char suit)
        {
            _rank = rank;
            _suit = suit;
            _image = (Bitmap)Resources.ResourceManager.GetObject(GetFilename(rank, suit));
            SetStyle(ControlStyles.UserPaint, true);
            Hide();
            Size = new Size(Image.Width, Image.Height);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }
        public int GetRank()
        {
            return _rank;
        }

        public char GetSuit()
        {
            return _suit;
        }

        public void Show()
        {
            _isHide = false;
            Image = new Bitmap(_image, new Size((int)(_image.Width * 1.5), (int)(_image.Height * 1.5)));
            Enabled = true;
        }

        public void Hide()
        {
            _isHide = true;
            Image = new Bitmap(Resources.card_back, new Size((int)(Resources.card_back.Width * 1.5), (int)(Resources.card_back.Height * 1.5)));
            Enabled = false;
        }
        private static string GetFilename(int rank, char suit)
        {
            string filename = "card_";
            switch (suit)
            {
                case '1': filename = filename + "clubs_"; break;
                case '2': filename = filename + "diamonds_"; break;
                case '3': filename = filename + "hearts_"; break;
                case '4': filename = filename + "spades_"; break;
            }

            if (rank > 1 && rank < 10)
            {
                filename = filename + "0" + rank;
            }
            else
            {
                switch (rank)
                {
                    case 10:
                        filename = filename + rank; break;
                    case 11:
                        filename = filename + "J"; break;
                    case 12:
                        filename = filename + "Q"; break;
                    case 13:
                        filename = filename + "K"; break;
                    case 14:
                        filename = filename + "A"; break;
                }
            }
            return filename;
        }
    }

}
