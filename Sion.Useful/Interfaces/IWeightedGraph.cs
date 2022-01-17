using Sion.Useful.Classes;
using System;
using System.Collections.Generic;

namespace Sion.Useful.Interfaces {
	public interface IWeightedGraph<TValue, TWeight> 
		where TValue : IEquatable<TValue>, IComparable<TValue> 
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {
			public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

			public bool AddEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2, TWeight weight);
			public bool AddNode(WeightedNode<TValue, TWeight> node);
			public IEnumerable<bool> AddNodes(params WeightedNode<TValue, TWeight>[] nodes);
			public IEnumerable<bool> AddNodes(IEnumerable<WeightedNode<TValue, TWeight>> nodes);
			public void Clear();
			public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch();
			public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch(WeightedNode<TValue, TWeight> root);
			public bool RemoveEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2);
			public bool RemoveNode(WeightedNode<TValue, TWeight> node);
	}
}
