using EFTask.DAL;
using EFTask.Models;
using Microsoft.EntityFrameworkCore;
namespace EFTask.Services
{
    internal class SizeService
    {
        public void CreateSize(string name, int pizzaId,double price)
        {
            Size size = new Size
            {
                Name = name,
                PizzaId = pizzaId,
                Price = price
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Sizes.Add(size);
                context.SaveChanges();
                Console.WriteLine("Succesfully added.");
            }
        }
        public List<Size> GetAll()
        {
            List<Size> sizes = new List<Size>();
            using (AppDbContext context = new AppDbContext())
            {
                sizes = context.Sizes.Include(s => s.Pizza).ToList();
            }
            return sizes;
        }
        public Size GetById(int id)
        {
            Size size;
            using (AppDbContext context = new AppDbContext())
            {
                size = context.Sizes.Include(s => s.Pizza).FirstOrDefault(p => p.Id == id);
            }
            if (size == null)
            {
                Console.WriteLine("There is no size for given id.");
                return null;
            }
            return size;

        }
        public void Remove(int id)
        {
            Size existed;
            using (AppDbContext context = new AppDbContext())
            {
                existed = context.Sizes.FirstOrDefault(p => p.Id == id);
                if (existed != null)
                {
                    context.Sizes.Remove(existed);
                    context.SaveChanges();
                    Console.WriteLine("Removed succesfully.");
                }
                else
                {
                    Console.WriteLine("Size not found.");
                }
            }
        }
        public void Update(Size size)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (size != null)
                {
                    context.Sizes.Update(size);
                    context.SaveChanges();
                    Console.WriteLine("Updated succesfully.");
                }
                else
                {
                    Console.WriteLine("Size not found.");
                }
            }
        }
    }
}
