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
/*
 * Класс "Пользователь"
 */
namespace MySqlLib
{
    public class member
    {
        public member(int memberID, string fio, 
            string phone, string email, int role)
        {
            this.memberID = memberID;
            this.fio=fio;
            this.role = role;
            this.email=email;
            this.phone=phone;
        }

        public member() { }

        private int memberID;
        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        private string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        private int role;
        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    public class client
    {
        public client(int id, 
             string email,string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            
        }

        public client() { }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
    public class membertoo
    {
        public membertoo(int memberID, string fio,
            string phone, string email, string role)
        {
            this.memberID = memberID;
            this.fio = fio;
            this.role = role;
            this.email = email;
            this.phone = phone;
        }

        public membertoo() { }

        private int memberID;
        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        private string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
    public class menedger
    {
        public menedger(int id, int idturoperator, string fio, 
            string phone, string email)
        {
            this.id = id;
            this.fio = fio;
            this.idturoperator = idturoperator;
            this.email = email;
            this.phone = phone;
        }

        public menedger() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idturoperator;
        public int Idturoperator
        {
            get { return idturoperator; }
            set { idturoperator = value; }
        }

        private string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
    public class mpassword
    {
        public mpassword(int id, int mid, string password)
        {
            this.id = id;
            this.mid = mid;
            this.password = password;
        }

        public mpassword() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int mid;
        public int Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
    
    public class menedgertoo
    {
        public menedgertoo(int id, string turoperator, string fio,
            string phone, string email)
        {
            this.id = id;
            this.fio = fio;
            this.turoperator = turoperator;
            this.email = email;
            this.phone = phone;
        }

        public menedgertoo() { }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string turoperator;
        public string Turoperator
        {
            get { return turoperator; }
            set { turoperator = value; }
        }

        private string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
    public class role
    {
        public role(int id, string name, string comment)
        {
            this.id = id;
            this.name= name;
            this.comment = comment;
            
        }

        public role() { }

        private int id;
        public int ID
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

        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
