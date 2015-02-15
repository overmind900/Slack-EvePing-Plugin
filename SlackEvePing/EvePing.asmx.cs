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
			string returnMessage= string.Empty;
			if( !string.IsNullOrWhiteSpace(text) ) { //no text no ping
				try {
					// Find the user who send the ping
					string vCode, keyID = null;
					KeyType keyType = KeyType.Corporation;
					if( DataLayer.Find(user_id, out keyID, out vCode, out keyType) ) { 
						//send ping
#if DEBUG
						return string.Format("200: Success(DEBUG) - slack_id: {0}, ping_keyID: {1}, ping_vCode: {2}, ping_type: {3}, message: {4}", user_id, keyID, vCode, keyType.ToString(), text);
#elif !DEBUG
						SlackEvePingPlugin.EvePing.SendPing(keyType, keyID, vCode, text); 
						returnMessage = "200: Success - message sent";
#endif
					} else {
						//User not found
						returnMessage = "404: Not Found - Your user id was not found, your slack user id is " + user_id + " Register at http://y790.somee.com";
					}
				} catch( ArgumentException ae ) {
					// bad parameters
					returnMessage = "400: Bad Request - " + ae.Message;
				} catch( Exception ex ) {
					// unknown server error
#if DEBUG
					returnMessage = "500: Server Error - " + ex.ToString();
#elif !DUBUG
					returnMessage = "500: Server Error - Contact Admin. Error Logged at" + DateTime.UtcNow.ToString();
					DataLayer.Log(ex.ToString());
#endif
				}
			} else {
				returnMessage = "400: Bad Request - no message to send";
			}
			return returnMessage;
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
			if(string.IsNullOrWhiteSpace(slack_UserID)) return "Please provide Slack ID";
			string returnMessage = string.Empty;
			try {
				KeyType KeyTypeEnum = !string.IsNullOrWhiteSpace(keytype) ? (KeyType)Enum.Parse(typeof(KeyType), keytype, true) : KeyType.Corporation;
				if( !string.IsNullOrWhiteSpace(ping_KeyID) && !string.IsNullOrWhiteSpace(ping_vCode) ) {
					// add new user or update existing user
					if( DataLayer.AddUpdate(slack_UserID, ping_KeyID, ping_vCode, KeyTypeEnum) ) {
						returnMessage = "201: Success - User " + slack_UserID + " Added/Updated";
					} else {
						// will likely throw exception before getting here but just in case
						returnMessage = "User " + slack_UserID + " failed to add";
						DataLayer.Log(string.Format("Failed to update the database no error thrown: slack_UserID: {0}, ping_KeyID: {1}, ping_vCode{2}", slack_UserID, ping_KeyID, ping_vCode));
					}
				} else {
					//didn't provide KeyID and vCode, delete user.
					if( DataLayer.Remove(slack_UserID) ) {
						returnMessage = "200: Success - User " + slack_UserID + " removed";
					} else {
						returnMessage = "404: Not Found - User " + slack_UserID + " not found";
					}
				}
			} catch( ArgumentException ae) {
				// bad parameters
				returnMessage = "400: Bad Request - " + ae.Message;
			} catch( Exception ex ) {
				// unknown server error
#if DEBUG
				returnMessage = "500: Server Error - " + ex.ToString();
#elif !DUBUG
				returnMessage = "500: Server Error - Contact Admin. Error Logged at" + DateTime.UtcNow.ToString();
				DataLayer.Log(ex.ToString());
#endif
			}
			return returnMessage;
		}



	}
}
