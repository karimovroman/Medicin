<%@ Page Title="Данные пациента" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="myinformation.aspx.cs" Inherits="myinformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <script runat="server">
        private DBase.MSSQL mssql = new DBase.MSSQL();    
        private int r = 0;
        
      void Page_Load(Object sender, EventArgs e)
      {
          if(!IsPostBack)
          {
              HttpCookie cookie = Request.Cookies["user"];
                pacid.Text = (cookie["iduser"]); 
              
          DBase.patient pat = new DBase.patient();
          DBase.predstavitel prt = new DBase.predstavitel();
          pat = mssql.Getpatient(Convert.ToInt32(pacid.Text));
          prt = mssql.GetPatientPredstavitel(Convert.ToInt32(pacid.Text));
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
           int w2 = 0;
           if (prt.Fio != null)
           {
               for (int i = 0; i < prt.Fio.Length; i++)
               {
                   if (Convert.ToString(prt.Fio.Substring(i, 1)) == " " && w == 0)
                   {
                       w = i;
                   }

                   if (Convert.ToString(prt.Fio.Substring(i, 1)) == " " && w != 0 && w2 == 0 && i > w)
                   {
                       w2 = i;
                   }

               }
               fiop.Text = prt.Fio.Substring(0, w - 1);
               imp.Text = prt.Fio.Substring(w + 1, w2 - w - 1);

               otchp.Text = prt.Fio.Substring(w2 + 1, prt.Fio.Length - w2 - 1);
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
      }
     
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
         if(Convert.ToInt32(daterozden.Text.Substring(6,4)) < 1997 || Convert.ToInt32(daterozden.Text.Substring(6,4)) > 2016)
         {
             HtmlGenericControl message = new HtmlGenericControl();
             message.InnerHtml = "<h5 style='color: Red'>Ошибка: Дата рождения! </h5>";
             mas.Controls.Add(message);
             
         }
         else {
             
         DBase.patient pat = new DBase.patient();    
         DBase.predstavitel prt = new DBase.predstavitel(); 
         //Пациент
         pat.School = school.Text;
         pat.PatientID = Convert.ToInt32(pacid.Text);
         pat.Fam = fam.Text;
         pat.Im = name.Text;
         pat.Otch = otch.Text;
         pat.Snils = snils.Text;
         pat.Inn = inn.Text;
         pat.Datr = daterozden.Text;
         pat.Mest = mesto.Text;
         pat.Vozr = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(daterozden.Text.Substring(6,4)));
         pat.Pol=pol.SelectedValue;
         pat.Dok = doc.Text;
         pat.Data = Convert.ToString(DateTime.Now);
         pat.Noms = numoms.Text;
         pat.Soms = seroms.Text;
         pat.Sem = sempol.SelectedValue;
         pat.Sernom = seriya.Text + numbers.Text;
         pat.Kemv = kemvidan.Text;
         pat.Rassa = rassa.Text;
         pat.Rabot = rabota.Text;
         pat.Datv = kogdavid.Text;
         pat.Typpolis = tipoms.SelectedValue;
         pat.Trud = hartrud.SelectedValue;
         pat.Strax = strahkom.SelectedValue;
         pat.Det = Convert.ToInt16(deti.Text);
         pat.Dms = dms.SelectedValue;
         pat.Datoms = datevid.Text;
         pat.Obraz = obraz.SelectedValue;
         pat.Dolg = dolj.Text;
         pat.Mo = Convert.ToInt32(mo.Text);
         pat.Oms = oms.Text;
         //Представитель пациента
         prt.Id = Convert.ToInt32(prtid.Text);
         prt.PatientID = Convert.ToInt32(pacid.Text);
         prt.Fio = fiop.Text + " " + imp.Text + " " + otchp.Text;
         prt.Rodstvo = rodstvo.SelectedValue;
         prt.Doc = pdoc.Text;
         prt.Num = pser.Text + pnum.Text;
         prt.Vidan = pkem.Text;
         prt.Kogda = pkogda.Text;
         prt.Address = padr.Text;

         prt.Sphone = sphone.Text;
         prt.Phone = pphone.Text;
         prt.Phone2= pphone2.Text;
         
         
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
                 message.InnerHtml = "<h5 style='color: Red'>При обновлении произошла ошибка! </h5>";
                 mas.Controls.Add(message);
             }
         }
         }
     }
         
      public void  CheckDate(object source, ServerValidateEventArgs args)
      {
          //args.IsValid = Convert.ToInt32(args.Value.Substring(6, 4)) >= 1997 && Convert.ToInt32(args.Value.Substring(6, 4)) <= 2015 && args.Value.Length == 10 && Convert.ToInt32(args.Value.Substring(0, 2)) > 0 && Convert.ToInt32(args.Value.Substring(0, 2)) < 32 && Convert.ToInt32(args.Value.Substring(3, 2)) > 0 && Convert.ToInt32(args.Value.Substring(3, 2)) < 13 && args.Value.Substring(2, 1) == "." && args.Value.Substring(5, 1) == ".";
          args.IsValid = args.Value == "1";
      }
    
   </script>
    
    
   
    
    <div id="mas" runat="server">
       </div>
    <div style="font-size:medium;width:100%;text-align:center">
        <asp:TextBox ID="mo" runat="server" Visible="false"></asp:TextBox>
    </div>
 <div style="font-size:medium;width:100%;text-align:center">
        Данные пациента:<asp:Label runat="server" ValidateRequestMode="Enabled"  ID="pacid" Visible="false"></asp:Label><asp:Label  ID="prtid" runat="server" Visible="false"></asp:Label>
    </div>  
    <table id="Table1" width="100%" style="margin-left: 100px">

        <tr align="center">
            <td>
            <tr align="left">
                <td width="120px">Фамилия*:
                <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="fam"
                    ErrorMessage="Вы ввели не фамилию."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="fam"
                        ErrorMessage="Вы не ввели фамилию"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="fam" Width="150px" onkeyup="check(this.value)" runat="server"></asp:TextBox></td>
            </tr>

        <tr align="left">
            <td width="120px">Имя*:
                <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="name" 
                    ErrorMessage="Вы ввели не имя."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="name"
                        ErrorMessage="Вы не ввели имя"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="name" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Отчество*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="otch"
                    ErrorMessage="Вы ввели не отчество."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="otch"
                        ErrorMessage="Вы не ввели отчество"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="otch" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">CНИЛС:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="snils"
                    ErrorMessage="Не верно"
                    ValidationExpression="[1234567890]{11}" />
                    </td>
            <td width="120px">
                <asp:TextBox ID="snils" MaxLength="11" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">ИНН:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="inn"
                    ErrorMessage="Не верно"
                    ValidationExpression="[1234567890]{12}" /></td>
            <td width="120px">
                <asp:TextBox ID="inn" MaxLength="12" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Дата рождения*: <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="daterozden"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="daterozden"
                        ErrorMessage="Вы не ввели дату"> 
                    </asp:RequiredFieldValidator><br />
                
            </td>
            <td width="120px">
                <asp:TextBox ID="daterozden" Width="150px"   Text="01.01.2015" runat="server"></asp:TextBox><asp:TextBox Visible="false" Width="150px" ID="vozrast" runat="server" Enabled="false"></asp:TextBox>
                &nbsp;</td>
        </tr>

        <tr align="left">
            <td width="120px">Место рождения*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="mesto" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
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
            <td width="120px">Серия и номер*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="seriya" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{4}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="seriya"
                        ErrorMessage="Вы не ввели серию"> 
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="numbers" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{6}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="numbers"
                        ErrorMessage="Вы не ввели номер"> 
                    </asp:RequiredFieldValidator>
            </td>
            <td width="120px">
                <asp:TextBox ID="seriya" Width="50px" MaxLength="4" runat="server"></asp:TextBox><asp:TextBox ID="numbers" MaxLength="6" Width="100px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Кем выдан*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="kemvidan" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="kemvidan"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="kemvidan" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Когда выдан*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="kogdavid"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="kogdavid"
                        ErrorMessage="Вы не ввели дату"> 
                    </asp:RequiredFieldValidator></td>
            <td width="120px">
                <asp:TextBox ID="kogdavid" Width="150px"   Text="01.01.2015" OnTextChanged="kogdavid_TextChanged" runat="server"></asp:TextBox></td>
        </tr>

        <tr align="left">
            <td width="120px">Гражданство:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="rassa" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,.-/]{1,150}" />
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
            <td width="120px">Количество детей:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
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
            <td width="120px">Место работы:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="rabota" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" />
                    </td>
            <td width="120px">
                <asp:TextBox ID="rabota" Width="150px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="tr2" align="left">
            <td width="120px">Должность:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
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
                <asp:DropDownList runat="server" id="oms" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="oms_SelectedIndexChanged" runat="server">
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
            <td width="120px">Номер полиса ОМС:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="numoms"
                    ErrorMessage="Не верно"
                    ValidationExpression="[0-9]{16}" /></td>
            <td width="120px">
                <asp:TextBox ID="numoms" MaxLength="16" Width="150px" runat="server" Height="22px"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="oms4" align="left">
            <td width="120px">Серия и номер бланка ОМС:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="seroms"
                    ErrorMessage="Не верно"
                    ValidationExpression="[0-9]{11}" />
                   </td>
            <td width="120px">
                <asp:TextBox ID="seroms" MaxLength="11" Width="150px" runat="server"></asp:TextBox></td>
        </tr>

        <tr runat="server" id="oms5" align="left">
            <td width="120px">Дата выдачи полиса ОМС:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="datevid"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   </td>
            <td width="120px">
                <asp:TextBox ID="datevid"  Width="150px" Text="01.01.2015" OnTextChanged="datevid_TextChanged" runat="server"></asp:TextBox></td>
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
            <td width="120px">Учебное заведение:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="school" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[[а-яА-Я\s*0-9,.-/]{1,150}" /></td>
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
                <td width="120px" style="height: 24px">Фамилия*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="fiop"
                    ErrorMessage="Вы ввели не фамилию."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="fiop"
                        ErrorMessage="Вы не ввели фамилию"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="fiop" Width="150px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Имя*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="imp"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="imp"
                        ErrorMessage="Вы не ввели имя"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px" style="height: 24px">
                    <asp:TextBox ID="imp" Width="150px" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px" style="height: 24px">Отчество*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="otchp"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
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
                <td width="120px">Документ*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="pdoc"
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*]{1,50}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="pdoc"
                        ErrorMessage="Вы не ввели название документа"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pdoc" Width="150px" ToolTip="Документ удостоверяющий личность представителя пациента" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Серия и номер*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="pser" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{4}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="pser"
                        ErrorMessage="Вы не ввели серию"> 
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="pnum" 
                    ErrorMessage="Вы ввели не цифры."
                    ValidationExpression="[0-9]{6}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="pnum"
                        ErrorMessage="Вы не ввели номер"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pser" Width="50px"  MaxLength="4" ToolTip="Пример: 1234 123123" runat="server"></asp:TextBox>
                    <asp:TextBox ID="pnum" MaxLength="6" Width="100px" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr align="left">
                <td width="120px">Кем выдан*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="pnum" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9,-;:]{1,150}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="pnum"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="pkem" Width="150px" MaxLength="150" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Когда выдан*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="pkogda"
                    ErrorMessage="Не верно"
                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   </td>
                <td width="120px">
                    <asp:TextBox ID="pkogda" Width="150px" Text="01.01.2015" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Адрес проживания*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                    ControlToValidate="padr" 
                    ErrorMessage="Вы ввели не текст."
                    ValidationExpression="[а-яА-Я\s*0-9]{1,150}" />
                    <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                        ControlToValidate="padr"
                        ErrorMessage="Вы не ввели текст"> 
                    </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="padr" Width="150px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            </tr>

            <tr align="left">
                <td width="120px">Телефон городской:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone"
                                    ErrorMessage="Вы ввели не номер. +7(xxx)xxx-xx-xx"
                                    ValidationExpression="^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$" />
                                </td>
                <td width="120px">
                    <asp:TextBox ID="pphone" Width="150px" TextMode="Phone" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px">Телефон сотовый*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="sphone"
                                    ErrorMessage="Вы ввели не номер. +7(xxx)xxx-xx-xx"
                                    ValidationExpression="^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="sphone"
                                    ErrorMessage="Вы не ввели номер. +7(xxx)xxx-xx-xx"> 
                                </asp:RequiredFieldValidator></td>
                <td width="120px">
                    <asp:TextBox ID="sphone" Width="150px" TextMode="Phone" runat="server"></asp:TextBox></td>
            </tr>
            <tr align="left">
                <td width="120px">Электронная почта*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="pphone2"
                                    ErrorMessage="Вы ввели не email."
                                    ValidationExpression="^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
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
                <asp:Button ID="save" OnClick="SaveMyInformation" BorderStyle="Groove" Text="Сохранить" Width="100px" runat="server" /></td>
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

