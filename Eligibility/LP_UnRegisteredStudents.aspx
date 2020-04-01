<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LP_UnRegisteredStudents.aspx.cs"
    Inherits="StudentRegistration.Eligibility.LP_UnRegisteredStudents" meta:resourcekey="PageResource1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content" runat="server">
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="0">
            <tr>
                <%--<TD class="FormName" align="left" vAlign="middle">
						<asp:label id="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead">View Status</asp:label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275; height: 17px;">
                    <asp:Label ID="lblPageHead" runat="server" Text="UnRegistered Students" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td>
                    <br />
                    <br />
                    <div id="divContainer" class="clOuterDiv">
                        <div class="clImageHolder">
                        </div>
                        <div id="divInfoHolder" class="clInfoHolder TabCourseDetails">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div id="divContent" runat="server">
                                            <dl>
                                                <dt><b><font size="2">PROCESS ELIGIBILITY FOR </font></b></dt>
                                            </dl>
                                            <br />
                                            <ul>
                                                <li class="header">UNREGISTERED STUDENTS</li><p>
                                                    <asp:Label Text="Eligibility process of Students whose PRN does not exist." runat="server"
                                                        ID="lblHeaderNote" meta:resourcekey="lblHeaderNoteResource1" />
                                                </p>
                                            </ul>
                                            <ul>
                                                <li class="header">REGISTERED STUDENTS</li><p>
                                                    <asp:Label Text="Eligibility Process of Students whose PRN exists.  These Student are automatically Eligible for the next year of the same course <br />If these Student take admission to new course then their Eligibility will be processed again."
                                                        ID="lblNote" runat="server" meta:resourcekey="lblNoteResource1" />
                                                </p>
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
