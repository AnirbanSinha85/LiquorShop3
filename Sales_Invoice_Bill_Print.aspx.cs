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
public partial class Admin_Sales_Invoice_Bill_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;

    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);

    int Bill_No;

    protected void Page_Load(object sender, EventArgs e)
    {
        Bill_No = Convert.ToInt32(Request.QueryString["Bno"]);
        Bind_Report();
        view_Sales_Invoice_print.Text = rpt.ToString();
    }
    private void Bind_Report()
    {
        dt = new DataTable();
        dt = Get_Sales_Invoice();
        if (dt.Rows.Count > 0)
        {
            show_Report();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);
            // Response.Redirect("VichleWiseMovement_Report.aspx");
        }


    }
    public DataTable Get_Sales_Invoice()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Sales_Invoice", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@Bill_No", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@Bill_No"].Value = Convert.ToInt32(Bill_No);

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
        rpt.Append("<table width='58%'  cellspacing='3' cellpadding='4' style='border-style: dotted; border-width: 1px; border-color: inherit; font-family: SimSun-ExtB; font-size: x-small;'>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td  colspan='5' style='border-bottom-style: dotted; border-bottom-width: 1px' align='left'>Bill No : {0} </td>", Bill_No);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td  width='33%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='left'>Particulars </td>");
        rpt.AppendFormat("<td width='3%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='right'>Qty. </td>");
        rpt.AppendFormat("<td width='5%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='right'>MRP </td>");
        rpt.AppendFormat("<td width='7%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px' align='right'>Size </td>");
        rpt.AppendFormat("<td width='10%' style='border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>Amount </td>");
        rpt.Append("</tr>");

        DateTime Sale_date = DateTime.Now.Date;
        int k = 0;
        int Page_no = 0;
        int flag = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
             
            rpt.Append("<tr>");

            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px' align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px' align='right'>{0}</td>", dt.Rows[i]["Sales_Qty"]);
            rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px' align='right'>{0}</td>", dt.Rows[i]["MRP"]);
            rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px' align='right'>{0}</td>", dt.Rows[i]["Size_Name"]);
            rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[i]["Amount"]);
            rpt.Append("</tr>");
            total_amount = total_amount + Convert.ToDecimal(dt.Rows[i]["Amount"]);
            Sale_date = Convert.ToDateTime(dt.Rows[i]["Bill_Date"]);

            k++;
            if (k > 13)
            {
                k = 0;
                
                Page_no++;
                rpt.Append("</table>");
                rpt.Append("<Br class=page />");
                rpt.Append("<table width='50%'  cellspacing='3' cellpadding='4' style='border-style: dotted; border-width: 1px; border-color: inherit; font-family: SimSun-ExtB; font-size: x-small;'>");
                rpt.Append("<tr>");
                rpt.AppendFormat("<td width='29%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='left'>Particulars </td>");
                rpt.AppendFormat("<td width='3%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='right'>Qty. </td>");
                rpt.AppendFormat("<td width='5%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='right'>MRP </td>");
                rpt.AppendFormat("<td width='5%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px' align='right'>Size </td>");
                rpt.AppendFormat("<td width='8%' style='border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>Amount </td>");
                rpt.Append("</tr>");
            }
            if (Page_no > 0)
            {
                if (dt.Rows.Count-i<12)
                {
                    flag = 1;
                    if (flag == 0)
                    {
                        rpt.Append("</table>");
                        rpt.Append("<Br class=page />");
                        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' style='border-style: dotted; border-width: 1px; border-color: inherit; font-family: SimSun-ExtB; font-size: small;'>");
                        rpt.Append("<tr>");
                        rpt.AppendFormat("<td width='29%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='left'>Particulars </td>");
                        rpt.AppendFormat("<td width='3%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='right'>Qty. </td>");
                        rpt.AppendFormat("<td width='5%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px; ' align='right'>MRP </td>");
                        rpt.AppendFormat("<td width='5%' style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px' align='right'>Size </td>");
                        rpt.AppendFormat("<td width='8%' style='border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>Amount </td>");
                        rpt.Append("</tr>");
                    }
                }
            }
        }

      
        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='3' style='  border-top-style: dotted;   border-top-width: 1px;'> Date :  {0}</td>", Sale_date.ToString("MM/dd/yyyy"));
        rpt.AppendFormat("<td   style='  border-top-style: dotted;   border-top-width: 1px;' align='right' > Total :  </td>");
        rpt.AppendFormat("<td style='border-top-style: dotted;   border-top-width: 1px;' align='right'>{0}</td>", total_amount);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='5' style='border-top-style: dotted;border-top-width: 1px;' align='left' >Signature : </td>");
        rpt.Append("</tr>");

        rpt.Append("</table>");
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create_New_Sales_Invoice.aspx");
    }
}