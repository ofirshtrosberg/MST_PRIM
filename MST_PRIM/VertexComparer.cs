using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MST_PRIM
{
    internal class VertexComparer : IComparer<VertexKeyPair>
    {
        public int Compare(VertexKeyPair? x, VertexKeyPair? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (y == null)
            {
                return -1;
            }
            else if (x == null)
            {
                return 1;
            }
            if (x.Key == y.Key)
            {
                return 0;
            }
            else if (x.Key < y.Key)
            {
                return -1;
            }
            return 1;
        }
    }
}
