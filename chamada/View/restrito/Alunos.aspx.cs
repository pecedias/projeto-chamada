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
                        btnSalvar.Visible = true;
                        btnIncluir.Visible = false;
                        CarregarCombo();

                        txtAluno.Text = listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                        txtMatricula.Text = listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;
                        ListItem txt = dropDownTurmas.Items.FindByText(listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);
                        txt.Selected = true;
                        txtNomeAluno.Text = listaGridAlunos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
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

        public void CarregarCombo()
        {
            dropDownTurmas.Items.Clear();
            List<Turma> lst = new TurmaController().Listar(new Turma());

            foreach (Turma item in lst)
            {
                dropDownTurmas.Items.Add(new ListItem(item.Nome, item.idTurma.ToString()));
            }
        }

        public void Carregar()
        {
            List<Aluno> alunos = new AlunoController().Listar(new Aluno());

            listaGridAlunos.DataSource = alunos;

            listaGridAlunos.DataBind();
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            btnSalvar.Visible = false;
            btnIncluir.Visible = true;
            CarregarCombo();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtNomeAluno.Text) && !String.IsNullOrEmpty(txtMatricula.Text))
            {
                if (txtMatricula.Text.Length <= 10)
                {
                    Incluir();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>alert('A matricula deve conter apenas 10 numeros');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>alert('Preencha Todos os Campos');</script>", false);
            }
           
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNomeAluno.Text) && !String.IsNullOrEmpty(txtMatricula.Text))
            {
                if(txtMatricula.Text.Length <= 10)
                {
                    Alterar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>alert('A matricula deve conter apenas 10 numeros');</script>", false);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>alert('Preencha Todos os Campos');</script>", false);
            }
        }

        public void Incluir()
        {
            try
            {

                Aluno aluno = new Aluno();
                Turma turma = new Turma();

                aluno.Nome = txtNomeAluno.Text;
                aluno.Matricula = int.Parse(txtMatricula.Text);

                turma.idTurma = int.Parse(dropDownTurmas.SelectedValue);

                aluno.idTurma = turma;

                new AlunoController().Incluir(aluno);

                Response.Redirect("Alunos.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }
        }

        public void Alterar()
        {

            try
            {

                Aluno aluno = new Aluno();
                Turma turma = new Turma();

                aluno.idAluno = int.Parse(txtAluno.Text);
                aluno.Nome = txtNomeAluno.Text;
                aluno.Matricula = int.Parse(txtMatricula.Text);

                turma.idTurma = int.Parse(dropDownTurmas.SelectedValue);

                aluno.idTurma = turma;

                new AlunoController().Atualizar(aluno);

                Response.Redirect("Alunos.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        private void ExibirMensagemAlert(string mensagem)
        {
            throw new NotImplementedException();
        }
    }
}
#endregion