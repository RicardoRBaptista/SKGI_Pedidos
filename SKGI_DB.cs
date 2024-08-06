using System;
using System.Data;
using System.Data.SqlClient;

namespace SKGI_Pedidos
{
    public class SKGI_DB
    {
        private string m_connectionString;
        private bool m_manterConexao;
        private bool m_BeginTrans;
        private SqlTransaction m_transaction;
        private SqlConnection conexao;

        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;
            }
        }

        public bool ManterConexao
        {
            get
            {
                return m_manterConexao;
            }
            set
            {
                m_manterConexao = value;
            }
        }

        public SqlTransaction Transaction
        {
            get
            {
                return m_transaction;
            }
            set
            {
                m_transaction = value;
            }
        }

        public bool BeginTrans
        {
            get
            {
                return m_BeginTrans;
            }
            set
            {
                m_BeginTrans = value;
            }
        }

        public SKGI_DB(string connectionString)
        {
            this.m_connectionString = connectionString;
            BeginTrans = false;
        }

        public SKGI_DB(string connectionString, bool manterConexao)
        {
            this.m_connectionString = connectionString;
            this.m_manterConexao = manterConexao;
            this.m_transaction = null;
            BeginTrans = false;
        }

        public SKGI_DB(string connectionString, bool manterConexao, bool begintrans)
        {
            this.m_connectionString = connectionString;
            this.m_manterConexao = manterConexao;
            this.m_BeginTrans = begintrans;
            this.m_transaction = null;
        }

        public void Fechar()
        {
            if (!(conexao == null))
            {
                conexao.Close();
                conexao.Dispose();
            }
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType)
        {
            return ExecuteNonQuery(cmdText, cmdType, null);
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd;

            int retVal;
            try
            {
                if (ManterConexao == false & BeginTrans == false)
                {
                    cmd = CriarComando(cmdText, cmdType, parameters);

                    retVal = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    this.Fechar();
                }
                else
                {
                    VerificarConexao();
                    if (BeginTrans & m_transaction == null)
                        m_transaction = conexao.BeginTransaction();

                    cmd = CriarComando(cmdText, cmdType, parameters);

                    retVal = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                return retVal;
            }
            catch (Exception e)
            {
                this.Fechar();
                throw e;
            }
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType)
        {
            return ExecuteScalar(cmdText, cmdType, null);
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = CriarComando(cmdText, cmdType, parameters);
            object retVal;
            try
            {
                if (ManterConexao == false)
                {
                    retVal = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    this.Fechar();
                }
                else
                {
                    retVal = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                return retVal;
            }
            catch (Exception e)
            {
                this.Fechar();
                throw e;
            }
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType)
        {
            SqlCommand cmd = CriarComando(cmdText, cmdType, null);
            return GetDataReader(cmd);
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            SqlCommand cmd = CriarComando(cmdText, cmdType, parameters);
            return GetDataReader(cmd);
        }

        private SqlDataReader GetDataReader(SqlCommand cmd)
        {
            try
            {
                SqlDataReader drTemp;
                if (ManterConexao == false)
                {
                    drTemp = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                    return drTemp;
                }
                else
                {
                    drTemp = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    return drTemp;
                }
            }
            catch (Exception e)
            {
                this.Fechar();
                throw e;
            }
        }

        private SqlCommand CriarComando(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(cmdText);
            cmd.CommandTimeout = 0;
            cmd.CommandType = cmdType;
            if (!(m_transaction == null))
                cmd.Transaction = m_transaction;

            if (!(parameters == null))
            {
                //SqlParameter paramTemp;
                foreach (SqlParameter paramTemp in parameters)
                    cmd.Parameters.Add(paramTemp);
            }
            VerificarConexao(ref cmd);
            return cmd;
        }

        public static SqlParameter CriarParametro(string name, SqlDbType type, object value)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = name;
            param.SqlDbType = type;

            if (value == null)
                param.Value = DBNull.Value;
            else if (type == SqlDbType.VarChar & value.ToString().Length == 0)
                param.Value = DBNull.Value;
            else
                param.Value = value;
            return param;
        }

        private void VerificarConexao(ref SqlCommand cmd)
        {
            try
            {
                if (conexao == null)
                {
                    conexao = new SqlConnection(m_connectionString);
                    conexao.Open();
                }
                else if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                cmd.Connection = conexao;
                return;
            }
            catch (Exception e)
            {
                this.Fechar();
                throw e;
            }
        }

        private void VerificarConexao()
        {
            if (conexao == null)
            {
                conexao = new SqlConnection(m_connectionString);
                conexao.Open();
            }
            else if (conexao.State != ConnectionState.Open)
                conexao.Open();
            return;
        }

        //public int VerificarStatus()
        //{
        //    return conexao.State;
        //}

        public static string GetString(ref SqlDataReader dr, int ordinal)
        {
            if (!dr.IsDBNull(ordinal))
                return dr.GetString(ordinal);
            else
                return null;
        }

        public static int GetInt32(ref SqlDataReader dr, int ordinal)
        {
            if (!dr.IsDBNull(ordinal))
                return dr.GetInt32(ordinal);
            else
                return default;
        }

        public void Commit()
        {
            try
            {
                if (!(Transaction == null))
                    if (!(Transaction == null))
                    Transaction.Commit();
            }
            catch
            {
            }// não exibe mensagem caso der erro
        }

        public void Rollback()
        {
            try
            {
                if (!(Transaction == null))
                    if (!(Transaction.Connection == null))
                    Transaction.Rollback();
            }
            catch
            {
            }// não exibe mensagem caso der erro
        }
    }
}