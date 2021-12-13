using Sion.Useful.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Classes {
	public class WeightedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight> {
		public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

		public WeightedGraph() {
			NodeSet = new();
		}

		public bool AddEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2, TWeight weight) {
			if(!NodeSet.Contains(node1) || !NodeSet.Contains(node2)) {
				return false;
			}
			else if(node1.Neighbors.Contains(node2) || node2.Neighbors.Contains(node1)) {
				return false;
			}
			else {
				node1.Neighbors.Add(node2);
				node1.Weights.Add(weight);
				node2.Neighbors.Add(node1);
				node2.Weights.Add(weight);
				return true;
			}
		}

		public bool AddNode(WeightedNode<TValue, TWeight> node) {
			if(NodeSet.Contains(node)) {
				return false;
			}
			else {
				NodeSet.Add(node);
				return true;
			}
		}

		public IEnumerable<bool> AddNodes(params WeightedNode<TValue, TWeight>[] nodes) {
			List<bool> result = new();
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public IEnumerable<bool> AddNodes(IEnumerable<WeightedNode<TValue, TWeight>> nodes) {
			List<bool> result = new();
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public void Clear() {
			NodeSet.Clear();
		}

		public bool RemoveEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2) {
			int node1Index = node2.Neighbors.IndexOf(node1);
			int node2Index = node1.Neighbors.IndexOf(node2);

			if(!NodeSet.Contains(node1) || !NodeSet.Contains(node2)) {
				return false;
			}
			else if(node1Index == -1 || node2Index == -1) {
				return false;
			}
			else {
				node1.Neighbors.Remove(node2);
				node1.Weights = node1.Weights.Take(node2Index).Skip(1).TakeWhile(w => true).ToList();
				node2.Neighbors.Remove(node1);
				node2.Weights = node2.Weights.Take(node1Index).Skip(1).TakeWhile(w => true).ToList();
				return true;
			}
		}

		public bool RemoveNode(WeightedNode<TValue, TWeight> node) {
			if(!NodeSet.Contains(node)) {
				return false;
			}
			else {
				foreach(var neighbor in node.Neighbors) {
					RemoveEdge(node, neighbor);
				}
				NodeSet.Remove(node);
				return true;
			}
		}
	}
}
