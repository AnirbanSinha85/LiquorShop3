using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Add_New_Claim : System.Web.UI.Page
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
            Bind_Claim();

            ddlCategory.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlBrand.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlSize.Items.Insert(0, new ListItem("Select", string.Empty));
            ddlProductName.Items.Insert(0, new ListItem("Select", string.Empty));
           

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
                SQL_QUERY += "Brand_ID=" + ddlBrand.SelectedValue + " AND ";
            }
            if (ddlSize.SelectedIndex != 0)
            {
                SQL_QUERY += "Size_ID=" + ddlSize.SelectedValue + " AND ";
            }
            SQL_QUERY += "Delete_Flag <>1 ";


            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmdEmp;
            da.Fill(dt);

            ddlProductName.DataSource = dt;
            ddlProductName.DataTextField = "Product_Name";
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
            //txtPcsInBox.Text = dt.Rows[0]["Pcs_In_Box"].ToString();
            //Calculate_Amount();
            //ScriptManager1.SetFocus(txtQtyInBox);

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
        rt = Insert_Size();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Bind_Claim();
           // Bind_Size();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }
    }

    protected int Insert_Size()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Claim", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Product_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Product_ID"].Value = Convert.ToInt32(ddlProductName.SelectedValue);

        cmdEmp.Parameters.Add("@Claim_Date", SqlDbType.DateTime);
        cmdEmp.Parameters["@Claim_Date"].Value = Convert.ToDateTime(txtClaimDate.Text);

        cmdEmp.Parameters.Add("@Claim_Qty", SqlDbType.Int);
        cmdEmp.Parameters["@Claim_Qty"].Value = Convert.ToInt32(txtQuantity.Text);

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
    protected void Bind_Claim()
    {
        DataTable dt = Get_Claim();
        gvClaim.DataSource = dt;
        gvClaim.DataBind();
         
    }
    public DataTable Get_Claim()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_Claim", con);
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
    protected void gvClaim_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClaim.PageIndex = e.NewPageIndex;
        Bind_Claim();
    }
}