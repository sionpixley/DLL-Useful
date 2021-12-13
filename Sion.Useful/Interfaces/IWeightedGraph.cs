using Sion.Useful.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Interfaces {
	public interface IWeightedGraph<TValue, TWeight> {
		public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

		public bool AddEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2, TWeight weight);
		public bool AddNode(WeightedNode<TValue, TWeight> node);
		public IEnumerable<bool> AddNodes(params WeightedNode<TValue, TWeight>[] nodes);
		public IEnumerable<bool> AddNodes(IEnumerable<WeightedNode<TValue, TWeight>> nodes);
		public void Clear();
		public bool RemoveEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2);
		public bool RemoveNode(WeightedNode<TValue, TWeight> node);
	}
}
