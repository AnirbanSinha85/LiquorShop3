using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Admin_Create_New_Purchase_Invoice : System.Web.UI.Page
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
            Bind_Product_Category();
            Bind_Brand();
            Bind_Size();
            //Bind_Product();
            Bind_Supplier();


            Bind_Purchase_Invoice();



            ddlCategory.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlBrand.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlSize.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlProductName.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlSupplier.Items.Insert(0, new ListItem("Select", string.Empty));

            lblStandardRebate.Text = "0.00";
            lblGrossTotal.Text = "0.00";
            lblSTaxAmount.Text = "0.00";
            txtSTaxPercent.Text = "0";
            txtDiscount.Text = "0.00";
            txtIC.Text = "0.00";
            txtTCS.Text = "0.00";
            lblGrandTotal.Text = "0.00";

            /// chkActive.Checked = true;
        }
    }

    protected void Bind_Product()
    {
        DataTable dt = Get_Product();
        ddlProductName.DataSource = dt;
        ddlProductName.DataTextField = "Product_Name";
        ddlProductName.DataValueField = "Product_ID";
        ddlProductName.DataBind();
    }

    public DataTable Get_Product()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Producte", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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

    protected void Bind_Size()
    {
        DataTable dt = Get_Size();
        ddlSize.DataSource = dt;
        ddlSize.DataTextField = "Size_Name";
        ddlSize.DataValueField = "Size_ID";
        ddlSize.DataBind();
    }

    public DataTable Get_Size()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Size", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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

    protected void Bind_Product_Category()
    {
        DataTable dt = Get_Product_Category();
        ddlCategory.DataSource = dt;
        ddlCategory.DataTextField = "Category_Name";
        ddlCategory.DataValueField = "Category_ID";
        ddlCategory.DataBind();
    }

    public DataTable Get_Product_Category()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_Category", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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

    protected void Bind_Brand()
    {
        DataTable dt = Get_Brand();
        ddlBrand.DataSource = dt;
        ddlBrand.DataTextField = "Brand_Name";
        ddlBrand.DataValueField = "Brand_ID";
        ddlBrand.DataBind();
    }

    public DataTable Get_Brand()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Brand", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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

    protected void Bind_Supplier()
    {
        DataTable dt = Get_Supplier();
        ddlSupplier.DataSource = dt;
        ddlSupplier.DataTextField = "Supplier_Name";
        ddlSupplier.DataValueField = "Supplier_ID";
        ddlSupplier.DataBind();
    }

    public DataTable Get_Supplier()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Supplier", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;

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

    protected void cmdAdd_Click(object sender, EventArgs e)
    {
        Delete_Flag = 0;

        DOC = Convert.ToDateTime(System.DateTime.Now);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Created_By = Convert.ToInt32(Session["User_ID"]);
        Modified_By = Convert.ToInt32(Session["User_ID"]);

        rt = Insert_Purchase_Invoice();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            //Clear_All();
            Bind_Purchase_Invoice();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }
    }

    protected int Insert_Purchase_Invoice()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Purchase_Invoice", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Purchase_Invoice_NO", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Purchase_Invoice_NO"].Value = txtInvoiceNo.Text;

        cmdEmp.Parameters.Add("@Purchase_Invoice_Date", SqlDbType.DateTime);
        cmdEmp.Parameters["@Purchase_Invoice_Date"].Value = Convert.ToDateTime(txtInvoiceDate.Text);

        cmdEmp.Parameters.Add("@Receive_Date", SqlDbType.DateTime);
        cmdEmp.Parameters["@Receive_Date"].Value = Convert.ToDateTime(txtReceiveDate.Text);

        cmdEmp.Parameters.Add("@Supplier_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Supplier_ID"].Value = Convert.ToInt32(ddlSupplier.SelectedValue);

        cmdEmp.Parameters.Add("@Category_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Category_ID"].Value = Convert.ToInt32(ddlCategory.SelectedValue);

        cmdEmp.Parameters.Add("@Brand_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Brand_ID"].Value = Convert.ToInt32(ddlBrand.SelectedValue);

        cmdEmp.Parameters.Add("@Product_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Product_ID"].Value = Convert.ToInt32(ddlProductName.SelectedValue);

        cmdEmp.Parameters.Add("@Size_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Size_ID"].Value = Convert.ToInt32(ddlSize.SelectedValue);

        cmdEmp.Parameters.Add("@Quantity_In_Box", SqlDbType.Int);
        cmdEmp.Parameters["@Quantity_In_Box"].Value = Convert.ToInt32(txtQtyInBox.Text);

        cmdEmp.Parameters.Add("@Quantity_In_Pce", SqlDbType.Int);
        cmdEmp.Parameters["@Quantity_In_Pce"].Value = Convert.ToInt32(txtQtyInPce.Text);

        cmdEmp.Parameters.Add("@Rate", SqlDbType.Decimal);
        cmdEmp.Parameters["@Rate"].Value = Convert.ToDecimal(txtRate.Text);

        cmdEmp.Parameters.Add("@Amount", SqlDbType.Decimal);
        cmdEmp.Parameters["@Amount"].Value = Convert.ToDecimal(txtAmount.Text);

        cmdEmp.Parameters.Add("@Batch_No", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Batch_No"].Value = txtBatchNo.Text;



        cmdEmp.Parameters.Add("@Delete_Flag", SqlDbType.Int);
        cmdEmp.Parameters["@Delete_Flag"].Value = Delete_Flag;

        cmdEmp.Parameters.Add("@DOC", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOC"].Value = Convert.ToDateTime(DOC);

        cmdEmp.Parameters.Add("@Created_By", SqlDbType.Int);
        cmdEmp.Parameters["@Created_By"].Value = Created_By;

        cmdEmp.Parameters.Add("@DOM", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOM"].Value = Convert.ToDateTime(DOM);

        cmdEmp.Parameters.Add("@Modified_By", SqlDbType.Int);
        cmdEmp.Parameters["@Modified_By"].Value = Modified_By;


        cmdEmp.Parameters.Add("@rtn", SqlDbType.Int);
        cmdEmp.Parameters["@rtn"].Direction = ParameterDirection.ReturnValue;

        cmdEmp.ExecuteNonQuery();

        con.Close();
        return Convert.ToInt32(cmdEmp.Parameters["@rtn"].Value);


    }

    protected void Bind_Purchase_Invoice()
    {

        DataTable dt = Get_Purchase_Invoice();
        decimal gross_total, standard_rebate, total_standard_rebate;
        gross_total = 0;
        total_standard_rebate = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            gross_total = gross_total + Convert.ToDecimal(dt.Rows[i]["Amount"]);
            standard_rebate = ((Convert.ToDecimal(dt.Rows[i]["Standerd_Rebet"])) * (Convert.ToDecimal(dt.Rows[i]["Quantity_In_Box"])));
            total_standard_rebate = total_standard_rebate + standard_rebate;
        }
        lblGrossTotal.Text = gross_total.ToString();
        lblStandardRebate.Text = total_standard_rebate.ToString();


        if (dt.Rows.Count > 0)
        {
            gvPurcase_Invoice.DataSource = dt;
            gvPurcase_Invoice.DataBind();
        }
        else
        {
            dt.Rows.Add(dt.NewRow());
            gvPurcase_Invoice.DataSource = dt;
            gvPurcase_Invoice.DataBind();
            int columncount = gvPurcase_Invoice.Rows[0].Cells.Count;
            gvPurcase_Invoice.Rows[0].Cells.Clear();
            gvPurcase_Invoice.Rows[0].Cells.Add(new TableCell());
            gvPurcase_Invoice.Rows[0].Cells[0].ColumnSpan = columncount;
            gvPurcase_Invoice.Rows[0].Cells[0].Text = " ";
        }


    }

    public DataTable Get_Purchase_Invoice()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Purchase_Invoice", con);
            cmdEmp.CommandType = CommandType.StoredProcedure;


            cmdEmp.Parameters.Add("@Purchase_Invoice_NO", SqlDbType.VarChar, 50);
            cmdEmp.Parameters["@Purchase_Invoice_NO"].Value = txtInvoiceNo.Text;


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

    protected void Calculate_Grand_Total()
    {
        decimal gross_total, standard_rebate, s_tax, discount, ic, tcs, grand_total;
        if (lblGrossTotal.Text == "0")
        {
            gross_total = 0;
        }
        else
        {
            gross_total = Convert.ToDecimal(lblGrossTotal.Text);
        }
        if (lblStandardRebate.Text == "0")
        {
            standard_rebate = 0;
        }
        else
        {
            standard_rebate = Convert.ToDecimal(lblStandardRebate.Text);
        }

        if (lblSTaxAmount.Text == "0")
        {
            s_tax = 0;
        }
        else
        {
            s_tax = Convert.ToDecimal(lblSTaxAmount.Text);
        }

        if (txtDiscount.Text == "")
        {
            discount = 0;
        }
        else
        {
            discount = Convert.ToDecimal(txtDiscount.Text);
        }

        if (txtIC.Text == "")
        {
            ic = 0;
        }
        else
        {
            ic = Convert.ToDecimal(txtIC.Text);
        }

        if (txtTCS.Text == "")
        {
            tcs = 0;
        }
        else
        {
            tcs = Convert.ToDecimal(txtTCS.Text);
        }


        grand_total = (gross_total + s_tax + ic + tcs) - (discount + standard_rebate);

        lblGrandTotal.Text = grand_total.ToString();

        lblNetPay.Text = Convert.ToInt32(grand_total).ToString();

    }

    protected void txtSTaxPercent_TextChanged(object sender, EventArgs e)
    {
        decimal s_tax_per, s_tax_amount;
        s_tax_per = Convert.ToDecimal(txtSTaxPercent.Text);
        lblSTaxAmount.Text = ((Convert.ToDecimal(lblGrossTotal.Text) * s_tax_per) / 100).ToString();
        Calculate_Grand_Total();
        ScriptManager1.SetFocus(txtDiscount);

    }

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        Calculate_Grand_Total();
        ScriptManager1.SetFocus(txtIC);
    }

    protected void txtIC_TextChanged(object sender, EventArgs e)
    {
        Calculate_Grand_Total();
        ScriptManager1.SetFocus(txtTCS);

    }

    protected void txtTCS_TextChanged(object sender, EventArgs e)
    {
        Calculate_Grand_Total();
    }

    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SQL_QUERY;
        try
        {
            con.Open();
            SQL_QUERY = "Select * from Supplier where Supplier_ID='" + ddlSupplier.SelectedValue + "'";

            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmdEmp;
            da.Fill(dt);
            txtSupplierName.Text = dt.Rows[0]["Supplier_Name"].ToString();
            txtSupplierPhNo.Text = dt.Rows[0]["Supplier_PhNo"].ToString();
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

    protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProductSize_BySize();

        GetProduct_By_Size_Brand();

    }

    private void GetProduct_By_Size_Brand()
    {
        string SQL_QUERY;
        try
        {
            con.Open();

            SQL_QUERY = "Select Product_Name,Product_ID from Product_Detail Where ";
            if (ddlBrand.SelectedIndex != 0)
            {
                SQL_QUERY += "Brand_ID="+ddlBrand.SelectedValue+" AND ";
            }
            if (ddlSize.SelectedIndex != 0)
            {
                SQL_QUERY += "Size_ID="+ddlSize.SelectedValue +" AND ";
            }
            SQL_QUERY += "Delete_Flag <>1 ";


            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmdEmp;
            da.Fill(dt);

            ddlProductName.DataSource = dt;
            ddlProductName.DataTextField = "Product_Name" ;
            ddlProductName.DataValueField = "Product_ID";
            ddlProductName.DataBind();

            ddlProductName.Items.Insert(0, new ListItem("Select", string.Empty));
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

    private void GetProductSize_BySize()
    {
        string SQL_QUERY;
        try
        {
            con.Open();
            SQL_QUERY = "Select * from Product_Size where Size_ID='" + ddlSize.SelectedValue + "'";

            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmdEmp;
            da.Fill(dt);
            txtPcsInBox.Text = dt.Rows[0]["Pcs_In_Box"].ToString();
            Calculate_Amount();
            ScriptManager1.SetFocus(txtQtyInBox);

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

    protected void Calculate_Amount()
    {
        int QtyInBox, QtyInPce, TotalPcs;
        decimal Rate, Box_Amount, Pcs_Amount, Amount;
        if (txtQtyInBox.Text == "")
        {
            QtyInBox = 0;
        }
        else
        {
            QtyInBox = Convert.ToInt32(txtQtyInBox.Text);
        }

        if (txtQtyInPce.Text == "")
        {
            QtyInPce = 0;
        }
        else
        {
            QtyInPce = Convert.ToInt32(txtQtyInPce.Text);
        }

        if (txtRate.Text == "")
        {
            Rate = 0;
        }
        else
        {
            Rate = Convert.ToDecimal(txtRate.Text);
        }

        TotalPcs = (QtyInBox * Convert.ToInt32(txtPcsInBox.Text)) + QtyInPce;

        Box_Amount = Rate * QtyInBox;
        Pcs_Amount = (Rate * QtyInPce) / Convert.ToInt32(txtPcsInBox.Text);
        Amount = Box_Amount + Pcs_Amount;
        txtAmount.Text = Amount.ToString();


    }

    protected void txtQtyInBox_TextChanged(object sender, EventArgs e)
    {
        Calculate_Amount();
        ScriptManager1.SetFocus(txtQtyInPce);
    }

    protected void txtQtyInPce_TextChanged(object sender, EventArgs e)
    {
        Calculate_Amount();
        ScriptManager1.SetFocus(txtRate);
    }

    protected void txtRate_TextChanged(object sender, EventArgs e)
    {
        Calculate_Amount();
        ScriptManager1.SetFocus(txtBatchNo);
    }

    protected void txtInvoiceNo_TextChanged(object sender, EventArgs e)
    {
        Bind_Purchase_Invoice();
        Calculate_Grand_Total();
    }

    protected void cmdCreate_Click(object sender, EventArgs e)
    {
        Delete_Flag = 0;

        DOC = Convert.ToDateTime(System.DateTime.Now);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Created_By = Convert.ToInt32(Session["User_ID"]);
        Modified_By = Convert.ToInt32(Session["User_ID"]);

        rt = Insert_Purchase_Invoice_Summary();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Purchase Invoice Create Sucessfully ');", true);
            Clear_All();
           // Bind_Purchase_Invoice();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Purchase Invoice No Alredy Exist!');", true);
        }
    }

    protected int Insert_Purchase_Invoice_Summary()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Purchase_Invoice_Summary", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Purchase_Invoice_NO", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Purchase_Invoice_NO"].Value = txtInvoiceNo.Text;

        cmdEmp.Parameters.Add("@Purchase_Invoice_Date", SqlDbType.DateTime);
        cmdEmp.Parameters["@Purchase_Invoice_Date"].Value = Convert.ToDateTime(txtInvoiceDate.Text);

        cmdEmp.Parameters.Add("@Receive_Date", SqlDbType.DateTime);
        cmdEmp.Parameters["@Receive_Date"].Value = Convert.ToDateTime(txtReceiveDate.Text);

        cmdEmp.Parameters.Add("@Supplier_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Supplier_ID"].Value = Convert.ToInt32(ddlSupplier.SelectedValue);

        cmdEmp.Parameters.Add("@Pass_No", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Pass_No"].Value = txtPassNo.Text;

        cmdEmp.Parameters.Add("@Sales_Tax_Percent", SqlDbType.Decimal);
        cmdEmp.Parameters["@Sales_Tax_Percent"].Value = Convert.ToDecimal(txtSTaxPercent.Text);

        cmdEmp.Parameters.Add("@Discount", SqlDbType.Decimal);
        cmdEmp.Parameters["@Discount"].Value = Convert.ToDecimal(txtDiscount.Text);

        cmdEmp.Parameters.Add("@IC", SqlDbType.Decimal);
        cmdEmp.Parameters["@IC"].Value = Convert.ToDecimal(txtIC.Text);

        cmdEmp.Parameters.Add("@TCS", SqlDbType.Decimal);
        cmdEmp.Parameters["@TCS"].Value = Convert.ToDecimal(txtTCS.Text);

        cmdEmp.Parameters.Add("@Delete_Flag", SqlDbType.Int);
        cmdEmp.Parameters["@Delete_Flag"].Value = Delete_Flag;

        cmdEmp.Parameters.Add("@DOC", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOC"].Value = Convert.ToDateTime(DOC);

        cmdEmp.Parameters.Add("@Created_By", SqlDbType.Int);
        cmdEmp.Parameters["@Created_By"].Value = Created_By;

        cmdEmp.Parameters.Add("@DOM", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOM"].Value = Convert.ToDateTime(DOM);

        cmdEmp.Parameters.Add("@Modified_By", SqlDbType.Int);
        cmdEmp.Parameters["@Modified_By"].Value = Modified_By;


        cmdEmp.Parameters.Add("@rtn", SqlDbType.Int);
        cmdEmp.Parameters["@rtn"].Direction = ParameterDirection.ReturnValue;

        cmdEmp.ExecuteNonQuery();

        con.Close();
        return Convert.ToInt32(cmdEmp.Parameters["@rtn"].Value);
    }

    protected void Clear_All()
    {
        txtInvoiceNo.Text = "";
        txtInvoiceDate.Text = "";
        txtReceiveDate.Text = "";

        txtSupplierName.Text = "";
        txtSupplierPhNo.Text = "";

        ddlProductName.SelectedValue = "";
        ddlSupplier.SelectedValue = "";
        ddlBrand.SelectedValue = "";

        lblStandardRebate.Text = "0.00";
        lblGrossTotal.Text = "0.00";
        lblSTaxAmount.Text = "0.00";
        txtSTaxPercent.Text = "0";
        txtDiscount.Text = "0.00";
        txtIC.Text = "0.00";
        txtTCS.Text = "0.00";
        lblGrandTotal.Text = "0.00";
        lblNetPay.Text = "0.00";

        Bind_Purchase_Invoice();
    }

    protected void gvPurcase_Invoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Purchase_Invoice_ID = Convert.ToInt32(gvPurcase_Invoice.DataKeys[e.RowIndex].Values["Purchase_Invoice_ID"].ToString());
        string SQL_QUERY;
        SQL_QUERY = "DELETE FROM Purchase_Invoice WHERE Purchase_Invoice_ID="+Purchase_Invoice_ID;
        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_Purchase_Invoice();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
        }
    }
}