using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_Ground_Area_51 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();

      Random rand = new Random();
      Node[] nodes = new Node[30];
      for(int k = 0; k < 30;k++) {
        nodes[k] = new Node("A", rand.Next(100), rand.Next(100), 0, (k + 1));
      }

      for(int s = 0; s < 30; s++) {
        int skip = rand.Next(30);
        for(int k = 0; k < 30;k++) {
          if(k != s && k != skip) 
            nodes[s].addConnection(nodes[k]);
        }
      }

      /*label1.Text = "All NODES\n";
      for(int k = 0;k < 30;k++)
        label1.Text += nodes[k].toString();
      */
      Person jackson = new Person(0, 0);
      jackson.currentNode = nodes[0];
      jackson.calculatePath(nodes[20]);
      label1.Text = "Nodes in the Path";
      foreach(Node n in jackson.path) {
        label1.Text += "\n" + n.toString();
      }
      //label1.Text = "n1.Equals(30) " + nodes[0].Equals(nodes[20]); 
    }
  }
}
