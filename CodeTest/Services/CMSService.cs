using Microsoft.EntityFrameworkCore;
using CodeTest.IServices;
using CodeTest.Model;

namespace CodeTest.Services
{
    public class CMSService :ICMSService
    {
        private readonly DataContext _context;

        public CMSService(DataContext context)
        {
            _context = context;
        }


        public async Task<Evouchers> SaveEvoucher(Evouchers evoucher)
        {
            evoucher.PromoCode = Guid.NewGuid();
            var data = await _context.Evoucher.FirstOrDefaultAsync();
            if (data == null)
            {
                evoucher.Id = 1;
            }
            else
            {
                evoucher.Id = _context.Evoucher.Max(x => x.Id) + 1;
            }
            await _context.Evoucher.AddAsync(evoucher);
            await _context.SaveChangesAsync();
            return evoucher;
        }



        public async Task<Evouchers> GetEVoucherById(int id)
        {
            Evouchers result = await _context.Evoucher.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }


        public async Task<Evouchers> UpdateEvoucher(int id, Evouchers evoucher)
        {
            evoucher.PromoCode = Guid.NewGuid();
            _context.Evoucher.Update(evoucher);
            await _context.SaveChangesAsync();
            return evoucher;
        }

        public async Task<List<Evouchers>> GetAllEVouchers(bool? showActive = null)
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

    }
}
