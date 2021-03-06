﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication11.Controllers
{
    public class AdminController : Controller
    {
        designtEntities dt = new WebApplication11.designtEntities();
        public AdminController()
        {
            //dt = new WebApplication11.designtEntities();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSer()
        {
            return View();
        }


        public ActionResult AddCat()
        {
            return View();
        }
        public ActionResult UpdateSer(string sid)
        {

            int id = Convert.ToInt32(sid);
            sertbl st = dt.sertbls.Find(id);
            return View(st);
        }


        public ActionResult ViewSer()
        {

            return View(dt.sertbls.ToList());
        }

        public ActionResult submitSer(sertbl ser, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/images"),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ser.SerImg = "/images/" + file.FileName;
                    dt.sertbls.Add(ser);
                    dt.SaveChanges();


                    ViewBag.Message = "File uploaded successfully";


                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("AddSer");
        }


        public ActionResult submitUpdate(sertbl ser, HttpPostedFileBase file)
        {
      

            designtEntities d = new designtEntities();
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/images"),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ser.SerImg = "/images/" + file.FileName;
                    dt.Entry(ser).State = EntityState.Modified;
                    dt.SaveChanges();



                    ViewBag.Message = "File uploaded successfully";


                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();

                }
            else
            {

                dt.Entry(ser).State = EntityState.Modified;
                dt.SaveChanges();
                ViewBag.Message = "File uploaded successfully";

            }
            return RedirectToAction("ViewSer");
        }


        public ActionResult AddPro()
        {

            ViewBag.ListOfCategories = dt.cattbls.ToList(); ;
            return View();
        }

        public ActionResult submitPro(protbl pro, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/images"),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    pro.ProImg = "/images/" + file.FileName;
                    dt.protbls.Add(pro);
                    dt.SaveChanges();


                    ViewBag.Message = "File uploaded successfully";


                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("AddPro");
        }
        public ActionResult submitcat(cattbl cat)
        {
            dt.cattbls.Add(cat);
            dt.SaveChanges();
            return RedirectToAction("AddCat");
        }


        public ActionResult ViewPro()
        {

            return View(dt.protbls.ToList());
        }

        public ActionResult Updatepro(int id)
        {

           // int id = Convert.ToInt32(sid);
            protbl pt = dt.protbls.Find(id);
            return View(pt);
        }

        public ActionResult submitUpdatePro(protbl pro, HttpPostedFileBase file)
        {

            designtEntities d = new designtEntities();
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/images"),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    pro.ProImg = "/images/" + file.FileName;
                    dt.protbls.Attach(pro);
                    dt.Entry(pro).State = EntityState.Modified;
                    dt.SaveChanges();



                    ViewBag.Message = "File uploaded successfully";


                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();

                }
            else
            {

                dt.protbls.Attach(pro);
                dt.Entry(pro).State = EntityState.Modified;
                dt.SaveChanges();
                ViewBag.Message = "File uploaded successfully";

            }
            return RedirectToAction("ViewSer");
        }


        public ActionResult AddHome(int id)
        {

            // int id = Convert.ToInt32(sid);
            protbl pt = dt.protbls.Find(id);
            return View(pt);
        }
    }
}