<%@ Page Language="c#" Codebehind="CalendarDisplay.aspx.cs" AutoEventWireup="false" MasterPageFile="~/Content.Master" Inherits="UniversityPortal.CalendarDisplay" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" >

    <script language="javascript" src="jscript/header.js"></script>

    <script language="javascript" src="jscript/footer.js"></script>

    <script language="javascript" src="jscript/SPXMLHTTP.js"></script>

    <script language="javascript" src="jscript/change.js"></script>

<%--    <script language="javascript" src="ajax/common.ashx"></script>

    <script language="javascript" src="ajax/UniversityPortal.CalendarDisplay,UniversityPortal.ashx"></script>--%>

    <script>
		var sTableCellID;
			function showTR(Text)
			{
				var tRow = 'ctl00_ContentPlaceHolder1_tr'+Text;
				var img = 'img'+Text;
				tRow = eval(document.getElementById(tRow));	
				img = eval(document.getElementById(img));	
							
				if(tRow.style.display == "none")
				{
					tRow.style.display = "inline";
					img.src = "Images/minus.gif";
				}
				else
				{
					tRow.style.display = "none";
					img.src = "Images/plus.gif";
				}
			}
			
//			function fillMonths(location,Combo)
//			{
//			
//				document.getElementById("<% =hid_Year.ClientID%>").value = Combo.value;						
//				sTableCellID=location;
//				CalendarDisplay.fillMonths(Combo.value, BindDataToCombo_CallBack); 
//			}
//			
//			function BindDataToCombo_CallBack(response)
//			{		
//				if(response.error == null)
//				{
//					document.getElementById(sTableCellID).innerHTML = response.value ;
//					document.getElementById("<%=hid_Month.ClientID%>").value = document.getElementById("<%=cmbMonth.ClientID%>").value;
//				}			
//			}	
//			
//			function setHidden(Combo)
//			{
//				document.getElementById("<%=hid_Month.ClientID%>").value = Combo.value;	
//			}			
    </script>
 <div id="ControlHolder" style="width:710px">
        <table width="100%">
            <tr>
                <td valign="top" align="left" width="99%">
                    <p class="llblContentTitle" align="left">
                        <asp:Label ID="lblTitle" runat="server" CssClass="llblContentTitle" Font-Bold="True">Calendar</asp:Label></p>
                    <table cellspacing="1" cellpadding="2" width="100%">
                        <tr>
                            <td colspan="4">
                                <asp:UpdatePanel runat="server" ID="uPanel1" UpdateMode="conditional">
                         <ContentTemplate>
                                <table width="90%" align="center">
                                    <tr>
                                        <td align="right" width="40%">
                                            <strong>Select Year:</strong></td>
                                        <td width="60%">
                                            <asp:DropDownList ID="cmbYear" runat="server" AutoPostBack="true"  Width="184px" OnSelectedIndexChanged="cmbYear_SelectedIndexChanged" >
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="40%">
                                            <b>Select Month:</b></td>
                                        <td id="TDMonth" width="60%">
                                            <asp:DropDownList ID="cmbMonth" runat="server"  Width="184px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td valign="middle" align="center" width="100%" colspan="2" class="clButtonHolder">
                                            <asp:Button ID="btnShow" runat="server" Text="View Calendar"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td id="tdCalendar" width="100%" colspan="2" runat="server">
                                            <asp:PlaceHolder ID="CalendarTable" runat="server"></asp:PlaceHolder>
                                            <asp:Label ID="lblInformation" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" colspan="2">
                                        </td>
                                    </tr>
                                </table>
                              </ContentTemplate>
                              <Triggers>
                              <asp:AsyncPostBackTrigger ControlID="cmbYear" EventName="SelectedIndexChanged" />
                              </Triggers>  
                                       </asp:UpdatePanel>
                                <table id="TbRepresents" runat="server" style="border-top-width: 0px; display: none; border-left-width: 0px; border-bottom-width: 0px; border-collapse: collapse; border-right-width: 0px" bordercolor="#000000" width="90%" border="1" align="center">
                                    <tr>
                                        <td bgcolor="#800000" style="border-right: 1px solid; border-top: 1px solid; border-left-color: #000000; border-bottom: 1px solid">
                                            &nbsp;</td>
                                        <td style="border-right: medium none; border-top: medium none; border-bottom: medium none">
                                            <b>&nbsp;Represents a Holiday.</b></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr>
                                <p class="llblContentTitle" align="left">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" CssClass="llblContentTitle">Holidays</asp:Label></p>
                                <table id="Table2" cellspacing="1" cellpadding="2" width="100%" align="center">
                                    <tr>
                                        <td align="center" colspan="4">
                                            <table id="Table3" width="100%" align="center">
                                                <tr>
                                                    <td align="center" width="60%">
                                                        <asp:Label ID="lblHolidayYear" runat="server" Font-Bold="True"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" width="60%">
                                                        <asp:DataGrid ID="DG_DisplayHolidays" runat="server" Width="80%" AllowSorting="True" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False">
                                                            
                                                            <ItemStyle CssClass="gridItem"></ItemStyle>
                                                            
                                                            <Columns>
                                                                <asp:BoundColumn HeaderText="Sr. No">
                                                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="7%" CssClass="gridHeader"></HeaderStyle>
                                                                    <ItemStyle Font-Size="8pt" HorizontalAlign="Center"></ItemStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Event_Date" HeaderText="Date">
                                                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Left" Width="20%" CssClass="gridHeader"></HeaderStyle>
                                                                    <ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Event_Title" HeaderText="Event">
                                                                    <HeaderStyle Font-Size="8pt" HorizontalAlign="Center" Width="30%" CssClass="gridHeader"></HeaderStyle>
                                                                    <ItemStyle Font-Size="8pt" HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundColumn>
                                                            </Columns>
                                                        </asp:DataGrid></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <p>
                                    &nbsp;</p>
                            </td>
                        </tr>
                    </table>
                    <p>
                        <asp:Label ID="lblUpdationDate" runat="server"></asp:Label></p>
                </td>
                <td valign="top" align="left" width="1%">
                </td>
            </tr>
        </table>
   <input type="hidden" runat="server" id="hid_Page" name="hid_Page"><input type="hidden" runat="server" id="hid_MenuID" name="hid_MenuID">
 
        <input id="hid_Mode" style="width: 80px; height: 22px" type="hidden" name="hid_Mode" runat="server" /><input id="hidUniID" style="width: 80px; height: 22px" type="hidden" name="hidUniID" runat="server" /><input id="hidFacID" style="width: 80px; height: 22px" type="hidden" name="hidFacID" runat="server" /><input id="hidSubID" style="width: 80px; height: 22px" type="hidden" name="hidSubID" runat="server" /><input id="hid_Year" style="width: 80px; height: 22px" type="hidden" name="hid_Year" runat="server" /><input id="hid_Month" style="width: 80px; height: 22px" type="hidden" name="hid_Month" runat="server" />
        </div>
</asp:Content> 