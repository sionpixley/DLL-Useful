using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Classes {
	public class WeightedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight> 
		where TValue : IEquatable<TValue>, IComparable<TValue> 
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {
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
					int i = 0;
					for(; i < node1.Weights.Count; i += 1) {
						if(weight.CompareTo(node1.Weights[0]) < 0) {
							break;
						}
					}
					node1.Neighbors.Insert(i, node2);
					node1.Weights.Insert(i, weight);

					i = 0;
					for(; i < node2.Weights.Count; i += 1) {
						if(weight.CompareTo(node2.Weights[i]) < 0) {
							break;
						}
					}
					node2.Neighbors.Insert(i, node1);
					node2.Weights.Insert(i, weight);

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

			public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch() {
				if(NodeSet.Count == 0) {
					return new List<WeightedNode<TValue, TWeight>>();
				}
				else {
					return DepthFirstSearch(NodeSet[0]);
				}
			}

			public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch(WeightedNode<TValue, TWeight> root) {
				if(!NodeSet.Contains(root)) {
					return new List<WeightedNode<TValue, TWeight>>();
				}

				List<WeightedNode<TValue, TWeight>> result = new();
				root.HasBeenVisited = true;
				result.Add(root);

				Stack<WeightedNode<TValue, TWeight>> order = new();
				order.Push(root);

				WeightedNode<TValue, TWeight> current = root;
				while(NodeSet.Any(node => !node.HasBeenVisited)) {
					if(current.Neighbors.All(n => n.HasBeenVisited) && order.Count == 0) {
						break;
					}
					else if(current.Neighbors.All(n => n.HasBeenVisited)) {
						current = order.Pop();
					}
					else {
						current = current.Neighbors.Where(n => !n.HasBeenVisited).First();
						current.HasBeenVisited = true;
						result.Add(current);
						order.Push(current);
					}
				}

				return result;
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
