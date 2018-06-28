using System;
using System.Drawing;
using System.Windows.Forms;
using TilemapLibrary;
namespace TilemapTest
{
    public partial class Form1 : Form
    {
        //A simple demo for the TileMap library
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tilemap bla = new Tilemap(5, 5, 16, Color.Black, panel1);
            bla.DrawTilemap();
            bla.Tiles[3, 3].DefultColor = Color.Red;
            bla.Tiles[2, 4].Images.Add(Properties.Resources.block15);
            bla.Tiles[0, 3].Images.Add(Properties.Resources.block15);
            bla.Tiles[0, 3].Images.Add(Properties.Resources.win);
            bla.Tiles[2, 2].DefultColor = Color.Red;
            bla.Tiles[2, 2].Images.Add(Properties.Resources.block15);
            bla.Tiles[1, 1].Attributes.Add("Banana");
            MessageBox.Show("Shows if [1,1] has a banana: " + bla.SeekAttribute(1, 1, "Banana")); // Shows whether [1,1] has a banana
            MessageBox.Show("Shows if [0,3] has a banana: " + bla.SeekAttribute(0, 3, "Banana")); // Shows whether [0,3] has a banana
            //Sets a few tiles "Banana" attribute to a set number
            bla.SetAttribute(0, 0, "Banana", 5);
            bla.SetAttribute(3, 0, "Banana", 3);
            bla.SetAttribute(0, 3, "Banana", 1);
            string AllData = "";
            foreach (var item in bla.Tiles)
            {
                if (item == null) continue;
                AllData += "[" + item.XPos + "," + item.YPos + "]:" + item.GetAttribute("Banana") + "\n";
            }
            MessageBox.Show("Shows a list with data:\n" + AllData);
            bla.DrawTilemap();
        }
    }
}
