using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.DalClass.Common;
using System.Web.UI;

namespace Stock.BllDalClasses.BllClass.Common
{
    public class ClsMotorTariff
    {
        public decimal pSuminsured { get; set; }
        public decimal pUtilitiesAmt { get; set; }
        public decimal pOtherSI { get; set; }
        public decimal pCC_HP_SEATS { get; set; }
        public int pManufactureYr { get; set; }
        public int pNCD { get; set; }
        public decimal pCExcess { get; set; }
        public decimal pDriverSuminsured { get; set; }
        public decimal pPassengerSuminsured { get; set; }
        public decimal pHelperSuminsured { get; set; }
        public int pNo_of_Driver { get; set; }
        public int pNo_of_Helper { get; set; }
        public int pNo_of_Passenger { get; set; }
        public int pVehicleCategoryid { get; set; }
        public int pVehicleControlCategoryid { get; set; }
        public Boolean pIsComprehensive { get; set; }
        public int pDeptid { get; set; }
        public int pClassid { get; set; }
        public int pVehicleAge { get; set; }
        public DateTime pIssueDate { get; set; }
        public Boolean pHasAgent { get; set; }
        public int pPrivateUse { get; set; }
        public int pExcludePool { get; set; }
        public int pIncludetowing { get; set; }
        public int isGovernment { get; set; }

        clsCommonDal objCmn = new clsCommonDal();

        public DataTable GetMotorTariffData()
        {           

            DataTable dt = new DataTable();
            DataSet dtsetup = new DataSet();

            DataTable _tmp = new DataTable();
            /*_tmp.Columns.Add("Sno", typeof(int));
            _tmp.Columns.Add("RiskDescription", typeof(string));
            _tmp.Columns.Add("Rate", typeof(decimal));
            _tmp.Columns.Add("Amount", typeof(decimal));
            _tmp.Columns.Add("Riskid", typeof(int));
            _tmp.Columns.Add("NatPerils", typeof(int));
            _tmp.Columns.Add("Mot_risk_sno", typeof(int));
            _tmp.Columns.Add("IgnoreComm", typeof(int));
            _tmp.Columns.Add("premcat", typeof(int));
            _tmp.Columns.Add("addmode", typeof(int));
            _tmp.Columns.Add("RskSerialNo", typeof(int));*/

            _tmp.Columns.Add("ROWNUMBER", typeof(int));//renamed
            _tmp.Columns.Add("RISKCODE", typeof(string));//renamed
            _tmp.Columns.Add("RskDescription", typeof(string));
            _tmp.Columns.Add("Rate", typeof(decimal));//renamed
            _tmp.Columns.Add("Amount", typeof(decimal));
            _tmp.Columns.Add("CATID", typeof(int));//renamed
            _tmp.Columns.Add("IGNORE_COMM", typeof(int));//renamed
            _tmp.Columns.Add("NAT_PERILS", typeof(int));//renamed
            _tmp.Columns.Add("addmode", typeof(int));
            _tmp.Columns.Add("Mot_risk_sno", typeof(int));
            _tmp.Columns.Add("RskSerialNo", typeof(int));

            if (pIsComprehensive)
            {
                dtsetup = GetTariffSetup("CM");
            }
            else
            {
                dtsetup = GetTariffSetup("TP");
            }

            FxCalcTariffAmount(dtsetup, ref _tmp);
            return _tmp;
        }
        public DataSet GetTariffSetup(string pTypeofCover)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@vehicletypeid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(pVehicleCategoryid);
            sqlparam[1] = new SqlParameter("@Deptid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(pDeptid);
            sqlparam[2] = new SqlParameter("@ClassID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(pClassid);
            sqlparam[3] = new SqlParameter("@TypeofCover", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(pTypeofCover);
            sqlparam[4] = new SqlParameter("@isGovt", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(isGovernment);
            return objCmn.GetTableSet("uw_Motor_tariff", "sp", sqlparam);
        }
        protected void FxCalcTariffAmount(DataSet dtSetup, ref DataTable dtTemp)
        {
            try
            {
                List<string> Conname=new List<string>();
                List<string> ConVal=new List<string>();
                Conname.Add("categoryid");
                ConVal.Add(pVehicleCategoryid.ToString());
                pVehicleControlCategoryid = ClsConvertTo.Int32(ClsCommon.CodeDecode("MSMOTORCLASSCATEGORY", "controlcatid", Conname, ConVal, ""));
                DataTable dtTariff = new DataTable();
                DataTable dtFilter = new DataTable();
                clsCommonEnumerator.Motor_Risk_SN Enum_Mot_Rsk = new clsCommonEnumerator.Motor_Risk_SN();
                clsCommonEnumerator.Class Enum_Class = new clsCommonEnumerator.Class();

                int _Sno = 0;
                string _RskDesc = "";
                decimal _Rate = 0;
                decimal _Amount = 0;
                string _RiskCode = "";
                decimal _NatPerils = 0;
                int _Mot_risk_sno = 0;
                int _IgnoreComm = 0;
                int _PremCat = 0;
                int _addMode = 0;
                int _RskSerialNo = 0;
                decimal _extraTon = 0;


                pVehicleAge = pIssueDate.Year - pManufactureYr;

                dtTariff = dtSetup.Tables[0];
                dtFilter = dtSetup.Tables[1];

                decimal _tariff = 0;

                if (dtTariff != null)
                {
                    if (dtTariff.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTariff.Rows)
                        {
                            _Rate = 0;
                            _Amount = 0;
                            _RiskCode = "";
                            _NatPerils = 0;
                            _Mot_risk_sno = 0;
                            _IgnoreComm = 0;
                            _PremCat = 0;
                            _addMode = 0;
                            _RskSerialNo = 0;
                            _extraTon = 0;


                            int _MotRiskSn = ClsConvertTo.Int32(dr["MOT_RISK_SN"]);
                            _tariff = 0;

                            if (_MotRiskSn == (int)Enum_Mot_Rsk.Basic_premium)
                            {
                                #region Basic Premium
                                if (pSuminsured > 0)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        for (int i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pCC_HP_SEATS > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                            else
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                break;
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            switch (pVehicleControlCategoryid)
                                            {
                                                case (int)Enum_MotorCategory.Motor_Cycle://1://motorcycle
                                                case (int)Enum_MotorCategory.Comercial://2://comercial
                                                case (int)Enum_MotorCategory.Truck_Pick_up://3://truck
                                                case (int)Enum_MotorCategory.Bus://4://bus
                                                case (int)Enum_MotorCategory.Passenger_Bus://5://passenger bus
                                                case (int)Enum_MotorCategory.Tanker://6://tanker
                                                case (int)Enum_MotorCategory.Tempo://7://Tempo
                                                case (int)Enum_MotorCategory.Taxi://11://Taxi
                                                case (int)Enum_MotorCategory.Construction_Equipment_Vehicle://13://Construction Equipment Vehicle
                                                //case (int)Enum_MotorCategory.Construction_Equipment_Vehicle://25://Construction Equipment Vehicle
                                                case (int)Enum_MotorCategory.Agriculture_or_Forestry_Vehicle://14://Agriculture or Forestry Vehicle
                                                //case (int)Enum_MotorCategory.Agriculture_or_Forestry_Vehicle://26://Agriculture or Forestry Vehicle
                                                //case (int)Enum_MotorCategory.Taxi://29://Taxi
                                                    _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]) + ((ClsConvertTo.Decimal(drt1[0]["Rate"]) / 100) * pSuminsured);
                                                    break;
                                                case (int)Enum_MotorCategory.Private_Car://9://Private Vehicle
                                                case (int)Enum_MotorCategory.Luxury_Car://10://Luxury Car
                                                case (int)Enum_MotorCategory.Electric_Vehicle://24://Electric Vehicle
                                                    if (pSuminsured <= 2000000)
                                                        _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]) + ((ClsConvertTo.Decimal(drt1[0]["Rate"]) / 100) * pSuminsured);
                                                    else
                                                        _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]) + ((ClsConvertTo.Decimal(drt1[0]["Rate"]) / 100) * 2000000);
                                                    break;
                                                case (int)Enum_MotorCategory.Tractor://8://tractor
                                                    _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]) + ((ClsConvertTo.Decimal(drt1[0]["Rate"]) / 100) * (pSuminsured));// - pUtilitiesAmt)); removed by sunila dated:1-feb-2017
                                                    break;
                                            }

                                            _Sno++;
                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }
                                #endregion Basic Premium
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Additional_premium || _MotRiskSn == (int)Enum_Mot_Rsk.Capacity_Loading)// or capacity loading
                            {
                                #region Additional Premium
                                _tariff = 0;
                                if (pSuminsured > 0)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        if (pClassid == (int)Enum_Class.Private_Vehicle)
                                        {
                                            for (int i = 0; i <= drt.Length - 1; i++)
                                            {
                                                if (pVehicleAge > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                                {
                                                    _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                }
                                                else
                                                {
                                                    _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                    break;
                                                }
                                            }
                                            DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                            if (drt1.Length > 0)
                                            {
                                                _Amount = 0;
                                                if (pSuminsured > 2000000)
                                                {
                                                    _Amount = ((ClsConvertTo.Decimal(drt1[0]["Rate"]) / 100) * (pSuminsured - 2000000));
                                                }
                                                _Sno++;
                                                _RskDesc = drt1[0]["RiskDesc"].ToString();
                                                _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                                _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                                _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                                _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                                _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                                //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                                //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                                //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                                //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);                                            
                                                _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                                //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                                _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                                _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                                
                                            }
                                        }
                                        else
                                        {
                                            for (int i = 0; i <= drt.Length - 1; i++)
                                            {
                                                if (pCC_HP_SEATS > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                                {
                                                    _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                    if (ClsCommon.CompanyId == (int)Enum_Company.NLGI)
                                                    {
                                                        _extraTon = ClsConvertTo.Decimal(pCC_HP_SEATS) - ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                    }
                                                    else
                                                    {
                                                        _extraTon = ClsConvertTo.Int16(Math.Round(pCC_HP_SEATS, 0) - Math.Round(ClsConvertTo.Decimal(drt[i]["tariff"].ToString()), 0));
                                                    }
                                                }
                                                else
                                                {
                                                    _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                    break;
                                                }
                                            }
                                            DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                            if (drt1.Length > 0)
                                            {
                                                _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]);

                                                #region changes by sunila for additional or extra ton date:4/26/2016
                                                //if (ClsConvertTo.Int32(drt1[0]["tid"]) == 3 && _extraTon > 0)//tid=3 ==> ton
                                                if (ClsConvertTo.Int32(drt1[0]["calcType"]) == (int)Enum_MotoCalcType.CARRYCAPACITY && _extraTon > 0)//tid=3 ==> ton
                                                {
                                                    _Amount = _Amount + _extraTon * ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                                }
                                                #endregion changes by sunila for additional or extra ton date:4/26/2016

                                                _Sno++;
                                                _RskDesc = drt1[0]["RiskDesc"].ToString();
                                                _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                                _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                                _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                                _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                                _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                                //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                                //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                                //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                                //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);                                            
                                                _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                                //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                                _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                                _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                            }
                                        }
                                    }
                                }
                                #endregion Additional Premium
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Trailor)
                            {
                                #region trailor
                                _tariff = 0;
                                if (pOtherSI > 0)
                                {
                                    decimal _tempPrem = 0;
                                    //if (pVehicleCategoryid == 10)
                                    _tempPrem = pOtherSI;
                                    //else
                                    //    _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        //if (pClassid == (int)Enum_Class.Private_Vehicle)
                                        //{
                                        int i = 0;
                                        for (i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pCC_HP_SEATS > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                            else
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                break;
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            _Sno++;

                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _Amount = (_tempPrem * (_Rate / 100)) - 200;
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                        //}
                                        //else
                                        //{
                                        //    _Sno++;
                                        //    _RskDesc = drt[0]["RiskDesc"].ToString();
                                        //    _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                        //    _Amount = (_tempPrem * (_Rate / 100)) + ClsConvertTo.Decimal(drt[0]["Amount"]);
                                        //    _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                        //    _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                        //    _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                        //    _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                        //    _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //    _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        //    _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        //    dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        //}
                                    }
                                }
                                #endregion trailor
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Manufacture_Year)
                            {
                                #region Manufacture Year

                                if (pManufactureYr > 0)
                                {
                                    decimal _tempPrem = 0;
                                    decimal _PrevYr = 0;
                                    _tariff = 0;
                                    _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                    if (pVehicleAge > 0)
                                    {
                                        DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                        if (drt.Length > 0)
                                        {
                                            int i = 0;
                                            for (i = 0; i <= drt.Length - 1; i++)
                                            {
                                                if (pVehicleAge > _PrevYr && pVehicleAge < ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                                {
                                                    _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                    _PrevYr = _tariff;
                                                }
                                                else if (pVehicleAge > _PrevYr && pVehicleAge > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                                {
                                                    _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                    _PrevYr = _tariff;
                                                    //break;
                                                }
                                            }

                                            DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                            if (drt1.Length > 0)
                                            {
                                                _Sno++;
                                                _RskDesc = drt1[0]["RiskDesc"].ToString();
                                                _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                                _Amount = (_tempPrem * (_Rate / 100));
                                                _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                                _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                                _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                                _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                                //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                                //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                                //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                                //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                                _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                                //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                                _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                                _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                            }
                                        }
                                    }

                                }
                                #endregion Manufacture Year
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Own_Goods_Carrying)
                            {
                                #region Own Goods Carrying Capacity
                                decimal _tempPrem = 0;
                                _tariff = 0;
                                _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);
                                DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                if (drt.Length > 0)
                                {
                                    _Sno++;
                                    _RskDesc = drt[0]["RiskDesc"].ToString();
                                    _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                    _Amount = (_tempPrem * (_Rate / 100));
                                    _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                    _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                    _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                    _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                    //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                    _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                    _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                }

                                #endregion Own Goods Carrying Capacity
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Rent_for_private_use)
                            {
                                #region private Use
                                if (pPrivateUse==1)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        decimal _tempPrem = 0;
                                        _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                        _Sno++;
                                        _RskDesc = drt[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                        _Amount = (_tempPrem * (_Rate / 100));
                                        _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }
                                #endregion private Use
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Excess_own_damage)
                            {
                                #region Excess_own_damage

                                if (pCExcess > 0)
                                {
                                    _tariff = 0;
                                    decimal _tempPrem = 0;
                                    _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        int i = 0;
                                        for (i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pCExcess > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                            else
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                break;
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _Amount = (_tempPrem * (_Rate / 100));
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }

                                #endregion Excess_own_damage

                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Fleet_Discount)
                            {
                                #region Fleet_Discount

                                //not reqd here as number of vehicle is not available now.


                                #endregion Fleet_Discount
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Minimum_Premium)
                            {
                                #region Minimum_Premium
                                //not reqd here as number of vehicle is not available now.
                                
                                DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                if (drt.Length > 0)
                                {
                                    _RskDesc = drt[0]["RiskDesc"].ToString();
                                    _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);

                                    decimal _tempPrem = 0;
                                    Boolean _Success = false;
                                    _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);
                                    _Amount = ClsConvertTo.Decimal(drt[0]["Amount"]);
                                    if ((int)Enum_Class.MotorCycle == pClassid)
                                    {
                                        if (_tempPrem < _Amount)
                                        {
                                            _tempPrem = _Amount - _tempPrem;
                                            _Success = true;
                                        }
                                    }
                                    if ((int)Enum_Class.Private_Vehicle == pClassid)
                                    {
                                        if (_tempPrem < _Amount)
                                        {
                                            _tempPrem = _Amount - _tempPrem;
                                            _Success = true;
                                        }
                                    }
                                    _Amount = _tempPrem;// ClsConvertTo.Decimal(drt[0]["Amount"]);
                                    _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                    _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                    _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                    _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                    _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    if (_Success)
                                    {
                                        _Sno++;
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }
                                #endregion Minimum_Premium
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Driver || _MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Driver_Rsd)
                            {
                                #region PA_to_Driver
                                if (pDriverSuminsured > 0)
                                {
                                    if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Driver_Rsd)
                                    {
                                        if (pExcludePool == 0)
                                        {
                                            DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                            if (drt.Length > 0)
                                            {
                                                _Sno++;
                                                _RskDesc = drt[0]["RiskDesc"].ToString();
                                                _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                                _Amount = (pDriverSuminsured * (_Rate / 1000));
                                                _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                                _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                                _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                                _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                                _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                                _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                                _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                        if (drt.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                            _Amount = (pDriverSuminsured * (_Rate / 1000));
                                            _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                            _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                            _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }

                                #endregion PA_to_Driver
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Conductor || _MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Conductor_RSD)
                            {
                                #region PA_to_Conductor
                                if (pHelperSuminsured > 0)
                                {
                                    if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Conductor_RSD  )
                                    {
                                        if (pExcludePool == 0)
                                        {
                                            DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                            if (drt.Length > 0)
                                            {
                                                _Sno++;
                                                _RskDesc = drt[0]["RiskDesc"].ToString();
                                                _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                                _Amount = (pHelperSuminsured * pNo_of_Helper * (_Rate / 1000));
                                                _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                                _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                                _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                                _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                                _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                                _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                                _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                        if (drt.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                            _Amount = (pHelperSuminsured * pNo_of_Helper * (_Rate / 1000));
                                            _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                            _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                            _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }

                                #endregion PA_to_Conductor
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Cleaner || _MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Cleaner_RSD)
                            {
                                #region PA_to_Cleaner
                                //if (pHelperSuminsured > 0)
                                //{
                                //    if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_to_Cleaner_RSD)
                                //    {
                                //        if (pExcludePool == 0)
                                //        {
                                //            DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                //            if (drt.Length > 0)
                                //            {
                                //                _Sno++;
                                //                _RskDesc = drt[0]["RiskDesc"].ToString();
                                //                _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                //                _Amount = (pHelperSuminsured * pNo_of_Helper * (_Rate / 1000));
                                //                _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                //                _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                //                _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                //                _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                //                _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                //                _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                //                _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                //                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, _Amount, _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                //            }
                                //        }
                                //    }
                                //    else
                                //    {
                                //        DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                //        if (drt.Length > 0)
                                //        {
                                //            _Sno++;
                                //            _RskDesc = drt[0]["RiskDesc"].ToString();
                                //            _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                //            _Amount = (pHelperSuminsured * pNo_of_Helper * (_Rate / 1000));
                                //            _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                //            _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                //            _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                //            _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                //            _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                //            _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                //            _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                //            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, _Amount, _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                //        }
                                //    }
                                //}

                                #endregion PA_to_Cleaner
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Other_SI || _MotRiskSn == (int)Enum_Mot_Rsk.Other_SI_RSD)
                            {
                                #region Other_SI
                                if (pOtherSI > 0)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        _Sno++;
                                        _RskDesc = drt[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                        _Amount = (pOtherSI * (_Rate / 1000));
                                        _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, _Amount, _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }

                                #endregion Other_SI
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_Passenger || _MotRiskSn == (int)Enum_Mot_Rsk.PA_Passenger_RSD)
                            {
                                #region PA_Passenger
                                if (pPassengerSuminsured > 0)
                                {
                                    if (_MotRiskSn == (int)Enum_Mot_Rsk.PA_Passenger_RSD  )
                                    {
                                        if (pExcludePool == 0)
                                        {
                                            DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                            if (drt.Length > 0)
                                            {
                                                _Sno++;
                                                _RskDesc = drt[0]["RiskDesc"].ToString();
                                                _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                                _Amount = (pPassengerSuminsured * pNo_of_Passenger * (_Rate / 1000));
                                                _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                                _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                                _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                                _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                                _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                                _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                                _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                                dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                        if (drt.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                            _Amount = ClsConvertTo.Decimal(drt[0]["Amount"]);
                                            if (_Amount <= 0)
                                                _Amount = (pPassengerSuminsured * pNo_of_Passenger * (_Rate / 1000));
                                            _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                            _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                            _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }

                                #endregion PA_Passenger
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.No_Claim_Discount)
                            {
                                #region No_Claim_Discount
                                if (pNCD > 0)
                                {
                                    decimal _tempPrem = 0;
                                    _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        int i = 0;
                                        for (i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pNCD == ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                break;
                                            }
                                            else if (pNCD > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _Amount = (_tempPrem * (_Rate / 100));
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, _Amount, _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }
                                #endregion No_Claim_Discount
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.RSD || _MotRiskSn == (int)Enum_Mot_Rsk.Terrorism)
                            {
                                #region Terrorism
                                if (pExcludePool == 0)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        _Sno++;
                                        _RskDesc = drt[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                        _Amount = ((pSuminsured + pOtherSI) * (_Rate / 100));
                                        _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }
                                #endregion Terrorism
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Government_Discount)
                            {
                                #region Government_Discount
                                decimal _tempPrem = 0;
                                _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);
                                DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                if (drt.Length > 0)
                                {
                                    _Sno++;
                                    _RskDesc = drt[0]["RiskDesc"].ToString();
                                    _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                    _Amount = (_tempPrem * (_Rate / 100));
                                    _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                    _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                    _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                    _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                    //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                    _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                    _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                }
                                #endregion Government_Discount
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Third_Party)
                            {
                                #region Third_Party

                                DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                if (drt.Length > 0)
                                {
                                    int i = 0;
                                    for (i = 0; i <= drt.Length - 1; i++)
                                    {
                                        if (pCC_HP_SEATS > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                        {
                                            _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                        }
                                        else
                                        {
                                            _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            break;
                                        }
                                    }

                                    DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                    if (drt1.Length > 0)
                                    {
                                        _Sno++;
                                        _RskDesc = drt1[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                        _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]);
                                        _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }

                                #endregion Third_Party
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Trailor_Third_Party)
                            {
                                #region Trailor_Third_Party
                                if (pOtherSI > 0)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        int i = 0;
                                        for (i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pCC_HP_SEATS > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                            else
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                break;
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]);
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }
                                #endregion Trailor_Third_Party
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Third_Party_NCD)
                            {
                                #region Third_Party_NCD
                                if (pNCD > 0)
                                {
                                    decimal _tempPrem = 0;
                                    _tempPrem = FxGetThirdPartyPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        int i = 0;
                                        for (i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pNCD == ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                                break;
                                            }
                                            else if (pNCD > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _Amount = (_tempPrem * (_Rate / 100));
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }
                                #endregion Third_Party_NCD
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Discount_as_per_CC)// or capacity discount
                            {
                                #region Discount_as_per_CC

                                decimal _PrevCC = 0;
                                DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                if (drt.Length > 0)
                                {
                                    int i = 0;
                                    for (i = 0; i <= drt.Length - 1; i++)
                                    {
                                        if (_PrevCC < pCC_HP_SEATS && pCC_HP_SEATS <= ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                        {
                                            _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                        }
                                        else if (_PrevCC < pCC_HP_SEATS && pCC_HP_SEATS > ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                        {
                                            _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                        }
                                        else if (pCC_HP_SEATS == 0 && pCC_HP_SEATS == ClsConvertTo.Decimal(drt[i]["tariff"].ToString()) && pVehicleControlCategoryid == (int)Enum_MotorCategory.Luxury_Car)
                                        {

                                        }
                                        _PrevCC = _tariff;
                                    }

                                    DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                    if (drt1.Length > 0)
                                    {
                                        _Sno++;
                                        _RskDesc = drt1[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                        _Amount = ClsConvertTo.Decimal(drt1[0]["Amount"]);
                                        _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }

                                #endregion Discount_as_per_CC
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Corporate_or_Special_Discount)
                            {
                                #region Corporate_or_Special_Discount
                                if (!pHasAgent)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        decimal _tempPrem = 0;
                                        _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                        _Sno++;
                                        _RskDesc = drt[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                        _Amount = (_tempPrem * (_Rate / 100));
                                        _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }
                                #endregion Corporate_or_Special_Discount
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Towing_Charge)
                            {
                                #region Towing_Charge
                                if (pIncludetowing == 1)
                                {
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        decimal _tempPrem = 0;
                                        _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                        _Sno++;
                                        _RskDesc = drt[0]["RiskDesc"].ToString();
                                        _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                        _Amount = ClsConvertTo.Decimal(drt[0]["Amount"]);
                                        _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                        _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                        _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                        _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                        //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                        _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                        //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                        _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                        _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                        dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                    }
                                }
                                #endregion Towing_Charge
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Trailor_Capacity_Discount)
                            {
                                #region Trailor_Capacity_Discount
                                DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                if (drt.Length > 0)
                                {
                                    decimal _tempPrem = 0;
                                    _tempPrem = FxGetTrailorPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);

                                    _Sno++;
                                    _RskDesc = drt[0]["RiskDesc"].ToString();
                                    _Rate = ClsConvertTo.Decimal(drt[0]["Rate"]);
                                    _Amount = (_tempPrem * (_Rate / 100));
                                    _RiskCode = drt[0]["RSKCOVERCODE"].ToString();
                                    _NatPerils = ClsConvertTo.Int32(drt[0]["NATPERILS"]);
                                    _Mot_risk_sno = ClsConvertTo.Int32(drt[0]["MOT_RISK_SN"]);
                                    _IgnoreComm = ClsConvertTo.Int32(drt[0]["IgnoreComm"]);
                                    //_PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    //_addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    //_RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                    _PremCat = ClsConvertTo.Int32(drt[0]["PremiumCategory"]);
                                    //_riskCat = ClsConvertTo.Int32(drt[0]["RISKCATEGORY"]);
                                    _addMode = ClsConvertTo.Int32(drt[0]["ADDMODE"]);
                                    _RskSerialNo = ClsConvertTo.Int32(drt[0]["RskSerialNo"]);
                                    dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                }

                                #endregion Trailor_Capacity_Discount
                            }
                            else if (_MotRiskSn == (int)Enum_Mot_Rsk.Discount_on_Suminsured)
                            {
                                #region Third_Party_NCD
                                if (pClassid == (int)Enum_Class.Private_Vehicle)
                                {
                                    decimal _tempPrem = 0;
                                    _tempPrem = FxGetBasicPremium(ClsConvertTo.String(dr["RskSerialNo"]), dtTemp);
                                    DataRow[] drt = dtFilter.Select("RSKCOVERCODE = " + dr["RiskCoverCode"].ToString(), "Tariff asc");
                                    if (drt.Length > 0)
                                    {
                                        int i = 0;
                                        for (i = 0; i <= drt.Length - 1; i++)
                                        {
                                            if (pSuminsured >= ClsConvertTo.Decimal(drt[i]["tariff"].ToString()))
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                            else
                                            {
                                                _tariff = ClsConvertTo.Decimal(drt[i]["tariff"].ToString());
                                            }
                                        }

                                        DataRow[] drt1 = dtFilter.Select("(RSKCOVERCODE = " + dr["RiskCoverCode"].ToString() + " and tariff = " + _tariff + ")");
                                        if (drt1.Length > 0)
                                        {
                                            _Sno++;
                                            _RskDesc = drt1[0]["RiskDesc"].ToString();
                                            _Rate = ClsConvertTo.Decimal(drt1[0]["Rate"]);
                                            _Amount = (_tempPrem * (_Rate / 100));
                                            _RiskCode = drt1[0]["RSKCOVERCODE"].ToString();
                                            _NatPerils = ClsConvertTo.Int32(drt1[0]["NATPERILS"]);
                                            _Mot_risk_sno = ClsConvertTo.Int32(drt1[0]["MOT_RISK_SN"]);
                                            _IgnoreComm = ClsConvertTo.Int32(drt1[0]["IgnoreComm"]);
                                            //_PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            //_RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            //dtTemp.Rows.Add(_Sno, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount) _RiskCode, _NatPerils, _Mot_risk_sno, _IgnoreComm, _PremCat, _addMode, _RskSerialNo);
                                            _PremCat = ClsConvertTo.Int32(drt1[0]["PremiumCategory"]);
                                            //_riskCat = ClsConvertTo.Int32(drt1[0]["RISKCATEGORY"]);
                                            _addMode = ClsConvertTo.Int32(drt1[0]["ADDMODE"]);
                                            _RskSerialNo = ClsConvertTo.Int32(drt1[0]["RskSerialNo"]);
                                            dtTemp.Rows.Add(_Sno, _RiskCode, _RskDesc, _Rate, ClsCommon.Rounding(pClassid, _Amount), _PremCat, _IgnoreComm, _NatPerils, _addMode, _Mot_risk_sno, _RskSerialNo);
                                        }
                                    }
                                }
                                #endregion Third_Party_NCD

                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        protected decimal FxGetBasicPremium(string prmRiskSno, DataTable dtTemp)
        {
            DataTable dt = new DataTable();
            dt = dtTemp;
            DataRow[] dr = dt.Select("RskSerialNo < " + prmRiskSno + " and CATID = 1 ");
            int _addMode = 0;
            decimal _Amount = 0;
            for (int i = 0; i <= dr.Length - 1; i++)
            {
                _addMode = ClsConvertTo.Int32(dr[i]["addmode"]);
                if (_addMode == 1)
                    _Amount = _Amount + ClsConvertTo.Decimal(dr[i]["Amount"]);
                else
                    _Amount = _Amount - ClsConvertTo.Decimal(dr[i]["Amount"]);
            }            
            return _Amount;
        }
        protected decimal FxGetPoolPremium(string prmRiskSno, DataTable dtTemp)
        {
            DataTable dt = new DataTable();
            dt = dtTemp;
            DataRow[] dr = dt.Select("RskSerialNo < " + prmRiskSno + " and CATID = 6 ");
            int _addMode = 0;
            decimal _Amount = 0;
            for (int i = 0; i <= dr.Length - 1; i++)
            {
                _addMode = ClsConvertTo.Int32(dr[i]["addmode"]);
                if (_addMode == 1)
                    _Amount = _Amount + ClsConvertTo.Decimal(dr[i]["Amount"]);
                else
                    _Amount = _Amount - ClsConvertTo.Decimal(dr[i]["Amount"]);
            }
            //txtRiskPoolPrem.Text = _addMode.ToString();
            return _Amount;
        }
        protected decimal FxGetThirdPartyPremium(string prmRiskSno, DataTable dtTemp)
        {
            DataTable dt = new DataTable();
            dt = dtTemp;
            DataRow[] dr = dt.Select("RskSerialNo < " + prmRiskSno + " and CATID = 2 ");
            int _addMode = 0;
            decimal _Amount = 0;
            for (int i = 0; i <= dr.Length - 1; i++)
            {
                _addMode = ClsConvertTo.Int32(dr[i]["addmode"]);
                if (_addMode == 1)
                    _Amount = _Amount + ClsConvertTo.Decimal(dr[i]["Amount"]);
                else
                    _Amount = _Amount - ClsConvertTo.Decimal(dr[i]["Amount"]);
            }
            //txtRiskThirdparty.Text = _addMode.ToString();
            return _Amount;
        }
        protected decimal FxGetTrailorPremium(string prmRiskSno, DataTable dtTemp)
        {
            DataTable dt = new DataTable();
            dt = dtTemp;
            DataRow[] dr = dt.Select("RskSerialNo < " + prmRiskSno + " and CATID = 7 ");
            int _addMode = 0;
            decimal _Amount = 0;
            for (int i = 0; i <= dr.Length - 1; i++)
            {
                _addMode = ClsConvertTo.Int32(dr[i]["addmode"]);
                if (_addMode == 1)
                    _Amount = _Amount + ClsConvertTo.Decimal(dr[i]["Amount"]);
                else
                    _Amount = _Amount - ClsConvertTo.Decimal(dr[i]["Amount"]);
            }
            //txtRiskThirdparty.Text = _addMode.ToString();
            return _Amount;
        }

        public int GetMotorCalcType(int categoryid)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@categoryid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(categoryid);
            DataTable dt = objCmn.GetTable("uw_MotorCalcType_get", "sp", sqlparam);
            if(dt!=null)
            {
                if(dt.Rows.Count>0)
                {
                    return ClsConvertTo.Int32(dt.Rows[0]["calcType"].ToString());
                }
            }
            return 0;
        }
    }
        
}