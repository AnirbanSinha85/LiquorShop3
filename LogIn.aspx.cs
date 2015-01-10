using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class LogIn : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdLogIn_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = Check_LogIn();
        if (dt.Rows.Count > 0)
        {
            Session["User_Id"] = dt.Rows[0]["User_ID"];
            Session["User_Name"] = dt.Rows[0]["User_Name"];
            Session["First_Name"] = dt.Rows[0]["First_Name"];
            Session["AcessLevel"] = dt.Rows[0]["AcessLevel"];
            
            Response.Redirect("Home.aspx");
        }
        else
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(In valid);", true);

        }
    }
    public DataTable Check_LogIn()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Check_LogIn", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@User_Name", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@User_Name"].Value = txtUserName.Text;

            cmdEmp.Parameters.Add("@Password", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@Password"].Value = txtPassword.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.SelectCommand = cmdEmp;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}