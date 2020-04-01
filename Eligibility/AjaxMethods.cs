using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using Classes;
using Ajax;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using StudentRegistration.Eligibility.ElgClasses;

namespace StudentRegistration.Eligibility
{
    /// <summary>
    /// Summary description for AjaxMethods.
    /// </summary>

    public class AjaxMethods
    {
        public AjaxMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        clsCommon objCommon = new clsCommon();
        clsUniversity clsUniversity = new clsUniversity();
        clsGeneral clsBoard = new clsGeneral();

        #region Following Functions can be added in the Institute repository just by changing the Procedure names as these Proc are created on similar lines as IDV2 Porcedures for Eligibility module

        # region for Regular Students

        // The following functions can be added in the InstituteRepository (By Shivani)

        #region Select  Institute Wise - Faculty

        [Ajax.AjaxMethod]

        public ArrayList selInstituteWiseFaculty(int UniID, int InstID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedFaculties", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }

        #endregion

        #region Select Institute Wise - Courses

        [Ajax.AjaxMethod]

        public ArrayList selInstituteWiseCourses(int UniID, int InstID, int FacID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ht.Add("Fac_ID", FacID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedCourses", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                // Exception e = new Exception(Ex.Message, Ex);
                throw Ex;
            }
            finally
            {

                Pool.ReleaseDBObject(oDB);

            }
        }

        #endregion

        #region Select Mode of Learning
        [Ajax.AjaxMethod]
        public ArrayList selModeofLearning(int UniID, int InstID, int FacID, int CrID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ht.Add("Fac_ID", FacID);
                ht.Add("Cr_ID", CrID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedModeOfLearning", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                //Exception e = new Exception(Ex.Message, Ex);
                throw (Ex);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Select Course Pattern
        [Ajax.AjaxMethod]
        public ArrayList selCoursePattern(int UniID, int InstID, int FacID, int CrID, int MoLrnID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("pk_Uni_ID", UniID);
                ht.Add("pk_Inst_ID", InstID);
                ht.Add("pk_Fac_ID", FacID);
                ht.Add("pk_Cr_ID", CrID);
                ht.Add("pk_MoLrn_ID", MoLrnID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedCoursePatterns", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Select Branch
        [Ajax.AjaxMethod]
        //public HtmlSelect selBranch(int UniID, int InstID, int FacID, int CrID, int MoLrnID, int PtrnID, string HtmlSelCrBrnID)
        public ArrayList selBranch(int UniID, int InstID, int FacID, int CrID, int MoLrnID, int PtrnID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            HtmlSelect htmlSel = new HtmlSelect();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ht.Add("Fac_ID", FacID);
                ht.Add("Cr_ID", CrID);
                ht.Add("MoLrn_ID", MoLrnID);
                ht.Add("Ptrn_ID", PtrnID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedBranches", ht);

                /*
                 htmlSel.ID = HtmlSelCrBrnID;
                 htmlSel.Attributes.Add("class", "selectbox");

                 htmlSel.Attributes.Add("onchange", "setValue('hid_Brn_id',this.value);FillCoursePart(this.value);");

                 htmlSel.DataSource = dt;
                 htmlSel.DataTextField = "Text";
                 htmlSel.DataValueField = "Value";
                 htmlSel.DataBind();
                 if (dt.Rows.Count > 0)
                 {
                     ListItem li = new ListItem("--- Select ---", "-1");
                     htmlSel.Items.Insert(0, li);
                 }
                 else
                 {
                     ListItem li = new ListItem(" No Branch ", "0");
                     htmlSel.Items.Insert(0, li);

                 }
                 */
                /*
               if (dt.Rows.Count > 0)
              {
                  ListItem li = new ListItem("--- Select ---", "-1");
                  htmlSel.Items.Insert(0, li);
              }
              else
              {
                  ListItem li = new ListItem(" No Branch ", "0");
                  htmlSel.Items.Insert(0, li);

              }*/

                Arrds.Add(ds);
                return Arrds;
                //return htmlSel;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }
        #endregion

        #region Select  CoursePart
        [Ajax.AjaxMethod]
        public ArrayList selCoursePart(int UniID, int InstID, int FacID, int CrID, int MoLrnID, int PtrnID, int BrnID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ht.Add("Fac_ID", FacID);
                ht.Add("Cr_ID", CrID);
                ht.Add("MoLrn_ID", MoLrnID);
                ht.Add("Ptrn_ID", PtrnID);
                ht.Add("Brn_ID", BrnID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedCourseParts", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }
        #endregion


        #region Select  CoursePartChild
        [Ajax.AjaxMethod]
        public ArrayList selCoursePartChild(int UniID, int InstID, int FacID, int CrID, int MoLrnID, int PtrnID, int BrnID, int CrPrDetailsID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ht.Add("Fac_ID", FacID);
                ht.Add("Cr_ID", CrID);
                ht.Add("MoLrn_ID", MoLrnID);
                ht.Add("Ptrn_ID", PtrnID);
                ht.Add("Brn_ID", BrnID);
                ht.Add("CrPr_Details_ID", CrPrDetailsID);
                ds = oDB.getparamdataset("ELGV2_AssignedConfirmedCoursePartTerm", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }
        #endregion
        //End of Functions that can be added in the InstituteRepository (By Shivani)

        #endregion

        //#region Select  ALL Courses
        //[Ajax.AjaxMethod]
        //public ArrayList selFacultyWiseAllCourses(int UniID, int FacID)
        //{
        //    DataSet ds;
        //    ArrayList Arrds = new ArrayList(1);
        //    try
        //    {

        //        SqlParameter[] pr = new SqlParameter[2];
        //        pr[0] = new SqlParameter("@UniID", UniID);
        //        pr[1] = new SqlParameter("@FacID", FacID);
        //        ds = SqlHelper.ExecuteDataset(Classes.clsGetSettings.ConnectionString, CommandType.StoredProcedure, "IDV2_AssignedConfirmedCourses", pr);
        //        Arrds.Add(ds);
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception e = new Exception(Ex.Message, Ex);
        //        throw (e);

        //    }
        //    return Arrds;
        //}
        //#endregion

        //#region Select  ALL CoursesPart
        //[Ajax.AjaxMethod]
        //public ArrayList selAllCoursePart(int UniID, int FacID, int CrID)
        //{
        //    DataSet ds;
        //    ArrayList Arrds = new ArrayList(1);
        //    try
        //    {
        //        SqlParameter[] pr = new SqlParameter[3];
        //        pr[0] = new SqlParameter("@UniID", UniID);
        //        pr[1] = new SqlParameter("@FacID", FacID);
        //        pr[2] = new SqlParameter("@CrID", CrID);
        //        ds = SqlHelper.ExecuteDataset(Classes.clsGetSettings.ConnectionString, CommandType.StoredProcedure, "ELG_RegularCoursePart", pr);
        //        Arrds.Add(ds);
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception e = new Exception(Ex.Message, Ex);
        //        throw (e);

        //    }
        //    return Arrds;
        //}
        //#endregion

        #region Fill State Wise Districts

        [Ajax.AjaxMethod()]

        public static DataSet FillStateWiseDistricts(int State_ID, string Lang_Flag)
        {
            DataSet ds;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("State_ID", State_ID);
                ht.Add("Lang_Flag", Lang_Flag);
                ds = oDB.getparamdataset("GEN_stateWiseDistricts", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #region Fill District Wise Tehsils

        [Ajax.AjaxMethod()]

        public static DataSet FillDistrictWiseTehsils(int District_ID, string Lang_Flag)
        {
            DataSet ds;
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("District_ID", District_ID);
                ht.Add("Lang_Flag", Lang_Flag);
                ds = oDB.getparamdataset("GEN_districtWiseTaluka", ht);
                return ds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion

        #endregion

        [Ajax.AjaxMethod()]

        public int FetchMatchingProfile(int rowID)
        {

            int id;
            id = rowID;
            return id;

        }

        #region for External Students

        #region Select  ALL CoursesPart

        //		[Ajax.AjaxMethod]
        //		public ArrayList selExtAllCoursePart(int UniID,int FacID,int CrID)
        //		{
        //			DataSet ds;
        //			ArrayList Arrds=new ArrayList(1);
        //			try
        //			{
        //				SqlParameter[] pr = new SqlParameter[3];
        //				pr[0] = new SqlParameter("@UniID",UniID);
        //				pr[1] = new SqlParameter("@FacID",FacID);
        //				pr[2] = new SqlParameter("@CrID",CrID);
        //				ds = SqlHelper.ExecuteDataset(Classes.clsGetSettings.ConnectionString,CommandType.StoredProcedure,"ELG_ExternalCoursePart",pr);
        //				Arrds.Add(ds);
        //			}
        //			catch(Exception Ex)
        //			{
        //				Exception e = new Exception(Ex.Message,Ex);
        //				throw(e);
        //			  			
        //			}
        //			return Arrds;
        //		}

        #endregion

        #endregion



        #region fillStateBoard

        [Ajax.AjaxMethod]
        public HtmlSelect fillStateBoard(string State_ID, string selectedValue)
        {

            DataTable tempDT = new DataTable();
            if (State_ID != "0")
            {
                tempDT = clsBoard.ListStateWiseBoard(State_ID);

            }
            HtmlSelect hStateID = new HtmlSelect();
            hStateID.ID = "Body_ID";
            hStateID.Attributes.Add("class", "selectbox");
            hStateID.Attributes.Add("onblur", "setValue('hid_BodyID',this.value)");
            try
            {
                objCommon.fillDropDown(hStateID, tempDT, selectedValue, "StateBoard_Description", "pk_BoardID", "--- Select ---");
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            return hStateID;
        }

        #endregion

        #region fillStateUniversity

        [Ajax.AjaxMethod]
        public HtmlSelect fillStateUniversity(string State_ID, string selValue)
        {
            DataTable tempDT = new DataTable();
            if (State_ID != "0")
            {
                tempDT = clsUniversity.ListStateWiseUniversities(State_ID);
            }
            HtmlSelect hUniversityID = new HtmlSelect();
            hUniversityID.ID = "Body_ID";
            hUniversityID.Attributes.Add("class", "selectbox");
            hUniversityID.Attributes.Add("onblur", "setValue('hid_BodyID',this.value)");
            try
            {
                objCommon.fillDropDown(hUniversityID, tempDT, selValue, "Uni_Name", "pk_Uni_ID", "--- Select ---");
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            return hUniversityID;
        }


        #region Select fillStateBoard for Bulk Process New Logic
        [Ajax.AjaxMethod]
        //public ArrayList fillStateBoard1(int universityID, int instituteID, int State_ID, int facID, int crID, int moLrnID, int ptrnID, int brnID, int DOB, int LastName, int FirstName, int Gender, int ElgStatusColl)
        public ArrayList fillStateBoard_BulkProcess(int State_ID, int universityID, int instituteID, int facID, int crID, int moLrnID, int ptrnID, int brnID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("fk_StateID", State_ID);
                ht.Add("pk_Uni_ID", universityID);
                ht.Add("pk_Inst_ID", instituteID);
                ht.Add("FacID", facID);
                ht.Add("CrID", crID);
                ht.Add("MoLrnID", moLrnID);
                ht.Add("PtrnID", ptrnID);
                ht.Add("BrnID", brnID);

                ds = oDB.getparamdataset("ELGV2_List_StateWiseBoard_BulkProcess", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion


        #region Select fillStateBoard New Logic
        [Ajax.AjaxMethod]
        //public ArrayList fillStateBoard1(int universityID, int instituteID, int State_ID, int facID, int crID, int moLrnID, int ptrnID, int brnID, int DOB, int LastName, int FirstName, int Gender, int ElgStatusColl)
        public ArrayList fillStateBoard1(string universityID, string instituteID, string State_ID, string facID, string crID, string moLrnID, string ptrnID, string brnID, string DOB, string LastName, string FirstName, string Gender, string ElgStatusColl)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("pk_Uni_ID", universityID);
                ht.Add("pk_Inst_ID", instituteID);
                ht.Add("fk_StateID", State_ID);
                ht.Add("Fac_ID", facID);
                ht.Add("Cr_ID", crID);
                ht.Add("MoLrn_ID", moLrnID);
                ht.Add("Ptrn_ID", ptrnID);
                ht.Add("Brn_ID", brnID);
                ht.Add("DOB_Stu", DOB);
                ht.Add("Last_Name", LastName);
                ht.Add("First_Name", FirstName);
                ht.Add("Gender_Stu", Gender);
                ht.Add("Elg_StatusColl", ElgStatusColl);
                ds = oDB.getparamdataset("ELGV2_List_StateWiseBoard", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region Select fillStateUniversity New Logic
        [Ajax.AjaxMethod]
        public ArrayList fillStateUniversity1(int State_ID, int universityID, int instituteID, int facID, int crID, int moLrnID, int ptrnID, int brnID, string selectedValue)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;

            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();
                ht.Add("State_ID", State_ID);

                ht.Add("pk_Uni_ID", universityID);
                ht.Add("pk_Inst_ID", instituteID);
                ht.Add("FacID", facID);
                ht.Add("CrID", crID);
                ht.Add("MoLrnID", moLrnID);
                ht.Add("PtrnID", ptrnID);
                ht.Add("BrnID", brnID);
                //ht.Add("CrPrDetailsID", CrPrDetailsID);
                ds = oDB.getparamdataset("ELGV2_ListStateWiseUniversities", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }
        }
        #endregion

        #region New Methods for Paper Exemption

        #region Select Institute Wise - Courses - COMBINED

        [Ajax.AjaxMethod]

        public ArrayList selInstituteWiseCoursesCombined(string UniID, string InstID, string FacID)
        {
            InstituteRepository oInstituteRepository = new InstituteRepository();
            DataTable oDT = oInstituteRepository.ListFacultyWiseConfirmedCourseMoLrnPattern(UniID, InstID, FacID);
            ArrayList ad = new ArrayList();
            ad.Add(oDT);
            return ad;
        }

        #endregion

        #region Fill College Wise CoursePartChild
        [Ajax.AjaxMethod]
        public ArrayList selCollWiseCoursePartChild(int UniID, int InstID, int FacID, int CrID, int MoLrnID, int PtrnID, int BrnID, int CrPrDetailsID)
        {
            DataSet ds;
            ArrayList Arrds = new ArrayList(1);
            Hashtable ht = new Hashtable();
            DBObjectPool Pool = null;
            DBObject oDB = null;
            try
            {
                Pool = DBObjectPool.Instance;
                oDB = Pool.AcquireDBObject();

                ht.Add("Uni_ID", UniID);
                ht.Add("Inst_ID", InstID);
                ht.Add("Fac_ID", FacID);
                ht.Add("Cr_ID", CrID);
                ht.Add("MoLrn_ID", MoLrnID);
                ht.Add("Ptrn_ID", PtrnID);
                ht.Add("Brn_ID", BrnID);
                ht.Add("CrPr_Details_ID", CrPrDetailsID);
                ds = oDB.getparamdataset("IDV2_InstWiseAssignCoursePartTerm", ht);
                Arrds.Add(ds);
                return Arrds;
            }
            catch (Exception Ex)
            {
                Exception e = new Exception(Ex.Message, Ex);
                throw (e);

            }
            finally
            {
                Pool.ReleaseDBObject(oDB);
            }

        }

        #endregion
    }
        #endregion

        #endregion
}
