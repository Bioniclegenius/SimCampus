using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Ground_Area_51 {
  class Person {

    public int x, y;
    public Node currentNode { get; set; }

    public string Destination { get; set; }
    public List<Node> path = new List<Node>();

    public Person(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public void calculatePath(Node dest) {
      currentNode.resetPathfinding();
      Node a = currentNode;

      a.totalDistance = 0;
      path.Add(currentNode);

      List<Node> t = new List<Node>();
      t.Add(a);

      while(true) {
        Node n = getSmallestDistance(t);
        foreach(Node v in n.connections) {
          double alt = n.totalDistance + n.distanceTo(v);
          if(alt < v.totalDistance || v.totalDistance == -1) {
            v.totalDistance = alt;
            v.parent = n;
            t.Add(v);
          }
        }
        if(n == dest) break;
      }

      //Gets path backwards
      List<Node> temp = new List<Node>();
      bool keepGoing = true;
      Node current = dest;
      temp.Add(current);
      while(keepGoing) {
        Console.WriteLine(current);
        temp.Add(current = current.parent);
        if(current.parent == null)
          keepGoing = false;
      }

      //Stores path forwards
      for(int k = temp.Count - 1;k >= 0;k--)
        path.Add(temp[k]);
    }

    public Node getSmallestDistance(List<Node> nodes) {
      int x = 0;
      for(int k = 0; k < nodes.Count;k++) {
        if(nodes[k].totalDistance < nodes[x].totalDistance) {
          x = k;
        }
      }
      return nodes[x];
    }
  }
}
