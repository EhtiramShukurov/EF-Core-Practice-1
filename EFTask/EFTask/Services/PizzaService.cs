using EFTask.DAL;
using EFTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.Services
{
    internal class PizzaService
    {
        public void CreatePizza(string name)
        {
            Pizza pizza = new Pizza
            {
                Name = name
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Pizzas.Add(pizza);
                context.SaveChanges();
                Console.WriteLine("Succesfully added.");
            }
        }
        public List<Pizza> GetAll()
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (AppDbContext context = new AppDbContext())
            {
                pizzas = context.Pizzas.ToList();
            }
            return pizzas;
        }
        public  Pizza GetById(int id)
        {
            Pizza pizza;
            using (AppDbContext context = new AppDbContext())
            {
                pizza = context.Pizzas.FirstOrDefault(p => p.Id == id);
            }
            if (pizza == null)
            {
                Console.WriteLine("There is no pizza for given id.");
                return null;
            }
            return pizza;

        }
        public void Remove(int id)
        {
            Pizza existed;
            using (AppDbContext context = new AppDbContext())
            {
                existed = context.Pizzas.FirstOrDefault(p => p.Id == id);
                if (existed != null)
                {
                    context.Pizzas.Remove(existed);
                    context.SaveChanges();
                    Console.WriteLine("Removed succesfully.");
                }
                else
                {
                    Console.WriteLine("Pizza not found.");
                }
            }
        }
        public void Update(Pizza pizza)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (pizza != null)
                {
                    context.Pizzas.Update(pizza);
                    context.SaveChanges();
                    Console.WriteLine("Updated succesfully.");
                }
                else
                {
                    Console.WriteLine("Pizza not found.");
                }
            }
        }
    }
}
