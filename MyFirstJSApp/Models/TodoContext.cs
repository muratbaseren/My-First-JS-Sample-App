using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstJSApp.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }

    public class MyInitializer : CreateDatabaseIfNotExists<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            context.TodoItems.Add(new TodoItem() { Text = "ASP.NET MVC kitabı okunacak." });
            context.TodoItems.Add(new TodoItem() { Text = "ASP.NET MVC de JS ile Proje Örneği yapılacak." });

            context.SaveChanges();
        }
    }

}