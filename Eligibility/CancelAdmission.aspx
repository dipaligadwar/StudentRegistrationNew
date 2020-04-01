<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CancelAdmission.aspx.cs" Inherits="StudentRegistration.Eligibility.CancelAdmission" meta:resourcekey="PageResource1" %>
<%@ Register Src="WebCtrl/StudentSearch_Control.ascx" TagName="Search_Control" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="ControlHolder">
        <div align="left" id="PageTitleHolder">           
            <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1" />
            <asp:Label ID="lblSubHeader" runat="server" meta:resourcekey="lblSubHeaderResource1" />           
            <div id="StudentLinkHolder" /> 
        </div>
        <div align="right">
        <asp:Label ID="lblErrorMsg" runat="server" CssClass="errorNote" meta:resourcekey="lblErrorMsgResource1" />
        </div>  
               
       <uc1:Search_Control id="Search_Control1" runat="server" />
              
        <div id="DivDetails" runat="server" style="padding: 5px; padding-bottom: 20px">
        <div style="width:100%;height:25px;text-align:left;font-size:9pt;font-family:Verdana" id="divStudentCount" visible="false" runat="server">
			<div id="divCount" class="clLeft">
				<asp:Label runat="server" ID="lblCount" meta:resourcekey="lblCountResource1" />&nbsp;
			</div>
			<div id="divLink" class="clLeft" runat="server">
				(<asp:LinkButton runat="server" ID="lnkCount" Text="Click here" OnClick="lnkCount_Click" ForeColor="Blue" meta:resourcekey="lnkCountResource1" /><asp:Label runat="server" ID="lblserachresult" Text=" to see all the searched results) " meta:resourcekey="lblserachresultResource1" />
			</div>				
		</div>
            <asp:GridView runat="server" AutoGenerateColumns="False" ID="GV_SrchStud" Width="100%"
                AllowSorting="True" AllowPaging="True" PageSize="50" OnPageIndexChanging="GV_SrchStud_PageIndexChanging"
                OnRowDataBound="GV_SrchStud_RowDataBound" OnRowCommand="GV_SrchStud_RowCommand"
                CssClass="clGrid" meta:resourcekey="GV_SrchStudResource1" 
                EnableModelValidation="True">
                <PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundField DataField="Center_Code" HeaderText="College Code" meta:resourcekey="BoundFieldResource1">
                        <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" meta:resourcekey="BoundFieldResource2">
                        <HeaderStyle Width="40%" CssClass="gridHeader"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="OldPRN_Number" HeaderText="Old PRN Number" meta:resourcekey="BoundFieldResource3">
                        <HeaderStyle Width="17%" CssClass="gridHeader"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PRN_Number" HeaderText="PRN Number" meta:resourcekey="BoundFieldResource4">
                        <HeaderStyle Width="17%" CssClass="gridHeader"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="RegisteredIn" HeaderText="Registered In" 
                        meta:resourcekey="BoundFieldResource5" >
                      <HeaderStyle Width="10%" CssClass="gridHeader"></HeaderStyle>
                    </asp:BoundField> 
                    
                    <asp:TemplateField HeaderText="Select" 
                        meta:resourcekey="TemplateFieldResource1" >
                        <HeaderStyle Width="6%" CssClass="gridHeader" />
                        <ItemStyle HorizontalAlign="Center" ForeColor="Navy" CssClass="gridItem" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" 
                                meta:resourcekey="lnkSelectResource1" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="pk_Uni_ID" meta:resourcekey="BoundFieldResource6">
                        <ItemStyle CssClass="off" />
                        <HeaderStyle CssClass="off" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pk_Year" meta:resourcekey="BoundFieldResource7">
                        <ItemStyle CssClass="off" />
                        <HeaderStyle CssClass="off" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pk_Student_ID" meta:resourcekey="BoundFieldResource8">
                        <ItemStyle CssClass="off" />
                        <HeaderStyle CssClass="off" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Region" meta:resourcekey="BoundFieldResource9">
                        <ItemStyle CssClass="off" />
                        <HeaderStyle CssClass="off" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Study_Center" meta:resourcekey="BoundFieldResource10">
                        <ItemStyle CssClass="off" />
                        <HeaderStyle CssClass="off" />
                    </asp:BoundField>                                           
                </Columns>
            </asp:GridView>
        </div>        
    </div>
    <input type="hidden" runat="server" id="hid_pk_Student_ID" />    
    <input type="hidden" runat="server" id="hid_pk_Year" />
    <input type="hidden" runat="server" id="hid_Inst_Details" /> 
    <input type="hidden" runat="server" id="hid_Stud_Name" />
    <input type="hidden" runat="server" id="hid_PRN_Number" />  
    
    <input type="hidden" runat="server" id="hid_PRN" />    
    <input type="hidden" runat="server" id="hid_OldPRN" />
    <input type="hidden" runat="server" id="hid_ElgFormNo" /> 
    <input type="hidden" runat="server" id="hid_FacID" />
    <input type="hidden" runat="server" id="hid_CourseID" /> 
    <input type="hidden" runat="server" id="hid_MoLrnID" />    
    <input type="hidden" runat="server" id="hid_PtrnID" />
    <input type="hidden" runat="server" id="hid_BranchID" /> 
    <input type="hidden" runat="server" id="hid_CrPrDetailsID" />
    <input type="hidden" runat="server" id="hid_CrPrTermID" />
    <input type="hidden" runat="server" id="hid_LastName" /> 
    <input type="hidden" runat="server" id="hid_FirstName" />
    <input type="hidden" runat="server" id="hid_Gender" />  
    <input type="hidden" runat="server" id="hid_AppFormNo" /> 
    <input type="hidden" runat="server" id="hidAcademicYear" /> 
         
</asp:Content>
