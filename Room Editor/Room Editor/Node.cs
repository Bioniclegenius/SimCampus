﻿using System;
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

        public string Name { get; set; }
        public int Number { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Node(string name, float inX, float inY, int inZ, int number)
        {
            this.name = name + "N" + number;
            x = inX;
            y = inY;
            z = inZ;
        }

        public void addConnection(Node a){
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
