<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" Codebehind="ELGV2_PaperChange__5.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperChange__5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
        	function CheckItem()//checks each item in the checkboxlist for checked or not 
            {     
                if(document.getElementById('<%=rdPrevCoursePartList.ClientID%>'))
                {
                    var options = document.getElementById('<%=rdPrevCoursePartList.ClientID%>').getElementsByTagName('input');    
                    var ischecked=false;    
                   
                     for(i=0;i<options.length;i++)    
                     {        
                        var opt = options[i];        
                        
                        if(opt.type=="radio")      
                        {        
                            if(opt.checked)             
                            {                
                                ischecked= true;                                                
                            }        
                        }     
                     }
                     if(ischecked)
                     {
                     return true;
                     }
                     else
                     {   	  
                         showValidationSummary(options,"<li>Select atleast one course.");              
                         return false;
                     }
                   }
              } 
              
            function DeleteMsg(id)
            {  
                var msg = 'Are you sure you want to remove selected Additional Paper'
                ShowConfirm(id,msg); 
                return false;   
            }

    </script>

    <div id="ControlHolder">
        <div id="PageTitleHolder" align="left" style="border-bottom: 1px solid #FFD275;">
            <asp:Label ID="lblPageHead" runat="server" />&nbsp;
            &nbsp;<asp:Label ID="lblSubHeader" runat="server"></asp:Label>
        </div>
        <div>
           
            <div style="width: 100%;">
                <div class="clRight">
                    <asp:Label ID="lblNote" runat="server"></asp:Label>
                </div>
            </div>
            <div style="clear: both;">
            </div>
            <br />
            <div style="width: 100%; background-color: #FFFACD; border: solid 1px #c0c0c0; vertical-align: top;
                margin-bottom: 20px;">
                <div>
                    <table width="100%" cellpadding="0">
                        <tr>
                            <td width="5%" colspan="4">
                                <asp:Image runat="server" ID="imginfo" ImageUrl="../Images/Info.jpg" /></td>
                            <td width="1%" valign="top">
                                1.</td>
                            <td valign="top">
                                If you want to 'Add' additional paper(s), select the course part term and click on
                                'Proceed'</td>
                        </tr>
                        <tr>
                            <td width="5%" colspan="4">
                                &nbsp;</td>
                            <td width="1%" valign="top">
                                2.</td>
                            <td>
                                If you want to 'Edit' additional paper(s), first remove paper(s) from list displayed
                                below which shows already opted additional paper(s), then select the course part
                                term and click on 'Proceed'</td>
                        </tr>
                    </table>
                </div>
            </div>
            <fieldset id="chk_Papers" runat="server">
                <legend>Select the course part term for which you want to add Additional paper(s)</legend>
                <div style="padding-top: 8px">
                    <asp:RadioButtonList ID="rdPrevCoursePartList" runat="server">
                    </asp:RadioButtonList><br />
                    <br />
                </div>
            </fieldset>
            <div class="clButtonHolder" style="padding-top: 10px" align="center">
                <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClientClick="return CheckItem()"
                    OnClick="btnProceed_Click" />
            </div>
            <div id="divDisplayGrid" runat="server" style="margin-top: 20px">
                <div>
                    <asp:Label ID="lblDisplayPreviousCourseName" Font-Bold="True" runat="server"></asp:Label>
                </div>
                <div style="margin-top: 5px">
                    <asp:GridView runat="server" AutoGenerateColumns="False" ID="GV_DisplayAdditionalPaper"
                        Width="100%" AllowSorting="True" AllowPaging="True" PageSize="25" CssClass="clGrid"
                        OnRowDataBound="GV_DisplayAdditionalPaper_RowDataBound" OnRowCommand="GV_DisplayAdditionalPaper_RowCommand">
                        <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <HeaderStyle Width="3%" CssClass="gridHeader" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseName" HeaderText="Course">
                                <HeaderStyle Width="25%" CssClass="gridHeader"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="AdditionalPaperName" HeaderText="Additional Paper(s)">
                                <HeaderStyle Width="35%" CssClass="gridHeader"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Remove">
                                <HeaderStyle Width="13%" CssClass="gridHeader" />
                                <ItemStyle HorizontalAlign="Center" ForeColor="Navy" CssClass="gridItem" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandName="Remove"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Prev_Fac_ID" HeaderText="Prev_Fac_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_Cr_ID" HeaderText="Prev_Cr_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_MoLrn_ID" HeaderText="Prev_MoLrn_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_Ptrn_ID" HeaderText="Prev_Ptrn_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_Brn_ID" HeaderText="Prev_Brn_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_CrPr_Seq" HeaderText="Prev_CrPr_Seq">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_CrPr_Details_ID" HeaderText="Prev_CrPr_Details_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_CrPrCh_ID" HeaderText="Prev_CrPrCh_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prev_CrPrCh_Seq" HeaderText="Prev_CrPrCh_Seq">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pk_PpPpGrp_ID" HeaderText="pk_PpPpGrp_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IsPpHead" HeaderText="IsPpHead">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaperHeadGrpID" HeaderText="PaperHeadGrpID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fk_PpHead_ID" HeaderText="fk_PpHead_ID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaperID" HeaderText="PaperID">
                                <ItemStyle CssClass="off" />
                                <HeaderStyle CssClass="off" />
                            </asp:BoundField>
                            
                        </Columns>
                    </asp:GridView>
                </div>
            </div>           
            <br />
        </div>
    </div>
    <input type="hidden" runat="server" id="hidUniID" />
    <input type="hidden" runat="server" id="hidInstID" />
    <input type="hidden" runat="server" id="hidInstName" />
    <input type="hidden" runat="server" id="hidInstCode" />
    <input type="hidden" runat="server" id="hidFacID" />
    <input type="hidden" runat="server" id="hidCrID" />
    <input type="hidden" runat="server" id="hidMoLrnID" />
    <input type="hidden" runat="server" id="hidPtrnID" />
    <input type="hidden" runat="server" id="hidBrnID" />
    <input type="hidden" runat="server" id="hidCrPrDetailsID" />
    <input type="hidden" runat="server" id="hidCrPrChID" />
    <input type="hidden" runat="server" id="hidCrPrSeq" />
    <input type="hidden" runat="server" id="hidCrPrChSeq" />
    <input type="hidden" runat="server" id="hidCrPartName" />   
    <input type="hidden" runat="server" id="hidCrName" />
    <input type="hidden" runat="server" id="hidStudentID" />
    <input type="hidden" runat="server" id="hidStudentName" />
    <input type="hidden" runat="server" id="hidStudentYear" />
    <input type="hidden" runat="server" id="hidOldPpList" />
    <input type="hidden" runat="server" id="hidAcademicYear" />
    <input type="hidden" runat="server" id="hidPRN" />
    <input type="hidden" runat="server" id="hidCrPrChName" />
    <input type="hidden" runat="server" id="hidExamFormModifyReq" />
    <input type="hidden" runat="server" id="hidElgFormNo" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Fac_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Cr_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_MoLrn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Ptrn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Brn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_CrPr_Details_ID" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePartChild" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePart_Opted" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePart_Admission_Type" />   
    <input type="hidden" runat="server" id="hid_Previous_PpGrpID" />
    <input type="hidden" runat="server" id="hid_IsPpHead" />

   
</asp:Content>
