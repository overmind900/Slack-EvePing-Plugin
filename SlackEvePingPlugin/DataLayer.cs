using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace SlackEvePingPlugin {
	internal static partial class DataLayer {

		internal static bool Find(string userId, out string keyId, out string vCode, out KeyType keyType) {
			if( string.IsNullOrWhiteSpace(userId) ) throw new ArgumentException("user_id cannot be empty");
			keyId = null;
			vCode = null;
			keyType = KeyType.Corporation;
			UserMapping user;
			using (SlackEvePingEntities ef = new SlackEvePingEntities()){
				user = ef.UserMappings.FirstOrDefault(x => x.UserID == userId.Trim());
				if( user != null ) {
					keyId = user.KeyID;
					vCode = user.vCode;
				}
			}
			return user != null;
		}

		internal static bool AddUpdate(string userId, string keyId, string vCode, KeyType keyType) {
			if(string.IsNullOrWhiteSpace(userId)) throw new ArgumentException("user_id cannot be empty");
			if( string.IsNullOrWhiteSpace(keyId) ) throw new ArgumentException("KeyID cannot be empty");
			if( string.IsNullOrWhiteSpace(vCode) ) throw new ArgumentException("vCode cannot be empty");
			using (SlackEvePingEntities ef = new SlackEvePingEntities()){
				UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == userId.Trim());
				if( user == null ) {
					user = new UserMapping {UserID = userId.Trim()};
					ef.UserMappings.AddObject(user);
				}
				user.KeyID = keyId.Trim();
				user.vCode = vCode.Trim();
				user.KeyType = keyType.ToString();
				ef.SaveChanges();
			}
			return true;
		}

		internal static bool Remove(string userId) {
			if( string.IsNullOrWhiteSpace(userId) ) throw new ArgumentException("user_id cannot be empty");
			bool success = false;
			using(SlackEvePingEntities ef = new SlackEvePingEntities()){
				UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == userId.Trim());
				if( user != null ) {
					ef.UserMappings.DeleteObject(user);
					ef.SaveChanges();
					success = true;
				}
			}
			return success;
		}

		internal static void Log(string message) {
			using(SlackEvePingEntities ef = new SlackEvePingEntities()){
				ef.Logs.AddObject( new Log { Message = message, DateTime = DateTime.UtcNow } );
				ef.SaveChanges();
			}
		}




	}
}
