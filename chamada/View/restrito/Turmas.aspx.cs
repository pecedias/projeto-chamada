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
    public partial class Turmas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Carregar();

        }

        protected void listaGridTurmas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "alterar":
                    {

                        int id = int.Parse(listaGridTurmas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        txtNome.Text = listaGridTurmas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);

                    }
                    break;

                case "excluir":
                    {

                        Turma turma = new Turma();
                        turma.idTurma = int.Parse(listaGridTurmas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        new TurmaController().Excluir(turma);
                        Carregar();

                    }
                    break;
            }
        }


        #region Métodos

        public void Carregar()
        {
            List<Turma> turmas = new TurmaController().Listar(new Turma());

            listaGridTurmas.DataSource = turmas;

            listaGridTurmas.DataBind();
        }
    }
}
#endregion