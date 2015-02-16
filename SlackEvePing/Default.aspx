<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SlackEvePingWebservice.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body background="image/bg.jpg">
	<center>
		<div>
			<div>
				<img src="image/SlackMessage1.png" />
				<br />
				<img src="image/eveping_api_1.png" />
				<br />
				<img src="image/eveping_api_2.png" />
				<br />
				<img src="image/eveping_api_3.png" />
			</div>
			<asp:Panel ID="Panel1" runat="server" BackColor="#333333" Style="width: 25%">
				<form id="form1" runat="server">
				<div>
					<asp:Label ID="Label1" runat="server" Text="Slack User ID: " Font-Bold="True" Font-Size="Medium"
						ForeColor="White"></asp:Label><asp:TextBox ID="TextBoxSlackID" runat="server"></asp:TextBox>
					<br />
					<asp:Label ID="Label4" runat="server" Text="Key Type" Font-Bold="True" Font-Size="Medium"
						ForeColor="White"></asp:Label><asp:DropDownList ID="DropDownKeyType" runat="server">
							<asp:ListItem Text="Alliance" Value="Alliance" />
							<asp:ListItem Text="Corporation" Value="Corporation" />
						</asp:DropDownList>
					<br />
					<asp:Label ID="Label2" runat="server" Text="EvePing KeyID" Font-Bold="True" Font-Size="Medium"
						ForeColor="White"></asp:Label><asp:TextBox ID="TextBoxPingKeyID" runat="server"></asp:TextBox>
					<br />
					<asp:Label ID="Label3" runat="server" Text="EvePing vCode" Font-Bold="True" Font-Size="Medium"
						ForeColor="White"></asp:Label><asp:TextBox ID="TextBoxPingvCode" runat="server"></asp:TextBox>
					<br />
					<asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
					<br />
					<asp:Label ID="LableResults" runat="server" Text="" Font-Bold="True" Font-Size="Medium"
						ForeColor="White" />
				</div>
				</form>
			</asp:Panel>
		</div>
	</center>
</body>
</html>
