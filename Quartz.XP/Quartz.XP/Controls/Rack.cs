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
            InitializeTiles();
        }

        public String Candidate { get; set; }
        private Tile[] tiles;

        private void InitializeTiles()
        {
            tiles=new Tile[]{this.tile1, this.tile2, this.tile3, this.tile4, this.tile5, this.tile6, this.tile7, this.tile8, this.tile9};
            foreach(Tile tile in tiles)
            {
                tile.Click += new System.EventHandler(this.tile_Click);
            }

        }
        public void roulette_tiles(Puzzle puzzle)
        {
            Random rnd = new Random();
            String[] tiles = new String[] {puzzle.a1, puzzle.a2, puzzle.a3, puzzle.b1, puzzle.b2, puzzle.b3, puzzle.c1, puzzle.c2, puzzle.c3 };
            String[] shuffled = tiles.OrderBy(x => rnd.Next()).ToArray();
            this.tile1.Text = shuffled[0];
            this.tile2.Text = shuffled[1];
            this.tile3.Text = shuffled[2];
            this.tile4.Text = shuffled[3];
            this.tile5.Text = shuffled[4];
            this.tile6.Text = shuffled[5];
            this.tile7.Text = shuffled[6];
            this.tile8.Text = shuffled[7];
            this.tile9.Text = shuffled[8];
            
        }

        private void tile_Click(object sender, EventArgs e)
        {
            Tile tile=(Tile)sender;
            if(tile.Pick())
            {
                this.Candidate = tile.Text;
                foreach (Tile t in tiles)
                {
                    if (t != tile)
                    {
                        t.UnPick();
                    }
                }
            }
            {
                this.Candidate = null;
            }
        }

    }
}
