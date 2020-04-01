<%@ Page Language="c#" Codebehind="Home.aspx.cs" MasterPageFile="~/Home.Master" AutoEventWireup="false" Inherits="Classes.Home" EnableViewState="False" %>

<%@ Register TagPrefix="uc1" TagName="CircularControl" Src="CircularControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MessagingInbox" Src="MessagingInbox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AlertsandReminders" Src="AlertsandReminders.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UniversityCalender" Src="UniversityCalender.ascx" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">

    <script language="javascript">
		<!-- 
		function MM_preloadImages()
		 { //v3.0
			var d=document; 
			if(d.images)
			{ 
				
				if(!d.MM_p) 
				d.MM_p=new Array();
				var i;
				var j=d.MM_p.length;
				var a=MM_preloadImages.arguments;
				for(i=0; i<a.length; i++)
				{
					if (a[i].indexOf("#")!=0)
					{
						d.MM_p[j]=new Image; 
						d.MM_p[j++].src=a[i];
					}
				}
			}
		}   		

		function MenuMouseOut(image,hyperLink)
		{
			var img=hyperLink.childNodes[0];
			img.src=image;
		}
		
		function MenuMouseOver(image,hyperLink)
		{
			var img=hyperLink.childNodes[0];
			img.src=image;
		}
		-->
    </script>

    <table id="Table2" width="710px">
        <tr>
            <td>
                <asp:Image ID="imgContainer" runat="server" Visible="False"></asp:Image>
                <asp:Label ID="lblName" Style="text-align: justify" runat="server"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td height="5" colspan="2" class="FormName">
                <asp:Label ID="llblContentTitle" Style="text-align: left" runat="server" CssClass="llblContentTitle" Width="100%"></asp:Label>
                &nbsp;<span class="WelcomeMsg">[<asp:Label ID="lblUpdationDate" runat="server"></asp:Label>]</span> &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="middle">
                <asp:Label ID="InnerContent" Style="text-align: center" runat="server" Width="80%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
            
                <table width="540px" cellpadding="0" cellspacing="0"  >
                    <tr>
                        <td width="49%" class='clBlueBox' style="padding:0" >
                            <uc1:MessagingInbox ID="MessagingInbox1" runat="server"></uc1:MessagingInbox>
                        </td>
                        <td width="5px" >
                        </td>
                        <td width="49%"class="clGreenBox" valign="top" >
                       <div class="clGreenBoxTitle" >&nbsp;:: Alerts and Reminders</div> 
                            <uc1:AlertsandReminders ID="AlertsandReminders1" runat="server"></uc1:AlertsandReminders>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:5px">
                        </td>
                    </tr>
                    <tr bordercolor="red" >
                        <td class="clMaroonBoxBorder" height="18px" width="265px" >
                            <div class="clMaroonBoxTitle">
                                &nbsp;:: University Calender
                            </div>
                        </td>
                        <td width="5px">
                        </td>
                        <td class="clOrangeBoxBorder" height="18px" width="265px" >
                            <div class="clOrangeBoxTitle">
                                &nbsp;:: Circulars/GR/Notices
                            </div>
                        </td>
                    </tr>
                    <tr height="100%">
                        <td class="clMaroonBox" valign="top"  align="left" >
                            <uc1:UniversityCalender ID="UniversityCalender1" runat="server"></uc1:UniversityCalender>
                        </td>
                        <td width="5px">
                        </td>
                        <td class="clOrangeBox" valign="top" >
                            <uc1:CircularControl ID="CircularControl1" runat="server"></uc1:CircularControl>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
              <tr>
                <td valign="top" align="left" width="99%" style="height: 20px">                  
                </td>
                <td valign="top" align="left" width="1%" style="height: 20px">
                </td>
            </tr>
    </table>
</asp:Content>
