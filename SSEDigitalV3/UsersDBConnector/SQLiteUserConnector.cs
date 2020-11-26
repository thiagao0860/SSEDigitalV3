using System;
using System.Data.SQLite;
using SSEDigitalV3.DataCore;

namespace SSEDigitalV3.UserDBConnector
{
    class SQLiteUserConnector
    {
        //user table indexes 
        //
        private static int id_user_table_index = 0;
        private static int name_user_table_index = 1;
        private static int celula_user_table_index = 2;
        private static int ramal_user_table_index = 3;
        private static int matricula_user_table_index = 4;
        private static int email_user_table_index = 5;
        private static int setor_user_table_index = 6;

        //mac table indexes 
        //
        private static int id_MAC_table_index = 0;
        private static int mac_MAC_table_index = 1;
        private static int user_id_MAC_table_index = 2;

        public static readonly int NULL_MAC_CODE = -1;

        private SQLiteConnection db_connection; 
        public SQLiteUserConnector(){
            CreateConnection();
        }

        private void CreateConnection()
        {
            // Create a new database connection:
            db_connection = new SQLiteConnection("Data Source=CoreDatabase.db; Version = 3;Pooling = True");
            InitConnection();
            CreateUserDataTable();
            CreateMACDataTable();
            CreateConstantTable();
            FinishConnection();
        }

        private void InitConnection()
        {
            try
            {
                db_connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("***    " + ex.Message + "    ***");
                Console.WriteLine("***    " + ex.StackTrace + "    ***");
            }
        }

        private void FinishConnection()
        {
            try
            {
                db_connection.Close();
            }catch (Exception ex)
            {
                Console.WriteLine("***    " + ex.Message + "    ***");
                Console.WriteLine("***    " + ex.StackTrace + "    ***");
            }
        }

        void CreateUserDataTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS USERS(id integer primary key autoincrement," +
                                    "name VARCHAR(255)," +
                                    "celula VARCHAR(255)," +
                                    "ramal VARCHAR(255)," +
                                    "matricula VARCHAR(255)," +
                                    "email VARCHAR(255)," +
                                    "setor TEXT)";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        void CreateMACDataTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS MAC_LOG(id integer primary key autoincrement," +
                                    "mac VARCHAR(255)," +
                                    "user_id integer references USERS(id)," +
                                    "FOREIGN KEY(user_id) REFERENCES USERS(id))";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        void CreateConstantTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS CONSTANTS(key VARCHAR(255) primary key ," +
                                    "value INTEGER)";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        public int GetIntValue(string key)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM CONSTANTS WHERE key = $mykey";
                SQLiteParameter mat = sqlite_cmd.CreateParameter();
                mat.ParameterName = "$mykey";
                mat.Value = key;
                sqlite_cmd.Parameters.Add(mat);


                sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read())
                {
                    return sqlite_datareader.GetInt32(1);
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                FinishConnection();
            }
        }

        public string GetStringValue(string key)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM CONSTANTS WHERE key = $mykey";
                SQLiteParameter mat = sqlite_cmd.CreateParameter();
                mat.ParameterName = "$mykey";
                mat.Value = key;
                sqlite_cmd.Parameters.Add(mat);


                sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read())
                {
                    return sqlite_datareader.GetString(1);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                FinishConnection();
            }
        }

        public void InsertUser(User newUser)
        {
            if (GetUserByMatricula(newUser.Matricula) != null)
            {
                throw new Exception("Usuario já cadastrado");
            }
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO USERS(name, celula, ramal, matricula, email, setor) " +
                    "VALUES($name, $celula, $ramal, $matricula, $email, $setor);";

                SQLiteParameter nome = sqlite_cmd.CreateParameter();
                nome.ParameterName = "$name";
                nome.Value = newUser.Nome;
                sqlite_cmd.Parameters.Add(nome);

                SQLiteParameter celula = sqlite_cmd.CreateParameter();
                celula.ParameterName = "$celula";
                celula.Value = newUser.CelulaString;
                sqlite_cmd.Parameters.Add(celula);

                SQLiteParameter ramal = sqlite_cmd.CreateParameter();
                ramal.ParameterName = "$ramal";
                ramal.Value = newUser.Ramal;
                sqlite_cmd.Parameters.Add(ramal);

                SQLiteParameter matricula = sqlite_cmd.CreateParameter();
                matricula.ParameterName = "$matricula";
                matricula.Value = newUser.Matricula;
                sqlite_cmd.Parameters.Add(matricula);

                SQLiteParameter email = sqlite_cmd.CreateParameter();
                email.ParameterName = "$email";
                email.Value = newUser.Email;
                sqlite_cmd.Parameters.Add(email);

                SQLiteParameter setor = sqlite_cmd.CreateParameter();
                setor.ParameterName = "$setor";
                setor.Value = newUser.Setor;
                sqlite_cmd.Parameters.Add(setor);

                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        public User GetUserByMatricula(string matricula)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM USERS WHERE matricula = $mat";
                SQLiteParameter mat = sqlite_cmd.CreateParameter();
                mat.ParameterName = "$mat";
                mat.Value = matricula;
                sqlite_cmd.Parameters.Add(mat);


                sqlite_datareader = sqlite_cmd.ExecuteReader();
                if (sqlite_datareader.Read())
                {
                    User return_set = new User();
                    return_set.Id = sqlite_datareader.GetInt32(id_user_table_index);
                    return_set.Nome = sqlite_datareader.GetString(name_user_table_index);
                    return_set.Matricula = sqlite_datareader.GetString(matricula_user_table_index);
                    return_set.CelulaString = sqlite_datareader.GetString(celula_user_table_index);
                    return_set.Ramal = sqlite_datareader.GetString(ramal_user_table_index);
                    return_set.Email = sqlite_datareader.GetString(email_user_table_index);
                    return_set.Setor = sqlite_datareader.GetString(setor_user_table_index);
                    return return_set;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                FinishConnection();
            }
        }

        public User GetUserByID(string id)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM USERS WHERE id = $id";
                SQLiteParameter p_id = sqlite_cmd.CreateParameter();
                p_id.ParameterName = "$id";
                p_id.Value = id;
                sqlite_cmd.Parameters.Add(p_id);


                sqlite_datareader = sqlite_cmd.ExecuteReader();
            
                if (sqlite_datareader.Read())
                {
                    User return_set = new User();
                    return_set.Id = sqlite_datareader.GetInt32(id_user_table_index);
                    return_set.Nome = sqlite_datareader.GetString(name_user_table_index);
                    return_set.Matricula = sqlite_datareader.GetString(matricula_user_table_index);
                    return_set.CelulaString = sqlite_datareader.GetString(celula_user_table_index);
                    return_set.Ramal = sqlite_datareader.GetString(ramal_user_table_index);
                    return_set.Email = sqlite_datareader.GetString(email_user_table_index);
                    return_set.Setor = sqlite_datareader.GetString(setor_user_table_index);
                    return return_set;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                FinishConnection();
            }
        }

        public void InsertMAC(MACTriger usr_data)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO MAC_LOG(mac, user_id) " +
                    "VALUES($mac, $user_id);";

                SQLiteParameter mac = sqlite_cmd.CreateParameter();
                mac.ParameterName = "$mac";
                mac.Value = usr_data.UniqueCode;
                sqlite_cmd.Parameters.Add(mac);

                SQLiteParameter user_id = sqlite_cmd.CreateParameter();
                user_id.ParameterName = "$user_id";
                user_id.Value = usr_data.stance_user.Id;
                sqlite_cmd.Parameters.Add(user_id);

                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        public void InsertNullMAC(String MAC)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO MAC_LOG(mac, user_id) " +
                    "VALUES($mac, $user_id);";

                SQLiteParameter mac = sqlite_cmd.CreateParameter();
                mac.ParameterName = "$mac";
                mac.Value = MAC;
                sqlite_cmd.Parameters.Add(mac);

                SQLiteParameter user_id = sqlite_cmd.CreateParameter();
                user_id.ParameterName = "$user_id";
                user_id.Value = NULL_MAC_CODE;
                sqlite_cmd.Parameters.Add(user_id);

                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        public Int32 GetUserIDbyMAC(string mac)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM MAC_LOG WHERE mac = $mac";
                SQLiteParameter p_mac = sqlite_cmd.CreateParameter();
                p_mac.ParameterName = "$mac";
                p_mac.Value = mac;
                sqlite_cmd.Parameters.Add(p_mac);


                sqlite_datareader = sqlite_cmd.ExecuteReader();

                if (sqlite_datareader.Read())
                {
                    return sqlite_datareader.GetInt32(user_id_MAC_table_index);
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                FinishConnection();
            }
        }

        public void UpdateUser(User newUser)
        {
            if (GetUserByMatricula(newUser.Matricula) == null)
            {
                throw new Exception("Usuario nao Existente");
            }
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE USERS " +
                    "SET name = $name ," +
                    "celula =$celula ," +
                    "ramal =$ramal ," +
                    "email = $email ," +
                    "setor = $setor " +
                    "WHERE matricula = $matricula;";

                SQLiteParameter nome = sqlite_cmd.CreateParameter();
                nome.ParameterName = "$name";
                nome.Value = newUser.Nome;
                sqlite_cmd.Parameters.Add(nome);

                SQLiteParameter celula = sqlite_cmd.CreateParameter();
                celula.ParameterName = "$celula";
                celula.Value = newUser.CelulaString;
                sqlite_cmd.Parameters.Add(celula);

                SQLiteParameter ramal = sqlite_cmd.CreateParameter();
                ramal.ParameterName = "$ramal";
                ramal.Value = newUser.Ramal;
                sqlite_cmd.Parameters.Add(ramal);

                SQLiteParameter matricula = sqlite_cmd.CreateParameter();
                matricula.ParameterName = "$matricula";
                matricula.Value = newUser.Matricula;
                sqlite_cmd.Parameters.Add(matricula);

                SQLiteParameter email = sqlite_cmd.CreateParameter();
                email.ParameterName = "$email";
                email.Value = newUser.Email;
                sqlite_cmd.Parameters.Add(email);

                SQLiteParameter setor = sqlite_cmd.CreateParameter();
                setor.ParameterName = "$setor";
                setor.Value = newUser.Setor;
                sqlite_cmd.Parameters.Add(setor);

                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        public void deleteMAC(String usr_data)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM MAC_LOG " +
                    "WHERE mac = $mac;";

                SQLiteParameter mac = sqlite_cmd.CreateParameter();
                mac.ParameterName = "$mac";
                mac.Value = usr_data;
                sqlite_cmd.Parameters.Add(mac);

                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }
    }
}
