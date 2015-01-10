using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_View_Sales_Invoice : System.Web.UI.Page
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
            //Bind_Sales_Invoice();
        }
    }
    protected void Bind_Sales_Invoice()
    {
        DataTable dt = Get_Sales_Invoice();
        if (dt.Rows.Count > 0)
        {
            gvSales_Invoice_View.DataSource = dt;
            gvSales_Invoice_View.DataBind();
        }
    }


    public DataTable Get_Sales_Invoice()
    {

        try
        {
            con.Open();

            string SQL_QUERY;

            int year, month;

            year = DateTime.Today.Year;
            month = DateTime.Today.Month;

          
            int days = DateTime.DaysInMonth(year, month);
            string Start_Date, End_Date;
            Start_Date = month + "/01/" + year;
            End_Date = month + "/" + days + "/" + year;

            SQL_QUERY = "SELECT dbo.Sales_Invoice_Detail.Bill_No,  dbo.[User].User_Name,Bill_Date, ";
            SQL_QUERY += "SUM(dbo.Sales_Invoice_Detail.Sales_Qty*dbo.Sales_Invoice_Detail.MRP) as Total_Amount FROM dbo.Sales_Invoice_Detail INNER JOIN ";
            SQL_QUERY += "dbo.[User] ON dbo.Sales_Invoice_Detail.Created_By = dbo.[User].User_ID  ";

            if (txtFromDate.Text == "" || txtToDate.Text == "")
            {

                SQL_QUERY += "WHERE Bill_Date BETWEEN '" + Start_Date + "' AND '" + End_Date + "' ";
                SQL_QUERY += "";
            }
            else
            {
                SQL_QUERY += "WHERE Bill_Date BETWEEN '"+ txtFromDate.Text +"' AND '"+txtToDate.Text+"' ";
                SQL_QUERY += "";
            }
            SQL_QUERY += "GROUP BY dbo.Sales_Invoice_Detail.Bill_No, dbo.[User].User_Name,Bill_Date ";
            SQL_QUERY += "ORDER BY dbo.Sales_Invoice_Detail.Bill_No DESC ";

            SQL_QUERY += "";
            SQL_QUERY += "";
            SQL_QUERY += "";
            SQL_QUERY += "";

            SQL_QUERY += "";
            SQL_QUERY += "";
            SQL_QUERY += "";
            SQL_QUERY += "";
            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);


            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

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
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Bind_Sales_Invoice();
    }
    protected void gvSales_Invoice_View_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSales_Invoice_View.PageIndex = e.NewPageIndex;
        Bind_Sales_Invoice();
    }
    protected void gvSales_Invoice_View_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int Bill_No = Convert.ToInt32(gvSales_Invoice_View.DataKeys[e.RowIndex].Values["Bill_No"].ToString());
            DOM = Convert.ToDateTime(System.DateTime.Now);
            Modified_By = Convert.ToInt32(Session["User_ID"]);
            string SQL_QUERY;
            SQL_QUERY = "DELETE FROM Sales_Invoice_Detail WHERE Bill_No=" + Bill_No;
            con.Open();
            SqlCommand cmd = new SqlCommand(SQL_QUERY, con);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Bind_Sales_Invoice();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
}