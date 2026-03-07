using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Event(object sender, EventArgs e)
    {
        string ConnStr = ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString;
        string LoginId = userid.Text.Trim();
        string LoginPass = userpass.Text.Trim();

        if(LoginId != "" && LoginPass != "")
        {
            string SqlTxt = "SELECT * FROM UserLogin WHERE UserId=@UserId AND UserPassword=@UserPassword AND Active='Y'";
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(SqlTxt,Conn);
            Cmd.Parameters.AddWithValue("@UserId", LoginId);
            Cmd.Parameters.AddWithValue("@UserPassword", LoginPass);
            SqlDataReader Reader = Cmd.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Read();

                string RowId = Reader["Id"].ToString().Trim();
                string UserName = Reader["UserName"].ToString().Trim();
                string UserId = Reader["UserId"].ToString().Trim();

                Session["RowId"] = RowId;
                Session["UserName"] = UserName;
                Session["UserId"] = UserId;

                Response.Redirect("/ItemMaster.aspx?Id=" + Session["RowId"] + "&UserName=" + Session["UserName"] + "&LoginId=" + Session["UserId"]);
            }
            else
            {
                servermessage.Text = "Wrong userId or password given!";
            }
            Conn.Close();

        }
        else
        {
            servermessage.Text = "Please give proper user id and password";
        }
    }

}