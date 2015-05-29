using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_zapros : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Time
    {
        set
        {
            time.Text = value;
        }
    }
    public string Fio
    {
        set
        {
            fio.Text = value;
        }
    }
    public string Id
    {
        set
        {
            id.Text = value;
        }
    }
    public string Pid
    {
        set
        {
            pacid.Text = value;
        }
    }
    public string Idvisit
    {
        set
        {
            idvisit.Text = value;
        }
    }
   
    
    protected void yes_Click(object sender, ImageClickEventArgs e)
    {
        int y = 0;
        DBase.MSSQL mssql = new DBase.MSSQL();
        List<DBase.successdesk> servsucs = mssql.GetAllDeskSuccess();
        foreach (DBase.successdesk ss in servsucs)
        {
            if (ss.Idvisits == Convert.ToInt32(idvisit.Text))
                y = ss.Id;
                
        }
        mssql.UpdateDeskSuccess(y, 1);
        Email.Email email = new Email.Email();
        email.SendEmailGmail("mail@medic.med", pacid.Text, "Подтверждение записи на прием", "Ваша запись: " + fio.Text + "подтверждена. ");
        
    }
    protected void no_Click(object sender, ImageClickEventArgs e)
    {
        int y = 0;
        DBase.MSSQL mssql = new DBase.MSSQL();
        List<DBase.successdesk> servsucs = mssql.GetAllDeskSuccess();
        foreach (DBase.successdesk ss in servsucs)
        {
            if (ss.Idvisits == Convert.ToInt32(idvisit.Text))
            { 
                y = ss.Id;
                mssql.DeleteDesk(ss.Idvisits);
            }

        }
        mssql.UpdateDeskSuccess(y, 0);
        Email.Email email = new Email.Email();
        email.SendEmailGmail("mail@medic.med", pacid.Text,"Отмена записи на прием", "Ваша запись: " + fio.Text + "отменена. Обратитесь в регистратуру");
                
        
    }
}