<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master"  CodeBehind="ELGV2_ManualProcess_reg_Students.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_ManualProcess_reg_Students" %>
<%@ Register Src="WebCtrl/searchInstNew.ascx" TagName="searchInstNew" TagPrefix="uc2" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	
		<script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
		<script language="javascript" type="text/javascript" src="/JS/change.js"></script>

			<CENTER> 
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2" 
					width="700" border="0"> 
					
					<tr> 
						
						<%--<TD class="FormName" align="left" vAlign="middle">
						<asp:label id="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead">Manual Process Eligibility</asp:label>--%>
						
						<td align="left" style="border-bottom: 1px solid #FFD275;">
                        <asp:Label ID="lblPageHead" runat="server" Text="Manual Process Eligibility" ></asp:Label>
						</TD> 
					</tr> 
					<TR> 						
						<td valign="top" align="center"> 
							<P><table width="100%" cellpadding="0" cellspacing="0" border="0" id="tblUserControl">
                                    <tr style="height:10px;"><td></td></tr>
                                    <tr>
                                        <td vAlign="top" align="center" style="width :80%">
                                            <uc2:searchInstNew ID="SchInst1" runat="server"/>
                                        </td>
                                    </tr>
                                 </table>
                                 <p style="azimuth:center"><asp:label id="lblGridName" runat="server" cssclass="GridSubHeading" width="95%" height="18px"></asp:label></p>
                                 <p style="azimuth:center"><asp:datagrid id="dgData" runat="server" cssclass="grid" width="95%" autogeneratecolumns="False"
	                                    allowpaging="True" pagesize="25" >
	                                    <%--<alternatingitemstyle cssclass="gridAltItem"></alternatingitemstyle>--%>
	                                    <itemstyle cssclass="gridItem"></itemstyle>
	                                    <columns>
		                                    <asp:buttoncolumn text="&lt;img border='0' src='../images/pencil.gif' width='16' height='16'&gt;" headertext="Select"
			                                    commandname="lnkButSelect">
			                                    <headerstyle width="5%" cssclass="gridHeader"></headerstyle>
			                                    <itemstyle font-bold="True" horizontalalign="Center" forecolor="#FF3333" verticalalign="Middle"></itemstyle>
		                                    </asp:buttoncolumn>
		                                    <asp:boundcolumn visible="False" datafield="pk_Inst_ID" headertext="pk_Inst_ID">
			                                    <headerstyle width="0%" cssclass="gridHeader" HorizontalAlign=Center></headerstyle>
		                                    </asp:boundcolumn>
		                                    <asp:boundcolumn datafield="InstName" headertext="Name">
			                                    <headerstyle width="80%" cssclass="gridHeader" HorizontalAlign=Center></headerstyle>
		                                    </asp:boundcolumn>
		                                    <asp:boundcolumn datafield="InstTy_Name" headertext="Type">
			                                    <headerstyle width="15%" cssclass="gridHeader" HorizontalAlign=Center></headerstyle>
		                                    </asp:boundcolumn>
	                                    </columns>
	                                    <pagerstyle verticalalign="Middle" font-bold="True" horizontalalign="Right" mode="NumericPages"></pagerstyle>
                                    </asp:datagrid></p>
                                   <div align="center"><asp:label id="lblData" runat="server" forecolor="Tomato" font-bold="True" width="99%" visible="False">No Record Found</asp:label>&nbsp;</div>
                                   <input id="hidInstID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidInstID" runat="server"/>
                                   <input id="hidUniID" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" name="hidUniID" runat="server"/></P> 
                                   <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
						</td> 
					</TR> 
					 
				</TABLE> 
			</CENTER> 
		
</asp:Content>
