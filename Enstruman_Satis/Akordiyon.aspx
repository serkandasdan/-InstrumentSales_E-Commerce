<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Akordiyon.aspx.cs" Inherits="Enstruman_Satis.Akordiyon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="sitiller/Anasayfa.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OrtakAlan" runat="server">

    <center>
        <br> <br>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EnstrumanSatisConnectionString %>" SelectCommand="SELECT [ID], [Fiyat], [Resim], [UrunAdi] FROM [Tbl_Akordiyon]"></asp:SqlDataSource>

         <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" Width="700px" Height="275px" DataKeyField="ID">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("Resim") %>' PostBackUrl='<%#"UrunDetay.aspx?P_ID="+Eval("ID")%>' />
                        <br />

                        <div id="product_name">
                            <asp:Label ID="UrunAdi" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Label>
                        </div>
                        <div id="price">

                            Fiyat : <asp:Label ID="Fiyat" runat="server" Text='<%# Eval("Fiyat") %>' /> TL
                          
                        </div>
                    </ItemTemplate>
                </asp:DataList>
           
        </center>

</asp:Content>
