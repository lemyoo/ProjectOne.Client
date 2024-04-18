using ProjectOne.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;
using System.Web.UI.HtmlControls;

namespace ProjectOne.Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static HttpClient projectOneClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7056")
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            SubmitBtn.Attributes.Add("onclick", "sendData()");
        }

        protected void ClickMe(object sender, EventArgs e)
        {
            ltTxt.Visible = true;
            ltTxt.Text = "Clicked By Button";

        }

        protected async void UploadBtn_Click(object sender, EventArgs e)
        {
            if (ExcelFile.HasFile)
            {
                try
                {
                    ExcelFile.SaveAs("C:\\TempUpLoads\\" + ExcelFile.FileName);
                    var fileName = Path.GetFileName("C:\\TempUpLoads\\" + ExcelFile.FileName);
                    var content = new MultipartFormDataContent();
                    var fileStream = File.OpenRead("C:\\TempUploads\\" + ExcelFile.FileName);
                    content.Add(new StreamContent(fileStream), "formFile", fileName);
                    var response = await projectOneClient.PostAsync("api/excelfile/uploadfile/", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();

                        List<DataToBeChecked> dataToBeCheckeds = new List<DataToBeChecked>();
                        dataToBeCheckeds = JsonSerializer.Deserialize<List<DataToBeChecked>>(data.Result);
                        int rowId = 1;
                        foreach (var dataToBeChecked in dataToBeCheckeds)
                        {
                            TableCell id = new TableCell();
                            id.Text = dataToBeChecked.id.ToString();

                            TableCell ticketCode = new TableCell();
                            ticketCode.Text = dataToBeChecked.ticketCode;

                            TableCell timeGenerated = new TableCell();
                            timeGenerated.Text = dataToBeChecked.dateCreated.ToString();

                            TableCell type = new TableCell();
                            type.Text = dataToBeChecked.ticketType;

                            TableCell duplicateFromDb = new TableCell();
                            duplicateFromDb.Text = dataToBeChecked.duplicateFromDb.ToString();

                            TableCell duplicateFromExcel = new TableCell();
                            duplicateFromExcel.Text = dataToBeChecked.duplicateFromExcelSheet.ToString();

                            var deleteButton = new HtmlButton();
                            deleteButton.Attributes.Add("type", "button");
                            deleteButton.Attributes.Add("class", "btn btn-danger");
                            deleteButton.InnerText = "Delete";
                            deleteButton.Disabled = dataToBeChecked.duplicateFromExcelSheet.ToString() == "True" || dataToBeChecked.duplicateFromDb.ToString() == "True" ? false : true;
                            deleteButton.Attributes.Add("onclick", "removeARow(MainContent_"+rowId+"tablerow)");
                            
                            TableCell deleteOrNot = new TableCell();
                            deleteOrNot.Controls.Add(deleteButton);

                            TableRow tableRow = new TableRow();
                            tableRow.ID = rowId+ "tablerow";
                            tableRow.Cells.Add(id);
                            tableRow.Cells.Add(ticketCode);
                            tableRow.Cells.Add(timeGenerated);
                            tableRow.Cells.Add(type);
                            tableRow.Cells.Add(duplicateFromExcel);
                            tableRow.Cells.Add(duplicateFromDb);
                            tableRow.Cells.Add(deleteOrNot);

                            DataTableExcel.Rows.Add(tableRow);
                            rowId++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltTxt.Visible = true;
                    ltTxt.Text = ex.Message;
                }
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(DataTableExcel.Rows.Count);
            //foreach(var row in DataTableExcel.Rows)
            //{
                /*foreach(var cell in row.)
                {*/
                    ltTxt.Text = "Count of table " + DataTableExcel.Rows.Count;
                /*}*/
            //}
            //var response = await projectOneClient.PostAsync("api/excelfile/uploadfile/",);
        }
    }
}