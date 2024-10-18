<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Desboard.Master" AutoEventWireup="true" CodeBehind="student_confirmation2.aspx.cs" Inherits="rku_system.Admin.student_confirmation2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mt-5 mx-4">
    <div class="card-body">
        <center>
            <table>
                <tr>
                    <td class="auto-style5" colspan="2" style="text-align: center">
                        <h1>Student Details</h1>
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
                    <td class="auto-style7" style="text-align: right">Middle Name<br />
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

                        <asp:Button class="btn btn-info mx-4" ID="btn_verify" runat="server" Text="Confirm" OnClick="btn_conform_Click"></asp:Button>

                        <asp:Button class="btn btn-info mx-4" ID="Back" runat="server" Text="Back To Student Detail" OnClick="Back_Click"></asp:Button>
                    </td>
                </tr>


            </table>
        </center>
    </div>
</div>
</asp:Content>
