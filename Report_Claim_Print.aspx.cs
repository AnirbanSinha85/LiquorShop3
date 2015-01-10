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

public partial class Report_Claim_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);

    DateTime From_Date, To_Date;
    String s_From_Date, s_To_Date, s_Date;
    protected void Page_Load(object sender, EventArgs e)
    {
        From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        To_Date = Convert.ToDateTime(Request.QueryString["todt"]);
        s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");
        Bind_Report();
        view_Claim_print.Text = rpt.ToString();
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Claim.aspx");
    }
    private void Bind_Report()
    {
        dt = new DataTable();
        dt = Get_All_Claim();
        if (dt.Rows.Count > 0)
        {
            show_Report();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);
        }
    }
    public DataTable Get_All_Claim()
    {
        try
        {
            string Sql_Query;
            con.Open();
            Sql_Query = "SELECT dbo.Product_Brand.Brand_Name, dbo.Product_Category.Category_Name, dbo.Product_Detail.Product_Name, dbo.Product_Size.Size_Name, ";
            Sql_Query += "dbo.Claim.Claim_Date,dbo.Claim.Clain_Qty, dbo.Claim.Product_ID ";
            Sql_Query += "FROM dbo.Product_Size INNER JOIN dbo.Product_Brand INNER JOIN dbo.Claim INNER JOIN ";
            Sql_Query += "dbo.Product_Detail ON dbo.Claim.Product_ID = dbo.Product_Detail.Product_ID INNER JOIN ";
            Sql_Query += "dbo.Product_Category ON dbo.Product_Detail.Category_ID = dbo.Product_Category.Category_ID ON ";
            Sql_Query += "dbo.Product_Brand.Brand_ID = dbo.Product_Detail.Brand_ID ON dbo.Product_Size.Size_ID = dbo.Product_Detail.Size_ID ";
            Sql_Query += "WHERE Claim_Date BETWEEN '" + Convert.ToDateTime(From_Date) + "' AND '" + Convert.ToDateTime(To_Date)+"' "; 
            SqlCommand cmdEmp = new SqlCommand(Sql_Query, con);
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
        rpt.Append("<table width='100%' class='gridtable' cellspacing='3' cellpadding='4' >");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td  colspan='7' align='left'>CLAIM REPORT : {0}</td>", s_Date);
        rpt.Append("</tr>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td align='left'>Product ID</td>");
        rpt.AppendFormat("<td align='left'>Brand Name</td>");
        rpt.AppendFormat("<td align='left'>Category Name</td>");
        rpt.AppendFormat("<td align='left'>Product Name</td>");
        rpt.AppendFormat("<td align='left'>Size Name</td>");
        rpt.AppendFormat("<td align='left'>Claim Date </td>");
        rpt.AppendFormat("<td align='right'>Clain Qty </td>");
        rpt.Append("</tr>");
        
        DateTime Claim_date = DateTime.Now.Date;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            rpt.Append("<tr>");

            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Product_ID"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Brand_Name"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Category_Name"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Size_Name"]);
            Claim_date = Convert.ToDateTime(dt.Rows[i]["Claim_Date"]);
            rpt.AppendFormat("<td align='left'>{0}</td>", Claim_date.ToString("MM/dd/yyyy"));
            rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[i]["Clain_Qty"]);
            rpt.Append("</tr>");
        }
       
        rpt.Append("</table>");
    }
}