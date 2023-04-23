using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CodeTest.DTO;
using CodeTest.IServices;
using CodeTest.Model;
using CodeTest.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Test.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class EStoreAPI : Controller
    {
        private readonly ILogger<EStoreAPI> _logger;

        private readonly IMapper _mapper;

        private readonly IEStoreService _estoreService;

        private readonly ICMSService _cmsService;


        public EStoreAPI(ILogger<EStoreAPI> logger, IMapper mapper, IEStoreService estoreService,ICMSService cmsService)
        {
            _logger = logger;
            _mapper = mapper;
            _estoreService = estoreService;
            _cmsService = cmsService;
        }

        [Route("GetEvouchers")]
        [HttpGet]
        public async Task<ActionResult> GetEvouchers([FromQuery] bool? showActive = null)
        {
            return Ok(await _estoreService.GetEvouchers(showActive));
        }

        [Route("GetPaymentList")]
        [HttpGet]
        public async Task<ActionResult> GetPaymentList()
        {
            return Ok(await _estoreService.GetPaymentList());
        }

        [Route("CheckOutItem")]
        [HttpGet]
        public async Task<ActionResult> GetCheckOutItem()
        {
            return Ok(await _estoreService.GetCheckOutItem());

            //List<Payments> PaymentList = await _estoreService.GetPaymentList();
            //List<PaymentDTO> PaymentDtoList = new List<PaymentDTO>();
            //PaymentList.ForEach(x => PaymentDtoList.Add(_mapper.Map<PaymentDTO>(x)));

            //return PaymentDtoList;
        }
        [Route("SavePayment")]
        [HttpPost]
        public async Task<ActionResult> SavePurchase(PurchaseDTO purchaseDTO)
        {

            bool inuse = false;
            var evoucher = await _cmsService.GetEVoucherById(purchaseDTO.EvoucherId);
            var dispercent = await _estoreService.GetDisPercentById(purchaseDTO.PaymentId);
            if ((dispercent.DisPercent).Equals("null")) dispercent.DisPercent = 0;
            decimal discountpercent = dispercent.DisPercent;
            if (evoucher == null)
            {
                return NotFound("EVoucher Not Found");
            }
            else
            {
                Purchases purchase = _mapper.Map<Purchases>(purchaseDTO);
                return Ok(await _estoreService.SavePurchase(discountpercent, purchase));

            }
        }

        [Route("GetUseOrUnusedEvouchers")]
        [HttpGet]
        public async Task<ActionResult> GetUsedOrUnusedEvouchers([FromQuery] bool? inuse = null)
        {
            return Ok(await _estoreService.GetUsedOrUnusedEvouchers(inuse));
        }
    }

}