using exam_jc_netcore_react.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace exam_jc_netcore_react.Services
{
    public interface IInstrumentService
    {
        Task<Collection<Instrument>> GetAllInstrumentsAsync();
        Task<Instrument> GetInstrumentByIdAsync(string id);
        Task AddInstrumentAsync(Instrument instrument);
        Task UpdateInstrumentAsync(Instrument instrument);
        Task DeleteInstrumentAsync(string id);
    }
    

}
