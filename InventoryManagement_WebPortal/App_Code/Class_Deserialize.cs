using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class_Deserialize
/// </summary>
public class CommonResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
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
public class GetAsyncItemMasterData
{
    public ResItemMastere GetItemMasterResult { get; set; }
}
public class GetAsyncDeleteRes
{
    public CommonResponse DeleteDataResult { get; set; }
}
