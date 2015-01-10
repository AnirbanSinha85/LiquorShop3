using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Admin_Add_New_Brand : System.Web.UI.Page
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
            Bind_Brand();

            chkActive.Checked = true;
        }

    }
    protected void Bind_Brand()
    {
        DataTable dt = Get_Brand();
        gvBrand.DataSource = dt;
        gvBrand.DataBind();
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

        rt = Insert_Brand();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Clear_All();
            Bind_Brand();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }

    }
    protected int Insert_Brand()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Brand", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Brand_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Brand_Name"].Value = txtBrandName.Text;

        cmdEmp.Parameters.Add("@Brand_Description", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Brand_Description"].Value = txtBrandDesc.Text;


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
        txtBrandName.Text = "";
        txtBrandDesc.Text = "";
        chkActive.Checked = true; ;
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Clear_All();
    }
    protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        lblID.Text = gvBrand.DataKeys[gvrow.RowIndex].Value.ToString();
        txtName.Text = gvrow.Cells[1].Text;
        txtDesc.Text = gvrow.Cells[2].Text;
        txtActive.Text = gvrow.Cells[3].Text;
        if (txtActive.Text == "ACTIVE")
        {
            chkEditActive.Checked = true;
        }
        else
        {
            chkEditActive.Checked = false;
        }
        
        this.ModalPopupExtender1.Show();
    }

    protected int Update_Brand()
    {
        if (chkEditActive.Checked == true)
        {
            Delete_Flag = 0;//For  Active Data
        }
        else
        {
            Delete_Flag = 1;//For Not Active Data
        }

        DOM = Convert.ToDateTime(System.DateTime.Now);

        Modified_By = Convert.ToInt32(Session["User_ID"]);

        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Update_Brand", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Brand_ID", SqlDbType.Int);
        cmdEmp.Parameters["@Brand_ID"].Value = lblID.Text;

        cmdEmp.Parameters.Add("@Brand_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Brand_Name"].Value = txtName.Text;

        cmdEmp.Parameters.Add("@Brand_Description", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Brand_Description"].Value = txtDesc.Text;


        cmdEmp.Parameters.Add("@Delete_Flag", SqlDbType.Int);
        cmdEmp.Parameters["@Delete_Flag"].Value = Delete_Flag;

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
         

       rt= Update_Brand();
       if (rt == 11)
       {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
           Clear_All();
           Bind_Brand();
       }
       else
       {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
       }

    }
    protected void gvBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Brand_ID = Convert.ToInt32(gvBrand.DataKeys[e.RowIndex].Values["Brand_ID"].ToString());

        DOM = Convert.ToDateTime(System.DateTime.Now);
        Modified_By = Convert.ToInt32(Session["User_ID"]);
        string SQL_QUERY;
        SQL_QUERY = "UPDATE Product_Brand SET Delete_Flag=1,DOM='" + DOM + "', Modify_By=" + Modified_By + " WHERE Brand_ID=" + Brand_ID;

        con.Open();
        SqlCommand cmd = new SqlCommand(SQL_QUERY, con);

        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            Bind_Brand();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Deleted Successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in delete!.');", true);
        }
    }
}