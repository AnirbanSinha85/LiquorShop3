using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Report_Detail_Purchase_Invoice_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    DateTime From_Date, To_Date;
    String s_From_Date, s_To_Date, s_Date;
    int Brand_Id;
    string SQL_QUERY, Brand_Name;
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind_Report();
        view_PurchaseInvoice_print.Text = rpt.ToString();
    }
    private void Bind_Report()
    {
        dt = new DataTable();
        dt = Get_Category_Wise_Quantity();
        if (dt.Rows.Count > 0)
        {
            show_Report();

        }
        else
        {
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);

        }
    }

    public DataTable Get_Category_Wise_Quantity()
    {
        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Purchase_Invoice_Detail", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            //cmdEmp.Parameters.Add("@From_Date", SqlDbType.DateTime);
            //cmdEmp.Parameters["@From_Date"].Value = Convert.ToDateTime(From_Date);

            //cmdEmp.Parameters.Add("@To_Date", SqlDbType.DateTime);
            //cmdEmp.Parameters["@To_Date"].Value = Convert.ToDateTime(To_Date);

            //cmdEmp.Parameters.Add("@Category_Id", SqlDbType.Int);
            //cmdEmp.Parameters["@Category_Id"].Value = Category_Id;

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
        //rpt.AppendFormat("PRODUCT WISE SALE FOR {0} ", s_Date);
        rpt.AppendFormat("<br/><br/>Product Size : ML ");
        #region Detail Section
        rpt.Append("<table class='gridtable' cellspacing='3' cellpadding='4' >");
       

        rpt.Append("<tr>");
        rpt.AppendFormat("<td align='left'>Invoice No</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Purchase_Invoice_NO"]);
        rpt.AppendFormat("<td align='left'>Invoice Date</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>",Convert.ToDateTime(dt.Rows[0]["Purchase_Invoice_Date"]).ToString("dd/MM/yyyy")); 
        rpt.AppendFormat("<td align='left'>Receive Date</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>",Convert.ToDateTime(dt.Rows[0]["Receive_Date"]).ToString("dd/MM/yyyy"));
        rpt.Append("</tr>");

        rpt.Append("<tr>");
      
        rpt.AppendFormat("<td align='left'>Supplier Name</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Supplier_Name"]);
        rpt.AppendFormat("<td align='left'> Supplier Phone No</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Supplier_PhNo"]);
        rpt.AppendFormat("<td align='left'>Supplier Address</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Supplier_Address"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td align='left'>Pass No</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Pass_No"]);
        //rpt.AppendFormat("<td align='left'>Supplier Name</td>");
        //rpt.AppendFormat("<td align='left'>:</td>");
        //rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Purchase_Invoice_Date"]);
        //rpt.AppendFormat("<td align='left'> Supplier Phone No</td>");
        //rpt.AppendFormat("<td align='left'>:</td>");
        //rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Receive_Date"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='9' align='left'></td>");
        //rpt.AppendFormat("<td align='left'>:</td>");
        //rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Purchase_Invoice_NO"]);
        //rpt.AppendFormat("<td align='left'>Supplier Name</td>");
        //rpt.AppendFormat("<td align='left'>:</td>");
        //rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Purchase_Invoice_Date"]);
        //rpt.AppendFormat("<td align='left'> Supplier Phone No</td>");
        //rpt.AppendFormat("<td align='left'>:</td>");
        //rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Receive_Date"]);
        rpt.Append("</tr>");
       
        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='9' align='left'>");

        rpt.Append("<table class='gridtable' cellspacing='3' cellpadding='4' >");
        rpt.Append("<tr>");
        rpt.AppendFormat("<td align='left'>Category </td>");
        rpt.AppendFormat("<td align='left'>Brand </td>");
        rpt.AppendFormat("<td align='left'>Size </td>");
        rpt.AppendFormat("<td align='left'>Product Name </td>");
        rpt.AppendFormat("<td align='left'>Batch No </td>");
        rpt.AppendFormat("<td align='left'>Quantity (PCS.) </td>");
        rpt.AppendFormat("<td align='right'>Rate </td>");
        rpt.AppendFormat("<td align='left'>Discount Per Case </td>");
        rpt.AppendFormat("<td align='left'>Quantity (CASE) </td>");
        rpt.AppendFormat("<td align='left'>Rate Per Case </td>");
        rpt.AppendFormat("<td align='right'>Amount </td>");
        rpt.Append("</tr>");
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            rpt.Append("<tr>");
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Category_Name"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Brand_Name"]);            
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Size_Name"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Batch_No"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Quantity_In_Pce"]);
            rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[i]["Rate"]);
            rpt.AppendFormat("<td align='left'></td>");//discount per case
            //rpt.AppendFormat("<td   align='left'>{0}</td>", dt.Rows[i]["750 ML"]);
            rpt.AppendFormat("<td   align='left'>{0}</td>", dt.Rows[i]["Quantity_In_Box"]);
            //rpt.AppendFormat("<td   align='left'>{0}</td>", dt.Rows[i]["1000 ML 12p"]);
            rpt.AppendFormat("<td align='left'></td>");//rate per case
            rpt.AppendFormat("<td   align='right'>{0}</td>", dt.Rows[i]["Amount"]);
            rpt.Append("</tr>");
        }

        rpt.Append("</table>");
        rpt.AppendFormat("</td>");
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'>Gross Total</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Receive_Date"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'>Standard Rebate</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Receive_Date"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'>Sales Tax</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Sales_Tax_Percent"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'>Discount</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Discount"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'> IC</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["IC"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'>TCS</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["TCS"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'> Grand Total</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Receive_Date"]);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='6'></td>");
        rpt.AppendFormat("<td align='left'>Net Payble Amount</td>");
        rpt.AppendFormat("<td align='left'>:</td>");
        rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["Receive_Date"]);
        rpt.Append("</tr>");
        rpt.Append("</table>");

        //rpt.AppendFormat("<td  align='right'>{0}</td>", ((string.IsNullOrEmpty(dt.Rows[i]["180 ML"].ToString())) ? "0" : dt.Rows[i]["180 ML"])); //string answer = ( (five==5) ? ("true") : ("false") );
        #endregion
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {

    }
}