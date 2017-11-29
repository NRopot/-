using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        public static void Initialize(Construction_companyContext context)
        {
            context.Database.EnsureCreated();

            // Проверка занесены ли данные
            if (context.Brigade.Any())
            {
                return;   // База данных инициализирована
            }

            context.AddRange(
                new Brigade()
                {
                    NameBrigade = "Электрики",
                    FioBrigadier = "Казаченко",
                    CompositionWorker = "Ропот, Борисенко, Щербаков, Гуща",
                    JobId = 5

                },
                new Brigade()
                {
                    NameBrigade = "Строители",
                    FioBrigadier = "Грибоедов",
                    CompositionWorker = "Донцевич, Петросян, Капранов, Лукъянов",
                    JobId = 6

        },
                new Brigade()
                {
                    NameBrigade = "Уборщики",
                    FioBrigadier = "Гагарин",
                    CompositionWorker = "Ленин, Горбатко, Бешта, Лионов",
                    JobId = 7

                }

            );
            context.SaveChanges();
        }
    }
}
