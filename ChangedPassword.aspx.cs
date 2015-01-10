using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class ChangedPassword : System.Web.UI.Page
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
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        string SQL_QUERY;
        string Email;
        try
        {
            con.Open();

            SQL_QUERY = "SELECT * FROM [User] Where User_Id= " + Session["User_Id"] +" AND Password='"+txtOldPassword.Text+"'";
            SQL_QUERY += "AND Delete_Flag <>1 ";
            SqlCommand cmdEmp = new SqlCommand(SQL_QUERY, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmdEmp;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Email = dt.Rows[0]["Email"].ToString();
                DOM = Convert.ToDateTime(System.DateTime.Now);
                Modified_By = Convert.ToInt32(Session["User_ID"]);
                SQL_QUERY = "UPDATE [USER] SET PASSWORD='" + txtNewPassword.Text + "' WHERE User_Id= " + Session["User_Id"];
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL_QUERY, con);
                int result = cmd.ExecuteNonQuery();
               
                if (result == 1)
                {
                    Send_Mail(Email);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Password Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error in update!.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('You are not a valid user!.');", true);
            }
        }
        catch (Exception ex)
        {
            con.Close();
        }
        finally
        {
            con.Close();

        }
    }

    public void Send_Mail(string Email)
    {
        try
        {
            MailMessage Msg = new MailMessage();
            // Sender e-mail address.
            Msg.From = new MailAddress("no-reply@debduttaroy.com");
            // Recipient e-mail address.
            Msg.To.Add(Email);
            Msg.Subject = "Password Change";
            Msg.Body = "Your Password Changed Sucessfully.<br/> Your New Password : <strong>" + txtNewPassword.Text + "</strong>";
            Msg.IsBodyHtml = true;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("debduttaroyEmail@gmail.com", "debduttaroy@email");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            Msg = null;
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
    }
}