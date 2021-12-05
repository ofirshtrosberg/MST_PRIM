// Gal Cohen: 314752536
// Ofir Shtrosberg: 207828641
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
            //graph.AddEdge(GetVerIndex('a'), GetVerIndex('c'), 23);
            //graph.AddEdge(GetVerIndex('c'), GetVerIndex('e'), 17);
            //graph.AddEdge(GetVerIndex('e'), GetVerIndex('i'), 16);
            //graph.AddEdge(GetVerIndex('i'), GetVerIndex('k'), 7);
            //graph.AddEdge(GetVerIndex('k'), GetVerIndex('l'), 12);
            //graph.AddEdge(GetVerIndex('l'), GetVerIndex('f'), 20);
            //graph.AddEdge(GetVerIndex('f'), GetVerIndex('b'), 7);
            //graph.AddEdge(GetVerIndex('b'), GetVerIndex('a'), 12);
            //graph.AddEdge(GetVerIndex('a'), GetVerIndex('d'), 5);
            //graph.AddEdge(GetVerIndex('d'), GetVerIndex('c'), 18);
            //graph.AddEdge(GetVerIndex('d'), GetVerIndex('g'), 9);
            //graph.AddEdge(GetVerIndex('d'), GetVerIndex('f'), 10);
            //graph.AddEdge(GetVerIndex('g'), GetVerIndex('j'), 3);
            //graph.AddEdge(GetVerIndex('g'), GetVerIndex('h'), 4);
            //graph.AddEdge(GetVerIndex('j'), GetVerIndex('e'), 14);
            //graph.AddEdge(GetVerIndex('h'), GetVerIndex('l'), 8);

            // part 3 
            graph.AddEdge(0, 4, 5);
            graph.AddEdge(4, 25, 30);
            graph.AddEdge(25, 23, 14);
            graph.AddEdge(23, 24, 31);
            graph.AddEdge(23, 21, 26);
            graph.AddEdge(23, 22, 3);
            graph.AddEdge(22, 21, 5);
            graph.AddEdge(22, 25, 13);
            graph.AddEdge(22, 3, 12);
            graph.AddEdge(3, 25, 7);
            graph.AddEdge(3, 4, 20);
            graph.AddEdge(3, 21, 7);
            graph.AddEdge(3, 2, 15);
            graph.AddEdge(3, 1, 14);
            graph.AddEdge(4, 1, 10);
            graph.AddEdge(0, 1, 3);
            graph.AddEdge(0, 9, 4);
            graph.AddEdge(1, 9, 70);
            graph.AddEdge(1, 5, 100);
            graph.AddEdge(1, 6, 5);
            graph.AddEdge(6, 5, 7);
            graph.AddEdge(2, 6, 2);
            graph.AddEdge(6, 21, 5);
            graph.AddEdge(6, 8, 4);
            graph.AddEdge(6, 7, 6);
            graph.AddEdge(5, 7, 8);
            graph.AddEdge(5, 9, 1);
            graph.AddEdge(9, 7, 23);
            graph.AddEdge(7, 8, 3);
            graph.AddEdge(8, 21, 21);
            graph.AddEdge(2, 21, 10);
            graph.AddEdge(8, 12, 2);
            graph.AddEdge(8, 14, 27);
            graph.AddEdge(8, 13, 31);
            graph.AddEdge(7, 13, 35);
            graph.AddEdge(7, 11, 33);
            graph.AddEdge(9, 11, 50);
            graph.AddEdge(9, 10, 80);
            graph.AddEdge(10, 11, 7);
            graph.AddEdge(11, 13, 41);
            graph.AddEdge(13, 14, 37);
            graph.AddEdge(14, 15, 10);
            graph.AddEdge(14, 12, 25);
            graph.AddEdge(14, 16, 8);
            graph.AddEdge(13, 16, 1);
            graph.AddEdge(13, 17, 5);
            graph.AddEdge(16, 17, 2);
            graph.AddEdge(11, 17, 20);
            graph.AddEdge(10, 17, 5);
            graph.AddEdge(10, 18, 103);
            graph.AddEdge(16, 19, 57);
            graph.AddEdge(19, 20, 12);
            graph.AddEdge(17, 19, 20);
        }

    }
}
