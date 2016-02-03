using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Room_Editor {
    public class Room {
        private string name;
        private string location;
        public List<PointF[]> lines = new List<PointF[]>();
        private List<Node> nodes = new List<Node>();


        public Room(string name = "") {
            this.name = name;
        }

        public void addLine(float x1, float y1, float x2, float y2) {
            PointF[] a = { new PointF(x1, y1), new PointF(x2, y2) };
            lines.Add(a);
        }

        public void addNode(Node n) {
            nodes.Add(n);
        }

        public bool addConnection(Node n1, Node n2) {
            bool success = false;
            if(nodes.Contains(n1) == true && nodes.Contains(n2) == true) {
                n1.addConnection(n2);
                n2.addConnection(n1);
                success = true;
            }

            return success;
        }

        public void saveFile() {
            System.IO.FileStream file;
            if(location == null || location.Equals("")) {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Room | *.rm";
                d.FilterIndex = 1;
                d.Title = "Save Room As";
                d.OverwritePrompt = false;
                if(d.ShowDialog() == DialogResult.OK)
                    file = (System.IO.FileStream)d.OpenFile();
                else
                    file = new System.IO.FileStream("", System.IO.FileMode.Create);//This will never be reached
                location = d.FileName;
            } else {
                file = new System.IO.FileStream(location, System.IO.FileMode.Create);
            }
            if(location == null || location.Equals("")) {
                foreach(Node n in nodes) {
                    byte[] line = new UTF8Encoding(true).GetBytes(n.toString());
                    file.Write(line, 0, line.Length);
                }
                foreach(PointF[] f in lines) {
                    byte[] line = new UTF8Encoding(true).GetBytes("L " + f[0].X + " " + f[0].Y + " " + f[1].X + " " + f[1].Y + "\n");
                    file.Write(line, 0, line.Length);
                }
                file.Close();
            }
        }

        public void loadFile() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Room| *.rm";
            ofd.FilterIndex = 1;
            ofd.Title = "Open Room";
            if(ofd.ShowDialog() == DialogResult.OK) {
                System.IO.StreamReader readIn = new System.IO.StreamReader(ofd.OpenFile());
                location = ofd.FileName;
                while(readIn.Peek() >= 0) {
                    String line = readIn.ReadLine();
                    if(line.Contains("l")) {

                    } else if(line.Contains("n")) {

                    }
                }
            } 
        }
    }
}
