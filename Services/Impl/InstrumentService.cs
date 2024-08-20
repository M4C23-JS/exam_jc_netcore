using exam_jc_netcore_react.Models;
using exam_jc_netcore_react.Models.Repository;
using System.Collections.ObjectModel;

namespace exam_jc_netcore_react.Services.Impl
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository _instrumentRepository;

        // Constructor actualizado para recibir una instancia de IInstrumentRepository
        public InstrumentService(IInstrumentRepository instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;
        }
        public async Task<Collection<Instrument>> GetAllInstrumentsAsync()
            => await _instrumentRepository.GetAllInstrumentsAsync();


        public async Task<Instrument> GetInstrumentByIdAsync(string id)
            => await _instrumentRepository.GetInstrumentByIdAsync(id);


        public async Task AddInstrumentAsync(Instrument instrument)
            => await _instrumentRepository.AddInstrumentAsync(instrument);


        public async Task UpdateInstrumentAsync(Instrument instrument)
            => await _instrumentRepository.UpdateInstrumentAsync(instrument);


        public async Task DeleteInstrumentAsync(string id)
            => await _instrumentRepository.DeleteInstrumentAsync(id);
    }
}
