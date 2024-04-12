<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectOne.Client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">  
        function getDummyData() {
            $.ajax({
                type: "GET",
                url: "https://localhost:7056/api/ExcelFile/GetData",

                success: function (result) {
                    console.log(result);
                },
                error: function (req, status, error) {
                    console.log("meee" + status);
                }
            })
        }
        $(document).ready(getDummyData);
    </script>
    
        <asp:Button ID="upload" runat="server" Text="Upload" OnClick="Submit_Click"/>
    

</asp:Content>
