<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" Codebehind="ELGV2_rptUploadedStudentStatistics__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_rptUploadedStudentStatistics__1" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--<style>
             
        .DataGridFixedHeader

        {
        font-weight: bold;
        vertical-align:middle;
        font-family: Verdana; 
        text-align:center;
	    font-size: 8pt;
	    font-weight:bold; 
	    /*color:#000000;*/
	    background-color:#D7E1F9;
	    padding-left:5px;
	    border:solid 1px;
	    border-color:#B2B2A9;
        position: relative;
        top: expression(this.offsetParent.scrollTop-3);
        }
        
        .DataGridHeaderText

        {
        font-weight: normal;       
        font-family: Verdana; 
        text-align:center;
	    font-size: 8pt;	    
	    color:#000000;	   
        }        

    </style>--%>
    <style type="text/css">
            
        .Freezing 
        { 
           position:relative ; 
           top:expression(this.offsetParent.scrollTop); 
           z-index: 10; 
        }
     </style>
    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblPageHead" runat="server" Font-Bold="True" CssClass="lblPageHead"
                        meta:resourcekey="lblPageHeadResource1"> List of Colleges Not Uploaded Data</asp:Label>
                    <asp:Label ID="lblAcaYear" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="lblAcaYearResource1"></asp:Label>
                    <asp:Label ID="lblCrDetails" runat="server" Font-Bold="True" Font-Size="Small"> </asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblMessage" runat="server" CssClass="errorNote" meta:resourcekey="lblMessageResource1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="Table2" cellspacing="0" cellpadding="5" align="center" border="0">
                        <tr>
                            <br />
                            <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Back" CssClass="butSubmit"
                                Width="53px" meta:resourcekey="Button2Resource1" />
                        </tr>
                    </table>
                    <br />
                    <div id="divCollegeStat" style="margin-left: 5px; width:98%; position: relative;"
                        runat="server">
                        <asp:GridView ID="dgGrid1" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                            Width="100%" OnPageIndexChanging="dgGrid1_PageIndexChanging" BorderStyle="None" CssClass="clGrid grid-view"
                            OnSorting="dgGrid1_Sorting" meta:resourcekey="dgGrid1Resource1" style="border-style:double; border-collapse:collapse">
                            <HeaderStyle BackColor="#E0E0E0" CssClass="gridHeader" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ></HeaderStyle>
                                    <ItemTemplate>
                                        <center>
                                            <%# (Container.DataItemIndex)+1 %>.
                                            <center>
                                    </ItemTemplate>
                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Inst_Code" HeaderText="College Code" SortExpression="Inst_Code"
                                    meta:resourcekey="BoundFieldResource1">
                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Inst_Name" HeaderText="College Name" SortExpression="Inst_Name"
                                    meta:resourcekey="BoundFieldResource2">
                                    <ItemStyle Width="31%" HorizontalAlign="Left" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="District" HeaderText="District" SortExpression="District"
                                    meta:resourcekey="BoundFieldResource3">
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Taluka" HeaderText="Taluka" SortExpression="Taluka" meta:resourcekey="BoundFieldResource4">
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Contact No" HeaderText="Contact No.1" SortExpression="Contact No"
                                    meta:resourcekey="BoundFieldResource5">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Contact No2" HeaderText="Contact No.2" SortExpression="Contact No2"
                                    meta:resourcekey="BoundFieldResource6">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Inst_MobileNo1" HeaderText="Mobile No" SortExpression="Inst_MobileNo1"
                                    meta:resourcekey="BoundFieldResource7">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <HeaderStyle Font-Bold="True" BackColor="#E0E0E0" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                            <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:GridView>
                        <br />
                        <br />
                    </div>
                    <input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" type="hidden" />
                    <input id="hid_AcademicYear" runat="server" name="hid_AcademicYear" type="hidden" />
                    <input id="hid_strAcademicYr1" runat="server" name="hid_strAcademicYr1" type="hidden" />
                    <input id="hid_strAcademicYr2" runat="server" name="hid_strAcademicYr2" type="hidden" />
                    <input id="hidInstId" runat="server" name="hidInstId" type="hidden" />
                    <input id="hidFacID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidCrID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidMoLrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidPtrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidBrnID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidCrPrDetailsID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidCrPrChID" runat="server" style="width: 32px; height: 22px" type="hidden" />
                    <input id="hidFacName" runat="server" type="hidden" />
                    <input id="hidCrName" runat="server" type="hidden" />
                    <input id="hidBrName" runat="server" type="hidden" />
                    <input id="hidCrPrName" runat="server" type="hidden" />
                    <input id="hidCrPrDetName" runat="server" type="hidden" />
                    <input id="hidCrPrChName" runat="server" type="hidden" />
                    <input id="hidAcYrName" runat="server" type="hidden" />
                    <input id="hidRCName" runat="server" type="hidden" />
                    <input id="hidRCID" runat="server" type="hidden" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
