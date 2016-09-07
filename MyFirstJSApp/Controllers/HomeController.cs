using MyFirstJSApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstJSApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult Index6()
        {
            TodoContext db = new TodoContext();

            return View(db.TodoItems.ToList());
        }

        [HttpPost]
        public ActionResult Index6(string task)
        {
            // { task : "" }
            TodoContext db = new TodoContext();
            TodoItem item = new TodoItem() { Text = task };
            db.TodoItems.Add(item);

            JsonResultObject result = new JsonResultObject();

            if (db.SaveChanges() > 0)
            {
                // save başarılı ise savechanges 1 döner.(insert edilen kayıt sayısı)
                result.NewTaskId = item.Id;
            }
            else
            {
                result.HasError = true;
            }

            return Json(result); // { HasError:false, NewTaskId=1 }
        }

        [HttpPost]
        public ActionResult DelTodoItem(int task_id)
        {
            TodoContext db = new TodoContext();
            TodoItem item = db.TodoItems.Find(task_id);
            db.TodoItems.Remove(item);

            JsonResultObject result = new JsonResultObject();

            if (db.SaveChanges() > 0)
            {

            }
            else
            {
                result.HasError = true;
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult EditTodoItem(int task_id, string new_text)
        {
            TodoContext db = new TodoContext();
            TodoItem item = db.TodoItems.Find(task_id);

            item.Text = new_text;

            JsonResultObject result = new JsonResultObject();

            if (db.SaveChanges() > 0)
            {

            }
            else
            {
                result.HasError = true;
            }

            return Json(result);
        }
    }
}