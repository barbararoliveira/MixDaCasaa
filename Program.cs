using System;
using mixdacasaa.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MixDaCasa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new hamburgueriaContext())
            {
                Console.WriteLine("Hamburgueres que levam o ingrediente 'Burguer Mix da Casa'");
                var nome = db.BurguerIngrediente

                    .Include(b => b.Burguer)
                    .Include(b => b.Ingrediente)
                    .Where(b => b.Ingrediente.Nome == "Burguer Mix da Casa")
                    .OrderBy(b => b.Burguer.Preco)
                    .ThenBy(b => b.Burguer.Nome);
                
                foreach (var burguer in nome)
                {
                    Console.WriteLine($"-> Hamburguer {burguer.Burguer.Nome} que custa {burguer.Burguer.Preco:C}");
                }
            }
        }
    }
}