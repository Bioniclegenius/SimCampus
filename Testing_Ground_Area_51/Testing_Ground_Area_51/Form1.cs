using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_Ground_Area_51 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();

      List<Node> nodes = new List<Node>();
      Room r = new Room();
      r.loadFile();
      nodes = r.nodes;
      Person jackson = new Person(0, 0);
      jackson.currentNode = nodes[0];

      DateTime start;
      TimeSpan time;

      start = DateTime.Now;
      jackson.calculatePath(nodes[5]);
      time = DateTime.Now - start;
      label1.Text = "Nodes in the Path";
      foreach(Node n in jackson.path) {
        label1.Text += "\n" + n.toString();
      }
      label1.Text += "\n" + String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0')); ;

      start = DateTime.Now;
      jackson.calculatePath(nodes[4]);
      time = DateTime.Now - start;
      label1.Text += "\nNodes in the Path 2";
      foreach(Node n in jackson.path) {
        label1.Text += "\n" + n.toString();
      }
      label1.Text += "\n" + String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0')); ;

      //label1.Text = "n1.Equals(30) " + nodes[0].Equals(nodes[20]); 
    }
  }
}
