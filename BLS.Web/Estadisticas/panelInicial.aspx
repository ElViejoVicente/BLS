<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panelInicial.aspx.cs" Inherits="BLS.Web.Estadisticas.panelInicial" %>

<%@ Register Assembly="DevExpress.XtraCharts.v25.2.Web, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css"/>
    <script src="../Scripts/mensajes.js"></script>
    <title>SGN</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
            padding: 0;
            background: #f4f6fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
        .Principal {
            min-height: 100vh;
            background: linear-gradient(135deg, #e3eafc 0%, #f9f9f9 100%);
        }
        .center-container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }
        .chart-card {
            background: #fff;
            border-radius: 18px;
            box-shadow: 0 4px 24px rgba(0,0,0,0.08), 0 1.5px 4px rgba(0,0,0,0.04);
            padding: 32px 32px 24px 32px;
            margin: 32px 0;
            transition: box-shadow 0.2s;
            max-width: 1300px;
            width: 100%;
        }
        .chart-title {
            font-size: 2.1rem;
            font-weight: 600;
            color: #2a3b4c;
            margin-bottom: 18px;
            text-align: center;
            letter-spacing: 0.5px;
        }
        .powered-by {
            text-align: right;
            font-size: 1rem;
            color: #7a869a;
            margin-top: 12px;
        }
        @media (max-width: 1400px) {
            .chart-card {
                padding: 18px 8px 12px 8px;
                max-width: 98vw;
            }
        }
        @media (max-width: 900px) {
            .chart-card {
                padding: 8px 2px 8px 2px;
            }
            .chart-title {
                font-size: 1.2rem;
            }
        }
    </style>
    <script type="text/javascript">
        window.onresize = function (event) {
            AdjustSize();
        };

        function OnInit(s, e) {
            s.GetWindowElement(-1).className += " popupStyle";
        }

        function AdjustSize() {
            var height = document.getElementById('maindiv') ? document.getElementById('maindiv').clientHeight - 100 : 600;
            if (window.gvArea) gvArea.SetHeight(height);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="Principal">

             <div class="center-container">
            <div class="chart-title">Estadística de operacion, Año:  <%= DateTime.Now.Year %> Notaria 01 Huamantla Tlaxcala</div>
            <div class="chart-card">
                <dx:WebChartControl ID="chartEstadisticaActosSimple" runat="server" Height="600px"
                    Width="1100px"
                    ClientInstanceName="chartEstadisticaActosSimple" OnCustomCallback="chartEstadisticaActosSimple_CustomCallback"
                    ToolTipEnabled="True" CrosshairEnabled="True" RenderFormat="Svg">
                    <Legend Name="Default Legend" AlignmentVertical="Top" Font="Tahoma, 10pt, style=Bold" TextColor="DimGray"></Legend>
                    <SeriesSerializable>
                        <dx:Series Name="Estatus"  LegendTextPattern="{A} : {V:F1}">
                            <Points>
                            </Points>
                            <ViewSerializable>
                                <dx:PieSeriesView Rotation="90" RuntimeExploding="True">
                                    <Titles>
                                        <dx:SeriesTitle Dock="Bottom" Text="Total: {TV:#} Expedientes" Font="Tahoma, 16pt, style=Bold" />
                                    </Titles>
                                </dx:PieSeriesView>
                            </ViewSerializable>
                            <LabelSerializable>
                                <dx:PieSeriesLabel Position="Radial"  ColumnIndent="50" TextColor="#2a3b4c" BackColor="Transparent" Font="Tahoma, 9pt, style=Bold" TextPattern="{VP:P0}">
                                    <Border Visibility="False"></Border>
                                </dx:PieSeriesLabel>
                            </LabelSerializable>
                        </dx:Series>
                    </SeriesSerializable>
                    <BorderOptions Visibility="False" />
                    <Titles>
                        <dx:ChartTitle Text="" />
                    </Titles>
                    <DiagramSerializable>
                        <dx:SimpleDiagram></dx:SimpleDiagram>
                    </DiagramSerializable>
                </dx:WebChartControl>
                <div class="powered-by">Powered by Consultoria-It</div>
            </div>
        </div>
    </form>
    </body> 
</html>
