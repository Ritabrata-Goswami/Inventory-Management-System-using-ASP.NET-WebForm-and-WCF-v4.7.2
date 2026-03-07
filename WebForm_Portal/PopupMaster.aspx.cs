using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopupMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string GetType =Request.QueryString["SelectType"];
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(GetType) && (Session["RowId"] != null || Session["UserName"] != null || Session["UserId"] != null))
            {
                RegisterAsyncTask(new PageAsyncTask(() => GetMasterDataTable(GetType)));
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }

    protected async Task GetMasterDataTable(string Args)
    {
        Args = Args?.Trim().ToLower();
        HttpClient WebClient = null;
        HttpResponseMessage WebRes = null;
        string GetDataStr = "";
        string StatusMsg = "";
        int StatusCode = 0;
        try
        {
            switch (Args)
            {
                case "vendormaster":
                    WebClient = new HttpClient();
                    WebRes = await WebClient.GetAsync("http://localhost:55391/Wcf_ServiceApi.svc/GetVendorMaster");
                    GetDataStr = await WebRes.Content.ReadAsStringAsync();
                    GetAsyncVendorMasterData GetDataObj_1 = JsonConvert.DeserializeObject<GetAsyncVendorMasterData>(GetDataStr);

                    StatusMsg = GetDataObj_1.GetVendorMasterResult.Cls_CommRes.Message;
                    StatusCode = GetDataObj_1.GetVendorMasterResult.Cls_CommRes.StatusCode;
                    List<GetVendorMaster> List_VendorMaster = GetDataObj_1.GetVendorMasterResult.Cls_GetVendorMasterList;

                    GridView_MasterData.DataSource = List_VendorMaster;
                    GridView_MasterData.DataBind();
                    break;
                case "itemmaster":
                    WebClient = new HttpClient();
                    WebRes = await WebClient.GetAsync("http://localhost:55391/Wcf_ServiceApi.svc/GetItemMaster");
                    GetDataStr = await WebRes.Content.ReadAsStringAsync();
                    GetAsyncItemMasterData GetDataObj_2 = JsonConvert.DeserializeObject<GetAsyncItemMasterData>(GetDataStr);

                    StatusMsg = GetDataObj_2.GetItemMasterResult.Cls_CommRes.Message;
                    StatusCode = GetDataObj_2.GetItemMasterResult.Cls_CommRes.StatusCode;
                    List<GetItemMaster> List_ItemMaster = GetDataObj_2.GetItemMasterResult.Cls_GetItemMasterList;

                    GridView_MasterData.DataSource = List_ItemMaster;
                    GridView_MasterData.DataBind();
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex) 
        {
            //
        }
        
    }
}