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

        protected void listaGridAulas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "alterar":
                    {

                        int id = int.Parse(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        txtNome.Text = listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);

                    }
                    break;

                case "excluir":
                    {

                        Aula aula = new Aula();
                        aula.idAula = int.Parse(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        new AulaController().Excluir(aula);
                        Carregar();

                    }
                    break;
            }
            Carregar();
        }


        #region Métodos

        public void Carregar()
        {
            List<Aula> aulas = new AulaController().Listar(new Aula());

            listaGridAulas.DataSource = aulas;

            listaGridAulas.DataBind();
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            profNome.Text = professor.Nome;
            TurmaController t = new TurmaController();
           // foreach (Turma turma in t.Listar())
           // {
            //    dropDownTurmas.Items.Add(turma.Nome);
          //  }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //salvar dados
        }
    }
}
#endregion