<%@ Page Title="Supplier-Master" Async="true" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SupplierMaster.aspx.cs" Inherits="SupplierMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
        .ItemMasterContainer{
            padding:10px 10px;
            font-family:Arial, Helvetica, sans-serif;
            display:flex;
            flex-direction:row;
            width:100%;
        }
        .ParentFormContainer{
            width:35%;
        }
        .ParentDisplayContainer{
            width:65%;
        }
        .header-container{
            text-align:center;
            margin-bottom:10px;
        }
        .form-container{
            padding:10px 5px;
            /*border:1px solid #000000;
            width:100%;*/
        }
        .field-container{
            display:flex;
            flex-direction:row;
            width:100%;
            margin-bottom:5px;
        }
        .lblTxt{
            width:30%;
            font-size:14px;
            font-weight:bold;
        }
        .input-fld{
            width:70%;
            max-width:none;
            padding:7px 3px;
            font-size:14px;
            border:1px solid #999797;
            border-radius:3px;
        }
        .txtareatag{
            resize:none;
        }
        .btn-container{
            margin-top:20px;
        }
        .submit-btn{
            /*display:block;*/
            padding:8px 8px;
            width:100%;
            max-width:none;
            font-size:15px;
            font-weight:bold;
            border:none;
            border-radius:3px;
            cursor:pointer;
            color:ghostwhite;
            background-color:#0ab869;
        }
        .submit-btn:hover{
            background-color:#0ccd2f;
            transition:0.5s;
        }
        .GridViewContainer{
            display:flex;
            justify-content:center;
            /*align-items:center;*/
            margin-top:15px;
            padding:3px 3px;
            max-height:65vh;     /* restrict height */
            overflow-y:auto;     /* enable vertical scroll */
            overflow-x:auto;     /* optional horizontal scroll */
            /*border: 1px solid #ccc;*/
        }
        .Tbl-Hdr-Txt th{
            padding:5px 8px;
            text-align:center;
        }
        .Tbl-Row-Txt td{
            padding:5px 10px;
            text-align:center;
            font-size:15px;
        }
    </style>
    <div class="ItemMasterContainer">
        <div class="ParentFormContainer">
            <div class="header-container">
                <h2>Enter Vendor Master</h2>
            </div>
            <div class="form-container">
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Vendor Code:</asp:Label>
                    <asp:TextBox runat="server" ID="VendorCode" CssClass="input-fld" placeholder="Enter Vendor Code..."></asp:TextBox>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Vendor Name:</asp:Label>
                    <asp:TextBox runat="server" ID="VendorName" CssClass="input-fld" placeholder="Enter Vendor Name..."></asp:TextBox>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Vendor Address:</asp:Label>
                    <asp:TextBox runat="server" ID="VendorAddr" CssClass="input-fld txtareatag" placeholder="Enter Vendor Address..." TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Vendor Phone:</asp:Label>
                    <asp:TextBox runat="server" ID="VendorPhone" CssClass="input-fld" placeholder="Enter Vendor Phone..."></asp:TextBox>
                </div>
                <div class="btn-container">
                    <asp:Button runat="server" Text="Submit" ID="BtnSubmit" CssClass="submit-btn" OnClientClick="return SubmitVendorMaster(event)"/>
                </div>
            </div>
        </div>
        <div class="ParentDisplayContainer">
            <div class="header-container">
                <h2>Display Vendor Master</h2>
            </div>
            <div class="GridViewContainer">
                <asp:GridView runat="server" ID="GridView_VendorMaster" AutoGenerateColumns="false" EmptyDataText="No Records Found!" DataKeyNames="Id" OnRowDeleting="GridView_RowDelete">
                    <HeaderStyle ForeColor="WhiteSmoke" BackColor="DarkBlue" Font-Size="Medium" CssClass="Tbl-Hdr-Txt"/>
                    <RowStyle CssClass="Tbl-Row-Txt" />
                    <EmptyDataRowStyle ForeColor="OrangeRed" BorderColor="White" Font-Size="17px" />
                    <AlternatingRowStyle BackColor="LightCyan" />
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id"/>
                        <asp:BoundField HeaderText="Vendor Code" DataField="VendorCode" />
                        <asp:BoundField HeaderText="Vendor Name" DataField="VendorName" />
                        <asp:BoundField HeaderText="Vendor Address" DataField="VendorAddr" />
                        <asp:BoundField HeaderText="Phone" DataField="Phone" />
                        <asp:BoundField HeaderText="Portal User" DataField="PortalOperatorName" />
                        <asp:BoundField HeaderText="Entry Date" DataField="EntryDate" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        function SubmitVendorMaster(event) {
            event.preventDefault();

            let getVendorCode = $("#<%= VendorCode.ClientID %>").val();
            let getVendorName = $("#<%= VendorName.ClientID %>").val();
            let getVendorAddr = $("#<%= VendorAddr.ClientID %>").val();
            let getVendorPhone = $("#<%= VendorPhone.ClientID%>").val();
            if (getVendorCode == "" || getVendorName == "" || getVendorAddr == "" || getVendorPhone =="") {
                alert("All fields are mandatory!");
                return false;
            }
            const getUrlObj = new URLSearchParams(window.location.search);
            const portalOperatorCode = getUrlObj.get("Id");
            let sendObj = {
                "VendorCode": getVendorCode,
                "VendorName": getVendorName,
                "VendorAddress": getVendorAddr,
                "VendorPhone": getVendorPhone,
                "PortalOperatorCode": portalOperatorCode
            };
            //console.log(portalOperatorCode);
            //console.log(sendObj);

            $.ajax({
                type: "POST",
                data: JSON.stringify(sendObj),
                url: "http://localhost:55391/Wcf_ServiceApi.svc/PostSupplierMaster",
                contentType: "application/json",
                success: function (res) {
                    console.log(res);
                    alert(res.Message);
                },
                error: function (Err) {
                    const ErrObj = JSON.parse(Err.responseText); 
                    console.log(ErrObj);
                    alert(`Error:- ${ErrObj.Message}`);
                }
            });
        }
    </script>
</asp:Content>

