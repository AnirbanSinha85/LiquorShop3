using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class Admin_Add_New_Supplier : System.Web.UI.Page
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
            Bind_Supplier();

            chkActive.Checked = true;
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

        rt = Insert_Supplier();

        if (rt == 11)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
            Clear_All();
            Bind_Supplier();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
        }
    }

    protected int Insert_Supplier()
    {
        con.Open();

        SqlCommand cmdEmp = new SqlCommand("sp_Insert_Supplier", con);
        cmdEmp.CommandType = CommandType.StoredProcedure;

        cmdEmp.Parameters.Add("@Supplier_Name", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Supplier_Name"].Value = txtSupplierName.Text;

        cmdEmp.Parameters.Add("@Supplier_Address", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Supplier_Address"].Value = txtSupplierAddress.Text;

        cmdEmp.Parameters.Add("@Supplier_PhNo", SqlDbType.VarChar, 50);
        cmdEmp.Parameters["@Supplier_PhNo"].Value = txtSupplierPhNo.Text;

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
        txtSupplierName.Text = "";
        txtSupplierAddress.Text = "";
        txtSupplierPhNo.Text = "";
        chkActive.Checked = true; ;
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Clear_All();
    }

    protected void Bind_Supplier()
    {
        DataTable dt = Get_Supplier();
        gvSupplier.DataSource = dt;
        gvSupplier.DataBind();
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
            con.Dispose();
        }
    }
}