using System;
using System.Collections.Generic;

namespace Sion.Useful.Graphs.Interfaces {
	/// <summary>
	/// Interface for a graph implementation.
	/// </summary>
	/// <typeparam name="T">Value of the nodes. Can be any type that inherits from IEquatable&lt;T&gt; and IComparable&lt;T&gt;.</typeparam>
	public interface IGraph<T> where T : IEquatable<T>, IComparable<T> {
		/// <summary>
		/// Full list of all the nodes in the graph.
		/// </summary>
		public List<Node<T>> NodeSet { get; set; }

		/// <summary>
		/// Adds an edge between two nodes.
		/// </summary>
		/// <param name="node1">The first node.</param>
		/// <param name="node2">The second node.</param>
		/// <returns>True if successful.</returns>
		public bool AddEdge(Node<T> node1, Node<T> node2);

		/// <summary>
		/// Adds a node to the graph.
		/// </summary>
		/// <param name="node">The node to add.</param>
		/// <returns>True if successful.</returns>
		public bool AddNode(Node<T> node);

		/// <summary>
		/// Adds a variable amount of nodes to the graph.
		/// </summary>
		/// <param name="nodes">The nodes to add.</param>
		/// <returns>True if successful.</returns>
		public IEnumerable<bool> AddNodes(params Node<T>[] nodes);

		/// <summary>
		/// Adds a collection of nodes to the graph.
		/// </summary>
		/// <param name="nodes">The nodes to add.</param>
		/// <returns>True if successful.</returns>
		public IEnumerable<bool> AddNodes(IEnumerable<Node<T>> nodes);

		/// <summary>
		/// Returns a collection of nodes in breadth first search order, using the first node added as root.
		/// </summary>
		/// <returns>A collection of nodes in breadth first search order.</returns>
		public IEnumerable<Node<T>> BreadthFirstSearch();

		/// <summary>
		/// Returns a collection of nodes in breadth first search order, using a provided root.
		/// </summary>
		/// <param name="root">The node in the graph to use as the root.</param>
		/// <returns>A collection of nodes in breadth first search order.</returns>
		public IEnumerable<Node<T>> BreadthFirstSearch(Node<T> root);

		/// <summary>
		/// Removes all nodes from the graph.
		/// </summary>
		public void Clear();

		/// <summary>
		/// Returns a collection of nodes in depth first search order, using the first node added as root.
		/// </summary>
		/// <returns>A collection of nodes in depth first search order.</returns>
		public IEnumerable<Node<T>> DepthFirstSearch();

		/// <summary>
		/// Returns a collection of nodes in depth first search order, using a provided root.
		/// </summary>
		/// <param name="root">The node in the graph to use as the root.</param>
		/// <returns>A collection of nodes in depth first search order.</returns>
		public IEnumerable<Node<T>> DepthFirstSearch(Node<T> root);

		/// <summary>
		/// Removes an edge between two nodes.
		/// </summary>
		/// <param name="node1">The first node.</param>
		/// <param name="node2">The second node.</param>
		/// <returns>True if the removal was successful.</returns>
		public bool RemoveEdge(Node<T> node1, Node<T> node2);

		/// <summary>
		/// Removes a specific node from the graph.
		/// </summary>
		/// <param name="node">The node to remove.</param>
		/// <returns>True if the removal was successful.</returns>
		public bool RemoveNode(Node<T> node);

		/// <summary>
		/// Sets all nodes HasBeenVisited property to false.
		/// </summary>
		public void ResetVisited();
	}
}
