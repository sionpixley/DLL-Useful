using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sion.Useful.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests {
	[TestClass]
	public class Graph {
		[TestMethod]
		public void AddEdge() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2);
				bool wasSuccessful = node1.Neighbors.Contains(node2) && node2.Neighbors.Contains(node1);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddEdge_Existing() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2);
				bool wasSuccessful = graph.AddEdge(node1, node2);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNode() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.NodeSet.Contains(node);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNode_Existing() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.AddNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNodes_IEnumerable() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				List<Sion.Useful.Classes.Node<int>> nodes = new() { node1, node2 };
				bool wasSuccessful = graph.AddNodes(nodes).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNodes_Params() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				bool wasSuccessful = graph.AddNodes(node1, node2).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void BreadthFirstSearch_Default() {
			try {
				Sion.Useful.Classes.Graph<char> graph = new();
				Sion.Useful.Classes.Node<char> a = new('a');
				Sion.Useful.Classes.Node<char> b = new('b');
				Sion.Useful.Classes.Node<char> c = new('c');
				Sion.Useful.Classes.Node<char> d = new('d');
				Sion.Useful.Classes.Node<char> e = new('e');
				Sion.Useful.Classes.Node<char> f = new('f');
				graph.AddNodes(a, b, c, d, e, f);
				graph.AddEdge(a, b);
				graph.AddEdge(a, d);
				graph.AddEdge(a, e);
				graph.AddEdge(a, f);
				graph.AddEdge(b, c);

				IEnumerable<Node<char>> bfs = graph.BreadthFirstSearch();
				Node<char>[] expected = { a, b, d, e, f, c };

				Assert.IsTrue(Enumerable.SequenceEqual(expected, bfs));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void BreadthFirstSearch_Empty() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				IEnumerable<Node<int>> expected = Enumerable.Empty<Node<int>>();
				IEnumerable<Node<int>> bfs = graph.BreadthFirstSearch();
				Assert.IsTrue(Enumerable.SequenceEqual(expected, bfs));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void BreadthFirstSearch_NotExisting() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> n1 = new(1);
				Sion.Useful.Classes.Node<int> n2 = new(2);
				graph.AddNode(n1);

				IEnumerable<Node<int>> expected = Enumerable.Empty<Node<int>>();
				IEnumerable<Node<int>> bfs = graph.BreadthFirstSearch(n2);
				Assert.IsTrue(Enumerable.SequenceEqual(expected, bfs));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void BreadthFirstSearch_RootProvided() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> n1 = new(1);
				Sion.Useful.Classes.Node<int> n2 = new(2);
				graph.AddNodes(n1, n2);
				graph.AddEdge(n1, n2);

				Node<int>[] expected = { n2, n1 };
				IEnumerable<Node<int>> bfs = graph.BreadthFirstSearch(n2);
				Assert.IsTrue(Enumerable.SequenceEqual(expected, bfs));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Clear() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				Sion.Useful.Classes.Node<int> node3 = new();
				graph.AddNodes(node1, node2, node3);
				graph.Clear();
				bool wasSuccessful = graph.NodeSet.Count == 0;
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CustomToString() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> n1 = new(1);
				Sion.Useful.Classes.Node<int> n2 = new(2);
				graph.AddNodes(n1, n2);
				graph.AddEdge(n1, n2);

				string expected = "[1],[2]";
				string result = graph.ToString();

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_Default() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new(1);
				Sion.Useful.Classes.Node<int> node2 = new(2);
				Sion.Useful.Classes.Node<int> node3 = new(3);
				Sion.Useful.Classes.Node<int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2);
				graph.AddEdge(node1, node3);
				graph.AddEdge(node3, node4);
				IEnumerable<Sion.Useful.Classes.Node<int>> dfs = graph.DepthFirstSearch();
				List<Sion.Useful.Classes.Node<int>> expected = new() { node1, node2, node3, node4 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_Empty() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				IEnumerable<Sion.Useful.Classes.Node<int>> dfs = graph.DepthFirstSearch();
				Assert.AreEqual(dfs.Count(), 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_NotExisting() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node = new();
				List<Sion.Useful.Classes.Node<int>> dfs = graph.DepthFirstSearch(node).ToList();
				Assert.AreEqual(dfs.Count, 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_RootProvided() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new(1);
				Sion.Useful.Classes.Node<int> node2 = new(2);
				Sion.Useful.Classes.Node<int> node3 = new(3);
				Sion.Useful.Classes.Node<int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2);
				graph.AddEdge(node1, node3);
				graph.AddEdge(node3, node4);
				IEnumerable<Sion.Useful.Classes.Node<int>> dfs = graph.DepthFirstSearch(node2);
				List<Sion.Useful.Classes.Node<int>> expected = new() { node2, node1, node3, node4 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveEdge() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2);
				graph.RemoveEdge(node1, node2);
				bool wasSuccessful = node1.Neighbors.Contains(node2) && node2.Neighbors.Contains(node1);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveEdge_NotExisting() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node1 = new();
				Sion.Useful.Classes.Node<int> node2 = new();
				graph.AddNodes(node1, node2);
				bool wasSuccessful = graph.RemoveEdge(node1, node2);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveNode() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node = new();
				graph.AddNode(node);
				graph.RemoveNode(node);
				bool wasSuccessful = graph.NodeSet.Contains(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveNode_NotExisting() {
			try {
				Sion.Useful.Classes.Graph<int> graph = new();
				Sion.Useful.Classes.Node<int> node = new();
				bool wasSuccessful = graph.RemoveNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
