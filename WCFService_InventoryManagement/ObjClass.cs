using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFService_InventoryManagement
{
    public class ConnectionRes
    {
        public int ResponseId { get; set; }
        public string message { get; set; }
    }

    public class CommonResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class ItemMasterEntry
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Uom { get; set; }
        public string PortalOperatorCode { get; set; }
    }
    public class VendorMasterEntry
    {
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorPhone { get; set; }
        public string PortalOperatorCode { get; set; }
    }
    public class GrpoEntry
    {
        public string VendorCode { get; set; }
        public string ItemCode { get; set; }
        public double ItemQty { get; set; }
        public string PortalOperatorCode { get; set; }
        public string GrnDate { get; set; }
    }
    public class StockOutEntry
    {
        public string ItemCode { get; set; }
        public double ItemQty { get; set; }
        public string PortalOperatorCode { get; set; }
    }

    public class GetItemMaster
    {
        public int Id { get; set; }
        public string ItemCode { set; get; }
        public string ItemName { get; set; }
        public string Uom { get; set; }
        public string PortalUserCode { get; set; }
        public string PortalUserName { get; set; }
        public string EntryDate { get; set; }
    }
    public class ResItemMastere
    {
        public CommonResponse Cls_CommRes { get; set; }
        public List<GetItemMaster> Cls_GetItemMasterList { get; set; }
    }

}