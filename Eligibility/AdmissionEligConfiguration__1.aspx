<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="AdmissionEligConfiguration__1.aspx.cs" Inherits="StudentRegistration.Eligibility.AdmissionEligConfiguration__1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script src="jscript\jquery-latest.js" type="text/javascript"></script>	
	
<script type="text/javascript" src="https://www.jqueryscript.net/demo/DataTables-Jquery-Table-Plugin/media/js/jquery.js"></script>
<script type="text/javascript" src="https://www.jqueryscript.net/demo/DataTables-Jquery-Table-Plugin/media/js/jquery.dataTables.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

	

    <script type="text/javascript">
        function fnSubmitValidate() {
            var myArray = new Array();
            myArray[myArray.length] = new Array(document.getElementById("<%=ddlAcademicYear.ClientID%>"), "0", "Please select academic year.", "select");
            var ret = validateMe(myArray, 10);
            return ret;
        }


//        function Search_Gridview(strKey) {
//            debugger;
//            var strData = strKey.value.toLowerCase().split(" ");
//          var GridView = "<%=oGridView.ClientID%>";          //display grid view

//            var GridtblData = document.getElementById(GridView);
//            var rowData;
//         
//            //iterate grid view table Row 
//            for (var i = 1; i < GridtblData.rows.length; i++) {
//                rowData = GridtblData.rows[i].cells[0].innerHTML;
//                var styleDisplay = 'none';

//                for (var j = 0; j < strData.length; j++) {
//                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
//                        styleDisplay = '';
//                    else {
//                        styleDisplay = 'none';
//                        break;
//                    }
//                }
//                GridtblData.rows[i].cells[0].style.display = styleDisplay;
//            }
//        }



 </script>


  
    <div id="mastercontentbox">
        <div align="left" class="masterheading" style="position: relative;">
            <asp:Label ID="lblPageHead" runat="server" Text="Eligibility Definition"></asp:Label>
            <%--<asp:Label ID="lblSubHeader" runat="server" Text="Page Sub-Header"></asp:Label>--%>
        </div>
        <br />
        <br />
        <div class="clOuterDiv" style="margin-left: 25px; margin-top: 1px;">
            <div class="clImageHolder">
            </div>
            <div class="clInfoHolder" style="padding-bottom: 8px; background-color: #EFEFEF;
                min-height: 100px;">
                <table>
                    <tr>
                        <td style="padding-left: 5px; vertical-align: top;">
                            <asp:Label for="confirmCheck1" ID="lblConfirm" runat="server">
                               To Define admission eligibility for a new course, Click on "Add New Configuration" button.To Edit or Delete 
                               existing configuration please go through links in Grid below. 
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <table cellspacing="5" cellpadding="2" width="100%" border="0">
            <tbody>

                <tr>
                    <td align="right">
                        <asp:Label runat="server" Width="221px" Text="Select Academic Year" ID="lblAcademicYear" Font-Bold="true"></asp:Label>
                    </td>
                    <td style="width: 1%; height: 20px" align="center">
                        <b>&nbsp;:&nbsp;</b>
                    </td>
                    <td style="height: 20px" align="left">
                        <asp:DropDownList runat="server" CssClass="selectbox" Width="298px" ID="ddlAcademicYear">
                            <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <font class="Mandatory">*</font>
                    </td>
                </tr>
                <tr>
                <td colspan="3">
                <asp:Button Text="View Configured Courses" ID="btnSubmit" OnClientClick="return fnSubmitValidate();" runat="server" OnClick="btnSubmit_Click" />
                 &nbsp; &nbsp;<asp:Button Text="Add new configuration" ID="btnAddNewConfiguration" OnClientClick="return fnSubmitValidate();" runat="server" OnClick="btnAddNewConfiguration_Click" />
                </td>
                </tr>

               
            </tbody>
        </table>
        <br /><br />
        <div>
         <fieldset class="fieldSet" id="tblSearch" runat="server" style="width: 95%" visible="false" >
         <table cellspacing="5" cellpadding="2" width="100%" border="0">
            <tr id="trSearchRecord" runat="server" visible="false" >                
                       <td style="height: 25px" align="right">

                      <asp:TextBox Id="txtSearchBox" placeholder="Search Course" runat="server" style="width:40%"></asp:TextBox>                        
                    
                      </td>

                      <td style="width: 2%; height: 20px" align="right"> 
                        <b>&nbsp;</b>
                      </td>

                       <td align="left">
                 <asp:Button Text="Search" ID="btnSearch"  runat="server" onclick="btnSearch_Click"/>
                    </td>                
                </tr>   
                <tr id="trNote" runat="server" visible="false">
                  <td colspan="2" align="right">
                 (Enter Keywords to Search the Records in Course Name)
                 </td>   
                </tr>      
         </table>           
        </fieldset>
        </div>
         <br />
        <table width="100%" id="tblGridHolder" visible="false" runat="server" >
        <tr>
        <td colspan="3" style="text-align:left;">
        <b>List of configured courses.</b>
        </td>
        </tr> 
            <tr> 
                <td colspan="3">
                    <asp:GridView ID="oGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="UniID,FacID,CrID,MoLrnID,PtrnID,BrnID,CrPrDetailsID,CrPrChID,CurrentAndPreviousKeys,AdmissionElgTypeID,ResultConsideration"
                        Width="100%" CssClass="clGrid" OnRowCommand="oGridView_OnRowCommand" AllowPaging="True"
                        PageSize="25" OnPageIndexChanging="oGridView_PageIndexChanging" OnRowDataBound="oGridView_RowDataBound" OnPreRender="oGridView_PreRender"
                        EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField HeaderText="Course" DataField="Course_Name">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Course Part/Term" DataField="CrPrCh_Abbr">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Eligibility Type" DataField="AdmissionElgType">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="gridItem" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Left" Width="7%" VerticalAlign="Top" CssClass="gridItem" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="update" CommandArgument="<%# Container.DataItemIndex %>"
                                        Text='Edit'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                        <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
                        <HeaderStyle CssClass="gridHeader" />
                    </asp:GridView>

                    <%-- --%>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label Text="" ID="lblNote" Visible="false" CssClass="saveNote" runat="server" />
                    <asp:Label Text="" ID="lblErrorMessage" Visible="false" CssClass="errorNote" runat="server" />
                </td>
            </tr>
        </table>

        <asp:Label ID="lblErrorMsg" runat="server" Text="No Records Found For Search Criteria"
                                        Visible="false" CssClass="errorNote"></asp:Label>
                                        <br />
    </div>
    <asp:Label ID="lblFaculty" runat="server" Style="display: none" Text="Faculty"></asp:Label>
    <asp:Label ID="lblCourse" runat="server" Style="display: none" Text="Course"></asp:Label>
    <input id="hidUniID" runat="server" name="hidUniID" type="hidden" />
    <input id="hidFacID" runat="server" name="hidFacID" type="hidden" />
    <input id="hidCrID" runat="server" name="hidCrID" type="hidden" />
    <input id="hidMoLrnID" runat="server" name="hidMoLrnID" type="hidden" />
    <input id="hidPtrnID" runat="server" name="hidPtrnID" type="hidden" />
    <input id="hidBrnID" runat="server" name="hidBrnID" type="hidden" />
    <input id="hidCrPrDetailsID" runat="server" name="hidCrPrDetailsID" type="hidden" />
    <input id="hidCrPrChID" runat="server" name="hidCrPrChID" type="hidden" />
    <input id="hidAcademicYearID" type="hidden" name="hidAcademicYearID" runat="server" />
    <input id="hidCurrentAndPreviousKeys" type="hidden" name="hidCurrentAndPreviousKeys" runat="server" />
    <input id="hidAdmissionElgTypeID" type="hidden" name="hidAdmissionElgTypeID" runat="server" /> 
    <input id="hidResultConsideration" type="hidden" name="hidResultConsideration" runat="server" /> 
</asp:Content>
