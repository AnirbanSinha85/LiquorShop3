using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Report_Product_Wise_Purchase : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            Bind_Product();
            ddlProduct.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlProduct.Items.Insert(1, new ListItem("All","All"));
        }
    }

    protected void Bind_Product()
    {
        DataTable dt = Get_Product();
        ddlProduct.DataSource = dt;
        ddlProduct.DataTextField = "Product_Name";
        //ddlBrand.DataValueField = "Brand_ID";
        ddlProduct.DataBind();


    }
    public DataTable Get_Product()
    {
        try
        {
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product", con);
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
        string p_name;
        p_name = ddlProduct.SelectedItem.ToString().Trim();

        Bind_Purchase_Invoice(p_name);

    }

    protected void Bind_Purchase_Invoice(string p_name)
    {

        DataTable dt = Get_Purchase_Invoice(p_name);

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

    public DataTable Get_Purchase_Invoice(string p_name)
    {
        try
        {
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Wise_Purchase_Invoice", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@P_Name", SqlDbType.VarChar, 30);
            cmdEmp.Parameters["@P_Name"].Value = p_name;
            cmdEmp.Parameters.Add("@From_Date", SqlDbType.Date);
            cmdEmp.Parameters["@From_Date"].Value = txtFromDate.Text;
            cmdEmp.Parameters.Add("@To_Date", SqlDbType.Date);
            cmdEmp.Parameters["@To_Date"].Value = txtToDate.Text;

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
        Response.Redirect("Report_Product_Wise_Purchase_Print.aspx?fmdt=" + txtFromDate.Text + "&todt=" + txtToDate.Text + "&Pname=" + ddlProduct.SelectedItem);
    }
}