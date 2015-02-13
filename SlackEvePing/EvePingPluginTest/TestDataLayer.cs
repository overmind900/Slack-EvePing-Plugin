using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SlackEvePingPlugin;

namespace EvePingPluginTest {
	[TestFixture]
	public class TestDataLayer {

		[Test]
		public void TestFind() {
			string keyId;
			string vCode;
			string userID = "1";
			bool found = DataLayer.Find(userID,out keyId,out vCode);

			Assert.True(found);
			Assert.AreEqual("1",keyId);
			Assert.AreEqual("1",vCode);
		}
	}
}
