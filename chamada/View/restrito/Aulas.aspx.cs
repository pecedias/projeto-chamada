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
        public Professor professor;
        public string nomeTurma = "";
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
                        action.Value = "update";
                        int id = int.Parse(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        idAula.Value = id.ToString();
                        profNome.Text = listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        ListItem lst = new ListItem(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text, listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text);
                        dropDownTurmas.Items.Add(lst);
                        txtNome.Text = listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text;                   
                        
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //salvar dados
            //int idTurma = int.Parse(dropDownTurmas.SelectedValue.ToString());
            //int idProfessor = professor.idProfessor;

            if (action.Value == "insert")
                Incluir();
            else
                Alterar();

        }


        #region Métodos

        public void Carregar()
        {
            List<Aula> aulas = new AulaController().Listar(new Aula());

            listaGridAulas.DataSource = aulas;

            listaGridAulas.DataBind();
            listaGridAulas.Columns[4].Visible = false;
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            profNome.Text = professor.Nome;
            TurmaController t = new TurmaController();
            foreach (Turma turma in t.Listar(new Turma()))
            {
                ListItem lst = new ListItem(turma.Nome, turma.idTurma.ToString());
                dropDownTurmas.Items.Add(lst);
            }
            action.Value = "insert";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);
        }

        public void Incluir()
        {
            try
            {

                Aula aula = new Aula();
                Turma turma = new Turma();

                aula.Nome = txtNome.Text;

                turma.idTurma = Convert.ToInt32(dropDownTurmas.SelectedItem.Value);

                aula.idTurma = turma;
                aula.idProfessor = professor;

                new AulaController().Incluir(aula);

                Response.Redirect("../restrito/Aulas.aspx");

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

                Aula aula = new Aula();

                Turma turma = new Turma();

                aula.idAula = Convert.ToInt32(idAula.Value);
                aula.Nome = txtNome.Text;
                aula.idProfessor = professor;

                turma.idTurma = Convert.ToInt32(dropDownTurmas.SelectedItem.Value);

                aula.idTurma = turma;

                new AulaController().Atualizar(aula);

                Response.Redirect("../restrito/Aulas.aspx");

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