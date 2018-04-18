<%@ Page
    Title="Dettaglio Prodotto"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs"
    Inherits="UC0001WebForm.Detail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="text-warning">
        <%=Message %>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server">Codice Prodotto </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"><%=prodotto.Codice %></asp:Label>
    </div>

    <div class="col-sm-4">
        <asp:Label runat="server">Descrizione Prodotto </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"><%=prodotto.Descrizione %></asp:Label>
    </div>

    <div class="col-sm-4">
        <asp:Label runat="server">Giacenza </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server"><%=prodotto.Giacenza %></asp:Label>
    </div>

    <div class="col-sm-4">
        <asp:Label runat="server">Quantita da richiedere</asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:Label runat="server">
            <asp:TextBox ID="qta" runat="server"></asp:TextBox>
        </asp:Label>
    </div>
    <asp:Button runat="server" OnClick="Richiedi_Click" class="btn btn-primary" Text="RICHIEDI ORDINE" />
    <asp:Button runat="server" PostBackUrl="~/Ricerca.aspx" class="btn btn-default" Text="ANNULLA" />
</asp:Content>
