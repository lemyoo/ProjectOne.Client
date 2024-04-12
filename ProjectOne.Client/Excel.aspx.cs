using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectOne.Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if((ExcelFile1.PostedFile != null) && (ExcelFile1.PostedFile.ContentLength>0))
            {
                string fn = System.IO.Path.GetFileName(ExcelFile1.PostedFile.FileName);
                
            }
        }
    }
}