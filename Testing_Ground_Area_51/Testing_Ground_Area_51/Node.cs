using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Ground_Area_51 {
  public class Node {
    public double x, y, z;

    public List<Node> connections = new List<Node>();
    public List<double> weights = new List<double>();

    /** Number type 
    * 0 - Normal Path
    * 1 - 
    */

    public string Name { get; set; }
    public int Number { get; set; }
    public int Type { get; set; }
    public string Comment { get; set; }


    public Node(string name, double inX, double inY, double inZ, int number) {
      Name = name + "N" + number;
      x = inX;
      y = inY;
      z = inZ;
      Number = number;
      Type = 0;
      Comment = "";
    }

    public void addConnection(Node a) {
      connections.Add(a);
      weights.Add(Math.Sqrt(Math.Pow(a.x - x, 2) + Math.Pow(a.y - y, 2)));
    }

    public void removeConnection(Node n) {
      int x = connections.IndexOf(n);
      if(x != -1) {
        weights.Remove(weights[x]);
        connections.Remove(n);
      }
    }

    public string toString() {
      string theString = "N " + Number + " ";//The node number
      theString += x + " " + y + " " + z + " ";//Location

      foreach(Node n in connections) {
        theString += n.Number + " ";
      }

      if(Comment.Equals("")) {
        theString += "C " + Comment;
      }

      return theString + "\n";
    }

    public Node getSmallestDistance() {
      int n = 0;
      if(weights.Count != 0) {
        for(int k = 1;k < weights.Count;k++)
          if(weights[n] < weights[k])
            n = k;
        return connections[n];
      } else {
        return this;
      }
    }

    public double distanceTo(Node n){
      int index = connections.IndexOf(n);
      try {
        return weights[index];
      } catch(Exception e) {
        return -20;
      }
    }

  }
}
