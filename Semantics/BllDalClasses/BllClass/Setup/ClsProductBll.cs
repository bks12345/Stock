using Stock.BllDalClasses.DalClass.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Setup
{
    public class ClsProductBll
    {
        #region TMCLAIMSURVEYORTYPE
        public int SURVEYORID { get; set; }
        public int SURVTYPECODE { get; set; }
        public string EDESCRIPTION { get; set; }
        public string NDESCRIPTION { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int islock { get; set; }
        #endregion

        ClsProductDal obj = new ClsProductDal();

        public string InsertUpdateSurveyorType()
        {
            return obj.InsertUpdateSurveyorType(this);
        }
        public DataTable GetSurveyorType()
        {
            return obj.GetSurveyorType(this);
        }
        public string InsertUpdateSurveyrType()
        {
            return obj.InsertUpdateSurveyrType(this);
        }
        public DataTable GetSurveyrType()
        {
            return obj.GetSurveyrType(this);
        }
    }
}