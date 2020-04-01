<%@ Page language="c#" Codebehind="OnErrorShow.aspx.cs" AutoEventWireup="false" MasterPageFile="~/Content.Master" Inherits="UniversityPortal.OnErrorShow" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">
    <TABLE id="Table2" width="100%">
	    <tr>
		    <td style="HEIGHT: 15px" class="llblContentTitle">Server error : .Net has 
			    encountered some error...</td>
	    </tr>
	    <TR>
		    <TD vAlign="top" align="left" width="99%">
			    <asp:Label id="LblError" runat="server" ForeColor="MidnightBlue" Font-Size="8pt"></asp:Label>
		    </TD>
		    <TD vAlign="top" align="left" width="1%"></TD>
	    </TR>
    </TABLE>
</asp:Content>
