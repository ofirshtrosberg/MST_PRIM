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

        public void PrintMstByParents(int[] parents)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 0; i < NumOfVertex; i++)
            {
                if (parents[i] >= NumOfVertex || parents[i] < 0)
                {
                    continue;
                }
                char parentLetter = 'a', vertexLetter = 'a';
                parentLetter += (char)parents[i];
                vertexLetter += (char)i;
                Console.WriteLine(parentLetter + " - " + vertexLetter + "\t" + _edgeWeightsMatrix[i, parents[i]]);
            }
        }
    }
}
