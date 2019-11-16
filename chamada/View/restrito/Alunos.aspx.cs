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
    public partial class Alunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Carregar();

        }

        protected void listaGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "alterar":
                    {

                        int id = int.Parse(listaGrid.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        txtNome.Text = listaGrid.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);

                    }
                    break;

                case "excluir":
                    {

                        Aula a = new Aula();
                        a.idAula = int.Parse(listaGrid.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        new AulaController().Excluir(a);
                        Carregar();

                    }
                    break;
            }
        }


        #region Métodos

        public void Carregar()
        {
            List<Aula> aulas = new AulaController().Listar(new Aula());

            listaGrid.DataSource = aulas;

            listaGrid.DataBind();
        }
    }
}
#endregion