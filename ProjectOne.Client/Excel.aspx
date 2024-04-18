<%@ Page Title="Upload Excel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excel.aspx.cs" Inherits="ProjectOne.Client.WebForm1" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label class="form-label">Upload File</label>
        <asp:FileUpload CssClass="form-control" ID="ExcelFile" runat="server" name="formFile" accept=".xlsx, .xls ,.csv" />
        <!--<asp:RequiredFieldValidator runat="server" ID="rfvFile" ControlToValidate="ExcelFile" ErrorMessage="Field is required" Display="Dynamic" />-->
    </div>
    <p>
        <asp:Button Text="UploadFile" runat="server" CssClass="btn btn-primary" OnClick="UploadBtn_Click" />
    </p>
    <asp:Table runat="server" ID="DataTableExcel" CssClass="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>#</asp:TableHeaderCell>
            <asp:TableHeaderCell>TicketCode</asp:TableHeaderCell>
            <asp:TableHeaderCell>Time generated</asp:TableHeaderCell>
            <asp:TableHeaderCell>Type</asp:TableHeaderCell>
            <asp:TableHeaderCell>Duplicate(In File)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Duplicate(In DB)</asp:TableHeaderCell>
            <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <asp:Button runat="server" Text="Submit Data" CssClass="btn btn-success" Enabled="false" ID="SubmitBtn" Type="button" />
    <asp:Literal ID="ltTxt" runat="server" />
    <script type="text/javascript">
        function removeARow(id) {
            id.parentElement.removeChild(id);
            //console.log(document.getElementById("MainContent_DataTableExcel"))
            let table = document.getElementById("MainContent_DataTableExcel")


            for (var i = 1, row; row = table.rows[i]; i++) {
                console.log(row.cells[4].innerText, row.cells[5].innerText)
                if (row.cells[4].innerText === "True" || row.cells[5].innerText === "True") {
                    document.getElementById("MainContent_SubmitBtn").disabled = true;
                    return;
                } else {
                    document.getElementById("MainContent_SubmitBtn").disabled = false;
                }

            }
        }

        async function sendData() {
            event.preventDefault();
            //console.log(document.getElementById("MainContent_DataTableExcel"));
            var table = document.getElementById("MainContent_DataTableExcel");
            var list = [];
            for (var i = 1, row; row = table.rows[i]; i++) {
                var data = {};

                data.ticketCode = row.cells[1].innerText;
                data.dateCreated = new Date(row.cells[2].innerText);
                data.ticketType = row.cells[3].innerText;
                data.duplicateFromExcelSheet = row.cells[4].innerText === "False" ? false : true;
                data.duplicateFromDb = row.cells[5].innerText === "False" ? false : true;

                list.push(data);

            }
            //JSON.parse(list)
            console.log(list)

            const myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            await fetch("https://localhost:7056/api/excelfile/uploaddata",
                {
                    method: "POST",
                    headers: myHeaders,
                    body: JSON.stringify(list),
                    redirect: "follow"
                })
                .then((response) => response.text())
                .then((result) => console.log(result))
                .catch((error) => console.error(error))

            //console.log(JSON.stringify(list));

        }
    </script>
</asp:Content>
