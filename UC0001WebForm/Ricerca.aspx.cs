using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UC0001WebForm {
    public partial class RicercaProdotto : Page {
        public List<Product> Prodotti { get; set; }
        public string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            Message = Request["Message"] ?? null;
        }

        protected void CiccioPasticcio(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(Codice.Text)) {
                Response.Redirect($"~/Detail.aspx?codice={Codice.Text}");
            } else if (!String.IsNullOrEmpty(Descrizione.Text)) {
                IDomainModel model = new MockDomainModel();
                Prodotti = model.SearchByDescription(Descrizione.Text) ?? null;
                foreach (Product p in Prodotti) {
                    TableRow tr = new TableRow();
                    TableCell tdCodice = new TableCell();
                    tdCodice.Controls.Add(new Label() { Text = p.Codice.ToString(),CssClass="col-xs-2" });
                    tr.Cells.Add(tdCodice);
                    TableCell tdDescrizione = new TableCell();
                    tdDescrizione.Controls.Add(new Label() { Text = p.Descrizione ,CssClass="col-xs-6" });
                    tr.Cells.Add(tdDescrizione);
                    TableCell tdGiacenza = new TableCell();
                    tdGiacenza.Controls.Add(new Label() { Text = p.Giacenza.ToString(),CssClass="col-xs-2" });
                    tr.Cells.Add(tdGiacenza);
                    TableCell tdButton = new TableCell();
                    tdButton.Controls.Add(new Button() { Text = "detail", PostBackUrl = $"Detail?codice={p.Codice}" ,CssClass="col-xs-2"});
                    tr.Cells.Add(tdButton);
                    Table1.Rows.Add(tr);
                }
            }
        }
    }
    public partial interface IDomainModel {
        List<Product> SearchByDescription(string description);
    }
    public partial class MockDomainModel : IDomainModel {
        public List<Product> SearchByDescription(string description) {
            return new List<Product>(){
                new Product(){Codice=1,Descrizione="Staffa U",Giacenza=500},
                new Product(){Codice=2,Descrizione="Staffa I",Giacenza=10250},
                new Product(){Codice=3,Descrizione="Staffa L",Giacenza=675}
            };
        }
    }
}