using JobFetcherAssesment.Interfaces;
using JobFetcherAssesment.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace JobFetcherAssesment.Repository
{
    public class JobRepository:IJobRepository
    {
        private readonly string _connectionString;
        public JobRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        private SqlConnection NewConnection() => new SqlConnection(_connectionString);

        public async Task<JobsDto?> GetJobsByIdAsync(int id)
        {
            try
            {
                const string sql = @"SELECT * FROM Jobs WHERE JobId = @id";
                using var conn = NewConnection();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                await conn.OpenAsync();
                using var rdr = await cmd.ExecuteReaderAsync();
                if (!await rdr.ReadAsync()) return null;
                return MapReaderToJob(rdr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<JobsDto>> GetAllJobsAsync(int page = 1, int pageSize = 50)
        {
            try
            {
                const string sql = @"SELECT * FROM Jobs ORDER BY JobName OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
                using var conn = NewConnection();
                using var cmd = new SqlCommand(sql, conn);
                int offset = (page - 1) * pageSize;
                cmd.Parameters.Add(new SqlParameter("@offset", SqlDbType.Int) { Value = offset });
                cmd.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.Int) { Value = pageSize });
                await conn.OpenAsync();
                using var rdr = await cmd.ExecuteReaderAsync();
                var list = new List<JobsDto>();
                while (await rdr.ReadAsync()) list.Add(MapReaderToJob(rdr));
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private JobsDto MapReaderToJob(SqlDataReader rdr)
        {
            return new JobsDto
            {
                JobId = rdr.GetInt32(rdr.GetOrdinal("JobId")),
                JobName = rdr.GetString(rdr.GetOrdinal("JobName")),
                DurationInMinutes = rdr.GetInt32(rdr.GetOrdinal("DurationInMinutes")),

                StartTime = rdr.IsDBNull(rdr.GetOrdinal("StartTime"))
           ? (DateTime?)null
           : rdr.GetDateTime(rdr.GetOrdinal("StartTime")),

                EndTime = rdr.IsDBNull(rdr.GetOrdinal("EndTime"))
           ? (DateTime?)null
           : rdr.GetDateTime(rdr.GetOrdinal("EndTime")),

                Priority = rdr.GetInt32(rdr.GetOrdinal("Priority")),
                Status = rdr["Status"] as string,

                MachineId = rdr.IsDBNull(rdr.GetOrdinal("MachineId"))
           ? 0
           : rdr.GetInt32(rdr.GetOrdinal("MachineId")),

                CreatedAt = rdr.IsDBNull(rdr.GetOrdinal("CreatedAt"))
           ? (DateTime?)null
           : rdr.GetDateTime(rdr.GetOrdinal("CreatedAt")),

                UpdatedAt = rdr.IsDBNull(rdr.GetOrdinal("UpdatedAt"))
           ? (DateTime?)null
           : rdr.GetDateTime(rdr.GetOrdinal("UpdatedAt")),
            };
        }
    }
}
