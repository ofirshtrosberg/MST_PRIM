// Gal Cohen: 314752536
// Ofir Shtrosberg: 207828641
using System;
using System.Collections.Generic;
using System.Text;

namespace MST_PRIM
{
    public class UndirectedGraph : Graph
    {
        public UndirectedGraph(int numOfVertex) : base(numOfVertex)
        {
        }

        public override void AddEdge(int src, int dest, int weight)
        {
            if (src < _numOfVertex && dest < _numOfVertex)
            {
                base.AddEdge(src, dest, weight);
                base.AddEdge(dest, src, weight);
            }
        }
        public override void RemoveEdge(int src, int dest)
        {
            base.RemoveEdge(src, dest);
            base.RemoveEdge(dest, src);
        }
        // get list of edges connected to the given vertex
        public List<int> GetEdges(int vertex)
        {
            List<int> edges = new List<int>();
            for (int i = 0; i < _numOfVertex; i++)
            {
                if (_isEdgeExistMatrix[vertex, i])
                {
                    edges.Add(i);
                }
            }
            return edges;
        }
        public void PrintGraph()
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 0; i <this.NumOfVertex; i++)
            {
                for (int j = i; j < this.NumOfVertex; j++)
                {
                    if (this._isEdgeExistMatrix[i, j])
                    {
                        Console.WriteLine((i)+"-"+(j)+"\t"+this._edgeWeightsMatrix[i,j]);
                    }
                }
            }
        }
    }
}
