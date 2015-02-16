using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Diagnostics;
using SlackEvePingPlugin;

namespace SlackEvePingWebservice {
	/// <summary>
	/// Summary description for EvePing
	/// </summary>
	[WebService(Namespace = "http://y790.somee.com")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class EvePing : System.Web.Services.WebService {

		/// <summary>
		/// Send a eve Ping
		/// </summary>
		/// <param name="token">Not required/ignored</param>
		/// <param name="team_id">Not required/ignored</param>
		/// <param name="channel_id">Not required/ignored</param>
		/// <param name="channel_name">Not required/ignored</param>
		/// <param name="user_id">slack user ID</param>
		/// <param name="user_name">Not required/ignored</param>
		/// <param name="command">Not required/ignored</param>
		/// <param name="text">Ping to send</param>
		/// <returns></returns>
		[WebMethod]
		public string SendPing(string token, string team_id, string channel_id, string channel_name, string user_id, string user_name, string command, string text) {
			return SlackEvePing.SendPing(user_id,text);
		}

		/// <summary>
		/// User Management if KeyID or vCode is omitted user will be removed
		/// </summary>
		/// <param name="slack_UserID">slack user ID</param>
		/// <param name="ping_KeyID">optional EvePingAPI KeyID</param>
		/// <param name="ping_vCode">optional EvePingAPI vCode</param>
		/// <returns></returns>
		[WebMethod]
		public string UpdateUserInfo(string slack_UserID, string ping_KeyID, string ping_vCode, string keytype) {
			return SlackEvePing.UpdateUserInfo(slack_UserID, ping_KeyID, ping_vCode, keytype);
		}



	}
}
