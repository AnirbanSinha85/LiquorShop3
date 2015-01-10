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

public partial class Report_Stock_Valuation_Print : System.Web.UI.Page
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
        s_Date = From_Date.ToString("dd/MM/yyyy");// +" To " + To_Date.ToString("MM/dd/yyyy");
        Bind_Report();
        view_Stock_Valuation_print.Text = rpt.ToString();
    }

    private void Bind_Report()
    {
        dt = new DataTable();
        dt = Get_Product_Detail();
        if (dt.Rows.Count > 0)
        {
            show_Report();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);

        }
    }

    public DataTable Get_Product_Detail()
    {

        try
        {
            con.Open();

            SQL_QUERY += "SELECT dbo.Product_Detail.Product_Name, dbo.Product_Size.Size_Name, dbo.Product_Detail.Product_ID, dbo.Product_Detail.Avalable_Quantity, ";
            SQL_QUERY += "dbo.Product_Brand.Brand_Name,Product_Detail.MRP FROM dbo.Product_Detail INNER JOIN ";
            SQL_QUERY += "dbo.Product_Brand ON dbo.Product_Detail.Brand_ID = dbo.Product_Brand.Brand_ID INNER JOIN ";
            SQL_QUERY += "dbo.Product_Size ON dbo.Product_Detail.Size_ID = dbo.Product_Size.Size_ID ";
            SQL_QUERY += "ORDER BY dbo.Product_Brand.Brand_Name,dbo.Product_Detail.Product_Name,dbo.Product_Size.Size_In_ML desc ";

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
        rpt.AppendFormat("PRODUCT WISE STOCK VALUATION AS ON {0} ", s_Date);

        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' class='gridtable'>");
        rpt.Append("<thead style='width:100%;'>");
        rpt.Append("<tr style='width:100%;'>");
        rpt.AppendFormat("<td style='width:55%;' align='left'>Product Name </td>");
        rpt.AppendFormat("<td style='width:10%;' align='right'>Size </td>");
        rpt.AppendFormat("<td style='width:15%;' align='right'>Stock </td>");
        rpt.AppendFormat("<td style='width:10%;' align='right'>MRP </td>");
        rpt.AppendFormat("<td style='width:10%;' align='right'>Amount </td>");
        rpt.Append("</tr>");
        rpt.Append("</thead>");

        rpt.Append("<tbody>");
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            #region Total Sales

            con.Open();
            SQL_QUERY = "SELECT Product_ID ,SUM(Sales_Qty) AS Total_Sales_Qty FROM dbo.Sales_Invoice_Detail ";
            SQL_QUERY += "WHERE Bill_Date <= '" + Convert.ToDateTime(From_Date) + "' AND Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += "GROUP BY Product_ID ";

            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt_Sales_qty = new DataTable();
            dt_Sales_qty.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.SelectCommand = cmdEmp;
            da.Fill(dt_Sales_qty);
            con.Close();

            int Sales_qty;
            if (dt_Sales_qty.Rows.Count > 0)
            {
                Sales_qty = Convert.ToInt32(dt_Sales_qty.Rows[0]["Total_Sales_Qty"]);
            }
            else
            {
                Sales_qty = 0;
            }
            #endregion

            #region Total Purchase


            //----------------------Prchase Invoice  ---------------------------
            con.Open();

            SQL_QUERY = "SELECT  dbo.Purchase_Invoice.Product_ID, SUM(dbo.Purchase_Invoice.Quantity_In_Box) AS Total_Box, ";
            SQL_QUERY += "SUM(dbo.Purchase_Invoice.Quantity_In_Pce) AS Total_Pce, dbo.Product_Size.Pcs_In_Box, ";
            SQL_QUERY += "((SUM(dbo.Purchase_Invoice.Quantity_In_Box)*dbo.Product_Size.Pcs_In_Box)+SUM(dbo.Purchase_Invoice.Quantity_In_Pce)) as Old_Total_Purchase ";
            SQL_QUERY += "FROM dbo.Purchase_Invoice INNER JOIN dbo.Product_Size ON dbo.Purchase_Invoice.Size_ID = dbo.Product_Size.Size_ID ";
            SQL_QUERY += "WHERE dbo.Purchase_Invoice.Purchase_Invoice_Date<= '" + Convert.ToDateTime(From_Date) + "' AND  dbo.Purchase_Invoice.Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += " GROUP BY  dbo.Purchase_Invoice.Product_ID, dbo.Product_Size.Pcs_In_Box ";


            SqlCommand cmd_Old_Total_Purchase = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da_Old_Total_Purchase = new SqlDataAdapter();
            DataTable dt_Total_Purchase = new DataTable();
            dt_Total_Purchase.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da_Old_Total_Purchase.SelectCommand = cmd_Old_Total_Purchase;
            da_Old_Total_Purchase.Fill(dt_Total_Purchase);
            con.Close();
            int Total_Purchase = 0;

            if (dt_Total_Purchase.Rows.Count > 0)
            {
                Total_Purchase = Convert.ToInt32(dt_Total_Purchase.Rows[0]["Old_Total_Purchase"]);
            }
            else
            {
                Total_Purchase = 0;
            }

            //----------------------End----------------------------------------
            #endregion

            int Total_Stock;
            Total_Stock = (Total_Purchase + Convert.ToInt32(dt.Rows[i]["Avalable_Quantity"])) - Sales_qty;
            double Stock_Valuation;
            Stock_Valuation = Total_Stock * Convert.ToDouble(dt.Rows[i]["MRP"]);

            rpt.Append("<tr>");
            rpt.AppendFormat("<td style='width:55%' align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["Size_Name"]);
            rpt.AppendFormat("<td style='width:15%' align='right'>{0}</td>", Total_Stock);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", dt.Rows[i]["MRP"]);
            rpt.AppendFormat("<td style='width:10%' align='right'>{0}</td>", Stock_Valuation);
            rpt.Append("</tr>");
            total_amount = total_amount + Convert.ToDecimal(Stock_Valuation);
        }
      

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='3'> </td>");
        rpt.AppendFormat("<td align='right'> TOTAL STOCK VALUE :  </td>");
        rpt.AppendFormat("<td align='right'>{0}</td>", total_amount);
        rpt.Append("</tr>");
  rpt.Append("</tbody>");
        rpt.Append("</table>");
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Stock_Valuation.aspx");
    }
}