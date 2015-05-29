<%@ Page Title="Новый пациент" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="regpatients.aspx.cs" Inherits="regpatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <script runat="server">
        private DBase.MSSQL mssql = new DBase.MSSQL();    
        private int r = 0;

        void SaveMyInformation(Object sender, EventArgs e)
        {
            if ((Convert.ToInt32(daterozden.Text.Substring(6, 4)) > Convert.ToInt32(kogdavid.Text.Substring(6, 4))) || (Convert.ToInt32(daterozden.Text.Substring(6, 4)) > 2005 && (Convert.ToInt32(kogdavid.Text.Substring(6, 4)) < 2006 || Convert.ToInt32(kogdavid.Text.Substring(6, 4)) > 2015)) || Convert.ToInt32(kogdavid.Text.Substring(6, 4)) > 2015)
            {
                HtmlGenericControl message = new HtmlGenericControl();
                message.InnerHtml = "<h5 style='color: Red'>Ошибка: Дата выдачи документа! </h5>";
                mas.Controls.Add(message);

            }
            else
            {
                if (Convert.ToInt32(daterozden.Text.Substring(6, 4)) < 1997 || Convert.ToInt32(daterozden.Text.Substring(6, 4)) > 2016)
                {
                    HtmlGenericControl message = new HtmlGenericControl();
                    message.InnerHtml = "<h5 style='color: Red'>Ошибка: Дата рождения! </h5>";
                    mas.Controls.Add(message);

                }
                else
                {
                    bool t = false;
                    List<DBase.patient> patsl = mssql.GetAllPatient();
                    foreach (DBase.patient p in patsl)
                    {
                        if (p.Inn == inn.Text || p.Snils == snils.Text)
                            t = true;
                    }

                    if (t)
                    {
                        HtmlGenericControl message = new HtmlGenericControl();
                        message.InnerHtml = "<h5 style='color: Red'>Ошибка: Запись с указанными данными существует! </h5>";
                        mas.Controls.Add(message);
                    }

                    else
                    {
                        DBase.patient pat = new DBase.patient();
                        DBase.predstavitel prt = new DBase.predstavitel();
                        //Пациент
                        pat.School = school.Text;
                        pat.PatientID = 1;
                        pat.Fam = fam.Text;
                        pat.Im = name.Text;
                        pat.Otch = otch.Text;
                        pat.Snils = snils.Text;
                        pat.Inn = inn.Text;
                        pat.Datr = daterozden.Text;
                        pat.Mest = mesto.Text;
                        pat.Vozr = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(daterozden.Text.Substring(6, 4)));
                        pat.Pol = pol.Text;
                        pat.Dok = doc.Text;
                        pat.Data = Convert.ToString(DateTime.Now);
                        pat.Noms = numoms.Text;
                        pat.Soms = seroms.Text;
                        pat.Sem = sempol.Text;
                        pat.Sernom = seriya.Text;
                        pat.Kemv = kemvidan.Text;
                        pat.Rassa = rassa.Text;
                        pat.Rabot = rabota.Text;
                        pat.Datv = kogdavid.Text;
                        pat.Typpolis = tipoms.SelectedValue;
                        pat.Trud = hartrud.SelectedValue;
                        pat.Strax = strahkom.SelectedValue;
                        pat.Det = Convert.ToInt16(deti.Text);
                        pat.Dms = dms.Text;
                        pat.Datoms = datevid.Text;
                        pat.Obraz = obraz.Text;
                        pat.Dolg = dolj.Text;
                        pat.Oms = oms.Text;

                        HttpCookie cookie = Request.Cookies["user"];
                        int userid = Convert.ToInt32(cookie["iduser"]);
                        int moid = mssql.GetRegistratorMO(userid);
                        pat.Mo = moid;


                        r = mssql.InsertPatient(pat);
                        if (r != 0)
                        {
                            //Представитель пациента
                            prt.Id = 1;
                            prt.PatientID = r;
                            prt.Fio = fiop.Text + " " + imp.Text + " " + otchp.Text;
                            prt.Rodstvo = rodstvo.Text;
                            prt.Doc = pdoc.Text;
                            prt.Num = pser.Text + pnum.Text;
                            prt.Vidan = pkem.Text;
                            prt.Kogda = pkogda.Text;
                            prt.Address = padr.Text;

                            prt.Sphone = sphone.Text;
                            prt.Phone = pphone.Text;
                            prt.Phone2 = pphone2.Text;
                            DBase.password pswd = new DBase.password();
                            string pass = pswd.generate();
                            r = mssql.InsertpatientPassword(pass, r);
                            Email.Email email = new Email.Email();
                            email.SendEmailGmail("mail@medic.med", prt.Phone2, "Ваш логин для входа: " + snils.Text + "<br /> Пароль для доступа к ЛК", "Пароль: " + pass + "/n Храните пароль в секрете! Ссылка для смены пароля <a href=\"https://localhost:44300/passwordchange\">Изменить</a> ");
                            SMSC smsc = new SMSC();
                            smsc.send_sms(sphone.Text, "Спасибо за регистрацию!");


                            r = mssql.InsertPredstavitel(prt);

                        }
                        if (r != 0)
                        {
                            HtmlGenericControl message = new HtmlGenericControl();
                            message.InnerHtml = "<h5 style='color: Red'>Пациент создан! Пароль для доступа в систему выслан на электронную почту.</h5>";
                            mas.Controls.Add(message);
                        }
                        else
                        {
                            HtmlGenericControl message = new HtmlGenericControl();
                            message.InnerHtml = "<h5 style='color: Red'>При добавлении произошла ошибка! Фл</h5>";
                            mas.Controls.Add(message);
                        }
                    }
                }
            }

        }
   </script>
    
    <div id="mas" runat="server"></div>
    <div style="text-align:center" >
        Для регистрации нового пациента заполните форму.
    </div>
     <div style="font-size:medium;width:100%;text-align:center">
        Данные пациента:
    </div>  
     <table id="Table1" width ="100%" style="margin-left:100px; vertical-align:top" >
           
        <tr align=center>
        <td>
        <tr align="left">
            <td Width="120px">Фамилия*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="fam"
                    ErrorMessage="Вы ввели не фамилию."
                    ValidationExpression="[а-яА-Я\s*\-]{1,50}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="fam"
                        ErrorMessage="Вы не ввели фамилию"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="fam" Width="250px" runat="server"></asp:TextBox></td></tr>
           
            <tr align="left">
            <td Width="120px">Имя*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="name" 
                    ErrorMessage="Вы ввели не имя."
                    ValidationExpression="[а-яА-Я\s*\-]{1,50}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="name"
                        ErrorMessage="Вы не ввели имя"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="name" Width="250px" runat="server"></asp:TextBox></td></tr>
          
            <tr align="left">
            <td Width="120px">Отчество*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="otch"
                    ErrorMessage="Вы ввели не отчество."
                    ValidationExpression="[а-яА-Я\s*\-]{1,50}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="otch"
                        ErrorMessage="Вы не ввели отчество"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="otch" Width="250px" runat="server"></asp:TextBox></td></tr>
          
            <tr align="left">
            <td Width="120px">CНИЛС*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="snils"
                    ErrorMessage="Не верно"
                    ValidationExpression="[1234567890]{11}" /></td>
            <td  width="250px"><asp:TextBox  ID="snils" MaxLength="11" Width="250px" runat="server"></asp:TextBox></td></tr>
          
            <tr align="left">
            <td Width="120px">ИНН*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="inn"
                    ErrorMessage="Не верно"
                    ValidationExpression="[1234567890]{12}" /></td>
            <td  width="250px"><asp:TextBox MaxLength="12"  ID="inn" Width="250px" runat="server"></asp:TextBox></td></tr>
          
            <tr align="left">
            <td Width="120px">Дата рождения*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="daterozden"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="daterozden"
                        ErrorMessage="Вы не ввели дату"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="120px">
                <asp:TextBox  ID="daterozden" Width="250px"  TextMode="Date" text="01.01.2015" AutoPostBack="true" OnDataBinding="daterozden_DataBinding" runat="server"></asp:TextBox>
                &nbsp;</td></tr>

            <tr align="left">
            <td Width="120px">Место рождения*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="mesto" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9,-;:\-\,\№]{1,150}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="mesto"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="mesto" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td></tr>
          
           
            <tr align="left">
            <td Width="120px">Пол пациента*:</td>
            <td  width="120px">
                <asp:DropDownList ID="pol" runat="server" Width="250px">
                    <asp:ListItem Text="Не указано" Value="не указано" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Мужской" Text="Мужской" ></asp:ListItem>
                    <asp:ListItem Value="Женский" Text="Женский" ></asp:ListItem>
                </asp:DropDownList></td></tr>

            <tr align="left">
            <td Width="120px">Документ*:</td>
            <td  width="250px"><asp:DropDownList ID="doc" Width="250px" runat="server">
                    <asp:ListItem Text="Свидетельство о рождении" Value="Свидетельство о рождении" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Паспорт" Value="Паспорт"></asp:ListItem>
                    <asp:ListItem Text="Cправка о рождении"  Value="Справка о рождении" ></asp:ListItem>
                </asp:DropDownList></td></tr>
          
           <tr align="left">
            <td width="120px">Серия и номер*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="seriya" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{4}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="seriya"
                        ErrorMessage="Вы не ввели серию"> 
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="numbers" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{6}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="numbers"
                        ErrorMessage="Вы не ввели номер"> 
                    </asp:RequiredFieldValidator>
            </td>
            <td width="120px">
                <asp:TextBox ID="seriya" Width="100px" MaxLength="4" runat="server"></asp:TextBox>
                <asp:TextBox ID="numbers" MaxLength="6" Width="147px" runat="server"></asp:TextBox></td>
        </tr>

            <tr align="left">
            <td Width="120px">Кем выдан*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="kemvidan" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:\-\,\№]{1,150}" />
                    <asp:RequiredFieldValidator ValidationGroup="r"  ForeColor="#ff3300" runat="server"
                        ControlToValidate="kemvidan"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="kemvidan" Width="250px" TextMode="MultiLine"   runat="server"></asp:TextBox></td></tr>
          
            <tr align="left">
            <td Width="120px">Когда выдан*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="kogdavid"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="kogdavid"
                        ErrorMessage="Вы не ввели дату"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="kogdavid" Width="250px" Text="01.01.2015" AutoPostBack="true" OnTextChanged="kogdavid_TextChanged"   runat="server"></asp:TextBox></td></tr>
          
           <tr align="left">
            <td Width="120px">Гражданство:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="rassa" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
            <td  width="250px"><asp:TextBox  ID="rassa" Width="250px"  runat="server"></asp:TextBox></td></tr>
           
            <tr align="left">
            <td Width="120px">Семейное положение:</td>
            <td  width="120px"> <asp:DropDownList ID="sempol" Width="250px" runat="server">
                    <asp:ListItem Text="Женат/Замужем" Value="Женат/Замужем" ></asp:ListItem>
                    <asp:ListItem Text="Не женат/Не замужем" Value="Начальное" Selected="True" ></asp:ListItem>
                    
                </asp:DropDownList>


            </td></tr>
          
           <tr align="left">
            <td Width="120px">Количество детей:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="deti" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[0-9]{1}" /></td>
            <td  width="250px"><asp:TextBox  ID="deti" Text="0" Width="250px"  runat="server"></asp:TextBox></td></tr>
          
             <tr align="left">
            <td Width="120px">Уровень образования:</td>
            <td  width="120px"> <asp:DropDownList ID="obraz" Width="250px" runat="server">
                    <asp:ListItem Text="Дошкольное" Value="Дошкольное" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Начальное" Value="Начальное" ></asp:ListItem>
                    <asp:ListItem Text="Основное общее" Value="Основное общее" ></asp:ListItem>
                    <asp:ListItem Text="Полное общее" Value="Полное общее" ></asp:ListItem>
                    <asp:ListItem Text="Высшее" Value="Высшее" ></asp:ListItem>
                </asp:DropDownList>


            </td></tr>
          
             <tr align="left">
            <td id="tr1" runat="server" Width="120px">Место работы:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="rabota" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:\-\,\№]{1,150}" /></td>
            <td  width="250px"><asp:TextBox  ID="rabota" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td></tr>
          
             <tr align="left">
            <td runat="server" id="tr2" Width="120px">Должность:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="dolj" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
            <td  width="250px"><asp:TextBox  ID="dolj" Width="250px"  runat="server"></asp:TextBox></td></tr>
          
             <tr runat="server" id="tr3" align="left">
            <td Width="120px">Характер труда:</td>
            <td  width="120px">
                <asp:DropDownList ID="hartrud" Width="250px" runat="server">
                    <asp:ListItem Text="Не указано" Value="null" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Умственный" Value="умственный" ></asp:ListItem>
                    <asp:ListItem Text="Физический" Value="физический" ></asp:ListItem>
                </asp:DropDownList></td></tr>
          
             <tr runat="server" id="oms0" align="left">
            <td Width="120px">Полис ОМС:</td>
            <td  width="250px"><asp:DropDownList runat="server" OnSelectedIndexChanged="oms_SelectedIndexChanged" id="oms" Width="250px" AutoPostBack="true" >
                    <asp:ListItem Text ="Есть" Value="Есть" Selected="True"></asp:ListItem>
                    <asp:ListItem Text ="Нет" Value="Нет" ></asp:ListItem>
               
                </asp:DropDownList></td></tr>

             <tr runat="server" id="oms1" align="left">
            <td Width="120px">Страховая компания:</td>
            <td  width="250px"><asp:DropDownList ID="strahkom" Width="250px" runat="server"></asp:DropDownList></td></tr>
          
            <tr runat="server" id="oms2" align="left">
            <td Width="120px">Тип полиса ОМС:</td>
            <td  width="120px">
                <asp:DropDownList ID="tipoms" Width="250px" runat="server">
                    <asp:ListItem Text="Полис старого образца" Value="Полис старого образца" ></asp:ListItem>
                    <asp:ListItem Text="Временное свидетельство" Value="Временное свидетельство" ></asp:ListItem>
                    <asp:ListItem Text="Полис ОМС единого образца" Value="Полис ОМС единого образца" Selected="True"></asp:ListItem>
                </asp:DropDownList></td></tr>
          
            <tr runat="server" id="oms3" align="left">
            <td Width="120px">Номер полиса ОМС:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="numoms"
                    ErrorMessage="Не верно"
                    ValidationExpression="[0-9]{16}" /></td>
            <td  width="250px"><asp:TextBox  MaxLength="16" ID="numoms" Width="250px"  runat="server" Height="22px"></asp:TextBox></td></tr>
          
            <tr runat="server" id="oms4"  align="left">
            <td Width="120px">Серия и номер бланка ОМС:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="seroms"
                    ErrorMessage="Не верно"
                    ValidationExpression="[0-9]{11}" /></td>
            <td  width="250px"><asp:TextBox MaxLength="11" ID="seroms" Width="250px"  runat="server"></asp:TextBox></td></tr>
          
            <tr runat="server" id="oms5" align="left">
            <td Width="120px">Дата выдачи полиса ОМС:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="datevid"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   </td>
            <td  width="250px"><asp:TextBox  ID="datevid" Width="250px" Text="01.01.2015" AutoPostBack="true" OnTextChanged="datevid_TextChanged"    runat="server"></asp:TextBox></td></tr>
          
            <tr runat="server" id="dms1"  align="left">
            <td Width="120px">Наличие полиса ДМС:</td>
            <td  width="120px">
                                <asp:DropDownList ID="dms" Width="250px" runat="server">
                    <asp:ListItem Text="Нет" Value="Нет" ></asp:ListItem>
                    <asp:ListItem Text="Да" Value="Да" Selected="True" ></asp:ListItem>
                </asp:DropDownList>

             <tr align="left">
            <td width="120px">Учебное заведение:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="school" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:\-\,\№]{1,150}" /></td>
            <td width="120px">
                <asp:TextBox ID="school" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>
            



            </td></tr>
         
         <div id="collapse">
             <tr align="left"><td colspan="2"><div style="text-align:left;margin-left:25%">Представитель пациента:</div></td></tr>
             <tr align="left">
                <td width="120px" style="height: 24px">Фамилия*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="fiop"
                    ErrorMessage="Вы ввели не фамилию."
                    ValidationExpression="а-яА-Я\s*\S*,-;:\-\,\№" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="fiop"
                        ErrorMessage="Вы не ввели фамилию"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="fiop" Width="250px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Имя*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="imp"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*\S*,-;:\-\,\№]{1,50}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="imp"
                        ErrorMessage="Вы не ввели имя"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="imp" Width="250px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Отчество*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="otchp"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*\S*,-;:\-\,\№]{1,50}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="otchp"
                        ErrorMessage="Вы не ввели отчество"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="otchp" Width="250px" runat="server"></asp:TextBox></td>
            </tr>
             <tr align="left">
            <td Width="120px">Описание родства*:</td>
            <td  width="120px">
                <asp:DropDownList ID="rodstvo" Width="250px" runat="server">
                    <asp:ListItem Text="Мать" Value="Мать" ></asp:ListItem>
                    <asp:ListItem Text="Отец" Value="Отец" ></asp:ListItem>
                    <asp:ListItem Text="Опекун" Value="Опекун" Selected="True" ></asp:ListItem>
                    <asp:ListItem Text="Отец" Value="Дедушка" ></asp:ListItem>
                    <asp:ListItem Text="Бабушка" Value="Бабушка" ></asp:ListItem>
                </asp:DropDownList>


            </td></tr>
         
             <tr align="left">
            <td Width="120px">Документ*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pdoc"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*\S*]{1,50}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pdoc"
                        ErrorMessage="Вы не ввели название документа"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="pdoc" Width="250px" ToolTip="Документ удостоверяющий личность представителя пациента"  runat="server"></asp:TextBox></td></tr>
         
         <tr align="left">
            <td Width="120px">Серия и номер*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pser" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{4}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pser"
                        ErrorMessage="Вы не ввели серию"> 
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pnum" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{6}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pnum"
                        ErrorMessage="Вы не ввели номер"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pser" Width="100px"  MaxLength="4" ToolTip="Пример: 1234 123123" runat="server"></asp:TextBox>
                    <asp:TextBox ID="pnum" MaxLength="6" Width="147px" runat="server"></asp:TextBox>
                </td>
            </tr>

         <tr align="left">
            <td Width="120px">Кем выдан*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pkem" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9\S*,-;:\-\,]{1,150}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pkem"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="pkem" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td></tr>
         
         <tr align="left">
            <td Width="120px">Когда выдан*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pkogda"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   </td>
            <td  width="250px"><asp:TextBox  ID="pkogda" Width="250px"  Text="01.01.2015"   runat="server"></asp:TextBox></td></tr>
         
           <tr align="left">
            <td Width="120px">Адрес проживания*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                    ControlToValidate="padr" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9\S*,-;:\-\,]{1,150}" />
                    <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                        ControlToValidate="padr"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="padr" Width="250px" TextMode="MultiLine"   runat="server"></asp:TextBox></td></tr>
         
           <tr align="left">
            <td Width="120px">Телефон городской:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone"
                                    ErrorMessage="Вы ввели не номер."
                                    ValidationExpression="[0-9\s*,-;:\S*]{5,13}" />
                               </td>
            <td  width="250px"><asp:TextBox  ID="pphone" Width="250px" TextMode="Phone"  runat="server"></asp:TextBox></td></tr>
             <tr align="left">
            <td Width="120px">Телефон сотовый*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="sphone"
                                    ErrorMessage="Вы ввели не номер. +7(xxx)xxx-xx-xx"
                                    ValidationExpression="^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$" />
                                <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="sphone"
                                    ErrorMessage="Вы не ввели номер. +7(xxx)xxx-xx-xx"> 
                                </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="sphone" Width="250px" TextMode="Phone"  runat="server"></asp:TextBox></td></tr>
         <tr align="left">
            <td Width="120px">Электронная почта*:<asp:RegularExpressionValidator ValidationGroup="r" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone2"
                                    ErrorMessage="Вы ввели не email."
                                    ValidationExpression="^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$" />
                                <asp:RequiredFieldValidator  ValidationGroup="r" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone2"
                                    ErrorMessage="Вы не ввели email"> 
                                </asp:RequiredFieldValidator></td>
            <td  width="250px"><asp:TextBox  ID="pphone2" Width="250px" TextMode="Phone"  runat="server"></asp:TextBox></td></tr>
        
         </div>
       
         <tr align="left" style="margin-top:20px">
            <td Width="120px"></td>
            <td  width="250px"><asp:Button ID="save" ValidationGroup="r" OnClick="SaveMyInformation" BorderStyle="Groove" Text="Сохранить" Width="250px" runat="server" /></td></tr>
          
         <tr>
             <td colspan="2">
                 <div style="font:x-small">
               * поля обязательные для ввода
           </div>
             </td>
         </tr>
         
        </table>
    
</asp:Content>



