using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Classes {
	public class WeightedNode<TValue, TWeight> {
		public TValue Value { get; set; }
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

		public override string ToString() => Value.ToString();
	}
}
