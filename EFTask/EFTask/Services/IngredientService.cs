using EFTask.DAL;
using EFTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.Services
{
    internal class IngredientService
    {
        public void CreateIngredient(string name,int pizzaId)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = name,
                PizzaId = pizzaId
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
                Console.WriteLine("Succesfully added.");
            }
        }
        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (AppDbContext context = new AppDbContext())
            {
                ingredients = context.Ingredients.Include(i => i.Pizza).ToList();
            }
            return ingredients;
        }
        public Ingredient GetById(int id)
        {
            Ingredient ingredient;
            using (AppDbContext context = new AppDbContext())
            {
                ingredient = context.Ingredients.Include(i=>i.Pizza).FirstOrDefault(p => p.Id == id);
            }
            if (ingredient == null)
            {
                Console.WriteLine("There is no ingredient for given id.");
                return null;
            }
            return ingredient;

        }
        public void Remove(int id)
        {
            Ingredient existed;
            using (AppDbContext context = new AppDbContext())
            {
                existed = context.Ingredients.FirstOrDefault(p => p.Id == id);
                if (existed != null)
                {
                    context.Ingredients.Remove(existed);
                    context.SaveChanges();
                    Console.WriteLine("Removed succesfully.");
                }
                else
                {
                    Console.WriteLine("Ingredient not found.");
                }
            }
        }
        public void Update(Ingredient ingredient)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (ingredient != null)
                {
                    context.Ingredients.Update(ingredient);
                    context.SaveChanges();
                    Console.WriteLine("Updated succesfully.");
                }
                else
                {
                    Console.WriteLine("Ingredient not found.");
                }
            }
        }
    }
}
