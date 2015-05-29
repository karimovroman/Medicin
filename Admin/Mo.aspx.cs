using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Mo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void del_Click(object sender, ImageClickEventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        mssql.DeleteMO(Convert.ToInt32(listermo.SelectedValue));
        mssql.DeleteMoServ(Convert.ToInt32(listermo.SelectedValue));
        List<DBase.mo> listmos = mssql.GetMo();
        List<DBase.mo> listmo = listmos.OrderBy(o => o.Name).ToList();
                   
        foreach (DBase.mo m in listmo)
        {
            listermo.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
        }
    }
}