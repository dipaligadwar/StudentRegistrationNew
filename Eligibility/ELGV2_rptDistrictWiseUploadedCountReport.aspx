<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_rptDistrictWiseUploadedCountReport.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptDistrictWiseUploadedCountReport" meta:resourcekey="PageResource1" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<ContentTemplate>

    <script type="text/javascript">
    //validate academic year
   
          function validateYear()
	            {
	                var flag=false;
	                var i=-1;
	                var myArr = new Array();  		    
	                myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYr.ClientID%>"),"0","Please Select Academic Year.","select");
	                var ret=validateMe(myArr,50); 	                	               
	                return ret;
	            }
	            
	            function clearLabel()
	            {
	                document.getElementById("<%= lblNoRec.ClientID%>").style.display='none';	                
	            }	  
	            
	           	            
	            
    </script>
    <table style="border-collapse: collapse" id="table2" bordercolor="#c0c0c0" cellpadding="2"
        width="100%" border="0">
        <tbody>
            <tr>
                <td class="FormName" align="left" width="100%">
                    <asp:label runat="server" text="Districtwise Uploaded count" font-bold="True"
                        id="lblPageHead" meta:resourcekey="lblPageHeadResource1"></asp:label>
                    <asp:label runat="server" font-bold="True" font-size="Small" id="lblAcaYear" meta:resourcekey="lblAcaYearResource1"></asp:label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <div runat="server" id="divAcademicYr" style="width: 90%; azimuth: center">
                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td align="right" colspan="3">
                                        <asp:Label ID="lblMessage" runat="server" CssClass="saveNote" Text="Report Generated Successfully"
                                            style="display: none" meta:resourcekey="lblMessageResource1"></asp:Label>
                                        <asp:Label ID="lblError" runat="server" CssClass="errorNote" Text="There was an error in Report Generation. Please try again later."
                                            style="display: none" meta:resourcekey="lblErrorResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 225px; height: 20px" align="right">
                                        <asp:label runat="server" text="Select Academic Year" font-bold="True" width="221px"
                                            id="lblAcyr" meta:resourcekey="lblAcyrResource1"></asp:label>
                                    </td>
                                    <td style="width: 1%; height: 20px" align="center">
                                        <b>&nbsp;:&nbsp;</b></td>
                                    <td runat="server" id="tdAcdYr" style="height: 20px" align="left">
                                        <asp:dropdownlist runat="server" cssclass="selectbox" width="245px" id="ddlAcademicYr"
                                            meta:resourcekey="ddlAcademicYrResource1" onchange="clearLabel()">
                                            <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1">
                                            </asp:ListItem>
                                        </asp:dropdownlist>
                                        <font class="Mandatory">*</font></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" CssClass="butSubmit"
                        OnClick="btnGenerate_Click" OnClientClick="return validateYear()" 
                        meta:resourcekey="btnGenerateResource1" />
                </td>
            </tr>

            
            <tr>
                <td align="left">       
                    <br />         
                    <asp:Label ID="lblNoRec" runat="server" CssClass="errorNote" Text="No Record(s) Found."
                        style="display: none" meta:resourcekey="lblNoRecResource1" />
                </td>
            </tr>
            <tr>
            <td align="left">
            <br />
            <asp:Label ID="lblNote" runat="server" CssClass="errorNote" 
                    meta:resourcekey="lblNoteResource1"> Note: Please select the Academic Year and click on 'Generate Report' button to get the report in Excel file format.
</asp:Label>
            </td>
            
            </tr>
        </tbody>
    </table>
   
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"  AsyncRendering="False" Width="100%" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"  WaitMessageFont-Size="14pt"
            Height="600px"  meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.DistrictWiseUplStudCountWithOutRCcode.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    <asp:Label runat="server" Style="display: none" Text="College" ID="lblCollege" meta:resourceKey="lblCollegeResource1"></asp:Label>
    <asp:Label runat="server" Style="display: none" Text="Course" ID="lblCr" meta:resourceKey="lblCrResource1"></asp:Label>
    <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden" />
</ContentTemplate>
    &nbsp;&nbsp;
   
</asp:Content>
