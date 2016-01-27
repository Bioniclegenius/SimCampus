using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Editor
{
    class Node
    {
        private float x, y;
        private string name;
        public List<Node> connections = new List<Node>();
        public List<double> weights = new List<double>();

        public Node(string name, float inX, float inY)
        {
            this.name = name;
            x = inX;
            y = inY;
        }

        public void addConnection(Node a){
            connections.Add(a);
            weights.Add(Math.Sqrt(Math.Pow(a.x - x, 2) + Math.Pow(a.y - y, 2)));
        }
    }
}
