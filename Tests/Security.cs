using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Random = Sion.Useful.Security.Random;

namespace Tests {
	[TestClass]
	public class Security {
		[TestMethod]
		public void Random_Bool() {
			try {
				List<bool> trueList = new();
				List<bool> falseList = new();
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
	}
}
