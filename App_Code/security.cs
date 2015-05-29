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
using System.Security.Cryptography;
using System.Text;


//namespace turist.App_Code.security
//{
//    public class security
//    {
//        private string connectionString;
//        public security()
//        {
//            // Извлечь из файла web.config строку соединения по умолчанию
//            connectionString = WebConfigurationManager.
//                ConnectionStrings["mssqltur"].ConnectionString;
//        }
//        public security(string connectionStringCustom)
//        {
//            // Извлечь из файла web.config другую строку соединения
//            connectionString = WebConfigurationManager.
//                ConnectionStrings[connectionStringCustom].ConnectionString;
//        }

//        public int peopleautho(string email, string password)
//        {
//            int id;

//            SqlConnection con = new SqlConnection(connectionString);
//            SqlCommand cmd = new SqlCommand("SELECT peopleID FROM people WHERE people.email = @email and people.id = peoplepassword.peopleid and peoplepassword.password = @password", con);
//            cmd.CommandType = CommandType.Text;
//            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
//            cmd.Parameters["@email"].Value = email;
//            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 260));
//            cmd.Parameters["@password"].Value = md5hash(password);
//            try
//            {
//                con.Open();
//                SqlDataReader reader = cmd.ExecuteReader();
//                id = (int)reader["peopleID"];
//                con.Close();
//                return id;
//            }
//            catch
//            {
//                return 0;
//            }
//            finally
//            {
//                con.Close();
//            }
//        }
//        public int memberautho(string email, string password)
//        {

//            SqlConnection con = new SqlConnection(connectionString);
//            SqlCommand cmd = new SqlCommand("Select memberID, fio, role, email, phone from member", con);
//            cmd.CommandType = CommandType.Text;
//            List<member> list = new List<member>();
//            try
//            {
//                con.Open();
//                SqlDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    member mem = new member(
//                    (int)reader["memberID"],
//                    (string)reader["fio"],
//                    (string)reader["phone"],
//                    (string)reader["email"],
//                    (int)reader["role"]
                    
//                    );
//                    list.Add(mem);
//                }
//                reader.Close();
//            }
//            catch
//            {
//                throw new ApplicationException("Ошибка данныx. Вывод всех менеджеров");
//            }
//            finally
//            {
//                con.Close();
//            }


//            SqlCommand cmd2 = new SqlCommand("SELECT id, memberid, password FROM memberpassword", con);
//            cmd2.CommandType = CommandType.Text;

//            List<mpassword> list2 = new List<mpassword>();
//            try
//            {
//                con.Open();
//                SqlDataReader reader = cmd2.ExecuteReader();
//                while (reader.Read())
//                {
//                    mpassword mem = new mpassword(
//                    (int)reader["id"],
//                    (int)reader["memberid"],
//                    (string)reader["password"]
//                    );
//                    list2.Add(mem);
//                }
//                reader.Close();
//            }
//            catch
//            {
//                throw new ApplicationException("Ошибка данныx. Вывод всех паролей менеджеров");
//            }
//            finally
//            {
//                con.Close();
//            }
//            int e = 0;
//            foreach (member i in list)
//            {
//                foreach (mpassword j in list2)
//                {
//                    if (i.MemberID == j.Mid)
//                        if (i.Email == email)
//                            if (j.Password.Trim() == password)
                                
//                                    if (i.MemberID == j.Mid)
//                                    {
//                                        e = i.MemberID;
//                                        return e;
//                                    }
                                
//                }
//            }
//             return 0;
//        }
//        public int menedgerautho(string email, string password)
//        {
            
//            SqlConnection con = new SqlConnection(connectionString);
//            SqlCommand cmd = new SqlCommand("Select turmenedger.id, turmenedger.idturoperator, turmenedger.fio, turmenedger.phone, turmenedger.email from turmenedger", con);
//            cmd.CommandType = CommandType.Text;
//            List<menedger> list = new List<menedger>();
//            try
//            {
//                con.Open();
//                SqlDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    menedger mem = new menedger(
//                    (int)reader["turmenedger.id"],
//                    (int)reader["turmenedger.idturoperator"],
//                    (string)reader["turmenedger.fio"],
//                    (string)reader["turmenedger.phone"],
//                    (string)reader["turmenedger.email"]
//                    );
//                    list.Add(mem);
//                }
//                reader.Close();
//            }
//            catch
//            {
//                throw new ApplicationException("Ошибка данныx. Вывод всех менеджеров");
//            }
//            finally
//            {
//                con.Close();
//            }

           
//            SqlCommand cmd2 = new SqlCommand("SELECT id, menedgerid, password FROM menedgerpassword", con);
//            cmd2.CommandType = CommandType.Text;
             
//           List<mpassword> list2 = new List<mpassword>();
//            try
//            {
//                con.Open();
//                SqlDataReader reader = cmd2.ExecuteReader();
//                while (reader.Read())
//                {
//                    mpassword mem = new mpassword(
//                    (int)reader["id"],
//                    (int)reader["menedgerid"],
//                    (string)reader["password"]
//                    );
//                    list2.Add(mem);
//                }
//                reader.Close();
//            }
//            catch
//            {
//                throw new ApplicationException("Ошибка данныx. Вывод всех паролей менеджеров");
//            }
//            finally
//            {
//                con.Close();
//            }

//            foreach (menedger i in list)
//            {
//                foreach (mpassword j in list2)
//                {
//                    if ((i.Id == j.Mid) && (i.Email == email) && (j.Password == password))
//                    {
//                        return 1;
//                    }
//                }
//            }
//            return 0;
//        }
//        public string md5hash(string input)
//        {
//            try
//            {
//                MD5 md5Hasher = MD5.Create();

//                // Преобразуем входную строку в массив байт и вычисляем хэш
//                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

//                // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
//                StringBuilder sBuilder = new StringBuilder();

//                // Преобразуем каждый байт хэша в шестнадцатеричную строку
//                for (int i = 0; i <= data.Length; i++)
//                {
//                    //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
//                    sBuilder.Append(data[i].ToString("x2"));
//                }
//                return sBuilder.ToString();
//            }
//            catch
//            {
//                return input;
//            }
           
//        } //hash password

//        //public List<membertoo> GetAllMemberToo()
//        //{
//        //    SqlConnection con = new SqlConnection(connectionString);
//        //    SqlCommand cmd = new SqlCommand("Select member.memberID, member.fio, member.phone, member.email, roles.name from member, roles where member.role = roles.id", con);
//        //    cmd.CommandType = CommandType.Text;

//        //    List<membertoo> list = new List<membertoo>();

//        //    try
//        //    {
//        //        con.Open();
//        //        SqlDataReader reader = cmd.ExecuteReader();

//        //        while (reader.Read())
//        //        {
//        //            membertoo mem = new membertoo(
//        //            (int)reader["member.memberID"],
//        //            (string)reader["member.fio"],
//        //            (string)reader["member.phone"],
//        //            (string)reader["member.email"],
//        //            (string)reader["member.role"]);
//        //            list.Add(mem);
//        //        }
//        //        reader.Close();

//        //        return list;
//        //    }
//        //    catch
//        //    {
//        //        throw new ApplicationException("Ошибка данныx. Вывод всех сотрудников");
//        //    }
//        //    finally
//        //    {
//        //        con.Close();
//        //    }
//        //}

//        //public List<menedgertoo> GetAllMenedgerToo()
//        //{
//        //    SqlConnection con = new SqlConnection(connectionString);
//        //    SqlCommand cmd = new SqlCommand("Select turmenedger.id, turoperator.name, turmenedger.fio, turmenedger.phone, turmenedger.email from turmenedger, turoperator where turmenedger.idturoperator = turoperator.turoperatorID", con);
//        //    cmd.CommandType = CommandType.Text;
//        //    List<menedgertoo> list = new List<menedgertoo>();
//        //    try
//        //    {
//        //        con.Open();
//        //        SqlDataReader reader = cmd.ExecuteReader();
//        //        while (reader.Read())
//        //        {
//        //            menedgertoo mem = new menedgertoo(
//        //            (int)reader["turmenedger.id"],
//        //            (string)reader["turoperator.name"],
//        //            (string)reader["turmenedger.fio"],
//        //            (string)reader["turmenedger.phone"],
//        //            (string)reader["turmenedger.email"]
//        //            );
//        //            list.Add(mem);
//        //        }
//        //        reader.Close();
//        //        return list;
//        //    }
//        //    catch
//        //    {
//        //        throw new ApplicationException("Ошибка данныx. Вывод всех менеджеров");
//        //    }
//        //    finally
//        //    {
//        //        con.Close();
//        //    }
//        //}


//    }
//}
