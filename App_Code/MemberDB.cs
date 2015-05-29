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

namespace MySqlLib
{
    public class MemberDB
    {
        private string connectionString;

        public MemberDB()
        {
            // Извлечь из файла web.config строку соединения по умолчанию
            connectionString = WebConfigurationManager.
                ConnectionStrings["mssqltur"].ConnectionString;
        }

        public MemberDB(string connectionStringCustom)
        {
            // Извлечь из файла web.config другую строку соединения
            connectionString = WebConfigurationManager.
                ConnectionStrings[connectionStringCustom].ConnectionString;
        }

        /* public member ValidateUser(string login, string passwd)
         {
             SqlConnection con = new SqlConnection(connectionString);
             SqlCommand cmd = new SqlCommand("ValidateUser", con);
             cmd.CommandType = CommandType.Text;
             cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.NVarChar, 30));
             cmd.Parameters["@login"].Value = login;
             cmd.Parameters.Add(new SqlParameter("@passwd", SqlDbType.NVarChar, 20));
             cmd.Parameters["@passwd"].Value = passwd;
             try
             {
                 con.Open();
                 SqlDataReader reader = cmd.ExecuteReader();
                 member emp = new member(
                     (int)reader["memberID"],
                     (string)reader["fio"],
                     (string)reader["login"],
                     (string)reader["passwd"],
                     (string)reader["email"],
                     (string)reader["phone"],
                     (int)reader["dolgn"]);
                
                 reader.Close();
                 return emp;
             }
             catch
             {
                 throw new ApplicationException("Ошибка данныx Проверка пользователя");
             }
             finally
             {
                 con.Close();
             }
         }*/

        public int InsertMember(member emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into member(fio,role,email,phone) values (@fio,@role,@email,@phone) SET @memberID = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@fio", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fio"].Value = emp1.Fio;
            cmd.Parameters.Add(new SqlParameter("@role", SqlDbType.Int, 6));
            cmd.Parameters["@role"].Value = emp1.Role;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
            cmd.Parameters["@email"].Value = emp1.Email;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 20));
            cmd.Parameters["@phone"].Value = emp1.Phone;
            cmd.Parameters.Add(new SqlParameter("@memberID", SqlDbType.Int, 6));
            cmd.Parameters["@memberID"].Direction = ParameterDirection.Output;




            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@memberID"].Value;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Добавление сотрудника");
            }
            finally
            {
                con.Close();
            }
        }
        public int RegistrationClient(client emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into client(email,password) values (@email,@password) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
            cmd.Parameters["@email"].Value = emp1.Email;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 20));
            cmd.Parameters["@password"].Value = emp1.Password;
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
                throw new ApplicationException("Ошибка данныx. Добавление сотрудника");
            }
            finally
            {
                con.Close();
            }
        }
        public int InsertMenedger(menedger emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into turmenedger(fio,idturoperator,email,phone) values (@fio,@idturoperator,@email,@phone) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@fio", SqlDbType.NVarChar, 150));
            cmd.Parameters["@fio"].Value = emp1.Fio;
            cmd.Parameters.Add(new SqlParameter("@idturoperator", SqlDbType.Int, 6));
            cmd.Parameters["@idturoperator"].Value = emp1.Idturoperator;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
            cmd.Parameters["@email"].Value = emp1.Email;
            cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 20));
            cmd.Parameters["@phone"].Value = emp1.Phone;
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
                throw new ApplicationException("Ошибка данныx. Добавление сотрудника туроператора");
            }
            finally
            {
                con.Close();
            }
        }
        public int InsertMemberPassword(string password, int memberid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into memberpassword(memberid, password) values (@memberid, @password) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 260));
            cmd.Parameters["@password"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@memberid", SqlDbType.Int, 6));
            cmd.Parameters["@memberid"].Value = memberid;
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
                throw new ApplicationException("Ошибка данныx. Добавление пароля сотрудника");
            }
            finally
            {
                con.Close();
            }
        }
        public int InsertMenedgerPassword(string password, int menedgerid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into menedgerpassword(menedgerid, password) values (@menedgerid, @password) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 260));
            cmd.Parameters["@password"].Value = password;
            cmd.Parameters.Add(new SqlParameter("@menedgerid", SqlDbType.Int, 6));
            cmd.Parameters["@menedgerid"].Value = menedgerid;
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
                throw new ApplicationException("Ошибка данныx. Добавление пароля менеджеру");
            }
            finally
            {
                con.Close();
            }
        }
        public member GetMember(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select fio, role, email, phone from member where memberID = @memberID", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@memberID", SqlDbType.Int, 6));
            cmd.Parameters["@memberID"].Value = id;

            member member = new member();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                member.MemberID = id;
                string fios = (string)reader["fio"];
                member.Fio = fios;
                member.Role = 1;
                member.Email = (string)reader["email"];
                member.Phone = (string)reader["phone"];

                reader.Close();
                return member;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод сотрудника");
            }
            finally
            {
                con.Close();
            }
        }
        public string GetMemberRole(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select name from role where member.memberID = @id and member.role = role.id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;

            

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string role = (string)reader["name"];
                

                reader.Close();
                return role;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx.  Возвращение должности");
            }
            finally
            {
                con.Close();
            }
        }
        public List<membertoo> GetAllMemberToo()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select member.memberID, member.fio, member.phone, member.email, roles.name from member, roles where member.role = roles.id", con);
            cmd.CommandType = CommandType.Text;
            
            List<membertoo> list = new List<membertoo>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    membertoo mem = new membertoo(
                    (int)reader["member.memberID"],
                    (string)reader["member.fio"],
                    (string)reader["member.phone"],
                    (string)reader["member.email"],
                    (string)reader["member.role"]);
                    list.Add(mem);
                }
                reader.Close();
                
                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех сотрудников");
            }
            finally
            {
                con.Close();
            }
        }
        public List<client> GetAllClient()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select id, email, password from client", con);
            cmd.CommandType = CommandType.Text;

            List<client> list = new List<client>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    client mem = new client(
                    (int)reader["id"],
                    (string)reader["email"],
                    (string)reader["password"]);
                    list.Add(mem);
                }
                reader.Close();

                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех клиентов");
            }
            finally
            {
                con.Close();
            }
        }
        public List<menedgertoo> GetAllMenedgerToo()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select turmenedger.id, turoperator.name, turmenedger.fio, turmenedger.phone, turmenedger.email from turmenedger, turoperator where turmenedger.idturoperator = turoperator.turoperatorID", con);
            cmd.CommandType = CommandType.Text;
            List<menedgertoo> list = new List<menedgertoo>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    menedgertoo mem = new menedgertoo(
                    (int)reader["turmenedger.id"],
                    (string)reader["turoperator.name"],
                    (string)reader["turmenedger.fio"],
                    (string)reader["turmenedger.phone"],
                    (string)reader["turmenedger.email"]
                    );
                    list.Add(mem);
                }
                reader.Close();
                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод всех менеджеров");
            }
            finally
            {
                con.Close();
            }
        }

        public menedger GetMenedger(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select fio, idturoperator, email, phone from menedger where menedger.id = @id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 6));
            cmd.Parameters["@id"].Value = id;

            menedger menedger = new menedger();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                menedger.Fio = (string)reader["fio"];
                menedger.Idturoperator = (int)reader["idturoperator"];
                menedger.Email = (string)reader["email"];
                menedger.Phone = (string)reader["phone"];

                reader.Close();
                return menedger;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод сотрудника");
            }
            finally
            {
                con.Close();
            }
        }
        public List<role> GetAllRoles()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT id, name,  comment FROM roles", con);
            cmd.CommandType = CommandType.Text;

            // Создать коллекцию для всех записей 
            List<role> list = new List<role>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    role emp = new role(
                    (int)reader["id"],
                    (string)reader["name"],
                    (string)reader["comment"]);

                    list.Add(emp);
                }
                reader.Close();
                return list;
            }
            catch
            {
                throw new ApplicationException("Ошибка данныx. Вывод должностей");
            }
            finally
            {
                con.Close();
            }
        } //Вывод всех типов
        public int InsertRole(role emp1)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Insert into roles(name, comment) values (@name, @comment) SET @id = @@IDENTITY ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50));
            cmd.Parameters["@name"].Value = emp1.Name;
            cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, 200));
            cmd.Parameters["@comment"].Value = emp1.Comment;;
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
                throw new ApplicationException("Ошибка данныx. Добавление должности");
            }
            finally
            {
                con.Close();
            }
        }



    }
}
