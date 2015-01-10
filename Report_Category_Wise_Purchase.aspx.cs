using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Report_Category_Wise_Purchase : System.Web.UI.Page
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
        //Response.Redirect("Report_Category_Wise_Purchase_Print.aspx?fmdt=" + txtFromDate.Text + "&todt=" + txtToDate.Text + "&cid=" + ddlCategory.SelectedValue + "&cname=" + ddlCategory.SelectedItem);

        int cid;
        cid = Convert.ToInt32(ddlCategory.SelectedValue);
        Bind_Purchase_Invoice(cid);
    }

    protected void Bind_Purchase_Invoice(int cid)
    {

        DataTable dt = Get_Purchase_Invoice(cid);
        decimal gross_total, standard_rebate, total_standard_rebate;
        gross_total = 0;
        total_standard_rebate = 0;
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    gross_total = gross_total + Convert.ToDecimal(dt.Rows[i]["Amount"]);
        //    standard_rebate = ((Convert.ToDecimal(dt.Rows[i]["Standerd_Rebet"])) * (Convert.ToDecimal(dt.Rows[i]["Quantity_In_Box"])));
        //    total_standard_rebate = total_standard_rebate + standard_rebate;
        //}
        //lblGrossTotal.Text = gross_total.ToString();
        //lblStandardRebate.Text = total_standard_rebate.ToString();


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

    public DataTable Get_Purchase_Invoice(int bid)
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Category_Wise_Purchase_Invoice", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;


            cmdEmp.Parameters.Add("@Category_ID", SqlDbType.Int);
            cmdEmp.Parameters["@Category_ID"].Value = bid;
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

}