using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);

            var monster = new Monster { Name = "Green Blob", Damage = 1, Hp = 2, MissRate = 80 };
            context.Monsters.Add(monster);

            //using (var ts = new TransactionScope())
            //{
            
            context.Players.Add(new Player { Name = "Foglol", Exp = 0, Hp = 20, MaxHp = 20 });
            context.SaveChanges();

            var player = context.Players.Where(player => player.Name == "Foglol").FirstOrDefault();

            var cell = new Cell { CanMoveTo = true, Description = "A beautiful forest", MonsterRate = 20, PosX = 0, PosY = 0, ItemRate = 60, PlayerId = (int)player.Id };
            var cell2 = new Cell { CanMoveTo = true, Description = "A Dangerous Magma Lake", MonsterRate = 80, PosX = 0, PosY = 1, ItemRate = 90, PlayerId = (int)player.Id };

            context.Cells.Add(cell);
            context.Entry<Cell>(cell).State = EntityState.Detached;

            context.Cells.Add(cell2);
            context.Entry<Cell>(cell2).State = EntityState.Detached;

            //player.Cells.Add(cell);
            //player.Cells.Add(cell2);

            context.SaveChanges();

            var playerAfterUpdate = context.Players.Where(player => player.Name == "Foglol").FirstOrDefault();


            //ts.Complete();
            //}



            Console.WriteLine("Hey bro it's ok !");
        }
    }
}
