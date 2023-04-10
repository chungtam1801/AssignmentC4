using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.IServices
{
    public interface IBillService
    {
        public List<Bill> GetAllBill();
        public Bill GetBillById(Guid id);
        public bool CreateBill(Bill x);
        public bool UpdateBill(Bill x);
        public bool DeleteBill(Guid id);
        public List<BillChartVM> GetBillChartVM();

    }
}
