<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_rptMIS.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptMIS" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--<script type="text/javascript">
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
	            
    </script>--%>
    <style type="text/css">
      .hidden-column {
        display: none;
      }
       </style>
    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table2" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="FormName" align="left" width="100%">
                            <asp:Label runat="server" Text="Uploaded Students MIS for" Font-Bold="True" ID="lblPageHead" meta:resourceKey="lblPageHeadResource2"></asp:Label>
                            <asp:Label runat="server" Font-Bold="True" Font-Size="Small" ID="lblAcaYear" meta:resourceKey="lblAcaYearResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            <%--<div runat="server" id="divAcademicYr" style="width: 90%; azimuth: center">
                                &nbsp;&nbsp;
                                <div runat="server" id="tblAcademicYr" align="center">
                                    <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="height: 20px" colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 225px; height: 20px" align="right">
                                                    <asp:Label runat="server" Text="Select Academic Year" Font-Bold="True" Width="221px"
                                                        ID="lblAcyr" meta:resourceKey="lblAcyrResource1"></asp:Label>
                                                </td>
                                                <td style="width: 1%; height: 20px" align="center">
                                                    <b>&nbsp;:&nbsp;</b></td>
                                                <td runat="server" id="tdAcdYr" style="height: 20px" align="left">
                                                    <asp:DropDownList runat="server" CssClass="selectbox" Width="245px" ID="ddlAcademicYr"
                                                        meta:resourceKey="ddlAcademicYrResource1">
                                                        <asp:ListItem Text="--- Select ---" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <font class="Mandatory">*</font></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>--%>
                            <br />
                            <div id="divYCMOU" runat="server">
                                <uc3:YCMOU ID="YCMOU" runat="server"></uc3:YCMOU>
                            </div>
                            <br />
                            <%--<center>
                                <asp:Button runat="server" OnClientClick="return validateYear()" Text="Next &gt;&gt;"
                                    CssClass="butSubmit" ID="BtnSubmit" meta:resourceKey="BtnSubmitResource1" OnClick="btnNext_Click">
                                </asp:Button>
                            </center>--%>
                            <center>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Button runat="server" Text="Export to Excel" CssClass="butSubmit" ID="Button3"
                                                    Style="display: none" OnClick="btnExportToExcel_Click"></asp:Button>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Export to PDF" CssClass="butSubmit" ID="btnPDF"
                                                    Style="display: none" OnClick="btnPDF_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </center>
                            <div runat="server" id="divDGStat" style="display: none; position: relative;">
                                <center>
                                </center>
                                <br />
                                <br />
                                <asp:GridView runat="server" AutoGenerateColumns="False" DataKeyNames="pk_Inst_ID"
                                    ShowFooter="True" BorderStyle="None" CssClass="clGrid grid-view"  ID="GVStat"
                                    meta:resourceKey="GVStatResource1" OnRowDataBound="GVStat_RowDataBound" OnRowCommand="GVStat_RowCommand"
                                    Style="border-style: Double; border-collapse: collapse;">
                                    <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex)+1 %>.
                                            </ItemTemplate>
                                            <HeaderStyle Width="7%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="4%"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CommandName="showHide" CommandArgument='<%# Eval("pk_Inst_ID") %>'
                                                    ID="lnkPlus" EnableViewState="true">
                                                    <asp:Image runat="server" AlternateText="Click to show details" ImageUrl="../Images/plus.gif"
                                                        ID="imgdiv"></asp:Image>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="District" HeaderText="District" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Taluka" HeaderText="Taluka" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="City" HeaderText="City" >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RegionalCenterInfo" HeaderText="Regional Center" meta:resourceKey="BoundFieldResourceRegionalCenterInfo">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CollegeCode" HeaderText="College Code" meta:resourceKey="BoundFieldResource27">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CollegeName" HeaderText="College Name" SortExpression="College Name"
                                            meta:resourceKey="BoundFieldResource28">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Totaluploadeddata" HeaderText="Total Uploaded Data"
                                            meta:resourceKey="BoundFieldResource30">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotalEligibilityProcessed" HeaderText="Total Eligibility Processed"
                                            SortExpression="Total uploaded data" meta:resourceKey="BoundFieldResource31">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Eligiblitynotprocessed" HeaderText="Eligiblity Not Processed"
                                            SortExpression="Eligiblity not processed" meta:resourceKey="BoundFieldResource33">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DuplicateStudentCount" HeaderText="Duplicate Student Count"
                                            SortExpression="Duplicate Student Count" meta:resourceKey="BoundFieldResource34">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PaperDiscrepancyCount" HeaderText="Paper Discrepancy Count"
                                            SortExpression="Paper Discrepancy Count" meta:resourceKey="BoundFieldResource35">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField meta:resourceKey="TemplateFieldResource3">
                                            <ItemTemplate>
                                                <tr>
                                                    <td colspan="13">
                                                        <div runat="server" id="divHideMeCourse" align="center" style="display: none; position: relative;
                                                            width: 100%;">
                                                            <div runat="server" id="divCourseInnerHide" style="display: none; left: 10px;">
                                                                <br />
                                                                <asp:GridView runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="clGrid grid-view"
                                                                    Width="94%" ID="GVInner" Style="border-color: #FFD275; display: none; border-style: Double;
                                                                    border-collapse: collapse;" meta:resourceKey="GVInnerResource1">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Course Name" HeaderText="Course Name" meta:resourcekey="BoundFieldResource1">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"
                                                                                Width="50%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Total intake capacity" HeaderText="Total Intake Capacity">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Total uploaded data" HeaderText="Total Uploaded Data"
                                                                            meta:resourceKey="BoundFieldResource30">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Total Eligibility Processed" HeaderText="Total Eligibility Processed"
                                                                            SortExpression="Total uploaded data" meta:resourceKey="BoundFieldResource31">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Eligiblity not processed" HeaderText="Eligiblity Not Processed"
                                                                            SortExpression="Eligiblity not processed" meta:resourceKey="BoundFieldResource33">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Duplicate Student Count" HeaderText="Duplicate Student Count"
                                                                            SortExpression="Duplicate Student Count" meta:resourceKey="BoundFieldResource34">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Paper Discrepancy Count" HeaderText="Paper Discrepancy Count"
                                                                            SortExpression="Paper Discrepancy Count" meta:resourceKey="BoundFieldResource35">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>
                                                                    <RowStyle CssClass="gridItem"></RowStyle>
                                                                </asp:GridView>
                                                            </div>
                                                            <br />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E0E0E0"
                                                CssClass="hidden-column"></HeaderStyle>
                                            <ItemStyle CssClass="hidden-column"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Large"></FooterStyle>
                                    <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader"></HeaderStyle>
                                </asp:GridView>
                            </div>
                            <table runat="server" id="tblExportedDataMsg" style="display: none">
                                <tr runat="server" id="Tr2">
                                    <td runat="server" id="Td2" style="height: 30px" align="left">
                                        <asp:Label runat="server" CssClass="errorNote" ID="lblExportedData" meta:resourceKey="lblExportedDataResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <input runat="server" id="hidUniID" type="hidden" />
            <input runat="server" id="hidInstID" type="hidden">
            <input runat="server" id="hid_AcademicYear" type="hidden" />
            <input runat="server" id="hid_fk_AcademicYr_ID" type="hidden" />
            <asp:Label runat="server" Style="display: none" Text="College" ID="lblCollege" meta:resourceKey="lblCollegeResource1"></asp:Label>
            <asp:Label runat="server" Style="display: none" Text="Course" ID="lblCr" meta:resourceKey="lblCrResource1"></asp:Label>
            <asp:Label runat="server" Style="display: none" Text="Paper" ID="lblPaper" meta:resourceKey="lblPaperResource1"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button3" />
            <asp:PostBackTrigger ControlID="btnPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="divUP" runat="server">
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </div>
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"   AsyncRendering="False" Width="100%" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"  WaitMessageFont-Size="14pt"
            Height="600px" meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.MIS.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
