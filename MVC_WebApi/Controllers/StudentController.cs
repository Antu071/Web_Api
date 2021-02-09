using MVC_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_WebApi.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<mvc_Student_Model> stdList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("values").Result;
            stdList = response.Content.ReadAsAsync<IEnumerable<mvc_Student_Model>>().Result;
            return View(stdList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id==0)
                return View(new mvc_Student_Model());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Students/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvc_Student_Model>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvc_Student_Model std)
        {
            if(std.Id==0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Students", std).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Students/"+std.
                    Id, std).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            
            return RedirectToAction("Index");
           
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Students/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }


}