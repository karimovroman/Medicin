<%@ Page Title="Электронная медицинская карта" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="mycard.aspx.cs" Inherits="mycard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    
    <script runat="server">
       private DBase.MSSQL mssql = new DBase.MSSQL();    
        private int r = 0;
        int pacid = 0;
      void Page_Load(Object sender, EventArgs e)
      {
          if(!IsPostBack)
          { 
              
          HttpCookie cookie = Request.Cookies["user"];
          pacid = Convert.ToInt32(cookie["iduser"]); 
          
          DBase.MSSQL mssql = new DBase.MSSQL();
          
          //Подгружаем все данные
          DBase.patient pat = new DBase.patient();
          pat = mssql.Getpatient(pacid);
          
          fio.Text = pat.Fam + " " + pat.Im + " " + pat.Otch;
          List<DBase.osmotr> osm = new List<DBase.osmotr>();
          osm = mssql.GetOsmotr(pacid);

          List<DBase.metrika> metr = new List<DBase.metrika>();
          metr = mssql.GetAllMetriks(pacid);
          
          //Подгружаем даты в дропдаунлисты
          foreach(DBase.metrika m in metr)
          {
              DropDownList1.Items.Add(new ListItem(m.Date, Convert.ToString(m.Id)));
          }

          foreach (DBase.osmotr o in osm)
          {
              DropDownList2.Items.Add(new ListItem(o.Data, Convert.ToString(o.Id)));
          }

          List<DBase.emk> emks = mssql.GetEmk(pacid);
          emks.Reverse();
          if (emks.Count != 0)
          {
              
          DBase.emk emk = emks.First();
          
            //Заполняем поля данными
            grupa.Text = emk.Grupkrov;
            rezus.Text = emk.Rezus;
            rebenok.Text = emk.Kategreben;
            katyceta.Text = emk.Kategsocial;
            zdorgrupa.Text = emk.Grupzdorov;
            kyren.Text = emk.Kyrenie;
            alkog.Text = emk.Alcogol;
            narkom.Text = emk.Narkot;
            allerg.Text = emk.Alerg;
            neperen.Text = emk.Neperen;
            xarak.Text = emk.Haract;
            semanam.Text = emk.Anamnez;
            inval.Text = emk.Invalid;
            otkl.Text = emk.Otklon;
            psihmot.Text = emk.Psihomotor;
            intel.Text = emk.Intelect;

          }
          else
          {
              all.Visible = false;
              ifnot.Text = "Данных еще нет. " + "<a href=\"patient.aspx\">Вернуться</a>";
          }
            if(metr.Count != 0 && osm.Count != 0)
            {
                
            DBase.metrika metrika = metr.Last();
            DBase.osmotr osmotr = osm.Last();

            mgolov.Text = metrika.Okrgol;
            mgrud.Text = metrika.Okrgrud;
            mtalia.Text = metrika.Okrtal;
            mtemp.Text = metrika.Temper;
            mchdd.Text = metrika.Chastota;
            mrost.Text = metrika.Rost;
            mmasa.Text = metrika.Massa;
            mimt.Text = metrika.Indeks;
            msis.Text = metrika.Sistol;
            mdias.Text = metrika.Diastol;
            mpuls.Text = metrika.Puls;
            mkom.Text = metrika.About;

            nsimptom.Text = osmotr.Simpt;
            nrezultat.Text = osmotr.Result;
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> diagnz = new List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz>();
            
                diagnz = mysql.SelectZabDiagnoz();
                
              foreach(MySqlLib.MySqlData.MySqlExecute.zabdiagnoz d in diagnz)
              {
                  if(d.id == osmotr.Iddiag)
                  {
                      ndiagnoz.Text = d.name;
                  }
              }
              nkoment.Text = osmotr.Comm;

            }
              else
            {
                metricsplace.Visible = false;
                osmotrplace.Visible = false;
            }
            reclist.Visible = false;
              List<DBase.listv> lists = new List<DBase.listv>();
              
              if (lists.Count != 0)
              { 
                  
              }
              
          }
      }
      protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
      {

          DBase.MSSQL mssql = new DBase.MSSQL();
          List<DBase.metrika> metr = new List<DBase.metrika>();
          metr = mssql.GetAllMetriks(pacid);
          foreach(DBase.metrika metrika in metr)
          { 
              if(metrika.Date == DropDownList1.SelectedItem.Text)
              { 
                  mgolov.Text = metrika.Okrgol;
                  mgrud.Text = metrika.Okrgrud;
                  mtalia.Text = metrika.Okrtal;
                  mtemp.Text = metrika.Temper;
                  mchdd.Text = metrika.Chastota;
                  mrost.Text = metrika.Rost;
                  mmasa.Text = metrika.Massa;
                  mimt.Text = metrika.Indeks;
                  msis.Text = metrika.Sistol;
                  mdias.Text = metrika.Diastol;
                  mpuls.Text = metrika.Puls;
                  mkom.Text = metrika.About;
              }
          }
      }
      protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
      {

          DBase.MSSQL mssql = new DBase.MSSQL();
          List<DBase.osmotr> osm = new List<DBase.osmotr>();
          osm = mssql.GetOsmotr(pacid);
          foreach (DBase.osmotr osmotr in osm)
          {
              if (osmotr.Data == DropDownList2.SelectedItem.Text)
              {
                  nsimptom.Text = osmotr.Simpt;
                  nrezultat.Text = osmotr.Result;
                  MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
                  List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> diagnz = new List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz>();
                  diagnz = mysql.SelectZabDiagnoz();
                  foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz d in diagnz)
                  {
                      if (d.id == osmotr.Iddiag)
                      {
                          ndiagnoz.Text = d.name;
                      }
                  }
                  nkoment.Text = osmotr.Comm;
              }
          }
      }
     
   </script>
    


    <div id="accordion">
    <!-- Вывод основной электронной карты -->
    <div id="emc" class="view-source">
        
<div style="font-size:medium;width:100%;text-align:center">
        Электронная медицинская карта пациента <asp:Label ID="fio" runat="server" Text="ФИО"></asp:Label>
        <br /> 
        <asp:Label ID="ifnot" runat="server" Text =""></asp:Label>
</div>  
    <div runat="server">
    <div  id="all" runat="server">
     <table  id="emk-t" width ="100%" style="margin-left:100px"  >
           
        <tr align=center>
        <td>
        <tr align="left">
            <td Width="120px">Группа крови:</td>
            <td  width="120px"><asp:Label  ID="grupa" Width="120px" runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">Резус фактур:</td>
            <td  width="120px"><asp:Label  ID="rezus" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Категория ребенка:</td>
            <td  width="120px"><asp:Label  ID="rebenok" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Категория учета в трудной ситуации:</td>
            <td  width="120px"><asp:Label  ID="katyceta" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Группа здоровья:</td>
            <td  width="120px"><asp:Label  ID="zdorgrupa" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px"><p>Вредные привычки пациента</p>Курение:</td>
            <td  width="120px"><p></p>
                <asp:Label  ID="kyren" Width="120px" runat="server"></asp:Label>
                &nbsp;</td></tr>

            <tr align="left">
            <td Width="120px">Алкоголизм:</td>
            <td  width="120px"><asp:Label  ID="alkog" Width="120px"  runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Наркомания:</td>
            <td  width="120px"><asp:Label  ID="narkom" TextMode="Number" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Аллергический анамнез:</td>
            <td  width="120px"><asp:Label  ID="allerg" TextMode="Number" Width="120px" runat="server"></asp:Label></td></tr>

            <tr align="left">
            <td Width="120px">Непереносимость препаратов:</td>
            <td  width="120px"><asp:Label  ID="neperen" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Характерные особенности:</td>
            <td  width="120px"><asp:Label  ID="xarak"  Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Семейный анамнез:</td>
            <td  width="120px"><asp:Label  ID="semanam" Width="120px"   runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Инвалидность:</td>
            <td  width="120px"><asp:Label  ID="inval" Width="120px"  runat="server"></asp:Label></td></tr>
          
           <tr align="left">
            <td Width="120px">Отклонения развития:</td>
            <td  width="120px"><asp:Label  ID="otkl" Width="120px"  runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">Психомоторные функции:</td>
            <td  width="120px"><asp:Label  ID="psihmot" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Интелект:</td>
            <td  width="120px"><asp:Label  ID="intel" Width="120px"  runat="server"></asp:Label></td></tr>
         
        </table>
        </div>
   
        
   <!--Блок выводит метрики -->
     <div id="metricsplace" runat="server">
    <div style="font-size:medium;width:100%;text-align:center">Метрики пациента.
        Дата записи:
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
    </div>  
    <div >
     <table  id="metrika-t" width ="100%" style="margin-left:100px" >
           
        <tr align=center>
        <td>
        <tr align="left">
            <td Width="120px">Окружность головы:</td>
            <td  width="120px"><asp:Label  ID="mgolov" Width="120px" runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">Окружность груди:</td>
            <td  width="120px"><asp:Label  ID="mgrud" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Окружность талии:</td>
            <td  width="120px"><asp:Label  ID="mtalia" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Температура тела:</td>
            <td  width="120px"><asp:Label  ID="mtemp" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Частота дыхательных движений:</td>
            <td  width="120px">
                <asp:Label  ID="mchdd" Width="120px" runat="server"></asp:Label>
                &nbsp;</td></tr>

            <tr align="left">
            <td Width="120px">Рост пациента:</td>
            <td  width="120px"><asp:Label  ID="mrost" Width="120px"  runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Масса тела:</td>
            <td  width="120px"><asp:Label  ID="mmasa"  Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Индекс массы тела:</td>
            <td  width="120px"><asp:Label  ID="mimt"  Width="120px" runat="server"></asp:Label></td></tr>

            <tr align="left">
            <td Width="120px">Систолическое давление:</td>
            <td  width="120px"><asp:Label  ID="msis"  Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Диастолическое давление:</td>
            <td  width="120px"><asp:Label  ID="mdias" Width="120px"   runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Пульс:</td>
            <td  width="120px"><asp:Label  ID="mpuls" Width="120px"  runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">Комментарии:</td>
            <td  width="120px"><asp:Label  ID="mkom" Width="120px"  runat="server"></asp:Label></td></tr>
         
        </table>
        </div>
        </div>
   <!--Блок выводит врачебные осмотры -->
    <div id="osmotrplace" runat="server">
        <div style="font-size:medium;width:100%;text-align:center">Врачебный осмотр.    Дата записи:
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList> 
    </div>  
    <div>
     <table  id="osmotr-t" width ="100%" style="margin-left:100px" >
           
        <tr align=center>
        <td>
        <tr align="left">
            <td Width="120px">Симптомы или жалобы:</td>
            <td  width="120px"><asp:Label  ID="nsimptom" Width="120px" runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">Результаты осмотра:</td>
            <td  width="120px"><asp:Label  ID="nrezultat" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Диагноз:</td>
            <td  width="120px"><asp:Label  ID="ndiagnoz" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Комментарий:</td>
            <td  width="120px"><asp:Label  ID="nkoment" Width="120px" runat="server"></asp:Label></td></tr>
          
         
         <!-- Новорожденый 
            <tr align="left">
            <td Width="120px">День жизни:</td>
            <td  width="120px"><asp:Label  ID="nden" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Температура:</td>
            <td  width="120px">
                <asp:Label  ID="ntemper" Width="120px" runat="server"></asp:Label>
                &nbsp;</td></tr>

            <tr align="left">
            <td Width="120px">Вес тела:</td>
            <td  width="120px"><asp:Label  ID="nvestel" Width="120px"  runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Динамика массы тела:</td>
            <td  width="120px"><asp:Label  ID="ndinamik"  Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Состояние:</td>
            <td  width="120px"><asp:Label  ID="nsosto"  Width="120px" runat="server"></asp:Label></td></tr>

            <tr align="left">
            <td Width="120px">Видимые пороки развития:</td>
            <td  width="120px"><asp:Label  ID="nvidporoki" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Малые пороки развития:</td>
            <td  width="120px"><asp:Label  ID="nmalporoki"  Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Поза при рождении:</td>
            <td  width="120px"><asp:Label  ID="npoza" Width="120px"   runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Мышечный тонус:</td>
            <td  width="120px"><asp:Label  ID="nmishech" Width="120px"  runat="server"></asp:Label></td></tr>
          
           <tr align="left">
            <td Width="120px">Рефлексы:</td>
            <td  width="120px"><asp:Label  ID="nrefleks" Width="120px"  runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">ЧСС уд/мин:</td>
            <td  width="120px"><asp:Label  ID="nchss" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Дыхание при рождении:</td>
            <td  width="120px"><asp:Label  ID="ndihanie" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Наружные половые признаки:</td>
            <td  width="120px"><asp:Label  ID="npolov" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Жалобы матери:</td>
            <td  width="120px"><asp:Label  ID="njalob" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Заболевания новорожденого:</td>
            <td  width="120px"><asp:Label  ID="nzabol" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Дополнительные данные о здоровье:</td>
            <td  width="120px"><asp:Label  ID="ndop" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Особенности:</td>
            <td  width="120px"><asp:Label  ID="nosob" Width="120px"  runat="server"></asp:Label></td></tr>
         
            <tr align="left">
            <td Width="120px">Комментарии:</td>
            <td  width="120px"><asp:Label  ID="nkom" Width="120px"  runat="server"></asp:Label></td></tr>
         -->

        </table>
        </div>
    </div>
   <!--Блок выводит рецепты и листы нетрудоспособности -->
    <div id="reclist" runat="server">

            <div style="font-size:medium;width:100%;text-align:center">Лист нетрудоспособности    
    </div>  
    <div>
     <table  id="list-t" width ="100%" style="margin-left:100px" >     
        <tr align=center>
        <td>
        <tr align="left">
            <td Width="120px">Номер и серия:</td>
            <td  width="120px"><asp:Label  ID="lnumser" Width="120px" runat="server"></asp:Label></td></tr>
           
            <tr align="left">
            <td Width="120px">Причина выдачи:</td>
            <td  width="120px"><asp:Label  ID="lprichina" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Заболевание:</td>
            <td  width="120px"><asp:Label  ID="lzabol" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Дата начала больничного:</td>
            <td  width="120px"><asp:Label  ID="ldatn" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Дата окончания больничного:</td>
            <td  width="120px"><asp:Label  ID="ldatk" Width="120px" runat="server"></asp:Label></td></tr>
          
            <tr align="left">
            <td Width="120px">Число дней нетрудоспособности:</td>
            <td  width="120px">
                <asp:Label  ID="ldnei" Width="120px" runat="server"></asp:Label>
                &nbsp;</td></tr>
        </table>
        </div>
    </div>

    </div>
</asp:Content>

