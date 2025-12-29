<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits=" BLS.Web.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<xmlns="http://www.w3.org/1999/xhtml">
<html>
<head runat="server"> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SISTEMA SGN</title>
   <%-- <link rel="stylesheet" href="Content/bootstrap.min.css" crossorigin="anonymous" />--%>
<%--    <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>--%>
<%--    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>--%>

    <link rel="shortcut icon" href="imagenes/header/LogoNotariaRecorte.png" type="image/x-icon" />

<style>
    html, body {
        width: 100%;
		height: 100%;
        margin:0px;
        padding:0px;
    }

    .embed-container {
		position: relative;
		height: 100%;
        width: 100%;
		overflow: hidden;
        border:0px solid green;
	}
   

    .embed-container1 {
		position: relative;
		height: 5%;
        width: 100%;
		overflow: hidden;
        border:0px solid red;
	}

	#headerGPB {
		position: absolute;
		top:0;
		left: 0;
		width: 100%;
		height: 100%;
        overflow: hidden; 
        border:0px solid blue;
	}

     .embed-container2 {
		position: relative;
		height: 96%;
        width: 100%;
		overflow: hidden;
        border:0px solid #2A385D;
	}

    #menu {
		position: absolute;
		top:0;
		left: 0;
		width: 13%;
		height:98.5%;
        border-bottom:2px solid #2A385D;
        border-right:4px solid #2A385D;
	}

     #basefrm {
		position: absolute;
		top:0;
		left: 0;
		width: 86.5%;
		height: 98.5%;
        margin-left:13.4%;
        border-bottom:2px solid #2A385D;
        border-right:2px solid #2A385D;
	}

    @media screen and (max-width:1520px){
        #menu{
		    width: 200px;
	    }
        #basefrm {
              margin-left:202px;
        }
    }
</style>

</head>

<body>
  <div class="embed-container">
       <div class="embed-container1">
			    <iframe name="headerGPB" id="headerGPB" src="header.aspx" frameborder="0"  scrolling="no" allowfullscreen></iframe>
       </div>
       <div class="embed-container2">
            
           <iframe name="menu" id="menu" src="Menu.aspx" frameborder="0"  scrolling="no" allowfullscreen ></iframe>
           <iframe name="basefrm" id="basefrm" src="RegistroClientes/ResumenCreditos.aspx" frameborder="0" allowfullscreen></iframe>
      </div>
  </div>

    <%--<div class="embed-container3">
			    <iframe name="headerGPB" id="headerGPB" src="header.aspx" frameborder="0" allowfullscreen></iframe>
    </div>--%>
  <%-- <div class="embed-container2">
           <iframe name="menu" id="menu" src="Menu.aspx" frameborder="0" allowfullscreen></iframe>
           <iframe name="basefrm" id="basefrm" src="PaginaVacia.html" frameborder="0" allowfullscreen></iframe>
   </div>--%>

</body>

</html>