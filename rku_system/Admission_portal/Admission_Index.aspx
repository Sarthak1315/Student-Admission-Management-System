<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admission_Index.aspx.cs" Inherits="rku_system.Admission_portal.Admission_Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admission Form</title>

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
        .auto-style2 {
            width: 323px;
        }
        .auto-style3 {
            align-content: center !important;
            width: 323px;
        }
        .auto-style5 {
            align-content: center !important;
            width: 325px;
        }
        .auto-style6 {
            align-content: center !important;
            width: 327px;
        }
        .auto-style7 {
            align-content: center !important;
            width: 430px;
        }
        .auto-style8 {
            width: 363px;
        }
        .auto-style9 {
            width: 364px;
        }
        .auto-style10 {
            width: 366px;
        }
        .auto-style11 {
            width: 430px;
        }
        .auto-style12 {
            width: 346px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div id="div1" runat="server">
            <center>
            <table class="border-0 " runat="server">
                <tr>
                    <td colspan="2">
                        <h1 style="text-align: center">Registration</h1>
                    </td>
                </tr>

                <tr id="tv1" runat="server">
                    <td class="auto-style12" style="text-align: right">For</td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="ddl_for" runat="server">
                            <asp:ListItem>Admission 2024-25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12" style="text-align: right">
    <asp:Label ID="lb_eml" runat="server" Text="Email : "></asp:Label>&nbsp;&nbsp;
</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txt_eml" runat="server" TextMode="Email"></asp:TextBox> &nbsp;&nbsp;
                        <asp:Button  class="btn btn-info mx-4" Text="VERIFY" ID="btn_v" runat="server" OnClick="fn_verify" />
                    </td>
                    
                </tr>
                <!--<tr>
                    <td colspan="3">
                        <asp:Label ID="lbl_message" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>-->
                <tr>
                    <td class="auto-style12" style="text-align: right">
                        <asp:Label ID="lbl_otp" runat="server" Text="Enter Email OTP : "></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txt_otp" runat="server" TextMode="Number"></asp:TextBox> &nbsp;&nbsp;
                         <asp:Button class="btn btn-info mx-4" ID="btn_otp" runat="server" Text="Verify OTP" OnClick="btn_otp_Click" />
                    </td>
                   
                </tr>



            </table>
            </center>
        </div>
        <div id="div2" runat="server">
            <table class="centered-table" runat="server">

                <tr>
                    <td class="auto-style5" colspan="2">
                        <h1 style="text-align: center">Registration</h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Last Cetificate/Degree</td>
                    <td class="auto-style2">

                        <asp:DropDownList ID="ddl_stream" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_stream_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style6">Addmission Form</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddl_dept" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Last Qualifying S.S.C Exam Marks(%)</td>
                    <td>
                        <asp:TextBox ID="txt_ssc" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Last Qualifying H.S.C Exam Marks(%)</td>
                    <td>
                        <asp:TextBox ID="txt_hsc" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Surname</td>
                    <td>
                        <asp:TextBox ID="txt_fname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Name</td>
                    <td>
                        <asp:TextBox ID="txt_mname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Father/Husband/Mother<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name</td>
                    <td>
                        <asp:TextBox ID="txt_lname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Birth Date</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_birth" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Address</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_add" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Mobile No</td>
                    <td>
                        <asp:TextBox ID="txt_mobile" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>



                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="lbl_category" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddl_category" runat="server">
                            <asp:ListItem>--Please Select--</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>ST</asp:ListItem>
                            <asp:ListItem>SEBC</asp:ListItem>
                            <asp:ListItem>General</asp:ListItem>
                            <asp:ListItem Value="EWS">EWS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lbl_gender" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdl_gender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>male</asp:ListItem>
                            <asp:ListItem>female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Ssc_f_l" runat="server" Text="SSC Result File :"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="ssc_file" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Hsc_f_l" runat="server" Text="HSC Result File :"></asp:Label>

                    </td>
                    <td>
                        <asp:FileUpload ID="hsc_file" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="profile_f_l" runat="server" Text="Profile Image :"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="profile_file" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Sign_f_l" runat="server" Text="Sign Image :"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="sign_file" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style9" colspan="2">
                        <asp:Button class="btn btn-info mx-4" ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
