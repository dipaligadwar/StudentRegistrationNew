<%@ Control Language="C#" AutoEventWireup="true" Codebehind="searchInstNew.ascx.cs"
    Inherits="StudentRegistration.Eligibility.searchInstNew" %>
<%--<link href="../CSS/UniPortal.css" type="text/css" rel="stylesheet" />--%>
<%--<link href="../CSS/calendar-blue.css" type="text/css" rel="stylesheet" />--%>

<script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
<script language="javascript" type="text/javascript" src="/JS/jscript_validations.js"></script>

<script type="text/javascript" src="/JS/jsAjaxMethod.js"></script>
<script language="javascript" type="text/javascript" src="/JS/change.js"></script>
<script type="text/javascript" src="ajax/common.ashx"></script>
<script type="text/javascript" src="ajax/StudentRegistration.Eligibility.ElgClasses.clsAjaxMethods,StudentRegistration.ashx"></script>

<script language="javascript" type="text/javascript">
		 
		 function hidunhid()
		  {
		  var val;
		  val = document.getElementById("<%=hidCountryId.ClientID%>").value
		  hideUnhide(val)
		  }

		  function hideUnhide(val)
		    {
		   
		    document.getElementById("<%=hidCountryId.ClientID%>").value = val;
		    if(val=="107")
		    {
		      if(document.getElementById("<%=State_ID.ClientID%>").selectedIndex ==0 )
		        {
		            document.getElementById("<%=hidStateID.ClientID%>").value = 0;
		            document.getElementById("<%=hidDistrictID.ClientID%>").value = 0; 
		            document.getElementById("<%=hidTehsilID.ClientID%>").value = 0;
		        }
		   
		            document.getElementById("<%=trDistrict.ClientID%>").style.display="block"; 
		            document.getElementById("<%=trTahsil.ClientID%>").style.display="block"; 
		            document.getElementById("<%=trState.ClientID%>").style.display="block"; 
		    
		    }
		    else 
		    {
		            document.getElementById("<%=trDistrict.ClientID%>").style.display="none"; 
		            document.getElementById("<%=trTahsil.ClientID%>").style.display="none"; 
		            document.getElementById("<%=trState.ClientID%>").style.display="none"; 
		    }
		    
		    }
		    
		    function ClearDropDownList(ddlObject)
            { 
             
	            while(ddlObject.length > 1)
	            {
            	  
		            ddlObject.remove(1);
	            }
            }
			  
			function FillDistrictDD(val)
			{ 
		      var TbDistID= document.getElementById("<%=TbDistID.ClientID%>").id;		     
		      var District_ID = document.getElementById("<%=District_ID.ClientID %>").id ;
		      
		      ClearDropDownList(document.getElementById("<%=District_ID.ClientID%>"));
		      ClearDropDownList(document.getElementById("<%=Tehsil_ID.ClientID%>"));
		      
		      document.getElementById("<%=hidDistrictID.ClientID%>").value = 0; 
		      document.getElementById("<%=hidTehsilID.ClientID%>").value = 0;  
		      FillDistrict(TbDistID,val,District_ID,0);
		      document.getElementById("<%=hidStateID.ClientID%>").value = val;
		      
			}
			function FillTalukaDD(val)
			{  
			    ClearDropDownList(document.getElementById("<%=Tehsil_ID.ClientID%>"));
			    
			    var TbTalID = document.getElementById("<%=TbTalID.ClientID %>").id;
			    var Tehsil_ID = document.getElementById("<%=Tehsil_ID.ClientID %>").id;
			    document.getElementById("<%=hidTehsilID.ClientID%>").value = 0;  
			    FillTaluka(TbTalID , val ,Tehsil_ID ,0);
			    document.getElementById("<%=hidDistrictID.ClientID%>").value = val;
			      
			}
		    function setTaluka(val)
		    { 
		   
			      document.getElementById("<%=hidTehsilID.ClientID%>").value = val;
			    
	   	    }
			function setOtherTaluka()
			{
			}		
			
            //calling ajax methods			
			//function to fill the districts drop down depends on the state	
	        function FillDistrict(location,val,Dist,j)
            {
               
                sTableCellID=location;   
                clsAjaxMethods.FillDistrict(val,Dist,j,BindDataToCombo_AffiliatedCallBack);
            }            
            //function to fill the Taluka drop down depends on the Districts
            
            function FillTaluka(location,val,Tal,j)
            {
                sTableCellID=location;		
                clsAjaxMethods.FillTaluka(val,Tal,j,BindDataToCombo_AffiliatedCallBack);
            }
            
            function  BindDataToCombo_AffiliatedCallBack(response)
	        {
	            if(response.error == null)
		        {
		           document.getElementById(sTableCellID).innerHTML = response.value;
	            }
		        else
		        {
			        alert("Response Object error in Ajax");
		        }					
	        }
			
</script>

<style type ="text/css">
  .datagridHeader td
{
   font-weight: bold;
   vertical-align:middle;
   font-family: Verdana; 
   text-align:center;
	font-size: 8pt;
	font-weight:bold; 
	color:#6f6f6f;/* #FFFFFF; */
	background-color: #efefef;/*#336699;*/
	padding-left:5px;
}</style>
<div align="center" style="vertical-align: top; width: auto">
    <fieldset class="fieldSet" id="tblSelect" runat="server" style="width: 90%">
        <legend><strong><asp:Label ID="lblSearchCollege" runat="server" Text="Search College" meta:resourcekey="lblSearchCollegeResource1"></asp:Label></strong></legend>
        <table cellspacing="3" cellpadding="0" width="100%" align="center" border="0" style="vertical-align: top">
            <tr>
                <td align="right" width="20%">
                    <strong>Type</strong></td>
                <td align="center" width="1%">
                    <b>:</b></td>
                <td width="79%" align="left">
                    <asp:RadioButtonList ID="rdbtnInstType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        ForeColor="Navy" Font-Bold="True" meta:resourcekey="rdbtnInstTypeResource1">
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="height: 17px" align="right" width="20%">
                    <b><span id="lblName0">Name</span></b></td>
                <td align="center" width="1%">
                    <b>:</b></td>
                <td style="height: 17px"  width="79%" align="left">
                    <asp:TextBox ID="Inst_Name" runat="server" CssClass="inputbox" Width="395px" MaxLength="300" meta:resourcekey="Inst_NameResource1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 17px" align="right" width="20%">
                    <b>Country&nbsp; </b>
                </td>
                <td style="height: 17px" align="center" width="1%">
                    <b>:</b></td>
                <td style="height: 17px" width="79%" align="left">
                    <b>
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="selectbox" onchange="hideUnhide(this.value);" meta:resourcekey="ddlCountryResource1">
                        </asp:DropDownList></b></td>
            </tr>
            <tr id="trState" runat="server">
                <td style="height: 17px" align="right" width="20%">
                    <b>State&nbsp; </b>
                </td>
                <td style="height: 17px" align="center" width="1%">
                    <b>:</b></td>
                <td style="height: 17px" width="79%" align="left">
                    <b>
                        <asp:DropDownList ID="State_ID" runat="server" CssClass="selectbox" onchange="FillDistrictDD(this.value);" meta:resourcekey="State_IDResource1">
                        </asp:DropDownList></b></td>
            </tr>
            <tr id="trDistrict" runat="server">
                <td style="height: 20px" align="right" width="20%">
                    <b>District</b></td>
                <td style="height: 20px" align="center" width="1%">
                    <b>:</b></td>
                <td id="TbDistID" style="height: 20px" width="79%" align="left">
                    <asp:DropDownList ID="District_ID" runat="server" CssClass="selectbox" onchange="FillTalukaDD(this.value);" meta:resourcekey="District_IDResource1">
                    </asp:DropDownList></td>
            </tr>
            <tr id="trTahsil" runat="server">
                <td style="height: 26px" align="right" width="20%">
                    <b>Tahsil</b></td>
                <td style="height: 26px" align="center" width="1%">
                    <b>:</b></td>
                <td id="TbTalID" style="height: 26px" width="79%" align="left">
                    <asp:DropDownList ID="Tehsil_ID" runat="server" CssClass="selectbox" onchange="setTaluka(this.value);" meta:resourcekey="Tehsil_IDResource1">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <b><asp:Label ID="lblCollegeCode" runat="server" Text="College Code" meta:resourcekey="lblCollegeCodeResource1"></asp:Label></b>
                </td>
                <td align="center" width="1%">
                    <b>:</b></td>
                <td width="79%" align="left">
                    <asp:TextBox ID="Collcode" runat="server" CssClass="inputbox" Width="100px" MaxLength="300" meta:resourcekey="CollcodeResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnSearch" runat="server" CssClass="butSubmit" Width="70px" Height="18px"
                        Text="Search" OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource1"></asp:Button></td>
            </tr>
        </table>
    </fieldset>
</div>
<br />
<br />
<fieldset id="fldPapers" runat="server" style="display: none; width: 90%" align="center">
    <legend><strong><asp:Label runat="server" ID="lblCollegeDetails" Text="College Details" meta:resourcekey="lblCollegeDetailsResource1"></asp:Label></strong></legend>
    <p style="margin-top: 10px; margin-bottom: 1px; margin-left: 0px" align="center">
        <asp:Label ID="lblGridName" runat="server" CssClass="clSubHeading" Width="95%" Height="18px" meta:resourcekey="lblGridNameResource1"></asp:Label>
     </p>
    <p style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px" align="center">
        <asp:GridView ID="dgData1" runat="server" Width="95%" AutoGenerateColumns="False" CssClass="clGrid grid-view"
            AllowPaging="True" PageSize="25"  meta:resourcekey="dgDataResource1" OnPageIndexChanging="dgData1_PageIndexChanging" OnRowCommand="dgData1_RowCommand" OnRowDataBound="dgData1_RowDataBound">
            <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right" BackColor="Control">
            </PagerStyle>
			 <RowStyle CssClass="gridItem"></RowStyle >
			 <HeaderStyle CssClass="gridHeader">
             </HeaderStyle>
                <Columns>
                <asp:ButtonField Text="&lt;img border='0' src='../images/pencil.gif' width='16' height='16'&gt;"
                    HeaderText="Select" CommandName="lnkButSelect" meta:resourcekey="ButtonColumnResource1">
                    <HeaderStyle Width="5%"></HeaderStyle>
                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FF3333" VerticalAlign="Middle">
                    </ItemStyle>
                </asp:ButtonField>
                <asp:BoundField  DataField="pk_Inst_ID" HeaderText="pk_Inst_ID" meta:resourcekey="BoundFieldResource1">
                    <HeaderStyle Width="0%"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Inst_Code" HeaderText="College Code" meta:resourcekey="BoundFieldResource2">
                </asp:BoundField>
                <asp:BoundField DataField="InstName" HeaderText="Name of College" meta:resourcekey="BoundFieldResource3">
                    <HeaderStyle Width="50%"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Inst_City" HeaderText="City" meta:resourcekey="BoundFieldResource4">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ITaluka_Name" HeaderText="Taluka" meta:resourcekey="BoundFieldResource5">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="District_Name" HeaderText="District" meta:resourcekey="BoundFieldResource6">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="InstTy_Name" HeaderText="Type" meta:resourcekey="BoundFieldResource7">
                    <HeaderStyle Width="15%"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="fk_InstTy_ID" HeaderText="Type" meta:resourcekey="BoundFieldResource8">
                    <HeaderStyle Width="15%"></HeaderStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </p>
</fieldset>
<!-- Selection ends -->
<div align="center">
    <asp:Label ID="lblData" runat="server" ForeColor="Tomato" Font-Bold="True" Width="99%"
        Visible="False" meta:resourcekey="lblDataResource1" Text="No Record Found"></asp:Label>
 </div>
<input id="hidInstID" style="width: 24px; height: 22px" type="hidden" name="hidInstID" runat="server" />
<input id="hidCountryId" style="width: 24px; height: 22px" type="hidden" value="0" name="hidcountryId" runat="server" />
<input id="hidCntry" style="width: 24px; height: 22px" type="hidden" value="0" name="Cntry" runat="server" />
<input id="hidStateID" style="width: 24px; height: 22px" type="hidden" value="0" name="hidStateID" runat="server" />
<input id="hidDistrictID" style="width: 24px; height: 22px" type="hidden" value="0" name="hidDistrictID" runat="server" />
<input id="hidTehsilID" style="width: 24px; height: 22px" type="hidden" value="0" name="hidTehsilID" runat="server" />
<input id="hidUniID" style="width: 24px; height: 22px" type="hidden" name="hidUniID" runat="server" />
<input type="hidden" runat="server" id="hidregisterationInfo" />
<input id="hidCollCode" style="width: 24px; height: 22px" type="hidden" name="hidCollCode" runat="server" />
<input id="hidCollName" style="width: 24px; height: 22px" type="hidden" name="hidCollName" runat="server" />
