using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Report_Brand_Wise_Stock_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    DateTime From_Date, To_Date;
    String s_From_Date, s_To_Date, s_Date;
    int Brand_Id;
    string SQL_QUERY, Brand_Name;

    protected void Page_Load(object sender, EventArgs e)
    {
        From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        To_Date = Convert.ToDateTime(Request.QueryString["todt"]);
        Brand_Id = Convert.ToInt32(Request.QueryString["bid"]);
        Brand_Name = Convert.ToString(Request.QueryString["bname"]);
        s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");
        Bind_Report(Brand_Id);
        //view_Brand_Wise_Sale_print.Text = rpt.ToString();
    }

    private void Bind_Report(int Brand_Id)
    {
        dt = new DataTable();

        dt = Get_Product_Detail_By_Brand(Brand_Id);
        if (dt.Rows.Count > 0)
        {
           // show_Report();
            int Product_Id;
            for (int i = 0; i<dt.Rows.Count; i++)
            {

            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);

        }
    }
    public DataTable Get_Product_Detail_By_Brand(int bid)
    {
        try
        {
            con.Open();

            SQL_QUERY = "";

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Detail_By_Brand", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@Brand_Id", SqlDbType.Int);
            cmdEmp.Parameters["@Brand_Id"].Value = bid;

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
}