<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration_form.aspx.cs" Inherits="rku_system.Admission_portal.registration_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Details</title>
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
<link rel="icon" type="image/png" href="../assets/img/favicon.png">
<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900|Roboto+Slab:400,700" />
<link href="../assets/css/nucleo-icons.css" rel="stylesheet" />
<link href="../assets/css/nucleo-svg.css" rel="stylesheet" />
<link href="https://fonts.googleapis.com/icon?family=Material+Icons+Round" rel="stylesheet">
<link id="pagestyle" href="../assets/css/material-dashboard.css?v=3.0.0" rel="stylesheet" />
<script src="../assets/js/alert.js"></script>
<script src="../assets/js/fn_msg.js"></script>
<script src="https://kit.fontawesome.com/48c360923b.js" crossorigin="anonymous"></script>

<!-- Add your CSS here -->
<style>
    .centered-table {
        margin-left: auto;
        margin-right: auto;
        width: 80%; /* Adjust as needed */
        border-collapse: collapse;
    }

        .centered-table th, .centered-table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .centered-table th {
            background-color: #f4f4f4;
        }
    .auto-style1 {
    width: 252px;
}

.auto-style2 {
    width: 300px;
}

.auto-style3 {
    width: 255px;
}

.auto-style4 {
    width: 299px;
}

.auto-style5 {
    margin-left: 23;
}
</style>
</head>
<body>
        <form id="form1" runat="server" enctype="multipart/form-data">
        <table class="centered-table" runat="server">
            <tr> 
                <td class="auto-style5" colspan="2">
                    <h1>Registration Details</h1>
                </td>
            </tr>
            <tr>
    <td class="auto-style7" style="text-align: right">Registration Date</td>
    <td class="auto-style4">&nbsp;&nbsp;
    <asp:TextBox ID="txt_adate" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style7" style="text-align: right">Email</td>
    <td class="auto-style4">&nbsp;&nbsp;
    <asp:TextBox ID="txt_email" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style7" style="text-align: right">First Name</td>
    <td class="auto-style4">&nbsp;&nbsp;
    <asp:TextBox ID="txt_fname" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style7" style="text-align: right">Middle Name</td>
        <td class="auto-style4">&nbsp;&nbsp;
    <asp:TextBox ID="txt_mname" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
</tr>
<tr>
    <td class="auto-style8" style="text-align: right">Last Name</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_lname" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style3" style="text-align: right">Birth Date</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_bdate" runat="server" Width="152px" TextMode="Email" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style3" style="text-align: right">Category</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_category" runat="server" Width="152px" TextMode="Email" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style8" style="text-align: right">Gender</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_gen" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style1" style="text-align: right">Mobile No</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_mobile" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style1" style="text-align: right">SSC percentage</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_sscper" runat="server" TextMode="Number" ReadOnly="True" CssClass="auto-style5"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style1" style="text-align: right">HSC percentage</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_hscper" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style1" style="text-align: right">Stream</td>
    <td class="auto-style4">&nbsp;&nbsp;
<asp:TextBox ID="txt_stream" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style8" style="text-align: right">Address</td>
    <td class="auto-style4">&nbsp;&nbsp;
     <asp:TextBox ID="txt_add" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
    <td class="auto-style3" style="text-align: right">Status</td>
    <td class="auto-style4">&nbsp;&nbsp;
        
    <asp:TextBox ID="txt_status" runat="server" Width="152px" TextMode="Email" ReadOnly="True"></asp:TextBox>
            
    </td>
</tr>
<tr>
    <td class="auto-style3" style="text-align: right">SSC File : </td>
    <td class="auto-style4">&nbsp;&nbsp;
        <asp:HyperLink ID="ssc_hl" runat="server" Target="_blank">
            <asp:Image ID="ssc_file" runat="server" Width="250px" Height="250px" />
        </asp:HyperLink>
    </td>
</tr>
<tr>
    <td class="auto-style3" style="text-align: right">HSC File : </td>
    <td class="auto-style4">&nbsp;&nbsp;
        <asp:HyperLink ID="hsc_hl" runat="server" Target="_blank">
       <asp:Image ID="hsc_file" runat="server" Width="250px" Height="250px" />
            </asp:HyperLink>
    </td>
</tr>
<tr>
    <td class="auto-style3" style="text-align: right">Profile Image : </td>
    <td class="auto-style4">&nbsp;&nbsp;
        <asp:HyperLink ID="pi_hl" runat="server" Target="_blank">
        <asp:Image ID="profile_file" runat="server" Width="250px" Height="250px" />
            </asp:HyperLink>
    </td>
</tr>
<tr>
    <td class="auto-style3" style="text-align: right">Sign Image : </td>
    <td class="auto-style4">&nbsp;&nbsp;
        <asp:HyperLink ID="sign_hl" runat="server" Target="_blank">
        <asp:Image ID="sign_file" runat="server" Width="250px" Height="250px" />
            </asp:HyperLink>
    </td>
</tr>
<tr>
    <td colspan="2">
        <asp:Button class="btn btn-info mx-4" ID="Back" runat="server" Text="Back To Student Detail" OnClick="Back_Click"></asp:Button>
    </td>
</tr>
        </table>
    </form>
</body>
</html>
