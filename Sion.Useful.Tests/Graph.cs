using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Tests {
	[TestClass]
	public class Graph {
		[TestMethod]
		public void Test_AddEdge() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
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
		public void Test_AddEdge_Existing() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
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
		public void Test_AddNode() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.NodeSet.Contains(node);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNode_Existing() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.AddNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNodes_IEnumerable() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				List<Classes.Node<int>> nodes = new() { node1, node2 };
				bool wasSuccessful = graph.AddNodes(nodes).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNodes_Params() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				bool wasSuccessful = graph.AddNodes(node1, node2).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_Clear() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				Classes.Node<int> node3 = new();
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
		public void Test_DepthFirstSearch_Default() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new(1);
				Classes.Node<int> node2 = new(2);
				Classes.Node<int> node3 = new(3);
				Classes.Node<int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2);
				graph.AddEdge(node1, node3);
				graph.AddEdge(node3, node4);
				IEnumerable<Classes.Node<int>> dfs = graph.DepthFirstSearch();
				List<Classes.Node<int>> expected = new() { node1, node2, node3, node4 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_Empty() {
			try {
				Classes.Graph<int> graph = new();
				IEnumerable<Classes.Node<int>> dfs = graph.DepthFirstSearch();
				Assert.AreEqual(dfs.Count(), 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_NotExisting() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node = new();
				graph.DepthFirstSearch(node);
			}
			catch(BehindScenes.Exception ge) {
				Assert.AreEqual(ge.Code, Enums.ExceptionCode.RootProvidedDoesNotExist);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_RootProvided() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new(1);
				Classes.Node<int> node2 = new(2);
				Classes.Node<int> node3 = new(3);
				Classes.Node<int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2);
				graph.AddEdge(node1, node3);
				graph.AddEdge(node3, node4);
				IEnumerable<Classes.Node<int>> dfs = graph.DepthFirstSearch(node2);
				List<Classes.Node<int>> expected = new() { node2, node1, node3, node4 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveEdge() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
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
		public void Test_RemoveEdge_NotExisting() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				graph.AddNodes(node1, node2);
				bool wasSuccessful = graph.RemoveEdge(node1, node2);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveNode() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node = new();
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
		public void Test_RemoveNode_NotExisting() {
			try {
				Classes.Graph<int> graph = new();
				Classes.Node<int> node = new();
				bool wasSuccessful = graph.RemoveNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
