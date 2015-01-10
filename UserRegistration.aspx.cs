using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_UserRegistration : System.Web.UI.Page
{

    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);

     
    string SQL_Query;

    int Delete_Flag, Created_By, Modified_By,Gender,rt;
    DateTime DOB, DOC, DOM;
    int AcessLevel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            Bind_User();
            rbMale.Checked = true;
            chkActive.Checked = true;
        }

    }
    protected void Bind_User()
    {
        DataTable dt = Get_User();
        gvUser.DataSource = dt;
        gvUser.DataBind();
    }
    public DataTable Get_User()
    {

        try
        {
            con.Open();

            SqlCommand cmdEmp = new SqlCommand("sp_Get_User", con);
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
        if (rbMale.Checked == true)
        {
            Gender = 1;//Male Gender
        }
        else
        {
            Gender = 0;//Female Gender
        }
        if (chkActive.Checked == true)
        {
            Delete_Flag = 0;//For  Active Data
        }
        else
        {
            Delete_Flag = 1;//For Not Active Data
        }
        if (Convert.ToInt32(ddlAcessLevel.SelectedValue) == 1)
        {
            AcessLevel = 1;//Admin
        }
        else
        {
            AcessLevel = 2;//User
        }

        DOC = Convert.ToDateTime(System.DateTime.Now);
        DOM = Convert.ToDateTime(System.DateTime.Now);
        Created_By =Convert.ToInt32( Session["User_ID"]);
        Modified_By = Convert.ToInt32(Session["User_ID"]);


        rt = Insert_User();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Bind_User();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }

    }
    protected int Insert_User()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_User", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@User_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@User_Name"].Value = txtUserName.Text;

        cmdEmp.Parameters.Add("@Password", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Password"].Value = txtPassword.Text;

        cmdEmp.Parameters.Add("@First_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@First_Name"].Value = txtFName.Text;

        cmdEmp.Parameters.Add("@Last_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Last_Name"].Value = txtLname.Text;

        cmdEmp.Parameters.Add("@Gender", SqlDbType.Int);
        cmdEmp.Parameters["@Gender"].Value = Gender;

        cmdEmp.Parameters.Add("@DOB", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOB"].Value = Convert.ToDateTime(txtDOB.Text);

        cmdEmp.Parameters.Add("@Address", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Address"].Value = txtAddress.Text;

        cmdEmp.Parameters.Add("@Ph_No", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Ph_No"].Value = txtPhNo.Text;

        cmdEmp.Parameters.Add("@Email", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Email"].Value = txtEmail.Text;

        cmdEmp.Parameters.Add("@AcessLevel", SqlDbType.Int);
        cmdEmp.Parameters["@AcessLevel"].Value = AcessLevel;

        cmdEmp.Parameters.Add("@Delete_Flag", SqlDbType.Int);
        cmdEmp.Parameters["@Delete_Flag"].Value = Delete_Flag;

        cmdEmp.Parameters.Add("@DOC", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOC"].Value =Convert.ToDateTime(  DOC);

        cmdEmp.Parameters.Add("@Created_By", SqlDbType.Int);
        cmdEmp.Parameters["@Created_By"].Value = Created_By;


        cmdEmp.Parameters.Add("@DOM", SqlDbType.DateTime);
        cmdEmp.Parameters["@DOM"].Value =Convert.ToDateTime(  DOM);

        cmdEmp.Parameters.Add("@Modified_By", SqlDbType.Int);
        cmdEmp.Parameters["@Modified_By"].Value = Modified_By;


        cmdEmp.Parameters.Add("@rtn", SqlDbType.Int);
        cmdEmp.Parameters["@rtn"].Direction = ParameterDirection.ReturnValue;

        cmdEmp.ExecuteNonQuery();

        con.Close();
        return Convert.ToInt32(cmdEmp.Parameters["@rtn"].Value);

        
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        txtAddress.Text = "";
        txtDOB.Text = "";
        txtEmail.Text = "";
        txtFName.Text = "";
        txtLname.Text = "";
        txtPassword.Text = "";
        txtPhNo.Text = "";
        txtRTPassword.Text = "";
        txtUserName.Text = ""; 

    }
    protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser.PageIndex = e.NewPageIndex;
        Bind_User();
    }
    protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int User_ID = Convert.ToInt32(gvUser.DataKeys[e.RowIndex].Values["User_ID"].ToString());

        DOM = Convert.ToDateTime(System.DateTime.Now);
        Modified_By = Convert.ToInt32(Session["User_ID"]);
        string SQL_QUERY;
        SQL_QUERY = "UPDATE USER SET Delete_Flag=1,DOM='" + DOM + "', Modify_By=" + Modified_By + " WHERE Product_ID=" + User_ID;

        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);

        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_User();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
        }
    }
}