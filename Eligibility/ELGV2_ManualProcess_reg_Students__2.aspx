<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home.Master" CodeBehind="ELGV2_ManualProcess_reg_Students__2.aspx.cs"
    Inherits="StudentRegistration.Eligibility.ELGV2_ManualProcess_reg_Students__2"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="/JS/SPXMLHTTP.js"></script>
    <script language="javascript" type="text/javascript" src="/JS/change.js"></script>
    <script language="javascript" type="text/javascript">
        var Rdiff = 0;

        var WinCollection = new Array()
        var WinCtr = -1;
        var ctrMin = 0;
        var ctrMax = 0;

        var dragObj = new Object();
        dragObj.zIndex = 0;

        function dragStart(event, id) {

            var el;
            var x, y;


            if (id)
                dragObj.elNode = document.getElementById(id);
            else
                dragObj.elNode = window.event.srcElement;


            x = window.event.clientX + document.documentElement.scrollLeft
      + document.body.scrollLeft;
            y = window.event.clientY + document.documentElement.scrollTop
      + document.body.scrollTop;

            //window.scroll = "yes";


            dragObj.cursorStartX = x;
            dragObj.cursorStartY = y;
            dragObj.elStartLeft = parseInt(dragObj.elNode.style.left, 10);
            dragObj.elStartTop = parseInt(dragObj.elNode.style.top, 10);

            if (isNaN(dragObj.elStartLeft)) dragObj.elStartLeft = 0;
            if (isNaN(dragObj.elStartTop)) dragObj.elStartTop = 0;


            dragObj.elNode.style.zIndex = ++dragObj.zIndex;


            document.attachEvent("onmousemove", dragGo);
            document.attachEvent("onmouseup", dragStop);
            window.event.cancelBubble = true;
            window.event.returnValue = false;

        }

        function dragGo(event) {

            var x, y;

            x = window.event.clientX + document.documentElement.scrollLeft
      + document.body.scrollLeft;
            y = window.event.clientY + document.documentElement.scrollTop
      + document.body.scrollTop;


            //var Ldiff=x-( x- parseInt(dragObj.elNode.style.left,10));
            //var Rdiff=x+ ( parseInt(dragObj.elNode.style.width,10)-( x- parseInt(dragObj.elNode.style.left,10) ));



            dragObj.elNode.style.left = (dragObj.elStartLeft + x - dragObj.cursorStartX) + "px";
            dragObj.elNode.style.top = (dragObj.elStartTop + y - dragObj.cursorStartY) + "px";

            window.event.cancelBubble = true;
            window.event.returnValue = false;


        }

        function dragStop(event) {


            document.detachEvent("onmousemove", dragGo);
            document.detachEvent("onmouseup", dragStop);
            // document.getElementById('divStudentDetails').doscroll('scrollbarPageDown');

        }



        function WinClose(val) {

            var node = document.getElementById(val).parentElement;

            while (node.tagName != 'DIV' && node.parentElement != null)
                node = node.parentElement;

            var nodeID = node.id;
            document.getElementById(nodeID).style.display = "none";

            //dragObj.elNode.style.left = 0;
            // dragObj.elNode.style.top = 0;
            // window.scrollTo(0,document.getElementById(val).scrollTop);




        }

        function WinMin(val) {

            var node = document.getElementById(val).parentElement;

            while (node.tagName != 'DIV' && node.parentElement != null)
                node = node.parentElement;

            var nodeID = node.childNodes[1].id;
            document.getElementById(nodeID).style.display = "none";

            WinCollection[WinCtr++] = node.id.toString();

            if (ctrMax != 0)
                ctrMax = ctrMax - parseInt(node.style.width, 10);

            if (ctrMin == 0) {
                ctrMin += parseInt(node.style.width, 10);

                node.style.left = document.getElementById("TaskBar").style.left;
                node.style.top = document.getElementById("TaskBar").style.top;
            }
            else {
                node.style.left = parseInt(document.getElementById("TaskBar").style.left, 10) + ctrMin;
                node.style.top = document.getElementById("TaskBar").style.top;
                ctrMin += parseInt(node.style.width, 10);
            }

        }

        function WinMax(val) {

            var node = document.getElementById(val).parentElement;

            while (node.tagName != 'DIV' && node.parentElement != null)
                node = node.parentElement;

            var nodeID = node.childNodes[1].id;
            document.getElementById(nodeID).style.display = "block";

            var xx;
            for (xx in WinCollection) {
                if (WinCollection[xx] == node.id.toString())
                    WinCollection[xx] = null;
            }

            if (ctrMin != 0)
                ctrMin = ctrMin - parseInt(node.style.width, 10);

            if (ctrMax == 0) {
                node.style.top = document.getElementById("layout").style.top;
                node.style.left = document.getElementById("layout").style.left;
                ctrMax = parseInt(node.style.width, 10);
            }
            else {
                node.style.top = document.getElementById("layout").style.top;
                node.style.left = parseInt(document.getElementById("layout").style.left, 10) + ctrMax;
                ctrMax += parseInt(node.style.width, 10);

            }

        }

        var zxcTO;
        function Scroll() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_divMStudentDetails').style.display == "block") {
                //clearTimeout(zxcTO);


                if (navigator.appName == "Microsoft Internet Explorer") {
                    eval("ctl00_ContentPlaceHolder1_divMStudentDetails.style.pixelTop=" + event.clientY * 2);
                    //eval("divMStudentDetails.style.pixelLeft=" + event.clientX); 
                }
                //zxcTO=setTimeout(1000);


            }
        }
        window.onscroll = Scroll;

 

		
    </script>
    <script language="javascript" type="text/javascript">
        var MUni_ID;
        var MYear;
        var MStudent_ID
        function fnCheckSelection(cb) {

            var cbID = document.getElementById(cb.id);
            var cnt = document.getElementById('hidMatchingRecCount').value;
            if (cbID.checked == true) {
                for (i = 1; i <= cnt; i++) {
                    var str = document.getElementById('DGMatchingRecords').cells[((i + 1) * 8) - 1].innerHTML;
                    if (str.match(cbID.id) == null)
                        document.getElementById('DGMatchingRecords').cells[((i + 1) * 8) - 1].innerHTML = str.replace(/CHECKED/, "");

                }
                var ch = confirm('Are you sure you want to associate the profile under consideration for Eligibility with the selected record ?');
                if (!ch) {
                    cbID.checked = false;
                }
            }

        }
        function fnFetchMatchingProfile(Uni_ID, Year, Student_ID) {
            MUni_ID = Uni_ID;
            MYear = Year;
            MStudent_ID = Student_ID;
            IA_StudentEligibility__1.FetchMatchingProfile(Uni_ID, Year, Student_ID, FetchMatchingProfile_CallBack);
        }

        function FetchMatchingProfile_CallBack(response) {
            var ds = response.value;
            document.getElementById('trMChangedName').style.display = "none";
            document.getElementById('DGMCourseDetails').style.display = "none";
            document.getElementById('DGMQualification').style.display = "none";
            var MatchingID = MUni_ID + '-' + MYear + '-' + MStudent_ID;
            document.getElementById('ImageM1').src = "ELGV2_ManualProcess_reg_Students__3.aspx?PMatchingID=" + MatchingID;
            document.getElementById('ImageM2').src = "ELGV2_ManualProcess_reg_Students__3.aspx?SMatchingID=" + MatchingID;
            //document.getElementById('DGMSubmittedDocs').style.display = "none";
            if (ds.Tables[0].Rows.length > 0) {
                var tbl = document.getElementById("DGMCourseDetails").getElementsByTagName("tbody")[0];
                if (tbl.rows.length != 0) {
                    var cnt = tbl.rows.length;
                    for (var k = 1; k < cnt && k != cnt; k++) {
                        if (tbl.rows.length != 0) {
                            tbl.deleteRow(1);
                        }
                    }
                }
                for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                    var row = document.createElement("TR");
                    row.setAttribute('align', 'center');
                    var cell = document.createElement("TD");
                    cell.innerHTML = i + 1;
                    row.appendChild(cell);
                    var cell1 = document.createElement("TD");
                    cell1.innerHTML = ds.Tables[0].Rows[i].Course;
                    row.appendChild(cell1);
                    var cell2 = document.createElement("TD");
                    cell2.innerHTML = ds.Tables[0].Rows[i].CoursePart;
                    row.appendChild(cell2);
                    var cell3 = document.createElement("TD");
                    cell3.innerHTML = ds.Tables[0].Rows[i].InstName;
                    row.appendChild(cell3);
                    var cell4 = document.createElement("TD");
                    cell4.innerHTML = ds.Tables[0].Rows[i].CrPrEligibility;
                    row.appendChild(cell4);
                    var cell5 = document.createElement("TD");
                    cell5.innerHTML = ds.Tables[0].Rows[i].CrPrStatus;
                    row.appendChild(cell5);
                    tbl.appendChild(row);
                }
                document.getElementById('DGMCourseDetails').style.display = "block";
            }

            if (ds.Tables[1].Rows.length > 0) {
                //alert("In Table 1");
                document.getElementById('lblMPRN').innerText = ds.Tables[1].Rows[0].PRN;
                document.getElementById('lblMAlumni').innerText = ds.Tables[1].Rows[0].Alumini;
                document.getElementById('lblMNameOfStudent').innerText = ds.Tables[1].Rows[0].Last_Name + " " + ds.Tables[1].Rows[0].First_Name + " " + ds.Tables[1].Rows[0].Middle_Name;
                document.getElementById('lblMMothersMaidenName').innerText = ds.Tables[1].Rows[0].Mother_Last_Name + " " + ds.Tables[1].Rows[0].Mother_First_Name + " " + ds.Tables[1].Rows[0].Mother_Middle_Name;
                document.getElementById('lblMFathersName').innerText = ds.Tables[1].Rows[0].Father_Last_Name + " " + ds.Tables[1].Rows[0].Father_First_Name + " " + ds.Tables[1].Rows[0].Father_Middle_Name;
                if (ds.Tables[1].Rows[0].Changed_Name_Flag == "1") {
                    document.getElementById('lblMPreviousName').innerText = ds.Tables[1].Rows[0].Prev_Last_Name + " " + ds.Tables[1].Rows[0].Prev_First_Name + " " + ds.Tables[1].Rows[0].Prev_Middle_Name;
                    document.getElementById('trMChangedName').style.display = "block";
                }
                document.getElementById('lblMGender').innerText = ds.Tables[1].Rows[0].Gender_Desc;
                document.getElementById('lblMDOB').innerText = ds.Tables[1].Rows[0].DOB;                   //Gender,Date_of_Birth,Changed_Name_Reason
                document.getElementById('lblMNationality').innerText = ds.Tables[1].Rows[0].Nationality;
            }
            if (ds.Tables[2].Rows.length > 0) {
                document.getElementById('lblMDomicileState').innerText = ds.Tables[2].Rows[0].Domicile_of_State;
                document.getElementById('lblMResvCategory').innerText = ds.Tables[2].Rows[0].Category;
                if (ds.Tables[2].Rows[0].Category_Flag == "1") {
                    if (ds.Tables[2].Rows[0].ResvCategory != "") {
                        document.getElementById('lblMResvCategory').innerText = document.getElementById('lblMResvCategory').innerText + " (" + ds.Tables[2].Rows[0].ResvCategory;
                        if (ds.Tables[2].Rows[0].SubCaste != "")
                            document.getElementById('lblMResvCategory').innerText = document.getElementById('lblMResvCategory').innerText + " - " + ds.Tables[2].Rows[0].SubCaste;
                        document.getElementById('lblMResvCategory').innerText = document.getElementById('lblMResvCategory').innerText + ")";
                    }
                }
                if (ds.Tables[2].Rows[0].Physically_Challenged_Flag == "1")
                    document.getElementById('lblMPhyChlngd').innerText = ds.Tables[2].Rows[0].PhysicallyChallenged;
                else
                    document.getElementById('lblMPhyChlngd').innerText = "     -";
                document.getElementById('lblMGuardianincome').innerText = ds.Tables[2].Rows[0].Guardian_Annual_Income;
                document.getElementById('lblMGuardianOccupation').innerText = ds.Tables[2].Rows[0].GuardOccupation;
            }
            if (ds.Tables[3].Rows.length > 0) {
                for (var i = 0; i < ds.Tables[3].Rows.length; i++) {
                    document.getElementById('lblMSocResv').innerText = document.getElementById('lblMSocResv').innerText + ds.Tables[3].Rows[i].SocialReservation_Description;
                    if (i < (ds.Tables[3].Rows.length - 1))
                        document.getElementById('lblMSocResv').innerText = document.getElementById('lblMSocResv').innerText + ", ";
                }
            }
            if (ds.Tables[4].Rows.length > 0) {
                var tbl = document.getElementById("DGMQualification").getElementsByTagName("tbody")[0];
                if (tbl.rows.length != 0) {
                    var cnt = tbl.rows.length;
                    for (var k = 1; k < cnt && k != cnt; k++) {
                        if (tbl.rows.length != 0) {
                            tbl.deleteRow(1);
                        }
                    }
                }
                for (var i = 0; i < ds.Tables[4].Rows.length; i++) {
                    var row = document.createElement("TR");
                    row.setAttribute('align', 'center');
                    var cell = document.createElement("TD");
                    cell.innerHTML = ds.Tables[4].Rows[i].Qualification;
                    row.appendChild(cell);
                    var cell1 = document.createElement("TD");
                    cell1.innerHTML = ds.Tables[4].Rows[i].CollegeInstituteName;
                    row.appendChild(cell1);
                    var cell2 = document.createElement("TD");
                    cell2.innerHTML = ds.Tables[4].Rows[i].Body;
                    row.appendChild(cell2);
                    var cell3 = document.createElement("TD");
                    cell3.innerHTML = ds.Tables[4].Rows[i].Marks_Obtained;
                    row.appendChild(cell3);
                    var cell4 = document.createElement("TD");
                    cell4.innerHTML = ds.Tables[4].Rows[i].Marks_OutOf;
                    row.appendChild(cell4);
                    var cell5 = document.createElement("TD");
                    cell5.innerHTML = ds.Tables[4].Rows[i].DateOfPassing;
                    row.appendChild(cell5);
                    tbl.appendChild(row);
                }
                document.getElementById('DGMQualification').style.display = "block";
            }

            if (ds.Tables[5].Rows.length > 0) {
                var tbl = document.getElementById("DGMSubmittedDocs").getElementsByTagName("tbody")[0];
                if (tbl.rows.length != 0) {
                    var cnt = tbl.rows.length;
                    for (var k = 1; k < cnt && k != cnt; k++) {
                        if (tbl.rows.length != 0) {
                            tbl.deleteRow(1);
                        }
                    }
                }
                for (var i = 0; i < ds.Tables[5].Rows.length; i++) {
                    var row = document.createElement("TR");
                    //row.setAttribute('align','center');
                    var cell = document.createElement("TD");
                    cell.innerHTML = (i + 1);
                    cell.setAttribute('align', 'center');
                    row.appendChild(cell);
                    var cell1 = document.createElement("TD");
                    cell1.innerHTML = ds.Tables[5].Rows[i].DocCert_Desc;
                    row.appendChild(cell1);
                    var cell2 = document.createElement("TD");
                    cell2.innerHTML = "Received";
                    cell2.setAttribute('align', 'center');
                    row.appendChild(cell2);
                    var cell3 = document.createElement("TD");
                    cell3.innerHTML = ds.Tables[5].Rows[i].ReceivedByUniversity;
                    cell3.setAttribute('align', 'center');
                    row.appendChild(cell3);
                    tbl.appendChild(row);
                }
                document.getElementById('DGMSubmittedDocs').style.display = "block";
            }

            if (document.getElementById('divMStudentDetails').style.display == "none") {
                document.getElementById('divMStudentDetails').style.display = "block";
            }
            document.getElementById('divMStudentDetails').style.top = 100;
            document.getElementById('divMStudentDetails').style.left = 220;

            //divMStudentDetails


        }

        function fnDocRecv(cbDocRecv) {
            var cbID = document.getElementById(cbDocRecv.id);
            var cnt = document.getElementById('ctl00_ContentPlaceHolder1_hidDocCnt').value;
            if (cbID.checked == true) {
                for (i = 1; i <= cnt; i++) {

                    var strCB = document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 3].innerHTML;
                    if (strCB.match(cbID.id) != null) {
                        var strRB = document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 4].innerHTML;
                        while (strRB.match("disabled") != null) {
                            strRB = strRB.replace(/disabled/, "");
                        }
                        if (strRB.match("value=rbValidDoc") != null)
                            strRB = strRB.replace(/value=rbValidDoc/, "value=rbValidDoc checked=\"checked\" ");
                        document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 4].innerHTML = strRB;
                    }
                }
            }
            if (cbID.checked == false) {
                for (i = 1; i <= cnt; i++) {

                    var strCB = document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 3].innerHTML;
                    if (strCB.match(cbID.id) != null) {
                        var strRB = document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 4].innerHTML;
                        while (strRB.match("<SPAN>") != null)
                            strRB = strRB.replace(/<SPAN>/, "<SPAN disabled>");
                        strRB = strRB.replace(/value=rbValidDoc/, "value=rbValidDoc disabled ");
                        strRB = strRB.replace(/value=rbInvalidDoc/, "value=rbInvalidDoc disabled ");
                        while (strRB.match("CHECKED") != null)
                            strRB = strRB.replace(/CHECKED/, "");
                        strRB = strRB.replace("", "<SPAN disabled>");
                        document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 4].innerHTML = strRB;
                    }
                }
            }
        }

        function fnOnSubmit() {
            var cnt = document.getElementById('ctl00_ContentPlaceHolder1_hidDocCnt').value;
            var DocXML = document.getElementById('ctl00_ContentPlaceHolder1_hidDocXML');
            DocXML.value = "";
            for (var i = 1; i <= cnt; i++) {

                if (document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 3].childNodes[1].checked == true) {
                    DocXML.value = DocXML.value + "1";    //Recieved_By_Uni = 1
                    if (document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 4].childNodes[1].childNodes[0].checked == true)
                        DocXML.value = DocXML.value + "1";   //Validity_By_Uni = 1
                    if (document.getElementById('ctl00_ContentPlaceHolder1_DGSubmittedDocs1').cells[7 * i + 4].childNodes[3].childNodes[0].checked == true)
                        DocXML.value = DocXML.value + "0";  //Validity_By_Uni = 0
                }
                else {
                    DocXML.value = DocXML.value + "00";
                }
            }
            debugger;

        }


        function fnDisplayDiv() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_rbProvisional').checked == true)
                document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'block';
            if (document.getElementById('ctl00_ContentPlaceHolder1_rbDefaulter').checked == true)
                document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'block';
            if (document.getElementById('ctl00_ContentPlaceHolder1_rbPending').checked == true)
                document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'block';
            if (document.getElementById('ctl00_ContentPlaceHolder1_rbEligible').checked == true)
                document.getElementById('ctl00_ContentPlaceHolder1_divReason').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').disabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_btnCancel').disabled = false;

        }


        function fnConfirm() {
            var ch;
            if (document.getElementById('ctl00_ContentPlaceHolder1_rbDefaulter').checked == true) {
                if (document.getElementById('ctl00_ContentPlaceHolder1_tbReason').value == "") {
                    alert('Please Enter a Valid Reason for marking this Student Not Eligible');
                    return false;
                }
                ch = confirm('Are you sure you want to mark this student as \"Not Eligible\" ?');
            }
            else if (document.getElementById('ctl00_ContentPlaceHolder1_rbPending').checked == true) {
                if (document.getElementById('ctl00_ContentPlaceHolder1_tbReason').value == "") {
                    alert('Please Enter a Valid Reason for keeping the Eligibility of Student Pending');
                    return false;
                }
                ch = confirm('Are you sure you want to keep the Eligibility of this student as \"Pending\" ?');
            }
            else if (document.getElementById('ctl00_ContentPlaceHolder1_rbProvisional').checked == true) {
                if (document.getElementById('ctl00_ContentPlaceHolder1_tbReason').value == "") {
                    alert('Please Enter a Valid Reason for keeping the Eligibility of Student Provisional');
                    return false;
                }
                ch = confirm('Are you sure you want to keep the Eligibility of this student as \"Provisional\" ?');
            }
            else if (document.getElementById('ctl00_ContentPlaceHolder1_rbEligible').checked == true)
                ch = confirm('Are you sure you want to mark this student as \"Eligible\" ?');
            fnOnSubmit();
            return ch;
        }

        function fnHelp() {
            document.getElementById('ctl00_ContentPlaceHolder1_divInstructions').style.display = "block";
            document.getElementById('ctl00_ContentPlaceHolder1_divInstructions').style.top = 255;
            document.getElementById('ctl00_ContentPlaceHolder1_divInstructions').style.left = 220;
        }

        /*
        function CheckCollUniStatus()
        {
		
        document.getElementById('divElgStstusCollege').style.display="block";
		   
		
        }
        */
		
    </script>
    <center>
        <table id="table1" style="border-collapse: collapse" bordercolor="#c0c0c0" cellpadding="2"
            width="700" border="1">
            <tr>
                <%--<td class="FormName" align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server" CssClass="lblPageHead" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblInstitute" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label>--%>
                <td align="left" style="border-bottom: 1px solid #FFD275;">
                    <asp:Label ID="lblPageHead" runat="server" meta:resourcekey="lblPageHeadResource1"></asp:Label>
                    <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" ForeColor="Black" meta:resourcekey="lblSubHeaderResource1"></asp:Label>
                    <asp:Label ID="lblStudName" runat="server" Font-Size="X-Small" meta:resourcekey="lblStudNameResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <p>
                        <div id="divMatchingRecords" style="display: none" runat="server">
                            <br>
                            <asp:Label ID="lblGridName" runat="server" CssClass="GridHeadingM" Height="18px"
                                Width="100%" meta:resourcekey="lblGridNameResource1" Text="Details of the Matching Records"></asp:Label><br>
                            <b>Note:</b><br>
                            <div>
                                <ol>
                                    <li>System has found that, the details of this student are matching with details of
                                        already registered student(s), as displayed in following table.
                                        <li>Please click on the student's name in the table to view and compare the profiles.
                                            <li>If you need to associate the student with any of the matching profiles, please click
                                                on the check box against that profile, in the following table. </li>
                                </ol>
                            </div>
                            <asp:GridView ID="DGMatchingRecords1" runat="server" Width="100%" BorderStyle="Solid"
                                PageSize="1" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699"
                                meta:resourcekey="DGMatchingRecords1Resource1">
                                <RowStyle CssClass="gridItem" />
                                <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource1">
                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                        <ItemTemplate>
                                            <center>
                                                <%# (Container.DataItemIndex)+1 %>
                                                <center>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudentName" runat="server" ForeColor="#666666" Style="cursor: hand;"
                                                meta:resourcekey="lblStudentNameResource1"><%# Convert.ToString(DataBinder.Eval(Container.DataItem, "StudName")) %></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ExistingPRN" HeaderText="PRN" meta:resourcekey="BoundFieldResource1">
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Alumini" ReadOnly="True" HeaderText="Alumini of Univeristy"
                                        meta:resourcekey="BoundFieldResource2">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CertificateNo" HeaderText="10th First Certificate No."
                                        meta:resourcekey="BoundFieldResource3">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PassingDate" HeaderText="10th Passing Year" meta:resourcekey="BoundFieldResource4">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SSCBoard" HeaderText="10th Examination  Board" meta:resourcekey="BoundFieldResource5">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource3">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelection" onclick="fnCheckSelection(this);" runat="server" meta:resourcekey="cbSelectionResource1">
                                            </asp:CheckBox>&nbsp;
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pkYear" ReadOnly="True" HeaderText="pkYear" meta:resourcekey="BoundFieldResource6">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pkStudentID" ReadOnly="True" HeaderText="pkStudentID"
                                        meta:resourcekey="BoundFieldResource7"></asp:BoundField>
                                </Columns>
                                <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                            </asp:GridView>
                            <br>
                        </div>
                        <div id="divMStudentDetails" style="border-right: #800000 solid; border-top: #800000 solid;
                            display: none; border-left: #800000 solid; width: 760px; border-bottom: #800000 solid;
                            position: absolute; top: 100px; height: 200px; background-color: white" runat="server">
                            <table onmousedown="dragStart(event, 'divMStudentDetails')" style="cursor: move;
                                background-color: #800000" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="GridHeadingM1" width="100%">
                                        <asp:Label ID="lblMProfileHeading" runat="server" Height="18px" meta:resourcekey="lblMProfileHeadingResource1"
                                            Text="Selected Student's Profile"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <img id="imgClose" style="cursor: hand" onclick="WinClose('imgClose')" src="../images/closeBtn.GIF"
                                            align="right">
                                    </td>
                                </tr>
                            </table>
                            <div id="divScroll" style="overflow: auto; top: 100px;" runat="server">
                                <br>
                                <br>
                                <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                    <tr class="GridSubHeadingM">
                                        <td colspan="4">
                                            <b>Registration Details of the Student</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td valign="top" width="30%">
                                            <b>
                                                <asp:Label ID="lblPermanentRNumber" runat="server" Text="Permanent Registration Number"
                                                    meta:resourcekey="lblPermanentRNumberResource1"></asp:Label>
                                            </b>
                                            <td valign="top" width="20%">
                                                <asp:Label ID="lblMPRN" runat="server" meta:resourcekey="lblMPRNResource1"></asp:Label>
                                            </td>
                                            <td valign="top" width="30%">
                                                <b>Alumni of
                                                    <%= lblUniversity.Text %>
                                                </b>
                                            </td>
                                            <td valign="top" width="20%">
                                                <asp:Label ID="lblMAlumni" runat="server" meta:resourcekey="lblMAlumniResource1"
                                                    Text="No"></asp:Label>
                                            </td>
                                    </tr>
                                </table>
                                <br>
                                <table class="tblBackColor" id="Tbl2" cellspacing="1" cellpadding="3" width="100%"
                                    border="0">
                                    <tbody>
                                        <tr class="GridSubHeadingM">
                                            <td style="height: 18px" colspan="4">
                                                <b>Admission Details of the Student</b>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class="GridDataM" id="DGMCourseDetails" style="display: none; width: 100%;
                                    border-collapse: collapse" bordercolor="#600000" cellspacing="0" rules="all"
                                    border="1">
                                    <tr class="GridHeadingM2" align="center">
                                        <td>
                                            Sr. No.
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCourses" runat="server" Text="Course" meta:resourcekey="lblCoursesResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCoursePart" runat="server" Text="Course Part" meta:resourcekey="lblCoursePartResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <%=lblCollege.Text %>
                                            Name
                                        </td>
                                        <td>
                                            Eligibility Status
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCourseStatus" runat="server" Text="Course Status" meta:resourcekey="lblCourseStatusResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <table id="Table2" cellspacing="0" cellpadding="3" width="100%" border="0">
                                    <tr>
                                        <td valign="top" width="80%">
                                            <table class="tblBackColor" id="Table3" cellspacing="1" cellpadding="3" width="100%"
                                                border="0">
                                                <tr class="GridSubHeadingM">
                                                    <td style="height: 16px" valign="top" colspan="4">
                                                        <b>Personal Details of&nbsp;the Student</b>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" width="30%">
                                                        <b>Full Name</b>
                                                    </td>
                                                    <td valign="top" colspan="3">
                                                        <asp:Label ID="lblMNameOfStudent" runat="server" meta:resourcekey="lblMNameOfStudentResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" width="30%">
                                                        <b>Father's Full Name</b>
                                                    </td>
                                                    <td valign="top" colspan="3">
                                                        <asp:Label ID="lblMFathersName" runat="server" meta:resourcekey="lblMFathersNameResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" width="30%">
                                                        <b>Mother's Maiden Name</b>
                                                    </td>
                                                    <td valign="top" colspan="3">
                                                        <asp:Label ID="lblMMothersMaidenName" runat="server" meta:resourcekey="lblMMothersMaidenNameResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="rFont" id="trMChangedName" style="display: none" runat="server">
                                                    <td valign="top" width="30%">
                                                        <b>Previous&nbsp;Name</b>
                                                    </td>
                                                    <td valign="top" colspan="3">
                                                        <asp:Label ID="lblMPreviousName" runat="server" meta:resourcekey="lblMPreviousNameResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" width="30%">
                                                        <b>Date of Birth</b>
                                                    </td>
                                                    <td valign="top" width="30%">
                                                        <asp:Label ID="lblMDOB" runat="server" meta:resourcekey="lblMDOBResource1"></asp:Label>
                                                    </td>
                                                    <td valign="top" width="20%">
                                                        <b>Gender</b>
                                                    </td>
                                                    <td valign="top" width="20%">
                                                        <asp:Label ID="lblMGender" runat="server" meta:resourcekey="lblMGenderResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" width="20%">
                                                        <b>Nationality</b>
                                                    </td>
                                                    <td valign="top" colspan="3">
                                                        <asp:Label ID="lblMNationality" runat="server" meta:resourcekey="lblMNationalityResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" width="20%">
                                            <table class="tblBackColor" id="Table4" cellspacing="1" cellpadding="3" width="100%"
                                                border="0">
                                                <tr class="GridSubHeadingM">
                                                    <td style="height: 16px" valign="top" align="center">
                                                        <b>Photograph</b>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" align="center">
                                                        <img id="ImageM1">
                                                    </td>
                                                </tr>
                                                <tr class="GridSubHeadingM">
                                                    <td style="height: 16px" valign="top" align="center">
                                                        <b>Signature</b>
                                                    </td>
                                                </tr>
                                                <tr class="rFont">
                                                    <td valign="top" align="center">
                                                        <img id="ImageM2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table class="tblBackColor" id="Table5" cellspacing="1" cellpadding="3" width="100%"
                                    border="0">
                                    <tr class="GridSubHeadingM">
                                        <td style="height: 16px" valign="top" colspan="4">
                                            <b>Reservation Details of the Student</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td valign="top" width="20%">
                                            <b>State of Domicile</b>
                                        </td>
                                        <td valign="top" width="30%">
                                            <asp:Label ID="lblMDomicileState" runat="server" meta:resourcekey="lblMDomicileStateResource1"></asp:Label>
                                        </td>
                                        <td valign="top" width="20%">
                                            <b>Reservation Category</b>
                                        </td>
                                        <td valign="top" width="30%">
                                            <asp:Label ID="lblMResvCategory" runat="server" meta:resourcekey="lblMResvCategoryResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td valign="top" width="20%">
                                            <b>Physically Challenged</b>
                                        </td>
                                        <td valign="top" colspan="3">
                                            <asp:Label ID="lblMPhyChlngd" runat="server" meta:resourcekey="lblMPhyChlngdResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td valign="top">
                                            <b>Social Reservation</b>
                                        </td>
                                        <td valign="top" colspan="3">
                                            <asp:Label ID="lblMSocResv" runat="server" meta:resourcekey="lblMSocResvResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                    <tr class="GridSubHeadingM">
                                        <td style="height: 16px" valign="top" colspan="4">
                                            <b>Guardian Details of the Student</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td valign="top" width="30%">
                                            <b>Annual Income of the Guardian</b>
                                        </td>
                                        <td valign="top" width="20%">
                                            <asp:Label ID="lblMGuardianincome" runat="server" meta:resourcekey="lblMGuardianincomeResource1"></asp:Label>
                                        </td>
                                        <td valign="top" width="30%">
                                            <b>Occupation of the Guardian</b>
                                        </td>
                                        <td valign="top" width="20%">
                                            <asp:Label ID="lblMGuardianOccupation" runat="server" meta:resourcekey="lblMGuardianOccupationResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <table class="tblBackColor" id="Table6" cellspacing="1" cellpadding="3" width="100%"
                                    border="0">
                                    <tr class="GridSubHeadingM">
                                        <td style="height: 16px" valign="top">
                                            <b>Educational Details&nbsp;of the Student</b>
                                        </td>
                                    </tr>
                                </table>
                                <table id="DGMQualification" style="display: none" bordercolor="gainsboro" cellspacing="0"
                                    cellpadding="0" width="100%" border="1">
                                    <tr align="center">
                                        <td>
                                            <b>Qualification</b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblColleges" runat="server" Text="College" meta:resourcekey="lblCollegesResource1"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblUniversitys" runat="server" Text="University" meta:resourcekey="lblUniversitysResource1"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>Marks</b>
                                        </td>
                                        <td>
                                            <b>Out of</b>
                                        </td>
                                        <td>
                                            <b>Passing Date</b>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <table class="tblBackColor" id="Tbl4" cellspacing="1" cellpadding="3" width="100%"
                                    border="0">
                                    <tr class="GridSubHeadingM">
                                        <td style="height: 16px" valign="top">
                                            <b>Documents Submitted by the Student</b>
                                        </td>
                                    </tr>
                                </table>
                                <table class="GridDataM" id="DGMSubmittedDocs" style="display: none; width: 100%;
                                    border-collapse: collapse" bordercolor="#600000" cellspacing="0" rules="all"
                                    border="1">
                                    <tr class="GridHeadingM2" align="center">
                                        <td>
                                            Sr. No.
                                        </td>
                                        <td>
                                            Document Name
                                        </td>
                                        <td>
                                            Received By
                                            <%= lblCollege.Text %>
                                        </td>
                                        <td>
                                            Received By
                                            <%= lblUniversity.Text %>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <br>
                            </div>
                        </div>
                        <div id="divStudentDetails" style="display: block" runat="server">
                            <br>
                            <asp:Label ID="lblStudentProfile" runat="server" CssClass="GridHeadingM" Height="18px"
                                Width="100%" meta:resourcekey="lblStudentProfileResource1" Text="Student Profile Whose Eligibility is Under Consideration"></asp:Label><br>
                            <asp:Label ID="lblInstructions" Style="cursor: hand" onclick="fnHelp();" Font-Bold="True"
                                runat="server" ForeColor="Green" meta:resourcekey="lblInstructionsResource1"
                                Text="Click here to view Instructions for Eligibility Decision"></asp:Label><br>
                            <br>
                            <div id="divInstructions" style="border-right: green solid; border-top: green solid;
                                display: none; border-left: green solid; width: 300px; border-bottom: green solid;
                                position: absolute; height: 200px; background-color: white" runat="server">
                                <table onmousedown="dragStart(event, 'divInstructions')" style="cursor: move; background-color: green"
                                    cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="GridHeadingMI" width="100%">
                                            <asp:Label ID="lblInstructionHead" runat="server" Height="18px" meta:resourcekey="lblInstructionHeadResource1"
                                                Text="Instructions for Eligibility Decision"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <img id="imgIClose" style="cursor: hand" onclick="WinClose('imgIClose')" src="../images/closeBtn.GIF"
                                                align="right">
                                        </td>
                                    </tr>
                                </table>
                                <div id="divIScroll" style="overflow: auto; height: 200px" runat="server">
                                    <br>
                                    <b>Instructions to be followed for the eligibility decision of a student: </b>
                                    <br>
                                    <ol>
                                        <li><font color="black">Please view the displayed profile of the student whose Eligibility
                                            is under consideration.<br>
                                            <br>
                                        </font>
                                            <li><font color="black">View the list of documents submitted by the student at the
                                                <%= lblCollege.Text %>
                                                level.</font><br>
                                                <br>
                                                <li><font color="black">Tick the check box against the document ,if the hard copy of
                                                    the document is recieved by the
                                                    <%= lblUniversity.Text %>
                                                    .</font><br>
                                                    <br>
                                                    <li><font color="black">Determine the validity of the received documents by marking
                                                        'valid' / 'invalid'.</font><br>
                                                        <br>
                                                        <li><font color="black">Take the eligibility decision by marking 'Eligible' / 'Not Eligible'
                                                            / 'Pending Eligible'.</font><br>
                                                            <br>
                                                            <li><font color="black">Specify the reason if the student is marked as 'Not Eligible'
                                                                / 'Pending Eligible'. </font>
                                                                <br>
                                                                <br>
                                                                <li><font color="black">Click on 'Cancel' button to change the Eligibility decision(only
                                                                    before submitting).</font><br>
                                                                    <br>
                                                                    <li><font color="black">'Submit' the eligibility of the student whose Eligibility is
                                                                        Under Consideration.</font><br>
                                                                        <br>
                                                                    </li>
                                    </ol>
                                    <br>
                                </div>
                            </div>
                            <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top" colspan="4">
                                        <b>Eligibility Form Number of the Student </b>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblEligibilityFormNo" runat="server" Font-Bold="True" meta:resourcekey="lblEligibilityFormNoResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="clSubHeading">
                                    <td valign="top" colspan="4">
                                        <b>
                                            <asp:Label ID="lblPermanentRegistrationNumber" runat="server" Text="Permanent Registration Number"
                                                meta:resourcekey="lblPermanentRegistrationNumberResource1"></asp:Label></b>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblPRNno" runat="server" Font-Bold="True" meta:resourcekey="lblPRNnoResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <br>
                            <table class="tblBackColor" id="Table7" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="clSubHeading">
                                        <td style="height: 18px" colspan="4">
                                            <b>Admission&nbsp;Details of the Student</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%" style="height: 18px">
                                            <b>
                                                <%= lblCollege.Text %>
                                                Name :</b>
                                        </td>
                                        <td colspan="3" style="height: 18px">
                                            <asp:Label ID="lblInstName" runat="server" meta:resourcekey="lblInstNameResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%" style="height: 19px">
                                            <b>Admission Form Number :</b>
                                        </td>
                                        <td width="20%" style="height: 19px">
                                            <asp:Label ID="lblAppFormNo" runat="server" meta:resourcekey="lblAppFormNoResource1"></asp:Label>
                                        </td>
                                        <td width="30%" style="height: 19px">
                                            <b>Admission Date :</b>
                                        </td>
                                        <td width="20%" style="height: 19px">
                                            <asp:Label ID="lblAdmissionDate" runat="server" meta:resourcekey="lblAdmissionDateResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td width="30%">
                                            <b>
                                                <asp:Label ID="lblSeekingAdmCr" runat="server" Text="Seeking Admission in Course"
                                                    meta:resourcekey="lblSeekingAdmCrResource1"></asp:Label>
                                                :</b>
                                        </td>
                                        <td width="70%" colspan="3">
                                            <asp:Label ID="lblCourse" runat="server" meta:resourcekey="lblCourseResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td colspan="4">
                                            <b>
                                                <asp:Label ID="lblPpSelected" runat="server" Text="Papers Selected" meta:resourcekey="lblPpSelectedResource1"></asp:Label>
                                                :</b>
                                        </td>
                                    </tr>
                                    <tr class="rFont">
                                        <td colspan="4">
                                            <asp:Label ID="lblPapers" runat="server" meta:resourcekey="lblPapersResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br>
                            <table id="Table8" cellspacing="0" cellpadding="3" width="100%" border="0">
                                <tr>
                                    <td valign="top" width="80%">
                                        <table class="tblBackColor" id="Table9" cellspacing="1" cellpadding="3" width="100%"
                                            border="0">
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" colspan="4">
                                                    <b>Personal Details of&nbsp;the Student</b>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Name as appeared on Statement of Marks</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNameAsMarksheet" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Full Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNameOfStudent" runat="server" meta:resourcekey="lblNameOfStudentResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Father's Full Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblFathersName" runat="server" meta:resourcekey="lblFathersNameResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Mother's Maiden Name</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblMothersMaidenName" runat="server" meta:resourcekey="lblMothersMaidenNameResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont" id="trChangedName" style="display: none" runat="server">
                                                <td style="height: 30px" valign="top" width="30%">
                                                    <b>Previous&nbsp;Name</b>
                                                </td>
                                                <td style="height: 30px" valign="top" colspan="3">
                                                    <asp:Label ID="lblPreviousName" runat="server" meta:resourcekey="lblPreviousNameResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="30%">
                                                    <b>Date of Birth</b>
                                                </td>
                                                <td valign="top" width="30%">
                                                    <asp:Label ID="lblDOB" runat="server" meta:resourcekey="lblDOBResource1"></asp:Label>
                                                </td>
                                                <td valign="top" width="20%">
                                                    <b>Gender</b>
                                                </td>
                                                <td valign="top" width="20%">
                                                    <asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGenderResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" width="20%">
                                                    <b>Nationality</b>
                                                </td>
                                                <td valign="top" colspan="3">
                                                    <asp:Label ID="lblNationality" runat="server" meta:resourcekey="lblNationalityResource1"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" width="20%">
                                        <table class="tblBackColor" id="Table10" cellspacing="1" cellpadding="3" width="100%"
                                            border="0">
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" align="center">
                                                    <b>Photograph</b>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" align="center">
                                                    <asp:Image ID="Image1" runat="server" AlternateText="Photograph" ImageUrl="../images/Member.gif"
                                                        meta:resourcekey="Image1Resource1"></asp:Image>
                                                </td>
                                            </tr>
                                            <tr class="clSubHeading">
                                                <td style="height: 16px" valign="top" align="center">
                                                    <b>Signature</b>
                                                </td>
                                            </tr>
                                            <tr class="rFont">
                                                <td valign="top" align="center">
                                                    <asp:Image ID="Image2" runat="server" AlternateText="Signature" ToolTip="Signature"
                                                        meta:resourcekey="Image2Resource1"></asp:Image>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Table11" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top" colspan="4">
                                        <b>Reservation Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="20%">
                                        <b>State of Domicile</b>
                                    </td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblDomicileState" runat="server" meta:resourcekey="lblDomicileStateResource1"></asp:Label>
                                    </td>
                                    <td valign="top" width="20%">
                                        <b>Reservation Category</b>
                                    </td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblResvCategory" runat="server" meta:resourcekey="lblResvCategoryResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="20%">
                                        <b>Physically Challenged</b>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblPhyChlngd" runat="server" meta:resourcekey="lblPhyChlngdResource1"></asp:Label>
                                    </td>
                                     <td valign="top" width="20%">
                                        <b>Admitted Category</b>
                                    </td>
                                    <td valign="top" width="30%">
                                        <asp:Label ID="lblAdmittedCategory" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top">
                                        <b>Social Reservation</b>
                                    </td>
                                    <td valign="top" colspan="3">
                                        <asp:Label ID="lblSocResv" runat="server" meta:resourcekey="lblSocResvResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top" colspan="4">
                                        <b>Guardian Details of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" width="30%">
                                        <b>Annual Income of the Guardian</b>
                                    </td>
                                    <td valign="top" width="20%">
                                        <asp:Label ID="lblGuardianincome" runat="server" meta:resourcekey="lblGuardianincomeResource1"></asp:Label>
                                    </td>
                                    <td valign="top" width="30%">
                                        <b>Occupation of the Guardian</b>
                                    </td>
                                    <td valign="top" width="20%">
                                        <asp:Label ID="lblGuardianOccupation" runat="server" meta:resourcekey="lblGuardianOccupationResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Table12" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top">
                                        <b>Educational Details&nbsp;of the Student</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td>
                                        <asp:GridView ID="DGQualification1" runat="server" Width="100%" AutoGenerateColumns="False"
                                            BorderWidth="1px" BorderColor="Gainsboro" meta:resourcekey="DGQualificationResource1">
                                            <Columns>
                                                <asp:BoundField DataField="Qualification" HeaderText="Qualification" meta:resourcekey="BoundFieldResource11">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CollegeInstituteName" HeaderText="College" meta:resourcekey="BoundFieldResource12">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Body" HeaderText="University" meta:resourcekey="BoundFieldResource13">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Marks_Obtained" HeaderText="Marks" meta:resourcekey="BoundFieldResource14">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Marks_OutOf" HeaderText="Out of" meta:resourcekey="BoundFieldResource15">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateOfPassing" HeaderText="Passing Date" meta:resourcekey="BoundFieldResource16">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <br>
                            <table class="tblBackColor" id="Table13" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tr class="clSubHeading">
                                    <td style="height: 16px" valign="top">
                                        <b>Documents submitted by the student.</b>
                                    </td>
                                </tr>
                                <tr class="rFont">
                                    <td valign="top" align="center" width="100%">
                                        <asp:GridView ID="DGSubmittedDocs1" runat="server" Width="90%" BorderStyle="Solid"
                                            PageSize="5" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#336699"
                                            OnRowDataBound="DGSubmittedDocs1_RowDataBound" meta:resourcekey="DGSubmittedDocs1Resource1"
                                            DataKeyNames="Is_Uploaded,FileName,AdmissionMode">
                                            <RowStyle CssClass="gridItem" />
                                            <HeaderStyle CssClass="gridHeader" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No." meta:resourcekey="TemplateFieldResource4">
                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <center>
                                                            <%# (Container.DataItemIndex)+1 %>
                                                            <center>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DocCert_Desc" ReadOnly="True" HeaderText="Document Name"
                                                    meta:resourcekey="BoundFieldResource8">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ReadOnly="True" HeaderText="Received By College" meta:resourcekey="BoundFieldResource9">
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Received By University" meta:resourcekey="TemplateFieldResource5">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbDocRecv" runat="server" onclick="fnDocRecv(this);" meta:resourcekey="cbDocRecvResource1">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Determine Validity " meta:resourcekey="TemplateFieldResource6">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbValidDoc" runat="server" GroupName="grpValidity" Text="Valid"
                                                            Enabled="False" meta:resourcekey="rbValidDocResource1"></asp:RadioButton>
                                                        <asp:RadioButton ID="rbInvalidDoc" runat="server" GroupName="grpValidity" Text="Invalid"
                                                            Enabled="False" meta:resourcekey="rbInvalidDocResource1"></asp:RadioButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="pk_DocCert_ID" ReadOnly="True" HeaderText="Doc_ID" meta:resourcekey="BoundFieldResource10">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <a href="javascript:void(0)" id="lnkViewDoc" runat="server" style="color: Gray; cursor: default;">
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                                    <HeaderStyle CssClass="gridHeader" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle VerticalAlign="Middle" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <asp:Label ID="lblDoctext" CssClass="ErrorNote" runat="server" Visible="False" meta:resourcekey="lblDoctextResource1"></asp:Label></div>
                            <br>
                            <div id="divElgStstusCollege" style="display: none" runat="server">
                                <table class="tblBackColor" cellspacing="1" cellpadding="3" width="100%" border="0">
                                    <tr class="rFont">
                                        <td valign="top" style="height: 21px; width: 49%;">
                                            <b>Student Eligibility Status Decided By
                                                <%= lblCollege.Text %>
                                                :</b>
                                        </td>
                                        <td valign="top" width="100%" style="height: 21px">
                                            <asp:Label ID="lblElgStstusCollege" runat="server" meta:resourcekey="lblElgStstusCollegeResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <asp:Label ID="lblElgStatusUniversity" runat="server" meta:resourcekey="lblElgStatusUniversityResource1"></asp:Label>
                            <div id="divEligibilityDecision" style="display: block" runat="server">
                                <table class="tblBackColor" id="Tbl44" cellspacing="1" cellpadding="3" width="100%"
                                    border="0">
                                    <tr class="rFont">
                                        <td valign="middle" width="32%" style="height: 58px">
                                            <b>Decision of Student's Eligibility</b>
                                        </td>
                                        <td valign="middle" style="height: 58px">
                                            <table width="100%" border="0">
                                                <tr>
                                                    <td width="16%" style="height: 35px">
                                                        <asp:RadioButton ID="rbEligible" runat="server" Text="Eligible" GroupName="grpEligibility"
                                                            meta:resourcekey="rbEligibleResource1"></asp:RadioButton>
                                                    </td>
                                                    <td width="32%" style="height: 35px">
                                                        <asp:RadioButton ID="rbProvisional" runat="server" Text="Provisionally Eligible"
                                                            GroupName="grpEligibility" meta:resourcekey="rbProvisionalResource1"></asp:RadioButton>
                                                    </td>
                                                    <td width="22%" style="height: 35px">
                                                        <asp:RadioButton ID="rbDefaulter" runat="server" Text="Not Eligible" GroupName="grpEligibility"
                                                            meta:resourcekey="rbDefaulterResource1"></asp:RadioButton>
                                                    </td>
                                                    <td width="30%" style="height: 35px">
                                                        <asp:RadioButton ID="rbPending" runat="server" Text="Eligibility Pending" GroupName="grpEligibility"
                                                            meta:resourcekey="rbPendingResource1"></asp:RadioButton>
                                                    </td>
                                                </tr>
                                            </table>
                                    </tr>
                                </table>
                                <div id="divReason" style="display: none" runat="server">
                                    <table class="tblBackColor" id="Table14" cellspacing="1" cellpadding="3" width="100%">
                                        <tr class="rFont">
                                            <td valign="top" width="39%">
                                                <b>Reason(s) for Denying Eligibility / Pending Eligibility </b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbReason" runat="server" CssClass="textarea" Height="30px" Width="466px"
                                                    TextMode="MultiLine" meta:resourcekey="tbReasonResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <br>
                                <table id="Table15" cellspacing="0" cellpadding="5" align="center" border="0">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="butSubmit" Text="Submit" Enabled="False"
                                                OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1"></asp:Button>
                                        </td>
                                        <td style="width: 5px">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="butSubmit" Text="Cancel" Enabled="False"
                                                meta:resourcekey="btnCancelResource1"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br>
                            <br>
                            <div id="divPRN" style="display: none" runat="server">
                                <table id="Table16" cellspacing="0" cellpadding="3" width="100%" align="center" border="0">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblPRN" runat="server" CssClass="StylePRN" meta:resourcekey="lblPRNResource1"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblRefresh" runat="server" CssClass="StylePRN" Style="position: relative"
                                                meta:resourcekey="lblRefreshResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 19px">
                                            <asp:Label ID="lblSMSError" runat="server" CssClass="StylePRN" Style="position: relative"
                                                meta:resourcekey="lblSMSErrorResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <table id="Table17" cellspacing="0" cellpadding="5" align="center" border="0">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnGoTo" runat="server" CssClass="butSubmit" Text="Go To Student List"
                                            OnClick="btnGoTo_Click" meta:resourcekey="btnGoToResource1"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                        <!--Main Ends-->
                        <input id="hidUniID" style="width: 40px; height: 22px" type="hidden" name="hidUniID"
                            runat="server" />
                        <input id="hidPRN" style="width: 40px; height: 22px" type="hidden" name="hidPRN"
                            runat="server" />
                        <input id="hidMatchingRecCount" style="width: 40px; height: 22px" type="hidden" name="hidMatchingRecCount"
                            runat="server" />
                        <input id="hidDocCnt" style="width: 40px; height: 22px" type="hidden" name="hidDocCnt"
                            runat="server" />
                        <input id="hidElgFormNo" style="width: 40px; height: 22px" type="hidden" name="hidElgFormNo"
                            runat="server" />
                        <input id="hidStudentName" style="width: 40px; height: 22px" type="hidden" name="hidStudentName"
                            runat="server" />
                        <input id="hidReturnFlag" style="width: 40px; height: 22px" type="hidden" name="hidReturnFlag"
                            runat="server" />
                        <!--For making it CDV2 Compatible -->
                        <input id="hidFacID" style="width: 40px; height: 22px" type="hidden" name="hidFacID"
                            runat="server" />
                        <input id="hidCrID" style="width: 40px; height: 22px" type="hidden" name="hidCrID"
                            runat="server" />
                        <input id="hidMoLrnID" style="width: 40px; height: 22px" type="hidden" name="hidMoLrnID"
                            runat="server" />
                        <input id="hidPtrnID" style="width: 40px; height: 22px" type="hidden" name="hidPtrnID"
                            runat="server" />
                        <input id="hidBrnID" style="width: 40px; height: 22px" type="hidden" name="hidBrnID"
                            runat="server" />
                        <input id="hidCrPrDetailsID" style="width: 40px; height: 22px" type="hidden" name="hidCrPrDetailsID"
                            runat="server" />
                        <input id="hidAcademicYr" name="hidAcademicYr" type="hidden" runat="server" />
                        <input id="hid_fk_AcademicYr_ID" runat="server" name="hid_fk_AcademicYr_ID" type="hidden" />
                        <input id="hidDocXML" style="width: 40px; height: 22px" type="hidden" name="hidDocXML"
                            runat="server">
                        <input id="hidInstID" runat="server" name="hidInstID" style="width: 24px; height: 22px"
                            type="hidden" />
                        <input id="hidpkStudentID" runat="server" name="hidpkStudentID" type="hidden" value="0" />
                        <input id="hidpkYear" runat="server" name="hidpkYear" type="hidden" value="0" />
                        <input id="hidCollElgFlag" runat="server" name="hidCollElgFlag" type="hidden" />
                        <input id="hidElgStatusColl" runat="server" name="hidElgStatusColl" type="hidden" />
                        <input id="hidCollElgFlagReason" runat="server" name="hidCollElgFlagReason" type="hidden" />
                        <input id="hidInv" runat="server" name="hidInv" type="hidden" />
                        <input id="hidIsBlank" runat="server" name="hidIsBlank" type="hidden">
                        <!-- Added by Madhu Poclassery for SMS Integration On 06th Oct 2007 -->
                        <input id="hidSMSFirstName" runat="server" name="hidSMSFirstName" type="hidden" value="0" />
                        <input id="hidSMSCrAbbr" runat="server" name="hidSMSCrAbbr" type="hidden" value="0" />
                        <input id="hidSMSMobileNumber" runat="server" name="hidSMSMobileNumber" type="hidden"
                            value="0" />
                        <input id="hidAcademicYrText" type="hidden" name="hidAcademicYrText" runat="server" />
                        <!-- Added by Madhu Poclassery for SMS Integration On 06th Oct 2007 Ends -->
                        <asp:Label ID="lblCr" runat="server" Text="Course" Style="display: none" meta:resourcekey="lblCrResource1"></asp:Label>
                        <asp:Label ID="lblUniversity" runat="server" Text="University" Style="display: none"
                            meta:resourcekey="lblUniversityResource1"></asp:Label>
                        <asp:Label ID="lblCollege" runat="server" Text="College" Style="display: none" meta:resourcekey="lblCollegeResource1"></asp:Label>
                        <asp:Label ID="lblPRNNomenclature" runat="server" Text="PRN" Style="display: none"
                            meta:resourcekey="lblPRNNomenclatureResource1"></asp:Label>
                        <input id="hidBranchName" type="hidden" runat="server">
                        <!--***************** Added by Pankaj on 26/10/2010-->
                        <input id="hidPRNorElgFormNo" style="width: 40px; height: 22px" type="hidden" name="hidPRNorElgFormNo"
                            runat="server" />
                        <input id="hidGender" style="width: 40px; height: 22px" type="hidden" name="hidGender"
                            runat="server" />
                        <input id="hidLastName" style="width: 40px; height: 22px" type="hidden" name="hidLastName"
                            runat="server" />
                        <input id="hidFirstName" style="width: 40px; height: 22px" type="hidden" name="hidFirstName"
                            runat="server" />
                        <input id="hidDOB" style="width: 40px; height: 22px" type="hidden" name="hidDOB"
                            runat="server" />
                        <input id="hidddlFaculty" style="width: 40px; height: 22px" type="hidden" name="hidddlFaculty"
                            runat="server" />
                        <input id="hidddlCourse" style="width: 40px; height: 22px" type="hidden" name="hidddlCourse"
                            runat="server" />
                        <input id="hidddlMoLrn" style="width: 40px; height: 22px" type="hidden" name="hidddlMoLrn"
                            runat="server" />
                        <input id="hidddlCrPtrn" style="width: 40px; height: 22px" type="hidden" name="hidddlCrPtrn"
                            runat="server" />
                        <input id="hidddlBranch" style="width: 40px; height: 22px" type="hidden" name="hidddlBranch"
                            runat="server" />
                        <input id="hidUniAbbrv" type="hidden" runat="server" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
