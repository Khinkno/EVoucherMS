using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeTest.DTO;
using CodeTest.IServices;
using CodeTest.Model;

namespace Test.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CMSController : ControllerBase
    {

        private readonly ILogger<CMSController> _logger;

        private readonly IMapper _mapper;

        private readonly ICMSService _cmsService;

        public CMSController(ILogger<CMSController> logger, IMapper mapper, ICMSService cmsService)
        {
            _logger = logger;
            _mapper = mapper;
            _cmsService = cmsService;
        }

        [Route("CreateEvoucher")]
        [HttpPost]
        public async Task<ActionResult> CreateEVoucher( EvoucherDTO evoucherDTO)
        {
            Evouchers evoucher = _mapper.Map<Evouchers>(evoucherDTO);
            return Ok(await _cmsService.SaveEvoucher(evoucher));
        }

        [Route("UpdateEvoucher")]
        [HttpPost]
        public async Task<ActionResult> UpdateEvoucher([FromBody] EvoucherDTO evoucherDTO)
        {
            var result = await _cmsService.GetEVoucherById(evoucherDTO.Id);
            if (result == null)
            {
                return NotFound("EVoucher Not Found");
            }
            else
            {
                Evouchers evoucher = _mapper.Map<Evouchers>(evoucherDTO);
                return Ok(await _cmsService.UpdateEvoucher(evoucher.Id, evoucher));
            }
        }

    }

}
