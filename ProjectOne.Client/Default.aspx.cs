using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjectOne.Client
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void Submit_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
            string filePath = @"C:\CalBank\ProjectOne\TestData.xlsx";
            var form = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            form.Add(fileContent,"formFile",Path.GetFileName(filePath));

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync($"https://localhost:7056/api/ExcelFile/Upload",form);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}