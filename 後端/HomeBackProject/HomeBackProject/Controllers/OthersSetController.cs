using HomeBackProject.Models;
using HomeBackProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HomeBackProject.library;
using System.Data.Entity;
using System.Net;

namespace HomeBackProject.Controllers
{
    public class OthersSetController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();

        [LoginCkeck]
        [LoginCkeckRank]
        public ActionResult Index(string idNmae)
        {
            if (idNmae == "Rank")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    PeopleRankData = db.PeopleRankData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "會員身份設定";

                //int pagesize = 10;
                //var pagedList = vMOthersSet.PeopleRankData.OrderBy(m=>m.PeopleRank).ToPagedList(page, pagesize);
                return View(vMOthersSet);
            }

            else if (idNmae == "Program")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    ProgramData = db.ProgramData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "會員方案設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Home")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    HomeTypeData = db.HomeTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "房屋類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Territory")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    TerritoryTypeData = db.TerritoryTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "土地類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Car")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    CarTypeData = db.CarTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "車位類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Sale")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    SaleTypeData = db.SaleTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "銷售類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "AD")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    ADTypeData = db.ADTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "廣告設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "City")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    CityTypeData = db.CityTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "縣市設定";
                return View(vMOthersSet);
            }


            ViewBag.CheckView = "請在左側選擇要操作的系統";
            return View();
        }

        [LoginCkeck]
        [LoginCkeckRank]
        [HttpPost]
        public ActionResult Create(string idNmae, string toDBName)
        {
            if (idNmae == "Rank")
            {
                PeopleRankData peopleRankData = new PeopleRankData();
                peopleRankData.PeopleRank = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.PeopleRankData, peopleRankData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Program")
            {
                ProgramData programData = new ProgramData();
                programData.ProgramName = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.ProgramData, programData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Home")
            {
                HomeTypeData homeTypeData = new HomeTypeData();
                homeTypeData.HomeTypeName = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.HomeTypeData, homeTypeData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Territory")
            {
                TerritoryTypeData territoryTypeData = new TerritoryTypeData();
                territoryTypeData.TerritoryTypeSelect = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.TerritoryTypeData, territoryTypeData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Car")
            {
                CarTypeData carTypeData = new CarTypeData();
                carTypeData.CarTypeName = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.CarTypeData, carTypeData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Sale")
            {
                SaleTypeData saleTypeData = new SaleTypeData();
                saleTypeData.SaleState = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.SaleTypeData, saleTypeData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "AD")
            {
                ADTypeData aDTypeData = new ADTypeData();
                aDTypeData.ADName = toDBName;
                if (ModelState.IsValid)
                {
                    actiondbController.Create(db, db.ADTypeData, aDTypeData);
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }

            return View();
        }

        [LoginCkeck]
        [LoginCkeckRank]
        public ActionResult DeleteConfirmed(string idNmae, string id)
        {
            ADTypeData aDTypeData = db.ADTypeData.Find(Int16.Parse(id));
            actiondbController.DeleteConfirmed(db, db.ADTypeData, aDTypeData, id);

            return RedirectToAction("Index", new { idNmae = idNmae });
        }

        [LoginCkeck]
        [LoginCkeckRank]
        [HttpPost]
        public ActionResult Edit(string idNmae, string toDBNameEdit, string id)
        {

            if (idNmae == "Rank")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PeopleRankData peopleRankData = db.PeopleRankData.Find(Int16.Parse(id));
                if (peopleRankData == null)
                {
                    return HttpNotFound();
                }
                peopleRankData.PeopleRank = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(peopleRankData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Program")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProgramData programData = db.ProgramData.Find(Int16.Parse(id));
                if (programData == null)
                {
                    return HttpNotFound();
                }
                programData.ProgramName = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(programData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Home")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                HomeTypeData homeTypeData = db.HomeTypeData.Find(Int16.Parse(id));
                if (homeTypeData == null)
                {
                    return HttpNotFound();
                }
                homeTypeData.HomeTypeName = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(homeTypeData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Car")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CarTypeData carTypeData = db.CarTypeData.Find(Int16.Parse(id));
                if (carTypeData == null)
                {
                    return HttpNotFound();
                }
                carTypeData.CarTypeName = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(carTypeData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Territory")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TerritoryTypeData territoryTypeData = db.TerritoryTypeData.Find(Int16.Parse(id));
                if (territoryTypeData == null)
                {
                    return HttpNotFound();
                }
                territoryTypeData.TerritoryTypeSelect = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(territoryTypeData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "Sale")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SaleTypeData saleTypeData = db.SaleTypeData.Find(Int16.Parse(id));
                if (saleTypeData == null)
                {
                    return HttpNotFound();
                }
                saleTypeData.SaleState = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(saleTypeData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            else if (idNmae == "AD")
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ADTypeData aDTypeData = db.ADTypeData.Find(Int16.Parse(id));
                if (aDTypeData == null)
                {
                    return HttpNotFound();
                }
                aDTypeData.ADName = toDBNameEdit;
                if (ModelState.IsValid)
                {
                    db.Entry(aDTypeData).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { idNmae = idNmae });
                }
            }
            return View();
        }

    }
}