using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Classes;
using System.IO;

namespace StudentRegistration.Eligibility
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PhotoSignHandler : IHttpHandler
    {
        clsEligibilityDBAccess oclsElgDBAccess;
        public void ProcessRequest(HttpContext context)
        {
            string imgType = context.Request.QueryString["img"];
            string UniId = context.Request.QueryString["UniID"];
            string StudentId = context.Request.QueryString["StudentID"];
            string Year = context.Request.QueryString["YearID"];

            oclsElgDBAccess = new clsEligibilityDBAccess();
            DataTable odt = new DataTable();
            odt = oclsElgDBAccess.ShowPhotoSign(UniId, Year, StudentId);

            context.Response.ContentType = "image/jpeg";
            System.Drawing.Image img;

            if (odt.Rows.Count > 0)
            {
                if (imgType == "Photo")
                {
                    byte[] Bytes = (byte[])odt.Rows[0]["Photograph"];
                    System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                    img = System.Drawing.Image.FromStream(s);

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img = clsResizeImage.ResizeImage(ms, 55, 80);

                    // Save the image to the OutputStream.
                    if (img != null)
                    {
                        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                else if (imgType == "Sign")
                {
                    byte[] Bytes = (byte[])odt.Rows[0]["Signature"];
                    System.IO.Stream s = new System.IO.MemoryStream(Bytes);
                    img = System.Drawing.Image.FromStream(s);

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img = clsResizeImage.ResizeImage(ms, 80, 55);

                    // Save the image to the OutputStream.
                    if (img != null)
                    {
                        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
