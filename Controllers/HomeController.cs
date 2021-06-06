using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketSystem.Models;
using TicketSystem.Db.Operations;
using System.Threading;
using System.Globalization;
using System.Web.Helpers;
using System.Collections;
using System.Data;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        TicketRepository repo = null;
        public HomeController()
        {
            repo = new TicketRepository();  //initiate the repository which will be used to get all the data 
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View(repo.GetTickets());
        }

        //change language option, and add it to cookies
        public ActionResult ChangeLanguage(string LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageAbbrevation);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Search(string search = "")  //get list of tickets based on keyword
        {
            return View(repo.GetTickets(search));
        }

        public ActionResult SearchGroupByProject()
        {
            return View(repo.GetTicketsGroupByProject()); //get projects along with the number of its assoicate tickets
        }


        [HttpPost]
        public JsonResult NewChart()
        {
            int cap = 10, max = 0;
            List<object> iData = new List<object>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ProjectName", System.Type.GetType("System.String"));
            dt.Columns.Add("TicketCount", System.Type.GetType("System.Int32"));

            //gather data for the chart 
            foreach (var result in repo.GetTicketsGroupByProject())
            {
                DataRow dr = dt.NewRow();
                dr["ProjectName"] = result.ProjectName;
                dr["TicketCount"] = result.TicketCount;
                dt.Rows.Add(dr);

                max = (result.TicketCount > max) ? result.TicketCount : max;
            }

            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            //make sure the maximum number (of the chart) is always higher than the highest number 
            ViewBag.Cap = ((max / 10) + 1) * 10;

            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.departments = repo.GetDepartments();
            ViewBag.isComplete = false;

            return View();
        }

        [HttpPost]
        public ActionResult Create(TicketModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateTime = System.DateTime.Now;
                int id = repo.AddTicket(model);

                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.isComplete = true;
                }
            }
            else 
                ViewBag.isComplete = false; 

            ViewBag.departments = repo.GetDepartments();
            
            return View();
        }

        public JsonResult GetEmployeeListBasedOnDepartment(int Id)
        {
            var emp = repo.GetEmployees().Where(x => x.DepartmentId == Id);
            var list = emp.Select(m => new { value = m.EmployeeId, text = m.EmployeeName });
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}