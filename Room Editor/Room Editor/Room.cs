using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Editor {
  class Room {
    private string name;
    public List<PointF[]> lines=new List<PointF[]>();
    private List<Node> nodes=new List<Node>();


    public Room(string name) {
      this.name=name;
    }

    public void addLine(float x1,float y1,float x2,float y2) {
      PointF[] a= { new PointF(x1,y1),new PointF(x2,y2) };
      lines.Add(a);
    }

    public void addNode(Node n) {
      nodes.Add(n);
    }

    public bool addConnection(Node n1,Node n2) {
      bool success=false;
      if(nodes.Contains(n1)==true&&nodes.Contains(n2)==true) {
        n1.addConnection(n2);
        n2.addConnection(n1);
        success=true;
      }

      return success;
    }

    public void saveFile(String fileLocation) {
      System.IO.StreamWriter file=new System.IO.StreamWriter(fileLocation);
      foreach(Node n in nodes) {
        file.WriteLine(n);
      }
      foreach(PointF[] f in lines) {
        file.WriteLine("L "+f[0].X+" "+f[0].Y+" "+f[1].X+" "+f[1].Y);
      }

    }

    public void render(Graphics g,float ang,float cx,float cy,int w,int h) {
      SolidBrush b=new SolidBrush(Color.FromArgb(196,196,196));
    }

    public void loadFile(string fileName) {
      string[] fileLines=System.IO.File.ReadAllLines(fileName);

      for(int x=1;x<fileLines.Length;x++) {
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
