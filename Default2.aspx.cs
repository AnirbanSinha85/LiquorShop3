using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data;
public partial class Default2 : System.Web.UI.Page
{
    public static string SqlConnection = ConfigurationManager.ConnectionStrings["LiquorShop"].ToString();
    SqlConnection con = new SqlConnection(SqlConnection);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDatabases();
            ReadBackupFiles();
        }
    }
    protected void btnBackup_Click(object sender, EventArgs e)
    {
        try
        {
            string _DatabaseName = ddlDatabases.SelectedItem.Text.ToString();
            string _BackupName = _DatabaseName + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";


            con.Open();
            string sqlQuery = "BACKUP DATABASE " + _DatabaseName + " TO DISK = 'D:\\New folder\\" + _BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            sqlCommand.CommandType = CommandType.Text;
            int iRows = sqlCommand.ExecuteNonQuery();
            con.Close();
            lblMessage.Text = "The " + _DatabaseName + " database Backup with the name " + _BackupName + " successfully...";
           // ReadBackupFiles();
        }
        catch (SqlException sqlException)
        {
            lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }
    private void FillDatabases()
    {
        try
        {

            con.Open();
            string sqlQuery = "SELECT * FROM sys.databases";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            ddlDatabases.DataSource = dataSet.Tables[0];
            ddlDatabases.DataTextField = "name";
            ddlDatabases.DataValueField = "database_id";
            ddlDatabases.DataBind();
        }
        catch (SqlException sqlException)
        {
            lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }
    protected void btnRestore_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstBackupfiles.SelectedIndex > 0)
            {
                string _DatabaseName = ddlDatabases.SelectedItem.Text.ToString();
                string _BackupName = lstBackupfiles.SelectedItem.Text.ToString();


                con.Open();
                string sqlQuery = "RESTORE DATABASE " + _DatabaseName + " FROM DISK ='" + _BackupName + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, con);
                sqlCommand.CommandType = CommandType.Text;
                int iRows = sqlCommand.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "The " + _DatabaseName + " database restored with the name " + _BackupName + " successfully...";
            }
        }
        catch (SqlException sqlException)
        {
            lblMessage.Text = sqlException.Message.ToString();
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }

    private void ReadBackupFiles()
    {
        try
        {
            if (!Directory.Exists(@"D:\New folder\"))
            {
                Directory.CreateDirectory(@"D:\New folder\");
            }

            string[] files = Directory.GetFiles(@"D:\New folder\", "*.bak");
            lstBackupfiles.DataSource = files;
            lstBackupfiles.DataBind();
            lstBackupfiles.SelectedIndex = 0;
        }
        catch (Exception exception)
        {
            lblMessage.Text = exception.Message.ToString();
        }
    }
}