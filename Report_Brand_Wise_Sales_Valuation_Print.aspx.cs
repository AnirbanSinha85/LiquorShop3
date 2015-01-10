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

public partial class Report_Brand_Wise_Sales_Valuation_Print : System.Web.UI.Page
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
        From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        To_Date = Convert.ToDateTime(Request.QueryString["todt"]);

        s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");
        Bind_Report();
        view_Brand_Wise_Bill_print.Text = rpt.ToString();

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
            SQL_QUERY = "SELECT     dbo.Sales_Invoice_Detail.MRP, SUM(dbo.Sales_Invoice_Detail.Sales_Qty) AS Total_Sales, ";
            SQL_QUERY += "dbo.Product_Detail.Product_Name, dbo.Product_Brand.Brand_Name,dbo.Product_Size.Size_Name,dbo.Product_Size.Size_In_ML,";
            SQL_QUERY += "SUM(dbo.Sales_Invoice_Detail.Sales_Qty)* dbo.Sales_Invoice_Detail.MRP as Amount ";
            SQL_QUERY += "FROM dbo.Sales_Invoice_Detail INNER JOIN ";
            SQL_QUERY += "dbo.Product_Detail ON dbo.Sales_Invoice_Detail.Product_ID = dbo.Product_Detail.Product_ID INNER JOIN ";
            SQL_QUERY += "dbo.Product_Brand ON dbo.Product_Detail.Brand_ID = dbo.Product_Brand.Brand_ID INNER JOIN ";
            SQL_QUERY += "dbo.Product_Size ON dbo.Sales_Invoice_Detail.Size_ID = dbo.Product_Size.Size_ID ";
            SQL_QUERY += "WHERE  dbo.Sales_Invoice_Detail.Bill_Date BETWEEN '" + From_Date + "' AND '" + To_Date + "' ";
            SQL_QUERY += "GROUP BY dbo.Sales_Invoice_Detail.MRP, dbo.Product_Detail.Product_Name, dbo.Product_Brand.Brand_Name, dbo.Product_Size.Size_Name,dbo.Product_Size.Size_In_ML ";
            //SQL_QUERY += "ORDER BY dbo.Product_Size.Size_In_ML desc, dbo.Product_Detail.Product_Name ";
            SQL_QUERY += "ORDER BY  dbo.Product_Brand.Brand_Name, dbo.Product_Detail.Product_Name,dbo.Product_Size.Size_In_ML desc ";

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
    private void show_Report()
    {
        decimal total_amount;
        total_amount = 0;
        string Product;

        rpt.Append("<div style='width:100%;position:fixed; top:0px; background-color:#ACD3FB;color: #000000; font-weight: bold; '>");
        rpt.AppendFormat("BRAND WISE SALE VALUATION FOR {0} ", s_Date);
        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' >");

        rpt.Append("<tr>");

        rpt.AppendFormat("<td style='width:55%' align='left'>Product Name </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>Size </td>");
        rpt.AppendFormat("<td style='width:15%' align='right'>Total Sales </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>MRP </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>Amount </td>");

        rpt.Append("</tr>");
        rpt.Append("</table>");
        rpt.Append("</div>");
        //rpt.Append("<div style='width:99%;top:200px;'>");
        
        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' class='gridtable'>");

        //rpt.Append("<tr>");

        //rpt.AppendFormat("<td style='width:55%;position:fixed;' align='left'>Product Name </td>");
        //rpt.AppendFormat("<td style='width:10%;position:fixed;' align='right'>Size </td>");
        //rpt.AppendFormat("<td style='width:15%;' align='right'>Total Sales </td>");
        //rpt.AppendFormat("<td style='width:10%;  ' align='right'>MRP </td>");
        //rpt.AppendFormat("<td style='width:10%;' align='right'>Amount </td>");

        //rpt.Append("</tr>");
        int k = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            Product = Convert.ToString(dt.Rows[i]["Product_Name"]) + "  " + Convert.ToString(dt.Rows[i]["Brand_Name"]);
            rpt.Append("<tr>");
            rpt.AppendFormat("<td style='width:55%' align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["Size_Name"]);
            rpt.AppendFormat("<td style='width:15%' align='right'>{0}</td>", dt.Rows[i]["Total_Sales"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["MRP"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["Amount"]);
            rpt.Append("</tr>");
            total_amount = total_amount + Convert.ToDecimal(dt.Rows[i]["Amount"]);

            //k++;
            //if (k > 30)
            //{
            //    k = 0;
            //    rpt.Append("</table>");
            //    rpt.Append("<Br class=page />");
            //    rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4'  class='gridtable'>");
            //    rpt.Append("<tr>");
            //    rpt.AppendFormat("<td style='width:55%' align='left'>Product Name </td>");
            //    rpt.AppendFormat("<td style='width:10%' align='right'>Size </td>");
            //    rpt.AppendFormat("<td style='width:15%' align='right'>Total Sales </td>");
            //    rpt.AppendFormat("<td style='width:10%' align='right'>MRP </td>");
            //    rpt.AppendFormat("<td style='width:10%' align='right'>Amount </td>");
            //    rpt.Append("</tr>");
            //}
        }
        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='3'> </td>");
        rpt.AppendFormat("<td align='right'> TOTAL SALE :  </td>");
        rpt.AppendFormat("<td align='right'>{0}</td>", total_amount);
        rpt.Append("</tr>");

        rpt.Append("</table>");
        //rpt.Append("</div>");
    }

    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Brand_Wise_Sales_Valuation.aspx");
    }
}