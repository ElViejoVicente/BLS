<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumenCreditos.aspx.cs" Inherits="BLS.Web.RegistroClientes.ResumenCreditos" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css" />
    <script src="../Scripts/mensajes.js"></script>

    <style>
        .paquete-scroll-container {
            max-height: 80vh;
            overflow-y: auto;
            padding-right: 10px;
        }

        .paquete-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(360px, 1fr));
            gap: 30px;
            margin: 20px auto;
            max-width: 800px;
        }

        .paquete-card {
            border-radius: 16px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.1);
            transition: transform 0.3s ease;
            background: #fff;
            text-align: center;
            padding: 30px 20px;
        }

            .paquete-card:hover {
                transform: translateY(-5px);
            }

        .paquete-titulo {
            font-weight: bold;
            font-size: 1.3rem;
            margin-bottom: 15px;
        }

        .paquete-precio {
            font-size: 2.5rem;
            color: #28a745;
            margin-bottom: 15px;
        }

        .paquete-descripcion {
            font-size: 1rem;
            color: #6c757d;
            margin-bottom: 20px;
        }

        .paquete-btn {
            border-radius: 25px;
            font-weight: 600;
            padding: 12px 25px;
            width: 100%;
        }
    </style>


    <style>
        .titulo-paquete {
            font-size: 2.5rem; /* ajusta el tamaño */
            font-weight: 700; /* negrita */
            text-align: center;
            margin-bottom: 1.5rem;
        }
    </style>




    <title>BLS</title>
</head>
<body>
    <form id="frmPage" runat="server" class="Principal">

        <section class="CLPageContent" id="maindiv">


            <dx:ASPxPanel ID="ASPxPanel1" runat="server" ClientVisible="false">
            </dx:ASPxPanel>




            <dx:ASPxPanel ID="pnlClienteNuevo" runat="server" ClientVisible="false">
                <PanelCollection>
                    <dx:PanelContent>



                        <div class="container mt-4">
                            <h3 class="titulo-paquete">Elige tu paquete</h3>
                        </div>



                        <div class="paquete-scroll-container">
                            <div class="paquete-grid">


                                <dx:ASPxPanel runat="server" CssClass="paquete-card">
                                    <PanelCollection>
                                        <dx:PanelContent>
                                            <div class="paquete-titulo">Gratis</div>
                                            <div class="paquete-precio">$0</div>
                                            <div class="paquete-descripcion">4 pruebas incluidas</div>
                                            <div class="paquete-descripcion">20 créditos disponibles</div>
                                            <div class="paquete-descripcion">20 créditos disponibles</div>
                                            <dx:ASPxButton runat="server" Text="Seleccionar" CssClass="btn btn-outline-success paquete-btn" />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxPanel>

                                <dx:ASPxPanel runat="server" CssClass="paquete-card">
                                    <PanelCollection>
                                        <dx:PanelContent>
                                            <div class="paquete-titulo">20 Créditos</div>
                                            <div class="paquete-precio">$100</div>
                                            <div class="paquete-descripcion">20 créditos disponibles</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <dx:ASPxButton runat="server" Text="Seleccionar" CssClass="btn btn-outline-primary paquete-btn" />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxPanel>

                                <dx:ASPxPanel runat="server" CssClass="paquete-card">
                                    <PanelCollection>
                                        <dx:PanelContent>
                                            <div class="paquete-titulo">50 Créditos</div>
                                            <div class="paquete-precio">$200</div>
                                            <div class="paquete-descripcion">50 créditos disponibles</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <dx:ASPxButton runat="server" Text="Seleccionar" CssClass="btn btn-outline-warning paquete-btn" />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxPanel>

                                <dx:ASPxPanel runat="server" CssClass="paquete-card">
                                    <PanelCollection>
                                        <dx:PanelContent>
                                            <div class="paquete-titulo">100 Créditos</div>
                                            <div class="paquete-precio">$400</div>
                                            <div class="paquete-descripcion">100 créditos disponibles</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <div class="paquete-descripcion">Incluye....</div>
                                            <dx:ASPxButton runat="server" Text="Seleccionar" CssClass="btn btn-outline-danger paquete-btn" />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxPanel>

                            </div>



                        </div>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxPanel>









            <dx:ASPxPanel ID="pnlResumenCliente" runat="server" ClientVisible="false">
            </dx:ASPxPanel>



        </section>

    </form>
</body>
</html>
