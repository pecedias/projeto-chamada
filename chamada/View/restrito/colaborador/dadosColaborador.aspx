<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dadosColaborador.aspx.cs" Inherits="View.restrito.colaborador.dadosColaborador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dados do colaborador</h1>
            <br />
            <asp:Label ID="Nome" runat="server" Text="Nome"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="CPF" runat="server" Text="CPF"></asp:Label>
            <asp:TextBox ID="txtCPF" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <h1>Dados da unidade</h1>
            <br />
            Nome da unidade:
            <br />
            <asp:DropDownList ID="cmbUnidades" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            &nbsp;
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
