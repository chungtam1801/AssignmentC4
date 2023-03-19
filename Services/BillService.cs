using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class BillService : IBillService
    {
        AssignmentDBContext context;
        public BillService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateBill(Bill p)
        {
            try
            {
                context.Bills.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                Bill p = context.Bills.Find(id);
                context.Bills.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Bill> GetAllBill()
        {
            return context.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.Find(id);
        }
        public bool UpdateBill(Bill p)
        {
            try
            {
                var bill = context.Bills.Find(p.ID);
                //bill.Quantity = p.Quantity;
                //bill.Price = p.Price;
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

