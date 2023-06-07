using Givvin.Volunteer.ApiModels;
using Givvin.Volunteer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Givvin.Volunteer.Controllers
{
    [ApiController]
    [Route("api/campaigns")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignGetApiModel>> GetById(string id)
        {
            var campaign = await _campaignRepository.GetByIdAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(campaign.ToApiModel());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignGetApiModel>>> GetAll()
        {
            var campaigns = await _campaignRepository.GetAllAsync();
            var campaignApiModels = campaigns.Select(c => c.ToApiModel());
            return Ok(campaignApiModels);
        }

        [HttpPost]
        public async Task<ActionResult<CampaignPostApiModel>> Post([FromBody] CampaignPostApiModel campaignApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campaign = campaignApiModel.ToEntity();
            await _campaignRepository.CreateAsync(campaign);

            return CreatedAtAction(nameof(GetById), new { id = campaign.Id }, campaign.ToApiModel());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CampaignUpdateApiModel>> Update(string id, [FromBody] CampaignUpdateApiModel campaignApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCampaign = await _campaignRepository.GetByIdAsync(id);
            if (existingCampaign == null)
            {
                return NotFound();
            }

            existingCampaign.UpdateFromApiModel(campaignApiModel);
            await _campaignRepository.UpdateAsync(id, existingCampaign);

            return Ok(existingCampaign.ToApiModel());
        }
    }
}
