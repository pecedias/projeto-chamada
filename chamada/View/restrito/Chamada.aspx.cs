using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito
{
    public partial class Chamada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void listaGridChamadaPresenca_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void listaGridChamadaFaltas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
 

                        int idChamada = int.Parse(listaGridChamadaFaltas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                        int idAluno = int.Parse(listaGridChamadaFaltas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);
                        int presenca = int.Parse(listaGridChamadaFaltas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
                        ListItem fvalue = new ListItem("false", "0");
                        ListItem tvalue = new ListItem("true", "1");
                        dropDownPresenca.Items.Add(fvalue);
                        dropDownPresenca.Items.Add(tvalue);
                        if(presenca == 1)
                        {
                            dropDownPresenca.Text = "true";
                        }
                        else
                        {
                            dropDownPresenca.Text = "false";
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(function() { $('#modalEditar').modal('show'); });</script>", false);

        }
    }
}