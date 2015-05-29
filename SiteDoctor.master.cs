using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Код ниже защищает от XSRF-атак
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Использование маркера защиты от XSRF из файла cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Создание нового маркера защиты от XSRF и его сохранение в файле cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Задание маркера защиты от XSRF
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Проверка маркера защиты от XSRF
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Ошибка проверки маркера защиты от XSRF.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
            HttpCookie cookie = Request.Cookies["user"];
            if (cookie != null)
            {
                string type = (cookie["typeuser"]);
                if (type == "doctor")
                {
                    welcome.Text += "<br />" + cookie["fiouser"];
                    DBase.MSSQL mssql = new DBase.MSSQL();
                    string userid = "", username = "";
                    
                    if (cookie != null)
                    {
                        
                        if (type == "doctor")
                        {
                            userid = cookie["iduser"];
                            username = cookie["fiouser"];
                        }
                        else
                        {
                            Response.Redirect("Login.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("logout.aspx");
                    }

                    List<DBase.doctordesk> desks = mssql.GetAllDesk(Convert.ToInt32(userid));
                    List<DBase.patient> pats = mssql.GetAllPatient();

                    foreach (DBase.doctordesk dd in desks)
                        if (dd.Data == DateTime.Now.ToShortDateString())
                        {
                            Templates_visitss cntrl = (Templates_visitss)LoadControl("Templates/visitss.ascx");
                            cntrl.Time = dd.Time;
                            cntrl.Idvisit = Convert.ToString(dd.Id);
                            cntrl.Pid = Convert.ToString(dd.PacientID);
                            cntrl.Id = Convert.ToString(dd.Id);
                            foreach (DBase.patient p in pats)
                                if (dd.PacientID == p.PatientID)
                                    cntrl.Fio = p.Fam + " " + p.Im + " " + p.Otch;
                            zaplist.Controls.Add(cntrl);
                            zagol.Text = "Записи на прием:";
                        }

                    if (zaplist.Controls.Count < 1)
                    {
                        zagol.Text = "Нет записей на сегодня.";
                        zagol.ForeColor = System.Drawing.Color.DarkRed;
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}