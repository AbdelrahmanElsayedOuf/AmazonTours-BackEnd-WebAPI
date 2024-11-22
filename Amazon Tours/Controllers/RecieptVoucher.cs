using AmazonTours.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecieptVoucher : AppBaseController
    {
        private readonly IReceiptVoucherService _receiptVoucherService;

        public RecieptVoucher(IReceiptVoucherService receiptVoucherService)
        {
            _receiptVoucherService = receiptVoucherService;
        }

        [HttpGet]
        [Route("GetAllReceiptVouchers")]
        public async Task<IActionResult> GetAllReceiptVouchers()
        {
            var receiptVouchers = await _receiptVoucherService.GetAllAsync();
            return OkResponse(receiptVouchers);
        }
    }
}
