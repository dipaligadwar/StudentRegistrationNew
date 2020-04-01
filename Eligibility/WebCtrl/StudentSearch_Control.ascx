<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentSearch_Control.ascx.cs" Inherits="StudentRegistration.Eligibility.WebCtrl.StudentSearch_Control" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="Progress_control.ascx" TagName="Progress_control" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">

    function fnValidate(ctrlToValidate) {

   
    //alert(document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value)
    document.getElementById("<%=txtPRN.ClientID%>").value = document.getElementById("<%=txtPRN.ClientID%>").value.trim();
    document.getElementById("<%=txtOldPRN.ClientID%>").value = document.getElementById("<%=txtOldPRN.ClientID%>").value.trim();
    document.getElementById("<%=txtElgFormNo.ClientID%>").value = document.getElementById("<%=txtElgFormNo.ClientID%>").value.trim();
    document.getElementById("<%=txtLastName.ClientID%>").value = document.getElementById("<%=txtLastName.ClientID%>").value.trim();
    document.getElementById("<%=txtFirstName.ClientID%>").value = document.getElementById("<%=txtFirstName.ClientID%>").value.trim();
    document.getElementById("<%=txtAppFormNo.ClientID%>").value = document.getElementById("<%=txtAppFormNo.ClientID%>").value.trim();

    var myArr= new Array();
    var ind = document.getElementById("<%=DD_Branch.ClientID%>").selectedIndex;

    if (document.getElementById("<%=txtElgFormNo.ClientID%>").value == "" && document.getElementById("<%=txtOldPRN.ClientID%>").value == "" && document.getElementById("<%=txtPRN.ClientID%>").value == "" && document.getElementById("<%=DDlFaculty.ClientID%>").selectedIndex == "0" && document.getElementById("<%=DD_Gender.ClientID%>").selectedIndex == "0" && document.getElementById("<%=txtLastName.ClientID%>").value == "" && document.getElementById("<%=txtFirstName.ClientID%>").value == "" && document.getElementById("<%=txtAppFormNo.ClientID%>").value == "")
    {
	    myArr[myArr.length]= new Array(document.getElementById("<%=txtPRN.ClientID%>"),"Empty","Enter atleast one criteria for searching student.","text");
    }
    else {
            if (document.getElementById("<%=hidIsPRNValidationRequired.ClientID%>").value != "N") 
            {
                myArr[myArr.length] = new Array(document.getElementById("<%=txtPRN.ClientID%>"), "NumericOnly", "Enter valid <%=lblPRN.Text%>.", "text");
            }

        myArr[myArr.length]= new Array(document.getElementById("<%=txtOldPRN.ClientID%>"),"NumericOnly","Enter valid old <%=lblPRN.Text%>.","text");
        myArr[myArr.length] = new Array(document.getElementById("<%=txtElgFormNo.ClientID%>"), "AlphaNumericOnly", "Enter valid Eligibility Form No.", "text");
        myArr[myArr.length] = new Array(document.getElementById("<%=txtAppFormNo.ClientID%>"), "AlphaNumericOnly", "Enter valid Application Form No.", "text");
       
        if(document.getElementById("<%=DDlFaculty.ClientID%>").selectedIndex != "0")
        {
           myArr[myArr.length] = new Array(document.getElementById("<%=DD_Course.ClientID%>"),"0","Select <%=lblCr.Text%>.","select");
           if(document.getElementById("<%=DD_Branch.ClientID%>")[ind].innerHTML!="No Branch Available")
           {
               myArr[myArr.length]= new Array(document.getElementById("<%=DD_Branch.ClientID%>"),"-1","Select Branch.","select");
		   }
		  
           myArr[myArr.length] = new Array(document.getElementById("<%=DD_CoursePart.ClientID%>"),"0","Select <%=lblCrPr.Text%>.","select");
           myArr[myArr.length] = new Array(document.getElementById("<%=DD_Term.ClientID%>"),"0","Select <%=lblCrPrTr.Text%>.","select");
        }        
       
  	    myArr[myArr.length]= new Array(document.getElementById("<%=txtLastName.ClientID%>"),"AlphaOnly/SingleSpace","Enter valid Last Name.","text")
        myArr[myArr.length]= new Array(document.getElementById("<%=txtFirstName.ClientID %>"),"AlphaOnly/SingleSpace","Enter valid First Name.","text");
	} 
	  	       		
    var ret = validateMe(myArr,50,ctrlToValidate);
	return ret;	
}

</script>

<div id="ControlHolder">
    <div style="PADDING: 5px;"> 

<uc1:Progress_control ID="Progress_control1" runat="server" />
      
        <div align="right">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorNote" meta:resourcekey="lblErrorMessageResource1"></asp:Label>
        </div>
   
    </div>
    <div style="CLEAR: both;">
        <fieldset>
            <div>
                <div style="WIDTH: 650px; PADDING-TOP: 8px">
                    <div align="right" class="clLeft" style="HEIGHT: 25px; PADDING-TOP: 12px; WIDTH: 180px;">
                        <asp:Label ID="lblPRN" runat="server" Text="DU PRN" meta:resourcekey="lblPRNResource1"></asp:Label><b> : </b>
                    </div>
                    <div align="left" class="clLeft">
                        <asp:TextBox ID="txtPRN" runat="server" Width="230px" CssClass="redbox" MaxLength="16"
                            TabIndex="1" meta:resourcekey="txtPRNResource1" ></asp:TextBox>
                    </div>
                    <div align="right" class="clRight" style="WIDTH: 170px;">
                        <asp:Panel ID="PnlSearch" runat="server" meta:resourcekey="PnlSearchResource1">
                            <div style="CURSOR: pointer;" class="clRight">
                                <asp:Label ID="Label1" runat="server" CssClass="SimpleSearch" meta:resourcekey="Label1Resource1" Text="(Advanced Search)"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div style="WIDTH: 650px; PADDING-TOP: 8px; CLEAR: both;">
                    <div align="right" class="clLeft" style="HEIGHT: 25px; PADDING-TOP: 12px;WIDTH: 180px;">
                        <asp:Label ID="Label2" runat="server" Text="Old PRN" meta:resourcekey="Label2Resource1"></asp:Label><b> : </b>
                    </div>
                    <div align="left" class="clLeft">
                        <asp:TextBox ID="txtOldPRN" runat="server" Width="230px" CssClass="redbox"
                            MaxLength="16" TabIndex="2" meta:resourcekey="txtOldPRNResource1"></asp:TextBox>
                    </div>
                </div>
                <div style="WIDTH: 650px; PADDING-TOP: 8px;CLEAR: both;">
                    <div align="right" class="clLeft" style="HEIGHT: 25px; PADDING-TOP: 12px; WIDTH:180px">
                        Eligibility Form No<b> : </b>
                    </div>
                    <div align="left" class="clLeft">
                        <asp:TextBox ID="txtElgFormNo" runat="server" Width="230px" CssClass="redbox"
                            TabIndex="3" meta:resourcekey="txtElgFormNoResource1"></asp:TextBox>
                    </div>
                </div>

                  <div style="WIDTH: 650px; PADDING-TOP: 8px;CLEAR: both;">
                    <div align="right" class="clLeft" style="HEIGHT: 25px; PADDING-TOP: 12px; WIDTH:180px">
                        Application Form No<b> : </b>
                    </div>
                    <div align="left" class="clLeft">
                        <asp:TextBox ID="txtAppFormNo" runat="server" Width="230px" CssClass="redbox"
                            TabIndex="3" meta:resourcekey="txtAppFormNoResource1"></asp:TextBox>
                    </div>
                </div>


                <div style="CLEAR: both;">
					
                    <asp:Panel ID="Panel2" runat="server" CssClass="CollapsePanel" meta:resourcekey="Panel2Resource1">
                       
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                            <ContentTemplate>
                             <div id="Div6" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 20px" runat="server"
                                    align="center">
                                    <div align="right" style="WIDTH: 180px" class="clLeft">
                                        <asp:Label ID="lblFac" runat="server" Text="Faculty" meta:resourcekey="lblFacResource1"></asp:Label><b> : </b></div>
                                    <div align="left" style="WIDTH: 450px" class="clLeft">
                                        &nbsp;
                                        <asp:DropDownList ID="DDlFaculty" runat="server" Width="400px" AutoPostBack="True" TabIndex="4"
                                            OnSelectedIndexChanged="DDlFaculty_SelectedIndexChanged" meta:resourcekey="DDlFacultyResource1" />                                            
                                    </div>
                                </div>
                                <div id="Div2" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 5px" runat="server"
                                    align="center">
                                    <div align="right" style="WIDTH: 180px" class="clLeft">
                                        <asp:Label ID="lblCr" runat="server" Text="Course" meta:resourcekey="lblCrResource1"></asp:Label><b> : </b></div>
                                    <div align="left" style="WIDTH: 450px" class="clLeft">
                                        &nbsp;
                                        <asp:DropDownList ID="DD_Course" runat="server" Width="400px" AutoPostBack="True" TabIndex="4"
                                            OnSelectedIndexChanged="DD_Course_SelectedIndexChanged" meta:resourcekey="DD_CourseResource1" />                                            
                                    </div>
                                </div>
                                <div id="Div3" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 5px" runat="server"
                                    align="center">
                                    <div align="right" style="WIDTH: 180px" class="clLeft">
                                        Branch (if applicable)<b> : </b></div>
                                    <div align="left" style="WIDTH: 450px" class="clLeft">
                                        &nbsp;
                                        <asp:DropDownList ID="DD_Branch" runat="server" Width="400px" AutoPostBack="True" TabIndex="5"
                                            OnSelectedIndexChanged="DD_Branch_SelectedIndexChanged" meta:resourcekey="DD_BranchResource1" />
                                    </div>
                                </div>
                                <div id="Div4" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 5px" runat="server"
                                    align="center">
                                    <div align="right" style="WIDTH: 180px" class="clLeft">
                                        <asp:Label ID="lblCrPr" runat="server" Text="Course Part" meta:resourcekey="lblCrPrResource1"></asp:Label><b> : </b></div>
                                    <div align="left" style="WIDTH: 450px" class="clLeft">
                                        &nbsp;
                                        <asp:DropDownList ID="DD_CoursePart" runat="server" Width="400px" AutoPostBack="True" TabIndex="6"
                                            OnSelectedIndexChanged="DD_CoursePart_SelectedIndexChanged" meta:resourcekey="DD_CoursePartResource1" />
                                    </div>
                                </div>
                                <div id="Div5" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 5px" runat="server"
                                    align="center">
                                    <div align="right" style="WIDTH: 180px" class="clLeft">
                                        <asp:Label id="lblCrPrTr" runat="server" Text="Course Part Term" meta:resourcekey="lblCrPrTrResource1"></asp:Label><b> : </b></div>
                                    <div align="left" style="WIDTH: 450px" class="clLeft">
                                        &nbsp;
                                        <asp:DropDownList ID="DD_Term" runat="server" Width="400px" TabIndex="7" meta:resourcekey="DD_TermResource1" />
                                    </div>
                                </div>
                                </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="DDlFaculty" />
                                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="DD_Course" />
                                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="DD_Branch" />
                                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="DD_CoursePart"/>
                                
                            </Triggers>
                        </asp:UpdatePanel>    
                        <div id="Div1" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 5px;" runat="server">
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                Last Name<b> : </b>
                            </div>
                            <div align="left" style="PADDING-LEFT: 5px" class="clLeft">
                                <asp:TextBox ID="txtLastName" runat="server" Width="100px" TabIndex="10" meta:resourcekey="txtLastNameResource1" />
                            </div>
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                First Name<b> : </b>
                            </div>
                            <div align="left" style="PADDING-LEFT: 5px" class="clLeft">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="100px" TabIndex="11" meta:resourcekey="txtFirstNameResource1" />
                            </div>
                        </div>
                        <div id="SC_div3" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 5px" runat="server">
                            <div align="right" class="clLeft" style="WIDTH: 180px">
                                Gender<b> : </b>
                            </div>
                            <div align="left" style="WIDTH: 210px; PADDING-LEFT: 5px" class="clLeft">
                                <asp:DropDownList ID="DD_Gender" runat="server" Width="105px" TabIndex="12" meta:resourcekey="DD_GenderResource1" />                                
                            </div>
                            <div align="right" style="WIDTH: 140px" class="clLeft">
                            </div>
                            <div align="left" style="WIDTH: 150px; PADDING-LEFT: 5px" class="clLeft">
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div align="center" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 8px" class="clButtonHolder">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" TabIndex="13"
                        OnClientClick="return fnValidate(this);" meta:resourcekey="btnSearchResource1" />
                </div>


                  <div id="divNoteApplicationformNo" runat="server" style="clear: both;"  >
                 <div align="left" style="height: 25px; width: 600px">
                       <span style="color:Red"> <b> Note : Application Form No will Be Search Only For Current Academic Year :
                         <asp:Label ID="lblAcademicYear" runat="server" /> 
                        </b> </span>
                        
               </div>      
               
                    </div>


                <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" 
                    TargetControlID="Panel2"
                    ExpandControlID="PnlSearch" CollapseControlID="PnlSearch" 
                    TextLabelID="Label1" ExpandedText="(Simple Search)"
                    CollapsedText="(Advanced Search)" 
                    Collapsed="True" 
                    SuppressPostBack="True" 
                    CollapsedSize="0"
                    ExpandedSize="0" Enabled="True">
                </cc1:CollapsiblePanelExtender>
            </div>
        </fieldset>
    </div>
     <input id="hidIsPRNValidationRequired" type="hidden" name="hidIsPRNValidationRequired" runat="server"/>
</div>