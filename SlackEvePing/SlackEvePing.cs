using System;
using System.Configuration;
using SlackEvePingPlugin;

namespace SlackEvePingWebservice {
	internal static class SlackEvePing {
		internal static string SendPing( string userId, string text ) {
			string returnMessage;
			if( !string.IsNullOrWhiteSpace( text ) ) { //no text no ping
				try {
					// Find the user who send the ping
					string vCode, keyId;
					KeyType keyType;
					if( DataLayer.Find( userId, out keyId, out vCode, out keyType ) ) {
						//send ping
#if DEBUG
						returnMessage = string.Format(
										 "200: Success(DEBUG) - slack_id: {0}, ping_keyID: {1}, ping_vCode: {2}, ping_type: {3}, message: {4}",
										userId, keyId, vCode, keyType, text );
#elif !DEBUG
						SlackEvePingPlugin.EvePing.SendPing(keyType, keyId, vCode, text); 
						returnMessage = "Success - message sent";
#endif
						DataLayer.Log( string.Format( "{0} send ping \"{1}\"", userId, text ) );
					} else {
						//User not found
						returnMessage = "404: Not Found - Your user id was not found, your slack user id is " + userId + " Register at " +
										ConfigurationManager.AppSettings["Site"];
						DataLayer.Log( returnMessage );
					}
				} catch( ArgumentException ae ) {
					// bad parameters
					returnMessage = "400: Bad Request - " + ae.Message;
					DataLayer.Log( ae.ToString() );
				} catch( Exception ex ) {
					// unknown server error
#if DEBUG
					returnMessage = "500: Server Error - " + ex;
#elif !DUBUG
					returnMessage = "500: Server Error - Contact Admin. Error Logged at" + DateTime.UtcNow;
#endif
					DataLayer.Log( ex.ToString() );
				}
			} else {
				returnMessage = "400: Bad Request - no message to send, your slack user id is " + userId;
			}
			return returnMessage;
		}

		internal static string UpdateUserInfo( string slackUserId, string pingKeyId, string pingVCode, string keytype ) {
			if( string.IsNullOrWhiteSpace( slackUserId ) ) return "Please provide Slack ID";
			string returnMessage;
			try {
				KeyType keyTypeEnum = !string.IsNullOrWhiteSpace( keytype )
					? (KeyType) Enum.Parse( typeof( KeyType ), keytype, true ) : KeyType.Corporation;
				if( !string.IsNullOrWhiteSpace( pingKeyId ) &&
					!string.IsNullOrWhiteSpace( pingVCode ) ) {
					// add new user or update existing user
					if( DataLayer.AddUpdate( slackUserId, pingKeyId, pingVCode, keyTypeEnum ) ) {
						returnMessage = "201: Success - User " + slackUserId + " Added/Updated";
					} else {
						// will likely throw exception before getting here but just in case
						returnMessage = "User " + slackUserId + " failed to add";
						DataLayer.Log(
									 string.Format(
												 "Failed to update the database no error thrown: slack_UserID: {0}, ping_KeyID: {1}, ping_vCode{2}",
												slackUserId, pingKeyId, pingVCode ) );
					}
				} else {
					//didn't provide KeyID and vCode, delete user.
					if( DataLayer.Remove( slackUserId ) ) {
						returnMessage = "200: Success - User " + slackUserId + " removed";
					} else {
						returnMessage = "404: Not Found - User " + slackUserId + " not found";
					}
				}
			} catch( ArgumentException ae ) {
				// bad parameters
				returnMessage = "400: Bad Request - " + ae.Message;
			} catch( Exception ex ) {
				// unknown server error
#if DEBUG
				returnMessage = "500: Server Error - " + ex;
#elif !DUBUG
				returnMessage = "500: Server Error - Contact Admin. Error Logged at" + DateTime.UtcNow.ToString();
#endif
				DataLayer.Log( ex.ToString() );
			}
			return returnMessage;
		}
	}
}