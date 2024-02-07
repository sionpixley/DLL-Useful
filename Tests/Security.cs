using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = Sion.Useful.Security.Random;

namespace Tests {
	[TestClass]
	public class Security {
		[TestMethod]
		public void Random_Bool() {
			try {
				List<bool> trueList = [];
				List<bool> falseList = [];
				for(int i = 0; i < 1000000; i += 1) {
					bool result = Random.Bool();
					if(result) {
						trueList.Add(true);
					}
					else {
						falseList.Add(false);
					}
				}
				double truePercent = trueList.Count / 1000000.0;
				double falsePercent = falseList.Count / 1000000.0;
				Assert.IsTrue(truePercent > 0.45 && falsePercent > 0.45);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Random_Double_MinAndMax() {
			try {
				double min = 8.2;
				double max = 2000.812;
				HashSet<double> set = [];
				for(int i = 0; i < 1000000; i += 1) {
					set.Add(Random.Double(min, max));
				}
				Assert.IsFalse(set.Any(n => n < min || n >= max));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Random_Float_MinAndMax() {
			try {
				float min = 67.2F;
				float max = 73.08F;
				HashSet<float> set = [];
				for(int i = 0; i < 1000000; i += 1) {
					set.Add(Random.Float(min, max));
				}
				Assert.IsFalse(set.Any(n => n < min || n >= max));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Random_Int_MinAndMax() {
			try {
				int min = -63;
				int max = 300;
				HashSet<int> set = [];
				for(int i = 0; i < 1000000; i += 1) {
					set.Add(Random.Int(min, max));
				}
				Assert.IsFalse(set.Any(n => n < min || n >= max));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Random_Long_MinAndMax() {
			try {
				long min = 445L;
				long max = 300234L;
				HashSet<long> set = [];
				for(int i = 0; i < 1000000; i += 1) {
					set.Add(Random.Long(min, max));
				}
				Assert.IsFalse(set.Any(n => n < min || n >= max));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Random_Short_MinAndMax() {
			try {
				short min = 2;
				short max = 100;
				HashSet<short> set = [];
				for(int i = 0; i < 1000000; i += 1) {
					set.Add(Random.Short(min, max));
				}
				Assert.IsFalse(set.Any(n => n < min || n >= max));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
