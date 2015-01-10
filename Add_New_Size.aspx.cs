using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Admin_Add_New_Size : System.Web.UI.Page
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
            Bind_Size();

            chkActive.Checked = true;
        }

    }

    protected void Bind_Size()
    {
        DataTable dt = Get_Size();
        gvSize.DataSource = dt;
        gvSize.DataBind();
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

        rt = Insert_Size();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Clear_All();
            Bind_Size();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }


    }
    protected int Insert_Size()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Size", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Size_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Size_Name"].Value = txtSize.Text;

        cmdEmp.Parameters.Add("@Size_Description", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Size_Description"].Value = txtSizeDesc.Text;

        cmdEmp.Parameters.Add("@Pcs_In_Box", SqlDbType.Int);
        cmdEmp.Parameters["@Pcs_In_Box"].Value = Convert.ToInt32(txtPcsInBox.Text);

        cmdEmp.Parameters.Add("@Size_In_ML", SqlDbType.Int);
        cmdEmp.Parameters["@Size_In_ML"].Value = Convert.ToInt32(txtSizeInML.Text);

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
        txtSize.Text = "";
        txtSizeDesc.Text = "";
        chkActive.Checked = true;
        txtPcsInBox.Text = "";
        txtSizeInML.Text = "";
    }

    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Clear_All();
    }
    protected void gvSize_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Size_ID = Convert.ToInt32(gvSize.DataKeys[e.RowIndex].Values["Size_ID"].ToString());

        DOM = Convert.ToDateTime(System.DateTime.Now);
        Modified_By = Convert.ToInt32(Session["User_ID"]);
        string SQL_QUERY;
        SQL_QUERY = "UPDATE Product_Size SET Delete_Flag=1,DOM='" + DOM + "', Modify_By=" + Modified_By + " WHERE Size_ID=" + Size_ID;

        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);

        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_Size();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
        }
    }
}