﻿using Sion.Useful.Classes;
using System;
using System.Collections.Generic;

namespace Sion.Useful.Interfaces {
	[Obsolete("Please use Sion.Useful.Graphs.Interfaces.IGraph instead. This will be removed in version 3.")]
	public interface IGraph<T> where T : IEquatable<T>, IComparable<T> {
		public List<Node<T>> NodeSet { get; set; }

		public bool AddEdge(Node<T> node1, Node<T> node2);
		public bool AddNode(Node<T> node);
		public IEnumerable<bool> AddNodes(params Node<T>[] nodes);
		public IEnumerable<bool> AddNodes(IEnumerable<Node<T>> nodes);
		public IEnumerable<Node<T>> BreadthFirstSearch();
		public IEnumerable<Node<T>> BreadthFirstSearch(Node<T> root);
		public void Clear();
		public IEnumerable<Node<T>> DepthFirstSearch();
		public IEnumerable<Node<T>> DepthFirstSearch(Node<T> root);
		public bool RemoveEdge(Node<T> node1, Node<T> node2);
		public bool RemoveNode(Node<T> node);
		public void ResetVisited();
	}
}