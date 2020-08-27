using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.User
{
    public class clsDebitNoteBll
    {
        #region tbldefusersettings
        public int ID { get; set; }
        public int USERID { get; set; }
        public byte[] usersignature { get; set; }
        public byte[] companyseal { get; set; }
        public string ccEmail { get; set; }
        public int isSenderEmail { get; set; }
        public string SIGNATUREURL { get; set; }
        public string COMPANYSEALURL { get; set; }
        public int ISDELETED { get; set; }
        #endregion tbldefusersettings
        clsDebitNoteDal objDebitNote = new clsDebitNoteDal();
        public string InsertUpdatetbldefusersettings()
        {
            return objDebitNote.InsertUpdatetbldefusersettings(this);
        }
        public DataTable getUserSettings()
        {
            return objDebitNote.getUserSettings(this);
        }
    }
}