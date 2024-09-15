using LoanApp.Infrastructure.Entity.Data;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Application.Helpers
{
    public class Context
    {
        private JsonConexion jsonConexion = new JsonConexion();

        public LoanAppDbContext Get()
        {
            var dbContext = new LoanAppDbContext(GetDataContextBD());

            return dbContext;
        }

        private DbContextOptions<LoanAppDbContext> GetDataContextBD()
        {
            var jsonCon = jsonConexion.GetConStr();

            var contextOption = new DbContextOptionsBuilder<LoanAppDbContext>()
             .UseSqlServer(jsonCon.ConnectionStrings.LoanDB).Options;

            return contextOption;
        }

        private DbContextOptions<LoanAppDbContext> GetDataContext(string instanceName)
        {
            var Db = instanceName;
            var connectionString = string.Empty;
            var jsonCon = jsonConexion.GetConStr();

            switch (Db)
            {
                case "LoanDB":
                    connectionString = jsonCon.ConnectionStrings.LoanDB;
                    break;
            }

            var contextOption = new DbContextOptionsBuilder<LoanAppDbContext>()
            .UseSqlServer(connectionString).Options;

            return contextOption;
        }
    }
}
