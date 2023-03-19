using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class BillDetailService : IBillDetailService
    {
        AssignmentDBContext context;
        public BillDetailService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateBillDetail(BillDetail p)
        {
            try
            {
                context.BillDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                BillDetail p = context.BillDetails.Find(id);
                context.BillDetails.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<BillDetail> GetAllBillDetail()
        {
            return context.BillDetails.ToList();
        }

        public BillDetail GetBillDetailById(Guid id)
        {
            return context.BillDetails.Find(id);
        }
        public bool UpdateBillDetail(BillDetail p)
        {
            try
            {
                var billDetail = context.BillDetails.Find(p.ID);
                billDetail.Quantity = p.Quantity;
                billDetail.Price = p.Price;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

