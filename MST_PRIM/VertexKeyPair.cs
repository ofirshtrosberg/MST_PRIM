using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MST_PRIM
{
    public class VertexKeyPair
    {
        public int Vertex { get; set; }
        public int Key { get; set; }
        public VertexKeyPair(int vertex, int key)
        {
            this.Vertex = vertex;
            this.Key = key;
        }
    }
}