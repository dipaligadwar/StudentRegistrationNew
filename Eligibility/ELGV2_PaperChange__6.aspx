<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" Codebehind="ELGV2_PaperChange__6.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_PaperChange__6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
        	function CheckItem()//checks each item in the radiobuttonlist for checked or not 
            {   
                if(document.getElementById('<%=OptedPaperList.ClientID%>'))
                {                    
                    var options = document.getElementById('<%=OptedPaperList.ClientID%>').getElementsByTagName('input');    
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
              
              function CheckPpHead(isPpHead,PpName)
              {     
                var myElement; 
                var message;          
                if(isPpHead!=document.getElementById('<%=hid_IsPpHead.ClientID%>').value)
                {
                
                    if(document.getElementById('<%=hid_IsPpHead.ClientID%>').value=='Y')
                    {
                        message="You will not be able to select <b>'"+PpName+"'</b> paper as you have selected paper head as additional paper.<br>Please select paper head.";
                    }
                    else
                    {
                         message="You will not be able to select <b>'"+PpName+"'</b> paper head as you have selected paper as additional paper.<br>Please select paper.";
                    }
                    showValidationSummary(myElement,message);              
                    return false;
                }               
              }                
    </script>

    <div id="ControlHolder">
        <div id="PageTitleHolder" align="left" style="border-bottom: 1px solid #FFD275;">
            <asp:Label ID="lblPageHead" runat="server" />&nbsp
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
                <div style="width: 100%; background-color: #FFFACD; height: 40px; border: solid 1px #c0c0c0;
                    vertical-align: top">
                    <div style="float: left">
                        <asp:Image runat="server" ID="imginfo" ImageUrl="../Images/Info.jpg" />
                    </div>
                    <div style="float: left; padding: 5px">
                        You have selected <%=sSelAddPaperName%> as an additional paper.<br />
                        Please select the paper from following list against which you want to add additional paper.
                    </div>
                    <br />
                </div>
                <br />
                <asp:Label ID="lblCourseName" Font-Bold="True" runat="server"></asp:Label>
            </div>
            <br />
            <fieldset id="chk_Papers" runat="server">                
                <div id="OptedPaperList" runat="server" style="padding-top:5px; padding-left:50px;">                    
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
    <input type="hidden" runat="server" id="hid_AdmissionType" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Fac_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Cr_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_MoLrn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Ptrn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_Brn_ID" />
    <input type="hidden" runat="server" id="hid_Prev_pk_CrPr_Details_ID" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePartChild" />
    <input type="hidden" runat="server" id="hid_SelectedAdditionalPpID" />
    <input type="hidden" runat="server" id="hid_SelectedAdditionalPpName" />
    <input type="hidden" runat="server" id="hid_SelectedOptedPpID" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePart_Opted" />
    <input type="hidden" runat="server" id="hid_Prev_CoursePart_Admission_Type" />
    <input type="hidden" runat="server" id="hid_IsPpHead" />
   
</asp:Content>
