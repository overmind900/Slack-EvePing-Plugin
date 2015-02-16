using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlackEvePingWebservice {
	public partial class index : System.Web.UI.Page {
		
		protected void ButtonUpdate_Click(object sender, EventArgs e) {
			try {
				LableResults.Text = SlackEvePing.UpdateUserInfo(TextBoxSlackID.Text, TextBoxPingKeyID.Text, TextBoxPingvCode.Text, DropDownKeyType.Text);
			} catch( Exception ) {
				
			}
		}
	}
}