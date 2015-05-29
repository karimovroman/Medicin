using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Web.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

//Работа с бозой данных MSSQL
namespace DBase
{
    /// <summary>
    /// Класс отвечающий за генерацию пароля
    /// </summary>
    public class password
    {
        //генератор случайных чисел
        Random rnd = new Random();

        StringBuilder str = new StringBuilder(8);

        //несколько символов: #-35, $-36, %-37, &-38, *-42, @-64
        List<int> Symbols = new List<int> { 35, 36, 37, 38, 42, 64 };

        /// <summary>
        /// Процедура генерации пароля из 8 символов
        /// </summary>
        /// <returns>
        /// Возвращает строку пароля
        /// </returns>
        public string generate()
        {
            str.Clear();

            for (int i = 0; i < 2; i++)
            {
                str.Append(((char)rnd.Next(48, 59)).ToString() +
                             (char)rnd.Next(65, 92) +
                             (char)rnd.Next(97, 124) +
                             (char)Symbols[rnd.Next(0, 6)]);
            }

            return Convert.ToString(str);
        }
    }
    /// <summary>
    /// Класс обьекта пациент
    /// </summary>
    public class patient
    {
        public patient(int patientID, 
            string data,
            string snils, 
            string inn,
            string fam,
            string im,
            string otch,
            string datr,
            string mest,
            string vozr,
            string pol,
            string dok,
            string sernom,
            string kemv,
            string datv,
            string rassa,
            string sem,
            int det,
            string obraz,
            string rabot,
            string dolg,
            string trud,
            string oms,
            string strax,
            string typpolis,
            string soms,
            string noms,
            string datoms,
            string dms,
            string school,
            int mo)
        {
            this.patientID = patientID;
            this.data = data;
            this.snils = snils;
            this.inn = inn;
            this.fam = fam;
            this.im = im;
            this.otch = otch;
            this.datr = datr;
            this.mest = mest;
            this.vozr = vozr;
            this.pol = pol;
            this.dok = dok;
            this.sernom = sernom;
            this.kemv = kemv;
            this.datv = datv;
            this.rassa = rassa;
            this.sem = sem;
            this.det = det;
            this.obraz = obraz;
            this.rabot = rabot;
            this.dolg = dolg;
            this.trud = trud;
            this.oms = oms;
            this.strax = strax;
            this.typpolis = typpolis;
            this.soms = soms;
            this.noms = noms;
            this.datoms = datoms;
            this.dms = dms;
            this.mo = mo;
            this.school = school;
        }

        public patient() { }

        private int patientID;
        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private string snils;
        public string Snils
        {
            get { return snils; }
            set { snils = value; }
        }

        private string inn;
        public string Inn
        {
            get { return inn; }
            set { inn = value; }
        }

        private string fam;
        public string Fam
        {
            get { return fam; }
            set { fam = value; }
        }

        private string im;
        public string Im
        {
            get { return im; }
            set { im = value; }
        }

        private string otch;
        public string Otch
        {
            get { return otch; }
            set { otch = value; }
        }

        private string datr;
        public string Datr
        {
            get { return datr; }
            set { datr = value; }
        }

        private string mest;
        public string Mest
        {
            get { return mest; }
            set { mest = value; }
        }

        private string vozr;
        public string Vozr
        {
            get { return vozr; }
            set { vozr = value; }
        }

        private string pol;
        public string Pol
        {
            get { return pol; }
            set { pol = value; }
        }

        private string dok;
        public string Dok
        {
            get { return dok; }
            set { dok = value; }
        }

        private string sernom;
        public string Sernom
        {
            get { return sernom; }
            set { sernom = value; }
        }

        private string kemv;
        public string Kemv
        {
            get { return kemv; }
            set { kemv = value; }
        }

        private string datv;
        public string Datv
        {
            get { return datv; }
            set { datv = value; }
        }

        private string rassa;
        public string Rassa
        {
            get { return rassa; }
            set { rassa = value; }
        }

        private string sem;
        public string Sem
        {
            get { return sem; }
            set { sem = value; }
        }

        private int det;
        public int Det
        {
            get { return det; }
            set { det = value; }
        }
        private int mo;
        public int Mo
        {
            get { return mo; }
            set { mo = value; }
        }

        private string obraz;
        public string Obraz
        {
            get { return obraz; }
            set { obraz = value; }
        }

        private string rabot;
        public string Rabot
        {
            get { return rabot; }
            set { rabot = value; }
        }

        private string dolg;
        public string Dolg
        {
            get { return dolg; }
            set { dolg = value; }
        }

        private string trud;
        public string Trud
        {
            get { return trud; }
            set { trud = value; }
        }

        private string oms;
        public string Oms
        {
            get { return oms; }
            set { oms = value; }
        }

        private string strax;
        public string Strax
        {
            get { return strax; }
            set { strax = value; }
        }

        private string typpolis;
        public string Typpolis
        {
            get { return typpolis; }
            set { typpolis = value; }
        }

        private string soms;
        public string Soms
        {
            get { return soms; }
            set { soms = value; }
        }

        private string noms;
        public string Noms
        {
            get { return noms; }
            set { noms = value; }
        }

        private string school;
        public string School
        {
            get { return school; }
            set { school = value; }
        }

        private string datoms;
        public string Datoms
        {
            get { return datoms; }
            set { datoms = value; }
        }

        private string dms;
        public string Dms
        {
            get { return dms; }
            set { dms = value; }
        }
    }
    /// <summary>
    /// Представитель пациента
    /// </summary>
    public class predstavitel
    {
        public predstavitel(int id,
            int patientID,
            string fio,
            string rodstvo,
            string doc,
            string num,
            string vidan,
            string kogda,
            string address,
            string sphone,
            string phone,
            string phone2)
        {
            this.id = id;
            this.patientID = patientID;
            this.fio = fio;
            this.rodstvo = rodstvo;
            this.doc = doc;
            this.num = num;
            this.vidan = vidan;
            this.kogda = kogda;
            this.address = address;
            this.sphone = sphone;
            this.phone = phone;
            this.phone2 = phone2;
        }

        public predstavitel() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int patientID;
        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        private string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        private string rodstvo;
        public string Rodstvo
        {
            get { return rodstvo; }
            set { rodstvo = value; }
        }

        private string doc;
        public string Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        private string num;
        public string Num
        {
            get { return num; }
            set { num = value; }
        }

        private string vidan;
        public string Vidan
        {
            get { return vidan; }
            set { vidan = value; }
        }

        private string kogda;
        public string Kogda
        {
            get { return kogda; }
            set { kogda = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string sphone;
        public string Sphone
        {
            get { return sphone; }
            set { sphone = value; }
        }
        private string phone2;
        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }
    }
    public class doctordesk
    {
        public doctordesk(int id,
            string code,
            string data,
            string time,
            int pacientID,
            int doctorID,
            int mo)
        {
            this.id = id;
            this.doctorID = doctorID;
            this.code = code;
            this.pacientID = pacientID;
            this.data = data;
            this.time = time;
            this.mo = mo;
        }

        public doctordesk() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int doctorID;
        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        private int mo;
        public int Mo
        {
            get { return mo; }
            set { mo = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        private int pacientID;
        public int PacientID
        {
            get { return pacientID; }
            set { pacientID = value; }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

       
    }
    /// <summary>
    /// Расписание работы
    /// </summary>
    public class doctordesks
    {
        public doctordesks(
            int id,
            
            string data,
            string time,
            int doctorID,
            int mo)
        {
            this.id = id;
            this.doctorID = doctorID;
          
            this.data = data;
            this.time = time;
            this.mo = mo;
        }

        public doctordesks() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int doctorID;
        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        private int mo;
        public int Mo
        {
            get { return mo; }
            set { mo = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
       

        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }


    }
    /// <summary>
    /// Посещение врача
    /// </summary>
    public class successvisit
    {
        public successvisit(
            int id,

            int idvisits,
            int success)
        {
            this.id = id;
            this.idvisits = idvisits;

            this.success = success;
        }

        public successvisit() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idvisits;
        public int Idvisits
        {
            get { return idvisits; }
            set { idvisits = value; }
        }

        private int success;
        public int Success
        {
            get { return success; }
            set { success = value; }
        }

       


    }
    public class successdesk
    {
        public successdesk(
            int id,

            int idvisits,
            int success)
        {
            this.id = id;
            this.idvisits = idvisits;

            this.success = success;
        }

        public successdesk() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idvisits;
        public int Idvisits
        {
            get { return idvisits; }
            set { idvisits = value; }
        }

        private int success;
        public int Success
        {
            get { return success; }
            set { success = value; }
        }




    }
     /// <summary>
    /// Посещение услуги
    /// </summary>
    public class successervice
    {
        public successervice(
            int id,

            int idservtime,
            int success)
        {
            this.id = id;
            this.idservtime = idservtime;

            this.success = success;
        }

        public successervice() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idservtime;
        public int Idservtime   
{
            get { return idservtime; }
            set { idservtime = value; }
        }

        private int success;
        public int Success
        {
            get { return success; }
            set { success = value; }
        }




    }
    /// <summary>
    /// Обьект время записи на услугу
    /// </summary>
    public class servicetime
    {
        public servicetime(int id,
            int idpac,
            string data,
            string time,
            
            int service)
        {
            this.id = id;
            this.idpac = idpac;
              this.data = data;
            this.time = time;
            this.service = service;
        }

        public servicetime() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int idpac;
        public int Idpac
        {
            get { return idpac; }
            set { idpac = value; }
        }
       
        private int service;
        public int Service
        {
            get { return service; }
            set { service = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
       
        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }


    }
    /// <summary>
    /// Врач
    /// </summary>
    public class doctor
    {
        public doctor(int id,
            string name,
            string sur,
            string mid,
            string dolj,
            string mo,
            string kabin,
            int idspec,
            string kvalif)
        {
            this.Id = id;
            this.Name = name;
            this.Sur = sur;
            this.Mid = mid;
            this.Dolj = dolj;
            this.Mo = mo;
            this.Kabin = kabin;
            this.Idspec = idspec;
            this.Kvalif = kvalif;
            
        }

        public doctor() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string sur;
        public string Sur
        {
            get { return sur; }
            set { sur = value; }
        }

        private string mid;
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        private string dolj;
        public string Dolj
        {
            get { return dolj; }
            set { dolj = value; }
        }

        private string mo;
        public string Mo
        {
            get { return mo; }
            set { mo = value; }
        }

        private string kabin;
        public string Kabin
        {
            get { return kabin; }
            set { kabin = value; }
        }

        private int idspec;
        public int Idspec
        {
            get { return idspec; }
            set { idspec = value; }
        }

        private string kvalif;
        public string Kvalif
        {
            get { return kvalif; }
            set { kvalif = value; }
        }
    }
    /// <summary>
    /// Врач
    /// </summary>
    public class registr
    {
        public registr(int id,
            string fio,
            string email,
            string phone)
        {
            this.Id = id;
            this.Fio = fio;
            this.Email = email;

            this.Phone = phone;

        }

        public registr() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

       
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
    /// <summary>
    /// Карта пациента
    /// </summary>
    public class emk
    {
        public emk(int id,
            int idp,
            string grupkrov,
            string rezus,
            string kategreben,
            string kategsocial,
            string grupzdorov,
            string kyrenie,
            string alcogol,
            string narkot,
            string alerg,
            string neperen,
            string haract,
            string anamnez,
            string invalid,
            string otklon,
            string psihomotor,
            string intelect,
            string time,
            int medrab)
        {
            this.Id = id;
            this.Idp = idp;
            this.Grupkrov = grupkrov;
            this.Rezus = rezus;
            this.Kategreben = kategreben;
            this.Kategsocial = kategsocial;
            this.Grupzdorov = grupzdorov;
            this.Kyrenie = kyrenie;
            this.Alcogol = alcogol;
            this.Narkot = narkot;
            this.Alerg = alerg;
            this.Neperen = neperen;
            this.Haract = haract;
            this.Anamnez = anamnez;
            this.Invalid = invalid;
            this.Otklon = otklon;
            this.Psihomotor = psihomotor;
            this.Intelect = intelect;
            this.Time = time;
            this.Medrab = medrab;
        }

        public emk() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idp;
        public int Idp
        {
            get { return idp; }
            set { idp = value; }
        }

        private string grupkrov;
        public string Grupkrov
        {
            get { return grupkrov; }
            set { grupkrov = value; }
        }

        private string rezus;
        public string Rezus
        {
            get { return rezus; }
            set { rezus = value; }
        }

        private string kategreben;
        public string Kategreben
        {
            get { return kategreben; }
            set { kategreben = value; }
        }

        private string kategsocial;
        public string Kategsocial
        {
            get { return kategsocial; }
            set { kategsocial = value; }
        }

        private string grupzdorov;
        public string Grupzdorov
        {
            get { return grupzdorov; }
            set { grupzdorov = value; }
        }

        private string kyrenie;
        public string Kyrenie
        {
            get { return kyrenie; }
            set { kyrenie = value; }
        }

        private string alcogol;
        public string Alcogol
        {
            get { return alcogol; }
            set { alcogol = value; }
        }

        private string narkot;
        public string Narkot
        {
            get { return narkot; }
            set { narkot = value; }
        }

        private string alerg;
        public string Alerg
        {
            get { return alerg; }
            set { alerg = value; }
        }

        private string neperen;
        public string Neperen
        {
            get { return neperen; }
            set { neperen = value; }
        }

        private string haract;
        public string Haract
        {
            get { return haract; }
            set { haract = value; }
        }

        private string anamnez;
        public string Anamnez
        {
            get { return anamnez; }
            set { anamnez = value; }
        }

        private string invalid;
        public string Invalid
        {
            get { return invalid; }
            set { invalid = value; }
        }

        private string otklon;
        public string Otklon
        {
            get { return otklon; }
            set { otklon = value; }
        }

        private string psihomotor;
        public string Psihomotor
        {
            get { return psihomotor; }
            set { psihomotor = value; }
        }

        private string intelect;
        public string Intelect
        {
            get { return intelect; }
            set { intelect = value; }
        }

        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        private int medrab;
        public int Medrab
        {
            get { return medrab; }
            set { medrab = value; }
        }
    }
    /// <summary>
    /// Метрики пациента
    /// </summary>
    public class metrika
    {
        public metrika(
            int id,
            int idp,
            string okrgol,
            string okrgrud,
            string okrtal,
            string temper,
            string chastota,
            string rost,
            string massa,
            string indeks,
            string sistol,
            string diastol,
            string puls,
            string about,
            string date,
            int medrab)
        {
            this.Id = id;
            this.Idp = idp;
            this.Okrgol = okrgol;
            this.Okrgrud = okrgrud;
            this.Okrtal = okrtal;
            this.Temper = temper;
            this.Chastota = chastota;
            this.Rost = rost;
            this.Massa = massa;
            this.Indeks = indeks;
            this.Sistol = sistol;
            this.Diastol = diastol;
            this.Puls = puls;
            this.About = about;
            this.Date = date;
            this.Medrab = medrab;
        }

        public metrika() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idp;
        public int Idp
        {
            get { return idp; }
            set { idp = value; }
        }

        private string okrgol;
        public string Okrgol
        {
            get { return okrgol; }
            set { okrgol = value; }
        }

        private string okrgrud;
        public string Okrgrud
        {
            get { return okrgrud; }
            set { okrgrud = value; }
        }

        private string okrtal;
        public string Okrtal
        {
            get { return okrtal; }
            set { okrtal = value; }
        }

        private string temper;
        public string Temper
        {
            get { return temper; }
            set { temper = value; }
        }

        private string chastota;
        public string Chastota
        {
            get { return chastota; }
            set { chastota = value; }
        }

        private string rost;
        public string Rost
        {
            get { return rost; }
            set { rost = value; }
        }

        private string massa;
        public string Massa
        {
            get { return massa; }
            set { massa = value; }
        }

        private string indeks;
        public string Indeks
        {
            get { return indeks; }
            set { indeks = value; }
        }

        private string sistol;
        public string Sistol
        {
            get { return sistol; }
            set { sistol = value; }
        }

        private string diastol;
        public string Diastol
        {
            get { return diastol; }
            set { diastol = value; }
        }

        private string puls;
        public string Puls
        {
            get { return puls; }
            set { puls = value; }
        }

        private string about;
        public string About
        {
            get { return about; }
            set { about = value; }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

       

        private int medrab;
        public int Medrab
        {
            get { return medrab; }
            set { medrab = value; }
        }
    }
    /// <summary>
    /// Исследования здоровья
    /// </summary>
    public class isledovanie
    {
        public isledovanie(int id,
            int idp,
            string name,
            string result,
            string about,
            string data,
            string files,
            string diag,
            int idk,
            int idv )
        {
            this.Id = id;
            this.Idp = idp;
            this.Idk = idk;
            this.Idv = idv;
            this.Name = name;
            this.Result = result;
            this.Diagnoz = diag;
            this.Files = files;
            this.About = about;
            this.Data = data;
        }

        public isledovanie() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idp;
        public int Idp
        {
            get { return idp; }
            set { idp = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string diagnoz;
        public string Diagnoz
        {
            get { return diagnoz; }
            set { diagnoz = value; }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private string files;
        public string Files
        {
            get { return files; }
            set { files = value; }
        }

        private string about;
        public string About
        {
            get { return about; }
            set { about = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private int idk;
        public int Idk
        {
            get { return idk; }
            set { idk = value; }
        }

        private int idv;
        public int Idv
        {
            get { return idv; }
            set { idv = value; }
        }
    }
    /// <summary>
    /// Курс лечения
    /// </summary>
    public class kyrs
    {
        public kyrs(int id,
            int idr,
            string databeg,
            string dataend,
            int prin,
            int prop,
            string period,
            string fizio)
        {
            this.Id = id;
            this.Idr = idr;
            this.Databeg = databeg;
            this.Dataend = dataend;
            this.Prin = prin;
            this.Prop = prop;
            this.Period = period;
            this.fizio = fizio;
        }

        public kyrs() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idr;
        public int Idr
        {
            get { return idr; }
            set { idr = value; }
        }

        private string databeg;
        public string Databeg
        {
            get { return databeg; }
            set { databeg = value; }
        }

        private string dataend;
        public string Dataend
        {
            get { return dataend; }
            set { dataend = value; }
        }

        private int prin;
        public int Prin
        {
            get { return prin; }
            set { prin = value; }
        }

        private int prop;
        public int Prop
        {
            get { return prop; }
            set { prop = value; }
        }

        private string period;
        public string Period
        {
            get { return period; }
            set { period = value; }
        }

        private string fizio;
        public string Fizio
        {
            get { return fizio; }
            set { fizio = value; }
        }
       
    }
    public class mo
    {
        public mo(int id,
            
            string name,
            string adres,
            string phone,
            string bik,
            string lico,
            string licenz,
            string kpp,
            string inn,
            string email)
        {
            this.Id = id;
            
            this.Name = name;
            this.Adres = adres;
            this.Bik = bik;
            this.Lico = lico;
            this.Licenz = licenz;
            this.Kpp = kpp;
            this.Inn = inn;
           
            this.Phone = phone;
            this.Email = email;
        }

        public mo() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string bik;
        public string Bik
        {
            get { return bik; }
            set { bik = value; }
        }

        private string lico;
        public string Lico
        {
            get { return lico; }
            set { lico = value; }
        }

        private string licenz;
        public string Licenz
        {
            get { return licenz; }
            set { licenz = value; }
        }

        private string kpp;
        public string Kpp
        {
            get { return kpp; }
            set { kpp = value; }
        }

        private string inn;
        public string Inn
        {
            get { return inn; }
            set { inn = value; }
        }

        private string adres;
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
    /// <summary>
    /// Рецепт
    /// </summary>
    public class recept
    {
        public recept(int id,
            int idp,
            int idv,
            string regnom,
            string serial,
            string number,
            string data,
            int idl,
            string forma,
            string doza,
            string kratnost,
            string kolvodoz,
            string profilakt)
        {
            this.Id = id;
            this.Idp = idp;
            this.Idv = idv;
            this.Regnom = regnom;
            this.Serial = serial;
            this.Number = number;
            this.Data = data;
            this.Idl = idl;
            this.Forma = forma;
            this.Doza = doza;
            this.Kratnost = kratnost;
            this.Kolvodoz = kolvodoz;
            this.Profilakt = profilakt;
        }

        public recept() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idp;
        public int Idp
        {
            get { return idp; }
            set { idp = value; }
        }

        private int idv;
        public int Idv
        {
            get { return idv; }
            set { idv = value; }
        }

        private string regnom;
        public string Regnom
        {
            get { return regnom; }
            set { regnom = value; }
        }

        private string serial;
        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }

        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private int idl;
        public int Idl
        {
            get { return idl; }
            set { idl = value; }
        }

        private string forma;
        public string Forma
        {
            get { return forma; }
            set { forma = value; }
        }

        private string doza;
        public string Doza
        {
            get { return doza; }
            set { doza = value; }
        }

        private string kratnost;
        public string Kratnost
        {
            get { return kratnost; }
            set { kratnost = value; }
        }

        private string kolvodoz;
        public string Kolvodoz
        {
            get { return kolvodoz; }
            set { kolvodoz = value; }
        }

        private string profilakt;
        public string Profilakt
        {
            get { return profilakt; }
            set { profilakt = value; }
        }
        

    }
    /// <summary>
    /// Лист временной нетрудоспособности
    /// </summary>
    public class listv
    {
        public listv(int id,
            int idp,
            int idv,
            string serial,
            string number,
            string prich,
            int idz,
            string databeg,
            string dataend,
            string dney)
        {
            this.Id = id;
            this.Idp = idp;
            this.Idv = idv;
            this.Serial = serial;
            this.Number = number;
            this.Prich = prich;
            this.Idz = idz;
            this.Databeg = databeg;
            this.Dataend = dataend;
            this.Dney = dney;
        }

        public listv() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idp;
        public int Idp
        {
            get { return idp; }
            set { idp = value; }
        }

        private int idz;
        public int Idz
        {
            get { return idz; }
            set { idz = value; }
        }

        private int idv;
        public int Idv
        {
            get { return idv; }
            set { idv = value; }
        }

        private string serial;
        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }

        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string prich;
        public string Prich
        {
            get { return prich; }
            set { prich = value; }
        }

        private string databeg;
        public string Databeg
        {
            get { return databeg; }
            set { databeg = value; }
        }

        private string dataend;
        public string Dataend
        {
            get { return dataend; }
            set { dataend = value; }
        }

        private string dney;
        public string Dney
        {
            get { return dney; }
            set { dney = value; }
        }

    }
    /// <summary>
    /// Осмотр
    /// </summary>
    public class osmotr
    {
        public osmotr(int id,
            int idp,
            int idv,
            string data,
            string simpt,
            string result,
            int iddiag,
            string comm
            )
        {
            this.Id = id;
            this.Idp = idp;
            this.Idv = idv;
            this.Data = data;
            this.Simpt = simpt;
            this.Result = result;
            this.Iddiag = iddiag;
            this.Comm = comm;
        }

        public osmotr() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idp;
        public int Idp
        {
            get { return idp; }
            set { idp = value; }
        }

        private int idv;
        public int Idv
        {
            get { return idv; }
            set { idv = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private string simpt;
        public string Simpt
        {
            get { return simpt; }
            set { simpt = value; }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private int iddiag;
        public int Iddiag
        {
            get { return iddiag; }
            set { iddiag = value; }
        }

        private string comm;
        public string Comm
        {
            get { return comm; }
            set { comm = value; }
        }


    }
    /// <summary>
    /// Услуга
    /// </summary>
    public class service
    {
        public service(int id,
            string name,
            string cost,
            string about
            
            )
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.About = about;
            
        }

        public service() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string cost;
        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private string about;
        public string About
        {
            get { return about; }
            set { about = value; }
        }
    }
    /// <summary>
    /// Осмотр новорожденого
    /// </summary>
    public class osmotrn
    {
        public osmotrn(int id,
            int idosm,
            int den,
            string temp,
            string ves,
            string dinamica,
            string sost,
            string poroki,
            string minpor,
            string poza,
            string tonys,
            string refleks,
            string chss,
            string dihan,
            string pol,
            string jalob,
            string zabolev,
            string dop,
            string osoben,
            string comm)
        {
            this.Id = id;
            this.Idosm = idosm;
            this.Den = den;
            this.Temp = temp;
            this.Ves = ves;
            this.Dinamica = dinamica;
            this.Sost = sost;
            this.Poroki = poroki;
            this.Minpor = minpor;
            this.Poza = poza;
            this.Tonys = tonys;
            this.Refleks = refleks;
            this.Chss = chss;
            this.Dihan = dihan;
            this.Pol = pol;
            this.Jalob = jalob;
            this.Zabolev = zabolev;
            this.Dop = dop;
            this.Osoben = osoben;
            this.Comm = comm;
        }

        public osmotrn() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idosm;
        public int Idosm
        {
            get { return idosm; }
            set { idosm = value; }
        }

        private int den;
        public int Den
        {
            get { return den; }
            set { den = value; }
        }

        private string temp;
        public string Temp
        {
            get { return temp; }
            set { temp = value; }
        }

        private string ves;
        public string Ves
        {
            get { return ves; }
            set { ves = value; }
        }

        private string dinamica;
        public string Dinamica
        {
            get { return dinamica; }
            set { dinamica = value; }
        }

        private string sost;
        public string Sost
        {
            get { return sost; }
            set { sost = value; }
        }

        private string poroki;
        public string Poroki
        {
            get { return poroki; }
            set { poroki = value; }
        }

        private string minpor;
        public string Minpor
        {
            get { return minpor; }
            set { minpor = value; }
        }

        private string poza;
        public string Poza
        {
            get { return poza; }
            set { poza = value; }
        }

        private string tonys;
        public string Tonys
        {
            get { return tonys; }
            set { tonys = value; }
        }

        private string refleks;
        public string Refleks
        {
            get { return refleks; }
            set { refleks = value; }
        }

        private string chss;
        public string Chss
        {
            get { return chss; }
            set { chss = value; }
        }

        private string dihan;
        public string Dihan
        {
            get { return dihan; }
            set { dihan = value; }
        }

        private string pol;
        public string Pol
        {
            get { return pol; }
            set { pol = value; }
        }

        private string jalob;
        public string Jalob
        {
            get { return jalob; }
            set { jalob = value; }
        }

        private string zabolev;
        public string Zabolev
        {
            get { return zabolev; }
            set { zabolev = value; }
        }

        private string dop;
        public string Dop
        {
            get { return dop; }
            set { dop = value; }
        }

        private string osoben;
        public string Osoben
        {
            get { return osoben; }
            set { osoben = value; }
        }

        private string comm;
        public string Comm
        {
            get { return comm; }
            set { comm = value; }
        }
    }
    /// <summary>
    /// Сообщения
    /// </summary>
    public class sms
    {
        public sms(int id,
            string data,
            string time,
            int otpac,
            int dopac,
            int otdoc,
            int dodoc)
        {
            this.Id = id;
            this.Data = data;
            this.Time = time;
            this.Otpac = otpac;
            this.Dopac = dopac;
            this.Otdoc = otdoc;
            this.Dodoc = dodoc;
        }

        public sms() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private int otpac;
        public int Otpac
        {
            get { return otpac; }
            set { otpac = value; }
        }

        private int dopac;
        public int Dopac
        {
            get { return dopac; }
            set { dopac = value; }
        }

        private int otdoc;
        public int Otdoc
        {
            get { return otdoc; }
            set { otdoc = value; }
        }

        private int dodoc;
        public int Dodoc
        {
            get { return dodoc; }
            set { dodoc = value; }
        }
    }
    
    public class file
    {
        public string name;
        public string address;
    }

    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class MSSQL
    {
        private string connectionString;

        /// <summary>
        /// Подключение к базе данных по умолчанию
        /// </summary>
        public MSSQL()
        {
            // Извлечь из файла web.config строку соединения по умолчанию
            connectionString = WebConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        }
        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        /// <param name="connectionStringCustom">
        /// Строка подключения
        /// </param>
        public MSSQL(string connectionStringCustom)
        {
            // Извлечь из файла web.config другую строку соединения
            connectionString = WebConfigurationManager.
                ConnectionStrings[connectionStringCustom].ConnectionString;
        }
        public string MSSQLStatus()
        {
            // Извлечь из файла web.config другую строку соединения
            connectionString = WebConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT @@VERSION AS 'SQL Server Version' set @out = @@VERSION", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@out", SqlDbType.NVarChar, 60));
            cmd.Parameters["@out"].Direction = ParameterDirection.Output;

           try
           {
               con.Open();
               cmd.ExecuteNonQuery();
               return (string)cmd.Parameters["@out"].Value;
           }
           catch
           {
               return "offline";
           }
            finally
           {
               con.Close();
           }
                
                
        }
        /// <summary>
        /// Запись на прием к врачу
        /// </summary>
        /// <param name="emp1"></param>
        /// <returns></returns>
        public int InsertDoctorTime(doctordesk emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[visits] (code,data,time,pacientID,doctorID,mo) VALUES (@code,@data,@time, @pacientID,@doctorID,@mo) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@code", SqlDbType.NVarChar, 10));
            cmd.Parameters["@code"].Value = emp1.Code;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
            cmd.Parameters["@data"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.NVarChar, 150));
            cmd.Parameters["@time"].Value = emp1.Time;
            cmd.Parameters.Add(new SqlParameter("@pacientID", SqlDbType.Int, 6));
            cmd.Parameters["@pacientID"].Value = emp1.PacientID;

            cmd.Parameters.Add(new SqlParameter("@mo", SqlDbType.Int, 6));
            cmd.Parameters["@mo"].Value = emp1.Mo;
            cmd.Parameters.Add(new SqlParameter("@doctorID", SqlDbType.Int, 6));
            cmd.Parameters["@doctorID"].Value = emp1.DoctorID;
            
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Запись на прием");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Запись расписания работы врача
        /// </summary>
        /// <param name="emp1"></param>
        /// <returns></returns>
        public int InsertDoctorDesk(doctordesks emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[doctordesk] (data,time,doctorID,mo) VALUES (@data,@time,@doctorID,@mo) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
            cmd.Parameters["@data"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.NVarChar, 150));
            cmd.Parameters["@time"].Value = emp1.Time;
            cmd.Parameters.Add(new SqlParameter("@mo", SqlDbType.Int, 6));
            cmd.Parameters["@mo"].Value = emp1.Mo;
            cmd.Parameters.Add(new SqlParameter("@doctorID", SqlDbType.Int, 6));
            cmd.Parameters["@doctorID"].Value = emp1.DoctorID;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Расписание доктора" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Запись на услугу
        /// </summary>
        /// <param name="emp1"></param>
        /// <returns></returns>
        public int InsertServiceTime(servicetime emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[servicetime] ( time, data, service,idpac) VALUES ( @time, @data, @service,@idpac) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
            cmd.Parameters["@data"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.NVarChar, 150));
            cmd.Parameters["@time"].Value = emp1.Time;
            cmd.Parameters.Add(new SqlParameter("@service", SqlDbType.Int, 6));
            cmd.Parameters["@service"].Value = emp1.Service;

            cmd.Parameters.Add(new SqlParameter("@idpac", SqlDbType.Int, 6));
            cmd.Parameters["@idpac"].Value = emp1.Idpac;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Запись на услугу"+ e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление услуги
        /// </summary>
        /// <param name="emp1"></param>
        /// <returns></returns>
        public int InsertService(service emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[service] (name,about,cost) VALUES (@name,@about, @cost) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 150));
            cmd.Parameters["@name"].Value = emp1.Name;

            cmd.Parameters.Add(new SqlParameter("@about", SqlDbType.NVarChar, 1150));
            cmd.Parameters["@about"].Value = emp1.About;

            cmd.Parameters.Add(new SqlParameter("@cost", SqlDbType.NVarChar, 150));
            cmd.Parameters["@cost"].Value = emp1.Cost;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление услуги" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Запись осмотра
        /// </summary>
        /// <param name="emp1"></param>
        /// <returns></returns>
        public int InsertOsmotr(osmotr emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[osmotr] (idp,idd,date,simptom,result,diagnoz,about) VALUES (@idp,@idd,@date,@simptom,@result,@diagnoz,@about) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idp", SqlDbType.Int, 6));
            cmd.Parameters["@idp"].Value = emp1.Idp;
            cmd.Parameters.Add(new SqlParameter("@idd", SqlDbType.Int, 6));
            cmd.Parameters["@idd"].Value = emp1.Idv;
            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.NVarChar, 150));
            cmd.Parameters["@date"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@simptom", SqlDbType.NVarChar, 150));
            cmd.Parameters["@simptom"].Value = emp1.Simpt;
            cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 150));
            cmd.Parameters["@result"].Value = emp1.Result;
            cmd.Parameters.Add(new SqlParameter("@about", SqlDbType.NVarChar, 150));
            cmd.Parameters["@about"].Value = emp1.Comm;
            cmd.Parameters.Add(new SqlParameter("@diagnoz", SqlDbType.Int, 6));
            cmd.Parameters["@diagnoz"].Value = emp1.Iddiag;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Осмотр пациента");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Запись осмотра
        /// </summary>
        /// <param name="emp1"></param>
        /// <returns></returns>
        public int InsertOsmotrNew(osmotrn emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[osmotrnew] (idosmotr,den,temp,vestela,dinamica,sost,poroki,minporoki,poza,tonys,refleks,chastota,dihan,pol,jalob,zabolev,dop,osoben,about) VALUES (@idosmotr,@den,@temp,@vestela,@dinamica,@sost,@poroki,@minporoki,@poza,@tonys,@refleks,@chastota,@dihan,@pol,@jalob,@zabolev,@dop,@osoben,@about) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idosmotr", SqlDbType.Int, 6));
            cmd.Parameters["@idosmotr"].Value = emp1.Idosm;
            cmd.Parameters.Add(new SqlParameter("@temp", SqlDbType.NVarChar, 150));
            cmd.Parameters["@temp"].Value = emp1.Temp;
            cmd.Parameters.Add(new SqlParameter("@vestela", SqlDbType.NVarChar, 150));
            cmd.Parameters["@vestela"].Value = emp1.Ves;
            cmd.Parameters.Add(new SqlParameter("@dinamica", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dinamica"].Value = emp1.Dinamica;
            cmd.Parameters.Add(new SqlParameter("@about", SqlDbType.NVarChar, 150));
            cmd.Parameters["@about"].Value = emp1.Comm;
            cmd.Parameters.Add(new SqlParameter("@sost", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sost"].Value = emp1.Sost;
            cmd.Parameters.Add(new SqlParameter("@poroki", SqlDbType.NVarChar, 150));
            cmd.Parameters["@poroki"].Value = emp1.Poroki;
            cmd.Parameters.Add(new SqlParameter("@minporoki", SqlDbType.NVarChar, 150));
            cmd.Parameters["@minporoki"].Value = emp1.Minpor;
            cmd.Parameters.Add(new SqlParameter("@poza", SqlDbType.NVarChar, 150));
            cmd.Parameters["@poza"].Value = emp1.Poza;
            cmd.Parameters.Add(new SqlParameter("@tonys", SqlDbType.NVarChar, 150));
            cmd.Parameters["@tonys"].Value = emp1.Tonys;
            cmd.Parameters.Add(new SqlParameter("@refleks", SqlDbType.NVarChar, 150));
            cmd.Parameters["@refleks"].Value = emp1.Refleks;
            cmd.Parameters.Add(new SqlParameter("@chastota", SqlDbType.NVarChar, 150));
            cmd.Parameters["@chastota"].Value = emp1.Chss;
            cmd.Parameters.Add(new SqlParameter("@dihan", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dihan"].Value = emp1.Dihan;
            cmd.Parameters.Add(new SqlParameter("@pol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@pol"].Value = emp1.Pol;
            cmd.Parameters.Add(new SqlParameter("@jalob", SqlDbType.NVarChar, 150));
            cmd.Parameters["@jalob"].Value = emp1.Jalob;
            cmd.Parameters.Add(new SqlParameter("@zabolev", SqlDbType.NVarChar, 150));
            cmd.Parameters["@zabolev"].Value = emp1.Zabolev;
            cmd.Parameters.Add(new SqlParameter("@dop", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dop"].Value = emp1.Dop;
            cmd.Parameters.Add(new SqlParameter("@osoben", SqlDbType.NVarChar, 150));
            cmd.Parameters["@osoben"].Value = emp1.Osoben;
            cmd.Parameters.Add(new SqlParameter("@den", SqlDbType.Int, 6));
            cmd.Parameters["@den"].Value = emp1.Den;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Осмотр новорожденного пациента" + e);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Добавление нового пациента в базу
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int InsertPatient(patient emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[patient] ([data],[snils],[inn],[fam],[im],[otch],[datr],[mest],[vozr]"+
           ",[pol],[dok],[sernom],[kemv],[datv],[rassa],[sem],[det],[obraz],[rabot],[dolg],[trud] ,[oms],[strax],[typpolis],[soms],[noms]"+
           ",[datoms],[dms],[school],mo) VALUES (@data,@snils,@inn,@fam,@im,@otch,@datr,@mest,@vozr" +
           ",@pol,@dok,@sernom,@kemv,@datv,@rassa,@sem,@det,@obraz,@rabot,@dolg,@trud,@oms,@strax,@typpolis,@soms,@noms" +
           ",@datoms,@dms,@school,@mo) SET @patientID = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
            cmd.Parameters["@data"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@snils", SqlDbType.NVarChar, 150));
            cmd.Parameters["@snils"].Value = emp1.Snils;
            cmd.Parameters.Add(new SqlParameter("@inn", SqlDbType.NVarChar, 150));
            cmd.Parameters["@inn"].Value = emp1.Inn;
            cmd.Parameters.Add(new SqlParameter("@fam", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fam"].Value = emp1.Fam;
            cmd.Parameters.Add(new SqlParameter("@im", SqlDbType.NVarChar, 150));
            cmd.Parameters["@im"].Value = emp1.Im;
            cmd.Parameters.Add(new SqlParameter("@otch", SqlDbType.NVarChar, 150));
            cmd.Parameters["@otch"].Value = emp1.Otch;
            cmd.Parameters.Add(new SqlParameter("@datr", SqlDbType.NVarChar, 150));
            cmd.Parameters["@datr"].Value = emp1.Datr;
            cmd.Parameters.Add(new SqlParameter("@mest", SqlDbType.NVarChar, 150));
            cmd.Parameters["@mest"].Value = emp1.Mest;
            cmd.Parameters.Add(new SqlParameter("@vozr", SqlDbType.NVarChar, 150));
            cmd.Parameters["@vozr"].Value = emp1.Vozr;
            cmd.Parameters.Add(new SqlParameter("@pol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@pol"].Value = emp1.Pol;
            cmd.Parameters.Add(new SqlParameter("@dok", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dok"].Value = emp1.Dok;
            cmd.Parameters.Add(new SqlParameter("@sernom", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sernom"].Value = emp1.Sernom;
            cmd.Parameters.Add(new SqlParameter("@kemv", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kemv"].Value = emp1.Kemv;
            cmd.Parameters.Add(new SqlParameter("@datv", SqlDbType.NVarChar, 150));
            cmd.Parameters["@datv"].Value = emp1.Datv;
            cmd.Parameters.Add(new SqlParameter("@rassa", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rassa"].Value = emp1.Rassa;
            cmd.Parameters.Add(new SqlParameter("@sem", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sem"].Value = emp1.Sem;
            cmd.Parameters.Add(new SqlParameter("@det", SqlDbType.Int, 3));
            cmd.Parameters["@det"].Value = emp1.Det;

            cmd.Parameters.Add(new SqlParameter("@mo", SqlDbType.Int, 3));
            cmd.Parameters["@mo"].Value = emp1.Mo;
            cmd.Parameters.Add(new SqlParameter("@obraz", SqlDbType.NVarChar, 150));
            cmd.Parameters["@obraz"].Value = emp1.Obraz;
            cmd.Parameters.Add(new SqlParameter("@rabot", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rabot"].Value = emp1.Rabot;
            cmd.Parameters.Add(new SqlParameter("@dolg", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dolg"].Value = emp1.Dolg;
            cmd.Parameters.Add(new SqlParameter("@trud", SqlDbType.NVarChar, 150));
            cmd.Parameters["@trud"].Value = emp1.Trud;
            cmd.Parameters.Add(new SqlParameter("@oms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@oms"].Value = emp1.Oms;
            cmd.Parameters.Add(new SqlParameter("@strax", SqlDbType.NVarChar, 150));
            cmd.Parameters["@strax"].Value = emp1.Strax;
            cmd.Parameters.Add(new SqlParameter("@typpolis", SqlDbType.NVarChar, 150));
            cmd.Parameters["@typpolis"].Value = emp1.Typpolis;
            cmd.Parameters.Add(new SqlParameter("@soms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@soms"].Value = emp1.Soms;
            cmd.Parameters.Add(new SqlParameter("@noms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@noms"].Value = emp1.Noms;
            cmd.Parameters.Add(new SqlParameter("@datoms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@datoms"].Value = emp1.Datoms;
            cmd.Parameters.Add(new SqlParameter("@dms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dms"].Value = emp1.Dms;
            cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.NVarChar, 150));
            cmd.Parameters["@school"].Value = emp1.School;
            cmd.Parameters.Add(new SqlParameter("@patientID", SqlDbType.Int, 6));
            cmd.Parameters["@patientID"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@patientID"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление пациента");
            }
            finally
            {
                con.Close();
            }
        }
        //public int UpdatePatient(patient emp1)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand("UPDATE [BD].[dbo].[patient] SET ([data]=@data,[snils]=@snils,[inn]=@inn,[fam]=@fam,[im]=@im,[otch]=@otch,[datr]=@datr,[mest]=@mest,[vozr]=@vozr" +
        //   ",[pol]=@pol,[dok]=@dok,[sernom]=@sernom,[kemv]=@kemv,[datv]=@datv,[rassa]=@rassa,[sem]=@sem,[det]=@det,[obraz]=@obraz,[rabot]=@rabot,[dolg]=@dolg,[trud]=@trud ,[oms]=@oms,[strax]=@strax,[typpolis]=@typpolis,[soms]=@soms,[noms]=@noms" +
        //   ",[datoms]=@datoms,[dms]=@dms,[school]=@school) where patientID = @patientID ", con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@data"].Value = emp1.Data;
        //    cmd.Parameters.Add(new SqlParameter("@snils", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@snils"].Value = emp1.Snils;
        //    cmd.Parameters.Add(new SqlParameter("@inn", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@inn"].Value = emp1.Inn;
        //    cmd.Parameters.Add(new SqlParameter("@fam", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@fam"].Value = emp1.Fam;
        //    cmd.Parameters.Add(new SqlParameter("@im", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@im"].Value = emp1.Im;
        //    cmd.Parameters.Add(new SqlParameter("@otch", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@otch"].Value = emp1.Otch;
        //    cmd.Parameters.Add(new SqlParameter("@datr", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@datr"].Value = emp1.Datr;
        //    cmd.Parameters.Add(new SqlParameter("@mest", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@mest"].Value = emp1.Mest;
        //    cmd.Parameters.Add(new SqlParameter("@vozr", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@vozr"].Value = emp1.Vozr;
        //    cmd.Parameters.Add(new SqlParameter("@pol", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@pol"].Value = emp1.Pol;
        //    cmd.Parameters.Add(new SqlParameter("@dok", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@dok"].Value = emp1.Dok;
        //    cmd.Parameters.Add(new SqlParameter("@sernom", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@sernom"].Value = emp1.Sernom;
        //    cmd.Parameters.Add(new SqlParameter("@kemv", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@kemv"].Value = emp1.Kemv;
        //    cmd.Parameters.Add(new SqlParameter("@datv", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@datv"].Value = emp1.Datv;
        //    cmd.Parameters.Add(new SqlParameter("@rassa", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@rassa"].Value = emp1.Rassa;
        //    cmd.Parameters.Add(new SqlParameter("@sem", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@sem"].Value = emp1.Sem;
        //    cmd.Parameters.Add(new SqlParameter("@det", SqlDbType.Int, 3));
        //    cmd.Parameters["@det"].Value = emp1.Det;
        //    cmd.Parameters.Add(new SqlParameter("@obraz", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@obraz"].Value = emp1.Obraz;
        //    cmd.Parameters.Add(new SqlParameter("@rabot", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@rabot"].Value = emp1.Rabot;
        //    cmd.Parameters.Add(new SqlParameter("@dolg", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@dolg"].Value = emp1.Dolg;
        //    cmd.Parameters.Add(new SqlParameter("@trud", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@trud"].Value = emp1.Trud;
        //    cmd.Parameters.Add(new SqlParameter("@oms", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@oms"].Value = emp1.Oms;
        //    cmd.Parameters.Add(new SqlParameter("@strax", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@strax"].Value = emp1.Strax;
        //    cmd.Parameters.Add(new SqlParameter("@typpolis", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@typpolis"].Value = emp1.Typpolis;
        //    cmd.Parameters.Add(new SqlParameter("@soms", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@soms"].Value = emp1.Soms;
        //    cmd.Parameters.Add(new SqlParameter("@noms", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@noms"].Value = emp1.Noms;
        //    cmd.Parameters.Add(new SqlParameter("@datoms", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@datoms"].Value = emp1.Datoms;
        //    cmd.Parameters.Add(new SqlParameter("@dms", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@dms"].Value = emp1.Dms;
        //    cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.NVarChar, 150));
        //    cmd.Parameters["@school"].Value = emp1.School;
        //    cmd.Parameters.Add(new SqlParameter("@patientID", SqlDbType.Int, 6));
        //    cmd.Parameters["@patientID"].Value = emp1.PatientID;

        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        return (int)cmd.Parameters["@patientID"].Value;
        //    }
        //    catch
        //    {
        //        throw new ApplicationException("Ошибка данныx. Добавление пациента");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
       
        /// <summary>
        /// Обновление пациента в базе
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int UpdatePatient(patient emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update patient Set data = @data,snils = @snils,inn=@inn,fam=@fam,im=@im,otch=@otch,datr=@datr,mest=@mest,vozr=@vozr" +
           ",pol=@pol,dok=@dok,sernom=@sernom,kemv=@kemv,datv=@datv,rassa=@rassa,sem=@sem,det=@det,obraz=@obraz,rabot=@rabot,dolg=@dolg,trud=@trud,oms=@oms,strax=@strax,typpolis=@typpolis,soms=@soms,noms=@noms" +
           ",datoms=@datoms,dms=@dms,school=@school, mo =@mo Where patientID = @id ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
            cmd.Parameters["@data"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@snils", SqlDbType.NVarChar, 150));
            cmd.Parameters["@snils"].Value = emp1.Snils;
            cmd.Parameters.Add(new SqlParameter("@inn", SqlDbType.NVarChar, 150));
            cmd.Parameters["@inn"].Value = emp1.Inn;
            cmd.Parameters.Add(new SqlParameter("@fam", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fam"].Value = emp1.Fam;
            cmd.Parameters.Add(new SqlParameter("@im", SqlDbType.NVarChar, 150));
            cmd.Parameters["@im"].Value = emp1.Im;
            cmd.Parameters.Add(new SqlParameter("@otch", SqlDbType.NVarChar, 150));
            cmd.Parameters["@otch"].Value = emp1.Otch;
            cmd.Parameters.Add(new SqlParameter("@datr", SqlDbType.NVarChar, 150));
            cmd.Parameters["@datr"].Value = emp1.Datr;
            cmd.Parameters.Add(new SqlParameter("@mest", SqlDbType.NVarChar, 150));
            cmd.Parameters["@mest"].Value = emp1.Mest;
            cmd.Parameters.Add(new SqlParameter("@vozr", SqlDbType.NVarChar, 150));
            cmd.Parameters["@vozr"].Value = emp1.Vozr;
            cmd.Parameters.Add(new SqlParameter("@pol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@pol"].Value = emp1.Pol;
            cmd.Parameters.Add(new SqlParameter("@dok", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dok"].Value = emp1.Dok;
            cmd.Parameters.Add(new SqlParameter("@sernom", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sernom"].Value = emp1.Sernom;
            cmd.Parameters.Add(new SqlParameter("@kemv", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kemv"].Value = emp1.Kemv;
            cmd.Parameters.Add(new SqlParameter("@datv", SqlDbType.NVarChar, 150));
            cmd.Parameters["@datv"].Value = emp1.Datv;
            cmd.Parameters.Add(new SqlParameter("@rassa", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rassa"].Value = emp1.Rassa;
            cmd.Parameters.Add(new SqlParameter("@sem", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sem"].Value = emp1.Sem;
            cmd.Parameters.Add(new SqlParameter("@det", SqlDbType.Int, 3));
            cmd.Parameters["@det"].Value = emp1.Det;
            cmd.Parameters.Add(new SqlParameter("@mo", SqlDbType.Int, 3));
            cmd.Parameters["@mo"].Value = emp1.Mo;
            cmd.Parameters.Add(new SqlParameter("@obraz", SqlDbType.NVarChar, 150));
            cmd.Parameters["@obraz"].Value = emp1.Obraz;
            cmd.Parameters.Add(new SqlParameter("@rabot", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rabot"].Value = emp1.Rabot;
            cmd.Parameters.Add(new SqlParameter("@dolg", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dolg"].Value = emp1.Dolg;
            cmd.Parameters.Add(new SqlParameter("@trud", SqlDbType.NVarChar, 150));
            cmd.Parameters["@trud"].Value = emp1.Trud;
            cmd.Parameters.Add(new SqlParameter("@oms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@oms"].Value = emp1.Oms;
            cmd.Parameters.Add(new SqlParameter("@strax", SqlDbType.NVarChar, 150));
            cmd.Parameters["@strax"].Value = emp1.Strax;
            cmd.Parameters.Add(new SqlParameter("@typpolis", SqlDbType.NVarChar, 150));
            cmd.Parameters["@typpolis"].Value = emp1.Typpolis;
            cmd.Parameters.Add(new SqlParameter("@soms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@soms"].Value = emp1.Soms;
            cmd.Parameters.Add(new SqlParameter("@noms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@noms"].Value = emp1.Noms;
            cmd.Parameters.Add(new SqlParameter("@datoms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@datoms"].Value = emp1.Datoms;
            cmd.Parameters.Add(new SqlParameter("@dms", SqlDbType.NVarChar, 150));
            cmd.Parameters["@dms"].Value = emp1.Dms;
            cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.NVarChar, 150));
            cmd.Parameters["@school"].Value = emp1.School;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = emp1.PatientID;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return emp1.PatientID;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Обновление информации");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление медицинской организации
        /// </summary>
        /// <param name="obj">обьект организация</param>
        /// <returns>ид организации</returns>
        public int InsertMo(mo obj)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [mo] ( name, adres, phone, email, lico, bik, licenz, kpp, inn) " +
           "VALUES ( @name, @adres, @phone, @email, @lico, @bik, @licenz, @kpp, @inn) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 150));
            cmd.Parameters["@name"].Value = obj.Name;
            cmd.Parameters.Add(new SqlParameter("@adres", SqlDbType.NVarChar, 150));
            cmd.Parameters["@adres"].Value = obj.Adres;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone"].Value = obj.Phone;
            cmd.Parameters.Add(new SqlParameter("@lico", SqlDbType.NVarChar, 150));
            cmd.Parameters["@lico"].Value = obj.Lico;
            cmd.Parameters.Add(new SqlParameter("@bik", SqlDbType.NVarChar, 150));
            cmd.Parameters["@bik"].Value = obj.Bik;
            cmd.Parameters.Add(new SqlParameter("@licenz", SqlDbType.NVarChar, 150));
            cmd.Parameters["@licenz"].Value = obj.Licenz;
            cmd.Parameters.Add(new SqlParameter("@kpp", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kpp"].Value = obj.Kpp;
            cmd.Parameters.Add(new SqlParameter("@inn", SqlDbType.NVarChar, 150));
            cmd.Parameters["@inn"].Value = obj.Inn;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
            cmd.Parameters["@email"].Value = obj.Email;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление мед учреждения");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление услуг оказываемых мо
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>ид записи</returns>
        public int InsertMoServ(int idmo, int idserv)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [moserv] (  idserv, idmo) " +
           "VALUES (  @idserv, @idmo) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idserv", SqlDbType.Int, 6));
            cmd.Parameters["@idserv"].Value = idserv;
            cmd.Parameters.Add(new SqlParameter("@idmo", SqlDbType.Int, 6));
            cmd.Parameters["@idmo"].Value = idmo;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление услуг для мед учреждения" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Добавление emk в базу
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int InsertFile(string name, string address, int idp)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [files] (idp, name, address) " +
           "VALUES ( @idp, @name, @address) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idp", SqlDbType.Int, 6));
            cmd.Parameters["@idp"].Value = idp;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 150));
            cmd.Parameters["@name"].Value = name;
            cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 150));
            cmd.Parameters["@address"].Value = address;
            
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление файла");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// вывод emk
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public List<file> GetFilePatient(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select name, address) " +
           "from emk where idp = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            List<file> list = new List<file>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    file mem = new file();
                    
                    mem.name = (string)reader["name"];
                    mem.address = (string)reader["address"];
                    
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи ЭМК");
            }
            finally
            {
                con.Close();
            }
        }


        //////Посещяемость//////
        /// <summary>
        /// Вывод посещений
        /// </summary>
        /// <returns>список всех посещений услуг</returns>
        public List<successervice> GetServiceSuccess()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from successservtime ", con);
            cmd.CommandType = CommandType.Text;


            List<successervice> list = new List<successervice>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    successervice mem = new successervice();
                    mem.Id = (int)reader["id"];
                    mem.Idservtime = (int)reader["idservtime"];
                    mem.Success = (int)reader["success"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод посещяемости услуг: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод посещений врача
        /// </summary>
        /// <returns>список всех посещений врача</returns>
        public List<successvisit> GetVisitsSuccess()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from succesvisittime ", con);
            cmd.CommandType = CommandType.Text;


            List<successvisit> list = new List<successvisit>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    successvisit mem = new successvisit();
                    mem.Id = (int)reader["id"];
                    mem.Idvisits = (int)reader["idvisits"];
                    mem.Success = (int)reader["success"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод посещяемости врачей: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод подтверждения
        /// </summary>
        /// <returns>список всех посещений врача</returns>
        public int GetDeskSuccess(int iddesk)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from regdesksucces where iddesk = @iddesk ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@iddesk", SqlDbType.Int, 6));
            cmd.Parameters["@iddesk"].Value = iddesk;
           try
            {
                int suc = 0;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    suc = (int)reader["success"];
                    
                }
                reader.Close();

                return suc;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод подтверждения : " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Посещения по записи на прием
        /// </summary>
        /// <returns></returns>
        public List<DBase.successdesk> GetAllDeskSuccess()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from succesvisittime", con);
            cmd.CommandType = CommandType.Text;

           
            try
            {
                List<DBase.successdesk> desks = new List<successdesk>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DBase.successdesk desk = new DBase.successdesk();
                    desk.Id = (int)reader["id"];
                    desk.Idvisits = (int)reader["idvisits"];
                    desk.Success = (int)reader["success"];
                    desks.Add(desk);
                }
                reader.Close();

                return desks;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод подтверждения : " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Посещения по записи на прием
        /// </summary>
        /// <returns></returns>
        public List<DBase.successervice> GetAllServSuccess()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from successservtime", con);
            cmd.CommandType = CommandType.Text;


            try
            {
                List<DBase.successervice> desks = new List<successervice>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DBase.successervice desk = new DBase.successervice();
                    desk.Id = (int)reader["id"];
                    desk.Idservtime = (int)reader["idservtime"];
                    desk.Success = (int)reader["success"];
                    desks.Add(desk);
                }
                reader.Close();

                return desks;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод подтверждения : " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавляем посещение услуги
        /// </summary>
        /// <param name="idservtime">ид</param>
        /// <param name="success">1-да, 0 -нет</param>
        /// <returns>ид записи</returns>
        public int InsertServiceSuccess( int idservtime, int success)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [successservtime] (idservtime,success) " +
           "VALUES ( @idservtime,@success) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idservtime", SqlDbType.Int, 6));
            cmd.Parameters["@idservtime"].Value = idservtime;

            cmd.Parameters.Add(new SqlParameter("@success", SqlDbType.Int, 6));
            cmd.Parameters["@success"].Value = success;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление посещения услуги" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавляем посещение врача
        /// </summary>
        /// <param name="idservtime">ид</param>
        /// <param name="success">1-да, 0 -нет</param>
        /// <returns>ид записи</returns>
        public int InsertVisitSuccess(int idvisits, int success)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [succesvisittime] (idvisits,success) " +
           "VALUES ( @idvisits,@success) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idvisits", SqlDbType.Int, 6));
            cmd.Parameters["@idvisits"].Value = idvisits;

            cmd.Parameters.Add(new SqlParameter("@success", SqlDbType.Int, 6));
            cmd.Parameters["@success"].Value = success;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление посещения врача" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Подтверждение записи к врачу
        /// </summary>
        /// <param name="idservtime">ид</param>
        /// <param name="success">1-да, 0 -нет</param>
        /// <returns>ид записи</returns>
        public int InsertDeskSuccess(int iddesk, int success)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [regdesksucces] (iddesk,success) " +
           "VALUES ( @iddesk,@success) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@iddesk", SqlDbType.Int, 6));
            cmd.Parameters["@iddesk"].Value = iddesk;

            cmd.Parameters.Add(new SqlParameter("@success", SqlDbType.Int, 6));
            cmd.Parameters["@success"].Value = success;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Подтверждение записи в др мо" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateDeskSuccess(int id, int success)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE [BD].[dbo].[regdesksucces] set success = @success where id = @id ", con);
            cmd.CommandType = CommandType.Text;
            

            cmd.Parameters.Add(new SqlParameter("@success", SqlDbType.Int, 6));
            cmd.Parameters["@success"].Value = success;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Обновление Подтверждение записи в др мо" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
       
        /////
        /// <summary>
        /// Вывод услуг
        /// </summary>
        /// <returns>список всех услуг</returns>
        public List<service> GetServices()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from service ", con);
            cmd.CommandType = CommandType.Text;

           
            List<service> list = new List<service>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    service mem = new service();
                    mem.Id = (int)reader["id"];
                    mem.Name = (string)reader["name"];
                    mem.About = (string)reader["about"];
                    mem.Cost = (string)reader["cost"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод услуг. Подробности: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод услуг для конкретного МО
        /// </summary>
        /// <returns>список всех услуг оказываемых мо</returns>
        public List<service> GetServicesMo(int idmo)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select service.id, service.about, service.cost, service.name from service, moserv where ( service.id = moserv.idserv and moserv.idmo = @idmo) ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idmo", SqlDbType.Int, 6));
            cmd.Parameters["@idmo"].Value = idmo;
            List<service> list = new List<service>();
            
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    service mem = new service();
                    mem.Id = (int)reader["id"];
                    mem.Name = (string)reader["name"];
                    mem.About = (string)reader["about"];
                    mem.Cost = (string)reader["cost"];
                    
                    list.Add(mem);
                }
               
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод услуг для МО. Подробности: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Добавление emk в базу
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int InsertEmk(emk emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [emk] ( idp, grupkrov,rezus,kategreben,kategsocial,"+
           "grupzdorov,kyrenie,alcogol,narkot,alerg,neperen,haract,anamnez,invalid,otklon,psihomotor,intelect,time,medrab) "+
           "VALUES ( @idp, @grupkrov,@rezus,@kategreben,@kategsocial,@grupzdorov,@kyrenie,@alcogol,@narkot,@alerg,@neperen,@haract,@anamnez,"+
           "@invalid,@otklon,@psihomotor,@intelect,@time,@medrab) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idp", SqlDbType.Int,6));
            cmd.Parameters["@idp"].Value = emp1.Idp;
            cmd.Parameters.Add(new SqlParameter("@grupkrov", SqlDbType.NVarChar, 150));
            cmd.Parameters["@grupkrov"].Value = emp1.Grupkrov;
            cmd.Parameters.Add(new SqlParameter("@rezus", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rezus"].Value = emp1.Rezus;
            cmd.Parameters.Add(new SqlParameter("@kategreben", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kategreben"].Value = emp1.Kategreben;
            cmd.Parameters.Add(new SqlParameter("@kategsocial", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kategsocial"].Value = emp1.Kategsocial;
            cmd.Parameters.Add(new SqlParameter("@grupzdorov", SqlDbType.NVarChar, 150));
            cmd.Parameters["@grupzdorov"].Value = emp1.Grupzdorov;
            cmd.Parameters.Add(new SqlParameter("@kyrenie", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kyrenie"].Value = emp1.Kyrenie;
            cmd.Parameters.Add(new SqlParameter("@alcogol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@alcogol"].Value = emp1.Alcogol;
            cmd.Parameters.Add(new SqlParameter("@narkot", SqlDbType.NVarChar, 150));
            cmd.Parameters["@narkot"].Value = emp1.Narkot;
            cmd.Parameters.Add(new SqlParameter("@alerg", SqlDbType.NVarChar, 150));
            cmd.Parameters["@alerg"].Value = emp1.Alerg;
            cmd.Parameters.Add(new SqlParameter("@neperen", SqlDbType.NVarChar, 150));
            cmd.Parameters["@neperen"].Value = emp1.Neperen;
            cmd.Parameters.Add(new SqlParameter("@haract", SqlDbType.NVarChar, 150));
            cmd.Parameters["@haract"].Value = emp1.Haract;
            cmd.Parameters.Add(new SqlParameter("@anamnez", SqlDbType.NVarChar, 150));
            cmd.Parameters["@anamnez"].Value = emp1.Anamnez;
            cmd.Parameters.Add(new SqlParameter("@invalid", SqlDbType.NVarChar, 150));
            cmd.Parameters["@invalid"].Value = emp1.Invalid;
            cmd.Parameters.Add(new SqlParameter("@otklon", SqlDbType.NVarChar, 150));
            cmd.Parameters["@otklon"].Value = emp1.Otklon;
            cmd.Parameters.Add(new SqlParameter("@psihomotor", SqlDbType.NVarChar, 150));
            cmd.Parameters["@psihomotor"].Value = emp1.Psihomotor;
            cmd.Parameters.Add(new SqlParameter("@intelect", SqlDbType.NVarChar, 150));
            cmd.Parameters["@intelect"].Value = emp1.Intelect;
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.NVarChar, 150));
            cmd.Parameters["@time"].Value = emp1.Time;
            cmd.Parameters.Add(new SqlParameter("@medrab", SqlDbType.Int, 3));
            cmd.Parameters["@medrab"].Value = emp1.Medrab;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи ЭМК.Подробности: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// вывод emk
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public List<emk> GetEmk(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, idp, grupkrov,rezus,kategreben,kategsocial," +
           "grupzdorov,kyrenie,alcogol,narkot,alerg,neperen,haract,anamnez,invalid,otklon,psihomotor,intelect,time,medrab " +
           "from emk where idp = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            List<emk> list = new List<emk>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emk mem = new emk();
                    mem.Id = (int)reader["id"];
                    mem.Idp = (int)reader["idp"];
                    mem.Grupkrov = (string)reader["grupkrov"];
                    mem.Rezus = (string)reader["rezus"];
                    mem.Kategreben = (string)reader["kategreben"];
                    mem.Kategsocial = (string)reader["kategsocial"];
                    mem.Grupzdorov = (string)reader["grupzdorov"];
                    mem.Kyrenie = (string)reader["kyrenie"];
                    mem.Alcogol = (string)reader["alcogol"];
                    mem.Narkot = (string)reader["narkot"];
                    mem.Alerg = (string)reader["alerg"];
                    mem.Neperen = (string)reader["neperen"];
                    mem.Haract = (string)reader["haract"];
                    mem.Anamnez = (string)reader["anamnez"];
                    mem.Invalid = (string)reader["invalid"];
                    mem.Otklon = (string)reader["otklon"];
                    mem.Psihomotor = (string)reader["psihomotor"];
                    mem.Intelect = (string)reader["intelect"];
                    mem.Time = (string)reader["time"];
                    mem.Medrab = (int)reader["medrab"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи ЭМК" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public List<mo> GetMo()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from mo ", con);
            cmd.CommandType = CommandType.Text;

            List<mo> list = new List<mo>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mo mem = new mo();
                    mem.Id = (int)reader["id"];
                   
                    mem.Name = (string)reader["name"];
                    mem.Adres = (string)reader["adres"];
                    mem.Phone = (string)reader["phone"];
                    mem.Email = (string)reader["email"];
                    mem.Bik = (string)reader["bik"];
                    mem.Lico = (string)reader["lico"];
                    mem.Licenz = (string)reader["licenz"];
                    mem.Kpp = (string)reader["kpp"];
                    mem.Inn = (string)reader["inn"];
                    
                    list.Add(mem);
                }
                reader.Close();
                
                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод мед учреждений" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public List<registr> GetRegistrat()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from registrpassword ", con);
            cmd.CommandType = CommandType.Text;

            List<registr> list = new List<registr>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    registr mem = new registr();
                    mem.Id = (int)reader["id"];

                   
                    mem.Phone = (string)reader["phone"];
                    mem.Email = (string)reader["email"];
                    mem.Fio = (string)reader["fio"];
                   
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод регистр" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        // Выводы паролей пользователей
        public List<string> Login(string log, string pass, string type)
        {
            List<string> parametrs = new List<string>();
            if (type == "user")
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Select patient.patientID, patient.im, patient.fam, patient.otch, patientpassword.password from patient, patientpassword where (patient.snils = @snils  and patientpassword.password = @pass) or (patient.inn = @snils and patientpassword.password = @pass) or (patient.soms + patient.noms  = @snils and patientpassword.password = @pass) ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@snils", SqlDbType.NVarChar, 150));
                cmd.Parameters["@snils"].Value = log;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 150));
                cmd.Parameters["@pass"].Value = pass;
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                       parametrs.Add(Convert.ToString((int)reader["patientID"]));
                       parametrs.Add((string)reader["fam"] + " " + (string)reader["im"] + " " + (string)reader["otch"]);
                       parametrs.Add((string)reader["password"]);

                    }
                    reader.Close();

                    return parametrs;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Ошибка данныx. Вход пользователя" + e.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            if (type == "doctor")
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Select doctor.id, doctor.Surname  from bd.dbo.doctor,bd.dbo.doctorpassword where doctorpassword.email = @email and doctorpassword.password = @pass and doctor.id =doctorpassword.doctorID  ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
                cmd.Parameters["@email"].Value = log;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 150));
                cmd.Parameters["@pass"].Value = pass;
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        parametrs.Add(Convert.ToString((int)reader["id"]));
                        parametrs.Add(Convert.ToString((string)reader["Surname"]));

                    }
                    reader.Close();

                    return parametrs;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Ошибка данныx. Вход медработника" + e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            if (type == "registr")
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Select id, password, fio, email from registrpassword where registrpassword.email = @email and registrpassword.password = @pass ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
                cmd.Parameters["@email"].Value = log;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 150));
                cmd.Parameters["@pass"].Value = pass;
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        parametrs.Add(Convert.ToString((int)reader["id"]));
                        parametrs.Add((string)reader["fio"]);
                        parametrs.Add((string)reader["password"]);

                    }
                    reader.Close();

                    return parametrs;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Ошибка данныx. Вход сотрудника регистратуры" + e.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            return null;
            
        }
        /// <summary>
        /// вывод всех осмотров
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public List<osmotr> GetOsmotr(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, idp,idd,date,simptom,result,diagnoz,about from osmotr where idp = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            List<osmotr> list = new List<osmotr>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    osmotr mem = new osmotr();
                    mem.Id = (int)reader["id"];
                    mem.Idp = (int)reader["idp"];
                    mem.Comm = (string)reader["about"];
                    mem.Data = (string)reader["date"];
                    mem.Result = (string)reader["result"];
                    mem.Simpt = (string)reader["simptom"];
                    mem.Idv = (int)reader["idd"];
                    mem.Iddiag = (int)reader["diagnoz"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи ЭМК");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// вывод всех осмотров новорожденных
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public List<osmotrn> GetOsmotrNew(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, idosmotr,den,temp,vestela,dinamica,sost,poroki,minporoki,poza,tonys,refleks,chastota,dihan,pol,jalob,zabolev,dop,osoben,about from osmotrnew where osmotr.id = osmotrnew.idosmotr and osmotr.idp = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            List<osmotrn> list = new List<osmotrn>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    osmotrn mem = new osmotrn();
                    mem.Id = (int)reader["id"];
                    mem.Idosm = (int)reader["idosmotr"];
                    mem.Temp = (string)reader["temp"];
                    mem.Ves = (string)reader["vestela"];
                    mem.Dinamica = (string)reader["dinamica"];
                    mem.Sost = (string)reader["sost"];
                    mem.Poroki = (string)reader["poroki"];
                    mem.Minpor = (string)reader["minporoki"];
                    mem.Poza = (string)reader["poza"];
                    mem.Tonys = (string)reader["tonys"];
                    mem.Refleks = (string)reader["refleks"];
                    mem.Chss = (string)reader["chastota"];
                    mem.Dihan = (string)reader["dihan"];
                    mem.Pol = (string)reader["pol"];
                    mem.Jalob = (string)reader["jalob"];
                    mem.Zabolev = (string)reader["zabolev"];
                    mem.Osoben = (string)reader["osoben"];
                    mem.Dop = (string)reader["dop"];
                    mem.Osoben = (string)reader["osoben"];
                    mem.Comm = (string)reader["about"];

                    mem.Den = (int)reader["den"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод осмотров новорожденного");
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Обновление emk в базе
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        /// 
        public int UpdateEmk(emk emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update emk set  idp=@idp, grupkrov=@grupkrov,rezus=@rezus,kategreben=@kategreben,kategsocial=@kategsocial,"  +
           "grupzdorov=@grupzdorov,kyrenie=@kyrenie,alcogol=@alcogol,narkot=@narkot,alerg=@alerg,neperen=@neperen,haract=@haract,anamnez=@anamnez,invalid=@invalid,otklon=@otklon,psihomotor=@psihomotor,intelect=@intelect,time=@time,medrab=@medrab) " +
           " where id = @id ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idp", SqlDbType.Int, 6));
            cmd.Parameters["@idp"].Value = emp1.Idp;
            cmd.Parameters.Add(new SqlParameter("@grupkrov", SqlDbType.NVarChar, 150));
            cmd.Parameters["@grupkrov"].Value = emp1.Grupkrov;
            cmd.Parameters.Add(new SqlParameter("@rezus", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rezus"].Value = emp1.Rezus;
            cmd.Parameters.Add(new SqlParameter("@kategreben", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kategreben"].Value = emp1.Kategreben;
            cmd.Parameters.Add(new SqlParameter("@kategsocial", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kategsocial"].Value = emp1.Kategsocial;
            cmd.Parameters.Add(new SqlParameter("@grupzdorov", SqlDbType.NVarChar, 150));
            cmd.Parameters["@grupzdorov"].Value = emp1.Grupzdorov;
            cmd.Parameters.Add(new SqlParameter("@kyrenie", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kyrenie"].Value = emp1.Kyrenie;
            cmd.Parameters.Add(new SqlParameter("@alcogol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@alcogol"].Value = emp1.Alcogol;
            cmd.Parameters.Add(new SqlParameter("@narkot", SqlDbType.NVarChar, 150));
            cmd.Parameters["@narkot"].Value = emp1.Narkot;
            cmd.Parameters.Add(new SqlParameter("@alerg", SqlDbType.NVarChar, 150));
            cmd.Parameters["@alerg"].Value = emp1.Alerg;
            cmd.Parameters.Add(new SqlParameter("@neperen", SqlDbType.NVarChar, 150));
            cmd.Parameters["@neperen"].Value = emp1.Neperen;
            cmd.Parameters.Add(new SqlParameter("@haract", SqlDbType.NVarChar, 150));
            cmd.Parameters["@haract"].Value = emp1.Haract;
            cmd.Parameters.Add(new SqlParameter("@anamnez", SqlDbType.NVarChar, 150));
            cmd.Parameters["@anamnez"].Value = emp1.Anamnez;
            cmd.Parameters.Add(new SqlParameter("@invalid", SqlDbType.NVarChar, 150));
            cmd.Parameters["@invalid"].Value = emp1.Invalid;
            cmd.Parameters.Add(new SqlParameter("@otklon", SqlDbType.NVarChar, 150));
            cmd.Parameters["@otklon"].Value = emp1.Otklon;
            cmd.Parameters.Add(new SqlParameter("@psihomotor", SqlDbType.NVarChar, 150));
            cmd.Parameters["@psihomotor"].Value = emp1.Psihomotor;
            cmd.Parameters.Add(new SqlParameter("@intelect", SqlDbType.Int, 3));
            cmd.Parameters["@intelect"].Value = emp1.Intelect;
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.NVarChar, 150));
            cmd.Parameters["@time"].Value = emp1.Time;
            cmd.Parameters.Add(new SqlParameter("@medrab", SqlDbType.NVarChar, 150));
            cmd.Parameters["@medrab"].Value = emp1.Medrab;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = emp1.Id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return emp1.Id;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Обновление информации ЭМК");
            }
            finally
            {
                con.Close();
            }
        }



        /// <summary>
        /// Добавление emk в базу
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int InsertIsledovanie(isledovanie emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [isledovanie] (idp, name, result, about,files, diagnoz, date, idv) " +
           "VALUES ( @idp, @name, @result, @about,@files,@diagnoz, @date, @idv) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idp", SqlDbType.Int, 6));
            cmd.Parameters["@idp"].Value = emp1.Idp;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 150));
            cmd.Parameters["@name"].Value = emp1.Name;
            cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 150));
            cmd.Parameters["@result"].Value = emp1.Result;
            cmd.Parameters.Add(new SqlParameter("@about", SqlDbType.NVarChar, 150));
            cmd.Parameters["@about"].Value = emp1.About;
            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.NVarChar, 150));
            cmd.Parameters["@date"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@files", SqlDbType.NVarChar, 100));
            cmd.Parameters["@files"].Value = emp1.Files;
            cmd.Parameters.Add(new SqlParameter("@diagnoz", SqlDbType.NVarChar, 100));
            cmd.Parameters["@diagnoz"].Value = emp1.Diagnoz;
            cmd.Parameters.Add(new SqlParameter("@idv", SqlDbType.NVarChar, 150));
            cmd.Parameters["@idv"].Value = emp1.Idv;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи об исследовании"+ e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// вывод emk
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public List<isledovanie> GetAllIsledovanie(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, idp, name, result, about,files,diagnoz, date, idv " +
           "from isledovanie where idp = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            List<isledovanie> list = new List<isledovanie>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    isledovanie mem = new isledovanie();
                    mem.Id = (int)reader["id"];
                    mem.Idp = (int)reader["idp"];
                    mem.Name = (string)reader["name"];
                    mem.Result = (string)reader["result"];
                    mem.About = (string)reader["about"];
                    mem.Diagnoz = (string)reader["diagnoz"];
                     mem.Files = (string)reader["files"];
                    
                    mem.Data = (string)reader["date"];
                    mem.Idv = (int)reader["idv"];
                    
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод записей пациента");
            }
            finally
            {
                con.Close();
            }
        }
     
        /// <summary>
        /// Добавление рецепта в базу
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int InsertRecept(recept emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [recept] (idp, idd, regnom, serial, number, date, idl, forma, doza,kratnost,kolvodoz,profilact) " +
           "VALUES ( @idp, @idd, @regnom, @serial, @number, @date, @idl, @forma, @doza, @kratnost, @kolvodoz, @profilact) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idp", SqlDbType.Int, 6));
            cmd.Parameters["@idp"].Value = emp1.Idp;
            cmd.Parameters.Add(new SqlParameter("@idd", SqlDbType.Int, 6));
            cmd.Parameters["@idd"].Value = emp1.Idv;
            cmd.Parameters.Add(new SqlParameter("@idl", SqlDbType.Int, 6));
            cmd.Parameters["@idl"].Value = emp1.Idl;
            cmd.Parameters.Add(new SqlParameter("@regnom", SqlDbType.NVarChar, 150));
            cmd.Parameters["@regnom"].Value = emp1.Regnom;
            cmd.Parameters.Add(new SqlParameter("@serial", SqlDbType.NVarChar, 150));
            cmd.Parameters["@serial"].Value = emp1.Serial;
            cmd.Parameters.Add(new SqlParameter("@number", SqlDbType.NVarChar, 150));
            cmd.Parameters["@number"].Value = emp1.Number;
            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.NVarChar, 150));
            cmd.Parameters["@date"].Value = emp1.Data;
            cmd.Parameters.Add(new SqlParameter("@forma", SqlDbType.NVarChar, 150));
            cmd.Parameters["@forma"].Value = emp1.Forma;
            cmd.Parameters.Add(new SqlParameter("@doza", SqlDbType.NVarChar, 150));
            cmd.Parameters["@doza"].Value = emp1.Doza;
            cmd.Parameters.Add(new SqlParameter("@kratnost", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kratnost"].Value = emp1.Kratnost;
            cmd.Parameters.Add(new SqlParameter("@kolvodoz", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kolvodoz"].Value = emp1.Kolvodoz;
            cmd.Parameters.Add(new SqlParameter("@profilact", SqlDbType.NVarChar, 150));
            cmd.Parameters["@profilact"].Value = emp1.Profilakt;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи о рецепте"+ e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// вывод рецептов пациента
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public List<recept> GetAllRecept(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, idp, idd, regnom, serial, number, date, idl, forma, doza, kratnost, " +
           "kolvodoz, profilact from recept where idp = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            List<recept> list = new List<recept>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    recept mem = new recept();
                    mem.Id = (int)reader["id"];
                    mem.Idp = (int)reader["idp"];
                    mem.Idv = (int)reader["idd"];
                    mem.Regnom = (string)reader["regnom"];
                    mem.Serial = (string)reader["serial"];
                    mem.Number = (string)reader["number"];
                    mem.Data = (string)reader["date"];
                    mem.Idl = (int)reader["idl"];
                    mem.Forma = (string)reader["forma"];
                    mem.Doza = (string)reader["doza"];
                    mem.Kratnost = (string)reader["kratnost"];
                    mem.Doza = (string)reader["kolvodoz"];
                    mem.Kratnost = (string)reader["profilact"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод рецептов");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление метрик пациента
        /// </summary>
        /// <param name="emp1">
        /// обьект метрика</param>
        /// <returns>
        /// ид записи
        /// </returns>
        public int InsertMetrika(metrika emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [metrica] ( idpac,okrgol,okrgrud,okrtal,temper,chastota,rost,massa,indeks,sistol,diastol,puls,about,date,medrab) " +
           "VALUES ( @idpac,@okrgol,@okrgrud,@okrtal,@temper,@chastota,@rost,@massa,@indeks,@sistol,@diastol,@puls,@about,@date,@medrab) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@idpac", SqlDbType.Int, 6));
            cmd.Parameters["@idpac"].Value = emp1.Idp;
            cmd.Parameters.Add(new SqlParameter("@okrgol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@okrgol"].Value = emp1.Okrgol;
            cmd.Parameters.Add(new SqlParameter("@okrgrud", SqlDbType.NVarChar, 150));
            cmd.Parameters["@okrgrud"].Value = emp1.Okrgrud;
            cmd.Parameters.Add(new SqlParameter("@okrtal", SqlDbType.NVarChar, 150));
            cmd.Parameters["@okrtal"].Value = emp1.Okrtal;
            cmd.Parameters.Add(new SqlParameter("@temper", SqlDbType.NVarChar, 150));
            cmd.Parameters["@temper"].Value = emp1.Temper;
            cmd.Parameters.Add(new SqlParameter("@chastota", SqlDbType.NVarChar, 150));
            cmd.Parameters["@chastota"].Value = emp1.Chastota;
            cmd.Parameters.Add(new SqlParameter("@rost", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rost"].Value = emp1.Rost;
            cmd.Parameters.Add(new SqlParameter("@massa", SqlDbType.NVarChar, 150));
            cmd.Parameters["@massa"].Value = emp1.Massa;
            cmd.Parameters.Add(new SqlParameter("@indeks", SqlDbType.NVarChar, 150));
            cmd.Parameters["@indeks"].Value = emp1.Indeks;
            cmd.Parameters.Add(new SqlParameter("@sistol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sistol"].Value = emp1.Sistol;
            cmd.Parameters.Add(new SqlParameter("@diastol", SqlDbType.NVarChar, 150));
            cmd.Parameters["@diastol"].Value = emp1.Diastol;
            cmd.Parameters.Add(new SqlParameter("@puls", SqlDbType.NVarChar, 150));
            cmd.Parameters["@puls"].Value = emp1.Puls;
            cmd.Parameters.Add(new SqlParameter("@about", SqlDbType.NVarChar, 100));
            cmd.Parameters["@about"].Value = emp1.About;
            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.NVarChar, 150));
            cmd.Parameters["@date"].Value = emp1.Date;
            cmd.Parameters.Add(new SqlParameter("@medrab", SqlDbType.Int, 6));
            cmd.Parameters["@medrab"].Value = emp1.Medrab;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление записи метрик" + e);
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Вывод всех метрик пациента
        /// </summary>
        /// <param name="id">
        /// ид пациента
        /// </param>
        /// <returns>
        /// лист метрик
        /// </returns>
        public List<metrika> GetAllMetriks(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from metrica where idpac = @idpac ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@idpac", SqlDbType.Int, 6));
            cmd.Parameters["@idpac"].Value = id;
            List<metrika> list = new List<metrika>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    metrika mem = new metrika();
                    mem.Id = (int)reader["id"];
                    mem.Idp = (int)reader["idpac"];
                    mem.Medrab = Convert.ToInt32((string)reader["medrab"]);
                    mem.Chastota = (string)reader["chastota"];
                    mem.About = (string)reader["about"];
                    mem.Date = (string)reader["date"];
                    mem.Diastol = (string)reader["diastol"];
                    mem.Indeks = (string)reader["indeks"];
                    mem.Massa = (string)reader["massa"];
                    mem.Okrgol = (string)reader["okrgol"];
                    mem.Okrgrud = (string)reader["okrgrud"];
                    mem.Okrtal = (string)reader["okrtal"];
                    mem.Puls = (string)reader["puls"];
                    mem.Rost = (string)reader["rost"];
                    mem.Sistol = (string)reader["sistol"];
                    mem.Temper = (string)reader["temper"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех метрик пациента"+e.Message);
            }
            finally
            {
                con.Close();
            }
        }



        /// <summary>
        /// Вывод всех записей на прием
        /// </summary>
        /// <param name="id">ИД врача</param>
        /// <returns></returns>
        public List<doctordesk> GetAllDesk(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from visits where doctorID = @did ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@did", SqlDbType.Int, 6));
            cmd.Parameters["@did"].Value = id;
            List<doctordesk> list = new List<doctordesk>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doctordesk mem = new doctordesk();
                    mem.Id = (int)reader["id"];
                    mem.DoctorID = (int)reader["doctorID"];
                    mem.Code = (string)reader["code"];
                    mem.PacientID = (int)reader["pacientID"];
                    mem.Mo = (int)reader["mo"];
                    mem.Data = (string)reader["data"];
                    mem.Time = (string)reader["time"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех записей на прием" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public List<doctordesk> GetAlDesk()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from visits  ", con);
            cmd.CommandType = CommandType.Text;

            List<doctordesk> list = new List<doctordesk>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doctordesk mem = new doctordesk();
                    mem.Id = (int)reader["id"];
                    mem.DoctorID = (int)reader["doctorID"];
                    mem.Code = (string)reader["code"];
                    mem.PacientID = (int)reader["pacientID"];
                    mem.Mo = (int)reader["mo"];
                    mem.Data = (string)reader["data"];
                    mem.Time = (string)reader["time"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех записей на прием" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод всего расписания врача
        /// </summary>
        /// <param name="id">ИД врача</param>
        /// <returns></returns>
        public List<doctordesks> GetAllDoctorDesk(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from doctordesk where doctorID = @did ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@did", SqlDbType.Int, 6));
            cmd.Parameters["@did"].Value = id;
            List<doctordesks> list = new List<doctordesks>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doctordesks mem = new doctordesks();
                    mem.Id = (int)reader["id"];
                    mem.DoctorID = (int)reader["doctorID"];
                    mem.Mo = (int)reader["mo"];
                    mem.Data = (string)reader["data"];
                    mem.Time = (string)reader["time"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод расписания врача" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteDoctor(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from doctor where id = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;
            SqlCommand cmd2 = new SqlCommand("Delete from doctorpassword where doctorID = @id ", con);
            cmd2.CommandType = CommandType.Text;

            cmd2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd2.Parameters["@id"].Value = id;
            SqlCommand cmd3 = new SqlCommand("Delete from doctordesk where doctorID = @id ", con);
            cmd3.CommandType = CommandType.Text;

            cmd3.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd3.Parameters["@id"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление доктор" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteRegistrator(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from registrpassword where id = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление регистр" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
       
        public void DeleteMO(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from mo where id = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление мед учреждения" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteMoServ(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from moserv where idmo = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление услуг мед учреждения" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteServ(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from service where id = @id ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление услуги" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод всего расписания врача
        /// </summary>
        /// <param name="id">ИД врача</param>
        /// <returns></returns>
        public void DeleteDoctorDesk(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from doctordesk where doctorID = @did ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@did", SqlDbType.Int, 6));
            cmd.Parameters["@did"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление расписания доктора" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteDesk(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Delete from visits where visits.id = @did ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@did", SqlDbType.Int, 6));
            cmd.Parameters["@did"].Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Удаление записи к врачу" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод всех записей на услуги по ид услуги
        /// </summary>
        /// <param name="id">ИД услуги</param>
        /// <returns></returns>
        public List<servicetime> GetAllServiceTime(int ids)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from servicetime where service = @ids ", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@ids", SqlDbType.Int, 6));
            cmd.Parameters["@ids"].Value = ids;
            List<servicetime> list = new List<servicetime>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    servicetime mem = new servicetime();
                    mem.Id = (int)reader["id"];

                    mem.Idpac = (int)reader["idpac"];
                    mem.Service = (int)reader["service"];
                    mem.Service = (int)reader["service"];
                    mem.Data = (string)reader["data"];
                    mem.Time = (string)reader["time"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех записей на прием" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывод всех записей на услуги
        /// </summary>
        /// <returns></returns>
        public List<servicetime> GetAllServicesTime()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from servicetime ", con);
            cmd.CommandType = CommandType.Text;

            
            List<servicetime> list = new List<servicetime>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    servicetime mem = new servicetime();
                    mem.Id = (int)reader["id"];
                    
                    mem.Idpac = (int)reader["idpac"];
                    mem.Service = (int)reader["service"];
                    mem.Data = (string)reader["data"];
                    mem.Time = (string)reader["time"];

                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех записей на прием" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление нового врача в базу
        /// </summary>
        /// <param name="emp1">
        /// обьект пациент
        /// </param>
        /// <returns>
        /// результат, id записи
        /// </returns>
        public int InsertDoctor(doctor emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[doctor] ([name],[surname],[midname],[doljnost],[namemo],[kabin],[idspec],[kvalif])"+
            "VALUES (@name,@surname,@midname,@doljnost,@namemo,@kabin,@idspec,@kvalif) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 150));
            cmd.Parameters["@name"].Value = emp1.Name;
            cmd.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar, 150));
            cmd.Parameters["@surname"].Value = emp1.Sur;
            cmd.Parameters.Add(new SqlParameter("@midname", SqlDbType.NVarChar, 150));
            cmd.Parameters["@midname"].Value = emp1.Mid;
            cmd.Parameters.Add(new SqlParameter("@doljnost", SqlDbType.NVarChar, 150));
            cmd.Parameters["@doljnost"].Value = emp1.Dolj;
            cmd.Parameters.Add(new SqlParameter("@namemo", SqlDbType.NVarChar, 150));
            cmd.Parameters["@namemo"].Value = emp1.Mo;
            cmd.Parameters.Add(new SqlParameter("@kabin", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kabin"].Value = emp1.Kabin;
            cmd.Parameters.Add(new SqlParameter("@idspec", SqlDbType.Int, 6));
            cmd.Parameters["@idspec"].Value = emp1.Idspec;
            cmd.Parameters.Add(new SqlParameter("@kvalif", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kvalif"].Value = emp1.Kvalif;
            
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление доктора");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Установка пароля пользователя
        /// </summary>
        /// <param name="password">
        /// Пароль
        /// </param>
        /// <param name="patientid">
        /// Пациент
        /// </param>
        /// <returns>
        /// Запись (id)
        /// </returns>
        public int InsertpatientPassword(string password, int patientid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into patientpassword(patientID, password) values (@patientid, @password) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
            cmd.Parameters["@password"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@patientid", SqlDbType.Int, 6));
            cmd.Parameters["@patientid"].Value = patientid;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление пароля пациента");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Установка пароля врача
        /// </summary>
        /// <param name="password"></param>
        /// <param name="patientid"></param>
        /// <returns></returns>
        public int InsertDoctorPassword(string password, int doctorid, string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into doctorpassword(doctorID, password, email) values (@doctorid, @password,@email) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
            cmd.Parameters["@password"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters.Add(new SqlParameter("@doctorid", SqlDbType.Int, 6));
            cmd.Parameters["@doctorid"].Value = doctorid;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление пароля пациента");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление сотрудника регитратуры
        /// </summary>
        /// <param name="password"></param>
        /// <param name="registrid"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="fio"></param>
        /// <param name="comm"></param>
        /// <returns></returns>
        public int InsertRegistrator(string password, string email, string phone, string fio, string comm, int mo)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into registrpassword( password, fio, phone, email, comm, mo)"+
                " values ( @password, @fio, @phone, @email, @comm, @mo) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
            cmd.Parameters["@password"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters.Add(new SqlParameter("@fio", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fio"].Value = fio;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone"].Value = phone;
            cmd.Parameters.Add(new SqlParameter("@comm", SqlDbType.NVarChar, 150));
            cmd.Parameters["@comm"].Value = comm;

            cmd.Parameters.Add(new SqlParameter("@mo", SqlDbType.Int, 6));
            cmd.Parameters["@mo"].Value = mo;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление сотрудника регистратуры");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление администратора
        /// </summary>
        /// <param name="password"></param>
        /// <param name="registrid"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="fio"></param>
        /// <param name="comm"></param>
        /// <returns></returns>
        public int InsertAdmin(string password, string email, string phone, string fio, string comm)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into adminpassword( password, fio, phone, email, comm)" +
                " values ( @password, @fio, @phone, @email, @comm) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
            cmd.Parameters["@password"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters.Add(new SqlParameter("@fio", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fio"].Value = fio;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone"].Value = phone;
            cmd.Parameters.Add(new SqlParameter("@comm", SqlDbType.NVarChar, 150));
            cmd.Parameters["@comm"].Value = comm;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление админстратора системы");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вход пользователя, обьединеный метод
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="doctor">Если доктор - email</param>
        /// <param name="patient">Если пациент - снилс</param>
        /// <param name="registr">Если сотр регистратуры - email</param>
        /// <param name="admin">Если администратор - email</param>
        /// <returns>возвращает id пользователя</returns>
        public int loginuser(string password, string doctor, string patient, string registr, string admin)
        {
            int result;
            SqlConnection con = new SqlConnection(connectionString);
            if (doctor != "" && patient == "0" && registr == "0" && admin == "0")
            {
                SqlCommand cmd = new SqlCommand("Select doctorID from doctorpassword where email = @email and password=@password ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
                cmd.Parameters["@email"].Value = doctor ;
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = password;
                   
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    result = (int)reader["doctorID"];
                    reader.Close();
                    return result;
                }
                catch
                {
                    throw new ApplicationException("Ошибка входа в учетную запись доктора");
                }
                finally
                {
                    con.Close();
                }
            }
            if (doctor == "0" && patient != "0" && registr == "0" && admin == "0")
            {
                SqlCommand cmd = new SqlCommand("Select patient.patientID from patient, patientpassword where patient.snils = @patient and patientpassword.password=@password and patient.patientID = patientpassword.patientID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@patient", SqlDbType.NVarChar, 150));
                cmd.Parameters["@patient"].Value = patient;
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = password;

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    result = (int)reader["patientID"];
                    reader.Close();
                    return result;
                }
                catch
                {
                    throw new ApplicationException("Ошибка входа в учетную запись пациента");
                }
                finally
                {
                    con.Close();
                }
            }
            if (doctor == "0" && patient == "0" && registr != "0" && admin == "0")
            {
                SqlCommand cmd = new SqlCommand("Select id from registrpassword where email = @email and password=@password ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
                cmd.Parameters["@email"].Value = registr;
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = password;

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    result = (int)reader["id"];
                    reader.Close();
                    return result;
                }
                catch
                {
                    throw new ApplicationException("Ошибка входа в учетную запись сотрудника регистратора");
                }
                finally
                {
                    con.Close();
                }
            }
            if (doctor == "0" && patient == "0" && registr == "0" && admin != "0")
            {
                SqlCommand cmd = new SqlCommand("Select id from adminpassword where email = @email and password=@password ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150));
                cmd.Parameters["@email"].Value = admin;
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = password;

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    result = (int)reader["id"];
                    reader.Close();
                    return result;
                }
                catch
                {
                    throw new ApplicationException("Ошибка входа в учетную запись администратора");
                }
                finally
                {
                    con.Close();
                }
            }
           //Выход
            return 0;
        }
        /// <summary>
        /// Установка пароля пользователя
        /// </summary>
        /// <param name="password">
        /// Пароль
        /// </param>
        /// <param name="patientid">
        /// Пациент
        /// </param>
        /// <returns>
        /// Запись (id)
        /// </returns>
        public int SendSMS(string text, int otpatientid, int dopatientid, int otdoctorid, int dodoctorid, string time)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into sms(data, otpac,dopac,otdoc,dodoc,time) values (@data, @otpac, @dopac, @otdoc, @dodoc, @time) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 150));
            cmd.Parameters["@data"].Value = text; 
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.NVarChar, 150));
            cmd.Parameters["@time"].Value = time;
            cmd.Parameters.Add(new SqlParameter("@otpac", SqlDbType.Int, 6));
            cmd.Parameters["@otpac"].Value = otpatientid;
            cmd.Parameters.Add(new SqlParameter("@dopac", SqlDbType.Int, 6));
            cmd.Parameters["@dopac"].Value = dopatientid;
            cmd.Parameters.Add(new SqlParameter("@otdoc", SqlDbType.Int, 6));
            cmd.Parameters["@otdoc"].Value = otdoctorid;
            cmd.Parameters.Add(new SqlParameter("@dodoc", SqlDbType.Int, 6));
            cmd.Parameters["@dodoc"].Value = dodoctorid;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Отправка сообщения");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Получить все сообщения
        /// </summary>
        /// <returns>
        /// List всех сообщений
        /// </returns>
        public List<sms> GetAllSMS()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, data, otpac, dopac, otdoc, dodoc, time from sms", con);
            cmd.CommandType = CommandType.Text;

            List<sms> list = new List<sms>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sms mem = new sms();
                    mem.Id = (int)reader["id"];
                    mem.Data = (string)reader["data"];
                    mem.Time = (string)reader["time"];
                    mem.Otpac = Convert.ToInt32((string)reader["otpac"]);
                    mem.Dopac = Convert.ToInt32((string)reader["dopac"]);
                    mem.Otdoc = Convert.ToInt32((string)reader["otdoc"]);
                    mem.Dodoc = Convert.ToInt32((string)reader["dodoc"]);
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод сообщений");
            }
            finally
            {
                con.Close();
            }
        }
        public patient Getpatient(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from patient where patientID = @patientID", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@patientID", SqlDbType.Int, 6));
            cmd.Parameters["@patientID"].Value = id;

            patient patient = new patient();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patient.PatientID = id;
                    patient.Data = (string)reader["data"];
                    patient.Snils = (string)reader["snils"];
                    patient.Inn = (string)reader["inn"];
                    patient.Fam = (string)reader["fam"];
                    patient.Im = (string)reader["im"];
                    patient.Otch = (string)reader["otch"];
                    patient.Datr = (string)reader["datr"];
                    patient.Mest = (string)reader["mest"];
                    patient.Vozr = (string)reader["vozr"];
                    patient.Pol = (string)reader["pol"];
                    patient.Dok = (string)reader["dok"];
                    patient.Sernom = (string)reader["sernom"];
                    patient.Kemv = (string)reader["kemv"];
                    patient.Datv = (string)reader["datv"];
                    patient.Rassa = (string)reader["rassa"];
                    patient.Sem = (string)reader["sem"];
                    patient.Det = (int)reader["det"];
                    patient.Mo = (int)reader["mo"];
                    patient.Obraz = (string)reader["obraz"];
                    patient.Rabot = (string)reader["rabot"];
                    patient.Dolg = (string)reader["dolg"];
                    patient.Trud = (string)reader["trud"];
                    patient.Oms = (string)reader["oms"];
                    patient.Strax =  (string)reader["strax"];
                    patient.Typpolis = (string)reader["typpolis"];
                    patient.Soms = (string)reader["soms"];
                    patient.Noms = (string)reader["noms"];
                    patient.Datoms = (string)reader["datoms"];
                    patient.Dms = (string)reader["dms"];
                    patient.School = (string)reader["school"];
                }
                reader.Close();
                return patient;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод пациента" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Представитель пациента
        /// </summary>
        /// <param name="id">
        /// пациент
        /// </param>
        /// <returns>
        /// обьект представитель
        /// </returns>
        public predstavitel GetPatientPredstavitel(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from predstavitel where pacientID = @pid", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int, 6));
            cmd.Parameters["@pid"].Value = id;

            predstavitel mem = new predstavitel();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mem.Id = (int)reader["id"];
                    mem.PatientID = (int)reader["pacientid"];
                    mem.Fio = (string)reader["fio"];
                    mem.Rodstvo = (string)reader["rodstvo"];
                    mem.Doc = (string)reader["doc"];
                    mem.Num = (string)reader["num"];
                    mem.Vidan = (string)reader["vidan"];
                    mem.Kogda = (string)reader["kogda"];
                    mem.Address = (string)reader["address"];

                    mem.Sphone = (string)reader["sphone"];
                    mem.Phone = (string)reader["phone"];
                    mem.Phone2 = (string)reader["phone2"];
                }

                reader.Close();
                return mem;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx.  Возвращение представителя пациента");
            }
            finally
            {
                con.Close();
            }
        }

        public int GetRegistratorMO(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT [mo] FROM [BD].[dbo].[registrpassword]  where id = @pid", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int, 6));
            cmd.Parameters["@pid"].Value = id;

            int ider = 0;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ider = (int)reader["mo"];
                   
                }

                reader.Close();
                return ider;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Код мо для регистратора" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Добавление представителя пациента
        /// </summary>
        /// <param name="emp1">
        /// представитель
        /// </param>
        /// <returns>
        /// id представителя
        /// </returns>
        public int InsertPredstavitel(predstavitel emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [BD].[dbo].[predstavitel] ([pacientid],[fio],[rodstvo],[doc],[num],[vidan],[kogda],[address],[sphone],[phone]" +
           ",[phone2]) VALUES (@pacientid,@fio,@rodstvo,@doc,@num,@vidan,@kogda,@address,@sphone,@phone" +
           ",@phone2) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@pacientid", SqlDbType.Int, 6));
            cmd.Parameters["@pacientid"].Value = emp1.PatientID;
            cmd.Parameters.Add(new SqlParameter("@fio", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fio"].Value = emp1.Fio;
            cmd.Parameters.Add(new SqlParameter("@rodstvo", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rodstvo"].Value = emp1.Rodstvo;
            cmd.Parameters.Add(new SqlParameter("@doc", SqlDbType.NVarChar, 150));
            cmd.Parameters["@doc"].Value = emp1.Doc;
            cmd.Parameters.Add(new SqlParameter("@num", SqlDbType.NVarChar, 150));
            cmd.Parameters["@num"].Value = emp1.Num;
            cmd.Parameters.Add(new SqlParameter("@vidan", SqlDbType.NVarChar, 150));
            cmd.Parameters["@vidan"].Value = emp1.Vidan;
            cmd.Parameters.Add(new SqlParameter("@kogda", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kogda"].Value = emp1.Kogda;
            cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 150));
            cmd.Parameters["@address"].Value = emp1.Address;
            cmd.Parameters.Add(new SqlParameter("@sphone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sphone"].Value = emp1.Sphone;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone"].Value = emp1.Phone;
            cmd.Parameters.Add(new SqlParameter("@phone2", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone2"].Value = emp1.Phone2;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Добавление представителя пациента");
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Добавление представителя пациента
        /// </summary>
        /// <param name="emp1">
        /// представитель
        /// </param>
        /// <returns>
        /// id представителя
        /// </returns>
        public int UpdatePredstavitel(predstavitel emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update predstavitel set fio=@fio,rodstvo=@rodstvo,doc=@doc,num=@num,vidan=@vidan,kogda=@kogda,address=@address,sphone=@sphone,phone=@phone" +
           ",phone2=@phone2 where pacientid = @id ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@fio", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fio"].Value = emp1.Fio;
            cmd.Parameters.Add(new SqlParameter("@rodstvo", SqlDbType.NVarChar, 150));
            cmd.Parameters["@rodstvo"].Value = emp1.Rodstvo;
            cmd.Parameters.Add(new SqlParameter("@doc", SqlDbType.NVarChar, 150));
            cmd.Parameters["@doc"].Value = emp1.Doc;
            cmd.Parameters.Add(new SqlParameter("@num", SqlDbType.NVarChar, 150));
            cmd.Parameters["@num"].Value = emp1.Num;
            cmd.Parameters.Add(new SqlParameter("@vidan", SqlDbType.NVarChar, 150));
            cmd.Parameters["@vidan"].Value = emp1.Vidan;
            cmd.Parameters.Add(new SqlParameter("@kogda", SqlDbType.NVarChar, 150));
            cmd.Parameters["@kogda"].Value = emp1.Kogda;
            cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 150));
            cmd.Parameters["@address"].Value = emp1.Address;
            cmd.Parameters.Add(new SqlParameter("@sphone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@sphone"].Value = emp1.Sphone;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone"].Value = emp1.Phone;
            cmd.Parameters.Add(new SqlParameter("@phone2", SqlDbType.NVarChar, 150));
            cmd.Parameters["@phone2"].Value = emp1.Phone2;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = emp1.PatientID;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return emp1.PatientID;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Обновление информации о представителе пациента" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public int UpdatePassword(string type,int login, string oldpassword, string newpassword)
        {
            if (type == "user")
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Update patientpassword set password=@password" +
               " where patientID = @id ", con);

                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = newpassword;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
                cmd.Parameters["@id"].Value = login;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Ошибка данныx. Обновление пароля пользователя" + e.Message);
                }
                finally
                {
                    con.Close();

                }
            }
            if (type == "doctor")
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Update doctorpassword set password=@password" +
               " where doctorID = @id ", con);

                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = newpassword;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
                cmd.Parameters["@id"].Value = login;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 2;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Ошибка данныx. Обновление пароля доктора" + e.Message);
                }
                finally
                {
                    con.Close();

                }
            }
            if (type == "registr")
            {

                 SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Update registrpassword set password=@password" +
               " where id = @id ", con);

                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150));
                cmd.Parameters["@password"].Value = newpassword;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
                cmd.Parameters["@id"].Value = login;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return 3;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Ошибка данныx. Обновление пароля сотрудника регистратуры" + e.Message);
                }
                finally
                {
                    con.Close();

                }

            }
            return 0;
            


           
            
        }
       
        /// <summary>
        /// Вывести всех пациентов
        /// </summary>
        /// <returns>Лист</returns>
        public List<patient> GetAllPatient()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from patient ", con);
            cmd.CommandType = CommandType.Text;
            List<patient> list = new List<patient>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patient mem = new patient();
                    mem.PatientID = (int)reader["patientID"];
                mem.Data = (string)reader["data"]  ;
                mem.Snils = (string)reader["snils"] ;
                mem.Inn = (string)reader["inn"] ;
                mem.Fam = (string)reader["fam"] ;
                mem.Im = (string)reader["im"] ;
                mem.Otch = (string)reader["otch"] ;
                mem.Datr = (string)reader["datr"] ;
                mem.Mest = (string)reader["mest"] ;
                mem.Vozr = (string)reader["vozr"] ;
                mem.Pol = (string)reader["pol"] ;
                mem.Dok = (string)reader["dok"] ;
                mem.Sernom = (string)reader["sernom"] ;
                mem.Kemv = (string)reader["kemv"] ;
                mem.Datv = (string)reader["datv"] ;
                mem.Rassa = (string)reader["rassa"] ;
                mem.Sem = (string)reader["sem"] ;
                mem.Det = (int)reader["det"] ;

                mem.Mo = (int)reader["mo"];
                mem.Obraz = (string)reader["obraz"] ;
                mem.Rabot = (string)reader["rabot"] ;
                mem.Dolg = (string)reader["dolg"] ;
                mem.Trud = (string)reader["trud"] ;
                mem.Oms = (string)reader["oms"] ;
                mem.Strax = (string)reader["strax"] ;
                mem.Typpolis = (string)reader["typpolis"] ;
                mem.Soms = (string)reader["soms"] ;
                mem.Noms = (string)reader["noms"] ;
                mem.Datoms = (string)reader["datoms"] ;
                mem.Dms = (string)reader["dms"] ;
                mem.School = (string)reader["school"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех пациентов" + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Вывести всех докторов
        /// </summary>
        /// <returns></returns>
        public List<doctor> GetAllDoctors()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, Name, Surname, midname, doljnost, namemo, kabin, idspec,kvalif from doctor ", con);
            cmd.CommandType = CommandType.Text;
            List<doctor> list = new List<doctor>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doctor mem = new doctor();
                    mem.Id = (int)reader["id"];
                    mem.Name = (string)reader["Name"];
                    mem.Sur = (string)reader["Surname"];
                    mem.Mid = (string)reader["midname"];
                    mem.Dolj = (string)reader["doljnost"];
                    mem.Mo = (string)reader["namemo"];
                    mem.Kabin = (string)reader["kabin"];
                    mem.Idspec = (int)reader["idspec"];
                    mem.Kvalif = (string)reader["kvalif"];
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех докторов");
            }
            finally
            {
                con.Close();
            }
        }
       

    }

}