using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_View_Purchase_Invoice : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    int Delete_Flag, Created_By, Modified_By, Gender, rt;
    DateTime DOB, DOC, DOM;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }

         if (!IsPostBack)
         {
             Bind_Purchase_Invoice();
         }

    }
    protected void Bind_Purchase_Invoice()
    {
        DataTable dt = Get_Purchase_Invoice();
        gvPurcase_Invoice_View.DataSource = dt;
        
        gvPurcase_Invoice_View.DataBind();
    }


    public DataTable Get_Purchase_Invoice()
    {

        try
        {
            con.Open();

            string SQL_QUERY;

            SQL_QUERY = "SELECT Purchase_Invoice.Purchase_Invoice_NO ,Purchase_Invoice_Date,SUM(Amount) as GROSS_TOTAL, ";
            SQL_QUERY += "SUM(Purchase_Invoice_Payment_amount) Paid_Amount, ";
            SQL_QUERY += "SUM(Amount)-SUM(Purchase_Invoice_Payment_amount) as Due_Amount,dbo.[User].User_Name ";
            SQL_QUERY += "FROM Purchase_Invoice INNER JOIN Purchase_Invoice_Payment ON ";
            SQL_QUERY += "Purchase_Invoice.Purchase_Invoice_NO = Purchase_Invoice_Payment.Purchase_Invoice_NO ";
            SQL_QUERY += "INNER JOIN  dbo.[User] ON dbo.Purchase_Invoice_Payment.Modify_By = dbo.[User].User_ID ";
            SQL_QUERY += "GROUP BY Purchase_Invoice.Purchase_Invoice_NO ,Purchase_Invoice_Date,dbo.[User].User_Name";
             
            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
          

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
           
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

    protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        this.ModalPopupExtender1.Show();
    }
    
}