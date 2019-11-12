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
    public partial class dadosColaborador : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CarregarCombo();
                if (Request.QueryString["itemSel"] != null)
                {
                    Carregar();
                    
                }
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["itemSel"] == null)
                Incluir();
            else
                Alterar();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["itemSel"] == null)
                Response.Redirect("../menu.aspx");
            else
                Response.Redirect("listaColaborador.aspx");

        }

        #region Métodos

        public void Carregar()
        {

            Colaborador c = new Colaborador();
            c.idColaborador = int.Parse(Request.QueryString["itemSel"]);

            c = new ColaboradorController().Listar(c)[0];

            ViewState.Add("itemSel", c);

            txtNome.Text = c.Nome;
            txtCPF.Text = c.CPF;

            Unidade u = new Unidade();
            u.idUnidade = c.unidade.idUnidade;

            u = new UnidadeController().Listar(u)[0];

            cmbUnidades.Text = c.unidade.idUnidade.ToString();

        }


        public void Incluir()
        {
            int valor = 0;
            try
            {

                Colaborador colaborador = new Colaborador();
                Unidade unidade = new Unidade();

                colaborador.Nome = txtNome.Text;
                colaborador.CPF = txtCPF.Text;

                colaborador.unidade = unidade;

                if (cmbUnidades.SelectedIndex > 0)
                    valor = System.Convert.ToInt32(cmbUnidades.SelectedValue);
                    colaborador.unidade.idUnidade = valor;

                colaborador.usuario = UsuarioLogado;

                new ColaboradorController().Incluir(colaborador);

                Response.Redirect("../menu.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        public void Alterar()
        {
            int valor = 0;
            try
            {

                Colaborador colaborador = (Colaborador)ViewState["itemSel"];

                Unidade unidade = new Unidade();

                colaborador.Nome = txtNome.Text;
                colaborador.CPF = txtCPF.Text;

                colaborador.unidade = unidade;

                if (cmbUnidades.SelectedIndex > 0)
                    valor = System.Convert.ToInt32(cmbUnidades.SelectedValue);
                colaborador.unidade.idUnidade = valor;

                colaborador.usuario = UsuarioLogado;

                new ColaboradorController().Atualizar(colaborador);

                Response.Redirect("listaColaborador.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        public void CarregarCombo()
        {

            List<Unidade> lst = new UnidadeController().Listar(new Unidade());

            foreach (Unidade item in lst)
            {
                cmbUnidades.Items.Add(new ListItem(item.nome, item.idUnidade.ToString()));
            }

        }

    }
    #endregion
}