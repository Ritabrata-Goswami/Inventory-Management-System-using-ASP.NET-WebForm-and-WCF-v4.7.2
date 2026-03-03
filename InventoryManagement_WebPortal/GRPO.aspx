<%@ Page Title="Grpo" Async="true" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GRPO.aspx.cs" Inherits="GRPO" %>

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
        .input-fld-opt{
            width:63%;
            max-width:none;
            padding:7px 3px;
            font-size:14px;
            border:1px solid #999797;
            border-radius:3px;
        }
        .option-button{
            width: 7%;
            margin-left:2px;
            text-align:center;
            border-radius:3px;
            border:none;
            cursor:pointer;
            background-color:aqua;
        }
        .fa-bars{
            font-size:14px;
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
                <h2>Enter Goods Receipt Notes</h2>
            </div>
            <div class="form-container">
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Vendor Code:</asp:Label>
                    <asp:TextBox runat="server" ID="VendorCode" CssClass="input-fld-opt" placeholder="Enter Vendor Code..." ReadOnly="true"></asp:TextBox>
                    <button class="option-button" onclick="OpenPopup('VendorMaster',event)"><i class="fa fa-bars"></i></button>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Item Code:</asp:Label>
                    <asp:TextBox runat="server" ID="ItemCode" CssClass="input-fld-opt" placeholder="Enter Item Code..." ReadOnly="true"></asp:TextBox>
                    <button class="option-button" onclick="OpenPopup('ItemMaster',event)"><i class="fa fa-bars"></i></button>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Item Quantity:</asp:Label>
                    <asp:TextBox runat="server" ID="ItemQty" CssClass="input-fld" placeholder="Enter Item Quantity..." TextMode="Number"></asp:TextBox>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">GRN Date:</asp:Label>
                    <asp:TextBox runat="server" ID="GrnDate" CssClass="input-fld" placeholder="Enter GRN Date..." TextMode="Date"></asp:TextBox>
                </div>
                <div class="btn-container">
                    <asp:Button runat="server" Text="Submit" ID="BtnSubmit" CssClass="submit-btn" OnClientClick="return SubmitGrpo(event)"/>
                </div>
            </div>
        </div>
        <div class="ParentDisplayContainer">
            <div class="header-container">
                <h2>Display Goods Receipt Notes</h2>
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
                        <asp:BoundField HeaderText="Item Code" DataField="ItemCode" />
                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                        <asp:BoundField HeaderText="Quantity" DataField="Qty" />
                        <asp:BoundField HeaderText="Portal User" DataField="PortalOperatorName" />
                        <asp:BoundField HeaderText="GRN Date" DataField="GrnDate" />
                        <asp:BoundField HeaderText="Entry Date" DataField="EntryDate" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        function SubmitGrpo(event) {
            event.preventDefault();

            let getVendorCode = $("#<%= VendorCode.ClientID %>").val();
            let getItemCode = $("#<%= ItemCode.ClientID %>").val();
            let getItemQty = $("#<%= ItemQty.ClientID %>").val();
            let getGrnDate = $("#<%= GrnDate.ClientID%>").val();
            if (getVendorCode == "" || getItemCode == "" || getItemQty == "" || getGrnDate =="") {
                alert("All fields are mandatory!");
                return false;
            }
            const getUrlObj = new URLSearchParams(window.location.search);
            const portalOperatorCode = getUrlObj.get("Id");
            let sendObj = {
                "VendorCode": getVendorCode,
                "ItemCode": getItemCode,
                "ItemQty": getItemQty,
                "PortalOperatorCode": portalOperatorCode,
                "GrnDate": getGrnDate
            };
            //console.log(portalOperatorCode);
            //console.log(sendObj);

            $.ajax({
                type: "POST",
                data: JSON.stringify(sendObj),
                url: "http://localhost:55391/Wcf_ServiceApi.svc/PostGrpo",
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
        function OpenPopup(args, event) {
            event.preventDefault();
            const url = `./PopupMaster.aspx?SelectType=${args}`;
            const title = "Popup Master Data";
            const WindowSettings = "width=1050,height=550,left=100,top=100,resizable=yes,scrollbars=yes,status=yes";
            window.open(url, title, WindowSettings);
        }
        function GetMasterVal(GetVal, selectType) {
            if (selectType == "VendorMaster") {
                document.getElementById("<%=VendorCode.ClientID%>").value = GetVal;
            } else if (selectType == "ItemMaster") {
                document.getElementById("<%=ItemCode.ClientID%>").value = GetVal;
            }
        }
    </script>
</asp:Content>

