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
    public partial class Aulas : System.Web.UI.Page
    {
        Professor professor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Carregar();
            professor = (Professor)Session["ProfessorLogado"];
           
        }

        protected void listaGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

               Aula a = new Aula();
               a.idAula = int.Parse(listaGrid.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

              new AulaController().Excluir(a);
              Carregar();
        }


        #region Métodos

        public void Carregar()
        {
            List<Aula> aulas = new AulaController().Listar(new Aula());

            listaGrid.DataSource = aulas;

            listaGrid.DataBind();
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            profNome.Text = professor.Nome;
            TurmaController t = new TurmaController();
            foreach (Turma turma in t.Listar())
            {
                dropDownTurmas.Items.Add(turma.Nome);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //salvar dados
        }
    }
}
#endregion