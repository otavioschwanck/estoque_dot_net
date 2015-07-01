<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acesso.aspx.cs" Inherits="EstoqueDotNet.Acesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<%--<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="Login1_Authenticate">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </form>
</body>--%>


    <body>
    <form id="form1" runat="server" >
    <div style="width: 178px" >
    
    		<asp:Label ID="lblUser" runat="server" Text="User: "></asp:Label>
						<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
						<br />
						<asp:Label ID="lblPass" runat="server" Text="Pass: "></asp:Label>
						<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
						<br />
						<asp:Label ID="lblStatus" runat="server" Text="Status"
                            
                            
                            ></asp:Label>
						<br />
						<asp:Button ID="btnLogin" runat="server" Text="Login" 
								onclick="btnLogin_Click" />
    
    </div>
    </form>
</body>


</html>
