using System;
using System.Collections.Generic;

namespace Sion.Useful.Graphs.Interfaces
{
    /// <summary>
    /// Interface for a weighted graph implementation.
    /// </summary>
    /// <typeparam name="TValue">Value of the nodes. Can be any type that inherits from IEquatable&lt;TValue&gt; and IComparable&lt;TValue&gt;.</typeparam>
    /// <typeparam name="TWeight">Value of the weights for the edges. Can be any type that inherits from IEquatable&lt;TWeight&gt; and IComparable&lt;TWeight&gt;.</typeparam>
    public interface IWeightedGraph<TValue, TWeight>
        where TValue : IEquatable<TValue>, IComparable<TValue>
        where TWeight : IEquatable<TWeight>, IComparable<TWeight>
    {

        /// <summary>
        /// Full list of all the nodes in the graph.
        /// </summary>
        public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

        /// <summary>
        /// Adds an edge between two nodes. The edge is given the weight provided.
        /// </summary>
        /// <param name="node1">The first node.</param>
        /// <param name="node2">The second node.</param>
        /// <param name="weight">Weight of the edge.</param>
        /// <returns>True if successful.</returns>
        public bool AddEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2, TWeight weight);

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <returns>True if successful.</returns>
        public bool AddNode(WeightedNode<TValue, TWeight> node);

        /// <summary>
        /// Adds a variable amount of nodes to the graph.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        /// <returns>True if successful.</returns>
        public IEnumerable<bool> AddNodes(params WeightedNode<TValue, TWeight>[] nodes);

        /// <summary>
        /// Adds a collection of nodes to the graph.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        /// <returns>True if successful.</returns>
        public IEnumerable<bool> AddNodes(IEnumerable<WeightedNode<TValue, TWeight>> nodes);

        /// <summary>
        /// Returns a collection of nodes in breadth first search order, using the first node added as root.
        /// </summary>
        /// <returns>A collection of nodes in breadth first search order.</returns>
        public IEnumerable<WeightedNode<TValue, TWeight>> BreadthFirstSearch();

        /// <summary>
        /// Returns a collection of nodes in breadth first search order, using a provided root.
        /// </summary>
        /// <param name="root">The node in the graph to use as the root.</param>
        /// <returns>A collection of nodes in breadth first search order.</returns>
        public IEnumerable<WeightedNode<TValue, TWeight>> BreadthFirstSearch(WeightedNode<TValue, TWeight> root);

        /// <summary>
        /// Removes all nodes from the graph.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Returns a collection of nodes in depth first search order, using the first node added as root.
        /// </summary>
        /// <returns>A collection of nodes in depth first search order.</returns>
        public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch();

        /// <summary>
        /// Returns a collection of nodes in depth first search order, using a provided root.
        /// </summary>
        /// <param name="root">The node in the graph to use as the root.</param>
        /// <returns>A collection of nodes in depth first search order.</returns>
        public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch(WeightedNode<TValue, TWeight> root);

        /// <summary>
        /// Removes an edge between two nodes.
        /// </summary>
        /// <param name="node1">The first node.</param>
        /// <param name="node2">The second node.</param>
        /// <returns>True if the removal was successful.</returns>
        public bool RemoveEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2);

        /// <summary>
        /// Removes a specific node from the graph.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        /// <returns>True if the removal was successful.</returns>
        public bool RemoveNode(WeightedNode<TValue, TWeight> node);

        /// <summary>
        /// Sets all nodes HasBeenVisited property to false.
        /// </summary>
        public void ResetVisited();
    }
}
