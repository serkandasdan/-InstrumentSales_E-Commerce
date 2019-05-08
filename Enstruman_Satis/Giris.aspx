<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="Enstruman_Satis.Giris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Oturum Aç</title>
    <style type="text/css">
          body{
            background-color :white;
            font-family:Arial;
            font-weight:bold;


        }
        .auto-style1 {
            width: 52%;
            background-color:beige;
            border:solid 1px;
            padding-top:15px;

        }
        .auto-style6 {
            width: 172px;
            padding-top: 20px;
            height: 32px;
            padding-left:15px;

        }
        .auto-style7 {
            height: 32px;
             padding-top: 20px;
             padding-right:15px;
        }
        .auto-style4 {
            height: 23px;
            width: 172px;
            padding-top:10px;
             padding-left: 15px;
        }
        .auto-style2 {
            height: 23px;
            padding-top:10px;
            padding-bottom:5px;
            padding-right:15px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">

    <body>
    <center>
         <br> <br><br><br> <br> <br>
    <div>

    
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">E-Posta</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEposta" runat="server" TabIndex="1" Width="200px" Height="24px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Şifre</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtSifre" runat="server" TabIndex="2" Width="200px" Height="22px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
                    <asp:Button ID="btnOturumAc" runat="server" BackColor="#A20319" Font-Bold="True" ForeColor="White" Height="39px" Text="Oturum Aç" TabIndex="3" Width="123px" OnClick="btnOturumAc_Click" />
                </td>
            </tr>
            <br>
        </table>
    
    </div>
        </center>
   
</body>

</asp:Content>
