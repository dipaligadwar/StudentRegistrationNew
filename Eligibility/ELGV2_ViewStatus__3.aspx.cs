using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Classes;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using StudentRegistration.Eligibility;

namespace StudentRegistration.Eligibility
{
    public partial class ELGV2_ViewStatus__3 : System.Web.UI.Page
    {
        public System.Drawing.Image Photograph;
        public System.Drawing.Image Signature;
        clsCache clsCache = new clsCache();

        #region Page_Load

        protected void Page_Load(object sender, System.EventArgs e)
        {
            clsCache.NoCache();
            Response.ContentType = "image/jpeg";
            //string ElgFormNo = Request.QueryString["sElgFormNo"].ToString();
            string strStudentDetails = Request.QueryString["sStudentDetails"].ToString();
            try
            {
                /*if(Request.QueryString["img"]=="PI")
                {
                    DataSet ds;
                    //string ElgFormNo = Session["ElgFormNo"].ToString();
                    string[] arr = new string[4];  
                    arr = ElgFormNo.Split('-');   //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                    ds = elgDBAccess.IA_Fetch_Student_Photograph(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), arr[2], arr[3]);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        byte[] Bytes=(byte[])ds.Tables[0].Rows[0]["Photograph"];
                        System.IO.Stream s=new System.IO.MemoryStream(Bytes);
                        //Photograph=System.Drawing.Image.FromStream(s);
                        Photograph = clsResizeImage.ResizeImage(s, 55, 80);
                        Session["PSession"] = Photograph;
                        if(Photograph != null)
                            Photograph.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                */
                if (Request.QueryString["img"] == "PR")
                {
                    DataSet ds;
                    string[] arr = new string[2];
                    //arr = ElgFormNo.Split('-');  //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                    arr = strStudentDetails.Split('-');

                    ds = elgDBAccess.Reg_Fetch_Student_Photograph(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        /*byte[] Bytes=(byte[])ds.Tables[0].Rows[0]["Photograph"];
                        System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                        Photograph=System.Drawing.Image.FromStream(s);
                        if (Photograph != null)
                            Photograph.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Photograph = clsResizeImage.ResizeImage(s, 55, 80);*/
                        byte[] Bytes = (byte[])ds.Tables[0].Rows[0]["Photograph"];
                        System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                        Photograph = System.Drawing.Image.FromStream(s);
                        Photograph = clsResizeImage.ResizeImage(s, 55, 80);

                        if (Photograph != null)
                            Photograph.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);


                    }

                }
                /*
                else if(Request.QueryString["img"]=="SI")
                {
                    DataSet ds; 
                    //string ElgFormNo = Session["ElgFormNo"].ToString();
                    string[] arr = new string[4];
                    arr = ElgFormNo.Split('-');    //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                    ds = elgDBAccess.IA_Fetch_Student_Signature(arr[2],Classes.clsGetSettings.UniversityID.ToString(), arr[1], arr[3]);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        byte[] Bytes=(byte[])ds.Tables[0].Rows[0]["Signature"];
                        System.IO.Stream s=new System.IO.MemoryStream(Bytes);
                        //Signature=System.Drawing.Image.FromStream(s);
                        Signature = clsResizeImage.ResizeImage(s, 80, 55);
                        Session["SSession"] = Signature;
                        if(Signature != null)
                            Signature.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                */
                if (Request.QueryString["img"] == "SR")
                {
                    DataSet ds;
                    string[] arr = new string[2];
                    //arr = ElgFormNo.Split('-');  //UniID = arr[0], InstID = arr[1], Year = arr[2], StudID = arr[3]
                    arr = strStudentDetails.Split('-');

                    ds = elgDBAccess.Reg_Fetch_Student_Signature(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        byte[] Bytes = (byte[])ds.Tables[0].Rows[0]["Signature"];
                        System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                        //Signature=System.Drawing.Image.FromStream(s);
                        Signature = clsResizeImage.ResizeImage(s, 80, 55);
                        if (Signature != null)
                            Signature.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                else if (Request.QueryString["img"] == "PSession")
                {
                    Photograph = (System.Drawing.Image)Session["PSession"];
                    if (Photograph != null)
                        Photograph.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                else if (Request.QueryString["img"] == "SSession")
                {
                    Signature = (System.Drawing.Image)Session["SSession"];
                    if (Signature != null)
                        Signature.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }


                string PMatchingID = Request.QueryString.Get("PMatchingID");
                if (PMatchingID != null)
                {
                    //string[] arr = PMatchingID.Split('-');
                    string[] arr = strStudentDetails.Split('-');
                    DataSet ds;
                    ds = elgDBAccess.Reg_Fetch_Student_Photograph(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        byte[] Bytes = (byte[])ds.Tables[0].Rows[0]["Photograph"];
                        System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                        Photograph = System.Drawing.Image.FromStream(s);
                        if (Photograph != null)
                            Photograph.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

                string SMatchingID = Request.QueryString.Get("SMatchingID");
                if (SMatchingID != null)
                {
                    //string[] arr = SMatchingID.Split('-');
                    string[] arr = strStudentDetails.Split('-');
                    DataSet ds;
                    ds = elgDBAccess.Reg_Fetch_Student_Signature(Convert.ToInt32(Classes.clsGetSettings.UniversityID.ToString()), Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
                    //ds = elgDBAccess.Reg_Fetch_Student_Signature(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[2]), Convert.ToInt32(arr[3]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        byte[] Bytes = (byte[])ds.Tables[0].Rows[0]["Signature"];
                        System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                        Signature = System.Drawing.Image.FromStream(s);
                        if (Signature != null)
                            Signature.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion
    }
}
