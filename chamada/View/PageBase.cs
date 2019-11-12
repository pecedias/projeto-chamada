using Model;
using System;
using System.Web.UI;

namespace View
{
    public class PageBase : System.Web.UI.Page
    {

        public Professor ProfessorLogado
        {
            get
            {
                return (Professor)Session["ProfessorLogado"];
            }
            set
            {
                Session.Add("ProfessorLogado", value);
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            if (!Page.IsPostBack)
                ValidarAcesso();

            base.OnLoad(e);

        }

        protected override void OnError(EventArgs e)
        { 

            Exception ex = Server.GetLastError();

            Response.Redirect("~/publico/erro.aspx");

            base.OnError(e);

        }

        public void ExibirMensagemAlert(String textoMensagem)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "mensagemAlert", String.Format("alert('{0}')", textoMensagem), true);
        }

        public void ValidarAcesso()
        {

            bool acesso = false;

            for (int i = 0; i < ProfessorLogado.listaPaginaAcesso.Count; i++)
            {

                if (ProfessorLogado.listaPaginaAcesso[i].url != null)
                {

                    String aux = ProfessorLogado.listaPaginaAcesso[i].url;

                    aux = aux.Substring(aux.IndexOf('/'));

                    if (Page.AppRelativeVirtualPath.Contains(aux))
                    {
                        acesso = true;
                    }

                }
                
            }

            if (!acesso)
                Response.Redirect("../menu.aspx");

        }

    }
}