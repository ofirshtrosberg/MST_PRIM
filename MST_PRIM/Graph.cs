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

        public int NumOfVertex { get => _numOfVertex; }
        public Graph(int numOfVertex)
        {
            _edgeWeightsMatrix = new int[numOfVertex, numOfVertex];
            _isEdgeExistMatrix = new bool[numOfVertex, numOfVertex];
            _numOfVertex = numOfVertex;
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

        public bool TryGetWeight(int src, int dest, out int weight)
        {
            if (src < _numOfVertex && dest < _numOfVertex && _isEdgeExistMatrix[src, dest])
            {
                weight = _edgeWeightsMatrix[src, dest];
                return true;
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
