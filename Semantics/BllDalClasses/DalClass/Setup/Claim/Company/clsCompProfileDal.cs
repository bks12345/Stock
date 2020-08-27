using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllClass.Setup.Company;
using System.Data.SqlClient;
using System.Data;
using Stock.DalClass.Common;
using Stock.BllDalClasses.BllClass.Common;

namespace Stock.DalClass.Setup.Company
{
    public class clsCompProfileDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdateCompProfile(clsCompProfileBll objCompProfile)
        {
            SqlParameter[] sqlparam = new SqlParameter[23];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objCompProfile.ID);
            sqlparam[1] = new SqlParameter("@FontFamily", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objCompProfile.FontFamily);
            sqlparam[2] = new SqlParameter("@CompanyNameEng", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objCompProfile.CompanyNameEng);
            sqlparam[3] = new SqlParameter("@CompanyNameNep", SqlDbType.NVarChar);
            sqlparam[3].Value = NullHandler.String(objCompProfile.CompanyNameNep);
            sqlparam[4] = new SqlParameter("@AddressEng", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objCompProfile.AddressEng);
            sqlparam[5] = new SqlParameter("@AddressNep", SqlDbType.NVarChar);
            sqlparam[5].Value = NullHandler.String(objCompProfile.AddressNep);
            sqlparam[6] = new SqlParameter("@VatReg", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(objCompProfile.VatReg);
            sqlparam[7] = new SqlParameter("@Phone1", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(objCompProfile.Phone1);
            sqlparam[8] = new SqlParameter("@Phone2", SqlDbType.VarChar);
            sqlparam[8].Value = NullHandler.String(objCompProfile.Phone2);
            sqlparam[9] = new SqlParameter("@Website", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(objCompProfile.Website);
            sqlparam[10] = new SqlParameter("@Fax", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(objCompProfile.Fax);
            sqlparam[11] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String(objCompProfile.Email);
            sqlparam[12] = new SqlParameter("@Image", SqlDbType.Image, 0);
            sqlparam[12].Value = objCompProfile.Image;
            sqlparam[13] = new SqlParameter("ImgPath", SqlDbType.VarChar);
            sqlparam[13].Value = NullHandler.String(objCompProfile.ImgPath);
            sqlparam[14] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[14].Direction = ParameterDirection.Output;
            sqlparam[15] = new SqlParameter("@SystemType", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(objCompProfile.SystemType);
            sqlparam[16] = new SqlParameter("@en_suminsured", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(objCompProfile.En_SumInsured);
            sqlparam[17] = new SqlParameter("@BankDeposit_Opt", SqlDbType.TinyInt);
            sqlparam[17].Value = NullHandler.Int16(objCompProfile.BankDeposit_Option);
            sqlparam[18] = new SqlParameter("@VatGen_Opt", SqlDbType.TinyInt);
            sqlparam[18].Value = NullHandler.Int16(objCompProfile.VatGen_Option);
            sqlparam[19] = new SqlParameter("@CompanyPrefix", SqlDbType.VarChar);
            sqlparam[19].Value = NullHandler.String(objCompProfile.CompanyPrefix);
            sqlparam[20] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[20].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[21] = new SqlParameter("@uuid", SqlDbType.VarChar);
            sqlparam[21].Value = NullHandler.String(ClsCommon.UserCode);
            sqlparam[22] = new SqlParameter("@CompanyRegNo", SqlDbType.VarChar);
            sqlparam[22].Value = NullHandler.String(objCompProfile.CompanyRegNo);
            objCmnDal.InsertUpdateTable("company_CompProfile_insertUpdate", "sp", sqlparam);
            if (sqlparam[14].Value != DBNull.Value)
                return sqlparam[14].Value.ToString();
            else
                return null;
            
        }

        public DataTable GetCompanyProfile(clsCompProfileBll objCompProfile)
        {
            return objCmnDal.GetTable("company_CompProfile_get", "sp", null);
        }

    }

   
}