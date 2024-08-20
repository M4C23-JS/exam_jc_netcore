using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;

namespace exam_jc_netcore_react.Models.Repository.Impl
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly string _connectionString;

        public InstrumentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddInstrumentAsync(Instrument instrument)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("AddInstrument", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", instrument.Id);
                    command.Parameters.AddWithValue("@Name", instrument.Name);
                    command.Parameters.AddWithValue("@Type", instrument.Type);
                    command.Parameters.AddWithValue("@Price", instrument.Price);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Collection<Instrument>> GetAllInstrumentsAsync()
        {
            Collection<Instrument> gamesList = new Collection<Instrument>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetAllInstruments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            gamesList.Add(new Instrument
                            {
                                Id = reader.GetString(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Type = reader.GetString(reader.GetOrdinal("Type")),
                                Price = reader.GetString(reader.GetOrdinal("Price"))
                                //IsDeleted = null
                            });
                        }
                    }
                }
            }

            return gamesList;
        }

        public async Task UpdateInstrumentAsync(Instrument instrument)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("EditInstrument", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", instrument.Id);
                    command.Parameters.AddWithValue("@Name", instrument.Name);
                    command.Parameters.AddWithValue("@Type", instrument.Type);
                    command.Parameters.AddWithValue("@Price", instrument.Price);

                    //command.Parameters.AddWithValue("@IsDeleted", game.IsDeleted);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Instrument> GetInstrumentByIdAsync(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetInstrumentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Instrument
                            {
                                Id = reader.GetString(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Type = reader.GetString(reader.GetOrdinal("Type")),
                                Price = reader.GetString(reader.GetOrdinal("Price"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task DeleteInstrumentAsync(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SoftDeleteInstrument", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
}
}
