using System.Threading;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PessoaAPI.service.impl
{
    public class MyFirstService : IMyFirstService
    {

        IAnotherService _anotherService;

        public MyFirstService(IAnotherService anotherService)
        {
            _anotherService = anotherService;
        }

        public async void myFirstMethod()
        {

            Console.WriteLine("Testing");
            //Task.Run(() => _anotherService.callMe());

            Thread thread = new Thread(delegate ()
            {
                var options = new DbContextOptionsBuilder<Repository.Repository.BloggingContext>();
                options.UseSqlite("Data Source=caraii_borracha.db");

                using (var db = new Repository.Repository.BloggingContext(options.Options ))
                {
                    AnotherService another = new AnotherService(db);
                    another.callMe();
                }

            });

            thread.Start();
            thread.Join();

            Console.WriteLine("Terminou o trem");

        }
    }
}