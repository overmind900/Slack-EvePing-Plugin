using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Diagnostics;

namespace SlackEvePing {
	/// <summary>
	/// Summary description for EvePing
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class EvePing : System.Web.Services.WebService {

		/*
		token={0}
		team_id={1}
		channel_id={2}
		channel_name={3}
		user_id={4}
		user_name={5}
		command={6}
		text={7}
		 */
		[WebMethod]
		public string SlackTest(string token, string team_id, string channel_id, string channel_name, string user_id, string user_name, string command, string text) {
#if DEBUG
			Console.WriteLine(string.Format("token={0}, team_id={1}, channel_id={2}, channel_name={3}, user_id={4}, user_name={5}, command={6}, text={7}", token, team_id, channel_id, channel_name, user_id, user_name, command, text)); 
#endif
			return "200";
		}

		[WebMethod]
		public string Hello(string name) {
			return "Hello " + name;
		}


	}
}
