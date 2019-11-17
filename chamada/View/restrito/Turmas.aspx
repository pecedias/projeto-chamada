<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turmas.aspx.cs" Inherits="View.restrito.Turmas" %>

<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/docs/4.0/assets/img/favicons/favicon.ico">

    <title>Chamada UP</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js" type="text/javascript"></script>
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/dashboard/">

    <!-- Bootstrap core CSS -->  
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <!-- Custom styles for this template -->
    <link href="src/style.css" rel="stylesheet">
  </head>

  <body>
    <nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0">
      <a class="navbar-brand col-sm-3 col-md-2 mr-0" href="#">Chamada UP</a>
      
      <ul class="navbar-nav px-3">
        <li class="nav-item text-nowrap">
          <a class="nav-link" href="#">Sair</a>
        </li>
      </ul>
    </nav>

    <div class="container-fluid">
      <div class="row">
        <nav class="col-md-2 d-none d-md-block sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
              <li class="nav-item">
                <a class="nav-link active" href="#">
                  <span data-feather="home"></span>
                  Inicio <span class="sr-only">(current)</span>
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="Aulas.aspx">
                  <span data-feather="file"></span>
                  Aulas
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="Turmas.aspx">
                  <span data-feather="book"></span>
                  Turmas
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="Alunos.aspx">
                  <span data-feather="users"></span>
                  Alunos
                </a>
              </li>
            </ul>
          </div>
        </nav>
          <div class="content">
               <h1>Lista de Turmas</h1>
               <form id="form1" runat="server">
                      <!--- Modal Editar -->
                    <div class="modal" id="modal" tabindex="-1" role="dialog">
                          <div class="modal-dialog" role="document">
                            <div class="modal-content">
                              <div class="modal-header">
                                <h5 class="modal-title">Editando <asp:Label ID="editLabel"></asp:Label></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                                  <span aria-hidden="true">&times;</span>
                                </button>
                              </div>
                              <div class="modal-body">
                                <p>Nome: <asp:TextBox ID="txtNome" runat="server" MaxLength="120"></asp:TextBox></p>
                                <p>Turma: <asp:DropDownList ID="turmaDropDown"></asp:DropDownList></p>
                              </div>
                              <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                                <button type="button" class="btn btn-primary">Salvar mudanças</button>
                              </div>
                            </div>
                          </div>
                      </div>
                   <!-- Lista -->
                   <asp:GridView ID="listaGridTurmas" runat="server"
                     CssClass="table table-dark m-1"
                    AutoGenerateColumns="false" OnRowCommand="listaGridTurmas_RowCommand">
                       <Columns>
                           <asp:BoundField DataField="idTurma" HeaderText="ID Turma" ItemStyle-Height="16px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                           <asp:BoundField DataField="Nome" HeaderText="Nome Turma" ItemStyle-Height="16px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                           <asp:ButtonField CommandName="alterar" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Alterar" HeaderText="Alterar" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  />
                           <asp:ButtonField CommandName="excluir" ButtonType="Button" Text="Deletar" ControlStyle-CssClass="btn btn-danger" HeaderText="Excluir" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" />
                       </Columns>
                   </asp:GridView>
                   <asp:ScriptManager runat="server"></asp:ScriptManager>
               </form>
          </div>
      </div>
    </div>




    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <!-- Icons -->
    <script src="https://unpkg.com/feather-icons/dist/feather.min.js"></script>
    <script>
        feather.replace()
    </script>
  </body>
</html>