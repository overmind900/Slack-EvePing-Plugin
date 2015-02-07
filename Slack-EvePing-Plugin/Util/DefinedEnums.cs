using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slack_EvePing_Plugin.Util {

	[Flags]
	public enum WarnLevel { OFF = 0, ERROR, WARN, INFO, DEBUG, TRACE };
		
}
