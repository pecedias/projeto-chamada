using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito
{
    public partial class Chamada : System.Web.UI.Page
    {
        public int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CarregarCombo();
                Carregar(id);
        }

        protected void btnChamada_Click(object sender, EventArgs e)
        {
            var idx = int.Parse(dropDownChamadas.SelectedValue);
            Carregar(idx);
        }

        public void CarregarCombo()
        {
            dropDownChamadas.Items.Clear();
            List<Aula> lst = new AulaController().Listar(new Aula());

            foreach (Aula item in lst)
            {
                dropDownChamadas.Items.Add(new ListItem(item.Nome, item.idAula.ToString()));
            }
        }

        public void Carregar(int idx)
        {
            Model.Chamada m = new Model.Chamada();
            Model.Aula a = new Model.Aula();
            a.idAula = idx;
            m.idAula = a;

            List<Model.Chamada> presenca = new ChamadaController().ListarPresenca(m);

            listaGridChamadaPresenca.DataSource = presenca;

            listaGridChamadaPresenca.DataBind();

            List<Model.Chamada> faltas = new ChamadaController().ListarFalta(m);

            listaGridChamadaFaltas.DataSource = faltas;

            listaGridChamadaFaltas.DataBind();
        }
    }
}
