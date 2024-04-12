<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excel.aspx.cs" Inherits="ProjectOne.Client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="https://localhost:7056/api/excelfile/upload" enctype="multipart/form-data">
        <div>
            <asp:FileUpload ID="ExcelFile1" runat="server" accept=".xlsx, .xls ,.csv"  />
        </div>
        <p>
            <asp:Button Text="UploadFile" runat="server" Type="submit"  />
        </p>
    </form>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</body>
</html>
