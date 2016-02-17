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

            currentNode.totalDistance = 0;
            do {
                Node neighbor = currentNode.getSmallestDistance();

                List<Node> connections = neighbor.connections;

                foreach(Node n in connections) {

                }
            } while(true);
        }
    }
}
