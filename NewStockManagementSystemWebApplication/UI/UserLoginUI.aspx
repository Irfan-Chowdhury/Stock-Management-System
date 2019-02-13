<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginUI.aspx.cs" Inherits="NewStockManagementSystemWebApplication.UI.UserLoginUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Stock Management System</title>

    <style>
@import url(http://fonts.googleapis.com/css?family=Exo:100,200,400);
@import url(http://fonts.googleapis.com/css?family=Source+Sans+Pro:700,400,300);

body{
	margin: 0;
	padding: 0;
	background: #fff;

	color: #fff;
	font-family: Arial;
	font-size: 12px;
}

.body{
	position: absolute;
	top: -20px;
	left: -20px;
	right: -40px;
	bottom: -40px;
	width: auto;
	height: auto;
	background-image: url(http://ginva.com/wp-content/uploads/2012/07/city-skyline-wallpapers-008.jpg);
	background-size: cover;
	-webkit-filter: blur(5px);
	z-index: 0;
}

.grad{
	position: absolute;
	top: -20px;
	left: -20px;
	right: -40px;
	bottom: -40px;
	width: auto;
	height: auto;
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(0,0,0,0)), color-stop(100%,rgba(0,0,0,0.65))); /* Chrome,Safari4+ */
	z-index: 1;
	opacity: 0.7;
}

.header{
	position: absolute;
	top: calc(50% - 65px);  /*35px*/
	left: calc(50% - 255px);
	z-index: 2;
}

.header div{
	float: left;
	color: #fff;
	font-family: 'Exo', sans-serif;
	font-size: 35px;
	font-weight: 200;
}

.header div span{
	color: #5379fa !important;
}


.login{
	position: absolute;
	top: calc(50% - 75px);
	left: calc(50% - 50px);
	height: 150px;
	width: 350px;
	padding: 10px;
	z-index: 2;
}

.login input[type=text]{
	width: 250px;
	height: 30px;
	background: transparent;
	border: 1px solid rgba(255,255,255,0.6);
	border-radius: 2px;
	color: #fff;
	font-family: 'Exo', sans-serif;
	font-size: 16px;
	font-weight: 400;
	padding: 4px;
}

.login input[type=password]{
	width: 250px;
	height: 30px;
	background: transparent;
	border: 1px solid rgba(255,255,255,0.6);
	border-radius: 2px;
	color: #fff;
	font-family: 'Exo', sans-serif;
	font-size: 16px;
	font-weight: 400;
	padding: 4px;
	margin-top: 10px;
}

.login input[type=button]{
	width: 260px;
	height: 35px;
	background: #fff;
	border: 1px solid #fff;
	cursor: pointer;
	border-radius: 2px;
	color: #a18d6c;
	font-family: 'Exo', sans-serif;
	font-size: 16px;
	font-weight: 400;
	padding: 6px;
	margin-top: 10px;
}

.login input[type=button]:hover{
	opacity: 0.8;
}

.login input[type=button]:active{
	opacity: 0.6;
}

.login input[type=text]:focus{
	outline: none;
	border: 1px solid rgba(255,255,255,0.9);
}

.login input[type=password]:focus{
	outline: none;
	border: 1px solid rgba(255,255,255,0.9);
}

.login input[type=button]:focus{
	outline: none;
}

::-webkit-input-placeholder{
   color: rgba(255,255,255,0.6);
}

::-moz-input-placeholder{
   color: rgba(255,255,255,0.6);
}
</style>

<script src="LoginUI_2/js/prefixfree.min.js"></script>

<%--*****************************************  Show Password  *********************************--%>    

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">  
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
    
<%--***********************************************************************************************************--%>
</head>
<body onload="history.forward()">

    <div class="body"></div>
		<div class="grad"></div>
		<div class="header">
			<div>Stock<span><br/>Managment</span><br/><span style="color: black">System</span></div>
		</div>
        <br/>

    
<form id="form1" runat="server">
	<div class="login">
		<div class="col-md-6"> 
		<div  class="input-group">
		    <div class="input-group-append">
		    <table>
		        <tr>
		            <td>
                         <asp:TextBox ID="txtuser" runat="server"  placeholder="User Name"></asp:TextBox> <br/>		                
		            </td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="txtpass" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox> 		                
		            </td>
                    <td>
                        <%--<div class="input-group-append">--%>                               
                        <button id="show_password" class="btn btn-primary" type="button">  
                            <span class="fa fa-eye-slash icon"></span>  
                         </button> 
                        <%--</div> --%>  
                    </td>
		        </tr>
                <tr>
                    <td>
                        <asp:Label ID="outputLabel" runat="server" ForeColor="red" Width="250px"></asp:Label>
                    </td>
                    </tr>

                    <tr>
                    <td>
                        <br/>
                         <asp:Button  ID="loginButton" runat="server" Text="Login" Height="35px" Width="259px" OnClick="loginButton_OnClick" /> 
                    </td>
                </tr>
		    </table>    		            
         </div>
		</div>
      </div>
    </div>
</form>
  <script src='http://codepen.io/assets/libs/fullpage/jquery.js'></script>
 

<%--*****************************************  Show Password  *********************************--%>    

  <script src='http://codepen.io/assets/libs/fullpage/jquery.js'></script>--%>
    
  

<script type="text/javascript">
    $(document).ready(function () {
        $('#show_password').hover(function show() {
            //Change the attribute to text  
            $('#txtpass').attr('type', 'text');
            $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
        },
        function () {
            //Change the attribute back to password  
            $('#txtpass').attr('type', 'password');
            $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
        });
        //CheckBox Show Password  
        $('#ShowPassword').click(function () {
            $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');
        });
    });


    </script>         
    				
</body>
</html>

