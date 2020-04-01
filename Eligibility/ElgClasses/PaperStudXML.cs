using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace StudentRegistration.Eligibility.ElgClasses
{
    public class PaperStudXML
    {
        int studentID, tlm, am, at, year;
        int uniid, facID, crID, brnID, mOLID, ptrnID, crPrDetID, crPrChID;
        int pk_Pp_PpHead_CrPrCh_ID;

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public int TLM
        {
            get { return tlm; }
            set { tlm = value; }
        }
        public int AM
        {
            get { return am; }
            set { am = value; }
        }
        public int AT
        {
            get { return at; }
            set { at = value; }
        }
        public int FacID
        {
            get { return facID; }
            set { facID = value; }
        }
        public int CRID
        {
            get { return crID; }
            set { crID = value; }
        }
        public int BrnID
        {
            get { return brnID; }
            set { brnID = value; }
        }
        public int MOLID
        {
            get { return mOLID; }
            set { mOLID = value; }
        }
        public int PtrnID
        {
            get { return ptrnID; }
            set { ptrnID = value; }
        }
        public int CrPrDetID
        {
            get { return crPrDetID; }
            set { crPrDetID = value; }
        }
        public int CrPrChtID
        {
            get { return crPrChID; }
            set { crPrChID = value; }
        }
        public int Pk_Pp_PpHead_CrPrCh_ID
        {
            get { return pk_Pp_PpHead_CrPrCh_ID; }
            set { pk_Pp_PpHead_CrPrCh_ID = value; }
        }
        public int UniID
        {
            get { return uniid; }
            set { uniid = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        #region Function To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.

        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        #endregion

        #region Function To get XML string for selected Student-Paper TLM AM AT

        public static String SerializeObject(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "");

                String XmlizedString = null;

                XmlSerializer xs = new XmlSerializer(obj.GetType());

                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj, ns);

                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                string removeStr = "?<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                XmlizedString = XmlizedString.Remove(0, removeStr.Length);
                return XmlizedString;

            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
            }
        }

        #endregion

    }
    //==========================================================================================================================


    public class ExamFormModifyXML
    { 
      
        int uniID, studentID, year, acYrID, instID;
        int facID, crID, brnID, mOLID, ptrnID, crPrDetID, crPrChID;
        string createdBy; //, requestDetails;

        public int UniID
        { 
            get { return uniID; }
            set { uniID = value; }
        }
        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int AcYrID
        {
            get { return acYrID; }
            set { acYrID = value; }
        }
        public int InstID
        {
            get { return instID; }
            set { instID = value; }
        }
        public int FacID
        {
            get { return facID; }
            set { facID = value; }
        }
        public int CrID
        {
            get { return crID; }
            set { crID = value; }
        }
        public int BrnID
        {
            get { return brnID; }
            set { brnID = value; }
        }
        public int MoLrnID
        {
            get { return mOLID; }
            set { mOLID = value; }
        }
        public int PtrnID
        {
            get { return ptrnID; }
            set { ptrnID = value; }
        }
        public int CrPrDetailsID
        {
            get { return crPrDetID; }
            set { crPrDetID = value; }
        }
        public int CrPrChID
        {
            get { return crPrChID; }
            set { crPrChID = value; }
        }
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        //public string RequestDetails
        //{
        //    get { return requestDetails; }
        //    set { requestDetails = value; }
        //}
       

        #region Function To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.

        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        #endregion

        #region Function To get XML string for selected Student-Paper Exam Modify Request

        public static string SerializeObject(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "");

                String XmlizedString = null;

                XmlSerializer xs = new XmlSerializer(obj.GetType());

                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj, ns);

                
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                string removeStr = "?<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                XmlizedString = XmlizedString.Remove(0, removeStr.Length);
                XmlizedString = XmlizedString.Replace("&lt;", "<");
                XmlizedString = XmlizedString.Replace("&gt;", ">");
                return XmlizedString;

            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
            }
        }

        #endregion

    }
}
