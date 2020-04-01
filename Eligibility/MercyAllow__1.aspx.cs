using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using Classes;
using Ajax;
using System.Text.RegularExpressions;
//using StudentAccount.Profile.WebCtrl;
using DUConfigurations;
using StudentRegistration.Eligibility.ElgClasses;


namespace StudentRegistration.Eligibility
{
    public partial class MercyAllow_1 : System.Web.UI.Page
    {
        #region User Variables
        //Profile.WebCtrl.StudentProfileSearch RegStudentProfileSearchCtrl;

       

        Hashtable ht = new Hashtable();
        //clsStudent objStudent = new clsStudent();
       // clsStudentCourse objStudCourse = new clsStudentCourse();
        clsCommon objCommon = new clsCommon();
        Hashtable oHSSave = new Hashtable();
                clsRegStudent oStudent = new clsRegStudent();
        clsUser user = new clsUser();
      // clsRegStudent oStudent = new clsRegStudent();
        clsCommon Common = new clsCommon();

        string GoToUrl;
        int temp;
        string pUID = null, pYr = null, pStudID = null;
        static string PRN;


        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {


           

            if (!IsPostBack)
            {

                clsUser user = new clsUser();
                user = (clsUser)Session["user"];
                //hidUser_IDValue = user.User_ID;
                          


                hid_pk_Uni_ID.Value = Classes.clsGetSettings.UniversityID.ToString();
                hid_pk_Student_ID.Value = Session["pkStudent_ID"].ToString();
                hid_pk_Year.Value = Session["pkYear"].ToString();

                pUID = hid_pk_Uni_ID.Value.ToString();
                pYr = hid_pk_Year.Value.ToString();
                pStudID = hid_pk_Student_ID.Value.ToString();

                btnMercyAllow.Enabled = true;
                DisplayContactDetails();

            }
            else
            {

                pUID = hid_pk_Uni_ID.Value.ToString();
                pYr = hid_pk_Year.Value.ToString();
                pStudID = hid_pk_Student_ID.Value.ToString();


            }

            btnMercyAllow.Attributes.Add("onclick", @"return Confirmation()");
        }
        #endregion

        



        #region Display Contact Details
        public void DisplayContactDetails()
        {
            string PRN;
            DataSet ds = new DataSet();
            DataTable tempDT = new DataTable();
            oStudent = new clsRegStudent(Classes.clsGetSettings.UniversityID.ToString(), hid_pk_Year.Value, hid_pk_Student_ID.Value.ToString());
            Session["StudentObj"] = oStudent;

            ds = clsRegStudent.Fetch_StudentReRegistraionCourseDetails(pUID, pYr, pStudID);
            if (ds.Tables[0].Rows.Count > 0)
            {
             
                clsCDN objCDN = new clsCDN();
                DataRow dtRow = objCDN.GetCDNKeys(clsDUConfigurations.Instance.CDNKeys.PhotoSignKey);
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PhotoPath"])))
                    Image1.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[0].Rows[0]["PhotoPath"].ToString(); //"ViewRequestStatus__2.aspx?PStudentID=" + pUID + "-" + pYr + "-" + pStudID;                
                else
                    Image1.ImageUrl = dtRow["Download_Path"].ToString() + "NoPhoto.JPG";
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SignPath"])))
                    Image2.ImageUrl = dtRow["Download_Path"].ToString() + ds.Tables[0].Rows[0]["SignPath"].ToString(); //"ViewRequestStatus__2.aspx?SStudentID=" + pUID + "-" + pYr + "-" + pStudID;
                else
                    Image2.ImageUrl = dtRow["Download_Path"].ToString() + "NoSign.JPG";

                PRN = ds.Tables[0].Rows[0]["PRN_Number"].ToString();
                if ((PRN == "") || (PRN == null) || ((PRN == "&nbsp;")))
                {
                    PRN = "Not Generated";
                    lblPRN.Text = PRN;
                }
                else
                {
                    lblPRN.Text = ds.Tables[0].Rows[0]["PRN_Number"].ToString();
                }
                //lblCourse.Text = ds.Tables[1].Rows[1]["CrDesc"].ToString();
                //lblCollege.Text = ds.Tables[1].Rows[1]["InstName"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {

                    DGCourseInstitute1.DataSource = ds.Tables[1];
                    DGCourseInstitute1.DataBind();
                    DGCourseInstitute1.Visible = true;
                }
                else
                {
                    //Err_Qualification.Visible = true;
                    DGCourseInstitute1.Visible = false;
                    btnMercyAllow.Enabled = false;
                }
                DGCourseInstitute1.Dispose();


            }

            lblNameOfStudent.Text = oStudent.Last_Name + " " + oStudent.First_Name + " " + oStudent.Middle_Name;
            lblNameOnMarksheet.Text = oStudent.Name_QualExamMarkSheet;
            lblFathersName.Text = oStudent.Father_Last_Name + " " + oStudent.Father_First_Name + " " + oStudent.Father_Middle_Name;
            lblMothersMaidenName.Text = oStudent.Mother_Last_Name + " " + oStudent.Mother_First_Name + " " + oStudent.Mother_Middle_Name;
            if (oStudent.Gender == "1")
            {
                lblGender.Text = "Male";
            }
            else if (oStudent.Gender == "2")
            {
                lblGender.Text = "Female";
            }
           
            lblDOB.Text = oStudent.DOB;
       


            
            }

        protected void btnMercyAllow_Click(object sender, EventArgs e)
        {
            DataTable dtMercy = new DataTable();
            hidTargetXML.Value = PrepareXML();
            dtMercy = clsRegStudent.CreateMercy(hid_pk_Year.Value, hid_pk_Student_ID.Value.ToString(),hidTargetXML.Value);

            if (dtMercy != null && dtMercy.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtMercy.Rows[0]["ExecutionStatus"].ToString()) == 1)
                {
                    lblNote.Text = "Reregistration is removed from student and now student is available for exam form generation of next course part term. !!";
                    lblNote.CssClass = "saveNote";


                }
                else
                {
                    lblNote.Text = "Mercy student!!";
                    lblNote.CssClass = "errorNote";
                }
            }//end If .. to check for existing student (error handling)
        }
        #region PrepareXML
        private string PrepareXML()
        {
            XmlDocument xml = null;
            try
            {
                xml = new XmlDocument();
                XmlNode root = xml.CreateNode(XmlNodeType.Element, "Root", "");
                for (int i = 0; i < DGCourseInstitute1.Rows.Count; i++)
                {
                    //Prepare XML
                    CheckBox chk = ((CheckBox)DGCourseInstitute1.Rows[i].FindControl("chkSelect"));
                    if (chk.Checked)
                    {
                        XmlNode childNode = xml.CreateNode(XmlNodeType.Element, "ELEMENT", "");
                        childNode.Attributes.Append(xml.CreateAttribute("pk_Uni_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_Uni_ID"].ToString();
                        root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("pk_Fac_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_Fac_ID"].ToString();
                        root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("pk_Cr_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_Cr_ID"].ToString();
                        root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("pk_MoLrn_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_MoLrn_ID"].ToString();
                        root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("pk_Ptrn_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_Ptrn_ID"].ToString();
                        root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("pk_Brn_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_Brn_ID"].ToString();
                        root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("pk_CrPr_Details_ID")).Value = DGCourseInstitute1.DataKeys[i]["pk_CrPr_Details_ID"].ToString();
                        root.AppendChild(childNode);
                        //childNode.Attributes.Append(xml.CreateAttribute("CrDesc")).Value = DGCourseInstitute1.DataKeys[i]["CrDesc"].ToString();
                        //root.AppendChild(childNode);
                        childNode.Attributes.Append(xml.CreateAttribute("ReRegistration_Flag")).Value = DGCourseInstitute1.DataKeys[i]["ReRegistration_Flag"].ToString();
                        root.AppendChild(childNode);
                        //childNode.Attributes.Append(xml.CreateAttribute("Course")).Value = DGCourseInstitute1.DataKeys[i]["Course"].ToString();
                        //root.AppendChild(childNode);
                        //childNode.Attributes.Append(xml.CreateAttribute("Version_No")).Value = gvTarget.DataKeys[i]["Version_No"].ToString();
                        //root.AppendChild(childNode);
                    }
                }
                xml.AppendChild(root);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return xml.OuterXml.ToString();
        }
        #endregion

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("MercyAllow.aspx");
        }
        }
        #endregion

      



    }
