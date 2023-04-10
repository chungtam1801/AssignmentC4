using Assignment.Models;
namespace Assignment.IServices
{
    public interface IBillDetailService
    {
        public List<BillDetail> GetAllBillDetail(Guid id);
        public BillDetail GetBillDetailById(Guid id);
        public bool CreateBillDetail(BillDetail x);
        public bool UpdateBillDetail(BillDetail x);
        public bool DeleteBillDetail(Guid id);
    }
}
