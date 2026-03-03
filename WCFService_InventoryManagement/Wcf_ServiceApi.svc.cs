using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;


namespace WCFService_InventoryManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Wcf_ServiceApi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Wcf_ServiceApi.svc or Wcf_ServiceApi.svc.cs at the Solution Explorer and start debugging.
    public class Wcf_ServiceApi : IWcf_ServiceApi
    {
        string SqlConnStr = ConfigurationManager.AppSettings["SqlConn"].ToString();
        public ConnectionRes CheckDbConnection()
        {
            ConnectionRes Res = new ConnectionRes();
            SqlConnection Conn = null;
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                Res.ResponseId = 0;
                Res.message = $"{Conn.Database} database is now connected!";
            }
            catch (SqlException SqlEx)
            {
                Res.ResponseId = -1;
                Res.message = SqlEx.Message;
            }
            catch (Exception ex)
            {
                Res.ResponseId= -1;
                Res.message = ex.Message;
            }

            return Res;
        }

        //POST Methods.
        public CommonResponse PostItemMaster(ItemMasterEntry ItemEntry)
        {
            CommonResponse ClsRes = new CommonResponse();
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn= new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"INSERT INTO ItemMaster (ItemCode, ItemName, UoM, UserCode, DATE) VALUES (@ItemCode, @ItemName, @UoM, @UserCode, @DATE)";
                SqlCommand Cmd = new SqlCommand(SqlTxt,Conn);
                Cmd.Parameters.AddWithValue("@ItemCode",ItemEntry.ItemCode);
                Cmd.Parameters.AddWithValue("@ItemName",ItemEntry.ItemName);
                Cmd.Parameters.AddWithValue("@UoM", ItemEntry.Uom);
                Cmd.Parameters.AddWithValue("@UserCode",ItemEntry.PortalOperatorCode);
                Cmd.Parameters.AddWithValue("@DATE",DateTime.Now);
                int Res = Cmd.ExecuteNonQuery();
                if(Res != 0)
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
                    ClsRes.StatusCode = (int)HttpStatusCode.Created;
                    ClsRes.Message = $"{Res} row effected. Data inserted successfully!";
                }
                else
                {
                    //
                }

            }
            catch (Exception ex) 
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
            }
            finally
            {
                Conn.Close();
            }

            return ClsRes;
        }
        public CommonResponse PostVendorMaster(VendorMasterEntry VendorEntry)
        {
            CommonResponse ClsRes = new CommonResponse();
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"INSERT INTO SupplierMaster (SupplierCode,SupplierName, Address,Phone,UserCode,DATE) VALUES 
                                                            (@SupplierCode,@SupplierName, @Address,@Phone,@UserCode,@DATE)";
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                Cmd.Parameters.AddWithValue("@SupplierCode", VendorEntry.VendorCode);
                Cmd.Parameters.AddWithValue("@SupplierName", VendorEntry.VendorName);
                Cmd.Parameters.AddWithValue("@Address", VendorEntry.VendorAddress);
                Cmd.Parameters.AddWithValue("@Phone", VendorEntry.VendorPhone);
                Cmd.Parameters.AddWithValue("@UserCode", VendorEntry.PortalOperatorCode);
                Cmd.Parameters.AddWithValue("@DATE", DateTime.Now);
                int Res = Cmd.ExecuteNonQuery();
                if (Res != 0)
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
                    ClsRes.StatusCode = (int)HttpStatusCode.Created;
                    ClsRes.Message = $"{Res} row effected. Data inserted successfully!";
                }
                else
                {
                    //
                }

            }
            catch (Exception ex)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
            }
            finally
            {
                Conn.Close();
            }

            return ClsRes;
        }
        public CommonResponse PostGrpo(GrpoEntry GrpoEntry)
        {
            CommonResponse ClsRes = new CommonResponse();
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"INSERT INTO GoodsReceiptNote (GRNDate,SupplierCode,ItemCode,ItemQuantity,UserCode,DATE) 
                                            VALUES (@GRNDate,@SupplierCode,@ItemCode,@ItemQuantity,@UserCode,@DATE)";
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                Cmd.Parameters.AddWithValue("@GRNDate",GrpoEntry.GrnDate);
                Cmd.Parameters.AddWithValue("@SupplierCode", GrpoEntry.VendorCode);
                Cmd.Parameters.AddWithValue("@ItemCode", GrpoEntry.ItemCode);
                Cmd.Parameters.AddWithValue("@ItemQuantity", GrpoEntry.ItemQty);
                Cmd.Parameters.AddWithValue("@UserCode", GrpoEntry.PortalOperatorCode);
                Cmd.Parameters.AddWithValue("@DATE", DateTime.Now);
                int Res = Cmd.ExecuteNonQuery();
                if (Res != 0)
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
                    ClsRes.StatusCode = (int)HttpStatusCode.Created;
                    ClsRes.Message = $"{Res} row effected. Data inserted successfully!";
                }
                else
                {
                    //
                }

            }
            catch (Exception ex)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
            }
            finally
            {
                Conn.Close();
            }

            return ClsRes;
        }
        public CommonResponse PostStockOut(StockOutEntry StockOutEntry)
        {
            CommonResponse ClsRes = new CommonResponse();
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"INSERT INTO StockOut (ItemCode,Quantity,UserCode,DATE) VALUES (@ItemCode,@Quantity,@UserCode,@DATE)";
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                Cmd.Parameters.AddWithValue("@ItemCode", StockOutEntry.ItemCode);
                Cmd.Parameters.AddWithValue("@Quantity", StockOutEntry.ItemQty);
                Cmd.Parameters.AddWithValue("@UserCode", StockOutEntry.PortalOperatorCode);
                Cmd.Parameters.AddWithValue("@DATE", DateTime.Now);
                int Res = Cmd.ExecuteNonQuery();
                if (Res != 0)
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
                    ClsRes.StatusCode = (int)HttpStatusCode.Created;
                    ClsRes.Message = $"{Res} row effected. Data inserted successfully!";
                }
                else
                {
                    //
                }

            }
            catch (Exception ex)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
            }
            finally
            {
                Conn.Close();
            }

            return ClsRes;
        }

        //GET Methods.
        public ResItemMastere GetItemMaster()
        {
            ResItemMastere ClsItemMaster = new ResItemMastere();
            List<GetItemMaster> ClsGetItemMaster_List = new List<GetItemMaster>();
            GetItemMaster ClsGetItemMaster = null;
            CommonResponse ClsRes = null;
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"SELECT	A.Id,
		                            A.ItemCode,
		                            A.ItemName,
		                            A.UoM,
		                            A.UserCode,
		                            A.DATE,
		                            B.UserName 
                            FROM	ItemMaster A INNER JOIN UserLogin B ON B.Id = A.UserCode
                            WHERE	A.Active='Y'";
                SqlCommand Cmd = new SqlCommand(SqlTxt,Conn);
                SqlDataReader Reader = Cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ClsGetItemMaster = new GetItemMaster()
                        {
                            Id = Convert.ToInt32(Reader["Id"].ToString()),
                            ItemCode = Reader["ItemCode"].ToString(),
                            ItemName = Reader["ItemName"].ToString(),
                            Uom = Reader["UoM"].ToString(),
                            PortalUserCode = Reader["UserCode"].ToString(),
                            PortalUserName = Reader["UserName"].ToString(),
                            EntryDate = Reader["DATE"].ToString()
                        };
                        ClsGetItemMaster_List.Add(ClsGetItemMaster);
                    }
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.OK;
                    ClsRes.Message = "Data fetched successfully!";
                    ClsItemMaster.Cls_CommRes = ClsRes;
                    ClsItemMaster.Cls_GetItemMasterList = ClsGetItemMaster_List;
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.NotFound;
                    ClsRes.Message = "No data found on item master!";
                    ClsItemMaster.Cls_CommRes = ClsRes;
                }
            }
            catch (Exception ex) 
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode= HttpStatusCode.InternalServerError;
                ClsRes = new CommonResponse();
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
                ClsItemMaster.Cls_CommRes= ClsRes;
            }
            finally
            {
                Conn?.Close();
            }
            return ClsItemMaster;
        }
        public ResVendorMaster GetVendorMaster()
        {
            ResVendorMaster ClsVendorMaster = new ResVendorMaster();
            List<GetVendorMaster> ClsGetVendorMaster_List = new List<GetVendorMaster>();
            GetVendorMaster ClsGetVendorMaster = null;
            CommonResponse ClsRes = null;
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"SELECT	A.Id, 
		                            A.SupplierCode, 
		                            A.SupplierName, 
		                            A.Address, 
		                            A.Phone, 
		                            B.UserName, 
		                            A.DATE 
                            FROM	SupplierMaster A INNER JOIN UserLogin B ON B.Id = A.UserCode 
                            WHERE	A.Active='Y'";
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                SqlDataReader Reader = Cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ClsGetVendorMaster = new GetVendorMaster()
                        {
                            Id = Convert.ToInt32(Reader["Id"].ToString()),
                            VendorCode = Reader["SupplierCode"].ToString(),
                            VendorName = Reader["SupplierName"].ToString(),
                            VendorAddr = Reader["Address"].ToString(),
                            Phone = Reader["Phone"].ToString(),
                            PortalOperatorName = Reader["UserName"].ToString(),
                            EntryDate = Reader["DATE"].ToString()
                        };
                        ClsGetVendorMaster_List.Add(ClsGetVendorMaster);
                    }
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.OK;
                    ClsRes.Message = "Data fetched successfully!";
                    ClsVendorMaster.Cls_CommRes = ClsRes;
                    ClsVendorMaster.Cls_GetVendorMasterList = ClsGetVendorMaster_List;
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.NotFound;
                    ClsRes.Message = "No data found on vendor master!";
                    ClsVendorMaster.Cls_CommRes = ClsRes;
                }
            }
            catch (Exception ex)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes = new CommonResponse();
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
                ClsVendorMaster.Cls_CommRes = ClsRes;
            }
            finally
            {
                Conn?.Close();
            }
            return ClsVendorMaster;
        }
        public ResGrpo GetGrpo()
        {
            ResGrpo ClsGrpo = new ResGrpo();
            List<GetGrpo> ClsGetGrpo_List = new List<GetGrpo>();
            GetGrpo ClsGetGrpo = null;
            CommonResponse ClsRes = null;
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"SELECT	A.Id, 
		                            A.GRNDate,
		                            A.SupplierCode,
		                            C.SupplierName,
		                            A.ItemCode,
		                            D.ItemName,
		                            A.ItemQuantity,
		                            B.UserName, 
		                            A.DATE 
                            FROM	GoodsReceiptNote A INNER JOIN UserLogin B ON B.Id = A.UserCode
                                    INNER JOIN SupplierMaster C ON C.SupplierCode = A.SupplierCode
		                            INNER JOIN ItemMaster D ON D.ItemCode = A.ItemCode";
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                SqlDataReader Reader = Cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ClsGetGrpo = new GetGrpo()
                        {
                            Id = Convert.ToInt32(Reader["Id"].ToString()),
                            VendorCode = Reader["SupplierCode"].ToString(),
                            VendorName = Reader["SupplierName"].ToString(),
                            ItemCode = Reader["ItemCode"].ToString(),
                            ItemName = Reader["ItemName"].ToString(),
                            Qty = Convert.ToDecimal(Reader["ItemQuantity"].ToString()),
                            PortalOperatorName = Reader["UserName"].ToString(),
                            GrnDate = Reader["GRNDate"].ToString(),
                            EntryDate = Reader["DATE"].ToString()
                        };
                        ClsGetGrpo_List.Add(ClsGetGrpo);
                    }
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.OK;
                    ClsRes.Message = "Data fetched successfully!";
                    ClsGrpo.Cls_CommRes = ClsRes;
                    ClsGrpo.Cls_GetGrpoList = ClsGetGrpo_List;
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.NotFound;
                    ClsRes.Message = "No data found on goods receipt note!";
                    ClsGrpo.Cls_CommRes = ClsRes;
                }
            }
            catch (Exception ex)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes = new CommonResponse();
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
                ClsGrpo.Cls_CommRes = ClsRes;
            }
            finally
            {
                Conn?.Close();
            }
            return ClsGrpo;
        }
        public ResStockOut GetStockOut()
        {
            ResStockOut ClsStockOut = new ResStockOut();
            List<GetStockOut> ClsGetStockOut_List = new List<GetStockOut>();
            GetStockOut ClsGetStockOut = null;
            CommonResponse ClsRes = null;
            SqlConnection Conn = null;
            string SqlTxt = "";
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                SqlTxt = @"SELECT	A.Id, 
		                            A.ItemCode,
		                            C.ItemName,
		                            A.Quantity,
		                            B.UserName, 
		                            A.DATE 
                            FROM	StockOut A INNER JOIN UserLogin B ON B.Id = A.UserCode
		                            INNER JOIN ItemMaster C ON C.ItemCode = A.ItemCode";
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                SqlDataReader Reader = Cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ClsGetStockOut = new GetStockOut()
                        {
                            Id = Convert.ToInt32(Reader["Id"].ToString()),
                            ItemCode = Reader["ItemCode"].ToString(),
                            ItemName = Reader["ItemName"].ToString(),
                            Qty = Convert.ToDecimal(Reader["Quantity"].ToString()),
                            PortalOperatorName= Reader["UserName"].ToString(),
                            EntryDate = Reader["DATE"].ToString()
                        };
                        ClsGetStockOut_List.Add(ClsGetStockOut);
                    }
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.OK;
                    ClsRes.Message = "Data fetched successfully!";
                    ClsStockOut.Cls_CommRes = ClsRes;
                    ClsStockOut.Cls_GetStockOutList = ClsGetStockOut_List;
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                    ClsRes = new CommonResponse();
                    ClsRes.StatusCode = (int)HttpStatusCode.NotFound;
                    ClsRes.Message = "No data found on stock out!";
                    ClsStockOut.Cls_CommRes = ClsRes;
                }
            }
            catch (Exception ex)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                ClsRes = new CommonResponse();
                ClsRes.StatusCode = (int)HttpStatusCode.InternalServerError;
                ClsRes.Message = ex.Message;
                ClsStockOut.Cls_CommRes = ClsRes;
            }
            finally
            {
                Conn?.Close();
            }
            return ClsStockOut;
        }


        //DELETE Methods.
        public CommonResponse DeleteData(string id, string tblname)
        {
            CommonResponse Cls_Res = new CommonResponse();
            SqlConnection Conn = null;
            id = id.Trim();
            tblname = tblname.Trim();
            try
            {
                Conn = new SqlConnection(SqlConnStr);
                Conn.Open();
                string SqlTxt = "DELETE FROM " + tblname + " WHERE Id=" + id;
                SqlCommand Cmd = new SqlCommand(SqlTxt, Conn);
                Cmd.ExecuteNonQuery();
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                Cls_Res.StatusCode = (int)HttpStatusCode.OK;
                Cls_Res.Message = $"{id} no id deleted successfully!";
            }
            catch (Exception ex) 
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode= HttpStatusCode.InternalServerError;
                Cls_Res.StatusCode = (int)HttpStatusCode.InternalServerError;
                Cls_Res.Message = ex.Message;
            }
            finally
            {
                if (Conn != null)
                {
                    Conn?.Close();
                }
            }
            return Cls_Res;
        }


    }
}
