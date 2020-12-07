using SSEDigitalV3.DataCore;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.MainDBConnector
{
    class SSEMainDBConnector
    {
        //Main Table Index
        #region Main table index map
        public static readonly int id_main_table_index = 0;
        public static readonly int fornecedor_main_table_index = 1;
        public static readonly int data_main_table_index = 2;
        public static readonly int tipo_main_table_index = 3;
        public static readonly int codigo_main_table_index = 4;
        public static readonly int referencia_main_table_index = 5;
        public static readonly int descricao_main_table_index = 6;
        public static readonly int solicitante_main_table_index = 7;
        public static readonly int ramal_main_table_index = 8;
        public static readonly int celula_main_table_index = 9;
        public static readonly int maquina_main_table_index = 10;
        public static readonly int ordem_main_table_index = 11;
        public static readonly int requisicao_main_table_index = 12;
        public static readonly int nota_main_table_index = 13;
        public static readonly int prazo_main_table_index = 14;
        public static readonly int data_rec_main_table_index = 15;
        public static readonly int valor_item_main_table_index = 16;
        public static readonly int valor_orc_main_table_index = 17;
        public static readonly int prioridade_main_table_index = 18;
        public static readonly int peso_main_table_index = 19;
        public static readonly int quantidade_main_table_index = 20;
        public static readonly int iss_main_table_index = 21;
        public static readonly int codigo_do_servico_main_table_index = 22;
        public static readonly int codigo_do_produto_main_table_index = 23;
        public static readonly int orc_num_main_table_index = 24;
        public static readonly int po_num_main_table_index = 25;
        public static readonly int valor_orc_retorno_num_main_table_index = 26;
        public static readonly int excluded_main_table_index = 27;
        public static readonly int is_sincronized_main_table_index = 28;
        public static readonly int foto_out_main_table_index = 29;
        public static readonly int foto_in_main_table_index = 30;
        #endregion
        //
        
        //Fornecedores Table Index
        #region Providers table index map
        public static readonly int id_providers_table_index = 0;
        public static readonly int provider_providers__table_index = 1;
        #endregion
        //

        //Types Table Index
        #region Types table index map
        public static readonly int id_types_table_index = 0;
        public static readonly int type_types_table_index = 1;
        #endregion
        //

        //Cell Table Index
        #region Cell table index map
        public static readonly int id_cell_table_index = 0;
        public static readonly int cell_name_cell_table_index = 1;
        public static readonly int setor_id_cell_table_index = 2;
        #endregion
        //

        //Sections Table Index
        #region Sections table index map
        public static readonly int s_id_sections_table_index = 0;
        public static readonly int sector_name_sections_table_index = 1;
        #endregion
        //

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
            }
            catch (Exception ex)
            {
                Console.WriteLine("***    " + ex.Message + "    ***");
                Console.WriteLine("***    " + ex.StackTrace + "    ***");
            }
        }

        private SQLiteConnection db_connection;
        public SSEMainDBConnector()
        {
            // Create a new database connection:
            db_connection = new SQLiteConnection("Data Source=SystemLog.db; Version = 3;Pooling = True");
            CreateTypeTable();
            CreateProvidersTable();
            CreateMainTable();
            CreateSectorTable();
            CreateCellTable();
        }

        //
        #region Setting Data Location 
        void CreateMainTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS MAIN(id integer primary key autoincrement," +
                                    "provider_id INTEGER NOT NULL references PROVIDERS(id)," +
                                    "sse_data DATE NOT NULL," +
                                    "type_id INTEGER NOT NULL references TYPES(id)," +
                                    "codigo VARCHAR(255)," +
                                    "referencia TEXT," +
                                    "descricao TEXT," +
                                    "solicitante VARCHAR(255) NOT NULL," +
                                    "ramal VARCHAR(255) NOT NULL," +
                                    "celula VARCHAR(255) NOT NULL," +
                                    "maquina VARCHAR(255) NOT NULL," +
                                    "ordem VARCHAR(255) NOT NULL," +
                                    "requisicao VARCHAR(255) NOT NULL," +
                                    "nf VARCHAR(255) NOT NULL," +
                                    "prazo_entrega DATE NOT NULL," +
                                    "data_recebimento DATE," +
                                    "valor_item FLOAT NOT NULL," +
                                    "valor_orc FLOAT NOT NULL," +
                                    "prioridade INTEGER NOT NULL," +
                                    "peso FLOAT NOT NULL," +
                                    "quantidade INTEGER NOT NULL," +
                                    "iss VARCHAR(255)," +
                                    "codigo_servico VARCHAR(255)," +
                                    "codigo_produto VARCHAR(255)," +
                                    "numero_orc VARCHAR(255)," +
                                    "numero_po VARCHAR(255)," +
                                    "valor_orc_retorno VARCHAR(255)," +
                                    "Excluded BOOLEAN," +
                                    "IsSincronized BOOLEAN," +
                                    "foto_out TEXT," +
                                    "foto_in TEXT," +
                                    "FOREIGN KEY(provider_id) REFERENCES PROVIDERS(id)," +
                                    "FOREIGN KEY(type_id) REFERENCES TYPES(id))";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        void CreateProvidersTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS PROVIDERS(id integer primary key autoincrement," +
                                    "provider VARCHAR(255) NOT NULL)";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }

        void CreateTypeTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS TYPES(id integer primary key autoincrement," +
                                    "sse_type VARCHAR(255) NOT NULL)";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }
        void CreateSectorTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS SECTOR(id integer primary key autoincrement," +
                                    "sector_name VARCHAR(255) NOT NULL)";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }
        void CreateCellTable()
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "CREATE TABLE IF NOT EXISTS CELL(id integer primary key autoincrement," +
                                    "Cell_name VARCHAR(255) NOT NULL," +
                                    "setor_id INTEGER NOT NULL references SECTOR(id)," +
                                    "FOREIGN KEY(setor_id) REFERENCES SECTOR(id))";
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            finally
            {
                FinishConnection();
            }
        }
        #endregion
        //
        #region Main Data Handle
        public int insertSSE(SSEDBWrapper toInsert)
        {
            InitConnection();
            int returned = 0;
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd1;
                sqlite_cmd1 = db_connection.CreateCommand();
                sqlite_cmd1.CommandText = "SELECT MAX(id) FROM MAIN;";
                sqlite_datareader = sqlite_cmd1.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    returned = sqlite_datareader.GetInt32(0);
                }
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO MAIN(provider_id," +
                                                            " sse_data," +
                                                            " type_id," +
                                                            " codigo," +
                                                            " referencia," +
                                                            " descricao," +
                                                            " solicitante," +
                                                            " ramal," +
                                                            " celula," +
                                                            " maquina," +
                                                            " ordem," +
                                                            " requisicao," +
                                                            " nf," +
                                                            " prazo_entrega," +
                                                            " data_recebimento," +
                                                            " valor_item," +
                                                            " valor_orc," +
                                                            " prioridade," +
                                                            " peso," +
                                                            " quantidade," +
                                                            " iss," +
                                                            " codigo_servico," +
                                                            " codigo_produto," +
                                                            " numero_orc," +
                                                            " numero_po," +
                                                            " valor_orc_retorno) " +
                    "VALUES($provider_id," +
                          " $sse_data," +
                          " $type_id," +
                          " $codigo," +
                          " $referencia," +
                          " $descricao," +
                          " $solicitante," +
                          " $ramal," +
                          " $celula," +
                          " $maquina," +
                          " $ordem," +
                          " $requisicao," +
                          " $nf," +
                          " $prazo_entrega,"+
                          " $data_recebimento," +
                          " $valor_item," +
                          " $valor_orc," +
                          " $prioridade," +
                          " $peso," +
                          " $quantidade," +
                          " $iss," +
                          " $codigo_servico," +
                          " $codigo_produto," +
                          " $numero_orc," +
                          " $numero_po," +
                          " $valor_orc_retorno);";

                putParameter(sqlite_cmd, "$provider_id", toInsert.ISSEBean.Fornecedor);
                putParameter(sqlite_cmd, "$sse_data", toInsert.ISSEBean.Data);
                putParameter(sqlite_cmd, "$type_id", toInsert.ISSEBean.Tipo);
                putParameter(sqlite_cmd, "$codigo", toInsert.ISSEBean.Codigo);
                putParameter(sqlite_cmd, "$referencia", toInsert.ISSEBean.Referencia);
                putParameter(sqlite_cmd, "$descricao", toInsert.ISSEBean.Descricao);
                putParameter(sqlite_cmd, "$solicitante", toInsert.ISSEBean.Requisitante.Matricula);
                putParameter(sqlite_cmd, "$ramal", toInsert.ISSEBean.Requisitante.Ramal);
                putParameter(sqlite_cmd, "$celula", toInsert.ISSEBean.Requisitante.CelulaString);
                putParameter(sqlite_cmd, "$maquina", toInsert.ISSEBean.Equipamento);
                putParameter(sqlite_cmd, "$ordem", toInsert.ISSEBean.Ordem);
                putParameter(sqlite_cmd, "$requisicao", toInsert.ISSEBean.Requisicao);
                putParameter(sqlite_cmd, "$nf", toInsert.ISSEBean.Nota);
                putParameter(sqlite_cmd, "$prazo_entrega", toInsert.ISSEBean.Prazo);
                putParameter(sqlite_cmd, "$data_recebimento", toInsert.data_recebimento);
                putParameter(sqlite_cmd, "$valor_item", toInsert.ISSEBean.Valor);
                putParameter(sqlite_cmd, "$valor_orc", toInsert.ISSEBean.ValorOrc);
                putParameter(sqlite_cmd, "$prioridade", toInsert.ISSEBean.Prioridade);
                putParameter(sqlite_cmd, "$peso", toInsert.ISSEBean.Peso);
                putParameter(sqlite_cmd, "$quantidade", toInsert.ISSEBean.Quantidade);
                putParameter(sqlite_cmd, "$iss", toInsert.iss);
                putParameter(sqlite_cmd, "$codigo_servico", toInsert.codigo_do_servico);
                putParameter(sqlite_cmd, "$codigo_produto", toInsert.codigo_do_produto);
                putParameter(sqlite_cmd, "$numero_orc", toInsert.numero_do_orcamento);
                putParameter(sqlite_cmd, "$numero_po", toInsert.numero_da_PO);
                putParameter(sqlite_cmd, "$valor_orc_retorno", toInsert.valor_do_orcamento_retorno);

                sqlite_cmd.ExecuteNonQuery();
                return returned+1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return returned+1;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool insertSSE(SSEDBWrapper toInsert, long id)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO MAIN(id" +
                                                            "provider_id," +
                                                            " sse_data," +
                                                            " type_id," +
                                                            " codigo," +
                                                            " referencia," +
                                                            " descricao," +
                                                            " solicitante," +
                                                            " ramal," +
                                                            " celula," +
                                                            " maquina," +
                                                            " ordem," +
                                                            " requisicao," +
                                                            " nf," +
                                                            " prazo_entrega," +
                                                            " data_recebimento," +
                                                            " valor_item," +
                                                            " valor_orc," +
                                                            " prioridade," +
                                                            " peso," +
                                                            " quantidade," +
                                                            " iss," +
                                                            " codigo_servico," +
                                                            " codigo_produto," +
                                                            " numero_orc," +
                                                            " numero_po," +
                                                            " valor_orc_retorno) " +
                    "VALUES($id" +
                          "$provider_id," +
                          " $sse_data," +
                          " $type_id," +
                          " $codigo," +
                          " $referencia," +
                          " $descricao," +
                          " $solicitante," +
                          " $ramal," +
                          " $celula," +
                          " $maquina," +
                          " $ordem," +
                          " $requisicao," +
                          " $nf," +
                          " $prazo_entrega," +
                          " $data_recebimento," +
                          " $valor_item," +
                          " $valor_orc," +
                          " $prioridade," +
                          " $peso," +
                          " $quantidade," +
                          " $iss," +
                          " $codigo_servico," +
                          " $codigo_produto," +
                          " $numero_orc," +
                          " $numero_po," +
                          " $valor_orc_retorno);";

                putParameter(sqlite_cmd, "$id", id);
                putParameter(sqlite_cmd, "$provider_id", toInsert.ISSEBean.Fornecedor);
                putParameter(sqlite_cmd, "$sse_data", toInsert.ISSEBean.Data);
                putParameter(sqlite_cmd, "$type_id", toInsert.ISSEBean.Tipo);
                putParameter(sqlite_cmd, "$codigo", toInsert.ISSEBean.Codigo);
                putParameter(sqlite_cmd, "$referencia", toInsert.ISSEBean.Referencia);
                putParameter(sqlite_cmd, "$descricao", toInsert.ISSEBean.Descricao);
                putParameter(sqlite_cmd, "$solicitante", toInsert.ISSEBean.Requisitante.Matricula);
                putParameter(sqlite_cmd, "$ramal", toInsert.ISSEBean.Requisitante.Ramal);
                putParameter(sqlite_cmd, "$celula", toInsert.ISSEBean.Requisitante.CelulaString);
                putParameter(sqlite_cmd, "$maquina", toInsert.ISSEBean.Equipamento);
                putParameter(sqlite_cmd, "$ordem", toInsert.ISSEBean.Ordem);
                putParameter(sqlite_cmd, "$requisicao", toInsert.ISSEBean.Requisicao);
                putParameter(sqlite_cmd, "$nf", toInsert.ISSEBean.Nota);
                putParameter(sqlite_cmd, "$prazo_entrega", toInsert.ISSEBean.Prazo);
                putParameter(sqlite_cmd, "$data_recebimento", toInsert.data_recebimento);
                putParameter(sqlite_cmd, "$valor_item", toInsert.ISSEBean.Valor);
                putParameter(sqlite_cmd, "$valor_orc", toInsert.ISSEBean.ValorOrc);
                putParameter(sqlite_cmd, "$prioridade", toInsert.ISSEBean.Prioridade);
                putParameter(sqlite_cmd, "$peso", toInsert.ISSEBean.Peso);
                putParameter(sqlite_cmd, "$quantidade", toInsert.ISSEBean.Quantidade);
                putParameter(sqlite_cmd, "$iss", toInsert.iss);
                putParameter(sqlite_cmd, "$codigo_servico", toInsert.codigo_do_servico);
                putParameter(sqlite_cmd, "$codigo_produto", toInsert.codigo_do_produto);
                putParameter(sqlite_cmd, "$numero_orc", toInsert.numero_do_orcamento);
                putParameter(sqlite_cmd, "$numero_po", toInsert.numero_da_PO);
                putParameter(sqlite_cmd, "$valor_orc_retorno", toInsert.valor_do_orcamento_retorno);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<SSEDBWrapper> findSSE(String findBy, object value)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM MAIN WHERE "+findBy+" = $nvalue AND Excluded = FALSE";
                putParameter(sqlite_cmd, "$nvalue", value);
                List<SSEDBWrapper> toReturnList = new List<SSEDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    User nUser = new User();
                    nUser.Matricula = sqlite_datareader.GetString(solicitante_main_table_index);
                    nUser.Ramal = sqlite_datareader.GetString(ramal_main_table_index);
                    nUser.CelulaString = sqlite_datareader.GetString(celula_main_table_index);
                    
                    SSEBean sse = new SSEBean(nUser);
                    sse.Codigo = sqlite_datareader.GetString(codigo_main_table_index);
                    sse.Data = sqlite_datareader.GetDateTime(data_main_table_index);
                    sse.Descricao = sqlite_datareader.GetString(descricao_main_table_index);
                    sse.Equipamento = sqlite_datareader.GetString(maquina_main_table_index);
                    sse.Fornecedor = sqlite_datareader.GetInt16(fornecedor_main_table_index);
                    sse.Nota = sqlite_datareader.GetString(nota_main_table_index);
                    sse.Ordem = sqlite_datareader.GetString(ordem_main_table_index);
                    sse.Peso = sqlite_datareader.GetFloat(peso_main_table_index);
                    sse.Prazo = sqlite_datareader.GetDateTime(prazo_main_table_index);
                    sse.Prioridade = sqlite_datareader.GetInt16(prioridade_main_table_index);
                    sse.Quantidade = sqlite_datareader.GetInt16(quantidade_main_table_index);
                    sse.Referencia = sqlite_datareader.GetString(referencia_main_table_index);
                    sse.Requisicao = sqlite_datareader.GetString(requisicao_main_table_index);
                    sse.Tipo = sqlite_datareader.GetInt16(tipo_main_table_index);
                    sse.Valor = sqlite_datareader.GetFloat(valor_item_main_table_index);
                    sse.ValorOrc = sqlite_datareader.GetFloat(valor_orc_main_table_index);

                    SSEDBWrapper return_set = new SSEDBWrapper(sse);
                    return_set.codigo_do_produto = SafeGetString(sqlite_datareader, codigo_do_produto_main_table_index);
                    return_set.codigo_do_servico = SafeGetString(sqlite_datareader, codigo_do_servico_main_table_index);
                    return_set.data_recebimento = SafeGetDateTime(sqlite_datareader, data_rec_main_table_index);
                    return_set.iss = SafeGetString(sqlite_datareader, iss_main_table_index);
                    return_set.numero_da_PO = SafeGetString(sqlite_datareader, po_num_main_table_index);
                    return_set.numero_do_orcamento = SafeGetString(sqlite_datareader, orc_num_main_table_index);
                    return_set.valor_do_orcamento_retorno = SafeGetFloat(sqlite_datareader, valor_orc_retorno_num_main_table_index);
                    return_set.id = sqlite_datareader.GetInt32(id_main_table_index);

                    toReturnList.Add(return_set);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<SSEDBWrapper> findAllSSEs()
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM MAIN WHERE Excluded = FALSE";
                List<SSEDBWrapper> toReturnList = new List<SSEDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    User nUser = new User();
                    nUser.Matricula = sqlite_datareader.GetString(solicitante_main_table_index);
                    nUser.Ramal = sqlite_datareader.GetString(ramal_main_table_index);
                    nUser.CelulaString = sqlite_datareader.GetString(celula_main_table_index);

                    SSEBean sse = new SSEBean(nUser);
                    sse.Codigo = sqlite_datareader.GetString(codigo_main_table_index);
                    sse.Data = sqlite_datareader.GetDateTime(data_main_table_index);
                    sse.Descricao = sqlite_datareader.GetString(descricao_main_table_index);
                    sse.Equipamento = sqlite_datareader.GetString(maquina_main_table_index);
                    sse.Fornecedor = sqlite_datareader.GetInt16(fornecedor_main_table_index);
                    sse.Nota = sqlite_datareader.GetString(nota_main_table_index);
                    sse.Ordem = sqlite_datareader.GetString(ordem_main_table_index);
                    sse.Peso = sqlite_datareader.GetFloat(peso_main_table_index);
                    sse.Prazo = sqlite_datareader.GetDateTime(prazo_main_table_index);
                    sse.Prioridade = sqlite_datareader.GetInt16(prioridade_main_table_index);
                    sse.Quantidade = sqlite_datareader.GetInt16(quantidade_main_table_index);
                    sse.Referencia = sqlite_datareader.GetString(referencia_main_table_index);
                    sse.Requisicao = sqlite_datareader.GetString(requisicao_main_table_index);
                    sse.Tipo = sqlite_datareader.GetInt16(tipo_main_table_index);
                    sse.Valor = sqlite_datareader.GetFloat(valor_item_main_table_index);
                    sse.ValorOrc = sqlite_datareader.GetFloat(valor_orc_main_table_index);

                    SSEDBWrapper return_set = new SSEDBWrapper(sse);
                    return_set.codigo_do_produto = SafeGetString(sqlite_datareader,codigo_do_produto_main_table_index);
                    return_set.codigo_do_servico = SafeGetString(sqlite_datareader,codigo_do_servico_main_table_index);
                    return_set.data_recebimento = SafeGetDateTime(sqlite_datareader, data_rec_main_table_index);
                    return_set.iss = SafeGetString(sqlite_datareader,iss_main_table_index);
                    return_set.numero_da_PO = SafeGetString(sqlite_datareader,po_num_main_table_index);
                    return_set.numero_do_orcamento = SafeGetString(sqlite_datareader,orc_num_main_table_index);
                    return_set.valor_do_orcamento_retorno = SafeGetFloat(sqlite_datareader, valor_orc_retorno_num_main_table_index);
                    return_set.id = sqlite_datareader.GetInt32(id_main_table_index);

                    toReturnList.Add(return_set);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool deleteSSE(long id)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE MAIN SET " +
                    "Excluded = TRUE " +
                    "WHERE id = $mid;";
                putParameter(sqlite_cmd, "$mid", id);
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool updateSSE(int id, SSEDBWrapper newValue)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText =                    " UPDATE MAIN SET " +
                                                            " provider_id = $provider_id," +
                                                            " sse_data = $sse_data," +
                                                            " type_id = $type_id," +
                                                            " codigo = $codigo," +
                                                            " referencia = $referencia," +
                                                            " descricao = $descricao," +
                                                            " solicitante = $solicitante," +
                                                            " ramal = $ramal," +
                                                            " maquina = $maquina," +
                                                            " ordem = $ordem," +
                                                            " requisicao = $requisicao," +
                                                            " nf = $nf," +
                                                            " prazo_entrega = $prazo_entrega,"+
                                                            " data_recebimento = $data_recebimento," +
                                                            " valor_item = $valor_item," +
                                                            " valor_orc = $valor_orc," +
                                                            " prioridade = $prioridade," +
                                                            " peso = $peso," +
                                                            " quantidade = $quantidade," +
                                                            " iss = $iss," +
                                                            " codigo_servico = $codigo_servico," +
                                                            " codigo_produto = $codigo_produto," +
                                                            " numero_orc = $numero_orc," +
                                                            " numero_po = $numero_po," +
                                                            " valor_orc_retorno = $valor_orc_retorno" +
                                                            " WHERE id = $_id;";

                putParameter(sqlite_cmd, "$provider_id", newValue.ISSEBean.Fornecedor);
                putParameter(sqlite_cmd, "$sse_data", newValue.ISSEBean.Data);
                putParameter(sqlite_cmd, "$type_id", newValue.ISSEBean.Tipo);
                putParameter(sqlite_cmd, "$codigo", newValue.ISSEBean.Codigo);
                putParameter(sqlite_cmd, "$referencia", newValue.ISSEBean.Referencia);
                putParameter(sqlite_cmd, "$descricao", newValue.ISSEBean.Descricao);
                putParameter(sqlite_cmd, "$solicitante", newValue.ISSEBean.Requisitante.Matricula);
                putParameter(sqlite_cmd, "$ramal", newValue.ISSEBean.Requisitante.Ramal);
                putParameter(sqlite_cmd, "$maquina", newValue.ISSEBean.Equipamento);
                putParameter(sqlite_cmd, "$ordem", newValue.ISSEBean.Ordem);
                putParameter(sqlite_cmd, "$requisicao", newValue.ISSEBean.Requisicao);
                putParameter(sqlite_cmd, "$nf", newValue.ISSEBean.Nota);
                putParameter(sqlite_cmd, "$prazo_entrega", newValue.ISSEBean.Prazo);
                putParameter(sqlite_cmd, "$data_recebimento", newValue.data_recebimento);
                putParameter(sqlite_cmd, "$valor_item", newValue.ISSEBean.Valor);
                putParameter(sqlite_cmd, "$valor_orc", newValue.ISSEBean.ValorOrc);
                putParameter(sqlite_cmd, "$prioridade", newValue.ISSEBean.Prioridade);
                putParameter(sqlite_cmd, "$peso", newValue.ISSEBean.Peso);
                putParameter(sqlite_cmd, "$quantidade", newValue.ISSEBean.Quantidade);
                putParameter(sqlite_cmd, "$iss", newValue.iss);
                putParameter(sqlite_cmd, "$codigo_servico", newValue.codigo_do_servico);
                putParameter(sqlite_cmd, "$codigo_produto", newValue.codigo_do_produto);
                putParameter(sqlite_cmd, "$numero_orc", newValue.numero_do_orcamento);
                putParameter(sqlite_cmd, "$numero_po", newValue.numero_da_PO);
                putParameter(sqlite_cmd, "$valor_orc_retorno", newValue.valor_do_orcamento_retorno);
                putParameter(sqlite_cmd, "$_id", id);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }

        public long lastindexSSE()
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT MAX(id) FROM MAIN;";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                int returned = 0;
                while (sqlite_datareader.Read())
                {
                    returned = sqlite_datareader.GetInt32(0);
                }
                return returned;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 0;
            }
            finally
            {
                FinishConnection();
            }
        }
        #endregion

        #region Providers Data Handle
        public bool insertProvider(String toInsert)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO PROVIDERS(provider) " +
                    "VALUES($provider);";

                putParameter(sqlite_cmd, "$provider", toInsert);
                
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<ProviderDBWrapper> findProviders(String findBy, object value)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM PROVIDERS WHERE "+findBy+" = $nvalue";
                putParameter(sqlite_cmd, "$nvalue", value);
                List<ProviderDBWrapper> toReturnList = new List<ProviderDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    ProviderDBWrapper provider = new ProviderDBWrapper(sqlite_datareader.GetString(provider_providers__table_index));
                    provider.id = sqlite_datareader.GetInt32(id_providers_table_index);
                    toReturnList.Add(provider);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<ProviderDBWrapper> findAllProviders()
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM PROVIDERS";
                List<ProviderDBWrapper> toReturnList = new List<ProviderDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    ProviderDBWrapper provider = new ProviderDBWrapper(sqlite_datareader.GetString(provider_providers__table_index));
                    provider.id = sqlite_datareader.GetInt32(id_providers_table_index);
                    toReturnList.Add(provider);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool deleteProvider(int id)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM PROVIDERS " +
                    "WHERE id = $_id;";
                putParameter(sqlite_cmd, "$_id", id);
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool updateProvider(int id, String newValue)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = " UPDATE PROVIDERS SET " +
                                                            " provider = $provider" +
                                                            " WHERE id = $_id;";

                putParameter(sqlite_cmd, "$provider", newValue);
                putParameter(sqlite_cmd, "$_id", id);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        #endregion

        #region Types Data Handle
        public bool insertType(String toInsert)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO TYPES(type) " +
                    "VALUES($type);";

                putParameter(sqlite_cmd, "$type", toInsert);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<TypeDBWrapper> findTypes(String findBy, object value)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM TYPES WHERE "+findBy+" = $nvalue";
                putParameter(sqlite_cmd, "$nvalue", value);
                List<TypeDBWrapper> toReturnList = new List<TypeDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    TypeDBWrapper type = new TypeDBWrapper(sqlite_datareader.GetString(type_types_table_index));
                    type.id = sqlite_datareader.GetInt32(id_types_table_index);
                    toReturnList.Add(type);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<TypeDBWrapper> findAllTypes()
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM TYPES";
                List<TypeDBWrapper> toReturnList = new List<TypeDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    TypeDBWrapper provider = new TypeDBWrapper(sqlite_datareader.GetString(type_types_table_index));
                    provider.id = sqlite_datareader.GetInt32(id_types_table_index);
                    toReturnList.Add(provider);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool deleteType(int id)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM TYPES " +
                    "WHERE id = $_id;";
                putParameter(sqlite_cmd, "$_id", id);
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool updateType(int id, String newValue)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = " UPDATE TYPES SET " +
                                                            " type = $type" +
                                                            " WHERE id = $_id;";

                putParameter(sqlite_cmd, "$type", newValue);
                putParameter(sqlite_cmd, "$_id", id);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        #endregion

        #region Cell handle
        public bool insertCell(CellDBWrapper toInsert)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO CELL(Cell_name,setor_id) " +
                    "VALUES($Cell_name, $setor_id);";

                putParameter(sqlite_cmd, "$Celll_name", toInsert.name);
                putParameter(sqlite_cmd, "$setor_id", toInsert.setor);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<CellDBWrapper> findCells(String findBy, object value)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM CELL WHERE " + findBy + " = $nvalue";
                putParameter(sqlite_cmd, "$nvalue", value);
                List<CellDBWrapper> toReturnList = new List<CellDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    CellDBWrapper cell = new CellDBWrapper(sqlite_datareader.GetString(cell_name_cell_table_index));
                    cell.id = sqlite_datareader.GetInt32(id_cell_table_index);
                    cell.setor = sqlite_datareader.GetInt32(setor_id_cell_table_index);
                    toReturnList.Add(cell);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<CellDBWrapper> findAllCells()
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM CELL";
                List<CellDBWrapper> toReturnList = new List<CellDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    CellDBWrapper cell = new CellDBWrapper(sqlite_datareader.GetString(cell_name_cell_table_index));
                    cell.id = sqlite_datareader.GetInt32(id_cell_table_index);
                    cell.setor = sqlite_datareader.GetInt32(setor_id_cell_table_index);
                    toReturnList.Add(cell);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool deleteCell(int id)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM CELL " +
                    "WHERE id = $_id;";
                putParameter(sqlite_cmd, "$_id", id);
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool updateCell(int id, CellDBWrapper newValue)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = " UPDATE CELL SET " +
                                                            " Cell_name = $Cell_name" +
                                                            " setor_id = $setor_id" +
                                                            " WHERE id = $_id;";

                putParameter(sqlite_cmd, "$Cell_name", newValue.name);
                putParameter(sqlite_cmd, "$setor_id", newValue.setor);
                putParameter(sqlite_cmd, "$_id", id);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        #endregion

        #region Setor handle
        public bool insertSection(SetorDBWrapper toInsert)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO SECTIONS(setor_name) " +
                    "VALUES($setor_name);";

                putParameter(sqlite_cmd, "$setor_name", toInsert.name);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        // Parâmetros:
        //   findBy:
        //     it will find by this collum  (do not acepts id you must use s_id)
        //   value:
        //     the target value (only exactly results):
        public List<SetorDBWrapper> findSections(String findBy, object value)
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM SECTIONS WHERE " + findBy + " = $nvalue";
                putParameter(sqlite_cmd, "$nvalue", value);
                List<SetorDBWrapper> toReturnList = new List<SetorDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    SetorDBWrapper setor = new SetorDBWrapper(sqlite_datareader.GetString(sector_name_sections_table_index));
                    setor.id = sqlite_datareader.GetInt32(s_id_sections_table_index);
                    toReturnList.Add(setor);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public List<SetorDBWrapper> findAllSections()
        {
            InitConnection();
            try
            {
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM SECTIONS";
                List<SetorDBWrapper> toReturnList = new List<SetorDBWrapper>();
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    SetorDBWrapper setor = new SetorDBWrapper(sqlite_datareader.GetString(sector_name_sections_table_index));
                    setor.id = sqlite_datareader.GetInt32(s_id_sections_table_index);
                    toReturnList.Add(setor);
                }
                return toReturnList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool deleteSection(int id)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM SECTIONS " +
                    "WHERE s_id = $_id;";
                putParameter(sqlite_cmd, "$_id", id);
                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        public bool updateSection(int id, SetorDBWrapper newValue)
        {
            InitConnection();
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = db_connection.CreateCommand();
                sqlite_cmd.CommandText = " UPDATE SECTIONS SET " +
                                                            " sector_name = $sector_name" +
                                                            " WHERE s_id = $_id;";
                putParameter(sqlite_cmd, "$sector_name", newValue.name);
                putParameter(sqlite_cmd, "$_id", id);

                sqlite_cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                FinishConnection();
            }
        }
        #endregion

        private static void putParameter(SQLiteCommand sqlitecmd,String parameter, object value)
        {
            SQLiteParameter par = sqlitecmd.CreateParameter();
            par.ParameterName = parameter;
            par.Value = value;
            sqlitecmd.Parameters.Add(par);
        }

        public static string SafeGetString(SQLiteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
        public static float SafeGetFloat(SQLiteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetFloat(colIndex);
            return -1;
        }
        public static DateTime SafeGetDateTime(SQLiteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return new DateTime(0,0,0);
        }
    }
}
