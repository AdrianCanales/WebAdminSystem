<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSystem.aspx.cs" Inherits="WebAdminSystem.AdminSystem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
            <div class="row">
            <div class="col-md-4">

                <h4 class="text-center text-info">Registro del Local.</h4>

                <br />
                <div class="form-group">
                    <asp:Label CssClass="col-sm-3 control-label" runat="server">Nombre Local</asp:Label>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtNombreLocal" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br /><br />

                <div class="form-group">
                    <asp:Label CssClass="col-sm-3 control-label" runat="server">Dirección Local</asp:Label>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtDireccionLocal" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br /><br />
                
                <div class="form-group">
                    <asp:Label CssClass="col-sm-3 control-label" runat="server">Nombre Usuario</asp:Label>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br /><br />
                <div class="form-group">
                    <asp:Label CssClass="col-sm-3 control-label" runat="server">Clave</asp:Label>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtClave" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br /><br />
                <asp:Button ID="btnAgregar" CssClass="btn btn-success btn-sm center-block" OnClick="btnAgregar_Click"  runat="server" Text="Registrar Local" /><br />
                <asp:Button ID="btnEdit" CssClass="btn btn-primary btn-sm center-block" OnClick="btnEdit_Click"  runat="server" Text="Editar Local" />
                <asp:Label ID="lbRespuesta" runat="server" CssClass="" Text=""></asp:Label>
                <asp:Label ID="lbID" runat="server" CssClass="" Text=""></asp:Label>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="datagrid_locales" OnRowCommand="datagrid_locales_RowCommand" AutoGenerateColumns="false" CssClass="table table-bordered" runat="server">
                    <HeaderStyle CssClass="btn-info" />

                <EmptyDataTemplate>
                    <h4 class="text-center text-danger">No existen Registros</h4>
                </EmptyDataTemplate>

                <Columns>
                    <asp:BoundField HeaderText="#" DataField="id_local" />
                    <asp:BoundField HeaderText="Nombre local" DataField="Nombre" />
                    <asp:BoundField HeaderText="Direccion local" DataField="Direccion" />
                    <asp:BoundField HeaderText="Admin" DataField="nombre" />
                    <asp:ButtonField CommandName="btnSeleccionar" 
                        Text="<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" 
                        HeaderText="<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" 
                        ControlStyle-CssClass="btn btn-primary btn-sm" ButtonType="Link" />
                </Columns>
                </asp:GridView>

            </div>
        </div>
        </div>
        
    </form>
</body>
</html>
