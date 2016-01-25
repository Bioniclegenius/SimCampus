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
        private bool taken = false;
        public List<Node> connections = new List<Node>();

        public Node(float inX, float inY)
        {
            x = inX;
            y = inY;
        }

        public void addConnection(Node a){
            connections.Add(a);
        }
    }
}
