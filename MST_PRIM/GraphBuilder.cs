using System;
using System.Collections.Generic;
using System.Text;

namespace MST_PRIM
{
    public static class GraphBuilder
    {
        private static int GetVerIndex(char ch)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                return ch - 'a';
            }
            if (ch >= 'A' && ch <= 'Z')
            {
                return ch - 'A';
            }
            return -1;
        }

        public static void BuildGraph(UndirectedGraph graph)
        {
            //input: the graph from the lecture about prim
            graph.AddEdge(GetVerIndex('a'), GetVerIndex('c'), 23);
            graph.AddEdge(GetVerIndex('c'), GetVerIndex('e'), 17);
            graph.AddEdge(GetVerIndex('e'), GetVerIndex('i'), 16);
            graph.AddEdge(GetVerIndex('i'), GetVerIndex('k'), 7);
            graph.AddEdge(GetVerIndex('k'), GetVerIndex('l'), 12);
            graph.AddEdge(GetVerIndex('l'), GetVerIndex('f'), 20);
            graph.AddEdge(GetVerIndex('f'), GetVerIndex('b'), 7);
            graph.AddEdge(GetVerIndex('b'), GetVerIndex('a'), 12);
            graph.AddEdge(GetVerIndex('a'), GetVerIndex('d'), 5);
            graph.AddEdge(GetVerIndex('d'), GetVerIndex('c'), 18);
            graph.AddEdge(GetVerIndex('d'), GetVerIndex('g'), 9);
            graph.AddEdge(GetVerIndex('d'), GetVerIndex('f'), 10);
            graph.AddEdge(GetVerIndex('g'), GetVerIndex('j'), 3);
            graph.AddEdge(GetVerIndex('g'), GetVerIndex('h'), 4);
            graph.AddEdge(GetVerIndex('j'), GetVerIndex('e'), 14);
            graph.AddEdge(GetVerIndex('h'), GetVerIndex('l'), 8);
        }

    }
}
