<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="İletisim.aspx.cs" Inherits="Enstruman_Satis.İletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            padding-left:70px;
        }
        .cerceve{
            border:1px solid;
            height:350px;
            width:500px;
           
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <br><br><br>
    <center>
        <div class="cerceve">
    <table class="auto-style1">
        <tr>
            <td>Adı Soyadı</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtAdSoyad" runat="server" TabIndex="1"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Mail Adresiniz</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtMail" runat="server" Width="164px" TabIndex="2"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Mesajınız</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtMesaj" runat="server" Height="130px" TextMode="MultiLine" Width="360px" TabIndex="3"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnGonder" runat="server" Text="Gönder" OnClick="btnGonder_Click" TabIndex="4" />
&nbsp;&nbsp;
                <asp:Label ID="lblBilgi" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
            </div>
        </center>
</asp:Content>
