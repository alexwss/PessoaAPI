using System;
using System.Threading;
using PessoaAPI.Repository;

namespace PessoaAPI.service.impl
{
    public class AnotherService : IAnotherService
    {

        private bool meuControle = false;

        Repository.Repository.BloggingContext _context;
        public AnotherService(Repository.Repository.BloggingContext context)
        {
            _context = context;
        }

        public void callMe()
        {

            if (meuControle == false)
            {

                meuControle = true;

                Thread.Sleep(20000);
                var blog = new Repository.Repository.Blog();

                blog.id = 1;
                blog.description = "description";

                var post = new Repository.Repository.Post();

                post.BlogId = 1;
                post.Content = "CONTEUDO";
                post.PostId = 1;
                post.Title = "titulo";

                _context.Blogs.Add(blog);
                //_context.Posts.Add(post);
                _context.SaveChanges();
                meuControle = false;
            }
            else
            {
                Console.WriteLine("test");
                return;
            }

        }

    }
}