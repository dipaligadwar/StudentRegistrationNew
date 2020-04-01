<%@ Register TagPrefix="uc1" TagName="InnerHeader" Src="InnerHeader.ascx" %>
<%@ Page language="c#" Codebehind="ComingSoonPostLogin.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.ComingSoonPostLogin" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SideLinks" Src="SideLinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><%=Classes.clsGetSettings.Name%> | Administrator</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="jscript/jscript_validations.js"></script>
		<LINK href="CSS/UniPortal.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="900" border="0">
					<TR>
						<TD colSpan="4"></TD>
					</TR>
					<TR>
						<TD colSpan="4" height="10">
							<uc1:InnerHeader id="InnerHeader1" runat="server"></uc1:InnerHeader></TD>
					</TR>
					<TR height="58">
						<TD height="5" vAlign="middle" align="center" rowSpan="1" class="FormName"><IMG height="45" src="images/CoomingSoon.gif" width="45"></TD>
						<td class="FormName" valign="top">
							<P align="left" class="lblPageHead">
								<asp:label id="llblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>Coming 
								Soon
								<asp:label id="lblUpdationDate" runat="server"></asp:label></P>
						</td>
					</TR>
					<TR>
						<TD height="380" vAlign="top" class="SideLeft" width="18%">
							<uc1:SideLinks id="SideLinks1" runat="server"></uc1:SideLinks>
						</TD>
						<TD vAlign="top" width="830">
							<TABLE id="Table2" width="100%">
								<TR>
									<TD vAlign="top" align="center" width="99%">
										<OBJECT codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
											classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
											<PARAM NAME="_cx" VALUE="5080">
											<PARAM NAME="_cy" VALUE="5080">
											<PARAM NAME="FlashVars" VALUE="">
											<PARAM NAME="Movie" VALUE="images/Coming_Soon.swf">
											<PARAM NAME="Src" VALUE="images/Coming_Soon.swf">
											<PARAM NAME="WMode" VALUE="Window">
											<PARAM NAME="Play" VALUE="-1">
											<PARAM NAME="Loop" VALUE="-1">
											<PARAM NAME="Quality" VALUE="High">
											<PARAM NAME="SAlign" VALUE="">
											<PARAM NAME="Menu" VALUE="-1">
											<PARAM NAME="Base" VALUE="">
											<PARAM NAME="AllowScriptAccess" VALUE="">
											<PARAM NAME="Scale" VALUE="ShowAll">
											<PARAM NAME="DeviceFont" VALUE="0">
											<PARAM NAME="EmbedMovie" VALUE="0">
											<PARAM NAME="BGColor" VALUE="">
											<PARAM NAME="SWRemote" VALUE="">
											<PARAM NAME="MovieData" VALUE="">
											<PARAM NAME="SeamlessTabbing" VALUE="1">
											<PARAM NAME="Profile" VALUE="0">
											<PARAM NAME="ProfileAddress" VALUE="">
											<PARAM NAME="ProfilePort" VALUE="0">
											<embed src="images/Coming_Soon.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
												type="application/x-shockwave-flash"> </embed>
										</OBJECT>
									</TD>
									<TD vAlign="top" align="left" width="1%"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="3">
						</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<uc1:Footer id="Footer1" runat="server"></uc1:Footer></TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
