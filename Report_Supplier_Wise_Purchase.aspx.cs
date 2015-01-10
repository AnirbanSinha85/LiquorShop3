using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Report_Supplier_Wise_Purchase : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    int Delete_Flag, Created_By, Modified_By, Gender, rt;
    DateTime DOB, DOC, DOM;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            Bind_Supplier();
            ddlSupplier.Items.Insert(0, new ListItem("Select", string.Empty));
        }
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Bind_Report();
    }
    protected void Bind_Supplier()
    {
        DataTable dt = Get_Supplier();
        ddlSupplier.DataSource = dt;
        ddlSupplier.DataTextField = "Supplier_Name";
        ddlSupplier.DataValueField = "Supplier_ID";
        ddlSupplier.DataBind();
    }
    public DataTable Get_Supplier()
    {
        try
        {
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Supplier", con);
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
    private void Bind_Report()
    {
        dt = new DataTable();
        dt = Get_Supplier_Wise_Purchase();
        if (dt.Rows.Count > 0)
        {
            gvPurcase_Invoice.DataSource = dt;
            gvPurcase_Invoice.DataBind();
        }
        else
        {
            dt.Rows.Add(dt.NewRow());
            gvPurcase_Invoice.DataSource = dt;
            gvPurcase_Invoice.DataBind();
            int columncount = gvPurcase_Invoice.Rows[0].Cells.Count;
            gvPurcase_Invoice.Rows[0].Cells.Clear();
            gvPurcase_Invoice.Rows[0].Cells.Add(new TableCell());
            gvPurcase_Invoice.Rows[0].Cells[0].ColumnSpan = columncount;
            gvPurcase_Invoice.Rows[0].Cells[0].Text = "No Data Found";
        }
    }
    public DataTable Get_Supplier_Wise_Purchase()
    {
        try
        {
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Supplier_Wise_Purchase", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@Supplier_ID", SqlDbType.Int);
            cmdEmp.Parameters["@Supplier_ID"].Value = Convert.ToInt32(ddlSupplier.SelectedValue);

            cmdEmp.Parameters.Add("@From_Date", SqlDbType.Date);
            cmdEmp.Parameters["@From_Date"].Value = Convert.ToDateTime(txtFromDate.Text);

            cmdEmp.Parameters.Add("@To_Date", SqlDbType.Date);
            cmdEmp.Parameters["@To_Date"].Value = Convert.ToDateTime(txtToDate.Text);

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