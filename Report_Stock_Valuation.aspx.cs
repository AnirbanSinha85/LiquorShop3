using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;


public partial class Report_Stock_Valuation : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    DateTime From_Date, To_Date;
    String s_From_Date, s_To_Date, s_Date;
    string SQL_QUERY;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            //gvStockValuation.DataSource = Get_Brand_Wise_Sale_Value();
            //gvStockValuation.DataBind();
        }
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        //From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        //To_Date = Convert.ToDateTime(Request.QueryString["todt"]);

        //s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");
        //Bind_Report();
        //view_Stock_Valuation.Text = rpt.ToString();
        //gvStockValuation.DataSource = Get_Brand_Wise_Sale_Value();
        //gvStockValuation.DataBind();

        Response.Redirect("Report_Stock_Valuation_Print.aspx?fmdt="+txtFromDate.Text);
    }

    private void Bind_Report()
    {
        dt = new DataTable();
        dt = Get_Brand_Wise_Sale_Value();
        if (dt.Rows.Count > 0)
        {
            show_Report();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);

        }
    }
    public DataTable Get_Brand_Wise_Sale_Value()
    {

        try
        {
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Stock_Valuation", con);
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
    private void show_Report()
    {
        decimal total_amount;
        total_amount = 0;
        string Product;
       // rpt.AppendFormat("BRAND WISE SALE VALUATION FOR {0} ", s_Date);

        rpt.Append("<div id=wrapper>");
        rpt.Append("<div id=test>");
       
        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' class='gridtable'>");
        rpt.Append("<tr>");
        rpt.AppendFormat("<td style='width:55%' align='left'>Product Name </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>Size </td>");
        rpt.AppendFormat("<td style='width:15%' align='right'>Stock </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>MRP </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>Amount </td>");
        rpt.Append("</tr>");
        rpt.Append("</table>");

        rpt.Append("</div>");
        

        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' class='gridtable'>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            //Product = Convert.ToString(dt.Rows[i]["Product_Name"]) + "  " + Convert.ToString(dt.Rows[i]["Brand_Name"]);
            rpt.Append("<tr>");
            rpt.AppendFormat("<td style='width:55%' align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["Size_Name"]);
            rpt.AppendFormat("<td style='width:15%' align='right'>{0}</td>", dt.Rows[i]["Stock"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["MRP"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["Stock_Valuation"]);
            rpt.Append("</tr>");
            total_amount = total_amount + Convert.ToDecimal(dt.Rows[i]["Stock_Valuation"]);
        }
        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='3'> </td>");
        rpt.AppendFormat("<td align='right'> TOTAL SALE :  </td>");
        rpt.AppendFormat("<td align='right'>{0}</td>", total_amount);
        rpt.Append("</tr>");

        rpt.Append("</table>");
        rpt.Append("</div>");
    }
    protected void gvStockValuation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStockValuation.PageIndex = e.NewPageIndex;
        gvStockValuation.DataSource = Get_Brand_Wise_Sale_Value();
        gvStockValuation.DataBind();
    }
}