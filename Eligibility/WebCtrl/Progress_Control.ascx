<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Progress_Control.ascx.cs" Inherits="StudentRegistration.Eligibility.Progress_Control" %>
<style type="text/css">
   div.DivLoading-visible{
    display:block;
    position:fixed;
    top:50%;
    left:45%;
    width:50px;
    z-index:1001;  
  }
    div.otherDiv{    
    height:expression(document.body.scrollHeight+document.body.clientHeight+"px"); 
  }
</style>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">  
    <ProgressTemplate>
    <div class="otherDiv" style="position:fixed; top:0px; left:0px; overflow:hidden; padding:0; margin:0; filter:alpha(opacity=30); opacity:0.3; background-color:white; z-index:1000; width:100%;" runat="server" id="divUpdProgress"></div>
          <div id="DivLoading" class="DivLoading-visible" > 
            <img id="ImgLoading" src="../Images/loading.gif" />
          </div>
   </ProgressTemplate>
</asp:UpdateProgress>
<input type="hidden" runat="server" id="hidUPHeight" />
