<%@ Page Title="Регистратура: Данные пациенто" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="reglistpatient.aspx.cs" Inherits="reglistpatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
        private DBase.MSSQL mssql = new DBase.MSSQL();
        private int r = 0;

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
           DBase.patient pat = new DBase.patient();
          DBase.predstavitel prt = new DBase.predstavitel();
          pat = mssql.Getpatient(Convert.ToInt32(DropDownList1.SelectedValue));
          prt = mssql.GetPatientPredstavitel(Convert.ToInt32(DropDownList1.SelectedValue));
          //Пациент
          MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
          List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
          foreach(MySqlLib.MySqlData.MySqlExecute.strahovay st in str)
          {
              strahkom.Items.Add(new ListItem(st.name, Convert.ToString(st.id)));
          }
           school.Text=pat.School ;
           fam.Text=pat.Fam ;
           name.Text=pat.Im ;
           otch.Text=pat.Otch;
           snils.Text=pat.Snils ;
           inn.Text=pat.Inn ;
           daterozden.Text = pat.Datr ;
           mesto.Text=pat.Mest ;
           vozrast.Text=pat.Vozr ;
           pol.Text=pat.Pol ;
           doc.Text=pat.Dok ;
           numoms.Text=pat.Noms ;
           seroms.Text=pat.Soms ;
           sempol.SelectedValue=pat.Sem ;
           seriya.Text=pat.Sernom.Substring(0,4) ;
           numbers.Text = pat.Sernom.Substring(4, 6) ;
           kemvidan.Text=pat.Kemv ;
           rassa.Text=pat.Rassa ;
           rabota.Text=pat.Rabot ;
           kogdavid.Text=pat.Datv ;
           tipoms.SelectedValue=pat.Typpolis ;
           hartrud.SelectedValue=pat.Trud ;
           strahkom.SelectedValue = pat.Strax;
           (deti.Text)=Convert.ToString(pat.Det) ;
           dms.SelectedValue=pat.Dms ;
           datevid.Text=pat.Datoms ;
           obraz.SelectedValue=pat.Obraz ;
           dolj.Text=pat.Dolg ;
           oms.Text=pat.Oms ;
           mo.Text = Convert.ToString(pat.Mo);
          //Представитель пациента 
           int w = 0;
           if (prt.Fio != null) { 
           for (int i = 0; i < prt.Fio.Length;i++ )
           {
               if(Convert.ToString(prt.Fio[i]) != " " && w==0)
                   fiop.Text += prt.Fio[i];
               else
               {
                   w = 1;
               }
               if (Convert.ToString(prt.Fio[i]) != " " && w == 1)
                   imp.Text += prt.Fio[i];
               else
               {
                   w = 2;
               }
               if (Convert.ToString(prt.Fio[i]) != " " && w == 2)
                   otchp.Text += prt.Fio[i];
               else
               {
                   w = 1;
               }
           }
           }
           
           rodstvo.SelectedValue=prt.Rodstvo ;
           pdoc.Text=prt.Doc ;
           if (prt.Num != null) { 
           pser.Text = prt.Num.Substring(0, 4);
               pnum.Text=prt.Num.Substring(4,6) ;
           }
           pkem.Text=prt.Vidan ;
           pkogda.Text=prt.Kogda ;
           padr.Text=prt.Address ;

           sphone.Text = prt.Sphone;
           pphone.Text=prt.Phone ;
           pphone2.Text=prt.Phone2 ;
           prtid.Text = Convert.ToString(prt.Id);
          }
        
        void Page_Load(Object sender, EventArgs e)
        {
           if(IsPostBack)
           {
               DBase.patient pat = new DBase.patient();
              List<DBase.patient> pats = new List<DBase.patient>();
               DBase.predstavitel prt = new DBase.predstavitel();
               pats = mssql.GetAllPatient();
               HttpCookie cookie = Request.Cookies["user"];
               int userid = Convert.ToInt32(cookie["iduser"]);
               int moid = mssql.GetRegistratorMO(userid);
               //DropDownList1.Items.Clear();
              
               MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
               List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
               pat = mssql.Getpatient(Convert.ToInt32(DropDownList1.SelectedValue));
               prt = mssql.GetPatientPredstavitel(Convert.ToInt32(DropDownList1.SelectedValue));

             
               
           }
            if(!IsPostBack)
            { 
            DBase.patient pat = new DBase.patient();
            List<DBase.patient> pats = new List<DBase.patient>();
            DBase.predstavitel prt = new DBase.predstavitel();
            pats = mssql.GetAllPatient();
            HttpCookie cookie = Request.Cookies["user"];
            int userid = Convert.ToInt32(cookie["iduser"]);
            int moid = mssql.GetRegistratorMO(userid);
                
            foreach(DBase.patient p in pats)
                if(p.Mo == moid)
            {
                DropDownList1.Items.Add(new ListItem(p.Fam + " " + p.Im + " " + p.Otch, Convert.ToString(p.PatientID)));
            }
            //Пациент
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
            pat = mssql.Getpatient(Convert.ToInt32(DropDownList1.SelectedValue));
            prt = mssql.GetPatientPredstavitel(Convert.ToInt32(DropDownList1.SelectedValue));
            
                foreach (MySqlLib.MySqlData.MySqlExecute.strahovay st in str)
            {
                strahkom.Items.Add(new ListItem(st.name, Convert.ToString(st.id)));
            }
            school.Text = pat.School;
            fam.Text = pat.Fam;
            name.Text = pat.Im;
            otch.Text = pat.Otch;
            snils.Text = pat.Snils;
            inn.Text = pat.Inn;
            daterozden.Text = pat.Datr;
            mesto.Text = pat.Mest;
            vozrast.Text = pat.Vozr;
            pol.Text = pat.Pol;
            doc.Text = pat.Dok;
            numoms.Text = pat.Noms;
            seroms.Text = pat.Soms;
            sempol.Text = pat.Sem;
            seriya.Text = pat.Sernom.Substring(0, 4);
            numbers.Text = pat.Sernom.Substring(4, 6);
            kemvidan.Text = pat.Kemv;
            rassa.Text = pat.Rassa;
            rabota.Text = pat.Rabot;
            kogdavid.Text = pat.Datv;
            tipoms.SelectedValue = pat.Typpolis;
            hartrud.SelectedValue = pat.Trud;
            strahkom.SelectedValue = pat.Strax;
            (deti.Text) = Convert.ToString(pat.Det);
            dms.Text = pat.Dms;
            datevid.Text = pat.Datoms;
            obraz.Text = pat.Obraz;
            dolj.Text = pat.Dolg;
            oms.Text = pat.Oms;
           
            //Представитель пациента
            int w = 0;
            int w2 = 0;
            if (prt.Fio != null)
            {
                for (int i = 0; i < prt.Fio.Length; i++)
                {
                    if (Convert.ToString(prt.Fio.Substring(i,1)) == " " && w == 0)
                    {
                        w = i;
                    }

                    if (Convert.ToString(prt.Fio.Substring(i, 1)) == " " && w != 0 && w2 == 0 && i > w)
                    {
                        w2 = i;
                    }
                    
                }
                fiop.Text = prt.Fio.Substring(0, w - 1);
                imp.Text = prt.Fio.Substring(w+1, w2-w-1);

                otchp.Text = prt.Fio.Substring(w2 + 1, prt.Fio.Length - w2 - 1);
            }
                rodstvo.Text = prt.Rodstvo;
            pdoc.Text = prt.Doc;
            if (prt.Num != null)
            {
                pser.Text = prt.Num.Substring(0, 4);
                pnum.Text = prt.Num.Substring(4, 6);
            } 
                pkem.Text = prt.Vidan;
            pkogda.Text = prt.Kogda;
            padr.Text = prt.Address;
            pphone.Text = prt.Phone;
            pphone2.Text = prt.Phone2;

            prtid.Text = Convert.ToString(prt.Id);
            }
        }
     
     void SaveMyInformation(Object sender, EventArgs e)
        {
        DBase.patient pat = new DBase.patient();    
         DBase.predstavitel prt = new DBase.predstavitel();
         
         //Пациент
         pat.School = school.Text;
         pat.PatientID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
         pat.Fam = fam.Text;
         pat.Im = name.Text;
         pat.Otch = otch.Text;
         pat.Snils = snils.Text;
         pat.Inn = inn.Text;
         pat.Datr = daterozden.Text;
         pat.Mest = mesto.Text;
         pat.Vozr = vozrast.Text;
         pat.Pol=pol.Text;
         pat.Dok = doc.Text;
         pat.Data = Convert.ToString(DateTime.Now);
         pat.Noms = numoms.Text;
         pat.Soms = seroms.Text;
         pat.Sem = sempol.Text;
         pat.Sernom = seriya.Text + numbers.Text;
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
         //Представитель пациента
         prt.Id =0;
         prt.PatientID = pat.PatientID;
         prt.Fio = fiop.Text + " " + imp.Text + " " + otchp.Text;
         prt.Rodstvo = rodstvo.Text;
         prt.Doc = pdoc.Text;
         prt.Num = pser.Text + pnum.Text;
         prt.Vidan = pkem.Text;
         prt.Kogda = pkogda.Text;
         prt.Address = padr.Text;
         prt.Phone = pphone.Text;
         prt.Sphone = sphone.Text;
         prt.Phone2= pphone2.Text;
         HttpCookie cookie = Request.Cookies["user"];
         int userid = Convert.ToInt32(cookie["iduser"]);
         int moid = mssql.GetRegistratorMO(userid);
         pat.Mo = moid;
         DBase.predstavitel prt2 = mssql.GetPatientPredstavitel(Convert.ToInt32(DropDownList1.SelectedValue));
         if (prt2.Id == 0)
         {
             prt2.Id = 0;
             prt2.PatientID = pat.PatientID;
             prt2.Kogda = "";
             prt2.Num = "";
             prt2.Phone = "";
             prt2.Phone2 = "";
             prt2.Sphone = "";
             prt2.Rodstvo = "";
             prt2.Vidan = "";
             prt2.Address = "";
             prt2.Doc = "";
             prt2.Fio = "";
             int res = mssql.InsertPredstavitel(prt2);
             res = res;


             int s = 0;
         }
            
            r= mssql.UpdatePatient(pat);
            if (r!=0)
                r=mssql.UpdatePredstavitel(prt);
             if (r != 0)
             {
                 HtmlGenericControl message = new HtmlGenericControl();
                 message.InnerHtml = "<h5 style='color: Red'>Данные обновленны!</h5>";
                 mas.Controls.Add(message);
             }
             else
             {
                 HtmlGenericControl message = new HtmlGenericControl();
                 message.InnerHtml = "<h5 style='color: Red'>При обновлении произошла ошибка! Фл</h5>";
                 mas.Controls.Add(message);
             } 
         }
        
        
    </script>
    <div id="mas" runat="server"></div>
    <br /> <asp:TextBox ID="mo" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="prtid" runat="server" Visible="false"></asp:TextBox>
    
    <asp:Label runat="server" Text="Выберите пациента: "></asp:Label>
    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ID="DropDownList1" runat="server" >
 </asp:DropDownList> 
    <asp:ImageButton ID="refresh"  OnClick="refresh_Click" runat="server" ImageUrl="~/images/refresh-icon-1280x1024.jpg" Width="15px"  /><br />
    <div style="font-size:medium;width:100%;text-align:center">Данные пациента:
    </div>  
     <table id="Table1" width="100%" style="margin-left: 100px">

        <tr align="center">
            <td>
            <tr align="left">
                <td width="120px">Фамилия*:
                <asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="fam" 
                    ErrorMessage="Вы ввели не фамилию."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="fam"
                        ErrorMessage="Вы не ввели фамилию"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="fam" Width="150px" onkeyup="check(this.value)" runat="server"></asp:TextBox></td>
            </tr>

        <tr align="left">
            <td width="120px">Имя*:
                <asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="name" 
                    ErrorMessage="Вы ввели не имя."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="name"
                        ErrorMessage="Вы не ввели имя"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="name" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Отчество*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="otch"
                    ErrorMessage="Вы ввели не отчество."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="otch"
                        ErrorMessage="Вы не ввели отчество"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="otch" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">CНИЛС:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="snils"
                    ErrorMessage="Не верно"
                    ValidationExpression="[1234567890]{11}" />
                    </td>
            <td width="120px">
                <asp:TextBox ID="snils" Width="150px" MaxLength="11" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">ИНН:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="inn"
                    ErrorMessage="Не верно"
                    ValidationExpression="[1234567890]{12}" /></td>
            <td width="120px">
                <asp:TextBox ID="inn" Width="150px" MaxLength="12" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Дата рождения*: <asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="daterozden"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="daterozden"
                        ErrorMessage="Вы не ввели дату"> 
                    </asp:RequiredFieldValidator><br />
                
            </td>
            <td width="120px">
                <asp:TextBox ID="daterozden" Width="150px"   Text="<% DateTime.Now.ToShortDate %>" runat="server"></asp:TextBox><asp:TextBox Visible="false" Width="150px" ID="vozrast" runat="server" Enabled="false"></asp:TextBox>
                &nbsp;</td>
        </tr>

        <tr align="left">
            <td width="120px">Место рождения*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="mesto" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="mesto"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="mesto" Width="150px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>

        

        <tr align="left">
            <td width="120px">Пол пациента*:</td>
            <td width="120px">
                <asp:DropDownList ID="pol" runat="server" Width="150px">
                    <asp:ListItem Text="Не указано" Value="не указано" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Мужской" Text="Мужской"></asp:ListItem>
                    <asp:ListItem Value="Женский" Text="Женский"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr align="left">
            <td width="120px">Документ*:</td>
            <td width="120px">
                <asp:DropDownList ID="doc" Width="150px" runat="server">
                    <asp:ListItem Text="Свидетельство о рождении" Value="Свидетельство о рождении" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Паспорт" Value="Паспорт"></asp:ListItem>
                    <asp:ListItem Text="Cправка о рождении"  Value="Справка о рождении" ></asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr align="left">
            <td width="120px">Серия и номер*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="seriya" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{4}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="seriya"
                        ErrorMessage="Вы не ввели серию"> 
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="numbers" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{6}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="numbers"
                        ErrorMessage="Вы не ввели номер"> 
                    </asp:RequiredFieldValidator>
            </td>
            <td width="120px">
                <asp:TextBox ID="seriya" Width="50px" MaxLength="4" runat="server"></asp:TextBox><asp:TextBox ID="numbers" MaxLength="6" Width="100px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Кем выдан*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="kemvidan" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="kemvidan"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="kemvidan" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Когда выдан*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="kogdavid"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="kogdavid"
                        ErrorMessage="Вы не ввели дату"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="kogdavid" Width="150px"   Text="<% DateTime.Now.ToShortDate %>"  runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Гражданство:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="rassa" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,.-/\s+]{1,150}" />
                    </td>
            <td width="120px">
                <asp:TextBox ID="rassa" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Семейное положение:</td>
            <td width="120px">
                <asp:DropDownList ID="sempol" Width="150px" runat="server">
                    <asp:ListItem Text="Женат/Замужем" Value="Женат/Замужем"></asp:ListItem>
                    <asp:ListItem Text="Не женат/Не замужем" Value="Начальное" Selected="True"></asp:ListItem>

                </asp:DropDownList>


            </td>
        </tr>

        <tr align="left">
            <td width="120px">Количество детей:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="deti" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[0-9]{1}" />
                    </td>
            <td width="120px">
                <asp:TextBox ID="deti" Width="150px" MaxLength="1" Text="0" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Уровень образования:</td>
            <td width="120px">
                <asp:DropDownList ID="obraz" Width="150px" runat="server">
                    <asp:ListItem Text="Дошкольное" Value="Дошкольное" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Начальное" Value="Начальное"></asp:ListItem>
                    <asp:ListItem Text="Основное общее" Value="Основное общее"></asp:ListItem>
                    <asp:ListItem Text="Полное общее" Value="Полное общее"></asp:ListItem>
                    <asp:ListItem Text="Высшее" Value="Высшее"></asp:ListItem>
                </asp:DropDownList>


            </td>
        </tr>

        <tr runat="server" id="tr1" align="left">
            <td width="120px">Место работы:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="rabota" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" />
                    </td>
            <td width="120px">
                <asp:TextBox ID="rabota" Width="150px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="tr2" align="left">
            <td width="120px">Должность:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="dolj" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
            <td width="120px">
                <asp:TextBox ID="dolj" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="tr3" align="left">
            <td width="120px">Характер труда:</td>
            <td width="120px">
                <asp:DropDownList ID="hartrud" Width="150px" runat="server">
                    <asp:ListItem Text="Не указано" Value="Не указано" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Умственный" Value="умственный"></asp:ListItem>
                    <asp:ListItem Text="Физический" Value="физический"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr runat="server" id="oms0" align="left">
            <td width="120px">Полис ОМС:</td>
            <td width="120px">
                <asp:DropDownList runat="server" id="oms" Width="150px" OnSelectedIndexChanged="oms_SelectedIndexChanged" AutoPostBack="true" >
                    <asp:ListItem Text ="Есть" Value="Есть" Selected="True"></asp:ListItem>
                    <asp:ListItem Text ="Нет" Value="Нет" ></asp:ListItem>
               
                </asp:DropDownList></td>
        </tr>

        <tr runat="server" id="oms1" align="left">
            <td width="120px">Страховая компания:</td>
            <td width="120px">
                <asp:DropDownList ID="strahkom" Width="150px" runat="server"></asp:DropDownList></td>
        </tr>

        <tr runat="server" id="oms2" align="left">
            <td width="120px">Тип полиса ОМС:</td>
            <td width="120px">
                <asp:DropDownList ID="tipoms" Width="150px" runat="server">
                    <asp:ListItem Text="Полис старого образца" Value="Полис старого образца"></asp:ListItem>
                    <asp:ListItem Text="Временное свидетельство" Value="Временное свидетельство"></asp:ListItem>
                    <asp:ListItem Text="Полис ОМС единого образца" Value="Полис ОМС единого образца" Selected="True"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr runat="server" id="oms3" align="left">
            <td width="120px">Номер полиса ОМС:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="numoms"
                    ErrorMessage="Не верно"
                    ValidationExpression="[0-9]{16}" /></td>
            <td width="120px">
                <asp:TextBox ID="numoms" MaxLength="16" Width="150px" runat="server" Height="22px"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="oms4" align="left">
            <td width="120px">Серия и номер бланка ОМС:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="seroms"
                    ErrorMessage="Не верно"
                    ValidationExpression="[0-9]{11}" />
                   </td>
            <td width="120px">
                <asp:TextBox ID="seroms" MaxLength="11" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="oms5" align="left">
            <td width="120px">Дата выдачи полиса ОМС:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="datevid"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   </td>
            <td width="120px">
                <asp:TextBox ID="datevid"  Width="150px" Text="<% DateTime.Now.ToShortDate %>"  runat="server"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="dms1" align="left">
            <td width="120px">Наличие полиса ДМС:</td>
            <td width="120px">
                <asp:DropDownList ID="dms" Width="150px" runat="server">
                    <asp:ListItem Text="Нет" Value="Нет"></asp:ListItem>
                    <asp:ListItem Text="Да" Value="Да" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left">
            <td width="120px">Учебное заведение:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="school" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
            <td width="120px">
                <asp:TextBox ID="school" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <div id="collapse">
            <tr align="left">
                <td colspan="2">
                    <div style="text-align: left; margin-left: 25%">Представитель пациента:</div>
                </td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Фамилия*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="fiop"
                    ErrorMessage="Вы ввели не фамилию."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="fiop"
                        ErrorMessage="Вы не ввели фамилию"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="fiop" Width="150px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Имя*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="imp"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="imp"
                        ErrorMessage="Вы не ввели имя"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="imp" Width="150px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Отчество*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="otchp"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="otchp"
                        ErrorMessage="Вы не ввели отчество"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="otchp" Width="150px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px">Описание родства*:</td>
                <td width="120px">
                    <asp:DropDownList ID="rodstvo" Width="150px" runat="server">
                        <asp:ListItem Text="Мать" Value="Мать"></asp:ListItem>
                        <asp:ListItem Text="Отец" Value="Отец"></asp:ListItem>
                        <asp:ListItem Text="Опекун" Value="Опекун" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Отец" Value="Дедушка"></asp:ListItem>
                        <asp:ListItem Text="Бабушка" Value="Бабушка"></asp:ListItem>
                    </asp:DropDownList>


                </td>
            </tr>

            <tr align="left">
                <td width="120px">Документ*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pdoc"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pdoc"
                        ErrorMessage="Вы не ввели название документа"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pdoc" Width="150px" ToolTip="Документ удостоверяющий личность представителя пациента" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Серия и номер*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pser" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{4}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pser"
                        ErrorMessage="Вы не ввели серию"> 
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pnum" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{6}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pnum"
                        ErrorMessage="Вы не ввели номер"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pser" Width="50px"  MaxLength="4" ToolTip="Пример: 1234 123123" runat="server"></asp:TextBox>
                    <asp:TextBox ID="pnum" MaxLength="6" Width="100px" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr align="left">
                <td width="120px">Кем выдан*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pkem" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="pkem"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pkem" Width="150px" MaxLength="150" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Когда выдан*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="pkogda"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   </td>
                <td width="120px">
                    <asp:TextBox ID="pkogda" Width="150px" Text="<% DateTime.Now.ToShortDate %>" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Адрес проживания*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                    ControlToValidate="padr" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                        ControlToValidate="padr"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="padr" Width="150px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Телефон городской:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone"
                                    ErrorMessage="Вы ввели не номер. +7(xxx)xxx-xx-xx"
                                    ValidationExpression="^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$" />
                                </td>
                <td width="120px">
                    <asp:TextBox ID="pphone" Width="150px" TextMode="Phone" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px">Телефон сотовый*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="sphone"
                                    ErrorMessage="Вы ввели не номер. +7(xxx)xxx-xx-xx"
                                    ValidationExpression="^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$" />
                                <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="sphone"
                                    ErrorMessage="Вы не ввели номер. +7(xxx)xxx-xx-xx"> 
                                </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="sphone" Width="150px" TextMode="Phone" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px">Электронная почта*:<asp:RegularExpressionValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone2"
                                    ErrorMessage="Вы ввели не email."
                                    ValidationExpression="^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$" />
                                <asp:RequiredFieldValidator ValidationGroup="rreg" ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone2"
                                    ErrorMessage="Вы не ввели email"> 
                                </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pphone2" Width="150px" TextMode="Phone" runat="server"></asp:TextBox></td>
            </tr>

        </div>

        <tr align="left" style="margin-top: 20px">
            <td width="100px"></td>
            <td width="200px">
                <asp:Button ID="save" OnClick="SaveMyInformation" ValidationGroup="rreg" BorderStyle="Groove" Text="Сохранить" Width="100px" runat="server" /></td>
        </tr>
         <tr>
             <td colspan="2">
                 <div style="font:x-small">
               * поля обязательные для ввода
           </div>
             </td>
         </tr>


    </table>
</asp:Content>

