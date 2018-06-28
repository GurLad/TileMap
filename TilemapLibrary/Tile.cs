using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TilemapLibrary
{
    public class Tile
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Size;
        public List<String> Attributes { get; set; } = new List<string>();
        public List<Image> Images { get; set; } = new List<Image>();
        public Color DefultColor = Color.White;
        public Tile(int XPos, int YPos, int Size, Color DefultColor)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            this.Size = Size;
            this.DefultColor = DefultColor;
        }
        public Tile()
        {
            this.XPos = 0;
            this.YPos = 0;
            this.Size = 0;
        }
        public bool SeekAttribute(string Attribute)
        {
            foreach (var item in Attributes)
            {
                if (item == Attribute) return true;
            }
            return false;
        }
        public void SetAttribute<T>(string Attribute, T Value)
        {
            if (Value == null) Value = (T)Convert.ChangeType(0, typeof(T));
            for (int i = 0; i < Attributes.Count; i++)
            {
                string[] Temp = Attributes[i].Split(':');
                if (Temp.Length <= 1) continue;
                Temp[1] = Value + "";
                Attributes[i] = String.Join(":",Temp);
                return;
            }
            Attributes.Add(Attribute + ":" + Value);
        }
        public string GetAttribute(string Attribute)
        {
            return GetAttribute<string>(Attribute);
            /*for (int i = 0; i < Attributes.Count; i++)
            {
                string[] Temp = Attributes[i].Split(':');
                if (Temp.Length <= 1) continue;
                return Temp[1];
            }
            Attributes.Add(Attribute + ":0");
            return "0";*/
        }
        public T GetAttribute<T>(string Attribute)
        {
            for (int i = 0; i < Attributes.Count; i++)
            {
                string[] Temp = Attributes[i].Split(':');
                if (Temp.Length <= 1) continue;
                return (T)Convert.ChangeType(Temp[1], typeof(T));
            }
            Attributes.Add(Attribute + ":0");
            return (T)Convert.ChangeType("0", typeof(T));
        }
        public override string ToString()
        {
            return XPos + ", " + YPos + ", " + Size + ", " + DefultColor;
        }
    }
}
