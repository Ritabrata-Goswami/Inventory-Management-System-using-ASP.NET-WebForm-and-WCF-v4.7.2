<%@ Page Title="Item-Master" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ItemMaster.aspx.cs" Inherits="ItemMaster" Async="true" %>

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
                <h2>Enter Item Master</h2>
            </div>
            <div class="form-container">
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Item Code:</asp:Label>
                    <asp:TextBox runat="server" ID="ItemCode" CssClass="input-fld" placeholder="Enter Item Code..."></asp:TextBox>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Item Name:</asp:Label>
                    <asp:TextBox runat="server" ID="ItemName" CssClass="input-fld" placeholder="Enter Item Name..."></asp:TextBox>
                </div>
                <div class="field-container">
                    <asp:Label runat="server" CssClass="lblTxt">Units of Measurement:</asp:Label>
                    <asp:DropDownList runat="server" ID="UoM" CssClass="input-fld">
                        <asp:ListItem Value="" Text="Select Units of Measurement"></asp:ListItem>
                        <asp:ListItem Value="kg" Text="Kg"></asp:ListItem>
                        <asp:ListItem Value="gram" Text="Gram"></asp:ListItem>
                        <asp:ListItem Value="pieces" Text="Pieces"></asp:ListItem>
                        <asp:ListItem Value="liter" Text="Liter"></asp:ListItem>
                        <asp:ListItem Value="ton" Text="Ton"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="btn-container">
                    <asp:Button runat="server" Text="Submit" ID="BtnSubmit" CssClass="submit-btn" OnClientClick="return SubmitItemMaster(event)"/>
                </div>
            </div>
        </div>
        <div class="ParentDisplayContainer">
            <div class="header-container">
                <h2>Display Item Master</h2>
            </div>
            <div class="GridViewContainer">
                <asp:GridView runat="server" ID="GridView_ItemMaster" AutoGenerateColumns="false" EmptyDataText="No Records Found!" DataKeyNames="Id" OnRowDeleting="GridView_RowDelete">
                    <HeaderStyle ForeColor="WhiteSmoke" BackColor="DarkBlue" Font-Size="Medium" CssClass="Tbl-Hdr-Txt"/>
                    <RowStyle CssClass="Tbl-Row-Txt" />
                    <EmptyDataRowStyle ForeColor="OrangeRed" BorderColor="White" Font-Size="17px" />
                    <AlternatingRowStyle BackColor="LightCyan" />
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id"/>
                        <asp:BoundField HeaderText="Item Code" DataField="ItemCode" />
                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                        <asp:BoundField HeaderText="Portal User" DataField="PortalUserName" />
                        <asp:BoundField HeaderText="Unit" DataField="Uom" />
                        <asp:BoundField HeaderText="Entry Date" DataField="EntryDate" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        function SubmitItemMaster(event) {
            event.preventDefault();

            let getItemCode = $("#<%= ItemCode.ClientID %>").val();
            let getItemName = $("#<%= ItemName.ClientID %>").val();
            let getUoM = $("#<%= UoM.ClientID %>").val();
            if (getItemCode == "" || getItemName == "" || getUoM == "") {
                alert("All fields are mandatory!");
                return false;
            }
            const getUrlObj = new URLSearchParams(window.location.search);
            const portalOperatorCode = getUrlObj.get("Id");
            let sendObj = {
                "ItemCode": getItemCode,
                "ItemName": getItemName,
                "Uom": getUoM,
                "PortalOperatorCode": portalOperatorCode
            };
            //console.log(portalOperatorCode);
            //console.log(sendObj);

            $.ajax({
                type: "POST",
                data: JSON.stringify(sendObj),
                url: "http://localhost:55391/Wcf_ServiceApi.svc/PostItemMaster",
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

