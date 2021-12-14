using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Classes {
	public class WeightedDirectedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight>
		where TValue : IEquatable<TValue>, IComparable<TValue>
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {
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
					int i = 0;
					for(; i < fromNode.Weights.Count; i += 1) {
						if(weight.CompareTo(fromNode.Weights[0]) < 0) {
							break;
						}
					}
					fromNode.Neighbors.Insert(i, toNode);
					fromNode.Weights.Insert(i, weight);
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
					throw new BehindScenes.Exception(Enums.ExceptionCode.RootProvidedDoesNotExist, "Root provided does not exist in the graph.");
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
