<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Desboard.Master" AutoEventWireup="true" CodeBehind="create_merit_list.aspx.cs" Inherits="rku_system.Admin_portal.create_merit_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <div class="card mt-5">
        <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
              <div class="bg-gradient-info shadow-info border-radius-lg pt-4 pb-3">
                <h5 class="text-white text-capitalize ps-3"><i class="fas fa-user-plus"></i> &nbsp;New Merit List</h5>
              </div>
            </div>
        <%--<div class="card-header">

            <h4>
                User Lists
            </h4>
        </div>--%> 
        <div class="card-body">

            <form>
                 <div class="input-group input-group-outline mb-3">
       <!--<asp:Label ID="lb_category" runat="server" Enabled="False" Text="Select category" CssClass="form-label"></asp:Label>-->
       <asp:DropDownList ID="category_ddl" runat="server"  CssClass="form-control selectpicker">
            <asp:ListItem>-- Select Category --</asp:ListItem>
           <asp:ListItem>General</asp:ListItem>
           <asp:ListItem>EWS</asp:ListItem>
           <asp:ListItem>ST/SC</asp:ListItem>
       </asp:DropDownList>
 </div>
                <div id="u_f" class="input-group input-group-outline mb-3" runat="server">
                     <asp:Label ID="lb_pr" runat="server" Enabled="False" Text="Enter percentage" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="pr" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
               
                
               <asp:Button ID="btn_sub" runat="server" Text="Display" ValidationGroup="val_user" CssClass="btn btn-info" OnClick="btn_display"/>
&nbsp;
                                


           </form>
        </div>
    </div>
            
            <div class="card mt-5">
        <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
              <div class="bg-gradient-info shadow-info border-radius-lg pt-4 pb-3">
                <h5 class="text-white text-capitalize ps-3"><i class="fas fa-users-cog"></i> &nbsp;Merit List</h5>
              </div>
            </div>
            <div class="card-body px-0 pb-2">
              <div class="table-responsive p-0">
                <asp:GridView ID="dgv_Merit_List" class="table align-items-center mb-0" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                </asp:GridView>
                  </div>
                </div>
    
    </div>
                
<br />
<br />
    <asp:Button ID="done" runat="server" Text="Create" CssClass="btn btn-info" OnClick="btn_create"/>
<br />

</asp:Content>
