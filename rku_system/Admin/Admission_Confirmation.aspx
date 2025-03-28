﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Desboard.Master" AutoEventWireup="true" CodeBehind="Admission_Confirmation.aspx.cs" Inherits="rku_system.Admin.Admission_Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                             <div class="card mt-5 mx-4">
    <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
          <div class="bg-gradient-info shadow-info border-radius-lg pt-4 pb-3">
            <h5 class="text-white text-capitalize ps-3"><i class="fas fa-users-cog"></i> &nbsp;All Merit List</h5>
          </div>
        </div>
        <div class="card-body px-0 pb-2">
          <div class="table-responsive p-0">
            <asp:GridView ID="dgv_h" class="table align-items-center mb-0" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True" OnSelectedIndexChanged="dgv_h_SelectedIndexChanged">
            </asp:GridView>
              </div>
            </div>

</div>
        
            
            <div class="card mt-5 mx-4">
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

    <!--<asp:Button ID="print" runat="server" Text="Print" CssClass="btn btn-info mx-4" OnClick="print_Click"/>-->
    <Button ID="b1" class="btn btn-info mx-4" OnClick="printGridView(); return false;">Print</Button>
    
    <asp:Button ID="Excel" runat="server" Text="Export Excel" CssClass="btn btn-info mx-4" OnClick="Excel_Click"/>
<br />
    <br />
    <br />
</asp:Content>
