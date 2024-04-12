<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelUpload.aspx.cs" Inherits="ProjectOne.Client.ExcelUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form name="excelform" method="post" enctype="multipart/form-data" action="https://localhost:7056/api/ExcelFile/Upload/">
    <div class="form-group">
        <label for="excelData">Excel File (Tickets)</label>
        <input type="file" class="form-control" id="excelData"/>
    </div>

    <button type="submit" class="btn btn-primary">Load</button>
</form>
</body>
</html>
