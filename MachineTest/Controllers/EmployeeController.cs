using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using System.Data.Entity;
using MachineTest.Models;

namespace MachineTest.Controllers
{
    public class EmployeeController : Controller
    {
        Model1 db=new Model1();
        
        public ActionResult Index()
        {
            var EmployeeList = this.db.Employees.ToList();  
            List<EmployeeDet> EmployeeDetails = new List<EmployeeDet>();
            foreach(var obj in EmployeeList)
            {
                EmployeeDetails.Add(new EmployeeDet
                {
                    Id = obj.id,
                    Name = obj.Name,
                    Department = obj.Department
                });
            }

            return View(EmployeeDetails);
        }
        #region Employee
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee EmpDetails = new Employee();
                    EmpDetails.Name = employee.Name;
                    EmpDetails.Department = employee.Department;
                    this.db.Employees.Add(EmpDetails);
                    this.db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        

        public ActionResult Details(int id)
        {
            EmployeeDet Details = new EmployeeDet();
            Employee empObj=db.Employees.Find(id);
            Details.Id = empObj.id;
            Details.Name = empObj.Name;
            Details.Department = empObj.Department;
            return View(Details);
        }
        public ActionResult Edit(int id)
        {
            EmployeeDet Details=new EmployeeDet();
            Employee empObj= db.Employees.Find(id);
            Details.Id = empObj.id;
            Details.Name = empObj.Name;
            Details.Department = empObj.Department;
            return View(Details);
        }
        [HttpPost]
        public ActionResult Edit(Employee Details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee empObj = new Employee();
                    empObj.id = Details.id;
                    empObj.Name = Details.Name;
                    empObj.Department = Details.Department;

                    this.db.Entry(empObj).State = EntityState.Modified;
                    this.db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(Details);
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }


        public ActionResult Delete(int id)
        {
            EmployeeDet Details = new EmployeeDet();
            Employee empObj = db.Employees.Find(id);
            Details.Id = empObj.id;
            Details.Name = empObj.Name;
            Details.Department = empObj.Department;
            return View(Details);
        }

        //[HttpDelete]
        [HttpPost]
        public ActionResult delete(int id)
        {
            try
            {
                Employee empObj = db.Employees.Find(id);
                db.Employees.Remove(empObj);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }


        #endregion

        
    }
}