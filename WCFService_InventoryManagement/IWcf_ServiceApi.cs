using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService_InventoryManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWcf_ServiceApi" in both code and config file together.
    [ServiceContract]
    public interface IWcf_ServiceApi
    {
        [OperationContract]
        [WebInvoke(Method ="GET", UriTemplate ="/CheckDBConn", ResponseFormat =WebMessageFormat.Json)]
        ConnectionRes CheckDbConnection();

        //POST methods.
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PostItemMaster", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonResponse PostItemMaster(ItemMasterEntry ItemEntry);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PostSupplierMaster", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonResponse PostVendorMaster(VendorMasterEntry VendorEntry);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PostGrpo", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonResponse PostGrpo(GrpoEntry GrpoEntry);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PostStockOut", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonResponse PostStockOut(StockOutEntry StockOutEntry);

        //GET methods.
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetItemMaster", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResItemMastere GetItemMaster();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetVendorMaster", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResVendorMaster GetVendorMaster();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetGrpo", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResGrpo GetGrpo();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetStockOut", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResStockOut GetStockOut();

        //DELETE methods.
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteData?id={id}&tablename={tblname}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        CommonResponse DeleteData(string id, string tblname);
    }
}
