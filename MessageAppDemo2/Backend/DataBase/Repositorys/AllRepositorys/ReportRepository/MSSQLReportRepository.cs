using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ReportRepository
{
    public class MSSQLReportRepository : Repository<ReportBase, Guid>, IRunStoredProcedure<SqlCommand, SqlDataReader>
    {
        private MSSQLDatabase MSSQLDatabase;
        public MSSQLReportRepository(MSSQLDatabase Database)
        {
            this.MSSQLDatabase = Database;
        }



        public void ExecuteStoredProcedure(SqlCommand cmd, string SPName, string[] ParameterNames, object[] Values)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ExecuteStoredProcedureAndRead(SqlCommand cmd, string SPName, string[] ParameterNames, object[] Values)
        {
            throw new NotImplementedException();
        }



        public override ReportBase GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public override void SaveAllChanges()
        {
            throw new NotImplementedException();
        }

        public override void UpdateVirtualList()
        {
            throw new NotImplementedException();
        }
    }
}
