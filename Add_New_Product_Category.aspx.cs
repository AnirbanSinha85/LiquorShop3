using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Add_New_Product_Category : System.Web.UI.Page
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
  
            chkActive.Checked = true;
        }

 
    }

    protected void Bind_Product_Category()
    {
        DataTable dt = Get_Product_Category();
        gvProduct_Category.DataSource = dt;
        gvProduct_Category.DataBind();
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
            con.Dispose();
        }
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (chkActive.Checked == true)
        {
            Delete_Flag = 0;//For  Active Data
        }
        else
        {
            Delete_Flag = 1;//For Not Active Data
        }
        DOC = Convert.ToDateTime(System.DateTime.Now);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Created_By = Convert.ToInt32(Session["User_ID"]);
        Modified_By = Convert.ToInt32(Session["User_ID"]);

        rt = Insert_Product_Category();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Clear_All();
            Bind_Product_Category();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }

    }
    protected int Insert_Product_Category()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Product_Category", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Category_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Category_Name"].Value = txtCategoryName.Text;

        cmdEmp.Parameters.Add("@Category_Description", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Category_Description"].Value = txtCategoryDesc.Text;


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
        txtCategoryDesc.Text = "";
        txtCategoryName.Text = "";
        chkActive.Checked = true; ;
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Clear_All();
    }
    protected void gvProduct_Category_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Category_ID = Convert.ToInt32(gvProduct_Category.DataKeys[e.RowIndex].Values["Category_ID"].ToString());
          
        DOM= Convert.ToDateTime(System.DateTime.Now);
        Modified_By = Convert.ToInt32(Session["User_ID"]);
        string SQL_QUERY;
        SQL_QUERY = "UPDATE Product_Category SET Delete_Flag=1,DOM='" + DOM + "', Modify_By=" + Modified_By + " WHERE Category_ID=" + Category_ID;

        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);
         
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_Product_Category();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
        }
    }
}