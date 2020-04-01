<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="LP_RegisteredStudents.aspx.cs" Inherits="StudentRegistration.Eligibility.LP_RegisteredStudents" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content" runat="server" >
<script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
	

			<CENTER>
				<TABLE id="table1" style="BORDER-COLLAPSE: collapse" borderColor="#c0c0c0" cellPadding="2"
					width="700" border="0">					
					<tr>						
						<%--<TD class="FormName" align="left" vAlign="middle">
						<asp:label id="lblTitle" runat="server" Width="99%" Font-Bold="True" CssClass="lblPageHead">View Status</asp:label>--%>
						<td align="left" style="border-bottom: 1px solid #FFD275; height: 17px;">
                        <asp:Label ID="lblPageHead" runat="server" Text="Registered Students"></asp:Label>
				        </TD>
					</tr>
					<tr style="height:10px;">
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
                                                        <dt><b> <font size="2">PROCESS ELIGIBILITY FOR </font></b></dt>
                                                    </dl>
                                                    <br />
                                                    <ul>
                                                        <li class="header">UNREGISTERED STUDENTS</li><p>
                                                            Eligibility process of Students whose 
                                                            <asp:Label runat="server" Text="PRN" ID="lblPRNNomenclature" meta:resourcekey="lblPRNNomenclatureResource1" ></asp:Label>
                                                             does not exist.
                                                        </p>
                                                    </ul>
                                                    <ul>
                                                        <li class="header">REGISTERED STUDENTS</li><p>
                                                            Eligibility Process of Students whose 
                                                            <asp:Label runat="server" Text="PRN" ID="lblPRNNomenclature_1" meta:resourcekey="lblPRNNomenclature_1Resource1" ></asp:Label>
                                                             exists. 
						                                    These Student are automatically Eligible for the next year of the same 
						                                    <asp:Label runat="server" Text="course" ID="lblCourseNomenclature" meta:resourcekey="lblCourseNomenclatureResource1" ></asp:Label>.
						                                    <br />If these Student take admission to new 
						                                    <asp:Label runat="server" Text="course" ID="lblCourseNomenclature_1" meta:resourcekey="lblCourseNomenclature_1Resource1" ></asp:Label>
						                                     then their Eligibility will be processed again.
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
					</TABLE>
					</CENTER>
</asp:Content>
