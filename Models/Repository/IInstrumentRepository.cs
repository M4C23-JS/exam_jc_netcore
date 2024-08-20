using System.Collections.ObjectModel;

namespace exam_jc_netcore_react.Models.Repository
{
    public interface IInstrumentRepository
    {
        Task<Collection<Instrument>> GetAllInstrumentsAsync();
        Task<Instrument> GetInstrumentByIdAsync(string id);
        Task AddInstrumentAsync(Instrument instrument);
        Task UpdateInstrumentAsync(Instrument instrument);
        Task DeleteInstrumentAsync(string id);
    }
}
