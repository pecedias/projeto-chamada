﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class inicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void btnOk_Click(object sender, EventArgs e)
        {

            try
            {

                ProfessorController uc = new ProfessorController();

                Professor us = new Professor();

                us.Email = txtCpf.Text;
                us.Senha = txtSenha.Text;

                Professor ul = uc.Logar(us);

                // Cria Ticket para autenticação no sistema
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket("  ", false, 15);
                // String para criptografia do Ticket
                String encryptTicket = FormsAuthentication.Encrypt(authTicket);
                // Cookie que armazena os dados do usuário autenticado
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                // Adiciona o Ticket no cookie
                Response.Cookies.Add(authCookie);

                Session.Add("ProfessorLogado", ul);

                Response.Redirect("/restrito/menu.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        public void ExibirMensagemAlert(String textoMensagem)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "mensagemAlert", String.Format("alert('{0}')", textoMensagem), true);
        }

    }
}