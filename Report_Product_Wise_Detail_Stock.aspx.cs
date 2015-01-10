using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Report_Product_Wise_Detail_Stock : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        

        gvProductStock.DataSource = Get_Sales_Invoice();
        gvProductStock.DataBind();
    }

    DataTable Get_Sales_Invoice()
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Stock", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;
            cmdEmp.Parameters.Add("@From_Date", SqlDbType.Date).Value = Convert.ToDateTime(txtFromDate.Text);
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
        }
    }
    protected void cmdPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Product_Wise_Detail_Stock_Print.aspx?fmdt=" + txtFromDate.Text);
    }
}