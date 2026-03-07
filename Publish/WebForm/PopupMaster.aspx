<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeFile="PopupMaster.aspx.cs" Inherits="PopupMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            font-family:Arial, Helvetica, sans-serif;
        }
        .popup-container{
            padding:8px 8px;
            display:flex;
            flex-direction:column;
            align-items:center;
            justify-content:center;
        }
        .hdr-txt{
            text-align:center;
            font-size:20px;
            font-weight:bold;
            margin-bottom:10px;
        }
        .gridview-container{
            margin-top:15px;
            padding:10px 5px;
        }
        .tbl-hdr th{
            padding: 7px 7px;
        }
        .tbl-row td{
            padding:7px 7px;
        }
        .tbl-row:hover{
            cursor:pointer;
            background-color:#b6b6b6;
            transition:0.3s;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="popup-container">
            <div id="hdr-txt"></div>
            <div id="gridview-container">
                <asp:GridView runat="server" ID="GridView_MasterData" AutoGenerateColumns="true">
                    <HeaderStyle BackColor="#1f1f1f" ForeColor="WhiteSmoke" Font-Size="17px" HorizontalAlign="Center" CssClass="tbl-hdr"/>
                    <RowStyle Font-Size="15px" CssClass="tbl-row" />
                </asp:GridView>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        const urlSearchObj = new URLSearchParams(window.location.search);
        const getSelectType = urlSearchObj.get("SelectType");
        document.getElementById("hdr-txt").style.fontSize = "23px";
        document.getElementById("hdr-txt").style.fontWeight = "bold";
        document.getElementById("hdr-txt").style.marginBottom = "15px";
        if (getSelectType == "VendorMaster") {
            document.getElementById("hdr-txt").innerHTML = "Vendor Master List";
        } else if (getSelectType == "ItemMaster") {
            document.getElementById("hdr-txt").innerHTML = "Item Master List";
        }

        const GetAllTbl = document.querySelectorAll("#<%= GridView_MasterData.ClientID %> tr");
        GetAllTbl.forEach((Val, Arr) => {
            Val.addEventListener("click", function () {
                const Cells = this.querySelectorAll("td");
                if (Cells.length > 1) {
                    const SecondColVal = Cells[1].innerHTML.trim();
                    //console.log(SecondColVal);
                    window.opener.GetMasterVal(SecondColVal, getSelectType);
                    window.close();
                }
            });
        });
    </script>
</body>
</html>
