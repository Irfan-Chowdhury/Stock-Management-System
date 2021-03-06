﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryUI.aspx.cs" Inherits="CatagoryWebApp.UI.CategoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title >Category Setup</title>
    
   <meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
		<script src="Data/js/jquery.min.js"></script>
		<script src="Data/js/skel.min.js"></script>
		<script src="Data/js/skel-layers.min.js"></script>
		<script src="Data/js/init.js"></script>
		<noscript>
			<link rel="stylesheet" href="Data/css/skel.css" />
			<link rel="stylesheet" href="Data/css/style.css" />
			<link rel="stylesheet" href="Data/css/style-xlarge.css" />
		</noscript>		
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lato">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="Data/css/style.css" />

<%--<link href="../Contents/bootstrap.css" rel="stylesheet" />    --%>
        <%--<----------------------- label eror--%>  


<style>
    
label.error {    <%--<----------------------- label eror--%>  
            color: red;
        }    

body,h1,h2,h3,h4,h5,h6 {font-family: "Lato", sans-serif}
.w3-bar,h1,button {font-family: "Montserrat", sans-serif}
.fa-anchor,.fa-coffee {font-size:200px}
</style>

</head>
<body>

    		<!-- **********************  Header ****************************** -->
<form id="form2" runat="server">
<div class="w3-top">		
<div class="w3-bar w3-red w3-card w3-left-align w3-large">
	<a class="w3-bar-item w3-button w3-hide-medium w3-hide-large w3-right w3-padding-large w3-hover-white w3-large w3-red" href="javascript:void(0);" onclick="myFunction()" title="Toggle Navigation Menu"><i class="fa fa-bars"></i></a>
    <a href="MainUI_2.aspx" class="w3-bar-item w3-button w3-padding-large w3-white">Home</a>
    
	<div class="w3-dropdown-hover w3-hide-small">
		<button class="w3-button" title="Notifications">Setup <i class="fa fa-caret-down"></i></button>     
		<div class="w3-dropdown-content w3-card-4 w3-bar-block">
		  <a href="CategoryUI.aspx" class="w3-bar-item w3-button">Category</a>
		  <a href="CompanyUI.aspx" class="w3-bar-item w3-button">Company</a>
		  <a href="ItemSetupUI.aspx" class="w3-bar-item w3-button">Item</a>
		</div>
	</div>
	
	<div class="w3-dropdown-hover w3-hide-small">
		<button class="w3-button" title="Notifications">Stock <i class="fa fa-caret-down"></i></button>     
		<div class="w3-dropdown-content w3-card-4 w3-bar-block">
		  <a href="StockInUI.aspx" class="w3-bar-item w3-button">Stock In</a>
		  <a href="StockOutUI.aspx" class="w3-bar-item w3-button">Stock Out</a>
		</div>
	</div>
	
	<div class="w3-dropdown-hover w3-hide-small">
		<button class="w3-button" title="Notifications">Report <i class="fa fa-caret-down"></i></button>     
		<div class="w3-dropdown-content w3-card-4 w3-bar-block">
		  <a href="SearchAndView.aspx" class="w3-bar-item w3-button">Search And View Item</a>
		  <a href="BetweenTwoDatesUI.aspx" class="w3-bar-item w3-button">Search And View Date</a>
		</div>
	</div>
	
	<a href="AboutUI.aspx" class="w3-bar-item w3-button w3-hide-small w3-hover-white">About Us</a>
   <a href="UserLoginUI.aspx" class="btn btn-info btn-lg">
          <span class="glyphicon glyphicon-log-out"></span> Log out
        </a>
<%--    <asp:Button  ID="logoutButton" runat="server" Text="Logout" BackColor="red" OnClick="logoutButton_OnClick" />--%>
    
  </div>
</div>

<%--</form>--%>
    
    <%--**********************  Category Setup  ******************--%>
    
    <h1 style="text-align: center; color: #27BDB2; display: block;font-size: 2em;margin-top: 1.67em;font-weight: bold ">Category Setup</h1>
    <%--<form id="form1" runat="server">--%>
    <div>
        <table>
            <tr>
                <td>
                     <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="categoryNameTextBox" for="categoryNameTextBox" runat="server" Width="209px"></asp:TextBox>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="categoryNameTextBox" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{2,15}$" runat="server" ErrorMessage="Category Name must be between 2 and 15 characters long." ForeColor="red"></asp:RegularExpressionValidator>
                </td>
                <td></td>
                <%--<td>
                     <asp:TextBox ID="categoryNameTextBox" for="categoryNameTextBox" runat="server" Width="209px"></asp:TextBox>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="categoryNameTextBox" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{4,15}$" runat="server" ErrorMessage="Category Name must be between 4 and 15 characters long." ForeColor="red"></asp:RegularExpressionValidator>                
                </td>--%>
                <%--<td>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="categoryNameTextBox" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{4,15}$" runat="server" ErrorMessage="Category Name must be between 4 and 15 characters long." ForeColor="red"></asp:RegularExpressionValidator>
                </td>--%>
            </tr>
            
            <tr>
                <td>
                     <asp:Button ID="Button1" runat="server" OnClick="saveButton_Click" Text="Save" />
                </td>
                <td>
                    <asp:Label ID="outputLabel" runat="server" ForeColor="red"></asp:Label>
                </td>
            </tr> 
    </table>
    </div>
      
        <%--<div class="GridView">--%>
    <div>
        <asp:GridView ID="categoryGridView" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>                
                 <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                        <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Eval("Id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="updateLinkButton" runat="server" OnClick="updateLinkButton_OnClick">Update</asp:LinkButton>                     
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>    
        <asp:HyperLink ID="refreshHyperLink" runat="server" NavigateUrl="CategoryUI.aspx">Refresh</asp:HyperLink>
        </div>
    </form>
    
    
    
    <%--*********************  label error ********************************--%>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/bootstrap.js"></script> 
    
    <script>
        
        $("#form2").validate({
            rules: {
                categoryNameTextBox: "required"         
            },
            messages: {
                categoryNameTextBox: "Please enter your Category Name"                
            }
        }); 

    </script>

</body>
</html>
