<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LP_UploadStatistics.aspx.cs" Inherits="StudentRegistration.Eligibility.LP_UploadStatistics" %>

<asp:Content ContentPlaceHolderID = "ContentPlaceHolder1" runat="server" ID="Content">
<script type="text/javascript" language="javascript" src="/JS/SPXMLHTTP.js">
</script>

			<CENTER>
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="700" border="0">					
					<tr>						
						<%--<TD class="FormName" align="left" vAlign="middle">
						<asp:label id="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead">View Status</asp:label>--%>
						<td align="left" style="border-bottom: 1px solid #FFD275; height: 17px;">
                        <asp:Label ID="lblPageHead" runat="server" Text="Registration Statistics"></asp:Label>
				        </TD>
					</tr>
					<tr style="height:10px;"><td></td></tr>
					</TABLE>
					</CENTER>
</asp:Content>
