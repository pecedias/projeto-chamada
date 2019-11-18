﻿using Controller;
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
                        ListItem item = new ListItem(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text, listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
                        CarregarCombo();
                        int id = int.Parse(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        profNome.Text = listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        dropDownTurmas.Items.Add(listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
                        //dropDownTurmas.SelectedValue = item.Value;
                        //dropDownTurmas.Text = listaGridAulas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;
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

        public void CarregarCombo()
        {
            dropDownTurmas.Items.Clear();
            List<Turma> lst = new TurmaController().Listar(new Turma());

            foreach (Turma item in lst)
            {
                dropDownTurmas.Items.Add(new ListItem(item.Nome, item.idTurma.ToString()));
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["itemSel"] == null)
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
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            profNome.Text = professor.Nome;

            CarregarCombo();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);
        }

        public void Incluir()
        {
            try
            {

                Aula aula = new Aula();
                Turma turma = new Turma();

                aula.Nome = txtNome.Text;

                turma.idTurma = int.Parse(dropDownTurmas.SelectedValue);

                aula.idTurma = turma;
                aula.idProfessor = professor;

                new AulaController().Incluir(aula);

                Response.Redirect("Aulas.aspx");

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

                Aula aula = (Aula)ViewState["itemSel"];

                Turma turma = new Turma();

                aula.Nome = txtNome.Text;
                aula.idProfessor = professor;

                turma.idTurma = int.Parse(dropDownTurmas.SelectedValue);

                aula.idTurma = turma;

                new AulaController().Atualizar(aula);

                Response.Redirect("Aulas.aspx");

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