using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using _3_CRUD.Models;


namespace _3_CRUD.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    DepartmentDBHelper db = new DepartmentDBHelper();
        //    return View(db.GetDepartments().ToList());
        //}

        [HttpGet]
        public ViewResult Index()
        {
            DepartmentDBHelper db = new DepartmentDBHelper();
            return View(db.GetDepartments().ToString());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name, string Location)
        {
            try
            {
                Department d = new Department()
                {
                    Name = Name,
                    Location = Location
                };

                DepartmentDBHelper db = new DepartmentDBHelper();
                db.InsertDepartment(d); 
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

       // [HttpGet]
       [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int? id)
        {
            DepartmentDBHelper db = new DepartmentDBHelper();
            Department dept = db.GetDepartments().FirstOrDefault(d => d.Id == id);

            return View(dept);
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]  
        public ActionResult Edit()
        {

            if (ModelState.IsValid)
            {


                Department d = new Department();

                TryUpdateModel<Department>(d);
                try
                {

                    DepartmentDBHelper db = new DepartmentDBHelper();
                    db.UpdateDepartment(d);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    
        [HttpGet]
        public ActionResult Details(int ?id)
        {
            DepartmentDBHelper db = new DepartmentDBHelper();
            Department dept = db.GetDepartments().FirstOrDefault(d => d.Id == id);
            return View(dept);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int? id)
        {
            DepartmentDBHelper db = new DepartmentDBHelper();
            Department dept = db.GetDepartments().FirstOrDefault(d => d.Id == id);
            return View(dept);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int? id)
        {
            try
            {
                 
                DepartmentDBHelper db = new DepartmentDBHelper();
                db.DeleteDepartment(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
         
        [NonAction]
        public ActionResult Sample1()
        {
            return View();
        }
        public ActionResult Sample2() 
        {
            return View();
        }

        public PartialViewResult PartialActionMethod(int ? id)
        {
            return PartialView("_PartialView");
        }
        //public ActionResult PartialActionMethod(int? id)
        //{
        //    return PartialView("_PartialView");
        //}

        [HttpGet]
        [ActionName("Login")]
        public ActionResult LoginGet()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost()
        {
            return View();

        }

        //public HttpUnauthorizedResult Index11()
        //{

        //}
        //public  EmptyResult Indexxx()
        //{

        //}



    }
}
    