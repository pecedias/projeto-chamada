using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito.colaborador
{
    public partial class listaColaboradores : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Carregar();
        }

        protected void dgvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "alterar":
                    {

                        int id = int.Parse(dgvLista.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        Response.Redirect("dadosColaborador.aspx?itemSel=" + id);

                    }
                    break;

                case "excluir":
                    {

                        Colaborador c = new Colaborador();
                        c.idColaborador = int.Parse(dgvLista.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        new ColaboradorController().Excluir(c);
                        Carregar();

                    }
                    break;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../menu.aspx");
        }

        #region Métodos

        public void Carregar()
        {
            List<Colaborador> colaboradores = new ColaboradorController().Listar(new Colaborador());

            dgvLista.DataSource = colaboradores;

            dgvLista.DataBind();
        }

        #endregion

    }
}