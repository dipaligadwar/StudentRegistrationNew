
<%@ Page language="c#" MasterPageFile="~/Content.Master" Codebehind="HomeContentDisplay.aspx.cs" AutoEventWireup="false" Inherits="UniversityPortal.HomeContentDisplay" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
		<table width="100%">
								<tr>
									<td width="99%" valign="top" align="left">
										<p align="left">
											<asp:label id="lblContentTitle" style="TEXT-ALIGN: left" runat="server" CssClass="llblContentTitle"></asp:label>
										</p>
										<P>
											<asp:label id="InnerContent" style="TEXT-ALIGN: justify" runat="server"></asp:label>
										</P>
										<P>
											<asp:label id="lblUpdationDate" runat="server"></asp:label>
										</P>
									</td>
									<td width="1%" valign="top" align="left">
									</td>
								</tr>
							</table>					
</asp:Content>
