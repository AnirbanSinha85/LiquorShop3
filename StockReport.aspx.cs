using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_StockReport : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    int Delete_Flag, Created_By, Modified_By, Gender, rt;
    DateTime DOB, DOC, DOM;
    string SQL_QUERY;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            Bind_Product_Category();
            Bind_Brand();

            ddlCategory.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlBrand.Items.Insert(0, new ListItem("Select", string.Empty));
            Bind_Product_By_Category_Brand();
           // BindProduct();

        }
    }
    protected void Bind_Product_Category()
    {
        DataTable dt = Get_Product_Category();
        ddlCategory.DataSource = dt;
        ddlCategory.DataTextField = "Category_Name";
        ddlCategory.DataValueField = "Category_ID";
        ddlCategory.DataBind();


    }
    public DataTable Get_Product_Category()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Category", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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
    protected void Bind_Brand()
    {
        DataTable dt = Get_Brand();
        ddlBrand.DataSource = dt;
        ddlBrand.DataTextField = "Brand_Name";
        ddlBrand.DataValueField = "Brand_ID";
        ddlBrand.DataBind();
    }
    public DataTable Get_Brand()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Brand", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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
    protected void Bind_Product_By_Category_Brand()
    {
        DataTable dt = Get_Product_By_Category_Brand();
        rptStockReport.DataSource = dt;

        rptStockReport.DataBind();
    }
    public DataTable Get_Product_By_Category_Brand()
    {

        try
        {
            con.Open();

            SQL_QUERY = "SELECT dbo.Product_Detail.Product_ID, dbo.Product_Category.Category_Name, dbo.Product_Brand.Brand_Name, dbo.Product_Size.Size_Name, ";
            SQL_QUERY += " dbo.Product_Detail.Product_Name, dbo.Product_Detail.Avalable_Quantity ";
            SQL_QUERY += "FROM dbo.Product_Detail INNER JOIN dbo.Product_Category ON dbo.Product_Detail.Category_ID = dbo.Product_Category.Category_ID INNER JOIN ";
            SQL_QUERY += "dbo.Product_Brand ON dbo.Product_Detail.Brand_ID = dbo.Product_Brand.Brand_ID INNER JOIN ";
            SQL_QUERY += " dbo.Product_Size ON dbo.Product_Detail.Size_ID = dbo.Product_Size.Size_ID   ";
            if (Convert.ToString(ddlCategory.SelectedItem) != "Select")
            {
                SQL_QUERY += "WHERE dbo.Product_Category.Category_ID='" + ddlCategory.SelectedValue + "'";
            }
            if (Convert.ToString(ddlBrand.SelectedItem) != "Select")
            {
                SQL_QUERY += "AND dbo.Product_Detail.Brand_ID='" + ddlBrand.SelectedValue + "'";
            }
            SQL_QUERY += "";
            SQL_QUERY += "";
            SQL_QUERY += "";
            SQL_QUERY += "";
            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);


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
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Bind_Product_By_Category_Brand();
    }

    public DataTable Getproduct()
    {
        try
        {
            con.Open();
            SQL_QUERY = "SELECT Product_ID,Avalable_Quantity FROM Product_Detail order BY Product_ID ";
            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
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

    public void BindProduct()
    {
        DataTable dt = Getproduct();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int pid = Convert.ToInt32(dt.Rows[i]["Product_ID"]);
            int Avalable_Quantity = Convert.ToInt32(dt.Rows[i]["Avalable_Quantity"]);
            con.Open();
            SQL_QUERY = "SELECT Product_ID,SUM(Sales_Qty) as Total_Sale FROM Sales_Invoice_Detail where Product_ID=" + pid;
            SQL_QUERY += " group BY Product_ID ORDER BY Product_ID ";
            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable sadt = new DataTable();
            sadt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.SelectCommand = cmdEmp;
            da.Fill(sadt);
            con.Close();
            int Total_Sale;
            if (sadt.Rows.Count > 0)
            {
                Total_Sale = Convert.ToInt32(sadt.Rows[0]["Total_Sale"]);
            }
            else
            {
                Total_Sale = 0;
            }

            //----------
            con.Open();
            SQL_QUERY = "select i.Product_ID,SUM(i.Quantity_In_Box*s.Pcs_In_Box) as Box_Total,SUM(i.Quantity_In_Pce) as Pcs_total, ";
            SQL_QUERY += "(SUM(i.Quantity_In_Box*s.Pcs_In_Box)+SUM(i.Quantity_In_Pce)) as Total_Purchase ";
            SQL_QUERY += "FROM Purchase_Invoice i inner JOIN Product_Size s on i.Size_ID=s.Size_ID where Product_ID=" + pid + " GROUP BY i.Product_ID ";
            cmdEmp = new SqlCommand(SQL_QUERY, con);
            da = new SqlDataAdapter();
            sadt = new DataTable();
            sadt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.SelectCommand = cmdEmp;
            da.Fill(sadt);
            con.Close();
            int Total_Purchase;
            if (sadt.Rows.Count > 0)
            {
                Total_Purchase = Convert.ToInt32(sadt.Rows[0]["Total_Purchase"]);
            }
            else
            {
                Total_Purchase = 0;
            }
            int ss = (Avalable_Quantity + Total_Purchase) - Total_Sale;


            con.Open();
            SQL_QUERY = "insert into Product_Stock values(" + pid + "," + ss +  ",0" + ",'2013-09-30 12:20:40.590'" + ",1" + ",'2013-09-30 12:20:40.590',1" + ")";
            cmdEmp = new SqlCommand(SQL_QUERY, con);
            cmdEmp.ExecuteNonQuery();

            con.Close();




        }
    }

}