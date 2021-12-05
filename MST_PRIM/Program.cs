using System;
using System.Collections.Generic;

namespace MST_PRIM
{
    class Program
    {
        public static UndirectedGraph MST_prim(UndirectedGraph graph, int startVertexIndex)
        {
            var mst = new UndirectedGraph(graph.NumOfVertex);
            VertexKeyPair[] keys = new VertexKeyPair[graph.NumOfVertex]; // keys array
            int[] parents = new int[graph.NumOfVertex]; // parents array (pi)
            // initialize all the keys to "infinity"
            for (int i = 0; i < graph.NumOfVertex; i++)
            {
                keys[i] = new VertexKeyPair(i, int.MaxValue);
            }
            // initialize the vertex we start with
            parents[startVertexIndex] = -1; // symbolize null
            keys[startVertexIndex].Key = 0;
            MinVertexQueue verticesQueue = new MinVertexQueue(keys);
            // while queue is not empty
            while (verticesQueue.Count != 0)
            {
                int vertexU = verticesQueue.ExtractMin();
                // for each v in adj[u]
                foreach (int vertexV in graph.GetEdges(vertexU))
                {
                    VertexKeyPair foundVertex;
                    // if v in queue and w(u,v)<key[v]
                    if ((foundVertex = verticesQueue.FindVertex(vertexV)) != null
                        && graph.TryGetWeight(vertexU, vertexV, out int uvWeight)
                        && uvWeight < foundVertex.Key)
                    {
                        parents[vertexV] = vertexU;
                        verticesQueue.Update(vertexV, uvWeight);
                    }
                }
            }
            for (int i = 0; i < parents.Length; i++)
            {
                // if parent is not null
                if (parents[i] != -1)
                {
                    graph.TryGetWeight(parents[i], i, out int weight);
                    mst.AddEdge(parents[i], i, weight);
                }
            }
            mst.printGraph();
           // graph.PrintMstByParents(parents);
            return mst;
        }
        // maybe need to initialize to null all the vertices parents
        //public static void MST_prim(UndirectedGraph graph, int startVertexIndex)
        //{
        //    VertexKeyPair[] keys = new VertexKeyPair[graph.NumOfVertex]; // keys array
        //    int[] parents = new int[graph.NumOfVertex]; // parents array (pi)
        //    // initialize all the keys to "infinity"
        //    for (int i = 0; i < graph.NumOfVertex; i++)
        //    {
        //        keys[i] = new VertexKeyPair(i, int.MaxValue);
        //    }
        //    // initialize the vertex we start with
        //    parents[startVertexIndex] = -1; // symbolize null
        //    keys[startVertexIndex].Key = 0;
        //    MinVertexQueue verticesQueue = new MinVertexQueue(keys);
        //    // while queue is not empty
        //    while (verticesQueue.Count != 0)
        //    {
        //        int vertexU = verticesQueue.ExtractMin();
        //        // for each v in adj[u]
        //        foreach (int vertexV in graph.GetEdges(vertexU))
        //        {
        //            VertexKeyPair foundVertex;
        //            // if v in queue and w(u,v)<key[v]
        //            if ((foundVertex = verticesQueue.FindVertex(vertexV)) != null
        //                && graph.TryGetWeight(vertexU, vertexV, out int uvWeight) 
        //                && uvWeight < foundVertex.Key)
        //            {
        //                parents[vertexV] = vertexU;
        //                verticesQueue.Update(vertexV, uvWeight);
        //            }
        //        }
        //    }
        //    graph.PrintMstByParents(parents);
        //}
        public static List<int> tryFindCircle(UndirectedGraph mstGraph, int parent, List<int> circleList)
        {
            List<int> foundResult = new List<int>();
            mstGraph.setColor(parent, 'g');
            Console.WriteLine(parent);
            foreach (int vertexV in mstGraph.GetEdges(parent))
            {       
                if ((mstGraph.getColorOfVertices()[vertexV] == 'g') && (mstGraph.getPi()[parent] != vertexV))
                {
                    int firstVertexInCircle = vertexV;
                    int pointerToCircle = parent;
                    circleList.Add(vertexV);
                    // the parent of the 
                    while (pointerToCircle != -1 && pointerToCircle!=mstGraph.getPi()[firstVertexInCircle])
                    {
                        circleList.Add(pointerToCircle);
                        pointerToCircle = mstGraph.getPi()[pointerToCircle];
                    }
                    mstGraph.setColor(parent, 'b');
                    return circleList;
                }
                if (mstGraph.getColorOfVertices()[vertexV] == 'w')
                {
                    mstGraph.setPi(vertexV, parent);
                    tryFindCircle(mstGraph, vertexV, circleList);
                }
            }
            mstGraph.setColor(parent, 'b');
            return circleList;
        }
        // Check if the new edge creates a circle in the mst graph.
        // If so, remove the most "expensive" edge in the circle from the mst.
        public static void MstUpdate(UndirectedGraph mstGraph, int src, int dest, int weight)
        {
            int firstIndex = src;
            int secondIndex = dest;
            int maxWeight = weight;
            List<int> circle = new List<int>(); // vertices in the circle
            List<int> findCircle = new List<int>();
            mstGraph.AddEdge(src, dest, weight);
            // initialize all vertices to be white and their parents to be null (-1)
            for (int i = 0; i < mstGraph.NumOfVertex; i++)
            {
                mstGraph.setColor(i, 'w');
                mstGraph.setPi(i, -1); // -1 is like null
            }
            for (int i = 0; i < mstGraph.NumOfVertex; i++)
            {
                if (mstGraph.getColorOfVertices()[i] == 'w')
                {
                    circle = tryFindCircle(mstGraph, i, findCircle);
                }
                //if a circle was found remove the heaviest edge 
                if (circle.Count != 0)
                {
                    Console.WriteLine("circle"+String.Join(",",circle));
                    for (int j = 0; j < circle.Count - 1; j++)
                    {
                        if (mstGraph.TryGetWeight(circle[j], circle[j + 1], out int maxWeightNew)
                            && maxWeightNew > maxWeight)
                        {
                            maxWeight = maxWeightNew;
                            firstIndex = circle[j];
                            secondIndex = circle[j + 1];
                        }
                    }
                    mstGraph.RemoveEdge(firstIndex, secondIndex);
                    mstGraph.printGraph();
                    return;
                }
            }
        }
        public static void Main()
        {
            var graph = new UndirectedGraph(20);
            var mst = new UndirectedGraph(20);
            GraphBuilder.BuildGraph(graph);
            mst = MST_prim(graph, 0);
            //MstUpdate(mst, 2, 0, 100);         
        }
    }
}
