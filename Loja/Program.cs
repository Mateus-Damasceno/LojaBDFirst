using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LojaEntities()) 
            {
                var cliente1 = new cliente()
                {
                    nome = "golum",
                    email = "smeagle@golum.com"
                };
                db.clientes.Add(cliente1);
                db.SaveChanges();

                var cliente2 = new cliente()
                {
                    nome = "radagaste",
                    email = "radagaste@lotr.com"
                };
                db.clientes.Add(cliente2);
                db.SaveChanges();

                var cliente3 = new cliente()
                {
                    nome = "jorga  ",
                    email = "smeagle@golum.com"
                };
                db.clientes.Add(cliente3);
                db.SaveChanges();

                cliente1.pedidoes.Add(new pedido
                {
                    item = "precioso",
                    preco = 1000
                });

                cliente2.pedidoes.Add(new pedido
                {
                    item = "laraka",
                    preco = 3000
                });

                cliente3.pedidoes.Add(new pedido
                {
                    item = "dois",
                    preco = 500
                });

                db.SaveChanges();

                //LINQ

                var query = from c in db.clientes.Include("pedidoes")
                            select c;

                foreach (var cliente in query)
                {
                    Console.WriteLine($"Cliente: {cliente.nome} ");
                    Console.WriteLine("PEDIDOS: ");
                    Console.WriteLine("====");
                    foreach(var p in cliente.pedidoes)
                    {
                        Console.Write($"Item : {p.item}, Preço: {p.preco} ");
                    }

                }

                Console.WriteLine();
            }
        }
    }
}
