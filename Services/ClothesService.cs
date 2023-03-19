﻿using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class ClothesService : IClothesService
    {
        AssignmentDBContext context;
        public ClothesService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateClothes(Clothes p)
        {
            try
            {
                context.Clotheses.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClothes(Guid id)
        {
            try
            {
                Clothes p = context.Clotheses.Find(id);
                context.Clotheses.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Clothes> GetAllClothes()
        {
            return context.Clotheses.ToList();
        }

        public Clothes GetClothesById(Guid id)
        {
            return context.Clotheses.Find(id);
        }

        public List<Clothes> GetClothesByName(string name)
        {
            return context.Clotheses.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateClothes(Clothes p)
        {
            try
            {
                var clothes = context.Clotheses.Find(p.ID);
                //clothes.Quantity = p.Quantity;
                //clothes.Price = p.Price;
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
