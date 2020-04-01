<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentRegistration.Login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title><%=Classes.clsGetSettings.Name%> | StudentRegistration</title>	
        <script language="javascript" type="text/javascript" src="../jscript/jquery-latest.js"></script>		
		 <script language="javascript" type="text/javascript" src="../jscript/jscript_validations.js"></script>		
		<script type="text/javascript" language="javascript">				
			function fnSaveValidate(ctrlToValidate)
			{
				var i=-1;
				var myArr= new Array();				
				//document.getElementById("txtPassword").value = Trim(document.getElementById("txtPassword").value);  
				//myArr[++i]= new Array(document.getElementById("txtPassword"),"Empty","Please Enter Password.","text");
				//document.getElementById("txtUserName").value = Trim(document.getElementById("txtUserName").value);  
				//myArr[++i]= new Array(document.getElementById("txtUserName"),"Empty","Please Enter User Name.","text");var ret=validateMe(myArr,50,ctrlToValidate); 
				//return ret;
				return true;
			}
		</script>
		
	</head>
	<body leftmargin="0" topmargin="0" rightmargin="0">
		<form id="Form1" runat="server">
       
			<div align="center">
				<table id="table1" style="BORDER-COLLAPSE: collapse" bordercolor="#c0c0c0" cellpadding="2"
					width="900" border="0">
					<tr>
						<td colspan="4" height="10"></td>
					</tr>
					<tr>
						<td style="WIDTH: 170px" valign="top"></td>
						<td valign="top" width="830" height="380">
							<table width="100%">
								<tr>
									<td valign="top" width="75%">
										<table width="100%">
											<tr valign="top">
												<td>&nbsp;</td>
											</tr>
										</table>
									</td>
									<td class="login" width="25%" height="89">
										<fieldset><legend>&nbsp;Login</legend>
											<table>
												<tr>
													<td align="right"><font face="verdana" color="#666666" size="1">User</font></td>
													<td align="right"><asp:textbox id="txtUserName" runat="server" maxlength="50" Text="superadmin" cssclass="loginbox"></asp:textbox></td>
												</tr>
												<tr>
													<td><font face="verdana" color="#666666" size="1">Password</font></td>
													<td><asp:textbox id="txtPassword" runat="server" maxlength="15" cssclass="loginbox" Text="DuDc123!@" textmode="Password"></asp:textbox></td>
												</tr> 
												<tr>
													<td valign="baseline" align="right" colspan="2"><asp:label id="lblError" runat="server" visible="False" font-size="6pt" forecolor="Red" font-bold="True">Invalid User Name/Password</asp:label><asp:button id="btnLogin" runat="server" cssclass="btnGo" text="Go" OnClientClick="return fnSaveValidate(this);" OnClick="btnLogin_Click"></asp:button></td>
												</tr>
												<tr>
													<td colspan="2"><font face="verdana" color="#666666" size="1">Forgot Password</font>
													</td>
												</tr>
											</table>
										</fieldset>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td colspan="3"></td>
					</tr>
				</table>
				<%--<asp:repeater id="mnuReapeater" runat="server">
					<headertemplate>
						<script language="javascript"> 
					<ItemTemplate>
					
					var sWidth=0;
				
					var pos="right";
								if(parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)))+170 < screen.width)
								{
									sWidth = parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)));
								}
								else
								{
									pos="left";
									sWidth= parseInt((document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetLeft)+parseInt((document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetWidth)))-335;
								}			
							new ypSlideOutMenu("menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>", pos,sWidth ,parseInt(document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>').offsetTop+document.getElementById('MenuTable<%#DataBinder.Eval(Container.DataItem, "GroupID")%>').offsetTop),170,document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>Content')?document.getElementById('menu<%#DataBinder.Eval(Container.DataItem, "MenuID")%>Content').offsetHeight:0);


					</ItemTemplate>
					<FooterTemplate> 
						ypSlideOutMenu.writeCSS();				
					</FooterTemplate>
						</script>
					</headertemplate>
				</asp:repeater>--%>
			</div>
		</form>
	</body>
</html>
