using System;
using System.Collections.Generic;

namespace Sion.Useful.Graphs {
	/// <summary>
	/// Simple node implementation for use in a graph.
	/// </summary>
	/// <typeparam name="T">Value of the nodes. Can be any type that inherits from IEquatable&lt;T&gt; and IComparable&lt;T&gt;.</typeparam>
	public class Node<T> where T : IEquatable<T>, IComparable<T> {
		/// <summary>
		/// The value of the node.
		/// </summary>
		public T? Value { get; set; }

		/// <summary>
		/// True if the node has been visited.
		/// </summary>
		public bool HasBeenVisited { get; set; }

		/// <summary>
		/// The collection of nodes that this node has an edge to.
		/// </summary>
		public List<Node<T>> Neighbors { get; set; }

		/// <summary>
		/// Creates a new, default value node.
		/// </summary>
		public Node() {
			Value = default;
			HasBeenVisited = false;
			Neighbors = new();
		}

		/// <summary>
		/// Creates a new node with a specific value.
		/// </summary>
		/// <param name="value">The value to set the node.</param>
		public Node(T value) {
			Value = value;
			HasBeenVisited = false;
			Neighbors = new();
		}

		public override string? ToString() => Value?.ToString();
	}
}
