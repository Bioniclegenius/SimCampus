using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Editor
{
    class Room
    {
        private string name;
        private List<PointF[]> lines = new List<PointF[]>();
        private List<Node> nodes = new List<Node>();


        public Room(string name, string fileName)
        {
            this.name = name;
            build(fileName);
        }

        public void addLine(float x1, float y1, float x2, float y2)
        {
            PointF[] a = { new PointF(x1, y1), new PointF(x2, y2) };
            lines.Add(a);
        }

        public void render(Graphics g,float ang, float cx, float cy, int w, int h)
        {
            SolidBrush b = new SolidBrush(Color.FromArgb(196, 196, 196));
        }

        public void build(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);

            for(int x = 1; x < lines.Length; x++)
            {
                /* 
                 * if(node)
                 *      lines.Add(new Node(lines[x]), name);
                 * else if (line)
                 *      something else
                 * */
            }
        }
    }
}
