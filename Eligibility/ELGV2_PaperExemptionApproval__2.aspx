<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_PaperExemptionApproval__2.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperExemptionApproval__2" %>

<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>

    <script language="javascript" type="text/javascript" src="/JS/jsAjaxMethod.js"></script>

    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>

    <script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>

    <script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>

    <script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>

    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>

    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

    <script language="javascript" src="ajax/StudentRegistration.Eligibility.AjaxMethods,StudentRegistration.ashx"></script>

    <script type="text/javascript" src="../../ajax/StudentRegistration.Eligibility.clsEligibilityDBAccess,StudentRegistration.ashx"></script>

    <script type="text/javascript">
    function multiselect()
                {   
                    var arr=new Array();
                    arr=document.getElementById("<%= GVPaperTLMAMAT.ClientID%>").getElementsByTagName("input");
                    
                    if(arr[0].checked)
                    {
                        for(i=0;i<arr.length;i++)
                        {
                            arr[i].checked=true;
                        }       
                    }
                    else
                    {
                        for(i=0;i<arr.length;i++)
                        {
                            arr[i].checked=false;
                        }                        
                    }
                }
    
    function validateAllowDenyNext(allowOrDeny)
                    {
                        var i=-1;
                        var myArr = new Array();
                        var flag=false;
                        var arr=new Array();
                        arr=document.getElementById('<%=GVPaperTLMAMAT.ClientID%>').getElementsByTagName("input");
                        for(var j=0;j<arr.length;j++)
                        {
                            if(arr[j].checked)
                            {
                                flag=true;
                                document.getElementById("<%= hidPaperTLMAMAT.ClientID%>").value="Y";
                                break;
                            }
                         }
                         if(!flag)
                         {
                            document.getElementById("<%= hidPaperTLMAMAT.ClientID%>").value="";
                            myArr[++i]  = new Array(document.getElementById("<%= hidPaperTLMAMAT.ClientID%>"),"Empty","Please select at least one student before proceeding.","text");
                         }
                        
                        var ret=validateMe(myArr,50);  
                        var ch;
                        if(ret)
                        {   
                                if(allowOrDeny==1)
                                {
                                    ch=confirm("Are you sure you want to grant the Exemption Claimed for the selected "+document.getElementById('<%=lblPaper.ClientID %>').innerText+"(s)?");
                                }
                                else if(allowOrDeny==2)
                                {
                                    ch=confirm("Are you sure you want to deny the Exemption Claimed for the selected "+document.getElementById('<%=lblPaper.ClientID %>').innerText+"(s)?");
                                }
                            return ch;
                        }  
                        else
                        {
                            return ret;
                        }
	                }
    </script>

    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table style="border-collapse: collapse" id="table3" bordercolor="#c0c0c0" cellpadding="2"
                width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="width: 705px; border-bottom: #ffd275 1px solid" align="left">
                            <asp:Label ID="lblPageHead" runat="server" meta:resourceKey="lblPageHeadResource1"
                                Text="List of Exemption Claimed Students"></asp:Label>
                            <asp:Label ID="lblGVPapersHeading" runat="server" meta:resourceKey="lblAcaYearResource1" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: none; margin-left: 2px; width: 100%; position: relative; height: 30px;
                                text-align: right" id="divMsg" runat="server">
                                <asp:Label ID="lblAppOrDenyMsg" runat="server" Width="100%" CssClass="saveNote" meta:resourcekey="lblAppOrDenyMsgResource1"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: none; margin-left: 2px; width: 100%; position: relative; text-align: left"
                                id="divResultPageDetails" runat="server">
                                <asp:Label ID="lblRes" runat="server" Text="Result:" Font-Bold="True" meta:resourcekey="lblResResource1"></asp:Label>
                                <asp:Label ID="lblStudCount" runat="server" meta:resourcekey="lblStudCountResource1"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <div style="display: none; margin-left: 0px; width: 99%; position: relative; text-align: left"
                                    id="divTLMAMATChoice" runat="server">
                                    <fieldset>
                                        <legend>To select specific TLM-AM-AT click below</legend>
                                        <asp:CheckBoxList ID="chkTLMAMAT" runat="server" Width="100%" DataTextField="TLM-AM-AT"
                                            DataValueField="TLM-AM-AT-ID" AutoPostBack="True" OnSelectedIndexChanged="divTLMAMATChoice_SelectedIndexChanged"
                                            RepeatDirection="Horizontal" meta:resourcekey="chkTLMAMATResource1">
                                        </asp:CheckBoxList>
                                    </fieldset>
                                </div>
                            </center>
                            <div style="margin-top: 1px; display: none; margin-left: 2px; width: 99%; position: relative"
                                id="divPaperTLMAMAT" runat="server">
                                <asp:GridView Style="border-top-style: double; border-right-style: double; border-left-style: double;
                                    border-collapse: collapse; border-bottom-style: double" ID="GVPaperTLMAMAT" runat="server"
                                    Width="100%" CssClass="clGrid grid-view" AllowPaging="True" BorderStyle="None" CellPadding="2" DataKeyNames="TLM-AM-AT-ID,pk_Student_ID,pk_Pp_PpHead_CrPrCh_ID,pk_Fac_ID,pk_Cr_ID,pk_MoLrn_ID,pk_Ptrn_ID,pk_Brn_ID,pk_CrPr_Details_ID,pk_CrPrCh_ID,pk_Uni_ID,pk_Year,fk_AcademicYear_ID, Ref_InstReg_Institute_ID"
                                    AutoGenerateColumns="False" OnPageIndexChanging="GVPaperTLMAMAT_PageIndexChanging"
                                    OnRowDataBound="GVPaperTLMAMAT_RowDataBound" meta:resourcekey="GVPaperTLMAMATResource1">
                                    <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:BoundField DataField="Sr. No" HeaderText="Sr. No." meta:resourcekey="BoundFieldResource1">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Student Name" HeaderText="Student Name" meta:resourcekey="BoundFieldResource2">
                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PRN_Number" HeaderText="PRN" meta:resourcekey="BoundFieldResource3">
                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Paper TLM-AM-AT" HeaderText="Paper TLM-AM-AT" meta:resourcekey="BoundFieldResource4">
                                            <ItemStyle HorizontalAlign="Center" Width="40%" />
                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource1">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" meta:resourcekey="CheckBox1Resource1" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <center>
                                                    <asp:CheckBox ID="chkSelectStudents" runat="server" meta:resourcekey="chkSelectStudentsResource1" />
                                                </center>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#E0E0E0" VerticalAlign="Middle"
                                                CssClass="gridHeader" Font-Bold="True" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="display: none; margin-left: 2px; width: 99%; position: relative" id="divEndButtons"
                                runat="server">                                
                            </div>
                            <center>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="height: 20px">
                                                    <asp:Button ID="btnApprove" OnClick="btnApproveOrDeny_Click" runat="server" Text="Grant"
                                                        CssClass="butSubmit" OnClientClick="return validateAllowDenyNext(1)" meta:resourcekey="btnApproveResource1"></asp:Button></td>
                                                <td style="height: 20px">
                                                    <asp:Button ID="btnDeny" OnClick="btnApproveOrDeny_Click" runat="server" Text="Deny"
                                                        CssClass="butSubmit" OnClientClick="return validateAllowDenyNext(2)" meta:resourcekey="btnDenyResource1"></asp:Button></td>
                                                <td style="height: 20px">
                                                    <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Text="Back to Paper Selection"
                                                        CssClass="butSubmit" meta:resourcekey="btnBackResource1"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="display: none" id="tblExportedDataMsg" width="100%" runat="server">
                                    <tr id="Tr1" runat="server">
                                        <td style="height: 30px" id="Td1" align="left" runat="server">
                                            <asp:Label ID="lblExportedData" runat="server" CssClass="errorNote" meta:resourcekey="lblExportedDataResource1"></asp:Label>
                                        </td>
                                    </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <input id="hidInstID" type="hidden" runat="server" />
            <input id="hid_fk_AcademicYr_ID" type="hidden" runat="server" />
            <input id="hidUniID" type="hidden" runat="server" />
            <input id="hidFacID" type="hidden" runat="server" />
            <input id="hidCrID" type="hidden" runat="server" />
            <input id="hidMoLrnID" type="hidden" runat="server" />
            <input id="hidPtrnID" type="hidden" runat="server" />
            <input id="hidBrnID" type="hidden" runat="server" />
            <input id="hidCrPrDetailsID" type="hidden" runat="server" />
            <input id="hidCrPrChID" type="hidden" runat="server" />
            <input id="hidPapers" type="hidden" runat="server" />
            <input id="hidPaperTLMAMAT" type="hidden" runat="server" />
            <input id="hidSelPaper" type="hidden" runat="server" />
            <input id="hidSelTLMAmAt" type="hidden" runat="server" />
            <input id="hidHead" type="hidden" runat="server" />
            <input id="hidTLMIDs" type="hidden" runat="server" />
            <input id="hidAMIDs" type="hidden" runat="server" />
            <input id="hidATIDs" type="hidden" runat="server" />
            <input type="hidden" runat="server" id="hidAcYrForCollLogin" />
            <input type="hidden" runat="server" id="hidCollName" />
             <input id="hidExamFormModifyReq" runat="server" type="hidden" />
               <input type="hidden" runat="server" id="hidYearID" />
            <input type="hidden" runat="server" id="hidStudentID" />
            <asp:Label Style="display: none" ID="lblPaper" runat="server" Text="Paper"
                meta:resourcekey="lblPaperResource1"></asp:Label>
                <asp:Label Style="display: none" ID="lblCourse" runat="server" Text="Course"
                meta:resourcekey="lblCourseResource1"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnBack" />
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
</asp:Content>