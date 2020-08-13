<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_HybridFlow.aspx.cs" Inherits="Hybrid_flow.WebForm_HybridFlow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
            height: 37px;
        }
        .auto-style2 {
            width: 30%;
            height: 37px;
        }
        .auto-style3 {
            width: 70%;
            height; 37px;
        }

        </style>

    <%-- Javascript function --%>
        <script type="text/javascript">
            function myFunction()
            {
                if (window.location.hash != "" )
                {
                    var _JSuri = window.location.hash;
                    document.getElementById("<%= Hidden1.ClientID %>").value = _JSuri;
                }
                else
                {
                    alert("Either you have the code and id_token stored or something went wrong!");
                }
            }
        </script>
    <%-- end --%>


</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h1>Insert the following variables:</h1>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Client ID:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Client Secret:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Redirect URI (http://localhost:'port'/WebForm_HybridFlow.aspx):</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">State:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nonce:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Scopes (separated by +):</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox6" value="openid+onlineid" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Response type ("code" + "id_token" for hybrid flow):</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox7" value="code%20id_token" runat="server" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Autorization Endpoint:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox8" value="https://identity.vismaonline.com/connect/authorize?" runat="server" OnTextChanged="TextBox8_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Token Endpoint:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox9" value="https://identity.vismaonline.com/connect/token" runat="server" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
                    </td>
                </tr>
            </table>

        <asp:Button ID="Login" runat="server" OnClick="Login_Click" Text="Login" style="height: 26px" />
        <br />
        <asp:HiddenField ID="Hidden1" runat="server" OnValueChanged="Hidden1_ValueChanged" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Retrieve variables" OnClientClick="myFunction()" OnClick="btnAuth_Click"  />
        <br />
        
            <table class="auto-style1">
            <tr>
                <td class="auto-style2">code : </td>
                <td class="auto-style3"><asp:Label ID="lblCd" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Access Token (retrieved from the Auth. code flow): </td>
                <td class="auto-style3"><asp:Label ID="lblAccTk" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">id_token (retrieved from the implicit flow): </td>
                <td class="auto-style3">
                    <asp:Label ID="lblTk" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">scope : </td>
                <td class="auto-style3">
                    <asp:Label ID="lblSc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">state : </td>
                <td class="auto-style3">
                    <asp:Label ID="lblSt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">session_state : </td>
                <td class="auto-style3">
                    <asp:Label ID="lblSeSt" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>
