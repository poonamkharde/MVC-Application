using MVCLoginApplication.Models;
using MVCLoginApplication.pcClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLoginApplication.pcClassCopy;

namespace MVCLoginApplication.Controllers
{
    public class pcExamCenterListCopyController : Controller
    {
        // GET: pcExamCenterListCopy

        pcExamCenterListModel opcExamCenterListModel = new pcExamCenterListModel();

        public ActionResult Index()
        {
            int intRecFound = 0;
            List<SelectListItem> ddlDistrictList = new List<SelectListItem>();
            intRecFound=pcExamCenterListClass.pcFillDistrictList(ref ddlDistrictList);
            opcExamCenterListModel.ddlEditDistrict=ddlDistrictList;

            return View("pcExamCenterListCopyView",opcExamCenterListModel);
        }
        [HttpPost]
        public ActionResult pcBtnShow(pcExamCenterListModel opcExamCenterListModel)
        {
            opcExamCenterListModel.gvpcExamCenterList = pcExamCenterListClass.pcExamCenterListData(opcExamCenterListModel.txtSelectedDistrictValue, opcExamCenterListModel.txtFilterNm);
            return PartialView("pcExamCenterPartialView",opcExamCenterListModel);
        }

        //public ActionResult LoadPartial(bool hideDiv = false)
        //{
        //    ViewBag.HideDiv = hideDiv;
        //    return PartialView("pcExamCenterPartialView", opcExamCenterListModel);
        //}
    }
}