﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace SlackEvePingPlugin {
	internal static partial class DataLayer {

		internal static bool Find(string user_id, out string keyID, out string vCode) {
			if( string.IsNullOrWhiteSpace(user_id) ) throw new ArgumentException("user_id cannot be empty");
			keyID = null;
			vCode = null;
			SlackEvePingEntities ef = new SlackEvePingEntities();
			UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == user_id.Trim());
			if( user != null ) {
				keyID = user.KeyID;
				vCode = user.vCode;
			}
			return user != null;
		}

		internal static bool AddUpdate(string user_id, string keyID, string vCode) {
			if(string.IsNullOrWhiteSpace(user_id)) throw new ArgumentException("user_id cannot be empty");
			if( string.IsNullOrWhiteSpace(keyID) ) throw new ArgumentException("KeyID cannot be empty");
			if( string.IsNullOrWhiteSpace(vCode) ) throw new ArgumentException("vCode cannot be empty");
			SlackEvePingEntities ef = new SlackEvePingEntities();
			UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == user_id.Trim());
			if( user == null ) {
				user = new UserMapping();
				user.UserID = user_id.Trim();
				ef.UserMappings.AddObject(user);
			}
			user.KeyID = keyID.Trim();
			user.vCode = vCode.Trim();
			user.LastPing = DateTime.UtcNow;
			ef.SaveChanges();
			return true;
		}

		internal static bool Remove(string user_id) {
			if( string.IsNullOrWhiteSpace(user_id) ) throw new ArgumentException("user_id cannot be empty");
			bool success = false;
			SlackEvePingEntities ef = new SlackEvePingEntities();
			UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == user_id.Trim());
			if( user != null ) {
				ef.UserMappings.DeleteObject(user);
				ef.SaveChanges();
				success = true;
			}
			return success;
		}

		internal static void Log(string message) {
			SlackEvePingEntities ef = new SlackEvePingEntities();
			SlackEvePingPlugin.Log logMessage = new SlackEvePingPlugin.Log();
			logMessage.Message = message;
			logMessage.DateTime = DateTime.UtcNow;
			ef.Logs.AddObject(logMessage);
		}




	}
}
