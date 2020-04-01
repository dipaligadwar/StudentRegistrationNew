<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowStudentPhoto.ascx.cs" Inherits="StudentRegistration.Eligibility.WebCtrl.ShowStudentPhoto" %>
<div runat="server" id="DivPhoto" align="right" class="clAlwaysVisible">
    <fieldset>
        <asp:Panel ID="IWantThisVisible" Width="75px" runat="server" style="min-height:95px" meta:resourcekey="IWantThisVisibleResource1">
            <div style="width: 75px;margin-top:10px" align="center">
                <asp:Image ID="ImgPhoto" runat="server" AlternateText="Photograph"  Style="border: 1px solid #c0c0c0" meta:resourcekey="ImgPhotoResource1">
                </asp:Image>
                <div id="DivNoPhoto" runat="server" class="clLeft" style="margin-left:10px; border:solid 1px #888888;text-align:center;vertical-align:middle;line-height:70px;padding:3px;background-color:#efefef;color:#888888">                                      
                  No Photo
                </div>
            </div>            
        </asp:Panel>
    </fieldset>    
</div>

<script type="text/javascript">
var valHO = document.getElementById("PhotoHolder").offsetLeft+808;
document.getElementById('<%=DivPhoto.ClientID%>').style.left=valHO+'px';
document.getElementById('<%=DivPhoto.ClientID%>').style.top="110px";
</script>