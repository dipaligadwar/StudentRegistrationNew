<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="MatchingProfile__1.aspx.cs"
    Inherits="StudentRegistration.Eligibility.MatchingProfile__1" %>

<%@ Register Src="CourseProfile.ascx" TagName="CourseProfile" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" src="<%=Classes.clsGetSettings.SitePath%>jscript/jquery-latest.js"
        type="text/javascript"></script>
    <style type="text/css">
        .OFFGrid
        {
            background-color: #FFFFFF;
            font-family: Verdana;
            font-size: 8pt;
            font-weight: normal;
            width: 100%;
        }
        .OFFGrid TR
        {
            background-color: #FFF;
        }
        .OFFGrid TR TH, OFFGrid TR TD
        {
            padding: 3px;
        }
        .OFFGrid TR TH
        {
            font-weight: normal;
            background-color: #EBEBEB;
            width: 230px;
            vertical-align: top;
            border: solid 1px #dfdfdf;
            text-align: left;
        }
        .OFFGrid TR TD
        {
            font-family: Verdana;
            font-size: 8pt;
            font-weight: normal;
            min-width: 240px;
            width: 240px;
            vertical-align: top;
            padding: 3px;
            border: solid 1px #dfdfdf;
            background-color: #fff;
        }
        .OFFGridMerge
        {
            font-family: Verdana;
            font-size: 8pt;
            font-weight: normal;
            background-color: #EBEBEB;
            width: 697px;
        }
        .OFFGridMerge TR
        {
            background-color: #fff;
        }
        .OFFGridMerge TR TH, OFFGridMerge TR TD
        {
            padding: 3px;
        }
        .OFFGridMerge TR TH
        {
            font-weight: normal;
            background-color: #EBEBEB;
            width: 209px;
            vertical-align: top;
            border: solid 1px #c0c0c0;
        }
        .OFFGridMerge TD
        {
            font-family: Verdana;
            font-size: 8pt;
            font-weight: normal;
            width: 520px;
            vertical-align: middle;
            text-align: center;
            border: solid 1px #c0c0c0;
        }
        .cltdRed
        {
            color: red;
        }
        .cltdGreen
        {
            color: green;
        }
        .cssImage
        {
            padding: 5px;
        }
        .clNone
        {
            display: none;
        }
        .clOnRed
        {
            color: red;
        }
        .clOnGreen
        {
            color: green;
        }
        .subHeading
        {
            padding: 3px 3px 3px 5px;
            line-height: 20px;
            font-size: 11pt;
            font-family: Verdana;
            margin: 0px 0px 0px 0px;
            letter-spacing: 1px;
            background-color: #EBEBEB;
            border: solid 1px #dfdfdf;
            border-bottom-width: 0px;
            width: 98.5%;
        }
        .tblContents
        {
            width: 100%;
        }
        .profileBut
        {
            border: solid 1px #808080;
            background-color: #EBEBEB;
            font-family: Verdana;
        }
        .mergeProfileBut
        {
            border: solid 1px #808080;
            background-color: #EBEBEB;
            font-size: 14pt;
            height: 30px;
            color: #808080;
            font-family: Verdana;
        }
        .mergeProfiles
        {
            width: 95%;
            padding: 15px;
            margin: 10px 0px 10px 0px;
            height: 140px;
            border-width: 1px;
            border-bottom: dashed 1px #c0c0c0;
            border-top: dashed 1px #c0c0c0;
            background-color: #D8D8D8;
        }
        .mergeProfileChild
        {
            background-color: #fffacd;
            text-align: left;
            height: 140px;
            font-family: Verdana;
            font-size: 8pt;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#fffacd, endColorstr=#fffeee);
        }
        .mergeProfileChild1
        {
            float: left;
            width: 58%;
            padding: 10px 15px 10px 5px;
            text-align: justify;
            font-family: Verdana;
            font-size: 9pt;
        }
        .mergeProfileChild2
        {
            float: left;
            width: 36%;
            margin: 10px 0px 10px 0px;
            padding: 0px 0px 0px 10px;
            border-left: dashed 1px #c0c0c0;
        }
        .mergeProfileChild3
        {
            width: 100%;
            height: 80px;
        }
        .chkBox
        {
            font-family: Verdana;
            font-size: 9pt;
        }
        .rdButton
        {
            font-family: Verdana;
            font-size: 9pt;
        }
        .RequestInfoClass
        {
            background-color: #fffacd;
            text-align: left;
            color: #006E12;
            font-family: Verdana;
            font-size: 11pt;
            width: 100%;
            padding: 5px 2px 2px 40px;
            margin: 5px 0px 2px 0px;
            background-image: url(../images/Info.jpg);
            background-position: 1% 15%;
            background-repeat: no-repeat;
        }
    </style>
    <center>
        <table width="100%" border="0" cellpadding="1" cellspacing="1">
            <tr>
                <td align="left" style="border-bottom: 1px solid #FFD275;" colspan="2">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%;" colspan="2">
                    <asp:Label ID="lblInfo" runat="server" meta:resourcekey="lblInfoResource1" CssClass="RequestInfoClass"
                        Height="55px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100%;" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%; padding: 5px 0px 5px 0px; font-family: Verdana;
                    font-size: 9pt;" colspan="2">
                    <asp:Label runat="server" ID="lblMatCriteria" meta:resourcekey="lblMatCriteriaResource1"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table width="95%" border="0" cellpadding="1" cellspacing="1">
            <tr>
                <th valign="top" align="left">
                    <asp:Label ID="lblListProfile" runat="server" meta:resourcekey="lblListProfileResource1"></asp:Label>
                </th>
                <th valign="top" align="left" style="width: 200px; border-left: dashed 1px #D1D1D1;
                    padding-left: 15px;">
                    <asp:Label ID="lblListCat" runat="server" meta:resourcekey="lblListCatResource1"></asp:Label>
                </th>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <asp:CheckBoxList ID="CBListFilter1" RepeatLayout="Flow" runat="server" CssClass="chkBox"
                        meta:resourcekey="CBListFilter1Resource1">
                    </asp:CheckBoxList>
                </td>
                <td valign="top" align="left" style="width: 200px; border-left: dashed 1px #D1D1D1;
                    padding-left: 15px;">
                    <asp:CheckBoxList ID="CBListFilter2" runat="server" RepeatLayout="Flow" CssClass="chkBox"
                        meta:resourcekey="CBListFilter2Resource1">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <hr style="height: 1px; border-width: 0px; border-bottom: dashed 1px #808080; margin: 5px 0px 10px 0px;" />
        <div id="divSummary" align="left" style="width: 700px;">
            <div class="subHeading" align="left">
                <b>:: Summary</b>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="TBLSummery" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TBLSummeryResource1">
                    <asp:TableRow runat="server" >
                        <asp:TableHeaderCell runat="server" >
                            <asp:Label ID="lblPRN" runat="server" Text="PRN" meta:resourcekey="lblPRNResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource3" runat="server" >
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource3" runat="server" Text="Student Name"></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource4" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource4" runat="server" Text="Photograph & Signature"></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <br />
        </div>
        <div id="divPerInfo" align="left" style="width: 700px;" class="clOff">
            <br />
            <div class="subHeading" align="left">
                <b>:: Personal Information</b>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="TblPersonalInfo" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblPersonalInfoResource1">
                    <asp:TableRow meta:resourcekey="TableRowResource6" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource6" runat="server" Text="Student's Name"></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource7" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource7" runat="server" Text="Mother's Name"></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource8" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource8" runat="server" Text="Father's Name"></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource9" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource9" runat="server" Text="Name as printed on statement of marks of qualifying Exam
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource10" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource10" runat="server"
                            Text="Name in Vernacular language
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource11" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource11" runat="server"
                            Text="Marital Status
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource12" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource12" runat="server"
                            Text="Gender
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource13" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource13" runat="server"
                            Text="Date of Birth
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource14" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource14" runat="server"
                            Text="
			                Place of Birth
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource15" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource15" runat="server"
                            Text="
			                Blood Group
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource16" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource16" runat="server"
                            Text="
			                Religion
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource17" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource17" runat="server"
                            Text="
			                Previous Name
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource18" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource18" runat="server"
                            Text="
			                Reason for Changing Name
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource19" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource19" runat="server"
                            Text="
			                Country of Citizenship
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource20" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource20" runat="server"
                            Text="
			                Location Category
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource21" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource21" runat="server"
                            Text="
			                Correspondence Address
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource22" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource22" runat="server"
                            Text="
			                Correspondence Tahsil
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource23" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource23" runat="server"
                            Text="
			                Correspondence District
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource24" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource24" runat="server"
                            Text="
			                Correspondence State
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource25" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource25" runat="server"
                            Text="
			                Correspondence Country
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource26" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource26" runat="server"
                            Text="
			                Permanent Address
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource27" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource27" runat="server"
                            Text="
			                Permanent Tahsil
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource28" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource28" runat="server"
                            Text="
			                Permanent District
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource29" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource29" runat="server"
                            Text="
			                Permanent State
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource30" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource30" runat="server"
                            Text="
			                Permanent Country
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource31" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource31" runat="server"
                            Text="
			                [STD Code] Phone # 1
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource32" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource32" runat="server"
                            Text="
			                [STD Code] Phone # 2
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource33" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource33" runat="server"
                            Text="
			                Mobile Number
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource34" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource34" runat="server"
                            Text="
			                Email ID
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <br />
        </div>
        <div id="divQual" align="left" style="width: 700px;" class="clOff">
            <div class="subHeading" align="left">
                <b>:: Qualification Details</b>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="TblQual" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblQualResource1">
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl10BrdType" runat="server" Text="10th Board Type" meta:resourcekey="lbl10BrdTypeResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl10BrdState" runat="server" Text="10th Board State" meta:resourcekey="lbl10BrdStateResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl10Brd" runat="server" Text="10th Board" meta:resourcekey="lbl10BrdResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl10PassCert" runat="server" Text="10th Passing Certificate" meta:resourcekey="lbl10PassCertResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl10ExSeatNo" runat="server" Text="10th Examination Seat Number"
                                meta:resourcekey="lbl10ExSeatNoResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl12BrdType" runat="server" Text="12th Board Type" meta:resourcekey="lbl12BrdTypeResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl12BrdState" runat="server" Text="12th Board State" meta:resourcekey="lbl12BrdStateResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl12Brd" runat="server" Text="12th Board" meta:resourcekey="lbl12BrdResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl12PassCert" runat="server" Text="12th Passing Certificate" meta:resourcekey="lbl12PassCertResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell  runat="server">
                            <asp:Label ID="lbl12ExSeatNo" runat="server" Text="12th Examination Seat Number"
                                meta:resourcekey="lbl12ExSeatNoResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <br />
        </div>
        <div id="divSocRes" align="left" style="width: 700px;" class="clOff">
            <div class="subHeading" align="left">
                <b>:: Social Reservation</b>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="TblSocRes" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblSocResResource1">
                    <asp:TableRow meta:resourcekey="TableRowResource45" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource45" runat="server"
                            Text="
			                Social Reservations
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource46" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource46" runat="server"
                            Text="
			                Domicile of State
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource47" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource47" runat="server"
                            Text="
			                Category
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource48" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource48" runat="server"
                            Text="
			                Reserved Category
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource49" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource49" runat="server"
                            Text="
			                Caste
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource50" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource50" runat="server"
                            Text="
			                Admitted Under Category
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource51" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource51" runat="server"
                            Text="
			                Physically Challenged
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource52" runat="server">
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource52" runat="server"
                            Text="
			                Annual Income of Guardian
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow meta:resourcekey="TableRowResource53" runat="server">
                        <asp:TableHeaderCell  meta:resourcekey="TableHeaderCellResource53" runat="server"
                            Text="
			                Occupation of Guardian
                    "></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <br />
        </div>
        <div id="divCourse" align="left" style="width: 700px;" class="clOff">
            <div class="subHeading" align="left">
                <div style="float: left; width: 250px">
                    <asp:Label ID="lblCourseProHead" runat="server" Text=":: Course Profile" Font-Bold="True"
                        Font-Names="Verdana" Font-Size="11pt" meta:resourcekey="lblCourseProHeadResource1"></asp:Label></div>
                <div style="float: right; font-family: Verdana; font-size: 8pt;">
                    <b>NOTE</b> : <font style="color: Red"># </font>Indicates performance not active.</div>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="TblCourse" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblCourseResource1">
                    <asp:TableRow runat="server">
                        <asp:TableHeaderCell runat="server">
                            <asp:Label ID="lblCourse" runat="server" Text="Course" meta:resourcekey="lblCourseResource1"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <br />
        </div>
        <div id="divCollege" align="left" style="width: 700px;" class="clOff">
            <div class="subHeading" align="left">
                <b>:: College Profile</b>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="TblCollege" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblCourseResource1">
                    <asp:TableRow runat="server" meta:resourcekey="TableRowResource56">
                        <asp:TableHeaderCell runat="server" meta:resourcekey="TableHeaderCellResource67">
                        College
                        </asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <br />
        </div>
        <div id="divAction" align="left" style="width: 700px;">
            <div class="subHeading" align="left">
                <b>:: Action</b>
            </div>
            <div align="left" class="tblContents">
                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" BackColor="White" meta:resourcekey="TblActionResource2">
                    <asp:TableRow ID="TableRow1" meta:resourcekey="TableRowResource55" runat="server">
                        <asp:TableHeaderCell BackColor="White" ID="TableHeaderCell1" Width="100%"  meta:resourcekey="TableHeaderCell1Resource"
                            runat="server" style="padding:5px;" Text="If you choose to ‘Delete Profile’: This will delete all the transactional data (including Exam and Result Data) of the selected profile, and only profile which is not selected will remain.
<br/><br/>If you choose to ‘Merge Profile’: This will merge the ‘Course details’, ‘Exam details’ and ‘Result details’ of selected profile with another profile and other details such as ‘Personal Information’, ‘Qualification Details’, ‘Social Reservation’ of selected profile will get deleted permanently.
"></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div align="" class="tblContents">
                <asp:Table ID="TblAction" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblActionResource2">
                    <asp:TableRow meta:resourcekey="TableRowResource55" runat="server">
                        <asp:TableHeaderCell meta:resourcekey="TableHeaderCellResource55" runat="server"
                            Text="Delete Matching Profile"></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
             <div align="left" class="tblContents">
                <asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" BorderWidth="0px"
                    CssClass="OFFGrid" meta:resourcekey="TblActionResource2">
                    <asp:TableRow  ID="TableRow2" meta:resourcekey="TableRowResource55" runat="server">
                        <asp:TableHeaderCell ID="TableHeaderCell2"  BackColor="White" runat="server" style="text-align:center;" 
                        Font-Bold="true" Text="OR" Width="100%" ></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
        <div id="DIVMergeProfile" class="mergeProfiles" align="left" style="margin-top:0;">
            <div class="mergeProfileChild">
                <div class="mergeProfileChild1">
                    <asp:Label Text="'Merge Profiles' will combine the selected student profile with another student
                    profile. The Personal Information, Qualification Details, Social Reservation details
                    of the selected student will not be combined with the other student profile. Only
                    the Course details, Exam details and Result details will get combined. On successful
                    merge the selected student will get deleted permanently." ID="mergeProfileChild1Note"  meta:resourcekey="mergeProfileChild1NoteResource1" runat="server" />
                    
                </div>
                <div class="mergeProfileChild2">
                    <div class="mergeProfileChild3">
                        <asp:Label runat="server" ID="lblSelectPRN" Text="Select Profile to Merge with other"
                            Font-Bold="True" meta:resourcekey="lblSelectPRNResource1"></asp:Label><br />
                        <br />
                        <asp:RadioButton runat="server" ID="rb1" Text="Profile 1" GroupName="prnRB" CssClass="rdButton"
                            onclick="GetBaseProfile(this);" meta:resourcekey="rb1Resource1" /><br />
                        <asp:RadioButton ID="rb2" runat="server" GroupName="prnRB" Text="Profile 2" CssClass="rdButton"
                            onclick="GetBaseProfile(this);" meta:resourcekey="rb2Resource1" />
                    </div>
                    <div align="center" style="padding: 10px;">
                        <asp:Button runat="server" CssClass="mergeProfileBut" ID="btnMerge" Text="Merge Profiles"
                            OnClientClick="javascript:return ValidateMerge();" OnClick="btnMerge_Click" meta:resourcekey="btnMergeResource1" />
                    </div>
                </div>
            </div>
        </div>
    </center>
    <input type="hidden" runat="server" id="hid_Matching_Profile_ID" />
    <input type="hidden" runat="server" id="hid_BaseStudentIDs" />
    <input type="hidden" runat="server" id="hid_MatchingStudentIDs" />
    <input type="hidden" runat="server" id="hid_MatchingCriteria" />
    <input type="hidden" runat="server" id="hid_ProfileToBeMerged" />
    <input type="hidden" runat="server" id="hid_Del_New_Identity" />
    <input type="hidden" runat="server" id="hid_FromPage" />
    <input type="hidden" runat="server" id="hidBasePRN" />
    <input type="hidden" runat="server" id="hidLockedProfile" />
    <script type="text/javascript" language="javascript">
        function GetBaseProfile(obj) {
            var rb1 = document.getElementById("<%=rb1.ClientID%>");
            var rb2 = document.getElementById("<%=rb2.ClientID%>");
            $("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD").each
         (
            function () {
                if (rb1.checked) {
                    $("#<%=hid_ProfileToBeMerged.ClientID%>").attr("value", $("#DIVMergeProfile").find("#<%=rb1.ClientID%>").next("label").parent().attr("id"));
                    $("#<%=hid_BaseStudentIDs.ClientID%>").attr("value", $("#DIVMergeProfile").find("#<%=rb2.ClientID%>").next("label").parent().attr("id"));
                }
                else {
                    $("#<%=hid_ProfileToBeMerged.ClientID%>").attr("value", $("#DIVMergeProfile").find("#<%=rb2.ClientID%>").next("label").parent().attr("id"));
                    $("#<%=hid_BaseStudentIDs.ClientID%>").attr("value", $("#DIVMergeProfile").find("#<%=rb1.ClientID%>").next("label").parent().attr("id"));
                }
            }
        )
        }
        function ValidateDelete(obj) {
            $("#<%=TBLSummery.ClientID%>").find("TR:first").find("TD.clOn").each
        (
            function () {
                if ($(this).attr("id") != $("#" + obj.id).parent().attr("id")) {
                    document.getElementById("<%=hid_Del_New_Identity.ClientID%>").value = $(this).attr("id");
                }
            }
        )
            ShowConfirm(obj.name, 'This student will get deleted permenantly.<br><br>Are you sure you wish to delete this student because of duplication?');
            return false;
        }

        function ValidateMerge() {
            var rb1 = document.getElementById("<%=rb1.ClientID%>");
            var rb2 = document.getElementById("<%=rb2.ClientID%>");
            document.getElementById("<%=hidBasePRN.ClientID%>").value = '';
            if (rb1.checked || rb2.checked) {
                if (rb1.checked) {
                    document.getElementById("<%=hidBasePRN.ClientID%>").value = rb2.nextSibling.innerText;
                }
                else {
                    document.getElementById("<%=hidBasePRN.ClientID%>").value = rb1.nextSibling.innerText;
                }

                if (document.getElementById("<%=hidBasePRN.ClientID%>").value.indexOf("-") > -1 || document.getElementById("<%=hidBasePRN.ClientID%>").value.indexOf(" ") > -1) {
                    showValidationSummary('', 'Profile Cannot be merge. Profile which you want to maintain is not having <%=lblPRN.Text%>.');
                    return false;
                }
            }
            else {
                showValidationSummary('', 'To merge the student profiles, first select the profile to be merged.');
                return false;
            }

            //var UniqueID = '<%=btnMerge.UniqueID%>';
            //ShowConfirm(UniqueID,"The Selected Student Profile will get merged with the Other Profile (Base) and will get deleted permanantly.<br\><br\>Are you sure you wish to merge the profiles?");
            //return false;
        }

        function ToogleProfile(oThis, iUniqueIdentifier) {
            $("Table.OFFGrid").find("TR").each
       (
            function () {
                $(this).find("TD").each
                (
                    function () {
                        if (jQuery.trim($(this).attr("id")) == jQuery.trim(iUniqueIdentifier)) {
                            $(this).removeClass();
                            if (oThis.checked) {
                                $(this).addClass("clOn");
                            }
                            else {
                                $(this).addClass("clOff");
                            }

                        }
                    }
                )
            }
       )
        }

        function ReviewProfiles(arr) {
            $("Table.OFFGrid").find("TR").each
         (
            function () {

                $(this).find("#" + arr[0]).find("div").removeAttr("style");
                $(this).find("#" + arr[1]).find("div").removeAttr("style");

                if ($(this).find("#" + arr[0]).html() == $(this).find("#" + arr[1]).html()) {
                    $(this).find("#" + arr[0]).find("div").attr("style", "color:green");
                    $(this).find("#" + arr[1]).find("div").attr("style", "color:green");
                }
                else {
                    $(this).find("#" + arr[0]).find("div").attr("style", "color:red");
                    $(this).find("#" + arr[1]).find("div").attr("style", "color:red");
                }
            }
         )

        }

        function DisplayContents() {
            $("#<%=CBListFilter2.ClientID%>").find("input[type='checkbox']").each
        (
            function () {
                if ($(this).is(":checked")) {
                    $("#" + $(this).parent().attr("rel")).removeClass();
                    $("#" + $(this).parent().attr("rel")).show("fast");
                }
                else {
                    $("#" + $(this).parent().attr("rel")).removeClass();
                    $("#" + $(this).parent().attr("rel")).hide("fast");
                }
            }
        )
            //
            //Clear radio buttons
            //
            document.getElementById("<%=rb1.ClientID%>").checked = false;
            document.getElementById("<%=rb2.ClientID%>").checked = false;
            //
            //Atleast 1 profile should be active
            //
            if ($("#<%=CBListFilter1.ClientID%>").find("input[type='checkbox']:checked").length == 0) {
                showValidationSummary('', 'Atleast 1 profile should be active.');
                return false;
            }
            //
            //Maximum two profiles can be viewed
            //
            if ($("#<%=CBListFilter1.ClientID%>").find("input[type='checkbox']:checked").length > 2) {
                showValidationSummary('', 'Maximum two profiles can be viewed.');
                return false;
            }
            //
            //Hide buttons when one profile is active
            //
            if ($("#<%=CBListFilter1.ClientID%>").find("input[type='checkbox']:checked").length == 1) {
                //$("#divAction").find("input[type='submit']").attr("disabled","disabled");  
                $("#divAction").hide("slow");
                $("#DIVMergeProfile").hide("slow");
            }
            else {
                //For unlocked profiles
                if (document.getElementById("<%=hidLockedProfile.ClientID%>").value != "1") {
                    //$("#divAction").find("input[type='submit']").removeAttr("disabled");
                    $("#divAction").show("slow");
                    $("#DIVMergeProfile").show("slow");
                }
            }
            $("#<%=CBListFilter1.ClientID%>").find("input[type='checkbox']").each
        (
            function () {
                ToogleProfile(document.getElementById($(this).attr("id")), $(this).parent().attr("id"));
            }
        )

            var arrProfile = new Array();
            $("#<%=CBListFilter1.ClientID%>").find("input[type='checkbox']:checked").each
        (
            function () {
                arrProfile[arrProfile.length] = new Array($(this).parent().attr("id"))
            }
        )

            //For locked profiles
            if (document.getElementById("<%=hidLockedProfile.ClientID%>").value == "1") {
                //$("#divAction").find("input[type='submit']").attr("disabled","disabled");            
                $("#divAction").hide("fast");
                $("#DIVMergeProfile").hide("fast");
            }
            //
            //Change Theme
            //
            ReviewProfiles(arrProfile);
            //
            //Reset single profile
            // 
            if ($("#<%=CBListFilter1.ClientID%>").find("input[type='checkbox']:checked").length == 1) {
                $("Table.OFFGrid").find("TR TD DIV").each
             (
                function () {
                    $(this).removeAttr("style");
                }
             )
            }

            //
            //Black borders
            //
            var len = $("#<%=TBLSummery.ClientID%>").find("TR").length;
            $("#<%=TBLSummery.ClientID%>").find("TR").each
            (
            function (index) {
                if (index == 0)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-top-color:Black");
                else if (index == len - 1)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-bottom-color:Black");
                else
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black");
            }
            )
            len = $("#<%=TblPersonalInfo.ClientID%>").find("TR").length;
            $("#<%=TblPersonalInfo.ClientID%>").find("TR").each
            (
            function (index) {
                if (index == 0)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-top-color:Black");
                else if (index == len - 1)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-bottom-color:Black");
                else
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black");
            }
            )
            len = $("#<%=TblQual.ClientID%>").find("TR").length;
            $("#<%=TblQual.ClientID%>").find("TR").each
            (
            function (index) {
                if (index == 0)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-top-color:Black");
                else if (index == len - 1)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-bottom-color:Black");
                else
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black");
            }
            )
            len = $("#<%=TblSocRes.ClientID%>").find("TR").length;
            $("#<%=TblSocRes.ClientID%>").find("TR").each
            (
            function (index) {
                if (index == 0)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-top-color:Black");
                else if (index == len - 1)
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-bottom-color:Black");
                else
                    $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black");
            }
            )
            $("#<%=TblCourse.ClientID%>").find("TR").each
            (
            function () {
                $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-top-color:Black;border-bottom-color:Black");
            }
            )           
            $("#<%=TblCollege.ClientID%>").find("TR").each
            (
            function () {
                $(this).find("TD.clOn").attr("style", "border-left-color:Black;border-right-color:Black;border-top-color:Black;border-bottom-color:Black");
            }
            )
            //
            //Changing the radio button text
            //
            $("#DIVMergeProfile").find("input[type='radio']").each
            (
            function (index) {
                if (arrProfile[index] != null) {
                    if ($("#<%=TBLSummery.ClientID%>").find("TR:first").find("#" + arrProfile[index]).text() == "Not Available") {
                        //$(this).next("label").html($("#<%=TBLSummery.ClientID%>").find("TR:first").next("TR").find("#"+arrProfile[index]).text());
                        $(this).next("label").html("<%=lblPRN.Text%> Not Available");
                        $(this).next("label").parent().attr("id", arrProfile[index]);
                    }
                    else {
                        $(this).next("label").html($("#<%=TBLSummery.ClientID%>").find("TR:first").find("#" + arrProfile[index]).text());
                        $(this).next("label").parent().attr("id", arrProfile[index]);
                    }
                }
            }
            )
        }
        setTimeout("DisplayContents()", 100);
    </script>
</asp:Content>
