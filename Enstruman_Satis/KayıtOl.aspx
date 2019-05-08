<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="KayıtOl.aspx.cs" Inherits="Enstruman_Satis.KayıtOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kayıt Ol</title>
    <style type="text/css">
        body{
            background-color :white;
            font-family:Arial;
            font-weight:bold;

        }
        .auto-style1 {
            background-color :beige;
            width: 40%;
            height: 306px;
           border:solid 1px;
            padding-left:5px;
            padding-top:15px;
          
        }
        .auto-style3 {
            width: 353px;
            padding-left:0px;
        }
          
        .auto-style5 {
            margin-bottom: 0px;
            margin-left:325px;
        }
        .auto-style8 {
            width: 359px;
            height: 63px;
            padding-left:5px;
        }
        .auto-style9 {
            height: 63px;
            width: 353px;
        }
  
        .auto-style10 {
            width: 250px;

            padding-left: 5px;

        }
  
        .auto-style12 {
            width: 353px;
            padding-left: 0px;
            height: 43px;
        }
        .auto-style13 {
            margin-left: 0px;
        }
  
        .auto-style14 {
            width: 353px;
        }
        .auto-style16 {
            width: 353px;
            height: 48px;
        }
  
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">
    <body >
    <center>
    <div>
        <br> <br><br><br>
        <table class="auto-style1">
            
            <tr>
                <td class="auto-style10">Adı </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtAdi" runat="server" TabIndex="1" Width="160px" Height="24px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Soyadı&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtSoyadi" runat="server" TabIndex="2" Width="160px" Height="24px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Cinsiyet</td>
                <td class="auto-style14">
                    <asp:DropDownList ID="ddl_Cinsiyet" runat="server" TabIndex="3" Height="32px" Width="95px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Erkek</asp:ListItem>
                        <asp:ListItem>Kadın</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Doğum Tarihi</td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtDogumTarihi" runat="server" TabIndex="4" Width="138px" Height="24px" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Cep Telefon</td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtCepNo" runat="server" TabIndex="5" Width="120px" Height="24px" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Adres</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtAdres" runat="server" Width="260px" TabIndex="6" Height="40px" MaxLength="100" Rows="2" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">E-Posta</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEposta" runat="server" TabIndex="7" Width="160px" Height="24px" CssClass="auto-style13" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Şifre</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtSifre" runat="server" TabIndex="8" Width="130px" Height="24px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Şifre (Tekrar)</td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtSifreTekrar" runat="server" TabIndex="9" Width="130px" Height="24px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style9">
                &nbsp;<asp:Label ID="lblMesaj" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
                 <asp:Button ID="btnKayit" runat="server" Height="40px" Align="Center" Text="Kayıt Ol" Width="110px" OnClick="btnKayit_Click" TabIndex="10" CssClass="auto-style5" BackColor="#A20319" ForeColor="White"   />

   
                </td>
            </tr>
   
        </table>
   
    </div>
 
        </center>
 
</body>
</asp:Content>
