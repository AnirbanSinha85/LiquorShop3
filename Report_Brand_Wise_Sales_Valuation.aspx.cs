using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Report_Brand_Wise_Sales_Valuation : System.Web.UI.Page
{
    
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    int Delete_Flag, Created_By, Modified_By, Gender, rt;
    DateTime DOB, DOC, DOM;

    protected void Page_Load(object sender, EventArgs e)
    {
         if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
           // Bind_Sales_Invoice();
        }
    }
   
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Brand_Wise_Sales_Valuation_Print.aspx?fmdt="+txtFromDate.Text+"&todt="+txtToDate.Text);
    }
}