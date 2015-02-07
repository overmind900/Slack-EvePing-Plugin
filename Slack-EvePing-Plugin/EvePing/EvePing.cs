using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slack_EvePing_Plugin.EvePing {
	class EvePing {

		private string m_KeyID;
		private string m_vCode;

		public string KeyID {
			get { return m_KeyID; }
			set { m_KeyID = value; }
		}

		public string vCode {
			get { return m_vCode; }
			set { m_vCode = value; }
		}

		public EvePing() {
			
		}

	}
}
