using System;
using System.Collections.Generic;

namespace Sion.Useful.Graphs {
	[Serializable]
	/// <summary>
	/// Simple weighted node implementation for use in a weighted graph.
	/// </summary>
	/// <typeparam name="TValue">Value of the nodes. Can be any type that inherits from IEquatable&lt;TValue&gt; and IComparable&lt;TValue&gt;.</typeparam>
	/// <typeparam name="TWeight">Value of the weights for the edges. Can be any type that inherits from IEquatable&lt;TWeight&gt; and IComparable&lt;TWeight&gt;.</typeparam>
	public class WeightedNode<TValue, TWeight>
		where TValue : IEquatable<TValue>, IComparable<TValue>
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {

		/// <summary>
		/// The value of the node.
		/// </summary>
		public TValue? Value { get; set; }

		/// <summary>
		/// True if the node has been visited.
		/// </summary>
		public bool HasBeenVisited { get; set; }

		/// <summary>
		/// The collection of nodes that this node has an edge to.
		/// </summary>
		public List<WeightedNode<TValue, TWeight>> Neighbors { get; set; }

		/// <summary>
		/// The collection of weights for each edge that this node has.
		/// </summary>
		public List<TWeight> Weights { get; set; }

		/// <summary>
		/// Creates a new, default value node.
		/// </summary>
		public WeightedNode() {
			Value = default;
			HasBeenVisited = false;
			Neighbors = new();
			Weights = new();
		}

		/// <summary>
		/// Creates a new node with a specific value.
		/// </summary>
		/// <param name="value">The value to set the node.</param>
		public WeightedNode(TValue value) {
			Value = value;
			HasBeenVisited = false;
			Neighbors = new();
			Weights = new();
		}

		public override string? ToString() => Value?.ToString();
	}
}
