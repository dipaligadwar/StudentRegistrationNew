<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_PaperExemptionApproval__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperExemptionApproval__1" %>

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
    function validatePaperNext()
                {
                    var i=-1;
                    var count=0;
                    var myArr = new Array();
                    var flag=false;
                    var arr=new Array();
                    arr=document.getElementById('<%=GVPapers.ClientID%>').getElementsByTagName("input");
                    for(var j=0;j<arr.length;j++)
                    {
                        if(arr[j].checked)
                        {                           
                            count++;
                            document.getElementById("<%= hidPapers.ClientID%>").value="Y";
                            if(count>1)
                                break;
                        }                            
                     }
                     if(count==1)flag=true;
                     if(!flag)
                     {
                        document.getElementById("<%= hidPapers.ClientID%>").value="";
                        myArr[++i]  = new Array(document.getElementById("<%= hidPapers.ClientID%>"),"Empty","Please select one "+document.getElementById('<%=lblPaper.ClientID %>').innerText+" for proceeding.","text");
                     }
                    
                    var ret=validateMe(myArr,50);    
                    return ret;
	            }
	            
	            function validatePaperTLMAMATSelection(denyAll)
                {
                    var i=-1;
                    var count=0;
                    var myArr = new Array();
                    var flag=false;
                    var arr=new Array();
                    arr=document.getElementById('<%=chkTLMAMAT.ClientID%>').getElementsByTagName("input");
                    for(var j=0;j<arr.length;j++)
                    {
                        if(arr[j].checked)
                        {                           
                            count++;
                            document.getElementById("<%= hidPapersTLMAMAT.ClientID%>").value="Y";
                            if(count>=1)
                            {
                                flag=true;
                                break;
                            }
                        }                            
                     }                     
                     if(!flag)
                     {
                        document.getElementById("<%= hidPapersTLMAMAT.ClientID%>").value="";
                        myArr[++i]  = new Array(document.getElementById("<%= hidPapersTLMAMAT.ClientID%>"),"Empty","Please select at least one "+document.getElementById('<%=lblPaper.ClientID %>').innerText+ " TLM-AM-AT for proceeding.","text");
                     }
                    
                    var ret=validateMe(myArr,50);   
                    var ch;
                    if(ret)
                    {   
                       if(denyAll==1)
                       {
                           ch=confirm("Are you sure you want to deny the Exemption Claimed for the selected "+document.getElementById('<%=lblPaper.ClientID %>').innerText+"(s)?");                                       
                           return ch;
                       }  
                       else
                       {
                            return ret;
                       }   
                   }  
                   else
                   {
                            return ret;
                   }                
	            }
	            
	            function chkSelectApps_click(curr_chk)
	            {
	               arr=document.getElementById('<%=GVPapers.ClientID%>').getElementsByTagName("input");
                    for(var j=0;j<arr.length;j++)
                    {
                        arr[j].checked = false;        
                     }
                     document.getElementById(curr_chk).checked = true;
                     //curr_chk.checked = true;
	                 document.getElementById("<%= divTLMAMATChoice.ClientID%>").style.display = "none";
	                 document.getElementById("<%= lblAppOrDenyMsg.ClientID%>").style.display = "none";
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
                                Text="Paper Exemption Approval"></asp:Label>
                            <asp:Label ID="lblAcaYear" runat="server" meta:resourceKey="lblAcaYearResource1"
                                Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: none; margin-left: 2px; width: 99%; position: relative; text-align: left"
                                id="divPapers" runat="server">
                                <asp:Label Style="font-size: 10pt; color: #ee6340" ID="lblGVPapersHeading" runat="server"
                                    Text="List of exemption claimed papers" meta:resourcekey="lblGVPapersHeadingResource1"
                                    CssClass="errorNote" Width="100%"></asp:Label>
                                <br />
                                <asp:GridView Style="border-top-style: double; border-right-style: double; border-left-style: double;
                                    border-collapse: collapse; border-bottom-style: double" ID="GVPapers" runat="server"
                                    meta:resourcekey="GVPapersResource1" CssClass="clGrid grid-view" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="pk_Pp_PpHead_CrPrCh_ID" CellPadding="2"
                                    BorderStyle="None" OnRowDataBound="GVPapers_RowDataBound">
                                    <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderText="Sr. No">
                                            <ItemStyle Width="4%" />
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex)+1 %>.
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PpNamePpCode" HeaderText="Paper Name (Paper Code)" meta:resourcekey="BoundFieldResource1">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Student Count" HeaderText="Student Count" meta:resourcekey="BoundFieldResource2">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="2%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource1">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" meta:resourcekey="CheckBox1Resource1" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <center>
                                                    <asp:CheckBox ID="chkSelectApps" onclick="chkSelectApps_click(this.id)" runat="server"
                                                        meta:resourcekey="chkSelectAppsResource1" />
                                                </center>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#E0E0E0" VerticalAlign="Middle"
                                                CssClass="gridHeader" Font-Bold="True" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <center>
                                <asp:Button Style="display: none" ID="btnPaperNext" OnClick="btnPaperNext_Click"
                                    runat="server" Text="Next >>" meta:resourcekey="btnPaperNextResource1" CssClass="butSubmit"
                                    OnClientClick="return validatePaperNext()"></asp:Button>
                            </center>
                            <div style="display: none; margin-left: 2px; width: 100%; position: relative; height: 30px;
                                text-align: right" id="divMsg" runat="server">
                                <asp:Label ID="lblAppOrDenyMsg" runat="server" meta:resourcekey="lblAppOrDenyMsgResource1"
                                    CssClass="saveNote" Width="100%"></asp:Label>
                            </div>
                            <center>
                                <div style="display: none; margin-left: 0px; width: 99%; position: relative; text-align: left"
                                    id="divTLMAMATChoice" runat="server">
                                    <fieldset>
                                        <legend>To select specific TLM-AM-AT click below</legend>
                                        <asp:CheckBoxList ID="chkTLMAMAT" runat="server" meta:resourcekey="chkTLMAMATResource1"
                                            Width="100%" RepeatDirection="Horizontal" DataValueField="TLM-AM-AT-ID" DataTextField="TLM-AM-AT">
                                        </asp:CheckBoxList>
                                        <br />
                                        <br />
                                        <center>
                                            <table width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnDenyAll" OnClick="btnDenyAll_Click" runat="server" Text="Deny Exemption For All Students"
                                                                meta:resourcekey="btnDenyAllResource1" CssClass="butSubmit" OnClientClick="return validatePaperTLMAMATSelection(1)">
                                                            </asp:Button></td>
                                                        <td>
                                                            <asp:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" Text="Select Students For Exemption Grant/Denial"
                                                                meta:resourcekey="btnSelectResource1" CssClass="butSubmit" OnClientClick="return validatePaperTLMAMATSelection()">
                                                            </asp:Button></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </fieldset>
                                </div>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="display: none" id="tblExportedDataMsg" width="100%" runat="server">
                                <tbody>
                                    <tr id="Tr1" runat="server">
                                        <td style="height: 30px" id="Td1" align="left" runat="server">
                                            <asp:Label ID="lblExportedData" runat="server" meta:resourcekey="lblExportedDataResource1"
                                                CssClass="errorNote"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
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
            <input id="hidCollName" type="hidden" runat="server" />
            <input id="hidPapersTLMAMAT" type="hidden" runat="server" />
            <input id="hidPaperTLMAMAT" type="hidden" runat="server" />
            <input id="hidSelPaper" type="hidden" runat="server" />
            <input id="hidSelTLMAmAt" type="hidden" runat="server" />
            <input id="hidHead" type="hidden" runat="server" />
            <input id="hidTLMIDs" type="hidden" runat="server" />
            <input id="hidAMIDs" type="hidden" runat="server" />
            <input id="hidATIDs" type="hidden" runat="server" />
            <input id="hidAcYrForCollLogin" type="hidden" runat="server" />
            <asp:Label Style="display: none" ID="lblPaper" runat="server" Text="Paper" meta:resourcekey="lblPaperResource1"></asp:Label>
            <asp:Label Style="display: none" ID="lblCourse" runat="server" Text="Course" meta:resourcekey="lblCourseResource1"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSelect"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
</asp:Content>
