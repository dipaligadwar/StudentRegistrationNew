<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Footer.ascx" %>

<%@ Page Language="c#" CodeBehind="Default.aspx.cs" AutoEventWireup="True" Inherits="DPTemplate2.Default"
    EnableViewState="False" meta:resourcekey="PageResource1" %>

<%@ Register TagPrefix="uc1" TagName="MenuControl" Src="MenuControl.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="head1">
    <title>
        <%=Classes.clsGetSettings.Name%>
    </title>   
    <link href="/CSS/template.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/portal.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="jscript/jquery-latest.js"></script>
    <script language="javascript" src="jscript/jscript_validations.js"></script>
    <script language="javascript" src="jscript/changescheme.js"></script>
    <script type="text/javascript">
        setStyle();
        $(document).ready(function () {
            $(".toggle_container").hide();
            $("li.trigger").click(function () {
                $(this).parent().next(".toggle_container").slideToggle("slow,");
                $(this).find("span.parent").toggleClass("parent-expanded");
            });
        });
        function validate_Me() {
            var i = -1;
            var myArr = new Array();
            myArr[++i] = new Array(document.getElementById("<%=txtUserName.ClientID%>"), "Empty", "Enter User Name.", "text");
            myArr[++i] = new Array(document.getElementById("<%=txtPassword.ClientID%>"), "Empty", "Enter Password.", "text");
            var ret = validateMe(myArr, 50);
            return ret;
        }
    
    </script>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div align="center" style="padding-top: 3px;">
        <div align="center" style="width: 900px; background-color: #FFFFFF;">
            <div style="width: 900px; background-color: #FFFFFF; margin-bottom: 5px;">
                <uc1:Header ID="UCHeader" runat="server"></uc1:Header>
            </div>
            <table align="center" style="width: 890px; margin-top: 5px; clear: both;" border="0">
                <tr>
                    <td valign="top" style="padding-left: 5px;">
                        <table id="table4" border="0" bordercolor="#c0c0c0" cellpadding="0" style="border-collapse: collapse"
                            width="160">
                            <tr>
                                <td align="left" valign="top">
                                    <uc1:MenuControl ID="mnuUniversity" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px">
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <uc1:MenuControl ID="mnuActivities" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <uc1:MenuControl ID="mnuMedia" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" style="padding-left: 2px; padding-right: 2px;">
                        <table id="table6" align="center" border="0" bordercolor="#c0c0c0" cellpadding="0"
                            style="border-collapse: collapse; width: 540px;">
                            <tr>
                                <td>
                                    <div id="CenterSwfImage" style="display: none" runat="server">
                                        <object width="538px" height="129">
                                            <param name="movie" value="coming_soon.swf" />
                                            <embed id="embedCenterImage" runat="server" width="538" height="129"></embed>
                                        </object>
                                    </div>
                                    <div id="CenterJpgImage" style="display: none" runat="server">
                                        <img id="ImgCenterImage" width="542" height="129" border="0" runat="server">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="39" valign="middle" style="border-top: dashed 1px #C0C0C0; border-bottom: dashed 1px #C0C0C0;">
                                    <marquee direction="left" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                                        scrolldelay="60" style="padding-right: 1px; padding-left: 1px; background-attachment: fixed;
                                        padding-bottom: 1px; color: #ff9933; padding-top: 1px; background-repeat: no-repeat">
                                        <asp:Literal ID="Literal5" runat="server" EnableViewState="False" 
                                                    meta:resourcekey="Literal5Resource1" Text="Announcements"></asp:Literal>
                                        - &nbsp;&nbsp;&nbsp;  <asp:Label ID="UCAnnouncement" runat="server"></asp:Label></marquee>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 5px">
                                    <table width="538px" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="clBlueBoxBorder" width="266px" height="18px">
                                                <div class="clBlueBoxTitle">
                                                    <asp:Label ID="lblcontentType1" runat="server" meta:resourcekey="lblcontentType1Resource1" />
                                                </div>
                                            </td>
                                            <td width="5px">
                                            </td>
                                            <td class="clGreenBoxBorder" width="267px" height="18px">
                                                <div class="clGreenBoxTitle">
                                                    <asp:Label ID="lblcontentType2" runat="server" meta:resourcekey="lblcontentType2Resource1" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="clBlueBox" width="265px">
                                                <marquee align="justify" direction="up" onmouseout="this.start()" onmouseover="this.stop()"
                                                    scrollamount="2" scrolldelay="60" style="padding-right: 1px; padding-left: 1px;
                                                    background-attachment: fixed; padding-bottom: 1px; color: #6d6254; padding-top: 1px;
                                                    background-repeat: no-repeat; height: 100px">
                                                      &nbsp;<asp:Label ID="UCNews" runat="server"></asp:Label></marquee>
                                            </td>
                                            <td width="5px">
                                            </td>
                                            <td class="clGreenBox" valign="top" style="padding: 5px" width="265px">
                                                &nbsp;<asp:Label ID="UCApplicationFrm" runat="server" meta:resourcekey="UCApplicationFrmResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="clMaroonBoxBorder" height="18px" width="265px">
                                                <div class="clMaroonBoxTitle">
                                                    <asp:Label ID="lblcontentType3" runat="server" meta:resourcekey="lblcontentType3Resource1" />
                                                </div>
                                            </td>
                                            <td width="5px">
                                            </td>
                                            <td class="clOrangeBoxBorder" height="18px" width="267px">
                                                <div class="clOrangeBoxTitle">
                                                    <asp:Label ID="lblcontentType4" runat="server" meta:resourcekey="lblcontentType4Resource1" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr height="100%">
                                            <td class="clMaroonBox" valign="top" style="padding: 5px" width="265px">
                                                &nbsp;<asp:Label ID="UCDownloads" runat="server" meta:resourcekey="UCDownloadsResource1"></asp:Label>
                                            </td>
                                            <td width="5px">
                                            </td>
                                            <td class="clOrangeBox" valign="top" style="padding: 5px" width="265px">
                                                &nbsp;<asp:Label ID="UCCircular" runat="server" meta:resourcekey="UCCircularResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="padding-right: 5px;" valign="top">
                        <table cellspacing="1" cellpadding="1" border="0" width="160">
                            <tr>
                                <td height="75" valign="top" align="right">
                                    <table cellspacing="1" cellpadding="1" border="0" style="height: 100%; width: 100%;
                                        border: solid 1px #ffd275; background-color: #FFF2D9;">
                                        <tr>
                                            <td align="right">
                                                <font class="loginLabels">
                                                    <asp:Literal ID="Literal1" runat="server" EnableViewState="False" meta:resourcekey="Literal1Resource1"
                                                        Text="User"></asp:Literal></font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" BorderColor="Gray" Height="12px" CssClass="clLogin"
                                                    MaxLength="50" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <font class="loginLabels">
                                                    <asp:Literal ID="Literal2" runat="server" EnableViewState="False" meta:resourcekey="Literal2Resource1"
                                                        Text="Password"></asp:Literal></font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="clLogin" MaxLength="15" TextMode="Password"
                                                    meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2" valign="baseline">
                                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="6pt" ForeColor="Red"
                                                    Visible="False" meta:resourcekey="lblErrorResource1">Invalid User Name/Password</asp:Label>
                                                <asp:Button ID="btnLogin" runat="server" CssClass="btnGo" Text="Go" OnClientClick="return validate_Me();"
                                                    OnClick="btnLogin_Click" meta:resourcekey="btnLoginResource1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                <font class="loginLabels">
                                                    <asp:Literal ID="Literal3" runat="server" EnableViewState="False" meta:resourcekey="Literal3Resource1"
                                                        Text="Forgot Password"></asp:Literal></font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left">
                                    <div style="padding: 3px;">
                                        <div>
                                            <a href='../OnlineAdmissions/PreRegistration.aspx'>
                                                <img src="/Images/OnlineApplications.gif" width="174" height="54" border="0" /></a>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="VerifyPRN.aspx" target="_self">
                                        <img src="Images/esuvidha.gif" width="172px" height="99" class='clLeftMenu'></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="http://easy.mkcl.org/registration/" target="_self">
                                        <img src="Images/easy_web.jpg" width="172px" height="74" class='clLeftMenu'></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="principalProfileSubmission.aspx" target="_self">
                                        <img src="Images/teacherreg.jpg" width="172px" height="51" class='clLeftMenu'></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="http://oasis.mkcl.org" target="_self">
                                        <img src="Images/opening.gif" width="172px" height="52" class='clLeftMenu'></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <uc1:MenuControl ID="mnuIPRPublication" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img border="0" height="5" src="Images/spacer.gif" width="50" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <uc1:MenuControl ID="mnuAcademics" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 5px">
                                    <div class='clLeftMenu' id="LeftMenuHolder">
                                        <table width="160px" style="margin-top: 5px">
                                            <tr>
                                                <td style="padding-top: 5px" align="center">
                                                    <b>
                                                        <asp:Literal ID="Literal4" runat="server" EnableViewState="False" Text="You are visitor number"
                                                            meta:resourcekey="Literal4Resource1"></asp:Literal>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px" align="center">                                                    
                                                    <asp:Label runat="server"   Text="" ID="lblVisitorCount"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center" style="width: 900px;">
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
