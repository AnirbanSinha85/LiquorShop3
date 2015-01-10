using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Report_Product_Wise_Purchase_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    DateTime From_Date, To_Date;
    String s_Date;

    string Product_Name;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["First_Name"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
            To_Date = Convert.ToDateTime(Request.QueryString["todt"]);
            Product_Name = Convert.ToString(Request.QueryString["Pname"]);
            s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");

            Bind_Purchase_Invoice(Product_Name, From_Date, To_Date);
            view_Product_Wise_Purchase_print.Text = rpt.ToString();
           // Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:Print();", true);
        }
        catch (Exception ex)
        {
        }
    }

    protected void Bind_Purchase_Invoice(string p_name, DateTime From_Date, DateTime To_Date)
    {
        dt = new DataTable();
        dt = Get_Purchase_Invoice(p_name, From_Date, To_Date);
        if (dt.Rows.Count > 0)
        {
            show_Report();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);
        }
    }

    public DataTable Get_Purchase_Invoice(string p_name, DateTime From_Date, DateTime To_Date)
    {
        try
        {
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Wise_Purchase_Invoice", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;
            cmdEmp.Parameters.Add("@P_Name", SqlDbType.VarChar, 30).Value = p_name;
            cmdEmp.Parameters.Add("@From_Date", SqlDbType.Date).Value = From_Date;
            cmdEmp.Parameters.Add("@To_Date", SqlDbType.Date).Value = To_Date;
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

    protected void cmdBack_Click(object sender, EventArgs e)
    {

    }

    void show_Report()
    {
       // rpt.AppendFormat("PRODUCT WISE DETAIL STOCK AS ON {0} ", s_Date);
        rpt.Append("<table width='90%'  cellspacing='3' cellpadding='4' class='gridtable'>");
        rpt.Append("<thead style='width:90%'>");
        rpt.Append("<tr>");
        rpt.AppendFormat("<td colspan='9'>PRODUCT WISE DETAIL STOCK AS ON {0}  </td>", s_Date);

        //rpt.AppendFormat("PRODUCT WISE DETAIL STOCK AS ON {0} ", s_Date);
        rpt.Append("</tr>");
        rpt.Append("<tr>");
        //rpt.AppendFormat("<td style='width:4%'  align='left' >Category </td>");
        //rpt.AppendFormat("<td style='width:10%'  align='left' >Brand </td>");
        //rpt.AppendFormat("<td style='width:8%'  align='right'>Size </td>");
        //rpt.AppendFormat("<td style='width:20%' align='left' >Product </td>");
        //rpt.AppendFormat("<td style='width:6%'  align='left' >Batch No </td>");
        //rpt.AppendFormat("<td style='width:7%'  align='right'>Qty.(PCS.)</td>");
        //rpt.AppendFormat("<td style='width:7%'  align='right'>Qty.(CASE)</td>");
        //rpt.AppendFormat("<td style='width:10%'  align='right'>Purchase Date </td>");
        //rpt.AppendFormat("<td style='width:8%'  align='right'>Rate </td>");
        //rpt.AppendFormat("<td style='width:10%'  align='right'>Dis. Per Case </td>");
        //rpt.AppendFormat("<td style='width:8%'  align='right'>Amount </td>");
        rpt.AppendFormat("<td style='width:10%'  align='left'>Purchase Date </td>");
        rpt.AppendFormat("<td style='width:20%' align='left' >Product </td>");
        rpt.AppendFormat("<td style='width:6%'  align='left' >Batch No </td>");
        rpt.AppendFormat("<td style='width:6%'  align='left' >Pass No </td>");
        rpt.AppendFormat("<td style='width:20%' align='left' >Supplier Name </td>");
        rpt.AppendFormat("<td style='width:7%'  align='right'>Qty.(PCS.)</td>");
        rpt.AppendFormat("<td style='width:7%'  align='right'>Qty.(CASE)</td>");
        rpt.AppendFormat("<td style='width:8%'  align='right'>Amount </td>");
        rpt.Append("</tr>");
        rpt.Append("</thead>");
        rpt.Append("<tbody>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
           
            rpt.Append("<tr>");
            //rpt.AppendFormat("<td style='width:4%'   align='left' >{0}</td>", dt.Rows[i]["Category_Name"]);
            //rpt.AppendFormat("<td style='width:10%'   align='left' >{0}</td>", dt.Rows[i]["Brand_Name"]);
            //rpt.AppendFormat("<td style='width:8%'   align='right'>{0}</td>", dt.Rows[i]["Size_Name"]);
            //rpt.AppendFormat("<td style='width:20%'' align='left' >{0}</td>", dt.Rows[i]["Product_Name"]);
            //rpt.AppendFormat("<td style='width:6%'   align='left' >{0}</td>", dt.Rows[i]["Batch_No"]);
            //rpt.AppendFormat("<td style='width:7%'   align='right' >{0}</td>", dt.Rows[i]["Quantity_In_Pce"]);
            //rpt.AppendFormat("<td style='width:7%'   align='right' >{0}</td>", dt.Rows[i]["Quantity_In_Box"]);
            //rpt.AppendFormat("<td style='width:10%'  align='right' >{0}</td>", Convert.ToDateTime(dt.Rows[i]["Purchase_Invoice_Date"]).ToString("dd/MM/yyyy"));
            //rpt.AppendFormat("<td style='width:8%'   align='right' >{0}</td>", dt.Rows[i]["Rate"]);
            //rpt.AppendFormat("<td style='width:9%'  align='right' >{0}</td>", dt.Rows[i]["Standerd_Rebet"]);
            //rpt.AppendFormat("<td style='width:8%'   align='right' >{0}</td>", dt.Rows[i]["Amount"]);
            rpt.AppendFormat("<td style='width:10%'  align='left' >{0}</td>", Convert.ToDateTime(dt.Rows[i]["Purchase_Invoice_Date"]).ToString("dd/MM/yyyy"));
            rpt.AppendFormat("<td style='width:20%' align='left' >{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='width:6%'  align='left' >{0}</td>", dt.Rows[i]["Batch_No"]);
            rpt.AppendFormat("<td style='width:6%'  align='left' >{0}</td>", dt.Rows[i]["Pass_No"]);
            rpt.AppendFormat("<td style='width:20%' align='left' >{0}</td>", dt.Rows[i]["Supplier_Name"]);
            rpt.AppendFormat("<td style='width:7%'  align='right'>{0}</td>", dt.Rows[i]["Quantity_In_Pce"]);
            rpt.AppendFormat("<td style='width:7%'  align='right'>{0}</td>", dt.Rows[i]["Quantity_In_Box"]);
            rpt.AppendFormat("<td style='width:8%'  align='right'>{0}</td>", dt.Rows[i]["Amount"]);

            rpt.Append("</tr>");
          

        }
        rpt.Append("</tbody>");
        rpt.Append("</table>");
    }
}