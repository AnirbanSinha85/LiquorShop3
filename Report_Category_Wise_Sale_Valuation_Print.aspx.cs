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


public partial class Report_Category_Wise_Quantity_Sale_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    DateTime From_Date, To_Date;
    String s_From_Date, s_To_Date, s_Date;
    int Category_Id;
    string SQL_QUERY, Category_Name;

    protected void Page_Load(object sender, EventArgs e)
    {
        From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        To_Date = Convert.ToDateTime(Request.QueryString["todt"]);
        Category_Id = Convert.ToInt32(Request.QueryString["cid"]);
        Category_Name = Convert.ToString(Request.QueryString["cname"]);
        s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");
        Bind_Report();
        view_Category_Wise_Quantity_Sale_print.Text = rpt.ToString();
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);

        }
    }

    public DataTable Get_Category_Wise_Quantity()
    {
        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Category_Wise_Quantity", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@From_Date", SqlDbType.DateTime);
            cmdEmp.Parameters["@From_Date"].Value = Convert.ToDateTime(From_Date);

            cmdEmp.Parameters.Add("@To_Date", SqlDbType.DateTime);
            cmdEmp.Parameters["@To_Date"].Value = Convert.ToDateTime(To_Date);

            cmdEmp.Parameters.Add("@Category_Id", SqlDbType.Int);
            cmdEmp.Parameters["@Category_Id"].Value = Category_Id;

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
        double Grand_Total;
        double ML_180 = 0, Total_180_ML = 0;
        double ML_275 = 0, Total_275_ML = 0;
        double ML_330 = 0, Total_330_ML = 0;
        double ML_375 = 0, Total_375_ML = 0;
        double ML_500 = 0, Total_500_ML = 0;
        double ML_650 = 0, Total_650_ML = 0;
        double ML_750 = 0, Total_750_ML = 0;
        double ML_1000 = 0, Total_1000_ML = 0;
        double ML_1000_12p = 0, Total_1000_ML_12p = 0;
        double ML_2000 = 0, Total_2000_ML = 0;

        double Grand_Total_Price, Gross_Total_price = 0; ;
        double ML_180_Price = 0, Total_180_ML_Price = 0;
        double ML_275_Price = 0, Total_275_ML_Price = 0;
        double ML_330_Price = 0, Total_330_ML_Price = 0;
        double ML_375_Price = 0, Total_375_ML_Price = 0;
        double ML_500_Price = 0, Total_500_ML_Price = 0;
        double ML_650_Price = 0, Total_650_ML_Price = 0;
        double ML_750_Price = 0, Total_750_ML_Price = 0;
        double ML_1000_Price = 0, Total_1000_ML_Price = 0;
        double ML_1000_12p_Price = 0, Total_1000_ML_12p_Price = 0;
        double ML_2000_Price = 0, Total_2000_ML_Price = 0;

        rpt.AppendFormat("CATEGORY WISE SALE VALUATION FOR {0} ", s_Date);
        rpt.AppendFormat("<br/><br/>Category Name : {0} Size : ML ", Category_Name);

        rpt.Append("<table class='gridtable' cellspacing='3' cellpadding='4' >");

        rpt.Append("<tr>");

        rpt.AppendFormat("<td align='left'>Product Name </td>");
        rpt.AppendFormat("<td align='right'>180 ML </td>");
        rpt.AppendFormat("<td align='right'>275 ML </td>");
        rpt.AppendFormat("<td align='right'>330 ML</td>");
        rpt.AppendFormat("<td align='right'>375 ML </td>");
        rpt.AppendFormat("<td align='right'>500 ML </td>");
        rpt.AppendFormat("<td align='right'>650 ML</td>");
        rpt.AppendFormat("<td align='right'>750 ML </td>");
        rpt.AppendFormat("<td align='right'>1000 ML </td>");
        rpt.AppendFormat("<td align='right'>1000 ML 12p </td>");
        rpt.AppendFormat("<td align='right'>2000 ML </td>");
        rpt.AppendFormat("<td align='right'>Amount </td>");

        rpt.Append("</tr>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (!string.IsNullOrEmpty(dt.Rows[i]["180 ML"].ToString()))
            {
                ML_180 = ML_180 + Convert.ToInt32(dt.Rows[i]["180 ML"]);
                ML_180_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "180 ML", Category_Name);
            }
            else
            {
                ML_180 = ML_180 + 0;
                ML_180_Price = 0;

            }
            Total_180_ML = 180 * ML_180;
            //Total_180_ML_Price = Convert.ToInt32(dt.Rows[i]["180 ML"]) * ML_180_Price;
            Total_180_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["180 ML"].ToString())) ? "0" : dt.Rows[i]["180 ML"])) * ML_180_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["275 ML"].ToString()))
            {
                ML_275 = ML_275 + Convert.ToInt32(dt.Rows[i]["275 ML"]);
                ML_275_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "275 ML", Category_Name);
            }
            else
            {
                ML_275 = ML_275 + 0;
                ML_275_Price = 0;
            }
            Total_275_ML = 275 * ML_275;
            Total_275_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["275 ML"].ToString())) ? "0" : dt.Rows[i]["275 ML"])) * ML_275_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["330 ML"].ToString()))
            {
                ML_330 = ML_330 + Convert.ToInt32(dt.Rows[i]["330 ML"]);
                ML_330_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "330 ML", Category_Name);
            }
            else
            {
                ML_330 = ML_330 + 0;
                ML_330_Price = 0;
            }
            Total_330_ML = 330 * ML_330;
            Total_330_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["330 ML"].ToString())) ? "0" : dt.Rows[i]["330 ML"])) * ML_330_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["375 ML"].ToString()))
            {
                ML_375 = ML_375 + Convert.ToInt32(dt.Rows[i]["375 ML"]);
                ML_375_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "375 ML", Category_Name);
            }
            else
            {
                ML_375 = ML_375 + 0;
                ML_375_Price = 0;
            }
            Total_375_ML = 375 * ML_375;
            Total_375_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["375 ML"].ToString())) ? "0" : dt.Rows[i]["375 ML"])) * ML_375_Price;
            if (!string.IsNullOrEmpty(dt.Rows[i]["500 ML"].ToString()))
            {
                ML_500 = ML_500 + Convert.ToInt32(dt.Rows[i]["500 ML"]);
                ML_500_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "500 ML", Category_Name);
            }
            else
            {
                ML_500 = ML_500 + 0;
                ML_500_Price = 0;
            }
            Total_500_ML = 500 * ML_500;
            Total_500_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["500 ML"].ToString())) ? "0" : dt.Rows[i]["500 ML"])) * ML_500_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["650 ML"].ToString()))
            {
                ML_650 = ML_650 + Convert.ToInt32(dt.Rows[i]["650 ML"]);
                ML_650_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "650 ML", Category_Name);
            }
            else
            {
                ML_650 = ML_650 + 0;
                ML_650_Price = 0;
            }
            Total_650_ML = 650 * ML_650;
            Total_650_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["650 ML"].ToString())) ? "0" : dt.Rows[i]["650 ML"])) * ML_650_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["750 ML"].ToString()))
            {
                ML_750 = ML_750 + Convert.ToInt32(dt.Rows[i]["750 ML"]);
                ML_750_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "750 ML", Category_Name);
            }
            else
            {
                ML_750 = ML_750 + 0;
                ML_750_Price = 0;
            }
            Total_750_ML = 750 * ML_750;
            Total_750_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["750 ML"].ToString())) ? "0" : dt.Rows[i]["750 ML"])) * ML_750_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["1000 ML"].ToString()))
            {
                ML_1000 = ML_1000 + Convert.ToInt32(dt.Rows[i]["1000 ML"]);
                ML_1000_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "1000 ML", Category_Name);
            }
            else
            {
                ML_1000 = ML_1000 + 0;
                ML_1000_Price = 0;
            }
            Total_1000_ML = 1000 * ML_1000;
            Total_1000_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["1000 ML"].ToString())) ? "0" : dt.Rows[i]["1000 ML"])) * ML_1000_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["2000 ML"].ToString()))
            {
                ML_2000 = ML_2000 + Convert.ToInt32(dt.Rows[i]["2000 ML"]);
                ML_2000_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "2000 ML", Category_Name);
            }
            else
            {
                ML_2000 = ML_2000 + 0;
                ML_2000_Price = 0;
            }
            Total_2000_ML = 2000 * ML_2000;
            Total_2000_ML_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["2000 ML"].ToString())) ? "0" : dt.Rows[i]["2000 ML"])) * ML_2000_Price;

            if (!string.IsNullOrEmpty(dt.Rows[i]["1000 ML 12p"].ToString()))
            {
                ML_1000_12p = ML_1000_12p + Convert.ToInt32(dt.Rows[i]["1000 ML 12p"]);
                ML_1000_12p_Price = Get_MRP_By_Category_Name(Convert.ToString(dt.Rows[i]["Product_Name"]), "1000 ML 12p", Category_Name);
            }
            else
            {
                ML_1000_12p = ML_1000_12p + 0;
                ML_1000_12p_Price = 0;
            }
            Total_1000_ML_12p = 180 * ML_1000_12p;
            Total_1000_ML_12p_Price = Convert.ToDouble(((string.IsNullOrEmpty(dt.Rows[i]["1000 ML 12p"].ToString())) ? "0" : dt.Rows[i]["1000 ML 12p"])) * ML_2000_Price;

            Grand_Total_Price = Total_180_ML_Price + Total_275_ML_Price + Total_330_ML_Price + Total_375_ML_Price + Total_500_ML_Price + Total_650_ML_Price + Total_750_ML_Price + Total_1000_ML_Price + Total_1000_ML_12p_Price + Total_2000_ML_Price;
            Gross_Total_price = Gross_Total_price + Grand_Total_Price;
            rpt.Append("<tr>");

            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='left'>{0}</td>", dt.Rows[i]["Product_Name"]);
            rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["180 ML"]);
            //rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", ((string.IsNullOrEmpty(dt.Rows[i]["180 ML"].ToString())) ? "0" : dt.Rows[i]["180 ML"])); //string answer = ( (five==5) ? ("true") : ("false") );
            rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["275 ML"]);
            rpt.AppendFormat("<td style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["330 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["375 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["500 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["650 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["750 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["1000 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["1000 ML 12p"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", dt.Rows[i]["2000 ML"]);
            rpt.AppendFormat("<td  style='border-right-style: dotted; border-right-width: 1px;border-bottom-style: dotted; border-bottom-width: 1px;' align='right'>{0}</td>", Grand_Total_Price);
            rpt.Append("</tr>");

        }
        Grand_Total = (Total_180_ML + Total_275_ML + Total_330_ML + Total_375_ML + Total_500_ML + Total_650_ML + Total_750_ML + Total_1000_ML + Total_1000_ML_12p + Total_2000_ML) / 1000;

        rpt.Append("<tr >");
        rpt.AppendFormat("<td colspan='10'> </td>");
        rpt.AppendFormat("<td align='right' > TOTAL AMOUNT :  </td>");
        rpt.AppendFormat("<td align='right'>{0}</td>", Gross_Total_price);
        rpt.Append("</tr>");

        rpt.Append("</table>");
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Category_Wise_Quantity_Sale.aspx");
    }

    public int Get_MRP_By_Category_Name(string Product_Name, string Size_Name, string Category_Name)
    {
        int MRP = 0;
        DataTable dt = new DataTable();
        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_MRP_By_Category_Name", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@Product_Name", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@Product_Name"].Value = Product_Name;

            cmdEmp.Parameters.Add("@Size_Name", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@Size_Name"].Value = Size_Name;

            cmdEmp.Parameters.Add("@Category_Name", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@Category_Name"].Value = Category_Name;

            SqlDataAdapter da = new SqlDataAdapter();

            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.SelectCommand = cmdEmp;
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();

        }

        return Convert.ToInt32(dt.Rows[0]["MRP"]);
    }
}