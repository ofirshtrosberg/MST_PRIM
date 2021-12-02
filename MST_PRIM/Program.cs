using System;
using System.Collections.Generic;

namespace MST_PRIM
{
    class Program
    {
        public static void MST_prim(UndirectedGraph graph, int startVertexIndex)
        {
            VertexKeyPair[] keys = new VertexKeyPair[graph.NumOfVertex];
            int[] parents = new int[graph.NumOfVertex];
            for (int i = 0; i < graph.NumOfVertex; i++)
            {
                keys[i] = new VertexKeyPair(i, int.MaxValue);
            }
            parents[startVertexIndex] = -1;
            keys[startVertexIndex].Key = 0;
            MinVertexQueue verticesQueue = new MinVertexQueue(keys);
            while (verticesQueue.Count != 0)
            {
                int vertexU = verticesQueue.ExtractMin();
                foreach (int vertexV in graph.GetEdges(vertexU))
                {
                    VertexKeyPair foundVertex;
                    if ((foundVertex = verticesQueue.FindVertex(vertexV)) != null
                        && graph.TryGetWeight(vertexU, vertexV, out int uvWeight) 
                        && uvWeight < foundVertex.Key)
                    {
                        parents[vertexV] = vertexU;
                        verticesQueue.Update(vertexV, uvWeight);
                    }
                }
            }
            graph.PrintMstByParents(parents);
        }

        public static void Main()
        {
            var graph = new UndirectedGraph(12);
            GraphBuilder.BuildGraph(graph);
            MST_prim(graph, 0);
        }
    }
}
