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

        protected void listaGridAlunos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "alterar":
                    {

                        int id = int.Parse(listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        txtNome.Text = listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);

                    }
                    break;

                case "excluir":
                    {

                        Aluno aluno = new Aluno();
                        aluno.idAluno = int.Parse(listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        new AlunoController().Excluir(aluno);
                        Carregar();

                    }
                    break;
            }
        }


        #region Métodos

        public void Carregar()
        {
            List<Aluno> alunos = new AlunoController().Listar(new Aluno());

            listaGridAlunos.DataSource = alunos;

            listaGridAlunos.DataBind();
        }
    }
}
#endregion