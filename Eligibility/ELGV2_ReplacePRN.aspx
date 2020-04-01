<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="ELGV2_ReplacePRN.aspx.cs" Inherits="StudentRegistration.Eligibility.ELGV2_ReplacePRN"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" language=javascript>
        function fnValidateShowPRN() {

            var i = -1;
            var myArr = new Array();
            myArr[myArr.length] = new Array(document.getElementById("<%=txtPRN.ClientID%>"), "Empty", "Please enter Existing PRN", "text");

            var ret = validateMe(myArr, 50);
            if (ret == false)
                return false;
        }
        function fnValidateReplacePRN() {

            var i = -1;
            var myArr = new Array();
            myArr[myArr.length] = new Array(document.getElementById("<%=txtReplacePRN.ClientID%>"), "Empty", "Please enter PRN for replace", "text");

            var ret = validateMe(myArr, 50);
            if (ret == false)
                return false;
        }
        
    </script>
    <center>
        <table cellpadding="0" cellspacing="0" width="700" height="30px">
            <tr valign="top">
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" Text="Replace PRN"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table>
        
        <table>
            <tr>
                <td>
                <div>
                    <div  align="right" style="WIDTH:100%;">
                         <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                    <div id="Div4" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 10px" runat="server"
                        align="center">
                        <div align="right" style="WIDTH: 180px" class="clLeft">
                             <b><asp:Label ID="Label1" runat="server" Text="Enter PRN"></asp:Label> :&nbsp;</b></div>
                        <div align="left" style="WIDTH: 450px" class="clLeft">
                              <asp:TextBox ID="txtPRN" runat="server" Width="230px" CssClass="redbox" TabIndex="1"></asp:TextBox>       
                        </div>
                    </div>
                    <div id="Div5" style="WIDTH: 100%; CLEAR: both; PADDING-TOP: 10px" runat="server"
                        align="center">
                        <div align="center">
                            <asp:Button ID="btnProceed" runat="server" Text="Proceed" 
                             onclick="btnProceed_Click" OnClientClick="return fnValidateShowPRN()"/>
                        </div>
                    </div>
                    <div>
                    </div>
                    <div id="divStudentDetails" runat=server style="display:none">
                        <fieldset>
                        <legend>Student Details</legend>
                        <div id="Div6" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 10px" runat="server"
                            align="center">
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                 <b><asp:Label ID="Label4" runat="server" Text="Student Name"></asp:Label> :&nbsp; </b></div>
                            <div align="left" style="WIDTH: 450px" class="clLeft">
                                 <asp:Label ID="lblStudentName" runat="server"></asp:Label>              
                            </div>
                        </div>
                        <div id="Div1" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 10px" runat="server"
                            align="center">
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                 <b><asp:Label ID="Label6" runat="server" Text="Existing PRN Number"></asp:Label> : &nbsp;</b></div>
                            <div align="left" style="WIDTH: 450px" class="clLeft">
                                 <asp:Label ID="lblStudentPRN" runat="server"></asp:Label>              
                            </div>
                        </div>
                        <div id="Div2" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 10px" runat="server"
                            align="center">
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                 <b><asp:Label ID="Label8" runat="server" Text="Course"></asp:Label> :&nbsp;</b></div>
                            <div align="left" style="WIDTH: 450px" class="clLeft">
                                 <asp:Label ID="lblCourse" runat="server"></asp:Label>              
                            </div>
                        </div>
                        <div id="Div3" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 10px" runat="server"
                            align="center">
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                 <b><asp:Label ID="Label10" runat="server" Text="Branch"></asp:Label> :&nbsp;</b></div>
                            <div align="left" style="WIDTH: 450px" class="clLeft">
                                 <asp:Label ID="lblBranch" runat="server"></asp:Label>              
                            </div>
                        </div>
                        </fieldset>
                        <fieldset>
                        <legend>Replace PRN</legend>
                        <div>
                            <div id="Div7" style="WIDTH: 650px; CLEAR: both; PADDING-TOP: 10px" runat="server"
                            align="center">
                            <div align="right" style="WIDTH: 180px" class="clLeft">
                                 <b><asp:Label ID="Label2" runat="server" Text="Enter PRN to Replace"></asp:Label> :&nbsp;</b></div>
                            <div align="left" style="WIDTH: 450px" class="clLeft">
                                  <asp:TextBox ID="txtReplacePRN" runat="server" Width="230px" CssClass="redbox"></asp:TextBox>       
                            </div>
                            </div>
                        </div>
                        <div id="Div8" style="WIDTH: 100%; CLEAR: both; PADDING-TOP: 20px" runat="server"
                        align="center">
                        <div align="center">
                            <asp:Button ID="btnUpdate" runat="server" Text="Replace PRN" OnClientClick="return fnValidateReplacePRN()" onclick="btnUpdate_Click"/>
                        </div>
                    </div>
                        </fieldset>

                    </div>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
