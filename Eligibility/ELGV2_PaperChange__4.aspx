<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" Codebehind="ELGV2_PaperChange__4.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperChange__4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
        	function CheckItem()//checks each item in the radiobuttonlist for checked or not 
            {     
                if(document.getElementById('<%=AdditionalPaperList.ClientID%>'))
                {
                    var options = document.getElementById('<%=AdditionalPaperList.ClientID%>').getElementsByTagName('input');    
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
                         showValidationSummary(options,"<li>Select atleast one paper.");              
                         return false;
                     }
                  }
              }              
                     
    </script>

    <div id="ControlHolder">
        <div id="PageTitleHolder" align="left" style="border-bottom: 1px solid #FFD275;">
            <asp:Label ID="lblPageHead" runat="server"/>&nbsp;
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
            <div id="dvNoteMsg" runat="server">               
                <div style="width: 100%; background-color: #FFFACD; height: 30px; border: solid 1px #c0c0c0;
                    vertical-align: top">
                    <div style="float: left">
                        <asp:Image runat="server" ID="imginfo" ImageUrl="../Images/Info.jpg" />
                    </div>
                    <div style="float: left; padding: 5px">
                        Select additional paper from following list.
                    </div>
                    <br />
                </div>
                <br />                            
                <asp:Label ID="lblCourseName" Font-Bold="True" runat="server"></asp:Label>
            </div>
            <br />
            <fieldset id="chk_Papers" runat="server">
                <div id="AdditionalPaperList" runat="server" style="padding-top:5px; padding-left:50px;">                 
                </div>
            </fieldset>
            <div class="clButtonHolder" style="padding-top: 10px" align="center">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClientClick="return CheckItem()"
                    OnClick="btnProceed_Click" />
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
    <input type="hidden" runat="server" id="hid_Previous_PpGrpID" />    
    <input type="hidden" runat="server" id="hid_Prev_pk_Fac_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Cr_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_MoLrn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Ptrn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Brn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_CrPr_Details_ID" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePartChild" />
    <input type="hidden" runat="server" id="hid_SelectedAdditionalPpID" />
    <input type="hidden" runat="server" id="hid_SelectedAdditionalPpName" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePart_Opted" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePart_Admission_Type" />
    <input type="hidden" runat="server" id="hid_IsPpHead" /> 
</asp:Content>
