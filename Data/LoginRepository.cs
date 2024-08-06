//using SKGI_API.Models;
using System.Data;
using System;
using System.Data.SqlClient;

namespace SKGI_Pedidos.Repositorio
{
    public class LoginRepository
    {
        internal int login()
        {
            try
            {
                SqlParameter[] param;
                string sql = "SELECT usuCod FROM dbo.WS_UsuariosAutorizados WHERE  (usuLogin = @usuLogin) AND (usuSenha = @usuSenha)";
                SKGI_DB BD = new SKGI_DB(Configuracao.ConnectionString, false, false);

                param = new[]
                {
                    SKGI_DB.CriarParametro("usuLogin", SqlDbType.Char, "Ricardo"),
                    SKGI_DB.CriarParametro("usuSenha", SqlDbType.Char, "123456")
                };

                var obj = BD.ExecuteScalar(sql, CommandType.Text, param);

                if (obj != null)
                {
                    BD.Fechar();

                    return Convert.ToInt32(obj);
                }
                else
                {
                    BD.Fechar();

                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
