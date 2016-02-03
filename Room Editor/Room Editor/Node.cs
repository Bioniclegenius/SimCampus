using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Editor
{
    public class Node
    {
        private float x, y, z;
        private int number;
        private string name;
        public List<Node> connections = new List<Node>();
        public List<double> weights = new List<double>();

        public Node(string name, float inX, float inY, int number)
        {
            this.name = name + "N" + number;
            x = inX;
            y = inY;
        }

        public void addConnection(Node a){
            connections.Add(a);
            weights.Add(Math.Sqrt(Math.Pow(a.x - x, 2) + Math.Pow(a.y - y, 2)));
        }

        public int getNumber()
        {
            return number;
        }

        public string toString()
        {
            string theString = "N " + number + " ";//The node number
            theString += x + " " + y + " " + z + " ";//Location

            foreach (Node n in connections)
            {
                theString += n.getNumber() + " ";
            }

            return theString + "\n";
        }
    }
}
