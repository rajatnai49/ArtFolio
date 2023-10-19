<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserData.aspx.cs" Inherits="artfolio.AddUserData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add User Data</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
        }

        form {
            max-width: 900px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #333;
            border-bottom: 2px solid #ccc;
            padding-bottom: 5px;
            margin-bottom: 15px;
        }

        label {
            display: block;
            margin-bottom: 8px;
            color: #555;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        .form-control:focus {
            outline: none;
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        .btnSubmit {
            background-color: black;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
        }

        .btnSubmit:hover {
            background-color: #333;
        }

          .file-upload-wrapper {
            position: relative;
            overflow: hidden;
            display: inline-block;
        }

        .file-upload-wrapper input[type=file] {
            font-size: 100px;
            position: absolute;
            left: 0;
            top: 0;
            opacity: 0;
        }

        .file-upload-wrapper .btnUpload {
            background-color: #2ecc71;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        .file-upload-wrapper .btnUpload:hover {
            background-color: #27ae60;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ArtFolio</h1>
        </div>
        <div>
            <h1>Super Awesome Personal Website Creator</h1>
            <h3>"Express yourself with style!"</h3>

            <h2>User Information</h2>
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" /><br />

            <label for="txtDesc">Description:</label>
            <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine" /><br />

            <label for="fileDp">Display Picture:</label>
            <asp:FileUpload ID="fileDp" runat="server" CssClass="form-control"/><br />

            <label for="txtWorkDesp">Work Description:</label>
            <asp:TextBox ID="txtWorkDesp" runat="server" CssClass="form-control" TextMode="MultiLine" /><br />

            <label for="fileWorkImage">Work Image:</label>
            <asp:FileUpload ID="fileWorkImage" runat="server" CssClass="form-control"/><br />

            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" /><br />

            <h2>Contact Information</h2>
            <label for="txtMobile">Mobile:</label>
            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" /><br />

            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" /><br />

            <label for="txtTwitter">Twitter:</label>
            <asp:TextBox ID="txtTwitter" runat="server" CssClass="form-control" /><br />

            <label for="txtInstagram">Instagram:</label>
            <asp:TextBox ID="txtInstagram" runat="server" CssClass="form-control" /><br />

            <label for="txtFacebook">Facebook:</label>
            <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control" /><br />

            <label for="txtLinkedIn">LinkedIn:</label>
            <asp:TextBox ID="txtLinkedIn" runat="server" CssClass="form-control" /><br />

            <h2>Customization Options</h2>
            <label for="ddlPrimaryColor">Primary Color:</label>
            <asp:DropDownList ID="ddlPrimaryColor" runat="server" CssClass="form-control">
                <asp:ListItem Text="Red" Value="red" />
                <asp:ListItem Text="Blue" Value="blue" />
                <asp:ListItem Text="Green" Value="green" />
            </asp:DropDownList><br />

            <label for="ddlSecondaryColor">Secondary Color:</label>
            <asp:DropDownList ID="ddlSecondaryColor" runat="server" CssClass="form-control">
                <asp:ListItem Text="Yellow" Value="yellow" />
                <asp:ListItem Text="Purple" Value="purple" />
                <asp:ListItem Text="Orange" Value="orange" />
            </asp:DropDownList><br />

            <label for="ddlFont">Font:</label>
            <asp:DropDownList ID="ddlFont" runat="server" CssClass="form-control">
                <asp:ListItem Text="Arial" Value="Arial" />
                <asp:ListItem Text="Times New Roman" Value="Times New Roman" />
                <asp:ListItem Text="Verdana" Value="Verdana" />
            </asp:DropDownList><br />


            <h2>Photo Information</h2>
            <label for="filePhoto">Upload Photo:</label>
            <asp:FileUpload ID="filePhoto" runat="server" AllowMultiple="true" CssClass="form-control"/><br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnSubmit" />

        </div>
    </form>
</body>
</html>
