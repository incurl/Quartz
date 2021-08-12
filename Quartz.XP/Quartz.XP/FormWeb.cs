using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestSharp;
using Quartz.XP.Models;
using LiteDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Quartz.XP
{
    public partial class FormWeb : Form
    {
        public FormWeb()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try 
            {
                int bundleId =Int32.Parse(textBox1.Text);
                var client = new RestClient("http://150.158.181.194:3001");

                Bundle bundle;
                List<Puzzle> puzzles;

                var request = new RestRequest("bundles?id=eq.{bundleId}").AddUrlSegment("bundleId", bundleId.ToString());
                var response = client.Get(request);
                bundle = JsonConvert.DeserializeObject<List<Bundle>>(response.Content).First<Bundle>();

                request = new RestRequest("rpc/get_bundle_puzzles?bid={bundleId}").AddUrlSegment("bundleId", bundleId.ToString());
                response = client.Get(request);
                puzzles = JsonConvert.DeserializeObject<List<Puzzle>>(response.Content);

                using (var db = new LiteDatabase(@".\Data\Quartz.db"))
                {
                    var colB = db.GetCollection<Bundle>("bundle");
                    colB.Insert(bundle);

                    var colP = db.GetCollection<Puzzle>("puzzle");
                    foreach (Puzzle p in puzzles)
                    {
                        colP.Insert(p);
                    }
                    colP.EnsureIndex<int>(x => x.id);
                    colP.EnsureIndex<bool>(x => x.Solved);
                    colP.EnsureIndex<bool>(x => x.Starred);
                    colP.EnsureIndex<bool>(x => x.Binned);
                }
            }
            catch  (FormatException x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}
