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
            graph.PrintMstByParents(parents);
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
        public static List<int> tryFindCircle(UndirectedGraph mstGraph, int vertexU)
        {
            List<int> circleList = new List<int>();
            List<int> foundResult = new List<int>();
            mstGraph.setColor(vertexU, 'g');
            int firstVertexInCircle = -1;
            bool foundCircle = false;
            foreach (int vertexV in mstGraph.GetEdges(vertexU))
            {
                if (mstGraph.getColorOfVertices()[vertexV] == 'g'
                    && mstGraph.getPi()[vertexV] != vertexU)
                {
                    foundCircle = true;
                    firstVertexInCircle = vertexV;
                    circleList.Add(vertexV);
                    break;
                }
                if (mstGraph.getColorOfVertices()[vertexV] == 'w')
                {
                    mstGraph.setPi(vertexV, vertexU);
                    foundResult = tryFindCircle(mstGraph, vertexV);
                    if (foundResult != null)
                    {
                        return foundResult;
                    }
                }
            }
            mstGraph.setColor(vertexU, 'b');
            if (foundCircle)
            {
                while (vertexU != firstVertexInCircle)
                {
                    circleList.Add(vertexU);
                    vertexU = mstGraph.getPi()[vertexU]; // u = pi[u] 
                }
            }
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
                    circle = tryFindCircle(mstGraph, i);
                }
                //if a circle was found remove the heaviest edge 
                if (circle.Count != 0)
                {
                    Console.WriteLine(String.Join(",",circle));
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
        //public static bool SearchEdgeToRemove(UndirectedGraph mstGraph, int vertexU, int src, int dest, int weight)
        //{
        //    int pointerToCircle;
        //    int currPointer;
        //    int maxWeight = weight;
        //    int firstIndex = src;
        //    int secondIndex = dest;
        //    mstGraph.setColor(vertexU, 'g');
        //    foreach (int vertexV in mstGraph.GetEdges(vertexU))
        //    {
        //        if(mstGraph.getColorOfVertices()[vertexV] == 'g' 
        //            && mstGraph.getPi()[vertexV]!=vertexU)
        //        {
        //            pointerToCircle = vertexU;
        //            if(mstGraph.TryGetWeight(vertexV, vertexU, out int currWeight)
        //                && currWeight > maxWeight)
        //            {
        //                maxWeight = currWeight;
        //                firstIndex = vertexV;
        //                secondIndex = vertexU;
        //            }
        //            // problem checking it by parents only. need to check with edges matrix
        //            currPointer = vertexV;
        //            while (currPointer != pointerToCircle && currPointer>=0)
        //            {
        //                Console.WriteLine("here"+currPointer);

        //                if (mstGraph.TryGetWeight(mstGraph.getPi()[currPointer], currPointer, out int currWeightNew)
        //                && currWeightNew > maxWeight)
        //                {
        //                    maxWeight = currWeightNew;
        //                    Console.WriteLine("maxweight"+ maxWeight);
        //                    firstIndex = mstGraph.getPi()[currPointer];
        //                    secondIndex = currPointer;
        //                }
        //                currPointer = mstGraph.getPi()[currPointer];
        //            }
        //            mstGraph.setColor(vertexU, 'b');
        //            mstGraph.RemoveEdge(src, dest);
        //            return true;
        //        }
        //        if(mstGraph.getColorOfVertices()[vertexV] == 'w')
        //        {
        //            mstGraph.setPi(vertexV, vertexU);
        //            SearchEdgeToRemove(mstGraph, vertexV, src, dest, weight);
        //        }
        //    }
        //    mstGraph.setColor(vertexU, 'b');
        //    return false;
        //}
        //public static void UpdateMST(UndirectedGraph mstGraph, int src, int dest, int weight)
        //{
        //    mstGraph.AddEdge(src, dest, weight);
        //    for (int i = 0; i < mstGraph.NumOfVertex; i++)
        //    {
        //        mstGraph.setColor(i,'w');
        //        mstGraph.setPi(i, -1); //pi[i]=null
        //    }
        //    for (int i = 0; i < mstGraph.NumOfVertex; i++)
        //    {
        //        if (mstGraph.getColorOfVertices()[i] == 'w')
        //        {
        //            bool foundCircle = SearchEdgeToRemove(mstGraph, i, src, dest, weight);
        //            if (foundCircle == true)
        //            {
        //                mstGraph.printGraph();
        //                return;
        //            }
        //        }
        //    }
        //    mstGraph.RemoveEdge(src, dest);
        //    mstGraph.printGraph();
        //}
        public static void Main()
        {
            var graph = new UndirectedGraph(12);
            var mst = new UndirectedGraph(12);
            GraphBuilder.BuildGraph(graph);
            mst = MST_prim(graph, 0);
            MstUpdate(mst, 2, 3, 6);
        }
    }
}
