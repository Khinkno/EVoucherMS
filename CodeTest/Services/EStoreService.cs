using CodeTest.Model;
using Microsoft.EntityFrameworkCore;
using CodeTest.IServices;
using CodeTest.DTO;

namespace CodeTest.Services
{
    public class EStoreService : IEStoreService
    {
        private readonly DataContext _context;

        public EStoreService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Evouchers>> GetEvouchers(bool? showActive = null)
        {
            if (showActive != null && showActive.HasValue)
            {
                return await _context.Evoucher.AsNoTracking().Where(x => x.IsActive == showActive).ToListAsync();
            }
            else
            {
                return await _context.Evoucher.AsNoTracking().ToListAsync();
            }
        }
        public async Task<List<Evouchers>> CheckOut(bool? showActive = null)
        {
            if (showActive != null && showActive.HasValue)
            {
                return await _context.Evoucher.AsNoTracking().Where(x => x.IsActive == showActive).ToListAsync();
            }
            else
            {
                return await _context.Evoucher.AsNoTracking().ToListAsync();
            }
        }
        public async Task<List<Payments>> GetPaymentList()
        {
            var paymentlist = await _context.Payment.AsNoTracking().ToListAsync();
            return paymentlist;
        }
        public async Task<List<Items>> GetCheckOutItem()
        {
            var paymentlist = await _context.Items.AsNoTracking().ToListAsync();
            return paymentlist;
        }
        public async Task<Purchases> SavePurchase(decimal dispercent, Purchases purchases)
        {
            if (dispercent == 0)
            {
                purchases.Amount = purchases.TotalAmount;
                purchases.DisAmount = 0;
            }
            else
            {
                var getlist = await _context.Purchase.OrderBy(x => x.Id).LastOrDefaultAsync();
                if (getlist == null)
                {
                   
                    purchases.Promocode = "PRO" + new string(purchases.Name.Take(2).ToArray()) + purchases.EvoucherId + DateTime.Now.Day + "000" ;
                }
                else
                {
                    int getcode = Convert.ToInt32(getlist.Promocode.Substring(getlist.Promocode.Length - 6)) + 1;
                    string getno = getcode.ToString().Substring(getcode.ToString().Length - 3);
                    purchases.Promocode = "PRO" + new string(purchases.Name.Take(2).ToArray()) + purchases.EvoucherId + DateTime.Now.Day + getno;
                }

                //purchases.Promocode = (purchases.PhNo).ToString().Substring(0, 4) + purchases.EvoucherId + purchases.Name.Substring(0, 5);
                purchases.DisAmount = purchases.TotalAmount * (dispercent / 100);
                purchases.Amount = purchases.TotalAmount - purchases.DisAmount;
                Evouchers result = await _context.Evoucher.AsNoTracking().FirstOrDefaultAsync(x => x.Id == purchases.EvoucherId);
                result.Inuse = true;
                _context.Evoucher.Update(result);
                await _context.SaveChangesAsync();
            }

            await _context.Purchase.AddAsync(purchases);
            await _context.SaveChangesAsync();
            return purchases;
            //var data = await _context.Evoucher.FirstOrDefaultAsync();
            //if (data == null)
            //{
            //    evoucher.Id = 1;
            //}
            //else
            //{
            //    evoucher.Id = _context.Evoucher.Max(x => x.Id) + 1;
            //}
            //await _context.Evoucher.AddAsync(evoucher);
            //await _context.SaveChangesAsync();
            //return evoucher;
        }

        public async Task<Payments> GetDisPercentById(int id)
        {
            Payments result = await _context.Payment.AsNoTracking().FirstOrDefaultAsync(x => x.PaymentId == id);
            return result;
        }
        public async Task<List<Evouchers>> GetUsedOrUnusedEvouchers(bool? inuse = null)
        {
            if (inuse != null && inuse.HasValue)
            {
                return await _context.Evoucher.AsNoTracking().Where(x => x.Inuse == inuse).ToListAsync();
            }
            else
            {
                return await _context.Evoucher.AsNoTracking().ToListAsync();
            }

        }
    }
}
