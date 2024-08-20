

using exam_jc_netcore_react.Models;
using exam_jc_netcore_react.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace exam_jc_netcore_react.Controllers
{
    [ApiController]
    [Route("/instruments")]
    public class InstrumentsController : ControllerBase
    {
        private readonly ILogger<InstrumentsController> _logger;
        private readonly IInstrumentService _instrumentService;

        public InstrumentsController(ILogger<InstrumentsController> logger, IInstrumentService instrumentService)
        {
            _logger = logger;
            _instrumentService = instrumentService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Collection<Instrument>>> GetAllInstruments()
        {
            try
            {
                var gamesList = await _instrumentService.GetAllInstrumentsAsync();
                return Ok(gamesList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching instruments.");
                return StatusCode(500, "An error occurred while fetching instruments.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInstrument([FromBody] Instrument instrument)
        {
            try
            {
                if (instrument == null)
                {
                    return BadRequest("Instrument is null.");
                }

                instrument.Id = Guid.NewGuid().ToString();
                await _instrumentService.AddInstrumentAsync(instrument);
                return Ok("Game added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a instrument.");
                return StatusCode(500, "An error occurred while adding the instrument.");
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditInstrument(string id, [FromBody] Instrument instrument)
        {
            try
            {
                if (instrument == null || instrument.Id != id)
                {
                    return BadRequest("Invalid game data.");
                }

                await _instrumentService.UpdateInstrumentAsync(instrument);
                return Ok("Game updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the instrument.");
                return StatusCode(500, "An error occurred while updating the instrument.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetInstrumentById(string id)
        {
            try
            {
                var game = await _instrumentService.GetInstrumentByIdAsync(id);
                if (game == null)
                {
                    return NotFound("Game not found.");
                }
                return Ok(game);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching the instrument by ID.");
                return StatusCode(500, "An error occurred while fetching the instrument.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteInstrument(string id)
        {
            try
            {
                await _instrumentService.DeleteInstrumentAsync(id);
                return Ok("Game deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting the instrument.");
                return StatusCode(500, "An error occurred while deleting the instrument.");
            }
        }
    }
}
