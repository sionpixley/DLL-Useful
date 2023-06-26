using System;
using System.Collections.Generic;

namespace Sion.Useful.Classes {
	[Obsolete("Please use Sion.Useful.Graphs.Node instead. This will be removed in version 3.")]
	public class Node<T> where T : IEquatable<T>, IComparable<T> {
		public T Value { get; set; }
		public bool HasBeenVisited { get; set; }
		public List<Node<T>> Neighbors { get; set; }

		public Node() {
			Value = default;
			HasBeenVisited = false;
			Neighbors = new();
		}

		public Node(T value) {
			Value = value;
			HasBeenVisited = false;
			Neighbors = new();
		}

		public override string ToString() => Value.ToString();
	}
}
