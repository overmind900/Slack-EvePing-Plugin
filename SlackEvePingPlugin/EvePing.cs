using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SlackEvePingPlugin {
	public enum KeyType { Alliance, Corporation }

	internal class EvePing {

		internal const string EvePingUrlFormat = @"https://www.eveping.com/api/sendmessage?keyid={0}&vcode={1}&type={2}&message={3}";
	
		internal string SendPing(KeyType keyType,string keyID, string vCode, string message) {
			if( string.IsNullOrWhiteSpace(keyID) ) throw new ArgumentException("keyID Cannot be Null, Empty, or White Space");
			if( string.IsNullOrWhiteSpace(vCode) ) throw new ArgumentException("vCode Cannot be Null, Empty, or White Space");
			if( string.IsNullOrWhiteSpace(message) ) throw new ArgumentException("message Cannot be Null, Empty, or White Space");

			// Set up the ping
			WebRequest ping = WebRequest.Create(string.Format(EvePingUrlFormat, keyID, vCode,keyType.ToString(),message));
			ping.Method = "GET";

			// Get the original response.
			WebResponse response = ping.GetResponse();
			Stream dataStream = response.GetResponseStream();

			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader(dataStream);

			// Read the content fully up to the end.
			string responseFromServer = reader.ReadToEnd();

			// Clean up the streams.
			reader.Close();
			dataStream.Close();
			response.Close();

			return responseFromServer;
			
		}
	}
}
