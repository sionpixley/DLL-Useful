using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Classes {
	public class WeightedDirectedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight> {
		public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

		public WeightedDirectedGraph() {
			NodeSet = new();
		}

		public bool AddEdge(WeightedNode<TValue, TWeight> fromNode, WeightedNode<TValue, TWeight> toNode, TWeight weight) {
			if(!NodeSet.Contains(fromNode) || !NodeSet.Contains(toNode)) {
				return false;
			}
			else if(fromNode.Neighbors.Contains(toNode)) {
				return false;
			}
			else {
				fromNode.Neighbors.Add(toNode);
				fromNode.Weights.Add(weight);
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

		public bool RemoveEdge(WeightedNode<TValue, TWeight> fromNode, WeightedNode<TValue, TWeight> toNode) {
			int toNodeIndex = fromNode.Neighbors.IndexOf(toNode);

			if(!NodeSet.Contains(fromNode) || !NodeSet.Contains(toNode)) {
				return false;
			}
			else if(toNodeIndex == -1) {
				return false;
			}
			else {
				fromNode.Neighbors.Remove(toNode);
				fromNode.Weights = fromNode.Weights.Take(toNodeIndex).Skip(1).TakeWhile(w => true).ToList();
				return true;
			}
		}

		public bool RemoveNode(WeightedNode<TValue, TWeight> node) {
			if(!NodeSet.Contains(node)) {
				return false;
			}
			else {
				IEnumerable<WeightedNode<TValue, TWeight>> referencingNodes = NodeSet.Where(n => n.Neighbors.Contains(node));
				foreach(var referencingNode in referencingNodes) {
					RemoveEdge(referencingNode, node);
				}
				node.Neighbors.Clear();
				NodeSet.Remove(node);
				return true;
			}
		}
	}
}
