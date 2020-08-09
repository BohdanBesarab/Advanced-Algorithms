﻿using Advanced.Algorithms.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.Graph
{
    [TestClass]
    public class BiPartititeMatch_Tests
    {
        /// <summary>
        /// Test Max BiParitite Edges using Ford-Fukerson algorithm
        /// </summary>
        [TestMethod]
        public void MaxBiPartiteMatch_AdjacencyListGraph_Smoke_Test()
        {
            var graph = new Advanced.Algorithms.DataStructures.Graph.AdjacencyList.Graph<char>();

            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');

            graph.AddVertex('F');
            graph.AddVertex('G');
            graph.AddVertex('H');
            graph.AddVertex('I');

            graph.AddEdge('A', 'F');
            graph.AddEdge('B', 'F');
            graph.AddEdge('B', 'G');
            graph.AddEdge('C', 'H');
            graph.AddEdge('C', 'I');
            graph.AddEdge('D', 'G');
            graph.AddEdge('D', 'H');
            graph.AddEdge('E', 'F');
            graph.AddEdge('E', 'I');

            var algorithm = new BiPartiteMatching<char>(new BiPartiteMatchOperators());

            var result = algorithm.GetMaxBiPartiteMatching(graph);

            Assert.AreEqual(result.Count, 4);
        }

        [TestMethod]
        public void MaxBiPartiteMatch_AdjacencyMatrixGraph_Smoke_Test()
        {
            var graph = new Advanced.Algorithms.DataStructures.Graph.AdjacencyMatrix.Graph<char>();

            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');

            graph.AddVertex('F');
            graph.AddVertex('G');
            graph.AddVertex('H');
            graph.AddVertex('I');

            graph.AddEdge('A', 'F');
            graph.AddEdge('B', 'F');
            graph.AddEdge('B', 'G');
            graph.AddEdge('C', 'H');
            graph.AddEdge('C', 'I');
            graph.AddEdge('D', 'G');
            graph.AddEdge('D', 'H');
            graph.AddEdge('E', 'F');
            graph.AddEdge('E', 'I');

            var algorithm = new BiPartiteMatching<char>(new BiPartiteMatchOperators());

            var result = algorithm.GetMaxBiPartiteMatching(graph);

            Assert.AreEqual(result.Count, 4);
        }
        /// <summary>
        /// operators for generics
        /// implemented for int type for edge weights
        /// </summary>
        public class BiPartiteMatchOperators : IBiPartiteMatchOperators<char>
        {

            private int currentIndex = 0;
            private char[] randomVertices = new char[] { '#', '*' };

            public int defaultWeight
            {
                get
                {
                    return 0;
                }
            }

            public int MaxWeight
            {
                get
                {
                    return int.MaxValue;
                }
            }

            public int AddWeights(int a, int b)
            {
                return checked(a + b);
            }

            /// <summary>
            /// we need only two random unique vertices not in given graph
            /// for Source & Sink dummy nodes
            /// </summary>
            /// <returns></returns>
            public char GetRandomUniqueVertex()
            {
                currentIndex = currentIndex == 2 ? 0 : currentIndex;
                var random = randomVertices[currentIndex];
                currentIndex++;
                return random;
            }

            public int SubstractWeights(int a, int b)
            {
                return checked(a - b);
            }
        }
    }
}
