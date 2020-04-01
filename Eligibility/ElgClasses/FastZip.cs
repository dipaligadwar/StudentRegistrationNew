using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;


namespace Classes
{

    public class clsXmlFileInfo
    {
        string xmlData = string.Empty;
        string xmlFileName = string.Empty;

        public string XmlFileName
        {
            get
            {
                return xmlFileName;
            }
            set
            {
                xmlFileName = value;
            }
        }

        public string XmlData
        {
            get
            {
                return xmlData;
            }
            set
            {
                try
                {
                    xmlData = value;
                    System.Xml.XmlDocument oDoc = new System.Xml.XmlDocument();
                    oDoc.LoadXml(xmlData);
                }
                catch (Exception Ex)
                {
                    xmlData = null;
                    throw new Exception("Invalid xml data." + Ex.Message.ToString(), Ex);
                }
            }
        }

        public clsXmlFileInfo()
        {

        }
    }

    /// <summary>
    /// FastZipEvents supports all events applicable to <see cref="FastZip">FastZip</see> operations.
    /// </summary>
    public class FastZipEvents
    {
        #region Delegates

        /// <summary>
        /// Delegate to invoke when processing files.
        /// </summary>
        public ProcessFileDelegate ProcessFile;

        #endregion

        #region Events
        /// <summary>
        /// Raises the ProcessFileEvent.
        /// </summary>
        /// <param name="file">The file for this event.</param>
        public void OnProcessFile(string file)
        {
            if (ProcessFile != null)
            {
                ScanEventArgs args = new ScanEventArgs(file);
                ProcessFile(this, args);
            }
        }

        #endregion
    }

    /// <summary>
    /// FastZip provides facilities for creating and extracting zip files.
    /// Only relative paths are supported.
    /// </summary>
    /// 
    public class FastZip
    {
        #region Contructor(s)
        /// <summary>
        /// Initialize a default instance of FastZip.
        /// </summary>
        public FastZip()
        {
            this.events = null;
        }

        /// <summary>
        /// Initialise a new instance of <see cref="FastZip"/>
        /// </summary>
        /// <param name="events"></param>
        public FastZip(FastZipEvents events)
        {
            this.events = events;
        }

        #endregion

        #region ENUM Overwrite
        /// <summary>
        /// Defines the desired handling when overwriting files.
        /// </summary>
        public enum Overwrite
        {
            /// <summary>
            /// Prompt the user to confirm overwriting
            /// </summary>
            Prompt,
            /// <summary>
            /// Never overwrite files.
            /// </summary>
            Never,
            /// <summary>
            /// Always overwrite files.
            /// </summary>
            Always
        }

        #endregion

        #region Property(s)
        /// <summary>
        /// Get/set a value indicating wether empty directories should be created.
        /// </summary>
        public bool CreateEmptyDirectories
        {
            get { return createEmptyDirectories; }
            set { createEmptyDirectories = value; }
        }

        #endregion

        #region Class Method(s)
        /// <summary>
        /// Delegate called when confirming overwriting of files.
        /// </summary>
        public delegate bool ConfirmOverwriteDelegate(string fileName);

        /// <summary>
        /// Exatract the contents of a zip file.
        /// </summary>
        /// <param name="zipFileName">The zip file to extract from.</param>
        /// <param name="targetDirectory">The directory to save extracted information in.</param>
        /// <param name="overwrite">The style of <see cref="Overwrite">overwriting</see> to apply.</param>
        /// <param name="confirmDelegate">A delegate to invoke when confirming overwriting.</param>
        /// <param name="fileFilter">A filter to apply to files.</param>
        /// <param name="directoryFilter">A filter to apply to directories.</param>
        public void ExtractZip(string sSourceDir, string sDestinationDir,
                               Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate,
                               string fileFilter, string directoryFilter)
        {

            string zipFileName = sSourceDir.Substring(sSourceDir.LastIndexOf("\\") + 1, sSourceDir.Length - sSourceDir.LastIndexOf("\\") - 1);

            //For Password
            string[] Val = zipFileName.Split('_');
            string UniID = Val[0];
            string InstID = Val[1];

            string sPassword = UniID + "" + InstID;

            if ((overwrite == Overwrite.Prompt) && (confirmDelegate == null))
            {
                throw new ArgumentNullException("confirmDelegate");
            }
            this.overwrite = overwrite;
            this.confirmDelegate = confirmDelegate;
            this.targetDirectory = sDestinationDir;
            this.fileFilter = new NameFilter(fileFilter);
            this.directoryFilter = new NameFilter(directoryFilter);

            inputStream = new ZipInputStream(File.OpenRead(sSourceDir));
            //Password for Zip File
            inputStream.Password = sPassword;
            try
            {

                if (password != null)
                {
                    inputStream.Password = password;
                }

                ZipEntry entry;
                while ((entry = inputStream.GetNextEntry()) != null)
                {
                    if (this.directoryFilter.IsMatch(Path.GetDirectoryName(entry.Name)) && this.fileFilter.IsMatch(entry.Name))
                    {
                        ExtractEntry(entry);
                    }
                }
            }
            finally
            {
                inputStream.Close();
            }
        }

        public List<clsXmlFileInfo> ExtractZip(System.Web.UI.HtmlControls.HtmlInputFile oHtmlInputFile)
        {

            string zipFileName = Path.GetFileName(oHtmlInputFile.PostedFile.FileName);

            zipFileName = zipFileName.Replace(Path.GetExtension(oHtmlInputFile.PostedFile.FileName), "");

            string[] Val = zipFileName.Split('_');

            string sPassword = Val[0] + "" + Val[1];

            inputStream = new ZipInputStream(oHtmlInputFile.PostedFile.InputStream);

            inputStream.Password = sPassword;
            List<clsXmlFileInfo> oListXmlFileInfo = new List<clsXmlFileInfo>();
            try
            {
                int size = 2048;
                byte[] data = new byte[2048];
                clsXmlFileInfo oXmlFileInfo = null;
                StringBuilder oS = new StringBuilder();
                ZipEntry entry;
                while ((entry = inputStream.GetNextEntry()) != null)
                {
                    oXmlFileInfo = new clsXmlFileInfo();
                    oXmlFileInfo.XmlFileName = entry.Name;
                    while (true)
                    {
                        size = inputStream.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            oS.Append(new ASCIIEncoding().GetString(data, 0, size));
                        }
                        else
                        {
                            break;
                        }
                    }

                    oXmlFileInfo.XmlData = oS.ToString();
                    oListXmlFileInfo.Add(oXmlFileInfo);
                    oS.Remove(0, oS.ToString().Length);
                }
            }
            finally
            {
                inputStream.Close();
            }
            return oListXmlFileInfo;
        }

        void ExtractFileEntry(ZipEntry entry, string targetName)
        {
            bool proceed = true;
            if ((overwrite == Overwrite.Prompt) && (confirmDelegate != null))
            {
                if (File.Exists(targetName) == true)
                {
                    proceed = confirmDelegate(targetName);
                }
            }

            if (proceed)
            {

                if (events != null)
                {
                    events.OnProcessFile(entry.Name);
                }

                FileStream streamWriter = File.Create(targetName);

                try
                {
                    if (buffer == null)
                    {
                        buffer = new byte[4096];
                    }

                    int size;

                    do
                    {
                        size = inputStream.Read(buffer, 0, buffer.Length);
                        streamWriter.Write(buffer, 0, size);
                    } while (size > 0);
                }
                finally
                {
                    streamWriter.Close();
                }

                if (restoreDateTime)
                {
                    File.SetLastWriteTime(targetName, entry.DateTime);
                }
            }
        }

        bool NameIsValid(string name)
        {
            return name != null && name.Length > 0 && name.IndexOfAny(Path.InvalidPathChars) < 0;

        }

        void ExtractEntry(ZipEntry entry)
        {
            bool doExtraction = NameIsValid(entry.Name);

            string dirName = null;
            string targetName = null;

            if (doExtraction)
            {
                string entryFileName;
                if (Path.IsPathRooted(entry.Name))
                {
                    string workName = Path.GetPathRoot(entry.Name);
                    workName = entry.Name.Substring(workName.Length);
                    entryFileName = Path.Combine(Path.GetDirectoryName(workName), Path.GetFileName(entry.Name));
                }
                else
                {
                    entryFileName = entry.Name;
                }

                targetName = Path.Combine(targetDirectory, entryFileName);
                dirName = Path.GetDirectoryName(Path.GetFullPath(targetName));

                doExtraction = doExtraction && (entryFileName.Length > 0);
            }

            if (doExtraction && !Directory.Exists(dirName))
            {
                if (!entry.IsDirectory || this.CreateEmptyDirectories)
                {
                    try
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    catch
                    {
                        doExtraction = false;
                    }
                }
            }

            if (doExtraction && entry.IsFile)
            {
                ExtractFileEntry(entry, targetName);
            }
        }

        public void CreateZip(string[] arrFilesToZip, string sDestination, string sPassword)
        {
            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(sDestination));
            s.Password = sPassword;
            s.SetLevel(9);
            foreach (string file in arrFilesToZip)
            {
                FileStream fs = File.OpenRead(file);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                string[] arrFileNames = null;
                arrFileNames = file.Split("\\".ToCharArray());

                ZipEntry entry = new ZipEntry(arrFileNames[arrFileNames.Length - 1].ToString().Trim());
                entry.DateTime = DateTime.Now;
                entry.Size = fs.Length;
                fs.Close();
                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                s.PutNextEntry(entry);
                s.Write(buffer, 0, buffer.Length);
                s.CloseEntry();
            }
            s.Flush();
            s.Close();
        }

        public void CreateZip(string[] arrFilesToZip, string sPassword)
        {
            Crc32 crc = new Crc32();
            MemoryStream memoryStream = new MemoryStream();
            ZipOutputStream zipOutputStream = new ZipOutputStream(memoryStream);
            zipOutputStream.Password = sPassword;
            zipOutputStream.SetLevel(9);
            foreach (string file in arrFilesToZip)
            {
                FileStream fileStream = File.OpenRead(file);
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                string[] arrFileNames = null;
                arrFileNames = file.Split("\\".ToCharArray());

                ZipEntry zipEntry = new ZipEntry(arrFileNames[arrFileNames.Length - 1].ToString().Trim());
                zipEntry.DateTime = DateTime.Now;
                zipEntry.Size = fileStream.Length;

                fileStream.Close();
                crc.Reset();
                crc.Update(buffer);
                zipEntry.Crc = crc.Value;

                zipOutputStream.PutNextEntry(zipEntry);
                zipOutputStream.Write(buffer, 0, buffer.Length);
                zipOutputStream.CloseEntry();
            }

            zipOutputStream.Finish();
            zipOutputStream.Flush();
            zipOutputStream.Close();

            System.Web.HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
            System.Web.HttpContext.Current.Response.AddHeader("Content-Length", memoryStream.GetBuffer().Length.ToString());
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Download.zip");
            Stream ResponseOutputStream = System.Web.HttpContext.Current.Response.OutputStream;
            ResponseOutputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.GetBuffer().Length);
            ResponseOutputStream.Flush();
            ResponseOutputStream.Close();
        }

        /// <summary>
        /// Compresses single file to ZipFile with password 
        /// protection
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFile"></param>
        /// <param name="sPassword"></param>
        public void CreateZip(string srcFile, string destFile, string sPassword)
        {
            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(destFile));
            s.Password = sPassword;
            s.SetLevel(9);

            FileStream fs = File.OpenRead(srcFile);
            if (fs.Length == 0)
            {
                fs.Close();
                File.Delete(srcFile);
            }
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);

            FileInfo oFileInfo = new FileInfo(srcFile);
            ZipEntry entry = new ZipEntry(oFileInfo.Name);
            entry.DateTime = DateTime.Now;
            entry.Size = fs.Length;

            fs.Close();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;

            s.PutNextEntry(entry);
            s.Write(buffer, 0, buffer.Length);
            s.CloseEntry();
            s.Flush();
            s.Close();

            File.Delete(srcFile);

            System.Web.HttpContext.Current.Response.AddHeader("Content-Type", "application/octet-stream");
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + new FileInfo(destFile).Name);
            System.Web.HttpContext.Current.Response.TransmitFile(destFile);
            System.Web.HttpContext.Current.Response.End();

        }



        public void CreateZip(string sZipFileName, string sPassword, List<clsXmlFileInfo> ListXmlFileInfo)
        {
            Crc32 crc = new Crc32();
            MemoryStream memoryStream = new MemoryStream();
            ZipOutputStream zipOutputStream = new ZipOutputStream(memoryStream);
            zipOutputStream.Password = sPassword;
            zipOutputStream.SetLevel(9);

            MemoryStream xmlMemoryStream = null;

            foreach (clsXmlFileInfo oXmlFileInfo in ListXmlFileInfo)
            {
                xmlMemoryStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(oXmlFileInfo.XmlData));
                byte[] bytes = xmlMemoryStream.ToArray();

                ZipEntry zipEntry = new ZipEntry(oXmlFileInfo.XmlFileName);
                zipEntry.DateTime = DateTime.Now;
                zipEntry.Size = bytes.Length;

                xmlMemoryStream.Flush();
                xmlMemoryStream.Close();

                crc.Reset();
                crc.Update(bytes);
                zipEntry.Crc = crc.Value;

                zipOutputStream.PutNextEntry(zipEntry);
                zipOutputStream.Write(bytes, 0, bytes.Length);
                zipOutputStream.CloseEntry();
            }

            zipOutputStream.Finish();
            zipOutputStream.Flush();
            zipOutputStream.Close();

            System.Web.HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
            System.Web.HttpContext.Current.Response.AddHeader("Content-Length", memoryStream.GetBuffer().Length.ToString());
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + sZipFileName);
            Stream ResponseOutputStream = System.Web.HttpContext.Current.Response.OutputStream;
            ResponseOutputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.GetBuffer().Length);
            ResponseOutputStream.Flush();
            ResponseOutputStream.Close();
        }

        #endregion

        #region Instance Fields
        byte[] buffer;
        ZipInputStream inputStream;
        string password = null;
        string targetDirectory;
        string sourceDirectory = string.Empty;
        NameFilter fileFilter;
        NameFilter directoryFilter;
        Overwrite overwrite;
        ConfirmOverwriteDelegate confirmDelegate;
        bool restoreDateTime = false;
        bool createEmptyDirectories = false;
        FastZipEvents events;
        #endregion
    }
}
