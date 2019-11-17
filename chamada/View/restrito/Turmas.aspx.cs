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
                        txtNomeTurma.Text = listaGridTurmas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;

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
            Carregar();
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
            List<Turma> turmas = new TurmaController().Listar(new Turma());

            listaGridTurmas.DataSource = turmas;

            listaGridTurmas.DataBind();
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modal').modal('show'); });</script>", false);
        }

        public void Incluir()
        {
            try
            {

                Turma turma = new Turma();

                turma.Nome = txtNomeTurma.Text;


              //  turma.idTurma = txtNomeTurma;

                new TurmaController().Incluir(turma);

                Response.Redirect("Turmas.aspx");

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

                Turma turma = (Turma)ViewState["itemSel"];


                turma.Nome = txtNomeTurma.Text;

                //turma.idTurma = turma;

                new TurmaController().Atualizar(turma);

                Response.Redirect("Turmas.aspx");

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