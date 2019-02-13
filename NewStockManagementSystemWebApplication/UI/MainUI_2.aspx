<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainUI_2.aspx.cs" Inherits="NewStockManagementSystemWebApplication.UI.MainUI_21" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>Stock Management System</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
		<!--[if lte IE 8]><script src="js/html5shiv.js"></script><![endif]-->
		<script src="Data/js/jquery.min.js"></script>
		<script src="Data/js/skel.min.js"></script>
		<script src="Data/js/skel-layers.min.js"></script>
		<script src="Data/js/init.js"></script>
		<noscript>
			<link rel="stylesheet" href="Data/css/skel.css" />
			<link rel="stylesheet" href="Data/css/style.css" />
			<link rel="stylesheet" href="Data/css/style-xlarge.css" />
		</noscript>
		
		
		<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lato">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="Data/css/style.css" />
<style>
body,h1,h3,h4,h5,h6 {font-family: "Lato", sans-serif}
.w3-bar,h1,button {font-family: "Montserrat", sans-serif}
.fa-anchor,.fa-coffee {font-size:200px}
</style>

</head>
<body>  
	

		<!-- **********************  Header ****************************** -->
 <form id="form1" runat="server">
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

</form>
		<!--********************* Banner *********************** -->
			<section id="banner">
				<div class="inner">
				    <div class="hero-text">
                        <h1 style="font-size: 70px;color: #E2E5E9">Stock Mangement System</h1>
                     </div> 
				</div>
			</section>

		<!-- One -->
			<section id="one" class="wrapper style1">
				<header class="major">
					<h2>Catalogue of Stock Mangement</h2>
				</header>
				<div class="container">
					<div class="row">
					
						<div class="4u">
							<section class="special box">
								<a href="CategoryUI.aspx"><image src="Data/images/Categories Excel.jpg" alt="pic" class="pic"/></a>
								<h3>Category</h3>
							</section>
						</div>
						
						<div class="4u">
							<section class="special box">
								<a href="CompanyUI.aspx"><image src="Data/images/company.jpg" alt="pic" class="pic"/></a>
								<h3>Company</h3>
							</section>
						</div>
						<div class="4u">
							<section class="special box">
								<a href="ItemSetupUI.aspx"><image src="Data/images/itemsetup.jpg" alt="pic" class="pic"/></a>
								<h3>Item Setup</h3>
							</section>
						</div>
						
						<div class="4u">
							<section class="special box">
								<a href="StockInUI.aspx"><image src="Data/images/stock.jpg" alt="pic" class="pic"/></a>
								<h3>Stock In</h3>
							</section>
						</div>
						
						<div class="4u">
							<section class="special box">
								<a href="StockOutUI.aspx"><image src="Data/images/stock out.jpg" alt="pic" class="pic"/></a>
								<h3>Stock Out</h3>
							</section>
						</div>
						
						<div class="4u">
							<section class="special box">
								<a href="SearchAndView.aspx"><img src="Data/images/search.jpg" alt="pic" class="pic"/></a>
								<h3>Search And View by Item</h3>
							</section>
						</div>
						
						<div class="4u">
							<section class="special box">
							    <a href="BetweenTwoDatesUI.aspx"><image src="Data/images/search date.png" alt="pic" class="pic"/></a>
								<h3>Search And View by Date</h3>
							</section>
						</div>
						
					</div>
				</div>
			</section>
			
		

<!-- ******************************  Footer *************************-->
<footer class="w3-container w3-padding-64 w3-center w3-opacity">  
  <div class="w3-xlarge w3-padding-32">
    <a href="https://www.facebook.com/"><i class="fa fa-facebook-official w3-hover-opacity"></i></a>
    <a href="https://www.instagram.com/"><i class="fa fa-instagram w3-hover-opacity"></i></a>
    <a href="https://www.snapchat.com/"><i class="fa fa-snapchat w3-hover-opacity"></i></a>
    <a href="https://www.pinterest.com/"><i class="fa fa-pinterest-p w3-hover-opacity"></i></a>
    <a href="https://twitter.com/"><i class="fa fa-twitter w3-hover-opacity"></i></a>
    <a href="https://www.linkedin.com/"><i class="fa fa-linkedin w3-hover-opacity"></i></a>
 </div>
 <p>Powered by @ <a href="#" target="_blank">Bug_Bites</a></p>
</footer>

<script>
// Used to toggle the menu on small screens when clicking on the menu button
function myFunction() {
    var x = document.getElementById("navDemo");
    if (x.className.indexOf("w3-show") == -1) {
        x.className += " w3-show";
    } else { 
        x.className = x.className.replace(" w3-show", "");
    }
}
</script>
	
</body>
</html>
