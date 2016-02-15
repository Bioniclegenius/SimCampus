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
        public List<Node> nodes = new List<Node>();


        public Room(string name = "") {
            this.name = name;
        }

        public void addLine(float x1, float y1, float x2, float y2) {
            PointF[] a = { new PointF(x1, y1), new PointF(x2, y2) };
            lines.Add(a);
        }

        public void addNode(double x, double y, double z) {
            Node n = getNodeReference(x, y, z);
            if(n == null) {
                int num = 0;
                if(nodes.Count > 0)
                    num = nodes[nodes.Count - 1].Number + 1;
                Node node = new Node(name, x, y, z, num); //Assumes nodes are in numerical order
                nodes.Add(node);
            }
        }

        public void removeNode(float x, float y, float z) {
            bool exists = false;
            int nodeNum = -1;
            for(int k = 0;k < nodes.Count;k++) {
                if(nodes[k].x == x && nodes[k].y == y && nodes[k].z == z) {
                    exists = true;
                    nodeNum = k;
                    break;
                }
            }
            if(exists == true) {
                foreach(Node n in nodes) {
                    n.removeConnection(nodes[nodeNum]);
                }
                nodes.Remove(nodes[nodeNum]);
                for(int k = nodeNum; k < nodes.Count;k++) {
                    nodes[k].Name = name + "N" + k;
                    nodes[k].Number = k;
                }
            }
        }

        public bool addConnection(float x1, float y1, float z1, float x2, float y2, float z2) {
            bool success = false;
            Node n1 = getNodeReference(x1, y1, z1);
            Node n2 = getNodeReference(x2, y2, z2);
            if(n1 != null && n2 != null) {
                n1.addConnection(n2);
                n2.addConnection(n1);
                success = true;
            }

            return success;
        }

        public bool removeConnection(float x1, float y1, float z1, float x2, float y2, float z2) {
            bool success = false;
            Node n1 = getNodeReference(x1, y1, z1);
            Node n2 = getNodeReference(x2, y2, z2);
            if(n1 != null && n2 != null) {
                n1.removeConnection(n2);
                n2.removeConnection(n1);
                success = true;
            }

            return success;
        }

        private Node getNodeReference(double x, double y, double z) {
          for(int t=0;t<nodes.Count;t++)
            if(nodes[t].x==x&&nodes[t].y==y&&nodes[t].z==z)
              return nodes[t];
          return null;
        }

        private void clearRoom() {
            lines.Clear();
            nodes.Clear();
            location = "";
            name = "";
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
                    return;
                location = d.FileName;
            } else {
                try {
                    file = new System.IO.FileStream(location, System.IO.FileMode.Create);
                } catch(Exception e) {
                    return;
                }
            }
            if(location != null || !location.Equals("")) {
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
                clearRoom();
                System.IO.StreamReader save = new System.IO.StreamReader(ofd.OpenFile());
                location = ofd.FileName;
                while(save.Peek() >= 0) {
                    String line = save.ReadLine();
                    String[] items = line.Split(' ');
                    if(line.Contains("L")) {
                        PointF pt1 = new PointF(Convert.ToInt32(items[1]), Convert.ToInt32(items[2]));
                        PointF pt2 = new PointF(Convert.ToInt32(items[3]), Convert.ToInt32(items[4]));
                        PointF[] a = {pt1, pt2};
                        lines.Add(a);
                    } else if(line.Contains("N")) {
                        Node n = new Node(name, Convert.ToDouble(items[2]), Convert.ToDouble(items[3]), Convert.ToDouble(items[4]), Convert.ToInt32(items[1]));
                        nodes.Add(n);
                    }
                }
                save.Close();
            } 
        }
    }
}
