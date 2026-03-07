using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadGridView));
        }
    }

    protected async Task LoadGridView()
    {
        HttpClient WebClient = null;
        try
        {
            WebClient = new HttpClient();
            HttpResponseMessage WebRes = await WebClient.GetAsync("http://localhost:55391/Wcf_ServiceApi.svc/GetStockOut");
            string GetDataStr = await WebRes.Content.ReadAsStringAsync();
            GetAsyncStockOutData GetDataObj = JsonConvert.DeserializeObject<GetAsyncStockOutData>(GetDataStr);

            string StatusMsg = GetDataObj.GetStockOutResult.Cls_CommRes.Message;
            int StatusCode = GetDataObj.GetStockOutResult.Cls_CommRes.StatusCode;
            List<GetStockOut> List_GrpoData = GetDataObj.GetStockOutResult.Cls_GetStockOutList;

            GridView_VendorMaster.DataSource = List_GrpoData;
            GridView_VendorMaster.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            
        }
    }
    protected async void GridView_RowDelete(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView_VendorMaster.DataKeys[e.RowIndex].Value);
        string TableName = "StockOut";
        try
        {
            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.DeleteAsync($"http://localhost:55391/Wcf_ServiceApi.svc/DeleteData?id={id}&tablename={TableName}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetAsyncDeleteRes>(json);
                    string message = result.DeleteDataResult.Message;

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{message}');", true);

                    await LoadGridView();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{id} no id delete failed!');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error: {ex.Message}');", true);
        }
    }

}