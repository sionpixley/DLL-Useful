using System;
using System.Collections.Generic;

namespace Sion.Useful.Graphs {
	public class WeightedNode<TValue, TWeight>
		where TValue : IEquatable<TValue>, IComparable<TValue>
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {
		public TValue? Value { get; set; }
		public bool HasBeenVisited { get; set; }
		public List<WeightedNode<TValue, TWeight>> Neighbors { get; set; }
		public List<TWeight> Weights { get; set; }

		public WeightedNode() {
			Value = default;
			HasBeenVisited = false;
			Neighbors = new();
			Weights = new();
		}

		public WeightedNode(TValue value) {
			Value = value;
			HasBeenVisited = false;
			Neighbors = new();
			Weights = new();
		}

		public override string? ToString() => Value?.ToString();
	}
}
