<%@ Page 
    Title="Conferma Invio Richiesta" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Carrello.aspx.cs" 
    Inherits="UC0001WebForm.Carrello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="text-warning">
        <%=Message %>
    </div>
    <%if(prodotti!=null){
      foreach(var p in prodotti){ %>        
        <div class="col-sm-4">
            <%=p.Codice%>
        </div>
        <div class="col-sm-4">
            <%=p.Descrizione%>
        </div>
        <div class="col-sm-4">
            <%=p.QuantitaRichiesta%>
        </div>
    <%}} %>
    <asp:Button runat="server" OnClick="Invia_Click" class="btn btn-primary" Text="INVIA RICHIESTA" /> 
</asp:Content>
