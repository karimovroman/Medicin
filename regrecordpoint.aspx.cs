using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Recordpoint : System.Web.UI.Page
{
    public string doct = "";
    public string pacient = "";
    public string emailp = "";
    public string moid = "";
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        DBase.doctordesk desk = new DBase.doctordesk();
        desk.Code = iddesk.Text;
        desk.DoctorID = Convert.ToInt32(doct);
        desk.PacientID = Convert.ToInt32(pacient);
        desk.Time = times.Text;
        desk.Data = data.Text;
        desk.Id = 0;
        desk.Mo = Convert.ToInt32(moid);
        DBase.MSSQL mssql = new DBase.MSSQL();
        mssql.InsertDoctorTime(desk);
        if (CheckBox1.Checked == true) { 
        Email.Email email = new Email.Email();
        email.SendEmailGmail("medicinsystem@medicen.com", "roman-kmail@mail.ru", "Информация о вашей записи на прием", "Уважаемый " + pac.Text + ". Вы записаны к " + spec.Text + " " + doctor.Text + " " + data.Text + " на " + times.Text + ". Кабинет " + cabin.Text);
        //desk.Code = pat.PatientID + doctorid + datazap.Substring(0, 2) + datazap.Substring(2, 2);
        }
        pan.Visible = false;
        panelka.Visible = true;
       
    }
}