using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace TilemapLibrary
{
    public class Tilemap
    {
        public int TileSize { get; }
        public int Width { get; }
        public int Height { get; }
        public Panel Parent { get; }
        public Tile[,] Tiles { get; set; } = new Tile[99, 99];
        public Tilemap(int Width, int Height, int TileSize, Color DefultColor, Panel Parent)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, Parent, new object[] { true });
            this.TileSize = TileSize;
            this.Width = Width;
            this.Height = Height;
            this.Parent = Parent;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Tiles[i, j] = new Tile(i, j, TileSize, DefultColor);
                }
            }
            DrawTilemap();
        }
        public void DrawTilemap()
        {
            Bitmap Result = new Bitmap(Parent.Width, Parent.Height);
            Graphics WorkWith = Graphics.FromImage(Result);
            Pen ThePen = new Pen(Color.AliceBlue, 1);
            SolidBrush TheBrush = new SolidBrush(Color.AliceBlue);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    ThePen.Color = Tiles[i, j].DefultColor;
                    TheBrush.Color = Tiles[i, j].DefultColor;
                    WorkWith.FillRectangle(TheBrush,i*TileSize,j*TileSize,TileSize,TileSize);
                    foreach (var item in Tiles[i, j].Images)
                    {
                        WorkWith.DrawImage(item, i * TileSize, j * TileSize,TileSize,TileSize);
                    }
                }
            }
            Parent.BackgroundImage = Result;
        }
        public bool SeekAttribute(int x, int y, string Attribute)
        {
            return Tiles[x, y].SeekAttribute(Attribute);
        }
        public void SetAttribute<T>(int x, int y, string Attribute, T Value)
        {
            Tiles[x, y].SetAttribute(Attribute, Value);
        }
        public string GetAttribute(int x, int y, string Attribute)
        {
            return Tiles[x, y].GetAttribute(Attribute);
        }
        public T GetAttribute<T>(int x, int y, string Attribute)
        {
            return Tiles[x, y].GetAttribute<T>(Attribute);
        }
    }
}
