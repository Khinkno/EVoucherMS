using CodeTest.Model;

namespace CodeTest.IServices
{
    public interface IEStoreService
    {
        public Task<List<Evouchers>> GetEvouchers(bool? showActive = null);

        public Task<List<Payments>> GetPaymentList();

        public Task<List<Items>> GetCheckOutItem();

        public Task<Payments> GetDisPercentById(int id);
        public Task<Purchases> SavePurchase(decimal discount,Purchases purchases);

        public Task<List<Evouchers>> GetUsedOrUnusedEvouchers(bool? inuse = null);


    }
}

