<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_rptDiscrepancyReport.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptDiscrepancyReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="WebCtrl/Progress_Control.ascx" TagName="Progress_Control" TagPrefix="uc2" %>
<%@ Register Src="WebCtrl/SelectSingleCourse.ascx" TagName="YCMOU" TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="../JS/Validations.js"></script>
    <script type="text/javascript" language="jscript" src="../jscript/calendar.js"> </script>
    <script type="text/javascript" language="jscript" src="../jscript/calendar-en.js"> </script>
    <script type="text/javascript" language="javascript" src="../jscript/InitCalendarFunc.js"> </script>
    <script language="javascript" type="text/javascript" src="ajax/common.ashx"></script>
    <script language="javascript" type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>
    <script type="text/javascript" src="ajax/StudentRegistration.Eligibility.clsEligibilityDBAccess,StudentRegistration.ashx"></script>
    <%--<script type="text/javascript">
               //validate academic year
//               function validateYear()
//	            {
//	                var flag=false;
//	                var i=-1;
//	                var myArr = new Array();  		    
//	                myArr[++i]  = new Array(document.getElementById("<%= ddlAcademicYr.ClientID%>"),"0","Please Select Academic Year.","select");
//	                var ret=validateMe(myArr,50); 	                                
//	                return ret;
//	            }	            
//	       
//	        
//	         //validate next click for all colleges report
//             function courseValidate()
//             {	    var i=-1; 
//		            var myArr   = new Array(); 
//		            myArr[++i]  = new Array(document.getElementById("<%=ddlAcademicYr.ClientID%>"),"0","Please Select Academic Year.","select");
//                    myArr[++i]  = new Array(document.getElementById("<%=ddlFacDesc.ClientID%>"),-1,"Please Select "+document.getElementById('<%=lblFacultyNm.ClientID%>').innerText,"select"); 
//	                myArr[++i]  = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"),-1,"Please Select "+document.getElementById('<%=lblSelectCr.ClientID%>').innerText,"select"); 
//	                if(document.getElementById("<%=ddlCrDesc.ClientID%>")[document.getElementById("<%=ddlCrDesc.ClientID%>").selectedIndex].text=="--- Select ---")
//	                myArr[++i]  = new Array(document.getElementById("<%=ddlCrDesc.ClientID%>"),0,"Please Select "+document.getElementById('<%=lblSelectCr.ClientID%>').innerText,"select"); 

//		            if(document.getElementById("<%=ddlCrBrnDesc.ClientID%>")[document.getElementById("<%=ddlCrBrnDesc.ClientID%>").selectedIndex].text!= "No Branch Available")
//		                myArr[++i]= new Array(document.getElementById("<%=ddlCrBrnDesc.ClientID%>"),-1,"Please Select Branch","select"); 
//		            myArr[++i] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"),-1,"Please Select " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part", "select");
//    		       	if(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>")[document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>").selectedIndex].text=="--- Select ---")
//    		       	    myArr[++i] = new Array(document.getElementById("<%=ddlCrPrDetailsDesc.ClientID%>"),0,"Please Select " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part", "select");

//                    //validation for 2 terms selection
//                    if(document.getElementById("<%=chkChild.ClientID%>")!=null && document.getElementById("<%=trTerm.ClientID%>").style.display!='none')
//                    {
//                        var chkTerms = document.getElementById("<%=chkChild.ClientID%>").getElementsByTagName("input");
//                        var count=0;                   
//                        var twoChecked=false;
//                        document.getElementById("<%=hidTermSelection.ClientID%>").value="";
//                         for (var i = 0; i < chkTerms.length; i++)
//                         {
//                                if(chkTerms[i].checked)
//                                {
//                                    count++;
//                                }                            
//                         }     
//                         if(count==2)
//                         {
//                                document.getElementById("<%=hidTermSelection.ClientID%>").value="1";
//                         }
//                         else
//                         {
//                                document.getElementById("<%=hidTermSelection.ClientID%>").value="";
//                         }               
//                        myArr[++i] = new Array(document.getElementById("<%=hidTermSelection.ClientID%>"),"Empty","Please Select Two " + document.getElementById('<%=lblSelectCr.ClientID%>').innerText + " Part Terms", "text");
//                    }
//    		        var ret=validateMe(myArr,50); 
//	                return ret;
//	        }	        
//	       
//             
//             //callback function for list colleges
//             function ListColleges_callback(response)
//             {         
//                var dt=response.value;
//                var flag=false;
//                if(dt.Rows.length > 0)
//                {              
//                    for(var j=0;j<dt.Rows.length;j++)
//                    {
//                        if(dt.Rows[j].Inst_Code==collTxt)
//                        {
//                            flag=true;
//                            break;
//                        }
//                    } 
//                    if(flag)
//                    {
//                        result=true;
//                    }                   
//                }                
//            
//             }
//             
//             //callback function for list faculties -college login
//             function ListFaculties_callback(response)
//             {         
//                var dt=response.value;
//                var flag=false;
//                if(dt.Rows.length > 0)
//                {              
//                    for(var j=0;j<dt.Rows.length;j++)
//                    {
//                        if(dt.Rows[j].Inst_Code==collTxt)
//                        {
//                            flag=true;
//                            break;
//                        }
//                    } 
//                    if(flag)
//                    {
//                        result=true;
//                    }                   
//                }                
//            
//             }
             
            function openNewWindow(AcademicYr,AcYrText1,AcYrText2, InstID, FacId, CrId, MoLrnId, PtrnId, BrnId, CrPrDetailsId,CrPrChId1,CrPrChId2)
	        {       
	        var fname=document.getElementById("<%=hidFacName.ClientID%>").value;
	        var cname=document.getElementById("<%=hidCrName.ClientID%>").value;
	        var bname=document.getElementById("<%=hidBrName.ClientID%>").value;
	        var cdetN=document.getElementById("<%=hidCrPrName.ClientID%>").value;
	       
            window.open("ELGV2_rptDiscrepancyReport__1.aspx?&AcademicYr="+AcademicYr+"-"+AcYrText1+"-"+AcYrText2+"&InstID="+InstID+"&FacId="+FacId+"&CrID="+CrId+"&MoLrnID="+MoLrnId+"&PtrnID="+PtrnId+"&BrnID="+BrnId+"&CrPrDetailsID="+CrPrDetailsId+"&CrPrChIds="+CrPrChId1+","+CrPrChId2+"&fname="+fname+"&cname="+cname+"&bname="+bname+"&cDetN="+cdetN+"","_blank","location=no,height=320,width=720,status=yes,addressbar=no,toolbar=no,menubar=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");
    	    
    
    	        return false;
	        }
    
    </script>--%>
    <script type="text/javascript">
        function openNewWindow(AcademicYr, AcYrText1, AcYrText2, InstID, FacId, CrId, MoLrnId, PtrnId, BrnId, CrPrDetailsId, CrPrChId1, CrPrChId2, RCentreID) {
            var fname = document.getElementById("<%=hidFacName.ClientID%>").value;
            var cname = document.getElementById("<%=hidCrName.ClientID%>").value;
            var bname = document.getElementById("<%=hidBrName.ClientID%>").value;
            var cdetN = document.getElementById("<%=hidCrPrName.ClientID%>").value;

            window.open("ELGV2_rptDiscrepancyReport__1.aspx?&AcademicYr=" + AcademicYr + "-" + AcYrText1 + "-" + AcYrText2 + "&InstID=" + InstID + "&FacId=" + FacId + "&CrID=" + CrId + "&MoLrnID=" + MoLrnId + "&PtrnID=" + PtrnId + "&BrnID=" + BrnId + "&CrPrDetailsID=" + CrPrDetailsId + "&CrPrChIds=" + CrPrChId1 + "," + CrPrChId2 + "&fname=" + fname + "&cname=" + cname + "&bname=" + bname + "&cDetN=" + cdetN + "&RCentreID=" + RCentreID + "", "_blank", "location=no,height=320,width=720,status=yes,addressbar=no,toolbar=no,menubar=no,scrollbars =yes,left=250,top=300,screenX=0,screenY=400'");


            return false;
        }
    </script>
    <asp:UpdatePanel ID="updContent" runat="server">
        <ContentTemplate>
            <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
                border="0" width="700">
                <tr style="width: 700">
                    <td class="FormName" align="left" width="100%">
                        <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" Text="Discrepancy Report for"
                            meta:resourcekey="lblPageHeadResource2"></asp:Label>
                        <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblAcaYearResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                    </td>
                </tr>
                <tr style="width: 700">
                    <td colspan="3">
                        <div id="divYCMOU" runat="server">
                            <uc3:YCMOU ID="YCMOU" runat="server"></uc3:YCMOU>
                        </div>
                    </td>
                </tr>
                <%--<tr>
                    <td valign="top" align="left">
                        <div id="divAcademicYr" runat="server" style="azimuth: center; margin-left: 30PX;
                            width: 90%;">
                            &nbsp;&nbsp
                            <div id="tblAcademicYr" runat="server" align="center">
                                <table cellspacing="0" cellpadding="2px" width="100%" border="0">
                                    <tr>
                                        <td style="height: 20px;" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 20px; width: 225px;">
                                            <asp:Label ID="lblAcyr" runat="server" Font-Bold="True" Width="221px" meta:resourcekey="lblAcyrResource1"
                                                Text="Select Academic Year"></asp:Label></td>
                                        <td align="center" style="height: 20px; width: 1%;">
                                            <b>&nbsp;:&nbsp;</b></td>
                                        <td align="left" id="tdAcdYr" runat="server" style="height: 20px">
                                            <asp:DropDownList ID="ddlAcademicYr" runat="server" CssClass="selectbox" Width="245px"
                                                meta:resourcekey="ddlAcademicYrResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="--- Select ---"></asp:ListItem>
                                            </asp:DropDownList><font class="Mandatory">*</font></td>
                                    </tr>                                    
                                </table>
                            </div>
                        </div>
                        <table id="divCourse" runat="server" style="azimuth: center; margin-left: 30PX; width: 90%;">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <div id="tblCourse" runat="server" style="azimuth: center;">
                                        <table cellpadding="2px" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td align="right" style="height: 20px; width: 125px;">
                                                    <b>
                                                        <asp:Label ID="Label1" runat="server" Text="Select Faculty Name" meta:resourcekey="Label1Resource1"
                                                            Width="221px"></asp:Label></b></td>
                                                <td align="center" style="height: 20px; width: 1%;">
                                                    <b>&nbsp;:&nbsp;</b></td>
                                                <td style="height: 20px" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlFacDesc" runat="server" OnSelectedIndexChanged="ddlFacDesc_SelectedIndexChanged"
                                                        CssClass="selectbox" Width="245px" AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource2" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="lblSelectCrName" runat="server" Text="Select Course Name" meta:resourcekey="lblSelectCrNameResource1"></asp:Label></b></td>
                                                <td align="center">
                                                    <b>:</b></td>
                                                <td id="tdCrDesc" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlCrDesc" runat="server" OnSelectedIndexChanged="ddlCrDesc_SelectedIndexChanged"
                                                        CssClass="selectbox" meta:resourcekey="ddlCrDescResource1" AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource3" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr id="trCrBrn">
                                                <td align="right">
                                                    <strong>
                                                        <asp:Label ID="lblSelCrBranch" runat="server" Text="Select Course Branch" meta:resourcekey="lblSelCrBranchResource1"></asp:Label></strong></td>
                                                <td align="center">
                                                    <b>:</b></td>
                                                <td id="tdCrBrnDesc" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlCrBrnDesc" OnSelectedIndexChanged="ddlCrBrnDesc_SelectedIndexChanged"
                                                        runat="server" CssClass="selectbox" meta:resourcekey="ddlCrBrnDescResource1"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource6" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>
                                                        <asp:Label ID="Label2" runat="server" Text="Select Course Part" meta:resourcekey="Label2Resource1"></asp:Label></b></td>
                                                <td align="center">
                                                    <b>:</b></td>
                                                <td id="tdCrPrDesc" colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlCrPrDetailsDesc" OnSelectedIndexChanged="ddlCrPrDetailsDesc_SelectedIndexChanged"
                                                        runat="server" CssClass="selectbox" meta:resourcekey="ddlCrPrDetailsDescResource1"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Value="-1" meta:resourcekey="ListItemResource16" Text="--- Select ---"></asp:ListItem>
                                                    </asp:DropDownList><font class="Mandatory">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                            </tr>--%>
                <%-- <tr id="trMsg" runat="server" style="display: none">
                    <td align="right" runat="server" style="height: 88px">
                    </td>
                    <td align="center" runat="server" style="height: 88px">
                    </td>
                    <td colspan="3" align="left" runat="server" style="height: 88px">
                        <font color="red">The Term wise Discrepancy Report is available only for semester wise
                            <%=lblCr.Text %>
                            s. </font>
                    </td>
                </tr>
                <tr id="trTerm" runat="server" style="display: none">
                    <td align="right" runat="server">
                        
                            <asp:Label ID="Label3" runat="server" Text="Select Course Part Term" meta:resourcekey="Label3Resource1"></asp:Label></td>
                    <td align="center" runat="server">
                        :</td>
                    <td style="width: 250px" runat="server">
                        <asp:CheckBoxList ID="chkChild" runat="server" Width="100%" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>--%>
            </table>
            <br />
            <center>
                <%--<asp:Button ID="BtnSubmit" Text="Next &gt;&gt;" CssClass="butSubmit" OnClientClick="return courseValidate()"
                                runat="server" meta:resourcekey="BtnSubmitResource1" OnClick="btnNext_Click" />--%>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Export to Excel" CssClass="butSubmit"
                                    OnClick="btnExportToExcel_Click" meta:resourcekey="Button3Resource1" Style="display: none" />
                                <td>
                                    <asp:Button runat="server" Text="Export to PDF" CssClass="butSubmit" ID="btnPDF"
                                        Style="display: none" OnClick="btnPDF_Click"></asp:Button>
                                </td>
                        </tr>
                    </tbody>
                </table>
                <br />
            </center>
            <asp:GridView ID="GVReport" runat="server" AutoGenerateColumns="False" OnRowDataBound="GVReport_RowDataBound"
                OnRowCommand="GVReport_RowCommand" BorderStyle="None" CssClass="clGrid grid-view"
                DataKeyNames="Difference,pk_Inst_ID" meta:resourcekey="GVReportResource2" Style="border-style: Double;
                border-collapse: collapse;">
                <HeaderStyle CssClass="gridHeader" BackColor="#E0E0E0" />
                <Columns>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource4" HeaderText="Sr. No.">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# (Container.DataItemIndex)+1 %>.
                        </ItemTemplate>
                        <HeaderStyle Width="7%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="RegionalCenterInfo" HeaderText="Regional Center" meta:resourceKey="BoundFieldResourceRegionalCenterInfo">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="College_Code" HeaderText="College Code" SortExpression="College Code"
                        meta:resourcekey="BoundFieldResource5">
                        <ItemStyle Width="2%" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="College_Name" HeaderText="College Name" meta:resourcekey="BoundFieldResource6">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Term1Discrepanycount" meta:resourcekey="BoundFieldResource7"
                        HeaderText="Uploaded Data For Semester 1">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Term2Discrepanycount" meta:resourcekey="BoundFieldResource8"
                        HeaderText="Uploaded Data For Semester 2">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle"
                            Width="20%" />
                    </asp:BoundField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2" HeaderText="Difference">
                        <ItemStyle Width="4%" ForeColor="Blue" />
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkDifference" BackColor="White" ForeColor="Black"
                                CommandName="showDiff" CommandArgument='<%# Eval("pk_Inst_ID") %>' meta:resourcekey="lnkDifferenceResource2"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Large" />
            </asp:GridView>
            <table id="tblExportedDataMsg" runat="server" width="100%" style="display: none">
                <tr id="Tr2" runat="server">
                    <td id="Td2" style="height: 30px;" align="left" runat="server">
                        <asp:Label runat="server" ID="lblExportedData" CssClass="errorNote" meta:resourcekey="lblExportedDataResource1"></asp:Label>
                    </td>
                </tr>
            </table>
            <input id="hidInstID" runat="server" style="width: 24px; height: 22px" type="hidden" />
            <input id="hid_fk_AcademicYr_ID" runat="server" style="width: 24px; height: 22px"
                type="hidden" />
            <input id="hid_AcademicYear" runat="server" style="width: 24px; height: 22px" type="hidden" />
            <input id="hid_strAcademicYr1" runat="server" value="" type="hidden" />
            <input id="hid_strAcademicYr2" runat="server" value="" type="hidden" />
            <input id="hidCountryId" style="width: 24px; height: 22px" type="hidden" value="0"
                runat="server" />
            <input id="hidCntry" style="width: 24px; height: 22px" type="hidden" value="0" runat="server" />
            <input id="hidStateID" style="width: 24px; height: 22px" type="hidden" value="0"
                runat="server" />
            <input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" value="0"
                runat="server" />
            <input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" value="0"
                runat="server" />
            <input id="hidCourseDetails" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidUniID" style="width: 24px; height: 22px" type="hidden" runat="server" />
            <input type="hidden" runat="server" id="hidregisterationInfo" />
            <input id="hidCollCode" style="width: 24px; height: 22px" type="hidden" runat="server" />
            <input id="hidFacID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidFacText" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidCrID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidCrText" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidMoLrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidMoLrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidPtrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidPtrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidBrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidCrPrDetailsID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidCrPrChID" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidBrnText" runat="server" style="width: 32px; height: 22px" type="hidden" />
            <input id="hidLevelFlag" runat="server" value="" type="hidden" />
            <input id="hidCollName" runat="server" type="hidden" />
            <input id="hidAcYrName" runat="server" type="hidden" />
            <input id="hidFacName" runat="server" type="hidden" />
            <input id="hidCrName" runat="server" type="hidden" />
            <input id="hidBrName" runat="server" type="hidden" />
            <input id="hidCrPrName" runat="server" type="hidden" />
            <input id="hidCrPrDetName" runat="server" type="hidden" />
            <input id="hidCrPrChName" runat="server" type="hidden" />
            <input id="hidAllInstChkStatus" type="hidden" runat="server" />
            <input id="hidTermSelection" type="hidden" runat="server" />
            <input id="hidCrPrChIds" type="hidden" runat="server" />
            <input id="hidCrPrChNames" type="hidden" runat="server" />
            <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
            <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                meta:resourcekey="lblUniversityResource1"></asp:Label>
            <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
            <asp:Label ID="lblSelectCr" runat="server" Text="Course" meta:resourcekey="lblSelectCrResource1"
                Style="display: none"></asp:Label>
            <asp:Label ID="lblFacultyNm" Style="display: none" runat="server" Text="Faculty Name"
                meta:resourcekey="lblFacultyNmResource1"></asp:Label>
            <asp:Label ID="lblPaper" runat="server" Text="Paper" meta:resourcekey="lblPaperResource1"
                Style="display: none"></asp:Label>
            <input id="hidRCName" runat="server" type="hidden" />
            <input id="hidRCID" runat="server" type="hidden" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GVReport" />
            <asp:PostBackTrigger ControlID="Button3" />
            <asp:PostBackTrigger ControlID="btnPDF" />
            <%--<asp:AsyncPostBackTrigger ControlID="ddlFacDesc" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCrDesc" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCrBrnDesc" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCrPrDetailsDesc" EventName="SelectedIndexChanged" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <table>
        <uc2:Progress_Control ID="PC" runat="server"></uc2:Progress_Control>
    </table>
    <div id="DivReportViewerDesign" runat="server" style="display: none;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"  WaitMessageFont-Size="14pt"
            Height="600px" Width="100%"  meta:resourcekey="ReportViewer1Resource1">
            <LocalReport ReportEmbeddedResource="StudentRegistration.Eligibility.Rdlc.CrPrTermWiseDisc.rdlc"
                EnableExternalImages="True">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
