using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace SlackEvePingPlugin {
	internal static partial class DataLayer {

		static DataLayer() {
			using( SlackEvePingEntities ef = new SlackEvePingEntities() ) {
				DbCommand dbc= ef.Connection.CreateCommand();
				dbc.CommandText = UserMappingSQL;
				dbc.ExecuteNonQuery();
			}
		}


		internal static bool Find(string user_id, out string keyID, out string vCode) {
			bool success = false;
			keyID = null;
			vCode = null;

			using( SlackEvePingEntities ef = new SlackEvePingEntities() ) {
				UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == user_id);
				if( user != null ) {
					keyID = user.KeyID;
					vCode = user.vCode;
					success = true;
				}
			}

			return success;
		}

		internal static bool AddUpdate(string user_id, string keyID, string vCode) {
			bool success = false;

			using( SlackEvePingEntities ef = new SlackEvePingEntities() ) {
				UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == user_id);
				if( user == null ) {
					user = new UserMapping();
					user.UserID = user_id;
					ef.UserMappings.AddObject(user);
				}
				keyID = user.KeyID;
				vCode = user.vCode;
				ef.SaveChanges();
				success = true;
			}

			return success;
		}

		internal static bool Remove(string user_id) {
			bool success = false;
			using( SlackEvePingEntities ef = new SlackEvePingEntities() ) {
				UserMapping user = ef.UserMappings.FirstOrDefault(x => x.UserID == user_id);
				if( user != null ) {
					ef.UserMappings.DeleteObject(user);
					ef.SaveChanges();
					success = true;
				}
			}
			return success;
		}


	}
}
