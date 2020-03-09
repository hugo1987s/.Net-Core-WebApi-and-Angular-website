using Dapper;
using Microsoft.Data.SqlClient;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) :base(connectionString)
        {

        }

        public IEnumerable<Supplier> SupplierPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
