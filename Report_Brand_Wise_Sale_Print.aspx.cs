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

public partial class Report_Brand_Wise_Sale_Print : System.Web.UI.Page
{
    StringBuilder rpt = new StringBuilder();
    DataTable dt;
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    DateTime From_Date, To_Date;
    String s_From_Date, s_To_Date, s_Date;
    int Brand_Id;
    string SQL_QUERY,Brand_Name;

    protected void Page_Load(object sender, EventArgs e)
    {
        From_Date = Convert.ToDateTime(Request.QueryString["fmdt"]);
        To_Date = Convert.ToDateTime(Request.QueryString["todt"]);
        Brand_Id = Convert.ToInt32(Request.QueryString["bid"]);
        Brand_Name = Convert.ToString(Request.QueryString["bname"]);
        s_Date = From_Date.ToString("MM/dd/yyyy") + " To " + To_Date.ToString("MM/dd/yyyy");
        Bind_Report();
        view_Brand_Wise_Sale_print.Text = rpt.ToString();
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

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Brand_Wise_Sale", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

            cmdEmp.Parameters.Add("@From_Date", SqlDbType.DateTime);
            cmdEmp.Parameters["@From_Date"].Value = Convert.ToDateTime(From_Date);

            cmdEmp.Parameters.Add("@To_Date", SqlDbType.DateTime);
            cmdEmp.Parameters["@To_Date"].Value = Convert.ToDateTime(To_Date);

            cmdEmp.Parameters.Add("@Brand_Id", SqlDbType.Int);
            cmdEmp.Parameters["@Brand_Id"].Value = Brand_Id;

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

     

        rpt.AppendFormat("BRAND WISE SALE FOR {0} ", s_Date);
        rpt.AppendFormat("<br/><br/>Brand Name : {0} Size : ML ", Brand_Name);
        //rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' style='font-family:verdana;border-right-style: dotted; border-bottom-style: dotted; border-left-style: dotted; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-top-width: 1px; border-top-style: dotted; font-size:medium;'>");
        rpt.Append("<table width='100%'  cellspacing='3' cellpadding='4' style='border-style: dotted; border-width: 1px; border-color: inherit; font-family: SimSun-ExtB; font-size: small;'>");

        rpt.Append("<tr>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='left'>Product Name </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>180 ML </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>275 ML </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold;'   align='right'>330 ML</td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>375 ML </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>500 ML </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold;'   align='right'>650 ML</td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>750 ML </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>1000 ML </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold;'   align='right'>1000 ML 12p </td>");
        rpt.AppendFormat("<td style='border-bottom-style: dotted; border-bottom-width: 1px; border-right-style: dotted; border-right-width: 1px;font-weight:bold; ' align='right'>2000 ML </td>");
        rpt.Append("</tr>");


        for (int i = 0; i < dt.Rows.Count; i++)
        {
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
            rpt.Append("</tr>");

            if (!string.IsNullOrEmpty(dt.Rows[i]["180 ML"].ToString()))
            {
                ML_180 = ML_180 + Convert.ToInt32(dt.Rows[i]["180 ML"]);
                
               
            }
            else
            {
                ML_180 = ML_180 + 0;
                
               
            }
            Total_180_ML = 180 * ML_180;
          
            if (!string.IsNullOrEmpty(dt.Rows[i]["275 ML"].ToString()))
            {
                ML_275 = ML_275 + Convert.ToInt32(dt.Rows[i]["275 ML"]);
                
            }
            else
            {
                ML_275 = ML_275 + 0;
               
            }
            Total_275_ML = 275 * ML_275;

            if (!string.IsNullOrEmpty(dt.Rows[i]["330 ML"].ToString()))
            {
                ML_330 = ML_330 + Convert.ToInt32(dt.Rows[i]["330 ML"]);
            }
            else
            {
                ML_330 = ML_330 + 0;
            }
            Total_330_ML = 330 * ML_330;

            if (!string.IsNullOrEmpty(dt.Rows[i]["375 ML"].ToString()))
            {
                ML_375 = ML_375 + Convert.ToInt32(dt.Rows[i]["375 ML"]);
            }
            else
            {
                ML_375 = ML_375 + 0;
            }
            Total_375_ML = 375 * ML_375;

            if (!string.IsNullOrEmpty(dt.Rows[i]["500 ML"].ToString()))
            {
                ML_500 = ML_500 + Convert.ToInt32(dt.Rows[i]["500 ML"]);
            }
            else
            {
                ML_500 = ML_500 + 0;
            }
            Total_500_ML = 500 * ML_500;

            if (!string.IsNullOrEmpty(dt.Rows[i]["650 ML"].ToString()))
            {
                ML_650 = ML_650 + Convert.ToInt32(dt.Rows[i]["650 ML"]);
            }
            else
            {
                ML_650 = ML_650 + 0;
            }
            Total_650_ML = 650 * ML_650;

            if (!string.IsNullOrEmpty(dt.Rows[i]["750 ML"].ToString()))
            {
                ML_750 = ML_750 + Convert.ToInt32(dt.Rows[i]["750 ML"]);
            }
            else
            {
                ML_750 = ML_750 + 0;
            }
            Total_750_ML = 750 * ML_750;

            if (!string.IsNullOrEmpty(dt.Rows[i]["1000 ML"].ToString()))
            {
                ML_1000 = ML_1000 + Convert.ToInt32(dt.Rows[i]["1000 ML"]);
            }
            else
            {
                ML_1000 = ML_1000 + 0;
            }
            Total_1000_ML = 1000 * ML_1000;

            if (!string.IsNullOrEmpty(dt.Rows[i]["2000 ML"].ToString()))
            {
                ML_2000 = ML_2000 + Convert.ToInt32(dt.Rows[i]["2000 ML"]);
            }
            else
            {
                ML_2000 = ML_2000 + 0;
            }
            Total_2000_ML = 2000 * ML_2000;

            if (!string.IsNullOrEmpty(dt.Rows[i]["1000 ML 12p"].ToString()))
            {
                ML_1000_12p = ML_1000_12p + Convert.ToInt32(dt.Rows[i]["1000 ML 12p"]);
            }
            else
            {
                ML_1000_12p = ML_1000_12p + 0;
            }
            Total_1000_ML_12p= 180 * ML_1000_12p;


           

        }
        Grand_Total = (Total_180_ML + Total_275_ML + Total_330_ML + Total_375_ML + Total_500_ML + Total_650_ML + Total_750_ML + Total_1000_ML + Total_1000_ML_12p + Total_2000_ML) / 1000;

        rpt.Append("<tr >");
        rpt.AppendFormat("<td colspan='9' style='  border-top-style: dotted;   border-top-width: 1px;'> </td>");
        rpt.AppendFormat("<td   style='  border-top-style: dotted;   border-top-width: 1px;' align='right' > TOTAL Liter :  </td>");
        rpt.AppendFormat("<td style='border-top-style: dotted;   border-top-width: 1px;' align='right'>{0}</td>", Grand_Total);
        rpt.Append("</tr>");
        rpt.Append("</table>");
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Brand_Wise_Sale.aspx");
    }

    //public int Get_MRP_By_Pname(string Product_Name, string Size_Name, string Brand_Name)
    //{
    //    int MRP = 0;
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        con.Open();

    //        SqlCommand cmdEmp = new SqlCommand("sp_Get_MRP_By_Pname", con);
    //        cmdEmp.CommandType = CommandType.StoredProcedure;

    //        cmdEmp.Parameters.Add("@Product_Name", SqlDbType.VarChar, 50);
    //        cmdEmp.Parameters["@Product_Name"].Value = Product_Name;

    //        cmdEmp.Parameters.Add("@Size_Name", SqlDbType.VarChar, 50);
    //        cmdEmp.Parameters["@Size_Name"].Value = Size_Name;

    //        cmdEmp.Parameters.Add("@Brand_Name", SqlDbType.VarChar, 50);
    //        cmdEmp.Parameters["@Brand_Name"].Value = Brand_Name;

    //        SqlDataAdapter da = new SqlDataAdapter();
           
    //        dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
    //        da.SelectCommand = cmdEmp;
    //        da.Fill(dt);

           
             
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();

    //    }


    //    return Convert.ToInt32(dt.Rows[0]["MRP"]);
















         


    //}

}