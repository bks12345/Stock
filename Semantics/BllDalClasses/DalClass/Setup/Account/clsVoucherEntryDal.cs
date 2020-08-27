using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class clsVoucherEntryDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string GET_VOUCHERID(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@DOCID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.DOCID);
            sqlparam[1] = new SqlParameter("@TTYPE", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.TTYPE);
            sqlparam[2] = new SqlParameter("@MSG", SqlDbType.VarChar, 20);
            sqlparam[2].Direction = ParameterDirection.Output;
            sqlparam[3] = new SqlParameter("@CLAIMID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.CLAIMID);
            sqlparam[4] = new SqlParameter("@advanceid", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.advanceid);
            sqlparam[5] = new SqlParameter("@claimsurvid", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.claimsurvid);
            sqlparam[6] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.branchid);
            string _errMsg = "";
            objCmnDal.InsertUpdateTable("ACC_GET_MASTERID_BY_DOCID", "sp", sqlparam, ref _errMsg);
            if (sqlparam[2].Value != DBNull.Value)
            {
                return sqlparam[2].Value.ToString();
            }
            else
                return null;
        }

        public string GET_CommGenId(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@CommGenID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CommGenId);
            sqlparam[1] = new SqlParameter("@MSG", SqlDbType.VarChar, 20);
            sqlparam[1].Direction = ParameterDirection.Output;
            string _errMsg = "";
            objCmnDal.InsertUpdateTable("ACC_GET_MASTERID_BY_Commgenid", "sp", sqlparam, ref _errMsg);
            if (sqlparam[1].Value != DBNull.Value)
            {
                return sqlparam[1].Value.ToString();
            }
            else
                return null;
        }
        public string CheckforVoucherEntry(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.branchid);
            sqlparam[1] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.SUBBRANCHID);
            sqlparam[2] = new SqlParameter("@fiscalid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.FiscalID);
            sqlparam[3] = new SqlParameter("@vouchertypeid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.vouchertypeid);
            sqlparam[4] = new SqlParameter("@vdate", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(obj.vdate);
            sqlparam[5] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[5].Direction = ParameterDirection.Output;
            objCmnDal.InsertUpdateTable("checkfor_voucherentry", "sp", sqlparam);
            if (sqlparam[5].Value != DBNull.Value)
                return sqlparam[5].Value.ToString();
            else
                return null;
        }
        public string InsertUpdate_VoucherEntry(clsVoucherEntryBll obj, ref int prmMasterID)
        {
            SqlParameter[] sqlparam = new SqlParameter[59];
            sqlparam[0] = new SqlParameter("@TRANID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.TRANID);
            sqlparam[1] = new SqlParameter("@DOCID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.DOCID);
            sqlparam[2] = new SqlParameter("@CLAIMID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.CLAIMID);
            sqlparam[3] = new SqlParameter("@RECEIPTNO", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.RECEIPTNO);
            sqlparam[4] = new SqlParameter("@BANKID", SqlDbType.Decimal);
            sqlparam[4].Value = NullHandler.Decimal(obj.BANKID);
            sqlparam[5] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.FiscalID);
            sqlparam[6] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.branchid);
            sqlparam[7] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.VOUCHERNO);
            sqlparam[8] = new SqlParameter("@EDATE", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(obj.EDATE);
            sqlparam[9] = new SqlParameter("@TRANSMITI", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(obj.TRANSMITI);
            sqlparam[10] = new SqlParameter("@ACCOUNTCODE", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(obj.ACCOUNTCODE);
            sqlparam[11] = new SqlParameter("@DRAMOUNT", SqlDbType.Decimal);
            sqlparam[11].Value = NullHandler.Decimal(obj.DRAMOUNT);
            sqlparam[12] = new SqlParameter("@CRAMOUNT", SqlDbType.Decimal);
            sqlparam[12].Value = NullHandler.Decimal(obj.CRAMOUNT);
            sqlparam[13] = new SqlParameter("@IFPREVBALANCE", SqlDbType.Decimal);
            sqlparam[13].Value = NullHandler.Decimal(obj.IFPREVBALANCE);
            sqlparam[14] = new SqlParameter("@OFDATE", SqlDbType.DateTime);
            sqlparam[14].Value = NullHandler.DateTime(obj.OFDATE);
            sqlparam[15] = new SqlParameter("@TTYPE", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(obj.TTYPE);
            sqlparam[16] = new SqlParameter("@ENTRYNO", SqlDbType.Decimal);
            sqlparam[16].Value = NullHandler.Decimal(obj.ENTRYNO);
            sqlparam[17] = new SqlParameter("@AGENTCODE", SqlDbType.VarChar);
            sqlparam[17].Value = NullHandler.String(obj.AGENTCODE);
            sqlparam[18] = new SqlParameter("@APPROVED", SqlDbType.Decimal);
            sqlparam[18].Value = NullHandler.Decimal(obj.APPROVED);
            sqlparam[19] = new SqlParameter("@CHQNO", SqlDbType.VarChar);
            sqlparam[19].Value = NullHandler.String(obj.CHQNO);
            sqlparam[20] = new SqlParameter("@CLAIMPAYID", SqlDbType.Decimal);
            sqlparam[20].Value = NullHandler.Decimal(obj.CLAIMPAYID);
            sqlparam[21] = new SqlParameter("@CLAIMTYPE", SqlDbType.Decimal);
            sqlparam[21].Value = NullHandler.Decimal(obj.CLAIMTYPE);
            sqlparam[22] = new SqlParameter("@CLIENTCODE", SqlDbType.VarChar);
            sqlparam[22].Value = NullHandler.String(obj.CLIENTCODE);
            sqlparam[23] = new SqlParameter("@DECLARATIONNO", SqlDbType.VarChar);
            sqlparam[23].Value = NullHandler.String(obj.DECLARATIONNO);
            sqlparam[24] = new SqlParameter("@DEPOSITID", SqlDbType.Decimal);
            sqlparam[24].Value = NullHandler.Decimal(obj.DEPOSITID);
            sqlparam[25] = new SqlParameter("@DESCRIPTION", SqlDbType.VarChar);
            sqlparam[25].Value = NullHandler.String(obj.DESCRIPTION);
            sqlparam[26] = new SqlParameter("@FACID", SqlDbType.Decimal);
            sqlparam[26].Value = NullHandler.Decimal(obj.FACID);
            sqlparam[27] = new SqlParameter("@FCAMOUNT", SqlDbType.Decimal);
            sqlparam[27].Value = NullHandler.Decimal(obj.FCAMOUNT);
            sqlparam[28] = new SqlParameter("@ISSUEDTO", SqlDbType.VarChar);
            sqlparam[28].Value = NullHandler.String(obj.ISSUEDTO);
            sqlparam[29] = new SqlParameter("@MANUALVN", SqlDbType.VarChar);
            sqlparam[29].Value = NullHandler.String(obj.MANUALVN);
            sqlparam[30] = new SqlParameter("@PNARRATION", SqlDbType.VarChar);
            sqlparam[30].Value = NullHandler.String(obj.PNARRATION);
            sqlparam[31] = new SqlParameter("@RELATEDTO", SqlDbType.Decimal);
            sqlparam[31].Value = NullHandler.Decimal(obj.RELATEDTO);
            sqlparam[32] = new SqlParameter("@REMARKS", SqlDbType.VarChar);
            sqlparam[32].Value = NullHandler.String(obj.REMARKS);
            sqlparam[33] = new SqlParameter("@RIID", SqlDbType.Decimal);
            sqlparam[33].Value = NullHandler.Decimal(obj.RIID);
            sqlparam[34] = new SqlParameter("@RIPOOLID", SqlDbType.Decimal);
            sqlparam[34].Value = NullHandler.Decimal(obj.RIPOOLID);
            sqlparam[35] = new SqlParameter("@CHQDATE", SqlDbType.VarChar);
            sqlparam[35].Value = NullHandler.String(obj.CHQDATE);
            sqlparam[36] = new SqlParameter("@ISMANUAL", SqlDbType.Decimal);
            sqlparam[36].Value = NullHandler.Decimal(obj.ISMANUAL);
            sqlparam[37] = new SqlParameter("@PD_ID", SqlDbType.Decimal);
            sqlparam[37].Value = NullHandler.Decimal(obj.PD_ID);
            sqlparam[38] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[38].Value = NullHandler.String(obj.AUID);
            sqlparam[39] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[39].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[40] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[40].Value = NullHandler.String(obj.UUID);
            sqlparam[41] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[41].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[42] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[42].Direction = ParameterDirection.Output;
            sqlparam[43] = new SqlParameter("@Master_id", SqlDbType.Int);
            sqlparam[43].Direction = ParameterDirection.Output;
            sqlparam[44] = new SqlParameter("@VOUCHERTYPE", SqlDbType.Structured);
            sqlparam[44].Value = obj.VOUCHERTYPE;
            sqlparam[45] = new SqlParameter("@TRANSACTIONTYPEID", SqlDbType.Int);
            sqlparam[45].Value = NullHandler.Int32(obj.TRANSACTIONTYPEID);
            sqlparam[46] = new SqlParameter("@vendorid", SqlDbType.Int);
            sqlparam[46].Value = NullHandler.Int32(obj.vendorid);
            sqlparam[47] = new SqlParameter("@billno", SqlDbType.VarChar);
            sqlparam[47].Value = NullHandler.String(obj.billno);
            sqlparam[48] = new SqlParameter("@pAmount", SqlDbType.Decimal);
            sqlparam[48].Value = NullHandler.Decimal(obj.pAmount);
            sqlparam[49] = new SqlParameter("@pdiscAmt", SqlDbType.Decimal);
            sqlparam[49].Value = NullHandler.Decimal(obj.pdiscAmt);
            sqlparam[50] = new SqlParameter("@pVatAmt", SqlDbType.Decimal);
            sqlparam[50].Value = NullHandler.Decimal(obj.pVatAmt);
            sqlparam[51] = new SqlParameter("@pNetAmt", SqlDbType.Decimal);
            sqlparam[51].Value = NullHandler.Decimal(obj.pNetAmt);
            sqlparam[52] = new SqlParameter("@IsDeleted", SqlDbType.Int);
            sqlparam[52].Value = NullHandler.Int32(obj.IsDeleted);
            sqlparam[53] = new SqlParameter("@vatoptionid", SqlDbType.Int);
            sqlparam[53].Value = NullHandler.Int32(obj.vatoptionid);
            sqlparam[54] = new SqlParameter("@pTypeid", SqlDbType.Int);
            sqlparam[54].Value = NullHandler.Int32(obj.ptypeid);
            sqlparam[55] = new SqlParameter("@SIGNATURECODE1", SqlDbType.VarChar);
            sqlparam[55].Value = NullHandler.String(obj.SIGNATURE1_CODE);
            sqlparam[56] = new SqlParameter("@SIGNATURECODE2", SqlDbType.VarChar);
            sqlparam[56].Value = NullHandler.String(obj.SIGNATURE2_CODE);
            sqlparam[57] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[57].Value = NullHandler.Int32(obj.SUBBRANCHID);
            sqlparam[58] = new SqlParameter("@AMTINWORDS", SqlDbType.VarChar);
            sqlparam[58].Value = NullHandler.String(obj.AmountinWords);
            string _errMsg = "";
            prmMasterID = 0;
            objCmnDal.InsertUpdateTable("acc_InsertUpdate_VoucherEntry", "sp", sqlparam, ref _errMsg);
            if (sqlparam[42].Value != DBNull.Value)
                if (_errMsg.Length > 2)
                {
                    return _errMsg;
                }
                else
                {
                    //if (sqlparam[42].Value.ToString() == "INSERT")
                    //{
                        prmMasterID = ClsConvertTo.Int32(sqlparam[43].Value);
                    //}
                    return sqlparam[42].Value.ToString();
                }
            else
                return null;

        }
        public string Collection_VoucherEntry(clsVoucherEntryBll obj, ref DataTable dt)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@DOCID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.DOCID);

            string _Procname = "co_acc_GenerateReceiptVoucher";
            //if (ClsCommon.CompanyId == (int)Enum_Company.NATIONAL)
            //{
            //    _Procname = "CO_ACC_VOUCHERENTRY_INSERTUPDATE";
            //}
            //else if (ClsCommon.CompanyId == (int)Enum_Company.GIC)
            //{
            //    _Procname = "CO_ACC_COLLECTION_VOUCHER_GIC";
            //}
            DataRow workRow = dt.NewRow();
            workRow["ProcName"] = _Procname;
            workRow["ProcType"] = "sp";
            workRow["sqlParam"] = sqlparam;
            dt.Rows.Add(workRow);
            return "";
        }
        public string OtherCollection_VoucherEntry(clsVoucherEntryBll obj, ref DataTable dt)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@PID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.PD_ID);
            DataRow workRow = dt.NewRow();
            workRow["ProcName"] = "OTHCO_ACC_VOUCHERENTRY_INSERTUPDATE";
            workRow["ProcType"] = "sp";
            workRow["sqlParam"] = sqlparam;
            dt.Rows.Add(workRow);
            return "";
        }
        #region OpeningTransfer

        public string InsertUpdate_OpeningTransfer(clsVoucherEntryBll obj, ref int prmMasterID)
        {
            SqlParameter[] sqlparam = new SqlParameter[68];
            sqlparam[0] = new SqlParameter("@TRANID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.TRANID);
            sqlparam[1] = new SqlParameter("@DOCUMENTNO", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.DOCUMENTNO);
            sqlparam[2] = new SqlParameter("@POLICYNO", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.POLICYNO);
            sqlparam[3] = new SqlParameter("@CLAIMNO", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.CLAIMNO);
            sqlparam[4] = new SqlParameter("@RECNO", SqlDbType.Decimal);
            sqlparam[4].Value = NullHandler.Decimal(obj.RECNO);
            sqlparam[5] = new SqlParameter("@RECEIPTNO", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.RECEIPTNO);
            sqlparam[6] = new SqlParameter("@BANKID", SqlDbType.Decimal);
            sqlparam[6].Value = NullHandler.Decimal(obj.BANKID);
            sqlparam[7] = new SqlParameter("@fiscalid", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.FiscalID);
            sqlparam[8] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.branchid);
            sqlparam[9] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.VOUCHERNO);
            sqlparam[10] = new SqlParameter("@EDATE", SqlDbType.DateTime);
            sqlparam[10].Value = NullHandler.DateTime(obj.EDATE);
            sqlparam[11] = new SqlParameter("@NDATE", SqlDbType.DateTime);
            sqlparam[11].Value = NullHandler.DateTime(obj.NDATE);
            sqlparam[12] = new SqlParameter("@ACCOUNTCODE", SqlDbType.VarChar);
            sqlparam[12].Value = NullHandler.String(obj.ACCOUNTCODE);
            sqlparam[13] = new SqlParameter("@ACCOUNTDESC", SqlDbType.VarChar);
            sqlparam[13].Value = NullHandler.String(obj.ACCOUNTDESC);
            sqlparam[14] = new SqlParameter("@DRAMOUNT", SqlDbType.Decimal);
            sqlparam[14].Value = NullHandler.Decimal(obj.DRAMOUNT);
            sqlparam[15] = new SqlParameter("@CRAMOUNT", SqlDbType.Decimal);
            sqlparam[15].Value = NullHandler.Decimal(obj.CRAMOUNT);
            sqlparam[16] = new SqlParameter("@IFPREVBALANCE", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Decimal(obj.IFPREVBALANCE);
            sqlparam[17] = new SqlParameter("@OFDATE", SqlDbType.DateTime);
            sqlparam[17].Value = NullHandler.DateTime(obj.OFDATE);
            sqlparam[18] = new SqlParameter("@TTYPE", SqlDbType.Decimal);
            sqlparam[18].Value = NullHandler.Decimal(obj.TTYPE);
            sqlparam[19] = new SqlParameter("@FCCODE", SqlDbType.Decimal);
            sqlparam[19].Value = NullHandler.Decimal(obj.FCCODE);
            sqlparam[20] = new SqlParameter("@FCRATE", SqlDbType.Decimal);
            sqlparam[20].Value = NullHandler.Decimal(obj.FCRATE);
            sqlparam[21] = new SqlParameter("@ENTRYNO", SqlDbType.Decimal);
            sqlparam[21].Value = NullHandler.Decimal(obj.ENTRYNO);
            sqlparam[22] = new SqlParameter("@AGENTCODE", SqlDbType.VarChar);
            sqlparam[22].Value = NullHandler.String(obj.AGENTCODE);
            sqlparam[23] = new SqlParameter("@AGENTCOMMPAID", SqlDbType.Decimal);
            sqlparam[23].Value = NullHandler.Decimal(obj.AGENTCOMMPAID);
            sqlparam[24] = new SqlParameter("@APPROVED", SqlDbType.Decimal);
            sqlparam[24].Value = NullHandler.Decimal(obj.APPROVED);
            sqlparam[25] = new SqlParameter("@BSMONTH", SqlDbType.Decimal);
            sqlparam[25].Value = NullHandler.Decimal(obj.BSMONTH);
            sqlparam[26] = new SqlParameter("@BSYEAR", SqlDbType.Decimal);
            sqlparam[26].Value = NullHandler.Decimal(obj.BSYEAR);
            sqlparam[27] = new SqlParameter("@CHQNO", SqlDbType.VarChar);
            sqlparam[27].Value = NullHandler.String(obj.CHQNO);
            sqlparam[28] = new SqlParameter("@CLAIMPAYID", SqlDbType.Decimal);
            sqlparam[28].Value = NullHandler.Decimal(obj.CLAIMPAYID);
            sqlparam[29] = new SqlParameter("@CLAIMTYPE", SqlDbType.Decimal);
            sqlparam[29].Value = NullHandler.Decimal(obj.CLAIMTYPE);
            sqlparam[30] = new SqlParameter("@CLIENTCODE", SqlDbType.VarChar);
            sqlparam[30].Value = NullHandler.String(obj.CLIENTCODE);
            sqlparam[31] = new SqlParameter("@DECLARATIONNO", SqlDbType.VarChar);
            sqlparam[31].Value = NullHandler.String(obj.DECLARATIONNO);
            sqlparam[32] = new SqlParameter("@DEPOSITID", SqlDbType.Decimal);
            sqlparam[32].Value = NullHandler.Decimal(obj.DEPOSITID);
            sqlparam[33] = new SqlParameter("@DESCRIPTION", SqlDbType.VarChar);
            sqlparam[33].Value = NullHandler.String(obj.DESCRIPTION);
            sqlparam[34] = new SqlParameter("@EDITTIME", SqlDbType.VarChar);
            sqlparam[34].Value = NullHandler.String(obj.EDITTIME);
            sqlparam[35] = new SqlParameter("@EDITUSER", SqlDbType.VarChar);
            sqlparam[35].Value = NullHandler.String(obj.EDITUSER);
            sqlparam[36] = new SqlParameter("@FACID", SqlDbType.Decimal);
            sqlparam[36].Value = NullHandler.Decimal(obj.FACID);
            sqlparam[37] = new SqlParameter("@FACIID", SqlDbType.Decimal);
            sqlparam[37].Value = NullHandler.Decimal(obj.FACIID);
            sqlparam[38] = new SqlParameter("@FCAMOUNT", SqlDbType.Decimal);
            sqlparam[38].Value = NullHandler.Decimal(obj.FCAMOUNT);
            sqlparam[39] = new SqlParameter("@ISSUEDTO", SqlDbType.VarChar);
            sqlparam[39].Value = NullHandler.String(obj.ISSUEDTO);
            sqlparam[40] = new SqlParameter("@LEVEL1", SqlDbType.Decimal);
            sqlparam[40].Value = NullHandler.Decimal(obj.LEVEL1);
            sqlparam[41] = new SqlParameter("@LEVEL2", SqlDbType.Decimal);
            sqlparam[41].Value = NullHandler.Decimal(obj.LEVEL2);
            sqlparam[42] = new SqlParameter("@LEVEL3", SqlDbType.Decimal);
            sqlparam[42].Value = NullHandler.Decimal(obj.LEVEL3);
            sqlparam[43] = new SqlParameter("@LEVEL4", SqlDbType.Decimal);
            sqlparam[43].Value = NullHandler.Decimal(obj.LEVEL4);
            sqlparam[44] = new SqlParameter("@LEVEL5", SqlDbType.Decimal);
            sqlparam[44].Value = NullHandler.Decimal(obj.LEVEL5);
            sqlparam[45] = new SqlParameter("@LSBUID", SqlDbType.VarChar);
            sqlparam[45].Value = NullHandler.String(obj.LSBUID);
            sqlparam[46] = new SqlParameter("@MANUALVN", SqlDbType.VarChar);
            sqlparam[46].Value = NullHandler.String(obj.MANUALVN);
            sqlparam[47] = new SqlParameter("@PNARRATION", SqlDbType.VarChar);
            sqlparam[47].Value = NullHandler.String(obj.PNARRATION);
            sqlparam[48] = new SqlParameter("@POLICYNUMBER", SqlDbType.VarChar);
            sqlparam[48].Value = NullHandler.String(obj.POLICYNUMBER);
            sqlparam[49] = new SqlParameter("@RELATEDTO", SqlDbType.Decimal);
            sqlparam[49].Value = NullHandler.Decimal(obj.RELATEDTO);
            sqlparam[50] = new SqlParameter("@REMARKS", SqlDbType.VarChar);
            sqlparam[50].Value = NullHandler.String(obj.REMARKS);
            sqlparam[51] = new SqlParameter("@RIID", SqlDbType.Decimal);
            sqlparam[51].Value = NullHandler.Decimal(obj.RIID);
            sqlparam[52] = new SqlParameter("@RIPOOLID", SqlDbType.Decimal);
            sqlparam[52].Value = NullHandler.Decimal(obj.RIPOOLID);
            sqlparam[53] = new SqlParameter("@TRNTIME", SqlDbType.VarChar);
            sqlparam[53].Value = NullHandler.String(obj.TRNTIME);
            sqlparam[54] = new SqlParameter("@TRNUSER", SqlDbType.VarChar);
            sqlparam[54].Value = NullHandler.String(obj.TRNUSER);
            sqlparam[55] = new SqlParameter("@vtypeId", SqlDbType.Int);
            sqlparam[55].Value = NullHandler.Int32(obj.VTYPEID);
            sqlparam[56] = new SqlParameter("@CHQDATE", SqlDbType.VarChar);
            sqlparam[56].Value = NullHandler.String(obj.CHQDATE);
            sqlparam[57] = new SqlParameter("@ISMANUAL", SqlDbType.Decimal);
            sqlparam[57].Value = NullHandler.Decimal(obj.ISMANUAL);
            sqlparam[58] = new SqlParameter("@PD_ID", SqlDbType.Decimal);
            sqlparam[58].Value = NullHandler.Decimal(obj.PD_ID);
            sqlparam[59] = new SqlParameter("@USERID", SqlDbType.VarChar);
            sqlparam[59].Value = NullHandler.String(obj.USERID);
            sqlparam[60] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[60].Value = NullHandler.String(obj.AUID);
            sqlparam[61] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[61].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[62] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[62].Value = NullHandler.String(obj.UUID);
            sqlparam[63] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[63].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[64] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[64].Direction = ParameterDirection.Output;
            sqlparam[65] = new SqlParameter("@TRANSFER", SqlDbType.Structured);
            sqlparam[65].Value = (obj.TRANSFER);
            sqlparam[66] = new SqlParameter("@Master_id", SqlDbType.Int);
            sqlparam[66].Direction = ParameterDirection.Output;
            sqlparam[67] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[67].Value = NullHandler.Int32(obj.SUBBRANCHID);
            string _errMsg = "";
            objCmnDal.InsertUpdateTable("[acc_InsertUpdate_OpeningBalance]", "sp", sqlparam, ref _errMsg);
            if (sqlparam[64].Value != DBNull.Value)
                if (_errMsg.Length > 2)
                {
                    return _errMsg;
                }
                else
                {
                    if (sqlparam[64].Value.ToString() == "insert")
                    {
                        prmMasterID = ClsConvertTo.Int32(sqlparam[66].Value);
                    }
                    return sqlparam[64].Value.ToString();
                }
            else
                return null;

        }

        #endregion

        public DataTable LoadVoucherNo()
        {
            return objCmnDal.GetTable("select distinct VOUCHERNO from ac_transaction_14 order by VOUCHERNO desc", "text", null);
        }
        public DataTable LoadVoucherNoList()
        {
            return objCmnDal.GetTable("select distinct * from ac_transaction_14 order by VOUCHERNO", "text", null);
        }
        public DataTable Get_VoucherNo_List(clsVoucherEntryBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(cls.VOUCHERNO);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_VoucherNoSearch_List", "sp", sqlparam);
            return ds;
        }
        public DataSet GetVoucherEntry(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.VOUCHERNO);
            sqlparam[1] = new SqlParameter("@VTYPE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.VTYPE);
            sqlparam[2] = new SqlParameter("@FISCALYEAR", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.FISCALYEAR);
            sqlparam[3] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.branchid);
            DataSet ds = new DataSet();
            ds = objCmnDal.GetTableSet("acc_voucherEntry_get", "sp", sqlparam);
            return ds;
        }
        public int Get_VoucherNoMax_List(clsVoucherEntryBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@BRANCHCODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(cls.branchid);
            sqlparam[1] = new SqlParameter("@VTYPE", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(cls.VTYPEID);
            sqlparam[2] = new SqlParameter("@FISCALYEAR", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(cls.FiscalID);
            sqlparam[3] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[3].Direction = ParameterDirection.Output;
            //DataTable ds = new DataTable();
            //ds = objCmnDal.GetTable("acc_VoucherNoMax_List", "sp", sqlparam);
            //return ds;
            objCmnDal.InsertUpdateTable("acc_VoucherNoMax_List", "sp", sqlparam);
            if (sqlparam[3].Value != DBNull.Value)
                        return ClsConvertTo.Int32(sqlparam[3].Value);
            return 0;
        }
        public string Get_VoucherNoMax_List_IFexist(clsVoucherEntryBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@BRANCHCODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(cls.branchid);
            sqlparam[1] = new SqlParameter("@VTYPE", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(cls.VTYPEID);
            sqlparam[2] = new SqlParameter("@FISCALYEAR", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(cls.FiscalID);
            sqlparam[3] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(cls.VOUCHERNO);
            sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[4].Direction = ParameterDirection.Output;
            //DataTable ds = new DataTable();
            //ds = objCmnDal.GetTable("acc_VoucherNoMax_List", "sp", sqlparam);
            //return ds;
            objCmnDal.InsertUpdateTable("acc_Voucher_getvoucherno", "sp", sqlparam);
            if (sqlparam[4].Value != DBNull.Value)
                return sqlparam[4].Value.ToString();
            else
                return null;
        }
        public DataTable Get_VoucherNo_LastUsed(clsVoucherEntryBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@BranchID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(cls.branchid);
            sqlparam[1] = new SqlParameter("@VoucherType", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(cls.VTYPEID);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(cls.FiscalID);
            sqlparam[3] = new SqlParameter("@SubBranchID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(cls.SUBBRANCHID);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_voucher_LastUsedNo", "sp", sqlparam);
            return ds;
        }
        public DataTable Get_OpenTransfer_List(clsVoucherEntryBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@BRANCHCODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(cls.branchid);
            sqlparam[1] = new SqlParameter("@DtFrom", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(cls.DATEFROM);
            sqlparam[2] = new SqlParameter("@DtTo", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(cls.DATETO);
            sqlparam[3] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(cls.SUBBRANCHID);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("[acc_OpenTransfer_List]", "sp", sqlparam);
            return ds;
        }

        public DataTable HasNextVoucherExists(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@BranchId", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@SubBranchID", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.Int32(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.FiscalID);
            sqlparam[3] = new SqlParameter("@VoucherNo", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objVoucherEntryBll.VOUCHERNO);
            sqlparam[4] = new SqlParameter("@VoucherTypeID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(objVoucherEntryBll.vouchertypeid);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_HasNextVoucher", "sp", sqlparam);
            return dt;
        }
        public DataTable GetVoucherStatus(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@BankdepositId", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.BankDepositID);
            sqlparam[1] = new SqlParameter("@ClaimID", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.Int32(objVoucherEntryBll.CLAIMID);
            sqlparam[2] = new SqlParameter("@DocID", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.DOCID);
            sqlparam[3] = new SqlParameter("@PayID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objVoucherEntryBll.PayID);
            sqlparam[4] = new SqlParameter("@VoucherDt", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.OFDATE);
            sqlparam[5] = new SqlParameter("@RiID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(objVoucherEntryBll.RIID);
            sqlparam[6] = new SqlParameter("@VoucherTypeID", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(objVoucherEntryBll.vouchertypeid);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_voucher_Status", "sp", sqlparam);
            return dt;
        }
        internal DataTable getdataforlisting(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[14];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@VTYPE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FISCALYEAR", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objVoucherEntryBll.FISCALYEAR);
            sqlparam[3] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objVoucherEntryBll.status);
            sqlparam[4] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[5] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[5].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);
            sqlparam[6] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.VOUCHERNO);
            sqlparam[7] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Decimal(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[8] = new SqlParameter("@TRANSACTIONTYPEID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Decimal(objVoucherEntryBll.TRANSACTIONTYPEID);
            sqlparam[9] = new SqlParameter("@Security_Branch", SqlDbType.Structured);
            sqlparam[9].Value = objVoucherEntryBll.dtSecBranch;
            sqlparam[10] = new SqlParameter("@Security_subBranch", SqlDbType.Structured);
            sqlparam[10].Value = objVoucherEntryBll.dtSecSubBranch;
            sqlparam[11] = new SqlParameter("@Sec_userid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(objVoucherEntryBll.Sec_userid);
            sqlparam[12] = new SqlParameter("@pg", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.PageNo);
            sqlparam[13] = new SqlParameter("@pgSize", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.PageSize);
            
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_voucherEntry_list", "sp", sqlparam);
            return dt;
        }
        internal DataTable getdataforlisting_New(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[15];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@VTYPE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FISCALYEAR", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objVoucherEntryBll.FISCALYEAR);
            sqlparam[3] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objVoucherEntryBll.status);
            sqlparam[4] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[5] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[5].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);
            sqlparam[6] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.VOUCHERNO);
            sqlparam[7] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Decimal(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[8] = new SqlParameter("@TRANSACTIONTYPEID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Decimal(objVoucherEntryBll.TRANSACTIONTYPEID);
            sqlparam[9] = new SqlParameter("@Security_Branch", SqlDbType.Structured);
            sqlparam[9].Value = objVoucherEntryBll.dtSecBranch;
            sqlparam[10] = new SqlParameter("@Security_subBranch", SqlDbType.Structured);
            sqlparam[10].Value = objVoucherEntryBll.dtSecSubBranch;
            sqlparam[11] = new SqlParameter("@Sec_userid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(objVoucherEntryBll.Sec_userid);
            sqlparam[12] = new SqlParameter("@pg", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.PageNo);
            sqlparam[13] = new SqlParameter("@pgSize", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.PageSize);
            sqlparam[14] = new SqlParameter("@IsExport", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(objVoucherEntryBll.IsExport);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_voucherEntry_list_opt", "sp", sqlparam);
            return dt;
        }

        public DataTable Delete()
        {
            return objCmnDal.GetTable("delete from AC_TRANSACTION_DETAILS where IFPREVBALANCE=1", "text", null);
        }

        //internal string updatevoucher(clsVoucherEntryBll objVoucherEntryBll)
        //{
        //    SqlParameter[] sqlparam = new SqlParameter[1];
        //    sqlparam[0] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
        //    sqlparam[0].Value = NullHandler.Decimal(objVoucherEntryBll.VOUCHERNO);

        //   return Convert.ToString( objCmnDal.InsertUpdateTable("acc_approve_vouchers", "sp", sqlparam));

        //}

        internal DataSet getledgerdata(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[15];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@vouchertypeid", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.FiscalID);

            sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);
            sqlparam[5] = new SqlParameter("@accountcode", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Decimal(objVoucherEntryBll.acccode);
            sqlparam[6] = new SqlParameter("@IncludeBF", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.balanceforward);
            sqlparam[7] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[8] = new SqlParameter("@APPROVED", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(objVoucherEntryBll.APPSTATUS);
            sqlparam[9] = new SqlParameter("@Security_Branch", SqlDbType.Structured);
            sqlparam[9].Value = objVoucherEntryBll.dtSecBranch;
            sqlparam[10] = new SqlParameter("@Security_subBranch", SqlDbType.Structured);
            sqlparam[10].Value = objVoucherEntryBll.dtSecSubBranch;
            sqlparam[11] = new SqlParameter("@Sec_userid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(objVoucherEntryBll.Sec_userid);
            sqlparam[12] = new SqlParameter("@PG", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.PageNo);
            sqlparam[13] = new SqlParameter("@PGSIZE", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.PageSize);
            sqlparam[14] = new SqlParameter("@ISEXPORT", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(objVoucherEntryBll.IsExport);
            DataSet dt = new DataSet();
            dt = objCmnDal.GetTableSet("acc_rpt_ledger", "sp", sqlparam);
            return dt;
        }

        internal DataTable getTrialBlcdata(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[18];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@vouchertypeid", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.FiscalID);

            sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);

            sqlparam[5] = new SqlParameter("@IncludeBF", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Decimal(objVoucherEntryBll.balanceforward);
            sqlparam[6] = new SqlParameter("@IsOpeningOnly", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.openingOnly);
            sqlparam[7] = new SqlParameter("@level1", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL1);

            sqlparam[8] = new SqlParameter("@level2", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL2);
            sqlparam[9] = new SqlParameter("@level3", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL3);
            sqlparam[10] = new SqlParameter("@level4", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL4);
            sqlparam[11] = new SqlParameter("@level5", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL5);
            sqlparam[12] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[13] = new SqlParameter("@APPROVED", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.APPROVED);
            sqlparam[14] = new SqlParameter("@Security_Branch", SqlDbType.Structured);
            sqlparam[14].Value = objVoucherEntryBll.dtSecBranch;
            sqlparam[15] = new SqlParameter("@Security_subBranch", SqlDbType.Structured);
            sqlparam[15].Value = objVoucherEntryBll.dtSecSubBranch;
            sqlparam[16] = new SqlParameter("@Sec_userid", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(objVoucherEntryBll.Sec_userid);
            sqlparam[17] = new SqlParameter("@TransactionTypeID", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(objVoucherEntryBll.TRANSACTIONTYPEID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_rpt_trialBalance", "sp", sqlparam);
            return dt;
        }
        internal DataTable getOpeningdata(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[18];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@vouchertypeid", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.FiscalID);

            sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);

            sqlparam[5] = new SqlParameter("@IncludeBF", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Decimal(objVoucherEntryBll.balanceforward);
            sqlparam[6] = new SqlParameter("@IsOpeningOnly", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.openingOnly);
            sqlparam[7] = new SqlParameter("@level1", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL1);

            sqlparam[8] = new SqlParameter("@level2", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL2);
            sqlparam[9] = new SqlParameter("@level3", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL3);
            sqlparam[10] = new SqlParameter("@level4", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL4);
            sqlparam[11] = new SqlParameter("@level5", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL5);
            sqlparam[12] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[13] = new SqlParameter("@APPROVED", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.APPROVED);
            sqlparam[14] = new SqlParameter("@Security_Branch", SqlDbType.Structured);
            sqlparam[14].Value = objVoucherEntryBll.dtSecBranch;
            sqlparam[15] = new SqlParameter("@Security_subBranch", SqlDbType.Structured);
            sqlparam[15].Value = objVoucherEntryBll.dtSecSubBranch;
            sqlparam[16] = new SqlParameter("@Sec_userid", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(objVoucherEntryBll.Sec_userid);
            sqlparam[17] = new SqlParameter("@TransactionTypeID", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(objVoucherEntryBll.TRANSACTIONTYPEID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_rpt_OpeningTransferData", "sp", sqlparam);
            return dt;
        }
        internal string FxSaveOpening(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[23];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@vouchertypeid", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.FiscalID);

            sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);

            sqlparam[5] = new SqlParameter("@IncludeBF", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Decimal(objVoucherEntryBll.balanceforward);
            sqlparam[6] = new SqlParameter("@IsOpeningOnly", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.openingOnly);
            sqlparam[7] = new SqlParameter("@level1", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL1);

            sqlparam[8] = new SqlParameter("@level2", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL2);
            sqlparam[9] = new SqlParameter("@level3", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL3);
            sqlparam[10] = new SqlParameter("@level4", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL4);
            sqlparam[11] = new SqlParameter("@level5", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL5);
            sqlparam[12] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[13] = new SqlParameter("@APPROVED", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.APPROVED);
            sqlparam[14] = new SqlParameter("@Security_Branch", SqlDbType.Structured);
            sqlparam[14].Value = objVoucherEntryBll.dtSecBranch;
            sqlparam[15] = new SqlParameter("@Security_subBranch", SqlDbType.Structured);
            sqlparam[15].Value = objVoucherEntryBll.dtSecSubBranch;
            sqlparam[16] = new SqlParameter("@Sec_userid", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(objVoucherEntryBll.Sec_userid);
            sqlparam[17] = new SqlParameter("@TransactionTypeID", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(objVoucherEntryBll.TRANSACTIONTYPEID);

            sqlparam[18] = new SqlParameter("@OpeningDiffAmt", SqlDbType.Decimal);
            sqlparam[18].Value = NullHandler.Decimal(objVoucherEntryBll.OpeningDiffAmt);
            sqlparam[19] = new SqlParameter("@OpeningDiffType", SqlDbType.VarChar);
            sqlparam[19].Value = NullHandler.String(objVoucherEntryBll.OpeningDRCRType);
            sqlparam[20] = new SqlParameter("@OpeningAccid", SqlDbType.Int);
            sqlparam[20].Value = NullHandler.Int32(objVoucherEntryBll.OpeningDiffAccode);
            sqlparam[21] = new SqlParameter("@msg", SqlDbType.VarChar,50);
            sqlparam[21].Direction = ParameterDirection.Output;
            sqlparam[22] = new SqlParameter("@Narration", SqlDbType.VarChar);
            sqlparam[22].Value = NullHandler.String(objVoucherEntryBll.PNARRATION);

            objCmnDal.InsertUpdateTable("acc_opening_insertupdate", "sp", sqlparam);
            if (sqlparam[21].Value != DBNull.Value)
                return sqlparam[21].Value.ToString();
            else
                return null;

        }
        internal DataTable getOpeningTrialBlcdata(clsVoucherEntryBll objVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[15];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objVoucherEntryBll.branchid);
            sqlparam[1] = new SqlParameter("@vouchertypeid", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objVoucherEntryBll.VTYPE);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objVoucherEntryBll.FiscalID);

            sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(objVoucherEntryBll.dtfrom);
            sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(objVoucherEntryBll.dtto);

            sqlparam[5] = new SqlParameter("@IncludeBF", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Decimal(objVoucherEntryBll.balanceforward);
            sqlparam[6] = new SqlParameter("@IsOpeningOnly", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Decimal(objVoucherEntryBll.openingOnly);
            sqlparam[7] = new SqlParameter("@level1", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL1);

            sqlparam[8] = new SqlParameter("@level2", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL2);
            sqlparam[9] = new SqlParameter("@level3", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL3);
            sqlparam[10] = new SqlParameter("@level4", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL4);
            sqlparam[11] = new SqlParameter("@level5", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Decimal(objVoucherEntryBll.LEVEL5);
            sqlparam[12] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objVoucherEntryBll.SUBBRANCHID);
            sqlparam[13] = new SqlParameter("@APPROVED", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objVoucherEntryBll.APPROVED);
            sqlparam[14] = new SqlParameter("@TransactionTypeID", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(objVoucherEntryBll.TRANSACTIONTYPEID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("[acc_rpt_trialBalance_with_O_O_C]", "sp", sqlparam);
            return dt;
        }

        //added by subarna
        public DataTable Get_VW_AccTransaction(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@Master_id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.MasterId);
            sqlparam[1] = new SqlParameter("@payId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.PayID);
            sqlparam[2] = new SqlParameter("@PurchaseID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.PurchaseID);
            DataTable dt = objCmnDal.GetTable("acc_vw_acctransaction_get", "sp", sqlparam);
            return dt;
        }

        //by pradip
        public DataTable Get_trialBalance_Operating(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.branchid);
            sqlparam[1] = new SqlParameter("@vouchertypeid", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.VTYPE);
            sqlparam[2] = new SqlParameter("@FiscalID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.FiscalID);

            sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(obj.dtfrom);
            sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(obj.dtto);
            DataTable dt = objCmnDal.GetTable("acc_rpt_trialBalance_Operating", "sp", sqlparam);
            return dt;
        }
        
        internal DataSet getvoucherdata(clsVoucherEntryBll clsVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@MasterId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsVoucherEntryBll.MasterId);
            sqlparam[1] = new SqlParameter("@payid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsVoucherEntryBll.PayID);
            DataSet ds = new DataSet();
            return ds = objCmnDal.GetTableSet("AC_TRANSACTION_MASTER_get", "sp", sqlparam);
        }
        internal DataSet getChequeData(clsVoucherEntryBll clsVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@MasterId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsVoucherEntryBll.MasterId);
            sqlparam[1] = new SqlParameter("@payid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsVoucherEntryBll.PayID);
            DataSet ds = new DataSet();
            return ds = objCmnDal.GetTableSet("AC_CHEQUEPRINT_GET", "sp", sqlparam);
        }
        public string InsertUpdateTBLCHEQUESIGNAT_HISTORY(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@SNO", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.SNO);



            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.BRANCHCODE);


            sqlparam[2] = new SqlParameter("@SIGNATURE1", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.SIGNATURE1);
            sqlparam[3] = new SqlParameter("@SIGNATURE1_CODE", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.SIGNATURE1_CODE);
            sqlparam[4] = new SqlParameter("@SIGNATURE2", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.SIGNATURE2);
            sqlparam[5] = new SqlParameter("@SIGNATURE2_CODE", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.SIGNATURE2_CODE);
            sqlparam[6] = new SqlParameter("@ISPRINT", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.ISPRINT);

            sqlparam[7] = new SqlParameter("@msg", SqlDbType.VarChar, 40);
            sqlparam[7].Direction = ParameterDirection.Output;
            sqlparam[8] = new SqlParameter("@MASTERID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.MasterId);
            sqlparam[9] = new SqlParameter("@CRAMOUNT", SqlDbType.Decimal);
            sqlparam[9].Value = NullHandler.Decimal(obj.CRAMOUNT);
            sqlparam[10] = new SqlParameter("@CHQNO", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(obj.CHQNO);
            objCmnDal.InsertUpdateTable("TBLCHEQUESIGNAT_HISTORY_insertUpdate", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;
        }
        public string Approve_Unapprove_Voucher(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[15];
            sqlparam[0] = new SqlParameter("@MasterID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.MasterId);
            sqlparam[1] = new SqlParameter("@remarks", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.REMARKS);
            sqlparam[2] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.branchid);
            sqlparam[3] = new SqlParameter("@VOUCHERTYPEID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.vouchertypeid);
            sqlparam[4] = new SqlParameter("@APPUSERID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.appuserid);
            sqlparam[5] = new SqlParameter("@APPDATE", SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(obj.approvedate);
            sqlparam[6] = new SqlParameter("@VOUCHERDT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(obj.voucherdate);
            sqlparam[7] = new SqlParameter("@VOUCHERNO", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.VOUCHERNO);
            sqlparam[8] = new SqlParameter("@APPLIMIT", SqlDbType.Decimal);
            sqlparam[8].Value = NullHandler.Decimal(obj.limitamt);
            sqlparam[9] = new SqlParameter("@VOUCHERAMT", SqlDbType.Decimal);
            sqlparam[9].Value = NullHandler.Decimal(obj.voucheramt);
            sqlparam[10] = new SqlParameter("@APPSTATUS", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(1);
            sqlparam[11] = new SqlParameter("@NOOFENTRY", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(obj.NOOFENTRY);
            sqlparam[12] = new SqlParameter("@APPROVED", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(ClsConvertTo.Int32(obj.APPROVED));
            sqlparam[13] = new SqlParameter("@msg", SqlDbType.VarChar, 40);
            sqlparam[13].Direction = ParameterDirection.Output;
            sqlparam[14] = new SqlParameter("@DTL_MID", SqlDbType.Structured);
            sqlparam[14].Value = obj.DT_MasterID;

            objCmnDal.InsertUpdateTable("acc_approve_vouchers", "sp", sqlparam);
            if (sqlparam[13].Value != DBNull.Value)
                return sqlparam[13].Value.ToString();
            else
                return null;
        }
        public DataTable getChqHistoryToCheck(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@MASTED_ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.MasterId);

            return objCmnDal.GetTable("tblChqHistory_get", "sp", sqlparam);

        }
        public DataTable getChqHistory(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@MASTED_ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.MasterId);

            return objCmnDal.GetTable("select * from TBLCHEQUESIGNAT_HISTORY where ISPRINT=1", "txt", sqlparam);

        }
        public DataTable getDataForChqHistory(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            //sqlparam[0] = new SqlParameter("@CHQNO", SqlDbType.VarChar);
            //sqlparam[0].Value = NullHandler.String(obj.CHQNO);

            return objCmnDal.GetTable("getaccdetails_forchqHistory", "sp", sqlparam);
        }
        public DataTable getEmployeeName() 
        {
            return objCmnDal.GetTable("select emp_code,Firstname +' '+Lastname as name from tblHR_employee", "txt", null);
        }
        public DataTable getCreditAmount(clsVoucherEntryBll obj)
        {
            return objCmnDal.GetTable("select CRAMOUNT,CHQNO from vw_acc_transactions where MASTERID="+obj.MasterId, "txt", null);
        }
        public DataTable GetVoucherTypeList(clsVoucherEntryBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            sqlparam[1] = new SqlParameter("@mode", SqlDbType.Int);//1=load all, 0 = exclude system generated vouchertype
            sqlparam[1].Value = NullHandler.Int32(obj.MODE);
            sqlparam[2] = new SqlParameter("@showondisbursement", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.SHOWONDISBURSEMENT);

            //sqlparam[3] = new SqlParameter("@DATEFROM", SqlDbType.Date);
            //sqlparam[3].Value = NullHandler.DateTime(obj.dtfrom);
            //sqlparam[4] = new SqlParameter("@DATETO", SqlDbType.Date);
            //sqlparam[4].Value = NullHandler.DateTime(obj.dtto);
            DataTable dt = objCmnDal.GetTable("[acc_icVoucherType_getList]", "sp", sqlparam);
            return dt;
        }
    }
}