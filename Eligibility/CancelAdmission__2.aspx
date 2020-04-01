<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" Codebehind="CancelAdmission__2.aspx.cs" Inherits="StudentRegistration.Eligibility.CancelAdmission__2" Title="Cancel Admission" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
		.OFFGrid
		{
			background-color:#FFFFFF;
			font-family: Verdana;
			font-size: 8pt;
			font-weight: normal;
			width:100%;
		}
		.OFFGrid TR
		{
			background-color:#FFF;
		}
		.OFFGrid TR TH,OFFGrid TR TD
		{
			padding:3px;
		}
		.OFFGrid TR TH
		{
			font-weight:normal;
			background-color:#EBEBEB;
			vertical-align:top;
			border:solid 1px #dfdfdf;
			text-align:left;
			/*width:120px;*/
		}
		.OFFGrid TR TD
		{
			font-family: Verdana;
			font-size: 8pt;
			font-weight: normal;
			/*min-width:575px;
			width:575px;*/
			vertical-align:top;
			padding:3px;
			border:solid 1px #dfdfdf;
			background-color:#fff;
		}	
		.OFFGrid TR TH.CrTable
		{
			font-weight:normal;
			background-color:#EBEBEB;
			vertical-align:top;
			border:solid 1px #dfdfdf;
			text-align:left;
			/*width:300px;*/
		}		
		.cssImage
		{
			padding:5px;
		}
		.clNone
		{
			display:none;    
		}		
		.subHeading
		{
			padding:3px 3px 3px 5px;
			line-height:20px;
			font-size:11pt;
			font-family:Verdana;
			margin:0px 0px 0px 0px;
			letter-spacing:1px; 
			background-color: #EBEBEB;
			border: solid 1px #dfdfdf;  
			border-bottom-width:0px;
			width:98.5%;  
		}
		.tblContents
		{
			width:100%;    
		}
		.mergeProfiles
		{
			width: 95%; padding: 15px; margin: 10px 0px 10px 0px;height:100px;
			border-width: 1px; border-bottom: dashed 1px #c0c0c0; 
			border-top: dashed 1px #c0c0c0;background-color: #D8D8D8;
		}
		.mergeProfileChild
		{
			background-color:#fffacd;text-align:left;
			height: 80px;font-family:Verdana;
			filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#fffacd, endColorstr=#fffeee); 
			padding:10px 15px 10px 5px;
			text-align:justify;font-family:Verdana;font-size:9pt;
		}

	</style>
	<center>
		<table border="0" cellpadding="1" cellspacing="1" width="100%">
			<tr>
				<td align="left" colspan="2" style="border-bottom: 1px solid #FFD275;">
					<asp:Label ID="lblPageHead" runat="server" 
                        meta:resourcekey="lblPageHeadResource1"></asp:Label>
					<asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" 
                        meta:resourcekey="lblSubHeaderResource1"></asp:Label>
				</td>
			</tr>
			<tr>
				<td align="right" colspan="2" style="width: 100%;">
					<asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label>
				</td>
			</tr>
		</table>
        <br />
		<div id="divSummary" align="left" style="width: 700px;">
			<div align="left" class="subHeading">
				<b>:: Summary</b>
			</div>
			<div align="left" class="tblContents">
				<asp:Table ID="TBLSummery" runat="server" BorderWidth="0px" CellPadding="0" 
                    CellSpacing="0" CssClass="OFFGrid" meta:resourcekey="TBLSummeryResource1">
					<asp:TableRow ID="TableRow1" runat="server" 
                        meta:resourcekey="TableRow1Resource1">
						<asp:TableHeaderCell ID="TableHeaderCell1" runat="server" >
							<asp:Label ID="lblPRN" runat="server" Text="PRN" meta:resourcekey="lblPRNResource1"></asp:Label>
                        </asp:TableHeaderCell>
					</asp:TableRow>
					<asp:TableRow ID="TableRow2" runat="server" 
                        meta:resourcekey="TableRow2Resource1">
						<asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Text="Student Name" 
                            meta:resourcekey="TableHeaderCell2Resource1"></asp:TableHeaderCell>
					</asp:TableRow>
					<asp:TableRow ID="TableRow3" runat="server" 
                        meta:resourcekey="TableRow3Resource1">
						<asp:TableHeaderCell ID="TableHeaderCell3" runat="server" 
                            Text="Photograph & Signature" meta:resourcekey="TableHeaderCell3Resource1"></asp:TableHeaderCell>
					</asp:TableRow>
				</asp:Table>
			</div>
			<br />
		</div>	
        <div id="divCourse" runat="server" align="left" style="width:700px;">
            <div align="left" class="subHeading">
				<div style="float: left; width: 250px">
					<asp:Label ID="lblCourseProHead" runat="server" Font-Bold="True" 
                        Font-Names="Verdana" Font-Size="11pt" Text=":: Course Profile" meta:resourcekey="lblCourseProHeadResource1"></asp:Label></div>
			</div>
            <div align="left" class="tblContents">
            <table class="OFFGrid" id="table2" border="0px" cellpadding="0px" cellspacing="0px">
                <tr>
                    <th><asp:Label ID="lblCr" runat="server" Text="Course" meta:resourcekey="lblCrResource1"></asp:Label></th>
                    <td style="padding:0px;margin:0px;">
                        <div id="divCourseProfile" runat="server">
                            <asp:Repeater ID="RptCourse" runat="server" OnItemDataBound="RptCourse_ItemDataBound" OnItemCommand="RptCourse_ItemCommand">
                            <HeaderTemplate>                  
                                <div style="width: 575px; text-align: left;padding-bottom: 8px;" >
                                <table align="center" cellpadding="0px" cellspacing="0px" border="0px">
                            </HeaderTemplate>   
                            <ItemTemplate>
                                <tr id="separator" runat="server" height="8px" bgcolor="white">
                                <td id="Td1" colspan="6" runat="server"></td>
                                </tr>
                                <tr id="trHeader" runat="server">
                                    <th id="Th1" colspan="6" class="CrTable" runat="server">
                                        <b><%# DataBinder.Eval(Container.DataItem,"CourseName") %></b>
                                    </th>
                                </tr>
                                <tr id="tdHeader" runat="server">
                                    <td id="Td2" align="center" style="width:30%;" runat="server"><asp:Label ID="lblTr" runat="server" Text="Part/ Term" meta:resourcekey="lblTrResource1"></asp:Label></td>
                                    <td id="Td3" align="center" style="width:20%;" runat="server">Admission Form No.</td>
                                    <td id="Td4" align="center" style="width:15%;" runat="server">Admission Date</td>
                                    <td id="Td5" align="center" style="width:15%;" runat="server"><asp:Label ID="lbCc" runat="server" Text="College Code" meta:resourcekey="lbCcResource1"></asp:Label></td>
                                    <td id="Td6" align="center" runat="server">Cancel Admission&nbsp;</td>   
                                    <td id="Td9" runat="server">Reason for Cancel Admission</td>                                     
                                    <td id="Td19" style="display:none;" runat="server">
                                    <asp:Label ID="lblheadPRN" runat="server" Text="PRN" meta:resourcekey="lblheadPRNResource1"></asp:Label></td>
                                </tr>       
                                <tr>
                                    <td >
                                        <%# DataBinder.Eval(Container.DataItem,"CrName") %>
                                    </td>
                                    <td >
                                        <%# DataBinder.Eval(Container.DataItem, "AdmissionFormNo")%>&nbsp;
                                    </td>
                                    <td align="center">
                                        <%# DataBinder.Eval(Container.DataItem, "AdmissionDate")%>&nbsp;
                                    </td>
                                    <td >
                                        <%# DataBinder.Eval(Container.DataItem, "InstituteCode")%>
                                    </td>
                                    <td runat="server" id="tdlink" align="center">
                                        <asp:LinkButton runat="server" ID="btnDel" ForeColor="Navy" CommandName="CancelAdm"
                                        Text="Cancel Admission" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "STUDID") %>' 
                                            meta:resourcekey="btnDelResource1" />&nbsp;
                                    </td>  
                                    <td id="Td8" runat="server"  align="center">
                                         <asp:TextBox ID="txtReasonforCancellation" class="txtText" type="text" runat="server" TextMode="MultiLine"></asp:TextBox>&nbsp;
                                    </td>                                                              
                                    <td style="display:none;" id="td7">
                                    <asp:Label runat="server" ID="lblPRN" Text='<%# DataBinder.Eval(Container.DataItem, "PRN") %>'></asp:Label>
                                    </td>
                                </tr>  
                            </ItemTemplate>    
                            <FooterTemplate>           
                                </table>        
                                </div>
                            </FooterTemplate>
                            </asp:Repeater>
                            <input id="hid_Term_Count" runat="server" type="hidden" />
                        </div>
                    </td>
                </tr>                
            </table></div>
        </div>   
        <div style="padding:0px 0px 10px 0px;">
		    <div id="DIVMergeProfile" align="left" class="mergeProfiles">
			    <div class="mergeProfileChild">
                <asp:Label ID="lblCAInfo" runat="server"></asp:Label>                
			    </div>
		    </div>
        </div>        
	</center>
    <input id="hid_pk_Year" runat="server" type="hidden" />
	<input id="hid_Stud_Name" runat="server" type="hidden" />
	<input id="hid_PRN" runat="server" type="hidden" />
	<input id="hid_OldPRN" runat="server" type="hidden" />
	<input id="hid_pk_Student_ID" runat="server" type="hidden" />
	<input id="hid_eligiblityFN" runat="server" type="hidden" />
	<input id="hid_pk_Uni_ID" runat="server" type="hidden" />	
	<input id="hid_Inst_Details" runat="server" type="hidden" />
	<input id="hid_PRN_Number" runat="server" type="hidden" />
    <script language="javascript" type="text/javascript">
        function DisplayNote(id) {
            if (document.getElementById("<%=divCourseProfile.ClientID%>")) {
                id.style.display = "inline";
            }
        }

        function ShowConfirmBox(obj, crTermCount) {
            debugger;
            var obj = obj.replace("btnDel", "txtReasonforCancellation");
            var ControlID = document.getElementById(obj);
            if (ControlID != null) {
                if (ControlID.value == "") {
                    showValidationSummary('', 'Please enter reason for cancel Admission.');
                    return false;
                }
                else {
                    var obj = obj.replace("txtReasonforCancellation", "btnDel");
                    if (document.getElementById("<%=hid_Term_Count.ClientID%>").value == "1") {
                        ShowConfirm(obj, 'Are you sure you want to Cancel the Admission for this term as this is the only term associated with this Student?');
                    }
                    else {
                        if (crTermCount == "1") {
                            ShowConfirm(obj, 'Are you sure you want to Cancel the Admission for this term as this is the only term associated with the <%=lblCr.Text %>?');
                        }
                        else {
                            ShowConfirm(obj, 'Are you sure you want to Cancel the Admission for this Term?');
                        }
                    }
                    return false;
                }
            }
        }
    </script>
</asp:Content>
