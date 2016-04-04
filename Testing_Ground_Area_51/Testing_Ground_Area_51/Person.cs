using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Ground_Area_51 {
  public class Person {

    public int x, y;
    public Node currentNode { get; set; }
    public Node destinationNode { get; set; }

    public string Destination { get; set; }
    public List<Node> path = new List<Node>();

    public Person(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public void calculatePath() {
      //currentNode.resetPathfinding();
      Dictionary<Node, double> distances = new Dictionary<Node, double>();
      Dictionary<Node, Node> parents = new Dictionary<Node, Node>();
      path = new List<Node>();

      Node a = currentNode;

      distances[a] = 0;

      List<Node> t = new List<Node>();
      t.Add(a);

      while(true) {
        Node n = getSmallestDistance(t, distances);
        t.Remove(n);
        foreach(Node v in n.connections) {
          double alt = distances[n] + n.distanceTo(v);
          try {
            if(alt < distances[v]) {
              distances[v] = alt;
              parents[v] = n;
              t.Add(v);
            }
          } catch(Exception e) {
            distances[v] = alt;
            parents[v] = n;
            t.Add(v);
          }
        }
        if(n == destinationNode) break;
      }

      //Gets path backwards
      List<Node> temp = new List<Node>();
      bool keepGoing = true;
      Node current = destinationNode;
      temp.Add(current);
      while(keepGoing) {
        try {
          temp.Add(current = parents[current]);
          if(parents[current] != null)
            keepGoing = true;
        } catch (Exception e) {
          keepGoing = false;
        }
      }

      //Stores path forwards
      for(int k = temp.Count - 1;k >= 0;k--)
        path.Add(temp[k]);
    }

    public Node getSmallestDistance(List<Node> nodes, Dictionary<Node, double> distances) {
      int x = 0;
      for(int k = 0; k < nodes.Count;k++) {
        if(distances[nodes[k]] < distances[nodes[x]]) {
          x = k;
        }
      }
      return nodes[x];
    }
  }
}
