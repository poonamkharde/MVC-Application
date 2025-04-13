using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MVCLoginApplication.Models;
using MVCLoginApplication.pcClass;

namespace MVCLoginApplication.Controllers
{
    public class pcExamCenterListController : Controller
    {
        // GET: pcExamCenterList

        pcExamCenterListModel opcExamCenterListModel=new pcExamCenterListModel();

        public ActionResult Index()
        {
            int intRecFound = 0;
            List<SelectListItem> ddlDistrictList = new List<SelectListItem>();
            intRecFound = pcClsExamCenter.pcFillddlDistrict(ref ddlDistrictList);

            opcExamCenterListModel.ddlEditDistrict = ddlDistrictList;
            
            return View("pcExamCenterListView",opcExamCenterListModel);
        }
    }
}