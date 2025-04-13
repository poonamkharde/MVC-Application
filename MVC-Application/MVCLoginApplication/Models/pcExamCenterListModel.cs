using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLoginApplication.Models
{
    public class pcExamCenterListModel
    {
        public string txtExamFilter { get; set; }

        public string txtFilterNm { get; set; }

        public List<SelectListItem> ddlEditDistrict { get; set; }

        public string txtSelectedDistrictValue { get; set; }
        public IEnumerable<pcExamCenterList> gvpcExamCenterList { get; set; }

    }
        public class pcExamCenterList
        {
            public string txtCenterCode { get; set; }

            public string txtCenterName { get; set; }
            public string txtCenterAddress {  get; set; }
            public string txtTelephoneNo { get; set; }
    }
}