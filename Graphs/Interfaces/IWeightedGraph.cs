using System;
using System.Collections.Generic;

namespace Sion.Useful.Graphs.Interfaces {
	/// <summary>
	/// Interface for a weighted graph implementation.
	/// </summary>
	/// <typeparam name="TValue">Value of the nodes. Can be any type that inherits from IEquatable&lt;TValue&gt; and IComparable&lt;TValue&gt;.</typeparam>
	/// <typeparam name="TWeight">Value of the weights for the edges. Can be any type that inherits from IEquatable&lt;TWeight&gt; and IComparable&lt;TWeight&gt;.</typeparam>
	public interface IWeightedGraph<TValue, TWeight>
		where TValue : IEquatable<TValue>, IComparable<TValue>
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {

		/// <summary>
		/// 
		/// </summary>
		public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node1"></param>
		/// <param name="node2"></param>
		/// <param name="weight"></param>
		/// <returns></returns>
		public bool AddEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2, TWeight weight);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool AddNode(WeightedNode<TValue, TWeight> node);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nodes"></param>
		/// <returns></returns>
		public IEnumerable<bool> AddNodes(params WeightedNode<TValue, TWeight>[] nodes);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nodes"></param>
		/// <returns></returns>
		public IEnumerable<bool> AddNodes(IEnumerable<WeightedNode<TValue, TWeight>> nodes);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<WeightedNode<TValue, TWeight>> BreadthFirstSearch();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public IEnumerable<WeightedNode<TValue, TWeight>> BreadthFirstSearch(WeightedNode<TValue, TWeight> root);

		/// <summary>
		/// 
		/// </summary>
		public void Clear();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch(WeightedNode<TValue, TWeight> root);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node1"></param>
		/// <param name="node2"></param>
		/// <returns></returns>
		public bool RemoveEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool RemoveNode(WeightedNode<TValue, TWeight> node);

		/// <summary>
		/// 
		/// </summary>
		public void ResetVisited();
	}
}
