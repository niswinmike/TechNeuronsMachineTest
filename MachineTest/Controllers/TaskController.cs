using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using System.Data.Entity;
using MachineTest.Models;
using System.Data.Entity.Validation;

namespace MachineTest.Controllers
{
    public class TaskController : Controller
    {
        Model1 db = new Model1();
        // GET: Task
        #region Tasks

        public ActionResult IndexTask()
        {
            var Tasksheets = db.Tasks.ToList();
            List<TaskDet> tasks = new List<TaskDet>();
            foreach (var task in Tasksheets)
            {
                tasks.Add(new TaskDet
                {
                    Id = task.Id,
                    TaskName = task.Taskname,
                    Description = task.Description
                });
            }
            return View(tasks);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaskDet tDeatails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Task objTask = new Task();
                    objTask.Id = tDeatails.Id;
                    objTask.Taskname = tDeatails.TaskName;
                    objTask.Description = tDeatails.Description;

                    db.Tasks.Add(objTask);
                    db.SaveChanges();

                    return RedirectToAction("IndexTask");
                }
                return View(tDeatails);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }


        public ActionResult Details(int id)
        {
            TaskDet taskDetails = new TaskDet();
            Task objTask = db.Tasks.Find(id);
            taskDetails.Id = objTask.Id;
            taskDetails.TaskName = objTask.Taskname;
            taskDetails.Description = objTask.Description;

            return View(taskDetails);

        }

        public ActionResult Edit(int id)
        {
            TaskDet taskDetails = new TaskDet();
            Task objTask = db.Tasks.Find(id);
            taskDetails.Id = objTask.Id;
            taskDetails.TaskName = objTask.Taskname;
            taskDetails.Description = objTask.Description;

            return View(taskDetails);
        }
        [HttpPost]
        public ActionResult Edit(Task objTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Task details = new Task();
                    details.Id = objTask.Id;
                    details.Taskname = objTask.Taskname;
                    details.Description = objTask.Description;

                    db.Entry(details).State=EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("IndexTask");
                }
                return View(objTask);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult Delete(int id)
        {
            TaskDet taskDetails = new TaskDet();
            Task objTask = db.Tasks.Find(id);
            taskDetails.Id = objTask.Id;
            taskDetails.TaskName = objTask.Taskname;
            taskDetails.Description = objTask.Description;

            return View(taskDetails);
        }
        [HttpPost]
        public ActionResult delete(int id)
        {
            try
            {
                Task objTask = db.Tasks.Find(id);
                db.Tasks.Remove(objTask);
                db.SaveChanges();

                return RedirectToAction("IndexTask");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }


        #endregion
    }
}