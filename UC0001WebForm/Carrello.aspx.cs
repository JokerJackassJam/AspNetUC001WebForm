using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UC0001WebForm {
    public partial class Carrello : Page {
        public string Message{get; set;}
        public List<Product> prodotti{get; set;}

        protected void Page_Load(object sender, EventArgs e) {
            prodotti = (List<Product>)Session["listaRichieste"] ?? null;
            Message = prodotti==null?"Nessun prodotto tra le richieste di ordine":null;
        }
        protected void Invia_Click(object sender, EventArgs e) {
            IDomainModel model = new MockDomainModel();
            foreach(Product p in prodotti){
                model.AddQta(p.Codice,p.QuantitaRichiesta);
            }
            Session["listaRichieste"]=null;
            Response.Redirect("~/Ricerca.aspx?Message=Richiesta di ordine salavata");
        }
    }
}