<%@ Page
    Title="Ricerca Prodotti"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Ricerca.aspx.cs"
    Inherits="UC0001WebForm.RicercaProdotto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="text-warning">
        <%=Message %>
    </div>
    <div class="form-group">
        <asp:Label runat="server">Codice</asp:Label>
        <asp:TextBox class="form-control" placeholder="Codice" runat="server" ID="Codice"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server">Descrizione</asp:Label>
        <asp:TextBox class="form-control" placeholder="descrizione anche parziale" runat="server" ID="Descrizione"></asp:TextBox>
    </div>
    <asp:Button runat="server" OnClick="Cerca_Click" class="btn btn-primary" Text="CERCA" />

    <div class="table" style="margin-top:25px">
        <asp:Table ID="Table1" runat="server" width="100%"
            CellPadding="10"
            GridLines="None"
            HorizontalAlign="Center">
        </asp:Table>
    </div>
    
</asp:Content>
