// Gal Cohen: 314752536
// Ofir Shtrosberg: 207828641
using System;
using System.Collections.Generic;
using System.Text;

namespace MST_PRIM
{
    public class Graph
    {
        protected int[,] _edgeWeightsMatrix;
        protected bool[,] _isEdgeExistMatrix;
        protected int _numOfVertex;
        protected char[] _colorOfVertices;
        protected int[] _pi;
        public int NumOfVertex { get => _numOfVertex; }
        // constructor
        public Graph(int numOfVertex)
        {
            _edgeWeightsMatrix = new int[numOfVertex, numOfVertex];
            _isEdgeExistMatrix = new bool[numOfVertex, numOfVertex];
            _numOfVertex = numOfVertex;
            _colorOfVertices = new char[numOfVertex];
            _pi = new int[numOfVertex];

        }
        public char[] getColorOfVertices()
        {
            return this._colorOfVertices;
        }
        public void setColor(int index, char color)
        {
            if (index < _numOfVertex)
            {
                this._colorOfVertices[index] = color;
            }
        }
        public int[] getPi()
        {
            return this._pi;
        }
        public void setPi(int vertex, int parent) 
        {
            if (vertex < _numOfVertex)
            {
                this._pi[vertex] = parent;
            }
        }
        public virtual void AddEdge(int src, int dest, int weight)
        {
            _edgeWeightsMatrix[src, dest] = weight;
            _isEdgeExistMatrix[src, dest] = true;
        }

        public virtual void RemoveEdge(int src, int dest)
        {
            _isEdgeExistMatrix[src, dest] = false;
        }
        // why out and why int and not double??????
        public bool TryGetWeight(int src, int dest, out int weight)
        {
            if (src >= 0 && dest >= 0)
            {
                if (src < _numOfVertex && dest < _numOfVertex && _isEdgeExistMatrix[src, dest])
                {
                    weight = _edgeWeightsMatrix[src, dest];
                    return true;
                }
            }
            weight = 0;
            return false;
        }

        public override string ToString()
        {
            string retValue = "Src\tDest\tWeight\n";
            for (int i = 0; i < _numOfVertex; i++)
            {
                for (int j = 0; j < _numOfVertex; j++)
                {
                    if (_isEdgeExistMatrix[i, j])
                    {
                        retValue += $"{i}\t{j}\t{_edgeWeightsMatrix[i, j]}";
                    }
                }
            }
            return retValue;
        }
    }
}
