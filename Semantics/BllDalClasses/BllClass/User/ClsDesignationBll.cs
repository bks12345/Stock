using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsDesignationBll
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public string AUID { get; set; }
        public string UUID { get; set; }
        public DateTime ADT { get; set; }
        public DateTime UDT { get; set; }

        public string InsertUpdateDesignation()
        {
            ClsDesignationDal objdal = new ClsDesignationDal();
            return objdal.InsertUpdateDesignation(this);
        }

        public DataTable getdesignation()
        {
             ClsDesignationDal objdal = new ClsDesignationDal();           
             return objdal.getdesignation(this);
        }

        public int delete_designation()
        {
            ClsDesignationDal objdal = new ClsDesignationDal();
            return objdal.delete_designation(this);
        }
    }
}