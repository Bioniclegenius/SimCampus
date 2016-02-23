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
      int count = 0;
      path.Add(currentNode);

      while(true) {
        Node u = a.getSmallestDistance();
        count++;
        foreach(Node v in u.connections) {
          double alt = u.totalDistance + u.distanceTo(v);
          if(alt < v.totalDistance) {
            v.totalDistance = alt;
            v.parent = u;
          }
        }
        if(count == 50) break;
      }

      //Gets path backwards
      List<Node> temp = new List<Node>();
      bool keepGoing = true;
      Node current = dest;
      temp.Add(current);
      while(keepGoing) {
        temp.Add(current = current.parent);
        if(current.parent == null)
          keepGoing = false;
      }

      //Stores path forwards
      for(int k = temp.Count - 1;k >= 0;k--)
        path.Add(temp[k]);
    }
  }
}
