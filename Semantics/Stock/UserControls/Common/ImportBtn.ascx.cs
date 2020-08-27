using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace Stock.Ensure.UserControls.Common
{
    public partial class ImportBtn : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.UniqueID.ToString();
            if (FileUpload1.HasFile)
            {
            }
        }
        public void ImportClick(ref Repeater rpt)
        {
            FileUpload1.UniqueID.ToString();
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);

                string pathToCheck = FilePath;

                // Create a temporary file name to use for checking duplicates.
                string tempfileName = "";

                // Check to see if a file already exists with the
                // same name as the file to upload.        
                if (System.IO.File.Exists(pathToCheck))
                {
                    int counter = 2;
                    while (System.IO.File.Exists(pathToCheck))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = counter.ToString() + FileName;
                        pathToCheck = Server.MapPath(FolderPath + tempfileName);
                        counter++;
                    }
                    FileName = tempfileName;
                }

                FilePath = Server.MapPath(FolderPath + FileName);

                FileUpload1.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension, ref rpt, rbHDR.SelectedItem.Text);
            }
        }
        public void Import_To_Grid(string FilePath, string Extension, ref Repeater rpt, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0].ItemArray[2].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            //Bind Data to Repeater
            //rpt.Caption = Path.GetFileName(FilePath);
            rpt.DataSource = dt;
            rpt.DataBind();
        }
    }
}