using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz.XP.Models;

namespace Quartz.XP.Controls
{
    public partial class Rack : UserControl
    {
        public Rack()
        {
            InitializeComponent();
        }

        public void roulette_tiles(Puzzle puzzle)
        {
            Random rnd = new Random();
            char[] tiles = new char[] {puzzle.a1, puzzle.a2, puzzle.a3, puzzle.b1, puzzle.b2, puzzle.b3, puzzle.c1, puzzle.c2, puzzle.c3 };
            char[] shuffled = tiles.OrderBy(x => rnd.Next()).ToArray();
            this.tile1.Text = shuffled[0].ToString();
            this.tile2.Text = shuffled[1].ToString();
            this.tile3.Text = shuffled[2].ToString();
            this.tile4.Text = shuffled[3].ToString();
            this.tile5.Text = shuffled[4].ToString();
            this.tile6.Text = shuffled[5].ToString();
            this.tile7.Text = shuffled[6].ToString();
            this.tile8.Text = shuffled[7].ToString();
            this.tile9.Text = shuffled[8].ToString();
        }
    }
}
