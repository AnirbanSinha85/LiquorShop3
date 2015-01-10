using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Product_Wise_Sale_Valuation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["First_Name"]) == "")
        {
            Response.Redirect("Login.aspx");
        }

    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report_Product_Wise_Quantity_Sale_Valuation_Print.aspx?fmdt=" + txtFromDate.Text + "&todt=" + txtToDate.Text);
    }
}