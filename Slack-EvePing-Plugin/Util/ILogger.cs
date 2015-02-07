using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slack_EvePing_Plugin.Util {
	public interface ILogger {

		void Log(string message);
		void Log(WarnLevel level, string message);
		bool Close();
	}
}
