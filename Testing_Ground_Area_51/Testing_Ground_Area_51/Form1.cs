using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
      Person[] people = new Person[10000];
      Random rand = new Random();
      for(int k = 0; k < people.Length;k++) {
        people[k] = new Person(0, 0);
        people[k].currentNode = nodes[rand.Next(0, 6)];
        int dest = rand.Next(0,6);
        while(nodes[dest] == people[k].currentNode) {
          dest = rand.Next(0, 6);
        }
        people[k].destinationNode = nodes[rand.Next(0, 6)];
      }

      Thread[] threads = new Thread[people.Length];
      for(int k = 0; k < threads.Length; k++) {
        threads[k] = new Thread(people[k].calculatePath);
      }

      DateTime start;
      TimeSpan time;

      start = DateTime.Now;
      for(int k = 0; k < threads.Length; k++) {
        threads[k].Start();
      }
      for(int k = 0; k < threads.Length;k++) {
        threads[k].Join();
      }
      time = DateTime.Now - start;
      label1.Text = "Took " + String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'));

      //saveFile(people);
    }

    public void saveFile(Person[] people) {
      System.IO.FileStream file;
      SaveFileDialog d = new SaveFileDialog();
      d.Filter = "Text | *.txt";
      d.FilterIndex = 1;
      d.Title = "Save Data As";
      d.OverwritePrompt = false;
      if(d.ShowDialog() == DialogResult.OK)
        file = (System.IO.FileStream)d.OpenFile();
      else
        return;
      for(int k = 0; k < people.Count();k++) {
        String x = "\n" + people[k].currentNode.toString() + " " + people[k].destinationNode.toString() + "\n";
        byte[] line = new UTF8Encoding(true).GetBytes(x);
        file.Write(line, 0, line.Length);
        for(int j = 0; j < people[k].path.Count;j++) {
          line = new UTF8Encoding(true).GetBytes(people[k].path[j].toString() + " \n");
          file.Write(line, 0, line.Length);
        }
        line = new UTF8Encoding(true).GetBytes("\n\n");
      }
      file.Close();
    }
  }
}
