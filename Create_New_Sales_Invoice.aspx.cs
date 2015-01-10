using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Admin_Create_New_Sales_Invoice : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);
    int Delete_Flag, Created_By, Modified_By, rt;
    DateTime DOC, DOM;
    decimal total = 0, totalml = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }

        Bind_Bill_No();
        txtBarCode.Focus();
        if (!IsPostBack)
        {
            Bind_Sales_Invoice();
            txtQty.Text = "1";

            DateTime Sale_date;
            Sale_date = System.DateTime.Now.Date;
            txtSalesDate.Text = Sale_date.ToString("MM/dd/yyyy");
        }
    }

    protected void txtBarCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            #region OLDCODE
            //con.Open();
            //SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Detail_By_Barcode", con);
            //cmdEmp.CommandType = CommandType.StoredProcedure;
            //cmdEmp.Parameters.Add("@Bar_Code", SqlDbType.VarChar, 50).Value = Convert.ToString(txtBarCode.Text).Trim();
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //da.SelectCommand = cmdEmp;
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    txtP_Name.Text = dt.Rows[0]["Product_Name"].ToString();
            //    lblp_id.Text = dt.Rows[0]["Product_ID"].ToString();

            //    txtB_Name.Text = dt.Rows[0]["Brand_Name"].ToString();
            //    lblb_id.Text = dt.Rows[0]["Brand_ID"].ToString();

            //    txtMRP.Text = dt.Rows[0]["MRP"].ToString();

            //    txtSize.Text = dt.Rows[0]["Size_Name"].ToString();
            //    lblSize_id.Text = dt.Rows[0]["Size_ID"].ToString();

            //    Delete_Flag = 0;

            //    DOC = Convert.ToDateTime(System.DateTime.Now);
            //    DOM = Convert.ToDateTime(System.DateTime.Now);
            //    Created_By = Convert.ToInt32(Session["User_ID"]);
            //    Modified_By = Convert.ToInt32(Session["User_ID"]);
            //    rt = Insert_Sales_Invoice();
            //    if (rt == 11)
            //    {
            //        Bind_Sales_Invoice();
            //        txtBarCode.Text = "";
            //        txtBarCode.Focus();
            //        txtQty.Text = "1";
            //        txtBatch.Text = "";
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);
            //    txtP_Name.Text = "";
            //    lblp_id.Text = "";
            //    txtB_Name.Text = "";
            //    lblb_id.Text = "";
            //    txtMRP.Text = "";
            //    txtSize.Text = "";
            //    lblSize_id.Text = "";
            //    txtBarCode.Text = "";
            //    txtBatch.Text = "";
            //}

            #endregion

            Created_By = Convert.ToInt32(Session["User_ID"]);
            Modified_By = Convert.ToInt32(Session["User_ID"]);
            Delete_Flag = 0;
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Insert_Sales_Invoice_Detail", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;
            cmdEmp.Parameters.Add("@Bill_No", SqlDbType.VarChar, 50).Value = Convert.ToInt32(lblBillNo.Text);
            cmdEmp.Parameters.Add("@Bar_Code", SqlDbType.VarChar, 50).Value = Convert.ToString(txtBarCode.Text).Trim();
            cmdEmp.Parameters.Add("@Sales_Qty", SqlDbType.Int).Value = Convert.ToInt32(txtQty.Text);
            cmdEmp.Parameters.Add("@Bill_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(txtSalesDate.Text);
            cmdEmp.Parameters.Add("@Batch_No", SqlDbType.VarChar, 50).Value = txtBatch.Text;
            cmdEmp.Parameters.Add("@Delete_Flag", SqlDbType.Int).Value = Delete_Flag;
            cmdEmp.Parameters.Add("@Created_By", SqlDbType.Int).Value = Created_By;
            cmdEmp.Parameters.Add("@Modified_By", SqlDbType.Int).Value = Modified_By;
            cmdEmp.Parameters.Add("@rtn", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmdEmp.ExecuteNonQuery();
            int rt = Convert.ToInt32(cmdEmp.Parameters["@rtn"].Value);
            if (rt == 11)
            {
                Bind_Sales_Invoice();
                txtBarCode.Text = "";
                txtBarCode.Focus();
                txtQty.Text = "1";
                txtBatch.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('No Data Found');", true);
                txtBarCode.Text = "";
                txtBatch.Text = "";
            }
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

    protected void Bind_Sales_Invoice()
    {
        try
        {
            DataTable dt = Get_Sales_Invoice();
            if (dt.Rows.Count > 0)
            {
                gvSalesInvoice.DataSource = dt;
                gvSalesInvoice.DataBind();
            }
            else
            {
                gvSalesInvoice.DataSource = dt;
                gvSalesInvoice.DataBind();
            }
        }
        catch (Exception ex)
        {

        }


    }

    public DataTable Get_Sales_Invoice()
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmdEmp = new SqlCommand("sp_Get_Sales_Invoice", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;
            cmdEmp.Parameters.Add("@Bill_No", SqlDbType.VarChar, 50).Value = Convert.ToInt32(lblBillNo.Text);
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

    protected void cmdPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sales_Invoice_Bill_Print.aspx?Bno=" + lblBillNo.Text);
    }

    protected void Bind_Bill_No()
    {
        try
        {
            DataTable dt = Get_Bill_No();
            if (dt.Rows.Count > 0)
            {
                lblBillNo.Text = dt.Rows[0]["Bill_No"].ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    private string GetNextValue(string s)
    {
        return String.Format("{0:D6}", Convert.ToInt32(s.Substring(3)) + 1);
    }

    public DataTable Get_Bill_No()
    {
        string SQL_QUERY;
        try
        {
            con.Open();
            SQL_QUERY = "select max(Bill_No)+1 as Bill_No from Bill_No";
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

    protected void gvSalesInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                totalml += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ML"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblamount = (Label)e.Row.FindControl("lblTotal");
                Label lblTotalML = (Label)e.Row.FindControl("lblTotalML");
                lblamount.Text = total.ToString();
                decimal lt;
                lt = Convert.ToDecimal(totalml) / 1000;
                lblTotalML.Text = lt.ToString() + " LT ";
                if (lt > 36)//Check 36 liter
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('You Sale Maximum 36 Liter Against a Bill.');", true);
                    //rt = Insert_New_Bill_No();
                    //if (rt == 11)
                    //{
                    //    Bind_Bill_No();
                    //    txtBarCode.Text = "";
                    //    txtBarCode.Focus();
                    //    Bind_Sales_Invoice();
                    //}
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void cmdNewBill_Click(object sender, EventArgs e)
    {
        try
        {
            DOC = Convert.ToDateTime(System.DateTime.Now);
            DOM = Convert.ToDateTime(System.DateTime.Now);
            Created_By = Convert.ToInt32(Session["User_ID"]);
            Modified_By = Convert.ToInt32(Session["User_ID"]);

            rt = Insert_New_Bill_No();
            if (rt == 11)
            {
                Bind_Bill_No();
                txtBarCode.Text = "";
                txtBarCode.Focus();
                Bind_Sales_Invoice();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('There are no record agains this bill.');", true);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected int Insert_New_Bill_No()
    {
        DOC = Convert.ToDateTime(System.DateTime.Now);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Created_By = Convert.ToInt32(Session["User_ID"]);
        Modified_By = Convert.ToInt32(Session["User_ID"]);
        SqlCommand cmdEmp = new SqlCommand();
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmdEmp = new SqlCommand("sp_Insert_New_Bill_No", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;
            cmdEmp.Parameters.Add("@Bill_No", SqlDbType.VarChar, 50).Value = Convert.ToInt32(lblBillNo.Text);
            cmdEmp.Parameters.Add("@DOC", SqlDbType.DateTime).Value = Convert.ToDateTime(DOC);
            cmdEmp.Parameters.Add("@Created_By", SqlDbType.Int).Value = Created_By;
            cmdEmp.Parameters.Add("@DOM", SqlDbType.DateTime).Value = Convert.ToDateTime(DOM);
            cmdEmp.Parameters.Add("@Modified_By", SqlDbType.Int).Value = Modified_By;
            cmdEmp.Parameters.Add("@rtn", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmdEmp.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return Convert.ToInt32(cmdEmp.Parameters["@rtn"].Value);
    }

    protected void gvSalesInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int Sales_Invoice_ID = Convert.ToInt32(gvSalesInvoice.DataKeys[e.RowIndex].Values["Sales_Invoice_ID"].ToString());
            DOM = Convert.ToDateTime(System.DateTime.Now);
            Modified_By = Convert.ToInt32(Session["User_ID"]);
            string SQL_QUERY;
            SQL_QUERY = "DELETE FROM Sales_Invoice_Detail WHERE Sales_Invoice_ID=" + Sales_Invoice_ID;
            con.Open();
            SqlCommand cmd = new SqlCommand(SQL_QUERY, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Bind_Sales_Invoice();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
}