using Assignment.IServices;
using Assignment.Models;
using Assignment.ViewModels;

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
                bill.Status = p.Status;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<BillChartVM> GetBillChartVM()
        {
            var lst = (from x in (from a in context.Bills.Where(x => x.CreateDate.Date > DateTime.Today.AddDays(-5))
                                  join b in (from c in context.BillDetails group c by c.BillID into g select new { BillID = g.Key, SumPriceBill = g.Sum(d => d.Price) })
                                  on a.ID equals b.BillID
                                  select new
                                  {
                                      CreateDate = a.CreateDate,
                                      SumPriceBill = b.SumPriceBill
                                  })
                       group x by x.CreateDate.Date into f
                       select new BillChartVM()
                       {
                           CreateDate = f.Key,
                           SumPrice = f.Sum(y => y.SumPriceBill)
                       }).ToList();
            return lst;        
        }
    }
}

