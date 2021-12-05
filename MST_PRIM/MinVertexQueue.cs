using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MST_PRIM
{
    public class MinVertexQueue
    {
        public List<VertexKeyPair> VerticesList { get; set; }
        private VertexComparer _vertexComparer;
        public int Count => VerticesList.Count;
        public MinVertexQueue(VertexKeyPair[] vertices)
        {
            this.VerticesList = new List<VertexKeyPair>();
            this.VerticesList.AddRange(vertices);
            _vertexComparer = new VertexComparer();
            Resort();
        }

        public void Update(int vertex, int key)
        {
            VertexKeyPair foundVertex;
            if ((foundVertex = FindVertex(vertex)) != null)
            {
                foundVertex.Key = key;
                Resort();
            }
        }

        public VertexKeyPair FindVertex(int vertex)
        {
            return this.VerticesList.Find(ver => ver.Vertex == vertex);
        }
       
        private void Resort()
        {
            this.VerticesList.Sort(_vertexComparer);
        }

        public int ExtractMin()
        {
            int v;
            v = this.VerticesList[0].Vertex;
            VerticesList.RemoveAt(0);
            return v;
        }
    }
}
