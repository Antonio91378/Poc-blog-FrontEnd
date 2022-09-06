using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Utils
{
    public static class ApplicationSettings
    {
        public static string GetMongoDBConnectionString()
        {
            var configuration = new Configuration();
            return configuration.ConfiguracaoDoArquivoAppSettings["Database:ConnectionString"];
        }
    }
}
