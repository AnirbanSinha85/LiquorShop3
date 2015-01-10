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


public partial class Report_Product_Wise_Detail_Stock_Print : System.Web.UI.Page
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
        From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        s_Date = From_Date.ToString("dd/MM/yyyy");
        Bind_Report();
        view_Product_Wise_Stock_print.Text = rpt.ToString();


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
            
            SQL_QUERY = "SELECT dbo.Product_Detail.Product_Name, dbo.Product_Size.Size_Name, dbo.Product_Detail.Product_ID, dbo.Product_Detail.Avalable_Quantity, ";
            SQL_QUERY += "dbo.Product_Brand.Brand_Name FROM dbo.Product_Detail INNER JOIN ";
            SQL_QUERY += "dbo.Product_Brand ON dbo.Product_Detail.Brand_ID = dbo.Product_Brand.Brand_ID INNER JOIN Product_Category ON dbo.Product_Detail.Category_ID=Product_Category.Category_ID ";
            SQL_QUERY += "INNER JOIN dbo.Product_Size ON dbo.Product_Detail.Size_ID = dbo.Product_Size.Size_ID ";
            SQL_QUERY += "ORDER BY dbo.Product_Brand.Brand_Name,Product_Category.Category_Name,dbo.Product_Detail.Product_Name,dbo.Product_Size.Size_In_ML desc ";

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

        //rpt.Append("<div style='width:90%;position:fixed; top:0px; background-color:#ACD3FB;color: #000000; font-weight: bold;'>");
        //rpt.AppendFormat("PRODUCT WISE DETAIL STOCK AS ON {0} ", s_Date);
        //rpt.Append("<table width='90%'  cellspacing='3' cellpadding='4' style='font-size:small'  >");
        //rpt.Append("<tr>");
        //rpt.AppendFormat("<td style='width:47%' align='left'>PRODUCT NAME </td>");
        //rpt.AppendFormat("<td style='width:10%' align='right'>PACK </td>");
        //rpt.AppendFormat("<td style='width:7%' align='right'>OPENING </td>");
        //rpt.AppendFormat("<td style='width:8%' align='right'>PURCHASE </td>");
        //rpt.AppendFormat("<td style='width:5%' align='right'>TOTAL </td>");
        //rpt.AppendFormat("<td style='width:5%' align='right'>SALE </td>");
        //rpt.AppendFormat("<td style='width:5%' align='right'>B.S.L </td>");
        //rpt.AppendFormat("<td style='width:5%' align='right'>TOTAL </td>");
        //rpt.AppendFormat("<td style='width:8%' align='right'>BALANCE </td>");
        //rpt.Append("</tr>");
        //rpt.Append("</table>");
        //rpt.Append("</div>");
        //rpt.Append("<br/><br/><br/>");
        rpt.Append("<table width='90%'  cellspacing='3' cellpadding='4' class='gridtable'>");
        rpt.Append("<thead style='width:90%'>");
        rpt.Append("<tr>");
        rpt.AppendFormat("<td style='width:47%' align='left'>PRODUCT NAME </td>");
        rpt.AppendFormat("<td style='width:10%' align='right'>PACK </td>");
        rpt.AppendFormat("<td style='width:7%' align='right'>OPENING </td>");
        rpt.AppendFormat("<td style='width:8%' align='right'>PURCHASE </td>");
        rpt.AppendFormat("<td style='width:5%' align='right'>TOTAL </td>");
        rpt.AppendFormat("<td style='width:5%' align='right'>SALE </td>");
        rpt.AppendFormat("<td style='width:5%' align='right'>B.S.L </td>");
        rpt.AppendFormat("<td style='width:5%' align='right'>TOTAL </td>");
        rpt.AppendFormat("<td style='width:8%' align='right'>BALANCE </td>");
        rpt.Append("</tr>");
        rpt.Append("</thead>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            #region OLD SALES
            con.Open();

            SQL_QUERY = "SELECT Product_ID ,SUM(Sales_Qty) AS Total_Sales_Qty FROM dbo.Sales_Invoice_Detail ";
            SQL_QUERY += "WHERE Bill_Date <= '" + Convert.ToDateTime(From_Date).AddDays(-1) + "' AND Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += "GROUP BY Product_ID ";
            SQL_QUERY += "";

            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt_Old_Sales_qty = new DataTable();
            dt_Old_Sales_qty.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.SelectCommand = cmdEmp;
            da.Fill(dt_Old_Sales_qty);
            con.Close();
          
            int Old_Sales_qty;
            if (dt_Old_Sales_qty.Rows.Count > 0)
            {
                Old_Sales_qty = Convert.ToInt32(dt_Old_Sales_qty.Rows[0]["Total_Sales_Qty"]);
            }
            else
            {
                Old_Sales_qty = 0;
            }
            #endregion

            #region OLD Purchse
            //----------------------Prchase Invoice OLD ---------------------------
            con.Open();

            SQL_QUERY = "SELECT  dbo.Purchase_Invoice.Product_ID, SUM(dbo.Purchase_Invoice.Quantity_In_Box) AS Total_Box, ";
            SQL_QUERY += "SUM(dbo.Purchase_Invoice.Quantity_In_Pce) AS Total_Pce, dbo.Product_Size.Pcs_In_Box, ";
            SQL_QUERY += "((SUM(dbo.Purchase_Invoice.Quantity_In_Box)*dbo.Product_Size.Pcs_In_Box)+SUM(dbo.Purchase_Invoice.Quantity_In_Pce)) as Old_Total_Purchase ";
            SQL_QUERY += "FROM dbo.Purchase_Invoice INNER JOIN dbo.Product_Size ON dbo.Purchase_Invoice.Size_ID = dbo.Product_Size.Size_ID ";
            SQL_QUERY += "WHERE dbo.Purchase_Invoice.Purchase_Invoice_Date<= '" + Convert.ToDateTime(From_Date).AddDays(-1) + "' AND  dbo.Purchase_Invoice.Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += " GROUP BY  dbo.Purchase_Invoice.Product_ID, dbo.Product_Size.Pcs_In_Box ";


            SqlCommand cmd_Old_Total_Purchase = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da_Old_Total_Purchase = new SqlDataAdapter();
            DataTable dt_Old_Total_Purchase = new DataTable();
            dt_Old_Total_Purchase.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da_Old_Total_Purchase.SelectCommand = cmd_Old_Total_Purchase;
            da_Old_Total_Purchase.Fill(dt_Old_Total_Purchase);
            con.Close();
            int Old_Total_Purchase = 0;

            if (dt_Old_Total_Purchase.Rows.Count > 0)
            {
                Old_Total_Purchase = Convert.ToInt32(dt_Old_Total_Purchase.Rows[0]["Old_Total_Purchase"]);
            }
            else
            {
                Old_Total_Purchase = 0;
            }

            //----------------------End----------------------------------------
            #endregion

            #region Old Claim
            //----------------------OLD Claim ---------------------------
            con.Open();

            SQL_QUERY = "SELECT  Product_ID,SUM(Clain_Qty) as Old_Total_Claim_Qty FROM Claim  ";
            SQL_QUERY += "WHERE Claim_Date <= '" + Convert.ToDateTime(From_Date).AddDays(-1) + "' AND Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += "GROUP BY Product_ID ";

            SqlCommand cmd_Old_Total_Claim = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da_Old_Total_Claim = new SqlDataAdapter();
            DataTable dt_Old_Total_Claim = new DataTable();
            dt_Old_Total_Claim.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da_Old_Total_Claim.SelectCommand = cmd_Old_Total_Claim;
            da_Old_Total_Claim.Fill(dt_Old_Total_Claim);
            con.Close();
            int Old_Total_Claim = 0;

            if (dt_Old_Total_Claim.Rows.Count > 0)
            {
                Old_Total_Claim = Convert.ToInt32(dt_Old_Total_Claim.Rows[0]["Old_Total_Claim_Qty"]);
            }
            else
            {
                Old_Total_Claim = 0;
            }

            //----------------------End----------------------------------------
            #endregion

            int O_Balance = 0;
            O_Balance = ((Convert.ToInt32(dt.Rows[i]["Avalable_Quantity"]) + Old_Total_Purchase) - Old_Sales_qty) - Old_Total_Claim;

            #region Today Purchase
            //----------------------Prchase Invoice TO DAY ---------------------------
            con.Open();

            SQL_QUERY = "SELECT dbo.Purchase_Invoice.Purchase_Invoice_Date, dbo.Purchase_Invoice.Product_ID, SUM(dbo.Purchase_Invoice.Quantity_In_Box) AS Total_Box, ";
            SQL_QUERY += "SUM(dbo.Purchase_Invoice.Quantity_In_Pce) AS Total_Pce, dbo.Product_Size.Pcs_In_Box, ";
            SQL_QUERY += "((SUM(dbo.Purchase_Invoice.Quantity_In_Box)*dbo.Product_Size.Pcs_In_Box)+SUM(dbo.Purchase_Invoice.Quantity_In_Pce)) as Today_Total_Purchase ";
            SQL_QUERY += "FROM dbo.Purchase_Invoice INNER JOIN dbo.Product_Size ON dbo.Purchase_Invoice.Size_ID = dbo.Product_Size.Size_ID ";
            SQL_QUERY += "WHERE dbo.Purchase_Invoice.Purchase_Invoice_Date = '" + Convert.ToDateTime(From_Date) + "' AND  dbo.Purchase_Invoice.Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += "GROUP BY dbo.Purchase_Invoice.Purchase_Invoice_Date, dbo.Purchase_Invoice.Product_ID, dbo.Product_Size.Pcs_In_Box ";


            SqlCommand cmd_Today_Total_Purchase = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da_Today_Total_Purchase = new SqlDataAdapter();
            DataTable dt_Today_Total_Purchase = new DataTable();
            dt_Today_Total_Purchase.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da_Today_Total_Purchase.SelectCommand = cmd_Today_Total_Purchase;
            da_Today_Total_Purchase.Fill(dt_Today_Total_Purchase);
            con.Close();
            int Today_Total_Purchase = 0;

            if (dt_Today_Total_Purchase.Rows.Count > 0)
            {
                Today_Total_Purchase = Convert.ToInt32(dt_Today_Total_Purchase.Rows[0]["Today_Total_Purchase"]);
            }
            else
            {
                Today_Total_Purchase = 0;
            }

            //----------------------End----------------------------------------
            #endregion

           
            int Total_Openning_Purchase = 0;
            Total_Openning_Purchase = Today_Total_Purchase + O_Balance;

            #region Today Sale
            //--------------------To Day Sale---------------------------

            con.Open();

            SQL_QUERY = "SELECT Product_ID ,SUM(Sales_Qty) AS Today_Total_Sales_Qty FROM dbo.Sales_Invoice_Detail ";
            SQL_QUERY += "WHERE Bill_Date = '" + Convert.ToDateTime(From_Date) + "' AND Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += "GROUP BY Product_ID ";
            SQL_QUERY += "";

            SqlCommand cmdSale = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter daSale = new SqlDataAdapter();
            DataTable dt_Today_Sales_qty = new DataTable();
            dt_Today_Sales_qty.Locale = System.Globalization.CultureInfo.InvariantCulture;
            daSale.SelectCommand = cmdSale;
            daSale.Fill(dt_Today_Sales_qty);
            con.Close();
            int ToDay_Total_Sales_Qty=0;
            if (dt_Today_Sales_qty.Rows.Count > 0)
            {
                ToDay_Total_Sales_Qty = Convert.ToInt32(dt_Today_Sales_qty.Rows[0]["Today_Total_Sales_Qty"]);
            }
            else
            {
                ToDay_Total_Sales_Qty = 0;
            }
            #endregion

            #region Today Claim
            
           
            //----------------------Today Claim ---------------------------
            con.Open();

            SQL_QUERY = "SELECT  Product_ID,SUM(Clain_Qty) as ToDay_Total_Claim_Qty FROM Claim  ";
            SQL_QUERY += "WHERE Claim_Date = '" + Convert.ToDateTime(From_Date) + "' AND Product_ID=" + dt.Rows[i]["Product_ID"];
            SQL_QUERY += "GROUP BY Product_ID ";

            SqlCommand cmd_ToDay_Total_Claim = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da_ToDay_Total_Claim = new SqlDataAdapter();
            DataTable dt_ToDay_Total_Claim = new DataTable();
            dt_ToDay_Total_Claim.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da_ToDay_Total_Claim.SelectCommand = cmd_ToDay_Total_Claim;
            da_ToDay_Total_Claim.Fill(dt_ToDay_Total_Claim);
            con.Close();
            int ToDay_Total_Claim = 0;

            if (dt_ToDay_Total_Claim.Rows.Count > 0)
            {
                ToDay_Total_Claim = Convert.ToInt32(dt_ToDay_Total_Claim.Rows[0]["ToDay_Total_Claim_Qty"]);
            }
            else
            {
                ToDay_Total_Claim = 0;
            }

            //----------------------End----------------------------------------
            #endregion


            //int bsl = 0;

            int Total_BSL_Sales=0;

            Total_BSL_Sales = ToDay_Total_Sales_Qty + ToDay_Total_Claim;

            int Current_Stock=0;
            Current_Stock = Total_Openning_Purchase - Total_BSL_Sales;
            rpt.Append("<tbody>");
            rpt.Append("<tr>");
            rpt.AppendFormat("<td style='width:47%' align='left' >{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='width:10%' align='right' >{0}</td>", dt.Rows[i]["Size_Name"]);
            rpt.AppendFormat("<td style='width:7%' align='right' >{0}</td>", O_Balance);
            rpt.AppendFormat("<td style='width:8%' align='right' >{0}</td>", Today_Total_Purchase);
            rpt.AppendFormat("<td style='width:5%' align='right' >{0}</td>", Total_Openning_Purchase);
            rpt.AppendFormat("<td style='width:5%' align='right' >{0}</td>", ToDay_Total_Sales_Qty);
            rpt.AppendFormat("<td style='width:5%' align='right' >{0}</td>", ToDay_Total_Claim);
            rpt.AppendFormat("<td style='width:5%' align='right' >{0}</td>", Total_BSL_Sales);
            rpt.AppendFormat("<td style='width:8%' align='right' >{0}</td>", Current_Stock);
            rpt.Append("</tr>");
            rpt.Append("</tbody>");



          
        }
        rpt.Append("</table>");
    }
    
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Product_Wise_Detail_Stock.aspx");
    }
}