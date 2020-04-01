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

namespace StudentRegistration.Eligibility
{
    public partial class BulkInsert_Uni_StudentStatus : System.Web.UI.Page
    {
        string ElgFormNo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.clsCache.NoCache();
            string sElgFormNo = Request.QueryString["ElgFormNo"].ToString();
            //Session["ElgFormNo"] = sElgFormNo.Trim();
            string sUniID = Request.QueryString["UniID"].ToString();
            string sYear = Request.QueryString["Year"].ToString();
            string sInstID = Request.QueryString["InstID"].ToString();
            string sStudID = Request.QueryString["StudID"].ToString();

            hidElgFormNo.Value = sElgFormNo;
            ElgFormNo = sElgFormNo;
            hidUniID.Value =sUniID;
            hidpkYear.Value = sYear;
            hidpkStudentID.Value = sStudID;
            FetchStudentDetails();
        }

        public void FetchStudentDetails()
        {
            DataSet ds = new DataSet();
            string[] RefIDarr = new string[4];
            RefIDarr = ElgFormNo.Split('-');  
            try
            {
                //ds = clsEligibilityDBAccess.REG_Get_Eligibilitystatusdetails(Convert.ToInt32(hidUniID.Value), Convert.ToInt32(hidpkYear.Value), Convert.ToInt32(hidpkStudentID.Value), Convert.ToInt32(RefIDarr[0].ToString()), Convert.ToInt32(RefIDarr[2].ToString()), Convert.ToInt32(RefIDarr[1].ToString()), Convert.ToInt32(RefIDarr[3].ToString()), hidPRN.Value);
                ds = elgDBAccess.IA_Fetch_Student_Details(RefIDarr[2],UniversityPortal.clsGetSettings.UniversityID.ToString(),RefIDarr[1],RefIDarr[3]);

                if (ds.Tables[2].Rows.Count > 0)
                {
                    //lblPermRegNo.Text = ds.Tables[0].Rows[0]["PRN"].ToString();
                    //lblAlumni.Text = ds.Tables[0].Rows[0]["Alumini_Flag"].ToString();
                    lblNameOfStudent.Text = ds.Tables[2].Rows[0]["Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Middle_Name"].ToString();
                    lblMothersMaidenName.Text = ds.Tables[2].Rows[0]["Mother_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Mother_Middle_Name"].ToString();
                    lblFathersName.Text = ds.Tables[2].Rows[0]["Father_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Father_Middle_Name"].ToString();
                    if (ds.Tables[2].Rows[0]["Changed_Name_Flag"].ToString() == "1")
                    {
                        lblPreviousName.Text = ds.Tables[2].Rows[0]["Prev_Last_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_First_Name"].ToString() + " " + ds.Tables[2].Rows[0]["Prev_Middle_Name"].ToString();
                    }
                    lblGender.Text = ds.Tables[2].Rows[0]["Gender_Desc"].ToString();
                    lblDOB.Text = ds.Tables[2].Rows[0]["DOB"].ToString();                   //Gender,Date_of_Birth,Changed_Name_Reason
                    lblNationality.Text = ds.Tables[2].Rows[0]["Nationality"].ToString();
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    lblDomicileState.Text = ds.Tables[3].Rows[0]["Domicile_of_State"].ToString();
                    lblResvCategory.Text = ds.Tables[3].Rows[0]["Category"].ToString();
                    if (ds.Tables[3].Rows[0]["Category_Flag"].ToString() == "1")
                    {
                        if (ds.Tables[3].Rows[0]["ResvCategory"].ToString() != "")
                        {
                            lblResvCategory.Text += " (" + ds.Tables[3].Rows[0]["ResvCategory"].ToString();
                            if (ds.Tables[3].Rows[0]["SubCaste"].ToString() != "")
                                lblResvCategory.Text += " - " + ds.Tables[3].Rows[0]["SubCaste"].ToString();
                            lblResvCategory.Text += ")";
                        }
                    }
                    if (ds.Tables[3].Rows[0]["Physically_Challenged_Flag"].ToString() == "1")
                        lblPhyChlngd.Text = ds.Tables[3].Rows[0]["PhysicallyChallenged"].ToString();
                    else
                        lblPhyChlngd.Text = "     -";
                    lblGuardianincome.Text = "Rs. " + ds.Tables[3].Rows[0]["Guardian_Annual_Income"].ToString();
                    lblGuardianOccupation.Text = ds.Tables[3].Rows[0]["GuardOccupation"].ToString();
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                    {
                        lblSocResv.Text += ds.Tables[4].Rows[i]["SocialReservation_Description"].ToString();
                        if (i < (ds.Tables[4].Rows.Count - 1))
                            lblSocResv.Text += ", ";
                    }
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    DGQualification.DataSource = ds.Tables[5];
                    DGQualification.DataBind();
                }

                if (ds.Tables[6].Rows.Count > 0)
                {
                    DGSubmittedDocs.DataSource = ds.Tables[6];
                    DGSubmittedDocs.DataBind();
                }
                

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblInstName.Text = ds.Tables[0].Rows[0]["InstName"].ToString();
                    lblEligibilityFormNo.Text = hidElgFormNo.Value;
                    TblAdmission.Style.Remove("display");
                    TblAdmission.Style.Add("display", "block");
                    divTblElgFormdetails.Style.Remove("display");
                    divTblElgFormdetails.Style.Add("display", "block");

                    lblAdmissionDate.Text = ds.Tables[0].Rows[0]["Admission_Date"].ToString();
                    lblAppFormNo.Text = ds.Tables[0].Rows[0]["Admission_Form_No"].ToString();
                    lblCourse.Text = ds.Tables[0].Rows[0]["Course"].ToString() + "-" + ds.Tables[0].Rows[0]["CoursePart"].ToString() + "(" + ds.Tables[0].Rows[0]["Faculty"].ToString() + ")";
                    hidCrMoLrnPtrnID.Value = ds.Tables[0].Rows[0]["pk_CrMoLrnPtrn_ID"].ToString();
                }


               // hidDocCnt.Value = ds.Tables[4].Rows.Count.ToString();
                Image1.ImageUrl = "PhotoAndSignTemp.aspx?img=PI&sElgFormNo="+hidElgFormNo.Value;
                Image1.Visible = true;
                Image2.ImageUrl = "PhotoAndSignTemp.aspx?img=SI&sElgFormNo="+hidElgFormNo.Value;
                Image2.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw new Exception(ex.Message);
            }

            ds.Dispose();
        }

        protected void DGSubmittedDocs_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                e.Item.Cells[0].Text = Convert.ToString(e.Item.ItemIndex + 1);
                e.Item.Cells[2].Text = "Recvd (Valid)";
            }
        }
    }
}
