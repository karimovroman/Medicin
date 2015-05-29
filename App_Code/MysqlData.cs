using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySqlLib
{
    /// <summary>
    /// Набор компонент для простой работы с MySQL базой данных.
    /// </summary>
    public class MySqlData
    {
        public static string connect = "SERVER=91.202.254.179;" + "DATABASE=medic;" + "UID=root;" + "PASSWORD=romviktori;" + "charset = utf8;";
        string createdb = "CREATE DATABASE `mydb` CHARACTER SET utf8 COLLATE utf8_general_ci;";
        /// <summary>
        /// Методы реализующие выполнение запросов с возвращением одного параметра либо без параметров вовсе.
        /// </summary>
        public class MySqlExecute
        {

            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class MyResult
            {
                /// <summary>
                /// Возвращает результат запроса.
                /// </summary>
                public string ResultText;
                /// <summary>
                /// Возвращает True - если произошла ошибка.
                /// </summary>
                public string ErrorText;
                /// <summary>
                /// Возвращает текст ошибки.
                /// </summary>
                public bool HasError;
            }

            /// <summary>
            /// Для выполнения запросов к MySQL с возвращением 1 параметра.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает значение при успешном выполнении запроса, текст ошибки - при ошибке.</returns>
            public static MyResult SqlScalar(string sql, string connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        result.ResultText = commRC.ExecuteScalar().ToString();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }


            /// <summary>
            /// Для выполнения запросов к MySQL без возвращения параметров.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает True - ошибка или False - выполнено успешно.</returns>
            public static MyResult SqlNoneQuery(string sql, string connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        commRC.ExecuteNonQuery();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }

            /// <summary>
            /// Создаем таблицы в базе данных
            /// </summary>
            /// <returns>
            /// Возвращает 1 если все хорошо
            /// </returns>
            public static string CreateBD()
            {
                //Строка подключения
                
                //Тестовая команда
                string test = "SHOW VARIABLES LIKE \" % version % \";";

                //Команды создающие таблицы
                string zab_class = "create table zabclas (id int(11) not null auto_increment, name varchar(100), number varchar(3), primary key (id));";
                string zab_block = "create table zabbloc (id int(11) not null auto_increment, idclas int(11), name varchar(100), number varchar(3), primary key (id));";
                string zab_diagnoz = "create table zabdiagnoz (id int(11) not null auto_increment, idbloc int(11), name varchar(100), number varchar(3), about varchar(255), primary key (id));";
                string zab_simptom = " create table zabsimptom (id int(11) not null auto_increment, iddiagnoz int(11), idsim int(11), primary key (id));";
                string simptoms = " create table simptoms (id int(11) not null auto_increment,  name varchar(100), about varchar(255),  primary key (id));";
                
                string doctor_spec = " create table specdoctor (id int(11) not null auto_increment, name varchar(100), primary key (id));";
                string lekarstvo = " create table lekarstvo (id int(11) not null auto_increment, name varchar(100), doza varchar(100), type varchar(100), primary key (id));";
                string strahovay = " create table strah (id int(11) not null auto_increment, name varchar(100), address varchar(100), primary key (id));";
                string specdoctor0 = "insert into specdoctor (id , name) value (1, 'Терапевт');";
                string specdoctor1 = "insert into specdoctor (id , name) value (2, 'Хирург');";
                string specdoctor2 = "insert into specdoctor (id , name) value (3, 'Окулист');";
                string specdoctor3 = "insert into specdoctor (id , name) value (4, 'Педиатр');";
                try
                {
                    MySqlExecute.MyResult res = new MySqlExecute.MyResult();
                    res = MySqlExecute.SqlScalar(zab_class, connect);
                    res = MySqlExecute.SqlScalar(zab_block, connect);
                    res = MySqlExecute.SqlScalar(zab_diagnoz, connect);
                    res = MySqlExecute.SqlScalar(zab_simptom, connect);
                    res = MySqlExecute.SqlScalar(doctor_spec, connect);
                    res = MySqlExecute.SqlScalar(lekarstvo, connect);
                    res = MySqlExecute.SqlScalar(strahovay, connect);
                    return res.ErrorText;
                    
                }
                catch
                {
                    return "";
                }
                finally
                {

                }
            }

            public static string CreateTable()
            {
                //Строка подключения
                //string zab_class0 = "insert into  zabclas (id , name, number) value (1, 'Некоторые инфекционные и паразитарные болезни (A00-B99)','I');";
                string zab_class1 = "insert into  zabclas (id , name, number) value (2, 'Новообразования (C00-D48)','II');";
                //string zab_class2 = "insert into  zabclas (id , name, number) value (1, 'Болезни нервной системы (G00-G99)','VI');";

                string zab_block0 = "insert into  zabbloc (id , name, number) value (1, 'Кишечные инфекции (A00-A09)','1');";
                string zab_block1 = "insert into  zabbloc (id , name, number) value (2, 'Вирусные инфекции центральной нервной системы (A80-A89)','9');";
                string zab_block2 = "insert into  zabbloc (id , name, number) value (3, 'Другие вирусные болезни (B25-B34)','14');";
                string zab_block3 = "insert into  zabbloc (id , name, number) value (4, 'Микозы (B35-B49)','15');";
                string zab_block4 = "insert into  zabbloc (id , name, number) value (5, 'Злокачественные новообразования (C00-C97)','1');";
                string zab_block5 = "insert into  zabbloc (id , name, number) value (6, 'Новообразования in situ (D00-D09)','2');";
                string zab_block6 = "insert into  zabbloc (id , name, number) value (7, 'Доброкачественные новообразования (D10-D36)','3');";
     
               
                //Команды создающие таблицы
               try
                {
                    MySqlExecute.MyResult res = new MySqlExecute.MyResult();
                    //res = MySqlExecute.SqlScalar(zab_class0, connect);
                    res = MySqlExecute.SqlScalar(zab_block0, connect);
                    res = MySqlExecute.SqlScalar(zab_block1, connect);
                    res = MySqlExecute.SqlScalar(zab_block2, connect);
                    res = MySqlExecute.SqlScalar(zab_block3, connect);
                    res = MySqlExecute.SqlScalar(zab_block4, connect);
                    res = MySqlExecute.SqlScalar(zab_block5, connect);
                    res = MySqlExecute.SqlScalar(zab_block6, connect);
                    res = MySqlExecute.SqlScalar(zab_class1, connect);
                                 return res.ErrorText;

                }
                catch
                {
                    return "";
                }
                finally
                {

                }
            }

            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class zabclas
            {
                public int id;
                public string name;
                public string number;
            }
            public class zabbloc
            {
                public int id;
                public int idclas;
                public string name;
                public string number;

            }
            public class zabdiagnoz
            {
                public int id;
                public int idbloc;
                public string name;
                public string number;
                public string about;

            }
          
            public class simptoms
            {
                public int id;
                public string name;
                public string about;

            }
            public class specdoctor
            {
                public int id;
                public string name;
            }
            public class lekarstvo
            {
                public int id;
                public string name;
                public string doza;
                public string type;

            }
            public class strahovay
            {
                public int id;
                public string name;
                public string address;
            }
            /// <summary>
            /// Вывод классов диагнозов -> Блок
            /// </summary>
            /// <returns></returns>
            public List<zabclas> SelectZabClass()
            {

                //Команды создающие таблицы
                string zab_class = "select  id, name, number from zabclas";

                MySqlCommand command = new MySqlCommand(); 
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<zabclas> clas = new List<zabclas>();
                try
                {
                    
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        zabclas z = new zabclas();
                        z.id = Convert.ToInt32(reader["id"]);
                        z.name = Convert.ToString(reader["name"]);
                        z.number = Convert.ToString(reader["number"]);
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Класс заболеваний");
                }
                finally
                {

                }
            }
            /// <summary>
            /// Вывод блоков диагнозов
            /// </summary>
            /// <returns></returns>
            public List<zabbloc> SelectZabBlock()
            {

                //Команды создающие таблицы
                string zab_class = "select  id, idclas, name, number from zabbloc";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<zabbloc> clas = new List<zabbloc>();
                try
                {
                   
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        zabbloc z = new zabbloc();
                        z.id = Convert.ToInt32(reader["id"]);
                        z.idclas = Convert.ToInt32(reader["idclas"]);
                        z.name = Convert.ToString(reader["name"]);
                        z.number = Convert.ToString(reader["number"]);
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Класс заболеваний");
                }
                finally
                {

                }
            }
            /// <summary>
            /// Вывод диагнозов
            /// </summary>
            /// <returns></returns>
            public List<zabdiagnoz> SelectZabDiagnoz()
            {

                //Команды создающие таблицы
                string zab_class = "select  id, idbloc, about, name, number from zabdiagnoz";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<zabdiagnoz> clas = new List<zabdiagnoz>();
                try
                {
                    
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        zabdiagnoz z = new zabdiagnoz();
                        z.id = Convert.ToInt32(reader["id"]);
                        z.idbloc = Convert.ToInt32(reader["idbloc"]);
                        z.about = Convert.ToString(reader["about"]);
                        z.name = Convert.ToString(reader["name"]);
                        z.number = Convert.ToString(reader["number"]);
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Диагнозы");
                }
                finally
                {

                }
            }
            /// <summary>
            /// Вывод всех симптомов
            /// </summary>
            /// <returns></returns>
            public List<simptoms> SelectSimptoms()
            {

                //Команды создающие таблицы
                string zab_class = "select  id, name, about from simptoms";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<simptoms> clas = new List<simptoms>();
                try
                {
                    
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        simptoms z = new simptoms();
                        z.id = Convert.ToInt32(reader["id"]);
                        z.about = Convert.ToString(reader["about"]);
                        z.name = Convert.ToString(reader["name"]);
                        
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch(Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Симптомы" + e.Message);
                }
                finally
                {

                }
            }
            /// <summary>
            /// Вывод всех специальностей доктора
            /// </summary>
            /// <returns></returns>
            public List<specdoctor> SelectSpecDoctor()
            {

                //Команды создающие таблицы
                string zab_class = "select  id, name from specdoctor";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<specdoctor> clas = new List<specdoctor>();
                try
                {
                  
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specdoctor z = new specdoctor();
                        z.id = Convert.ToInt32(reader["id"]);
                        
                        z.name = Convert.ToString(reader["name"]);
                        
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Диагнозы");
                }
                finally
                {

                }
            }

            public int DeleteDoctor(int id)
            {

                //Команды создающие таблицы
                string zab_class = "delete from specdoctor where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

              
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Удаление врача");
                }
                finally
                {

                }
            }
            public int DeleteLek(int id)
            {

                //Команды создающие таблицы
                string zab_class = "delete from lekarstvo where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Удаление лекарства");
                }
                finally
                {

                }
            }
            public int DeleteDiag(int id)
            {

                //Команды создающие таблицы
                string zab_diag = "delete from zabdiagnoz where id = @id;";

                string zab_simp = "delete from zabsimptom where iddiagnoz = @id;";
                
                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_diag;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;
                MySqlCommand command2 = new MySqlCommand();
                MySqlConnection connection2 = new MySqlConnection(connect);
                command2.CommandText = zab_simp;
                command2.Connection = connection;
                command2.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command2.Parameters["@id"].Value = id;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection2.Open();
                    command2.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Удаление лекарства");
                }
                finally
                {

                }
            }
            public int DeleteStrah(int id)
            {

                //Команды создающие таблицы
                string zab_class = "delete from strah where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Удаление лекарства");
                }
                finally
                {

                }
            }
            public int DeleteSimptom(int id)
            {

                //Команды создающие таблицы
                string zab_class = "delete from simptoms where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Удаление симптома");
                }
                finally
                {

                }
            }

            //
            //Сектор Insert
            //

            public int InsertSpecDoctor(int id, string name)
            {

                //Команды создающие таблицы
                string zab_class = "insert into specdoctor (id, name) values (@id, @name);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 20));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch (Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление специализации врача"+ e.Message);
                }
                finally
                {

                }
            }
            public int InsertSimptoms(int id, string name, string about)
            {

                //Команды создающие таблицы
                string zab_class = "insert into simptoms (id, name, about) values (@id, @name, @about);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

                command.Parameters.Add(new MySqlParameter("@about", MySqlDbType.String, 250));
                command.Parameters["@about"].Value = about;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 80));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch(Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление симптомов" + e.Message);
                }
                finally
                {

                }
            }
            public int InsertStrax(int id, string name, string address)
            {

                //Команды создающие таблицы
                string zab_class = "insert into strah (id, name, address) values (@id, @name, @address);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

                command.Parameters.Add(new MySqlParameter("@address", MySqlDbType.String, 250));
                command.Parameters["@address"].Value = address;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 80));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление страховой компании");
                }
                finally
                {

                }
            }
            public int InsertLek(int id, string name, string doza, string type)
            {

                //Команды создающие таблицы
                string zab_class = "insert into lekarstvo (id, name, doza, type) values (@id, @name, @doza, @type);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;
                command.Parameters.Add(new MySqlParameter("@type", MySqlDbType.String, 100));
                command.Parameters["@type"].Value = type;
                command.Parameters.Add(new MySqlParameter("@doza", MySqlDbType.String, 100));
                command.Parameters["@doza"].Value = doza;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 100));
                command.Parameters["@name"].Value = name;
                try
                {
                    int e = 0;
                    connection.Open();
                  
                       
                        e = command.ExecuteNonQuery();
                      
                        
                  
                   
                    return e;
                }
                catch (Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление лекарства" + e.Message);
                }
                finally
                {

                }
            }
            public int InsertDiagnoz(int id, string name, string number, string about, int idbl)
            {

                //Команды создающие таблицы
                string zab_class = "insert into zabdiagnoz (id, idbloc, name, number, about) values (@id, @idbloc, @name, @number, @about);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;
                command.Parameters.Add(new MySqlParameter("@idbloc", MySqlDbType.Int32, 3));
                command.Parameters["@idbloc"].Value = idbl;
                command.Parameters.Add(new MySqlParameter("@number", MySqlDbType.String, 3));
                command.Parameters["@number"].Value = number;
                command.Parameters.Add(new MySqlParameter("@about", MySqlDbType.String, 250));
                command.Parameters["@about"].Value = about;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 80));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch(Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление нового диагноза" + e.Message);
                }
                finally
                {

                }
            }
            public int InsertDSimptom( int idd, int ids)
            {

                //Команды создающие таблицы
                string zab_class = "insert into zabsimptom(iddiagnoz, idsim) values ( @iddiagnoz, @idsim) ;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@iddiagnoz", MySqlDbType.Int32, 3));
                command.Parameters["@iddiagnoz"].Value = idd;
                command.Parameters.Add(new MySqlParameter("@idsim", MySqlDbType.Int32, 3));
                command.Parameters["@idsim"].Value = ids;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return 1;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление симптомов к диагнозу");
                }
                finally
                {

                }
            }
           
            //
            //Сектор Update
            //

            public int UpdateSpecDoctor(int id, string name)
            {

                //Команды создающие таблицы
                string zab_class = "update specdoctor set name = @name where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 20));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch (Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Обновление специализации врача" + e.Message);
                }
                finally
                {

                }
            }
            public int UpdateSimptoms(int id, string name, string about)
            {

                //Команды создающие таблицы
                string zab_class = "update simptoms set name = @name, about = @about where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

                command.Parameters.Add(new MySqlParameter("@about", MySqlDbType.String, 250));
                command.Parameters["@about"].Value = about;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 80));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch (Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Обновление симптомов" + e.Message);
                }
                finally
                {

                }
            }
            public int UpdateStrax(int id, string name, string address)
            {

                //Команды создающие таблицы
                string zab_class = "Update strah set name = @name, address = @address where id = @id;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;

                command.Parameters.Add(new MySqlParameter("@address", MySqlDbType.String, 250));
                command.Parameters["@address"].Value = address;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 80));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Обновление страховой компании");
                }
                finally
                {

                }
            }
            public int UpdateLek(int id, string name, string doza, string type)
            {

                //Команды создающие таблицы
                string zab_class = "insert into lekarstvo (id, name, doza, type) values (@id, @name, @doza, @type);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;
                command.Parameters.Add(new MySqlParameter("@type", MySqlDbType.String, 100));
                command.Parameters["@type"].Value = type;
                command.Parameters.Add(new MySqlParameter("@doza", MySqlDbType.String, 100));
                command.Parameters["@doza"].Value = doza;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 100));
                command.Parameters["@name"].Value = name;
                try
                {
                    int e = 0;
                    connection.Open();


                    e = command.ExecuteNonQuery();




                    return e;
                }
                catch (Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление лекарства" + e.Message);
                }
                finally
                {

                }
            }
            public int UpdateDiagnoz(int id, string name, string number, string about, int idbl)
            {

                //Команды создающие таблицы
                string zab_class = "insert into zabdiagnoz (id, idbloc, name, number, about) values (@id, @idbloc, @name, @number, @about);";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32, 3));
                command.Parameters["@id"].Value = id;
                command.Parameters.Add(new MySqlParameter("@idbloc", MySqlDbType.Int32, 3));
                command.Parameters["@idbloc"].Value = idbl;
                command.Parameters.Add(new MySqlParameter("@number", MySqlDbType.String, 3));
                command.Parameters["@number"].Value = number;
                command.Parameters.Add(new MySqlParameter("@about", MySqlDbType.String, 250));
                command.Parameters["@about"].Value = about;
                command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.String, 80));
                command.Parameters["@name"].Value = name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return id;
                }
                catch (Exception e)
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление нового диагноза" + e.Message);
                }
                finally
                {

                }
            }
            public int UpdateDSimptom(int idd, int ids)
            {

                //Команды создающие таблицы
                string zab_class = "insert into zabsimptom(iddiagnoz, idsim) values ( @iddiagnoz, @idsim) ;";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                command.Parameters.Add(new MySqlParameter("@iddiagnoz", MySqlDbType.Int32, 3));
                command.Parameters["@iddiagnoz"].Value = idd;
                command.Parameters.Add(new MySqlParameter("@idsim", MySqlDbType.Int32, 3));
                command.Parameters["@idsim"].Value = ids;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return 1;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Добавление симптомов к диагнозу");
                }
                finally
                {

                }
            }

            //
            //Сектор Select
            //

            /// <summary>
            /// Вывод всех лекарств
            /// </summary>
            /// <returns></returns>
            public List<lekarstvo> SelectLekarstvo()
            {

                //Команды создающие таблицы
                string zab_class = "select  * from lekarstvo";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<lekarstvo> clas = new List<lekarstvo>();
                try
                {
                    
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lekarstvo z = new lekarstvo();
                        z.id = Convert.ToInt32(reader["id"]);
                        z.type = Convert.ToString(reader["type"]);
                        z.doza = Convert.ToString(reader["doza"]);
                        z.name = Convert.ToString(reader["name"]);
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Вывод лекарств");
                }
                finally
                {

                }
            }
            /// <summary>
            /// Вывод всех страховых
            /// </summary>
            /// <returns></returns>
            public List<strahovay> SelectStrah()
            {

                //Команды создающие таблицы
                string zab_class = "select  id, name, address from strah";

                MySqlCommand command = new MySqlCommand();
                MySqlConnection connection = new MySqlConnection(connect);
                command.CommandText = zab_class;
                command.Connection = connection;
                MySqlDataReader reader;
                List<strahovay> clas = new List<strahovay>();
                try
                {
                    
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        strahovay z = new strahovay();
                        z.id = Convert.ToInt32(reader["id"]);
                        z.address = Convert.ToString(reader["address"]);
                        z.name = Convert.ToString(reader["name"]);
                        clas.Add(z);
                    }
                    reader.Close();
                    return clas;
                }
                catch
                {

                    throw new ApplicationException("Ошибка данныx mysql. Диагнозы");
                }
                finally
                {

                }
            }

        }

        /// <summary>
        /// Методы реализующие выполнение запросов с возвращением набора данных.
        /// </summary>
        public class MySqlExecuteData
        {
            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class MyResultData
            {
                /// <summary>
                /// Возвращает результат запроса.
                /// </summary>
                public DataTable ResultData;
                /// <summary>
                /// Возвращает True - если произошла ошибка.
                /// </summary>
                public string ErrorText;
                /// <summary>
                /// Возвращает текст ошибки.
                /// </summary>
                public bool HasError;
            }


            /// <summary>
            /// Выполняет запрос выборки набора строк.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает набор строк в DataSet.</returns>
            public static MyResultData SqlReturnDataset(string sql, string connection)
            {
                MyResultData result = new MyResultData();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();

                    try
                    {
                        MySql.Data.MySqlClient.MySqlDataAdapter AdapterP = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        AdapterP.SelectCommand = commRC;
                        DataSet ds1 = new DataSet();
                        AdapterP.Fill(ds1);
                        result.ResultData = ds1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        result.HasError = true;
                        result.ErrorText = ex.Message;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }

                return result;

            }

        }


	    
    }
}