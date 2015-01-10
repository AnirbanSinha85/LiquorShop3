using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Report_Category_Wise_Quantity_Sale : System.Web.UI.Page
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
            Bind_Product_Category();
            ddlCategory.Items.Insert(0, new ListItem("Select", string.Empty));
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
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Category_Wise_Quantity_Sale_Print.aspx?fmdt=" + txtFromDate.Text + "&todt=" + txtToDate.Text + "&cid=" + ddlCategory.SelectedValue + "&cname=" + ddlCategory.SelectedItem);
    }
}