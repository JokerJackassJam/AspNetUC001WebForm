using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UC0001WebForm {
    public partial class Detail : Page {
        public string Message;
        public Product prodotto;
        private IDomainModel model = new MockDomainModel();
        protected void Page_Load(object sender, EventArgs e) {
            prodotto = int.TryParse(Request["Codice"], out int code) ? model.SearchProductByCode(code) : null;
            if (prodotto == null) {
                Response.Redirect("~/Ricerca.aspx?Message='prodotto non trovato'");
            }
        }
        protected void Richiedi_Click(object sender, EventArgs e) {
            if (int.TryParse(qta.Text, out int quantitaRichiesta)) {
                List<Product> prodotti = (List<Product>)Session["listaRichieste"] ?? new List<Product>();
                var query = from prod in prodotti
                    where prod.Codice==prodotto.Codice
                    select prod;
                if(query.FirstOrDefault()!=null){
                    query.FirstOrDefault().QuantitaRichiesta=  query.FirstOrDefault().QuantitaRichiesta +  quantitaRichiesta;
                }else{
                    prodotto.QuantitaRichiesta=quantitaRichiesta;
                    prodotti.Add(prodotto);
                }
                Session["listaRichieste"]=prodotti;
                Response.Redirect("~/Ricerca.aspx?Message=Quantita aggiunta al carrello");
            } else {
                Message= "La quantità deve essere un valore numerico";
            }
        }
    }
    public partial interface IDomainModel {
        Product SearchProductByCode(int code);
        void AddQta(int ProductCode, int qta);
    }

    public class Product {
        public int Codice { get; set; }
        public string Descrizione { get; set; }
        public int Giacenza { get; set; }
        public int QuantitaRichiesta { get; set; }
    }

    public partial class MockDomainModel : IDomainModel {
        public void AddQta(int ProductCode, int qta) {
        }

        public Product SearchProductByCode(int code) {
            return new Product() {
                Codice = 1, Descrizione = "Staffa U", Giacenza = 500
            };
        }
    }

}