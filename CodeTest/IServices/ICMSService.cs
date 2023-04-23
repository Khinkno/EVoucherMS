using CodeTest.Model;

namespace CodeTest.IServices
{
    public interface ICMSService
    {
        public Task<Evouchers> SaveEvoucher(Evouchers evoucher);
        public Task<Evouchers> UpdateEvoucher(int id, Evouchers evoucher);
        public Task<Evouchers> GetEVoucherById(int id);

    }
}
