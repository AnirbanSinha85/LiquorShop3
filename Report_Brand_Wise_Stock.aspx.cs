using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Report_Brand_Wise_Stock : System.Web.UI.Page
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
            Bind_Brand();
            ddlBrand.Items.Insert(0, new ListItem("Select", string.Empty));
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
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Brand_Wise_Stock_Print.aspx?fmdt=" + txtFromDate.Text + "&todt=" + txtToDate.Text + "&bid=" + ddlBrand.SelectedValue + "&bname=" + ddlBrand.SelectedItem);
    }
}