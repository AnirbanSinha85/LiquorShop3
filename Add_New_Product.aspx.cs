using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Add_New_Product : System.Web.UI.Page
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
            Bind_Product();
            ddlCategory.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlBrand.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlSize.Items.Insert(0, new ListItem("Select", string.Empty));
        }
    }

    protected void Bind_Size()
    {
        DataTable dt = Get_Size();
        ddlSize.DataSource = dt;
        ddlSize.DataTextField = "Size_Name";
        ddlSize.DataValueField = "Size_ID";
        ddlSize.DataBind();

        ddlEditSize.DataSource = dt;
        ddlEditSize.DataTextField = "Size_Name";
        ddlEditSize.DataValueField = "Size_ID";
        ddlEditSize.DataBind();

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

        ddlEditCategory.DataSource = dt;
        ddlEditCategory.DataTextField = "Category_Name";
        ddlEditCategory.DataValueField = "Category_ID";
        ddlEditCategory.DataBind();
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

        ddlEditBrand.DataSource = dt;
        ddlEditBrand.DataTextField = "Brand_Name";
        ddlEditBrand.DataValueField = "Brand_ID";
        ddlEditBrand.DataBind();
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
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        Delete_Flag = 0;
        DOC = Convert.ToDateTime(System.DateTime.Now);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Created_By = Convert.ToInt32(Session["User_ID"]);
        Modified_By = Convert.ToInt32(Session["User_ID"]);

        rt = Insert_Product();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Clear_All();
            Bind_Size();
            Bind_Product();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Bar-Code!.');", true);
        }

    }
    protected int Insert_Product()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Product", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Category_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Category_ID"].Value = Convert.ToInt32(ddlCategory.SelectedValue);

        cmdEmp.Parameters.Add("@Brand_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Brand_ID"].Value = Convert.ToInt32(ddlBrand.SelectedValue);

        cmdEmp.Parameters.Add("@Bar_code", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Bar_Code"].Value = txtBarCode.Text;

        cmdEmp.Parameters.Add("@Size_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Size_ID"].Value = Convert.ToInt32(ddlSize.SelectedValue);

        cmdEmp.Parameters.Add("@Product_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Product_Name"].Value = txtProductName.Text;

        cmdEmp.Parameters.Add("@Standerd_Rebet", SqlDbType.Decimal);
        cmdEmp.Parameters["@Standerd_Rebet"].Value = Convert.ToDecimal(txtStanderdRebet.Text);

        cmdEmp.Parameters.Add("@Avalable_Quantity", SqlDbType.Int);
        cmdEmp.Parameters["@Avalable_Quantity"].Value = Convert.ToInt32(txtQuantity.Text);

        cmdEmp.Parameters.Add("@MRP", SqlDbType.Decimal);
        cmdEmp.Parameters["@MRP"].Value = Convert.ToDecimal(txtMRP.Text);

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

        cmdEmp.Parameters.Add("@SortCode", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@SortCode"].Value = txtSortCode.Text.Trim().ToUpper();

        cmdEmp.Parameters.Add("@rtn", SqlDbType.Int);
        cmdEmp.Parameters["@rtn"].Direction = ParameterDirection.ReturnValue;

        cmdEmp.ExecuteNonQuery();

        con.Close();
        return Convert.ToInt32(cmdEmp.Parameters["@rtn"].Value);


    }
    protected void Clear_All()
    {
        txtProductName.Text = "";
        txtQuantity.Text = "";

    }
    protected void Bind_Product()
    {
        DataTable dt = Get_Product();
        gvProduct.DataSource = dt;
        gvProduct.DataBind();
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
    protected void cmdReset_Click(object sender, EventArgs e)
    {

    }
    protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        lblID.Text = gvProduct.DataKeys[gvrow.RowIndex].Value.ToString();

        //lblEditCategory.Text = gvrow.Cells[1].Text;
        //lblEditBrand.Text = gvrow.Cells[2].Text;
        //lblEditSize.Text = gvrow.Cells[4].Text;
        txtEditBarCode.Text = gvrow.Cells[4].Text;
        txtEditProductName.Text = gvrow.Cells[6].Text;
        txtEditStanderdRebet.Text = gvrow.Cells[7].Text;
        txtEditQuantity.Text = gvrow.Cells[8].Text;
        txtEditMRP.Text = gvrow.Cells[9].Text;
        txtEditSortCode.Text = gvrow.Cells[10].Text;

        //ddlEditCategory.SelectedIndex = ddlEditCategory.Items.IndexOf(ddlEditCategory.Items.FindByText(lblEditCategory.Text.ToString()));    To bind a drop down

        ddlEditCategory.SelectedIndex = ddlEditCategory.Items.IndexOf(ddlEditCategory.Items.FindByText(gvrow.Cells[2].Text.ToString()));

        ddlEditBrand.SelectedIndex = ddlEditBrand.Items.IndexOf(ddlEditBrand.Items.FindByText(gvrow.Cells[3].Text.ToString()));
        ddlEditSize.SelectedIndex = ddlEditSize.Items.IndexOf(ddlEditSize.Items.FindByText(gvrow.Cells[5].Text.ToString()));


        this.ModalPopupExtender1.Show();
    }
    protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProduct.PageIndex = e.NewPageIndex;
        Bind_Product();
    }
    protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Product_ID = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Values["Product_ID"].ToString());
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Modified_By = Convert.ToInt32(Session["User_ID"]);
        string SQL_QUERY;
        SQL_QUERY = "UPDATE Product_Detail SET Delete_Flag=1,DOM='" + DOM + "', Modify_By=" + Modified_By + " WHERE Product_ID=" + Product_ID;
        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_Product();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int Product_ID = Convert.ToInt32(lblID.Text);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Modified_By = Convert.ToInt32(Session["User_ID"]);

        string SQL_QUERY;
        SQL_QUERY = "UPDATE Product_Detail SET Avalable_Quantity=" + txtEditQuantity.Text + ", Standerd_Rebet='" + txtEditStanderdRebet.Text + "', ";
        SQL_QUERY += "Category_ID=" + ddlEditCategory.SelectedValue + ", Brand_ID= " + ddlEditBrand.SelectedValue + ", Bar_Code='" + txtEditBarCode.Text + "', ";
        SQL_QUERY += "Size_ID=" + ddlEditSize.SelectedValue + ",Product_Name='" + txtEditProductName.Text + "', ";
        SQL_QUERY += "Sort_Code='" + txtEditSortCode.Text.Trim().ToUpper() + "', ";
        SQL_QUERY += "MRP='" + txtEditMRP.Text + "',DOM='" + DOM + "', Modify_By=" + Modified_By + " WHERE Product_ID=" + Product_ID;

        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);

        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_Product();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Updated Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in update!.');", true);
        }


    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {

        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_By_Product_Name", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Product_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Product_Name"].Value = txtProductNameSearch.Text;

        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
        da.SelectCommand = cmdEmp;
        da.Fill(dt);
        gvProduct.DataSource = dt;
        gvProduct.DataBind();

        con.Close();
    }
    protected void cmdSortCodeSearch_Click(object sender, EventArgs e)
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Get_Product_By_Sort_Code", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Sort_Code", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Sort_Code"].Value = txtSearchSortCode.Text.Trim().ToUpper();

        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
        da.SelectCommand = cmdEmp;
        da.Fill(dt);
        gvProduct.DataSource = dt;
        gvProduct.DataBind();

        con.Close();
    }
}