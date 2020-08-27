using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Common
{
    public enum Enum_Company
    {
        NATIONAL = 1,
        PICL = 2,
        NLGI = 3,
        SIDD = 4,
        GIC = 5,
        SANIMA = 6,
        AJOD = 7
    }
    #region Enum for Department_and_class
    public enum Enum_Department
    {
        FIRE = 1,
        MOTOR = 2,
        MARINE = 3,
        MISCELLANEOUS = 4,
        ENGINEERING = 5,
        AVIATION = 6,
        AGRICULTURE = 7,
        MICRO = 8,
        HEALTH_INSURANCE = 9
    }
    #region Enum for Classes
    public enum Enum_Class_Fire
    {
        Industrial_Risk = 1,
        Commercial_Risk = 2,
        Lop_Industrial_or_Commercial_Risk = 3,
        Non_Industrial_N_Non_Commercial_Risk = 4,
        Traders_Comprehensive = 5,
        HouseHold_Insurance = 6,
        General_Fire = 7,
        Fire_Consequential_Loss = 8,
        Banker = 9,
        Stock = 10,
        Loss_of_Profit = 11,
        House = 12,
        Burglary = 13,
        Gharsangsar = 14
    }
    public enum Enum_Class_Motor
    {
        MotorCycle = 21,
        Commercial = 22,
        Private = 23,
        Motor_Third_Party = 24,
        Taxi = 25,
        Third_Party_Only_I = 26,
        Third_Party_Only_CV = 27,
        Third_Party_Only_PC = 28,
        Third_Party_Only_II = 29,
        Third_Party_Only_CV_I = 30,
        Third_Party_Only_PC_I = 201
    }
    public enum Enum_Class_Marine
    {
        Overseas_Transit = 31,
        Overseas_Transit_Open_Policy = 32,
        Overseas_and_Inland_Transit_Open_Policy = 33,
        Duty_Insurance = 34,
        Marine = 35,
        Inland_Transit_Specific = 36,
        Air = 37,
        Inland_Transit_Open_Policy = 38,
        Marine_by_Land = 39,
        Marine_By_Sea = 40,
        Overseas_Marine_Open = 41,
        I_C_C_A = 42,
        I_C_C_B = 43,
        I_C_C_C = 44,
        I_T_C_A = 45
    }
    public enum Enum_Class_Misc
    {
        Professional_Indemnity = 51,
        Personal_Domiciliary_Hospitalization = 52,
        Personal_Accident = 53,
        Burglary_N_House_Breaking = 54,
        Fidelity_Guarantee = 55,
        Public_Liability = 56,
        Workman_Compensation = 57,
        Group_Personal_Accident = 58,
        Group_Domiciliary_Hospitalization_Mediclaim = 59,
        Bankers_Blanket = 60,
        All_Risk = 61,
        Travel_Overseas_Medical_Insurance = 62,
        Cash_in_Transit_others = 63,
        Cash_in_Transit = 64,
        Product_Liability = 65,
        Baggage_Insurance = 66,
        Trekking = 67,
        Money = 68,
        Duty_Insurance = 69,
        Cover_Note = 70,
        Gold = 71,
        Strong_Room_Burglary = 72,
        Press_Accident = 73,
        Strong_Room_Fire = 74,
        Cash_Counter = 75,
        Vehicle_Personal_Accident = 76,
        Directors_and_Officers_Liability = 77,
        Householder_Insurance = 78,
        Individual_And_Group_Mobile = 79,
        Pedal_Cycle = 80,
        Student_Safety_Insurance = 81,
        Sweet_Home = 82,
        Guarantee_Policy = 83,
        Stand_Alone_Policy = 84,
        Professional_Indemnity_Standard = 85,
        MoneyII = 86,
        Cashless_Medical_Insurance = 87,
        Group_Medical_Insurance_Domiciliary = 88,
        Group_Medical_Insurance_Hospitalization = 89,
        Group_Cum_Family_Hospitalization = 90,
        Travel_Medical_Insurance_For_Student = 301

    }
    public enum Enum_Class_Engg
    {
        Contractors_All_Risk = 91,
        Machinery_Breakdown_Insurance = 92,
        Erection_All_Risk = 93,
        Contractors_Plant_and_Machinary = 94,
        Electronic_Equipment_Insurance = 95,
        Boiler_and_Pressure_Plant = 96,
        Marine_cum_Erection = 97,
        Loss_Of_Profit_or_Consequential_loss = 98,
        Consequential_Loss = 99,
        Electronic_Equipments = 100,
        Industrial_All_Risk = 101,
        Deterioration_of_Stock = 102,
        Storage_cum_Erection = 103,
        CPM_CAR = 104,
        EEI03 = 105,
        Erection_All_Risk_CAR = 106,
        Mobile_Insurance = 107
    }
    public enum Enum_Class_Aviation
    {
        Aviation = 111,
        Loss_of_Lisence = 112,
        Hull_War_Risk = 113,
        Personal_Accident_Crew = 114
    }
    public enum Enum_Class_Agriculture
    {
        Fruit = 121,
        Tarkari_Bari = 122,
        Potato = 123,
        Crop = 124,
        Cattle = 125,
        Birds = 126,
        Fish = 127,
        Bee = 128,
        Ostrich = 129,
        Mushroom = 130,
        Banana = 131,
        Seeds = 132,
        Elephant_Horse = 133,
        Cash_Crop = 134,
        Herbs = 135,
        Buffalo = 136,
        Goats = 137,
        Pig = 138,
        Ukhu = 139,
        Alaichi = 140,
        General_Crop = 151,
        Dalhan = 152,
        Masala_Bali = 153
    }
    public enum Enum_Class_Micro
    {
        Micro_Personal_Accident = 141,
        Micro_Household = 142,
        Micro_Medical = 143
    }

    public enum Enum_Class_HealthInsurance
    {
        GME_Hospitalization = 401,
        GME_Domicillary = 402,
        Individual_Medical_Insurance = 403,
        Travel_Medical_Insurance = 404,
        Travel_Medical_Insurance_Student = 405,
        GME_Extra_Benefit = 406,
        GME_Day_Care = 407
    }
    #endregion Enum for Classes
    #endregion Enum for Department_and_class
    public enum Enum_ProformaTaskType
    {
        Edit = 1,
        Cancel = 2
    }
    public enum Enum_MotorCategory
    {
        Motor_Cycle = 1,
        Comercial = 2,
        Truck_Pick_up = 3,
        Bus = 4,
        Passenger_Bus = 5,
        Tanker = 6,
        Tempo = 7,
        Tractor = 8,
        Private_Car = 9,
        Luxury_Car = 10,
        Taxi = 11,
        Construction_Equipment_Vehicle = 13,
        Agriculture_or_Forestry_Vehicle = 14,
        Electric_Vehicle = 24
    }
    public enum Enum_MotoCalcType
    {
        CCHP = 1,
        PASSCAPACITY = 2,
        CARRYCAPACITY = 3
    }
    #region Document Type
    public enum Enum_DocType
    {
        Fresh = 11,
        Endoresment = 21,
        Renewal = 31
    }
    public enum Enum_EndorseType
    {
        Additional = 1,
        Refund = 2,
        Nil = 3,
        Cancellation = 4,
        Name_Transfer = 5
    }
    public enum Enum_SubEndorseType
    {
        Add_Agent = 1
    }
    #endregion Document Type

    public enum Enum_Collection_TransactionType
    {
        Premium_Collection = 81,
        Other_Collection = 82,
        Deposit = 3
    }

    public enum Enum_UserFor
    {
        Ensure = 0,
        TPCounter = 1,
        Both = 2
    }
    public enum Enum_DefaultLoginPage
    {
        Ensure = 0,
        TPCounter = 1
    }
    public enum Enum_PrinterType
    {
        Laser = 0,
        Epson = 1
    }
    public enum Enum_KycValitateOption
    {
        NoValidation = 0,
        Citizenship = 1,
        Panno = 2
    }
    public enum Enum_CoverType
    {
        Individual = 1,
        Family = 2,
        Ski_ing = 3
    }
    public enum Enum_PolicyVault
    {
        RI_Vault = 1,
        Old_Vehicl_Vault = 2
    }
    public enum Enum_rounding
    {
        Normal = 0,
        Floor = 1,
        Ceil = 2
    }
    public enum Enum_ClaimMode
    {
        Entry = 0,
        Edit = 1,
        Supplementry = 2
    }

    public enum Enum_InsuredFlagType
    {
        Lock = 1,
        Suspicious = 2
    }

    public enum Enum_DefaultBankModule
    {
        Credit_Advice = 1,
        Bank_Deposit = 2,
        Commision_Payment = 3,
        Claim_Payment = 4,
        Collection = 5,
        Others = 6,
        Creditnote_Payment = 7,
        Purchase_entry = 11,
        Survey_Fee_Payment = 10
    }

    public enum Enum_ReportsOthers
    {
        REP,//RECEIPT
        VAT,//VAT
        DN,//DEBIT NOTE
        CN,//CREDIT NOTE
        OREP,//other RECEIPT
        OVAT,//other VAT
        REPVAT,// VAT + Receipt
        OREPVAT//other vat receipt
    }

    public enum Enum_UW_Reports
    {
        UW_TEMPLATES = 1,
        UW_TEMPLATES_DEBIT_ALL = 2,
        UW_TEMPLATES_POLICY_ALL = 3
    }

    public enum Enum_BackDateApproval
    {
        No_BackDateApproval = 0,
        Strict_Approval = 1,
        Flexible_Approval = 2
    }

    public enum Enum_SystemType
    {
        Normal_System = 1,
        Debit_Advice_System = 2,
        Tax_Invoice_System = 3
    }
    public enum Enum_BankDepositOption
    {
        Bank_Deposit_Module = 0,
        Collection_Module = 1
    }

    public enum Enum_PremiumType
    {
        Normal = 0,
        Short_Period = 1,
        Pro_Rate = 2
    }
    public enum Enum_PremiumCatagory
    {
        Basic_Premium = 1,
        ThirdParty_Premium = 2,
        Driver_Premium = 3,
        Helpers_Premium = 4,
        Passanger_Premium = 5,
        RSD_Premium = 6,
        Trailor_Premium = 7,
    }

    public enum Enum_BillType
    {
        Tax_Invoice_No = 0,
        Debit_Note = 1,
        Credit_Note = 2
    }

    public enum Enum_BusiType
    {
        New_Business = 1,
        Outward_CoInsurance = 2,
        Inward_CoInsurance = 3,
        Declaration_Policy = 4,
        Inward_Policy = 5,
        Inward_CoInsurance_Declaration = 9,
        Outward_CoInsurance_Declaration = 10
    }

    public enum Enum_PayType
    {
        Premium_Collection = 0,
        Other_Cllection = 2,
        Deposit = 3
    }

    public enum Enum_Declaration_Type
    {
        None = 1,
        SeventyFive_Percent = 2,
        Hundred_Percent = 3,
        Actual = 4,
        Fifty_Percent = 5
    }

    public enum Enum_ClaimStatus
    {
        REGISTERED = 1,
        SURVEYOR_DEPUTED = 2,
        CLAIM_PROCESSING = 3,
        APPROVED = 4,
        DV_SENT_TO_CLIENT = 5,
        DV_SIGNED_FROM_CLIENT = 6,
        FORWARDED_TO_RI = 7,
        FORWARDED_TO_ACCOUNT = 8,
        SETTLED = 9,
        WITHDRAWN = 10,
        SETTLED_SF_APPROVAL = 11,
        SURVEY_FEE_SETTLEMENT = 12
    }
    public enum Enum_ClaimLossType
    {
        Own_Damage = 1,
        Third_Party = 2
    }

    public enum Enum_RiTypes
    {
        RETENTION = 1,
        QUOTA = 2,
        SURPLUS_I = 3,
        SURPLUS_II = 4,
        FACULTATIVE = 5,
        NEPAL_REINSURANCE = 6,
        AUTO_FAC = 7,
        MKT_POOL = 99
    }
    public enum Enum_Sms_Type
    {
        Renew = 1,
        Claim_ClientPin = 2,
        Claim_Client = 3,
        Claim_Client_SurvDepNotify = 4,
        Claim_Client_DocReminder = 5,
        Claim_Client_DocReminder_Final = 6,
        Claim_Client_Approval = 7,
        Claim_Client_DVIssue = 8,
        Claim_Client_Settle = 9,
        Claim_Client_AdvApproval = 10,
        Claim_Client_AdvSettle = 11,
        Claim_Client_Close = 12,
        Claim_SurveyorPin = 13,
        Claim_Surveyor = 14,
        Claim_Surveyor_Approval = 15,
        Claim_Surveyor_Settle = 16
    }
    public enum Enum_Client_UserType
    {
        Client = 0,
        Surveyor = 1
    }
    public enum Enum_PremiumPaid
    {
        UNPAID = 0,
        PAID = 1,
        PAID_VIA_CREDITNOTE = 2,// IN CASE OF REFUND/CANCELLATION
        PARTIALLY_PAID = 3
    }

    public enum Enum_CommissionPaid
    {
        UNPAID = 0,
        PAID = 1,
        ADJUSTED = 2
    }

    public enum Enum_ModuleName
    {
        GENERAL_REPORT = 1,
        CLAIM_REPORT = 2,
        RI_REPORT = 3
    }
    public enum Enum_RiskBreakType
    {
        NORMAL = 0,
        POOL = 1,
        THIRDPARTY = 2
    }

    public enum Enum_Mot_Risk_SN
    {
        Basic_Premium = 1,
        Additional_Premium = 2,
        Trailor = 3,
        Manufacture_Year = 4,
        Own_Goods_Carrying = 5,
        Excess_own_damage = 6,
        Fleet_Discount = 7,
        PA_to_Driver = 8,
        PA_to_Driver_Rsd = 16,
        PA_to_Conductor = 9,
        PA_to_Conductor_RSD = 17,
        PA_to_Cleaner = 10,
        PA_to_Cleaner_RSD = 18,
        Other_SI = 11,
        Other_SI_RSD = 19,
        PA_Passenger = 12,
        PA_Passenger_RSD = 20,
        No_Claim_Discount = 13,
        RSD = 14,
        Terrorism = 15,
        Government_Discount = 21,
        Third_Party = 22,
        Third_Party_NCD = 23,
        Discount_as_per_CC = 24,
        Corporate_or_Special_Discount = 25,
        Towing_Charge = 26,
        Trailor_Capacity_Discount = 27,
        Trailor_Third_Party = 28,
        Discount_on_Suminsured = 29,
        Rent_for_private_use = 30,
        Capacity_Loading = 31,
        Staff_Discount = 32,
        Transfer_Fee = 33,
        Pound_Premium = 34,
        Minimum_Premium = 35,
        Accidental_Risk = 36
    }

    #region security
    public enum Enum_ModuleGroup
    {
        Setup = 1,
        Underwriting = 2,
        Claim = 3,
        Re_insurance = 4,
        Account = 5,
        Others = 6,
        Underwriting_Reports = 7,
        Re_insurance_Reports = 8,
        Claim_Reports = 9,
        Account_Reports = 10,
        Tools = 11,
        Reports = 12,
        Security = 13,
        HR = 14,
        Control_Panel = 15
    }
    #region module name
    public enum Enum_ModuleName_Setup
    {
        Underwriting_Setup = 1,
        Officer_Information = 2,
        Special_Client_Information = 3,
        User_Entry = 4,
        Fire_Identification = 5,
        Reinsurance_Setup = 6,
        Printing_Matters = 7,
        Claim_Setup = 8,
        Motor_Identification = 9,
        Motor_Tariff = 10,
        Marketting_Target_Setup = 11,
        Policy_Search_Popup_Menu = 12,
        Calender_Setup = 13,
        Nepali_Calender_Setup = 14,
        Payroll_Setup = 15,
        Policy_Issue_Block = 16,
        Classwise_Policy_Issue_Block = 17,
        Stamp_setup = 18,
        Area_Setup = 19,
        Motor_Setup = 20,
        Account_Setup = 21,
        Company_Setup = 22
    }
    public enum Enum_ModuleName_Underwriting
    {
        Policy_Issue = 1,
        Renewal_Notice = 2,
        Policy_Bill_Print = 3,
        Policy_Lock = 4,
        TMI_Calculation = 5
        //FxDeleteModuleName VModname, =1,Fire=1,
        //FxDeleteModuleName VModname, =1,Motor=1,
        //FxDeleteModuleName VModname, =1,Marine=1,
        //FxDeleteModuleName VModname, =1,Miscellaneous=1,
    }
    public enum Enum_ModuleName_Claim
    {
        Claim_Registration = 1,
        Claim_RI_Approval = 2,
        Claim_Approval = 3,
        Claim_Account_Settlement = 4,
        Force_Claim_Register = 5,
        Claim_Withdraw = 6,
        Claim_Search_Popup_Menu = 7,
        Surveyor_Deputation = 8,
        Claim_Assesment_Fire = 9,
        Claim_Assesment_Motor = 10,
        Claim_Assesment_Marine = 11,
        Claim_Assesment_Medical = 12,
        Claim_Assesment_PA_GPA = 13,
        Claim_Discharge_Voucher = 14,
        Claim_Advance_Payment = 15,
        Claim_Unlock = 16,
        Claim_Assignment = 17,
        Claim_Document_Submission = 18,
        Claim_SurveyorFee_Approval = 19,
        Claim_SurveyorFee_Settlement = 20
    }
    public enum Enum_ModuleName_Re_insurance
    {
        Inward_Facultative = 1,
        Treaty = 2,
        RI_Premium_Distribution = 3,
        Declaration_Entry = 4,
        Preview_Renewal_List = 5,
        Generate_RI_Break_Down = 6
    }
    public enum Enum_ModuleName_Account
    {
        Collection = 1,
        Commission_Paid = 2,
        Creditnotepayment = 3,
        Deposit = 4,
        Deposit_Adjustment = 5,
        Bank_Deposit = 6,
        Premium_Commission_Booked_Voucher = 7,
        Vatno_Cancellation = 8,
        Receiptno_Cancellation = 9,
        Generate_Voucher = 10,
        Voucher_Entry = 11,
        Voucher_Listing = 12,
        Transfer_Opening_Balance = 13,
        Account_Head_Creation = 14,
        Account_Chart_Definition = 15,
        Account_Head_Transfer = 16,
        Cheque_Bounce_Entry = 17,
        Disbursement = 32
    }
    public enum Enum_ModuleName_Others
    {
        Back_Up = 1,
        Policy_Search = 2,
        Debit_Advice_Search = 3,
        Claim_Search = 4,
        Policy_Print = 5,
        Security = 6,
        Branch_Option = 7,
        Renewal_Search = 8,
        Report_Search = 9,
        Customer_Search = 10,
        Collection_Search = 11,
        Email = 13,
        Attach_Document = 14,
        Quotation = 15,
        Document_Management = 16,
        Policy_Vault = 17,
        Disbursement_Search = 18
    }
    public enum Enum_ModuleName_Underwriting_Reports
    {
        Underwriting_Reports = 1,
        Renewal_Reports = 2,
        Collection_Reports = 3,
        Agency_Reports = 4,
        Outstanding_Reports = 5,
        MIS_Reports = 6,
        Money_Laundering_Reports = 7,
        Other_MIS_Reports = 8
    }
    public enum Enum_ModuleName_Re_insurance_Reports
    {
        Bordereau = 1,
        Market_Pool = 2,
        Local_Facultative = 3,
        Accounts = 4,
        Summary_Report = 5,
        Beema_Samati_Report = 6,
        Risk_Profile = 7,
        Mediclaim_Reports = 8
    }
    public enum Enum_ModuleName_Claim_Reports
    {
        Claim_Register = 1,
        Claim_OSPaid_Reports = 2,
        Claim_RI_Reports = 3,
        Claim_Withdraw_Reports = 4

        //FxDeleteModuleName VModname, =1,Incurred claim Reports=1,
        //FxDeleteModuleName VModname, =1,Claim Summary Reports=1,
    }
    public enum Enum_ModuleName_Account_Reports
    {
        Ledger = 1,
        Trial_Balance = 2,
        Category_Report = 3
    }
    public enum Enum_ModuleName_Tools
    {
        Update_Policy = 1
    }
    public enum Enum_ModuleName_Reports
    {
        Business_Summary_ConSole_Bordereau = 1,
        Partywise_Business_Summary = 2,
        KYC_REPORT = 3
    }
    public enum Enum_ModuleName_Security
    {
        Lock = 1,
        Log = 2,
        Page = 3,
        User_Security = 4,
        Setting = 5
    }
    public enum Enum_ModuleName_HR
    {
        Staff_Information = 1,
        Staff_Search = 2,
        Staff_Department = 3,
        Staff_Post = 4,
        Staff_Designation = 5
    }
    public enum Enum_ModuleName_ControlPanel
    {
        Control_Panel_Setting = 1
    }
    #endregion module name
    #region security name
    #region setup
    public enum Enum_Security_Setup_Underwriting_Setup
    {
        Department_Add = 1,
        Department_Edit = 2,
        Department_Delete = 3,

        Branch_Add = 4,
        Branch_Edit = 5,
        Branch_Delete = 6,

        Document_Type_Add = 7,
        Document_Type_Edit = 8,
        Document_Type_Delete = 9,

        Endorse_Type_Add = 10,
        Endorse_Type_Edit = 11,
        Endorse_Type_Delete = 12,

        Claim_Causes_Add = 13,
        Claim_Causes_Edit = 14,
        Claim_Causes_Delete = 15,

        Business_Type_Add = 16,
        Business_Type_Edit = 17,
        Business_Type_Delete = 18,

        Fiscal_Year_Add = 19,
        Fiscal_Year_Edit = 20,
        Fiscal_Year_Delete = 21,

        VAT_Add = 22,
        VAT_Edit = 23,
        VAT_Delete = 24,

        NCD_Rates_Add = 25,
        NCD_Rates_Edit = 26,
        NCD_Rates_Delete = 27,

        Co_Insurance_Add = 28,
        Co_Insurance_Edit = 29,
        Co_Insurance_Delete = 30,

        Business_Occupancy_Add = 31,
        Business_Occupancy_Edit = 32,
        Business_Occupancy_Delete = 33,

        Geographical_Region_Add = 34,
        Geographical_Region_Edit = 35,
        Geographical_Region_Delete = 36,

        Risk_Cover_Add = 37,
        Risk_Cover_Edit = 38,
        Risk_Cover_Delete = 39,

        Class_Add = 40,
        Class_Edit = 41,
        Class_Delete = 42,

        OMC_TI_Add = 43,
        OMC_TI_Edit = 44,
        OMC_TI_Delete = 45,

        Country_Add = 46,
        Country_Edit = 47,
        Country_Delete = 48,

        Add_Customer_Add = 49,
        Add_Customer_Edit = 50,
        Add_Customer_Delete = 51,

        Compulsary_Excess_Add = 52,
        Compulsary_Excess_Edit = 53,
        Compulsary_Excess_Delete = 54,

        Government_Anudan_Add = 55,
        Government_Anudan_Edit = 56,
        Government_Anudan_Delete = 57,

        Income_Source_Add = 58,
        Income_Source_Edit = 59,
        Income_Source_Delete = 60,

        MarketingOfficer_BusinessTarget_Add = 61,
        MarketingOfficer_BusinessTarget_Edit = 62,
        MarketingOfficer_BusinessTarget_Delete = 63,

        Short_Period_Add = 64,
        Short_Period_Edit = 65,
        Short_Peroid_Delete = 66,

        Tariff_Setup_Add = 67,
        Tariff_Setup_Edit = 68,
        Tariff_Setup_Delete = 69,

        Printing_Matters_Add = 70,
        Printing_Matters_Edit = 71,
        Printing_Matters_Delete = 72,

        Risk_Cover_Mapping_Add = 73,
        Risk_Cover_Mapping_Edit = 74,
        Risk_Cover_Mapping_Delete = 75,

        Sub_Branch_Add = 76,
        Sub_Branch_Edit = 77,
        Sub_Branch_Delete = 78,

        Designationwise_Apprvl_Lmt_Add = 79,
        Designationwise_Apprvl_Lmt_Edit = 80,
        Designationwise_Apprvl_Lmt_Delete = 81,


        Userwise_Apprvl_Lmt_Add = 140,
        Userwise_Apprvl_Lmt_Edit = 141,
        Userwise_Apprvl_Lmt_Delete = 142,

        Insured_Type_Add = 82,
        Insured_Type_Edit = 83,
        Insured_Type_Delete = 84,

        Printing_History = 85,

        Printing_Options = 86,

        Policy_Re_Print_Approval = 87,
        VATBill_Re_Print_Approval = 88,
        Receipt_Re_Print_Approval = 89,

        Required_Document_Add = 90,
        Required_Document_Edit = 91,
        Required_Document_Delete = 92,

        //Stamp_Duty_Add = 93,
        //Stamp_Duty_Edit = 94,
        //Stamp_Duty_Delete = 95,

        Fiscal_Year_Indian_Add = 93,
        Fiscal_Year_Indian_Delete = 94,
        Fiscal_Year_Indian_Edit = 95,

        Template_Setup_Add = 96,
        Template_Setup_Delete = 97,

        Template_Mapping_Add = 98,
        Template_Mapping_Delete = 99,

        Page_Setup_Add = 100,
        Page_Setup_Delete = 101,

        Page_Mapping_Add = 102,
        Page_Mapping_Delete = 103,

        CAR_Principal_Add = 104,
        CAR_Principal_Edit = 105,
        CAR_Principal_Delete = 106,


        CAR_Department_Add = 107,
        CAR_Department_Edit = 108,
        CAR_Department_Delete = 109,

        Stamp_Duty_Add = 110,
        Stamp_Duty_Delete = 111,
        Stamp_Duty_Edit = 112,

        Risk_Cover_Setting_Add = 113,
        Risk_Cover_Setting_Edit = 115,
        Risk_Cover_Setting_Delete = 114,


        BranchWiseTarget_Setup_Add = 116,
        BranchWiseTarget_Setup_Edit = 118,
        BranchWiseTarget_Setup_Delete = 117,
        BranchWiseTarget_Setup_Export = 120,
        BranchWiseTarget_Setup_Search = 119,

        SubjectMatter_Of_Insurance_Add = 121,
        SubjectMatter_Of_Insurance_Delete = 122,
        SubjectMatter_Of_Insurance_Edit = 123,

        Means_Of_Convience_Add = 124,
        Means_Of_Convience_Delete = 125,
        Means_Of_Convience_Edit = 126,

        Farming_Type_Add = 127,
        Farming_Type_Edit = 128,
        Farming_Type_Delete = 129,

        Breed_Type_Add = 130,
        Breed_Type_Edit = 131,
        Breed_Type_Delete = 132,


        TemplateTypeSetup_Add = 104,
        TemplateTypeSetup_Edit = 105,
        TemplateTypeSetup_Delete = 106,

        SpecialClient_new_Add = 107,
        SpecialClient_new_Edit = 108,
        SpecialClient_new_Delete = 109,

        Policy_Risk_Type_Add = 110,
        Policy_Risk_Type_Edit = 111,
        Polic_Risk_Type_Delete = 112,

        Hospital_Add = 113,
        Hospital_Edit = 114,
        Hospital_Delete = 115,

        Other_Report_Setup_Add = 197,
        Other_Report_Setup_Edit = 198,
        Other_Report_Setup_Delete = 199,


    }
    public enum Enum_Security_Setup_Officer_Information
    {
        Agent_Add = 1,
        Agent_Edit = 2,
        Agent_Delete = 3,

        Agent_Commission_Add = 4,
        Agent_Commission_Edit = 5,
        Agent_Commission_Delete = 6,

        Field_Officer_Add = 7,
        Field_Officer_Edit = 8,
        Field_Officer_Delete = 9,

        Marine_Surveyor_Agent_Add = 10,
        Marine_Surveyor_Agent_Edit = 11,
        Marine_Surveyor_Agent_Delete = 12,

        Sub_Agent_Add = 13,
        Sub_Agent_Edit = 14,
        Sub_Agent_Delete = 15,

        Surveyor_Add = 16,
        Surveyor_Edit = 17,
        Surveyor_Delete = 18,

        Sub_Field_Officer_Add = 19,
        Sub_Field_Officer_Edit = 20,
        Sub_Field_Officer_Delete = 21


    }
    public enum Enum_Security_Setup_Special_Client_Information
    {
        Bank_Add = 1,
        Bank_Edit = 2,
        Bank_Delete = 3,
        Bank_View = 4,

        Branch_Add = 5,
        Branch_Edit = 6,
        Branch_Delete = 7,
        Branch_View = 8
    }
    public enum Enum_Security_Setup_User_Entry
    {
        User_Add = 1,
        User_Edit = 2,

        User_Group_Add = 3,
        User_Group_Edit = 4,
        User_Group_Delete = 5,

        Change_Password = 6,
        User_List_Add = 7
    }
    public enum Enum_Security_Setup_Fire_Identification
    {
        Class_Of_Construction_Add = 1,
        Class_Of_Construction_Edit = 2,
        Class_Of_Construction_Delete = 3,

        Fire_Appliance_Add = 4,
        Fire_Appliance_Edit = 5,
        Fire_Appliance_Delete = 6,

        Nature_Of_Occupancy_Add = 7,
        Nature_Of_Occupancy_Edit = 8,
        Nature_Of_Occupancy_Delete = 9,

        Occupancy_Add = 10,
        Occupancy_Edit = 11,
        Occupancy_Delete = 12,

        category_Add = 13,
        category_Edit = 14,
        category_Delete = 15


    }
    public enum Enum_Security_Setup_Reinsurance_Setup
    {
        Re_Insurer_Add = 1,
        Re_Insurer_Edit = 2,
        Re_Insurer_Delete = 3,

        Treaty_Limit_Add = 4,
        Treaty_Limit_Edit = 5,
        Treaty_Limit_Delete = 6,

        RI_Share_Add = 7,
        RI_Share_Edit = 8,
        RI_Share_Delete = 9,

        Broker_Add = 10,
        Broker_Edit = 11,
        Broker_Delete = 12,

        Tax_Setting_Add = 13,
        Tax_Setting_Edit = 14,
        Tax_Setting_Delete = 15,

        Treaty_Heads_Add = 16,
        Treaty_Heads_Edit = 17,
        Treaty_Heads_Delete = 18,

        Quaterly_Period_Add = 19,
        Quaterly_Period_Edit = 20,
        Quaterly_Period_Delete = 21,

        Pool_Share_Add = 22,

        Suminsured_Settings_Add = 23,
        Suminsured_Settings_Delete = 24,

        Pool_Commission_Add = 25,
        Pool_Commission_Edit = 26,
        Pool_Commission_Delete = 27,

        Risk_Pro_Setup_Add = 28,
        Risk_Pro_Setup_Edit = 29,
        Risk_Pro_Setup_Delete = 30,

        Pool_Share_Edit = 31,

        Fac_Approval_Search = 32,
        Fac_Approval_Approve = 33,
        Fac_Approval_Export = 34



    }
    public enum Enum_Security_Setup_Printing_Matters
    {
        Printing_Matters_Setup = 1
    }
    public enum Enum_Security_Setup_Claim_Setup
    {
        Old_One_Add = 1,
        Old_One_Edit = 2,
        Old_One_Delete = 3,

        Claim_Causes_Add = 4,
        Claim_Causes_Edit = 5,
        Claim_Causes_Delete = 6,

        Claim_Documents_Add = 7,
        Claim_Documents_Edit = 8,
        Claim_Documents_Delete = 9,

        Survey_Type_Add = 10,
        Survey_Type_Edit = 11,
        Survey_Type_Delete = 12,

        Claimant_Add = 13,
        Claimant_Edit = 14,
        Claimant_Delete = 15,

        Member_Transfer_Add = 16,
        Member_Transfer_Edit = 17,
        Member_Transfer_Delete = 18,

        Authorizing_Member_Add = 19,
        Authorizing_Member_Edit = 20,
        Authorizing_Member_Delete = 21,

        Staff_Surveyor_Add = 22,
        Staff_Surveyor_Edit = 23,
        Staff_Surveyor_Delete = 24,

        Benefit_Limits_Add = 25,
        Benefit_Limits_Edit = 26,
        Benefit_Limits_Delete = 27,

        Medical_Heading_Add = 28,
        Medical_Heading_Edit = 29,
        Medical_Heading_Delete = 30,


        Medical_Sub_Heading_Add = 31,
        Medical_Sub_Heading_Edit = 32,
        Medical_Sub_Heading_Delete = 33,

        Table_of_Benefits_Add = 34,
        Table_of_Benefits_Edit = 35,
        Table_of_Benefits_Delete = 36,

        Medical_Members_Add = 37,
        Medical_Members_Edit = 38,
        Medical_Members_Delete = 39,

        Loss_Type_Add = 40,
        Loss_Type_Edit = 41,
        Loss_Type_Delete = 42,

        Category_Add = 43,
        Category_Edit = 44,
        Category_Delete = 45,

        Claim_Excess_Add = 46,
        Claim_Excess_Edit = 47,
        Claim_Excess_Delete = 48,

        Material_Type_Add = 49,
        Material_Type_Edit = 50,
        Material_Type_Delete = 51,

        Sub_Loss_Type_Add = 52,
        Sub_Loss_Type_Edit = 53,
        Sub_Loss_Type_Delete = 54,

        Survey_Info_Add = 55,
        Survey_Info_Edit = 56,
        Survey_Info_Delete = 57,

        Sub_Loss_Type_New_Add = 58,
        Sub_Loss_Type_New_Edit = 59,
        Sub_Loss_Type_New_Delete = 60,

        Loss_Type_Mapping_Add = 61,
        Loss_Type_Mapping_Edit = 62,
        Loss_Type_Mapping_Delete = 63,

        Surveyor_Type_Add = 64,
        Surveyor_Type_Edit = 65,
        Surveyor_Type_Delete = 66,

        Document_Group_Add = 67,
        Document_Group_Edit = 68,
        Document_Group_Delete = 69,

        Claim_Document_Group_Mapping_Add = 70,
        Claim_Document_Group_Mapping_Edit = 71,
        Claim_Document_Group_Mapping_Delete = 72,




    }
    public enum Enum_Security_Setup_Motor_Identification
    {
        Add = 1,
        Edit = 2,
        Delete = 3,

        Tariff_Category_Add = 4,
        Tariff_Category_Edit = 5,
        Tariff_Category_Delete = 6
    }
    public enum Enum_Security_Setup_Motor_Tariff
    {
        Motor_Tariff_Add = 1,
        Motor_Tariff_Edit = 2,
        Motor_Tariff_Delete = 3,
        Motor_Tariff_Export = 4,
        Motor_Tariff_Search = 5

    }
    public enum Enum_Security_Setup_Marketting_Target_Setup
    {
        Add = 1,
        Edit = 2
    }
    public enum Enum_Security_Setup_Policy_Search_Popup_Menu
    {
    }
    public enum Enum_Security_Setup_Calender_Setup
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_Setup_Nepali_Calender_Setup
    {
    }
    public enum Enum_Security_Setup_Payroll_Setup
    {
    }
    public enum Enum_Security_Setup_Policy_Issue_Block
    {
        Block = 1
    }
    public enum Enum_Security_Setup_Classwise_Policy_Issue_Block
    {
        Block = 1
    }
    public enum Enum_Security_Setup_Stamp_setup
    {
        save = 1
    }
    public enum Enum_Security_Setup_Area_Setup
    {
        Zone_Add = 1,
        Zone_Edit = 2,
        Zone_Delete = 3,

        District_Add = 4,
        District_Edit = 5,
        District_Delete = 6,

        Municipality_Add = 7,
        Municipality_Edit = 8,
        Municipality_Delete = 9,

        VDC_Add = 10,
        VDC_Edit = 11,
        VDC_Delete = 12,

        Area_Add = 13,
        Area_Edit = 14,
        Area_Delete = 15,

        Tole_Add = 16,
        Tole_Edit = 17,
        Tole_Delete = 18,

        Region_Add = 19,
        Region_Delete = 20,
        Region_Edit = 21
    }
    public enum Enum_Security_Setup_Motor_Setup
    {
        MakeModel_Add = 1,
        MakeModel_Edit = 2,
        MakeModel_Delete = 3,

        MakeVehicle_Add = 4,
        MakeVehicle_Edit = 5,
        MakeVehicle_Delete = 6,

        VehicleName_Add = 7,
        VehicleName_Edit = 8,
        VehicleName_Delete = 9,

        Class_Category_Add = 10,
        Class_Category_Edit = 11,
        Class_Category_Delete = 12
    }
    public enum Enum_Security_Setup_Account_Setup
    {
        Account_Type_Mapping_Add = 1,
        Account_Type_Mapping_Edit = 2,
        Account_Type_Mapping_Delete = 3,

        Account_Type_Setting_Add = 4,
        Account_Type_Setting_Edit = 5,
        Account_Type_Setting_Delete = 6,

        Account_Code_Mapping_Add = 7,
        Account_Code_Mapping_Edit = 8,
        Account_Code_Mapping_Delete = 9,

        Voucher_Type_Add = 10,
        Voucher_Type_Edit = 11,
        Voucher_Type_Delete = 12

    }
    public enum Enum_Security_Setup_Company_Setup
    {
        Company_Profile_Add = 1,
        Company_Profile_Edit = 2,

        Format_Setup_Add = 3,
        Format_Setup_Edit = 4,
        News_Event_Add = 5,
        News_Event_Edit = 6,
        News_Event_Delete = 7




    }


    #endregion setup
    #region underwriting
    public enum Enum_Security_Underwriting_Policy_Issue
    {
        Add_Policy = 1,
        Edit_Policy = 2,
        Delete_Policy = 3,
        Issue_Other_Branch = 4,
        Renew_Endorse_Other_Branch_Policy = 5
    }
    public enum Enum_Security_Underwriting_Renewal_Notice
    {
        Add = 1,
        Edit = 1
    }
    public enum Enum_Security_Underwriting_Policy_Bill_Print
    {
        Debit_Note = 1,
        Credit_Note = 2,
        VAT_Bill = 3
    }
    public enum Enum_Security_Underwriting_Policy_Lock
    {
        Lock = 1,
        UnLock = 1
    }
    public enum Enum_Security_Underwriting_TMI_Calculation
    {
        TMI_Calculation = 1
    }
    #endregion underwriting
    #region claim
    public enum Enum_Security_Claim_Claim_Registration
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        Save = 4
    }
    public enum Enum_Security_Claim_Claim_RI_Approval
    {
        Claim_RI_Approval = 1,
        Claim_RI_Approval_Alert = 2,
        Serv_Fee_Breakdown = 3
    }
    public enum Enum_Security_Claim_Claim_Approval
    {
        Claim_Approval = 1,
        Claim_UnApproval = 2
    }
    public enum Enum_Security_Claim_Claim_Account_Settlement
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        Print_Claim_Settle = 4,
        Print_Claim_Paid = 5,
        Print_Memo = 6
    }
    public enum Enum_Security_Claim_Force_Claim_Register
    {
        Force_Claim_Register = 1
    }
    public enum Enum_Security_Claim_Claim_Withdraw
    {
        Save = 1
    }
    public enum Enum_Security_Claim_Claim_Search_Popup_Menu
    {
        ClaimSearch_Popup_Menu = 1,
        Edit_Claim = 2,
        Policy_Preview = 3,
        Preview_Receipt = 4,
        View_Claim_Note = 5
    }
    public enum Enum_Security_Claim_Surveyor_Deputation
    {
        Save = 1
    }
    public enum Enum_Security_Claim_Claim_Assesment_Fire
    {
        Save = 1
    }
    public enum Enum_Security_Claim_Claim_Assesment_Motor
    {
        Save = 1
    }
    public enum Enum_Security_Claim_Claim_Assesment_Marine
    {
        Save = 1
    }
    public enum Enum_Security_Claim_Claim_Assesment_Medical
    {
        Save = 1
    }
    public enum Enum_Security_Claim_Claim_Assesment_PA_GPA
    {
        Save = 1,
        Preview_Claim_Note = 2,
        Other = 3
    }
    public enum Enum_Security_Claim_Claim_Discharge_Voucher
    {
        Print = 1,
        Save = 2
    }
    public enum Enum_Security_Claim_Claim_Advance_Payment
    {
        Save = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_Claim_Claim_Unlock
    {
        Unlock = 1
    }

    public enum Enum_Security_Claim_SurevyFeeNote
    {
        VIEW = 1
    }

    public enum Enum_Security_Claim_Claim_Assignment
    {
        Assign_User = 1,
        Edit_User = 2
    }
    public enum Enum_Security_Claim_Claim_Document_Submission
    {
        Save = 1
    }

    public enum Enum_Security_Claim_Claim_Document_RequestLog
    {
        Save = 1,
        Print = 2
    }

    public enum Enum_Security_Claim_Claim_FollowUp
    {
        Save = 1,
        Print = 2
    }

    public enum Enum_Security_Claim_Claim_SurveyorFee_Approval
    {
        Approve = 1,
        Unapprove = 2
    }
    public enum Enum_Security_Claim_Claim_SurveyorFee_Settlement
    {
        Save = 1,
        Delete = 2,
        Print_Voucher = 3
    }
    #endregion claim
    #region re-insurance
    public enum Enum_Security_Re_insurance_Inward_Facultative
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        Export_To_Excel = 4,
        Print = 5
    }
    public enum Enum_Security_Re_insurance_Treaty
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        Export_To_Excel = 4,
        Print = 5,
        Unlock = 6,
        Generate = 7,
        Search = 8
    }
    public enum Enum_Security_Re_insurance_RI_Premium_Distribution
    {
        RI_Premium_Distribution = 1
    }
    public enum Enum_Security_Re_insurance_Declaration_Entry
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        Print = 4,
        Show = 5
    }
    public enum Enum_Security_Re_insurance_Preview_Renewal_List
    {
        Preview_Renewal_List = 1
    }
    public enum Enum_Security_Re_insurance_Generate_RI_Break_Down
    {
        Generate_RI_Break_Down = 1,
        Generate_RI = 2,
        View_Report = 3
    }
    #endregion re-insurance
    #region account
    public enum Enum_Security_Account_Collection
    {
        Entry = 1,
        Edit = 2,
        Delete = 3,
        Adjust_Commission = 4,
        Printing = 5,
        Deposit_Adjustment = 6,
        JV_Adjustment = 7,
        Session_Start_End = 8,
        Refund_Adjustment = 9
    }
    public enum Enum_Security_Account_Commission_Paid
    {
        Save_Commission_Paid = 1,
        View_Commission = 2,
        Print_Report = 3,
        Print_Memo = 4,
        Export_Commission_Statement = 5
    }

    public enum Enum_Security_Account_AgentCommission
    {
        Save = 2,
        View_Commission = 1,
        Print_Memo = 5,
        Export = 4,
        Generate_Comm = 3,
        Print_Report = 6,
    }
    public enum Enum_Security_Account_Creditnotepayment
    {
        Entry = 1,
        Edit = 2,
        Delete = 3,
        Print = 4
    }
    public enum Enum_Security_Account_Disbursement
    {
        New = 1,
        Accept = 2,
        Remove = 3,
        Save = 4,
        Print = 5
    }
    public enum Enum_Security_Account_Deposit
    {
        Entry = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_Account_Deposit_Adjustment
    {
        Entry = 1
    }
    public enum Enum_Security_Account_Bank_Deposit
    {
        Save_Deposit = 1,
        Edit_Deposit = 2,
        Delete_Deposit = 3,
        Print_Bank_Deposit = 4,
        Export_Bank_Deposit = 5
    }
    public enum Enum_Security_Account_Premium_Commission_Booked_Voucher
    {
        Save = 1
    }
    public enum Enum_Security_Account_Vatno_Cancellation
    {
        Entry = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_OtherCollection
    {
        Entry = 1,
        Edit = 2
    }

    public enum Enum_Security_Account_Receiptno_Cancellation
    {
        Entry = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_Col_ChequeRealisation
    {
        SHOW = 1,
        UPDATE = 2
    }
    public enum Enum_Security_Account_Generate_Voucher
    {
        Generate_Voucher = 1
    }
    public enum Enum_Security_Account_Voucher_Entry
    {
        Entry = 1,
        Edit = 2,
        Delete = 3,
        Print_Voucher = 4
    }

    public enum Enum_Security_Account_KharidKhata_Entry
    {
        Entry = 1,
        Edit = 2,
        Delete = 3,
        Print_Voucher = 4
    }

    public enum Enum_Security_Account_Voucher_Listing
    {
        Display_Voucher = 1,
        Approve_Voucher = 2,
        Unapprove_Voucher = 3,
        Print_Voucher_Listing = 4,
        Export_Voucher_Listing = 5,
        Show_Approved_Voucher = 6
    }
    public enum Enum_Security_Account_Transfer_Opening_Balance
    {
        Transfer_Opening_Balance = 1,
        Delete = 2
    }
    public enum Enum_Security_Account_Account_Head_Creation
    {
        Entry = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_Account_VendorSetup
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_TransactionType
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_VoucherAmtApproval
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_DefaultBankSetup
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_BankFirmDeposit
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_BankFirmSearch
    {
        Search = 1,
        Export = 2
    }

    public enum Enum_Security_Account_InvestmenntEntry
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_InvestmentSearch
    {
        Search = 1,
        Export = 2
    }

    public enum Enum_Security_Account_BankChequeManagement
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum Enum_Security_Account_Account_Chart_Definition
    {
        Entry = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_Account_Account_Head_Transfer
    {
        Account_Head_Transfer = 1
    }
    public enum Enum_Security_Account_Cheque_Bounce_Entry
    {
        Cheque_Bounce = 1
    }
    #endregion account
    #region others
    public enum Enum_Security_Others_Back_Up
    {
        Back_Up = 1
    }
    public enum Enum_Security_Others_Policy_Search
    {
        Policy_Search = 1,
        Policy_Search_Export = 1
    }
    public enum Enum_Security_Others_Debit_Advice_Search
    {
        Debit_Advice_Search = 1
    }
    public enum Enum_Security_Others_Claim_Search
    {
        Claim_Search = 1,
        Export = 2,
        Claim_Note_Preview = 3,
        Switch_Respective_Page = 4,
        Settle_Or_Loss_Advice = 5,
        Add_Deadline_Date = 6
    }
    public enum Enum_Security_Others_Policy_Print
    {
        Policy_Print = 1
    }
    public enum Enum_Security_Others_Security
    {
        Debit_Bill_Print = 1,
        Debit_Advice_Preview = 2,
        Debit_SumInsured_Approve = 3,
        History_Report_Viewer = 4,
        Approve_Policy = 5,
        Unapprove_Policy = 6,
        Move_Policy_To_Blacklist = 7,
        Remove_Policy_From_Blacklist = 8,
        Edit_Policy = 9,
        Register_Claim = 10,
        Edit_Claim = 11,
        BackDate_Approval = 12
    }
    public enum Enum_Security_Others_Branch_Option
    {
        Branch_Option = 1
    }
    public enum Enum_Security_Others_Renewal_Search
    {
        Renewal_Search = 1,
        Renewal_Notice_Print = 2,
        Renewal_Notice_Send = 3

    }
    public enum Enum_Security_Others_Report_Search
    {
        General_Report_Search = 1,
        Claim_Report_Search = 2,
        RI_Report_Search = 3,
        Report_Setup_Add = 4,
        Report_Control_Setup_Add = 5,
        Report_Control_Setup_Delete = 6,
        Map_Report_Control_Setup_Add = 7
    }
    public enum Enum_Security_Others_Customer_Search
    {
        Customer_Search = 1,
        Export = 2,
        View_Report = 3,
        Edit = 4
    }
    public enum Enum_Security_Others_Collection_Search
    {
        Search = 1,
        Vat_Print = 2,
        Receipt_Print = 3,
        Export = 4
    }

    public enum Enum_Security_Others_Email
    {
        Email_Seting_Add = 1,
        Add_Contact_Add = 2,
        Add_Contact_Edit = 3,
        Add_Contact_Delete = 4,
        Send_Email_Delete = 5,
        Send_Email_Send = 6,
        Send_Email_Search_To = 7,
        Send_Email_Search_CC = 8,
        Send_Email_Search_Bcc = 9,
        Email_History_Show = 10,
        Email_History_Delete = 11

    }
    public enum Enum_Security_Others_AttachDocument
    {
        Attach_Document_Add = 1,
        Attach_Document_Save = 2,
        Attach_Document_Show = 3
    }
    public enum Enum_Security_Others_Quotation
    {
        Quotation_Search = 1,
        Quotation_Preview = 2,
        Quotation_Save = 3
    }

    public enum Enum_Security_Others_DocumentManagement
    {
        Document_Management_Add = 1,
        Document_Management_Search = 2
    }
    public enum Enum_Security_Others_Policy_Vault
    {
        Policy_Vault_Search = 1,
        Policy_Vault_Export = 2,
        Policy_Vault_Approve = 3
    }
    public enum Enum_Security_Others_Disbursement_Search
    {
        Disbursement_Search_Search = 1,
        Disbursement_Search_Export = 2,
        Disbursement_Search_Print = 3
    }
    #endregion others
    #region reports
    public enum Enum_Security_Reports_Business_Summary_ConSole_Bordereau
    {
    }
    public enum Enum_Security_Reports_Partywise_Business_Summary
    {
    }
    public enum Enum_Security_Reports_KYC_REPORT
    {
        SEARCH = 1,
        SAVE = 2,
        EXPORT = 3
    }
    #endregion reports
    #region underwriting reports
    public enum Enum_Security_Underwriting_Reports_Underwriting_Reports
    {
        Premium_Register = 1,
        Potfoliowise_Premium_Register = 2,
        Policy_Print = 3,
        VAT_Bill_Register = 4,
        Yearly_Rl_Premium_Bill_Register = 5,
        Yearly_Rl_Reportwise_Summary = 6,
        Yearly_Rl_Classwise_Summary = 7,
        Yearly_Rl_Deptwise_Summary = 8,
        Motor_Premium_Bill_Register_Summary = 9,
        UW_Dept_Summary_Report = 10,
        Bussiness_Summary_Motor = 11,
        Branch_Business_Summary = 12,
        Branch_Business_Summary_Cash_Basis = 13,
        Branchwise_Motor_Class_Category = 14,
        Credit_Note_Register = 15,
        Declaration_Report = 16,
        Partywise_Vat_Summary_Report = 17,
        PartyWise_VAT_Details_Report = 18,
        Debit_Advice_Register = 19,
        Premium_Register_Cash_Basis = 20
    }
    public enum Enum_Security_Underwriting_Reports_Renewal_Reports
    {
        Extra_List = 1,
        Notice_Sent_List = 2,
        Renewed_List = 3,
        Not_Renewed_List = 4,
        Preview_Renewal_Notice = 5,
        Expiry_Notice = 6
    }
    public enum Enum_Security_Underwriting_Reports_Collection_Reports
    {
        Daily_Collection_Report = 1,
        Premium_Income_Summary_Portfoliowise_Reports = 2,
        Collection_Report = 3,
        Undeposited_Collection_Report = 4,
        Deposit_Register = 5,
        Policy_Bill_Register = 6,
        Cash_Only = 7,
        Cheque_Only = 8,
        Both_Cash_Cheque = 9,
        Collection_Summary_Report = 10,
        Premium_Collection_Report = 11,
        Department_wise_Inward_Summary = 12,
        Premium_Collection_Report_UW = 13,
        TDS_Detail_Report = 14,
        Partly_Paid_Collection_Report = 15,
        Bank_Deposit_Report = 16,
        Bank_Deposit_Summary_Report = 17,
        Dept_Wise_Commission_Adj_Report = 18,
        Deposit_Withdraw_Details_Report = 19,
        Sales_Register = 20,
        Deposit_Withdraw_Report = 21
    }
    public enum Enum_Security_Underwriting_Reports_Agency_Reports
    {
        Agent_Business_Statement = 1,
        Agent_Commission_Payable_Statement = 2,
        Agent_Commission_Paid_Statement = 3,
        Agent_Commission_Paid_Through_PV_JV = 4,
        Agent_Commission_Payable_Summary = 5,
        Agent_Commission_Paid_Summary = 6,
        Department_Wise_Agent_Commission_Paid = 7,
        Date_Wise_Agency_Commission_Paid_Report = 8,
        Agent_Commission_Paid_Portfoliowise = 9
    }
    public enum Enum_Security_Underwriting_Reports_Outstanding_Reports
    {
        Outstanding_Policy_Report = 1,
        Field_Officerwise_Os_Details = 2,
        Clientwise_Os_Details = 3,
        Field_Officerwise_Paid_Outstanding_Ageing_Details = 4,
        Field_Officerwise_Outstansing_Summary = 5,
        Field_Officerwise_Os_Monthwise_Summary = 6,
        Departmentwise_Outstanding_Summary = 7,
        Departmentwise_Outstanding_Details = 8,
        Agentwise_Os_Details = 9
    }
    public enum Enum_Security_Underwriting_Reports_MIS_Reports
    {
        Premium_Income_Summary = 1,
        FO_Business_Summary_Statement = 2,
        Deptwise_FO_Business_Summary_Statement = 3,
        Partywise_Paid_Outstanding_Ageing_Summary = 4,
        Partywise_Paid_Outstanding_Ageing_Details = 5,
        Branchwise_Monthly_Premium_Summary = 6,
        FO_Wise_Profitability_Report = 7,
        Bima_Samiti_Report = 8,
        Sum_Insured_Wise_Risk_Profile = 9,
        Sum_Insured_Wise_Risk_Profile_Motor = 10,
        Performance_of_Development_Officer = 11,
        Branch_Business_Summary_Comparision_with_Last_Year = 12,
        Motor_Classwise_Report = 13,
        Deptwise_Agent_Business_Summary = 14,
        Management_Information_Report_Marketing_Staffwise = 15,
        Userwise_Policy_Issue_Report = 16
    }
    public enum Enum_Security_Underwriting_Reports_Money_Laundering_Reports
    {
        Money_Laundering_Annexture_2 = 1,
        Money_Laundering_Annexture_2_Details = 2,
        Money_Laundering_Annexture_2_Portfoliowise = 3,
        Money_Laundering_Annexture_2_Summary_Nepali = 4,
        Money_Laundering_Memo = 5,
        Money_Laundering_Report = 6,
        Money_Laundering_Report_Portfoliowise = 7
    }
    public enum Enum_Security_Underwriting_Reports_Other_MIS_Reports
    {
        Branch_Wise_Cash_Business_Report = 1,
        Branch_Wise_Monthly_Cash_Business_Report = 2,
        Business_Growth_Deficit_Report = 3
    }
    #endregion underwriting reports
    #region re-insurance reports
    public enum Enum_Security_Re_insurance_Reports_Bordereau
    {
        Master_Bordereau = 1,
        Pool_Bordereau = 2
    }
    public enum Enum_Security_Re_insurance_Reports_Market_Pool
    {
        Sum_Insuredwise_Pool_Premium = 1
    }
    public enum Enum_Security_Re_insurance_Reports_Local_Facultative
    {
        Inward_Facultative = 1,
        Inward_Facultative_Portfoliowise = 2,
        Outward_Facultative = 3
    }
    public enum Enum_Security_Re_insurance_Reports_Accounts
    {
        Treaty_Account = 1,
        Pool_Accounts = 2
    }
    public enum Enum_Security_Re_insurance_Reports_Summary_Report
    {
        Policy_Summary_Report = 1,
        Classwise_Summary_Report = 2,
        Departmentwise_Summary_Report = 3
    }
    public enum Enum_Security_Re_insurance_Reports_Beema_Samati_Report
    {
    }
    public enum Enum_Security_Re_insurance_Reports_Risk_Profile
    {
    }
    public enum Enum_Security_Re_insurance_Reports_Mediclaim_Reports
    {
    }
    #endregion re-insurance reports
    #region claim reports
    public enum Enum_Security_Claim_Reports_Claim_Register
    {
        Claim_Register_General = 1
    }
    public enum Enum_Security_Claim_Reports_Claim_OSPaid_Reports
    {
        Claim_Outstanding_Details = 1,
        Claim_Paid_Details = 2,
        Claim_Outstanding_Status_Details = 3,
        Claim_Advance_Report = 4,
        Department_wise_FO_Claim_Summary = 5,
        Department_wise_FO_Claim_Summary_Paid = 6
    }
    public enum Enum_Security_Claim_Reports_Claim_RI_Reports
    {
        Actual_Claim_Bordereau = 1,
        Estimated_Claim_Bordereau = 2,
        Re_insurerwise_Claim_OS_Details = 3

    }
    public enum Enum_Security_Claim_Reports_Claim_Withdraw_Reports
    {
        Claim_Withdraw_Reports = 1
    }
    #endregion claim reports
    #region account reports
    public enum Enum_Security_Account_Reports_Ledger
    {
        Show_Voucher = 1,
        Print = 2,
        Export = 3
    }
    public enum Enum_VoucherType
    {
        bank_deposite = 1,
        commission_payment = 2,
        claim_payment = 3,
        surveyfee_payment = 4,
        creditnote_payment = 5,
        purchase = 6,
        disbursement = 7

    }
    public enum Enum_Security_Account_Reports_Trial_Balance
    {
        Show_Ledger = 1,
        Print = 2,
        Export = 3
    }
    public enum Enum_Security_Account_Reports_Category_Report
    {
        Category_Report = 1
    }
    #endregion account reports
    #region tools
    public enum Enum_Security_Tools_Update_Policy
    {
        Update = 1
    }
    #endregion tools
    #region security
    public enum Enum_Security_Security_Lock
    {
        Account_Lock = 1,
        Branchwise_Policy_Issue_Lock = 2,
        Collection_Lock = 3,
        Table_Lock_Module = 4,
        Policy_Lock = 5,
        Sum_Insured_Lock = 6,
        Userwise_Policy_Issue_Lock = 7
    }
    public enum Enum_Security_Security_Log
    {
        Create_Log = 1,
        Login_History = 2,
        Log_Report = 3,
        Module_Hit_Count = 4
    }
    public enum Enum_Security_Security_Page
    {
        Page_Entry_Add = 1,
        Page_Entry_Edit = 2,
        Page_Security_Add = 3,
        Page_Security_Edit = 4
    }
    public enum Enum_Security_Security_User_Security
    {
        Groupwise_Security_Setting = 1,
        Groupwise_Security_Setting_Visible = 2,
        Multiple_Branchwise_Groupwise_Rights = 3,
        Multiple_Branchwise_User = 4,
        Print_Options = 5,
        Userwise_Security_Setting = 6
    }
    public enum Enum_Security_Security_Setting
    {
        Module_Group_Add = 1,
        Module_Group_Edit = 2,
        Module_Name_Add = 3,
        Module_Name_Edit = 4,
        Security_Name_Add = 5,
        Security_Name_Edit = 6,

        SMTP_Add = 7,
        SMTP_Edit = 8,
        Sms_Provider_Add = 9,
        Sms_Provider_Edit = 10,
        Client_Portal_Setup_Add = 11,
        Client_Portal_Setup_Edit = 12
    }
    #endregion
    #region HR
    public enum Enum_Security_HR_Staff_Information
    {
        Staff_Add = 1,
        Staff_Edit = 2,
        Staff_Search = 3
    }
    public enum Enum_Security_HR_Staff_Search
    {
        Search = 1,
        Export = 2,
        Print = 3
    }
    public enum Enum_Security_HR_Staff_Department
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_HR_Staff_Post
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }
    public enum Enum_Security_HR_Staff_Designation
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }
    #endregion
    #region Control Panel
    public enum Enum_ControlPanel_ComputerRegister
    {
        Computer_Register_Add = 1,
        Computer_Register_Delete = 2
    }

    #endregion
    #endregion security name
    #endregion security

    #region Entry Option
    public enum Enum_EntryOtion
    {
        Entry_Import = 0,
        Attachment = 1

    }
    public enum Enum_tbl_NewsAndEvent
    {
        NewsAndEvent = 1,
        Underwriting = 2,
        Claim = 3,
        RI = 4,
        Account = 5,
        Others = 6

    }
    public enum Enum_Attachment
    {
        Policy = 1,
        Claim = 2,
        Insured = 3,
        Staff = 4,
        Others = 5,
        Client = 6,
        Surveyor = 7,
        BankDeposit = 8

    }
    #endregion

    public class clsCommonEnumerator
    {
        public class Department
        {
            #region for department
            #region private variables
            private Enum_Department _Fire = Enum_Department.FIRE;
            private Enum_Department _Motor = Enum_Department.MOTOR;
            private Enum_Department _Marine = Enum_Department.MARINE;
            private Enum_Department _Miscellaneous = Enum_Department.MISCELLANEOUS;
            private Enum_Department _Engineering = Enum_Department.ENGINEERING;
            private Enum_Department _Aviation = Enum_Department.AVIATION;
            private Enum_Department _Micro = Enum_Department.AGRICULTURE;
            #endregion private variables
            #region properties
            public Enum_Department Fire
            {
                get
                {
                    return this._Fire;
                }
                set
                {
                    this._Fire = value;
                }
            }
            public Enum_Department Motor
            {
                get
                {
                    return this._Motor;
                }
                set
                {
                    this._Motor = value;
                }
            }
            public Enum_Department Marine
            {
                get
                {
                    return this._Marine;
                }
                set
                {
                    this._Marine = value;
                }
            }
            public Enum_Department Miscellaneous
            {
                get
                {
                    return this._Miscellaneous;
                }
                set
                {
                    this._Miscellaneous = value;
                }
            }
            public Enum_Department Engineering
            {
                get
                {
                    return this._Engineering;
                }
                set
                {
                    this._Engineering = value;
                }
            }
            public Enum_Department Aviation
            {
                get
                {
                    return this._Aviation;
                }
                set
                {
                    this._Aviation = value;
                }
            }
            public Enum_Department Micro
            {
                get
                {
                    return this._Micro;
                }
                set
                {
                    this._Micro = value;
                }
            }
            #endregion properties
            #endregion for department
        }

        public class Class
        {
            #region for classes

            #region for fire
            #region private variables
            private Enum_Class_Fire _Industrial_Risk = Enum_Class_Fire.Industrial_Risk;
            private Enum_Class_Fire _Commercial_Risk = Enum_Class_Fire.Commercial_Risk;
            private Enum_Class_Fire _Lop_Industrial_or_Commercial_Risk = Enum_Class_Fire.Lop_Industrial_or_Commercial_Risk;
            private Enum_Class_Fire _Non_Industrial_N_Non_Commercial_Risk = Enum_Class_Fire.Non_Industrial_N_Non_Commercial_Risk;
            private Enum_Class_Fire _Traders_Comprehensive = Enum_Class_Fire.Traders_Comprehensive;
            private Enum_Class_Fire _HouseHold_Insurance = Enum_Class_Fire.HouseHold_Insurance;
            private Enum_Class_Fire _General_Fire = Enum_Class_Fire.General_Fire;
            private Enum_Class_Fire _Fire_Consequential_Loss = Enum_Class_Fire.Fire_Consequential_Loss;
            private Enum_Class_Fire _Banker = Enum_Class_Fire.Banker;
            private Enum_Class_Fire _Stock = Enum_Class_Fire.Stock;
            private Enum_Class_Fire _Loss_of_Profit = Enum_Class_Fire.Loss_of_Profit;
            private Enum_Class_Fire _House = Enum_Class_Fire.House;
            private Enum_Class_Fire _Burglary = Enum_Class_Fire.Burglary;
            private Enum_Class_Fire _Gharsangsar = Enum_Class_Fire.Gharsangsar;
            #endregion private variables
            #region properties
            public Enum_Class_Fire Industrial_Risk
            {
                get
                {
                    return this._Industrial_Risk;
                }
                set
                {
                    this._Industrial_Risk = value;
                }
            }
            public Enum_Class_Fire Commercial_Risk
            {
                get
                {
                    return this._Commercial_Risk;
                }
                set
                {
                    this._Commercial_Risk = value;
                }
            }
            public Enum_Class_Fire Lop_Industrial_or_Commercial_Risk
            {
                get
                {
                    return this._Lop_Industrial_or_Commercial_Risk;
                }
                set
                {
                    this._Lop_Industrial_or_Commercial_Risk = value;
                }
            }
            public Enum_Class_Fire Non_Industrial_N_Non_Commercial_Risk
            {
                get
                {
                    return this._Non_Industrial_N_Non_Commercial_Risk;
                }
                set
                {
                    this._Non_Industrial_N_Non_Commercial_Risk = value;
                }
            }
            public Enum_Class_Fire Traders_Comprehensive
            {
                get
                {
                    return this._Traders_Comprehensive;
                }
                set
                {
                    this._Traders_Comprehensive = value;
                }
            }
            public Enum_Class_Fire HouseHold_Insurance
            {
                get
                {
                    return this._HouseHold_Insurance;
                }
                set
                {
                    this._HouseHold_Insurance = value;
                }
            }
            public Enum_Class_Fire General_Fire
            {
                get
                {
                    return this._General_Fire;
                }
                set
                {
                    this._General_Fire = value;
                }
            }
            public Enum_Class_Fire Fire_Consequential_Loss
            {
                get
                {
                    return this._Fire_Consequential_Loss;
                }
                set
                {
                    this._Fire_Consequential_Loss = value;
                }
            }
            public Enum_Class_Fire Banker
            {
                get
                {
                    return this._Banker;
                }
                set
                {
                    this._Banker = value;
                }
            }
            public Enum_Class_Fire Stock
            {
                get
                {
                    return this._Stock;
                }
                set
                {
                    this._Stock = value;
                }
            }
            public Enum_Class_Fire Loss_of_Profit
            {
                get
                {
                    return this._Loss_of_Profit;
                }
                set
                {
                    this._Loss_of_Profit = value;
                }
            }
            public Enum_Class_Fire House
            {
                get
                {
                    return this._House;
                }
                set
                {
                    this._House = value;
                }
            }
            public Enum_Class_Fire Burglary
            {
                get
                {
                    return this._Burglary;
                }
                set
                {
                    this._Burglary = value;
                }
            }
            public Enum_Class_Fire Gharsangsar
            {
                get
                {
                    return this._Gharsangsar;
                }
                set
                {
                    this._Gharsangsar = value;
                }
            }
            #endregion properties
            #endregion for fire

            #region for Motor
            #region private variables
            private Enum_Class_Motor _MotorCycle = Enum_Class_Motor.MotorCycle;
            private Enum_Class_Motor _Commercial = Enum_Class_Motor.Commercial;
            private Enum_Class_Motor _Private = Enum_Class_Motor.Private;
            #endregion private variables
            #region properties
            public Enum_Class_Motor MotorCycle
            {
                get
                {
                    return this._MotorCycle;
                }
                set
                {
                    this._MotorCycle = value;
                }
            }
            public Enum_Class_Motor Commercial_Vehicle
            {
                get
                {
                    return this._Commercial;
                }
                set
                {
                    this._Commercial = value;
                }
            }
            public Enum_Class_Motor Private_Vehicle
            {
                get
                {
                    return this._Private;
                }
                set
                {
                    this._Private = value;
                }
            }
            #endregion properties
            #endregion for Motor

            #region for Marine
            #region private variables
            private Enum_Class_Marine _Overseas_Transit = Enum_Class_Marine.Overseas_Transit;
            private Enum_Class_Marine _Overseas_Transit_Open_Policy = Enum_Class_Marine.Overseas_Transit_Open_Policy;
            private Enum_Class_Marine _Overseas_and_Inland_Transit_Open_Policy = Enum_Class_Marine.Overseas_and_Inland_Transit_Open_Policy;
            private Enum_Class_Marine _Duty_Insurance = Enum_Class_Marine.Duty_Insurance;
            private Enum_Class_Marine _Marine = Enum_Class_Marine.Marine;
            private Enum_Class_Marine _Inland_Transit_Specific = Enum_Class_Marine.Inland_Transit_Specific;
            private Enum_Class_Marine _Air = Enum_Class_Marine.Air;
            private Enum_Class_Marine _Inland_Transit_Open_Policy = Enum_Class_Marine.Inland_Transit_Open_Policy;
            private Enum_Class_Marine _Marine_by_Land = Enum_Class_Marine.Marine_by_Land;
            private Enum_Class_Marine _Marine_By_Sea = Enum_Class_Marine.Marine_By_Sea;
            private Enum_Class_Marine _Overseas_Marine_Open = Enum_Class_Marine.Overseas_Marine_Open;
            private Enum_Class_Marine _I_C_C_A = Enum_Class_Marine.I_C_C_A;
            private Enum_Class_Marine _I_C_C_B = Enum_Class_Marine.I_C_C_B;
            private Enum_Class_Marine _I_C_C_C = Enum_Class_Marine.I_C_C_C;
            private Enum_Class_Marine _I_T_C_A = Enum_Class_Marine.I_T_C_A;
            #endregion private variables
            #region properties
            public Enum_Class_Marine Overseas_Transit
            {
                get
                {
                    return this._Overseas_Transit;
                }
                set
                {
                    this._Overseas_Transit = value;
                }
            }
            public Enum_Class_Marine Overseas_Transit_Open_Policy
            {
                get
                {
                    return this._Overseas_Transit_Open_Policy;
                }
                set
                {
                    this._Overseas_Transit_Open_Policy = value;
                }
            }
            public Enum_Class_Marine Overseas_and_Inland_Transit_Open_Policy
            {
                get
                {
                    return this._Overseas_and_Inland_Transit_Open_Policy;
                }
                set
                {
                    this._Overseas_and_Inland_Transit_Open_Policy = value;
                }
            }
            public Enum_Class_Marine Duty_Insurance
            {
                get
                {
                    return this._Duty_Insurance;
                }
                set
                {
                    this._Duty_Insurance = value;
                }
            }
            public Enum_Class_Marine Marine
            {
                get
                {
                    return this._Marine;
                }
                set
                {
                    this._Marine = value;
                }
            }
            public Enum_Class_Marine Inland_Transit_Specific
            {
                get
                {
                    return this._Inland_Transit_Specific;
                }
                set
                {
                    this._Inland_Transit_Specific = value;
                }
            }
            public Enum_Class_Marine Air
            {
                get
                {
                    return this._Air;
                }
                set
                {
                    this._Air = value;
                }
            }
            public Enum_Class_Marine Inland_Transit_Open_Policy
            {
                get
                {
                    return this._Inland_Transit_Open_Policy;
                }
                set
                {
                    this._Inland_Transit_Open_Policy = value;
                }
            }
            public Enum_Class_Marine Marine_by_Land
            {
                get
                {
                    return this._Marine_by_Land;
                }
                set
                {
                    this._Marine_by_Land = value;
                }
            }
            public Enum_Class_Marine Marine_By_Sea
            {
                get
                {
                    return this._Marine_By_Sea;
                }
                set
                {
                    this._Marine_By_Sea = value;
                }
            }
            public Enum_Class_Marine Overseas_Marine_Open
            {
                get
                {
                    return this._Overseas_Marine_Open;
                }
                set
                {
                    this._Overseas_Marine_Open = value;
                }
            }
            public Enum_Class_Marine I_C_C_A
            {
                get
                {
                    return this._I_C_C_A;
                }
                set
                {
                    this._I_C_C_A = value;
                }
            }
            public Enum_Class_Marine I_C_C_B
            {
                get
                {
                    return this._I_C_C_B;
                }
                set
                {
                    this._I_C_C_B = value;
                }
            }
            public Enum_Class_Marine I_C_C_C
            {
                get
                {
                    return this._I_C_C_C;
                }
                set
                {
                    this._I_C_C_C = value;
                }
            }
            public Enum_Class_Marine I_T_C_A
            {
                get
                {
                    return this._I_T_C_A;
                }
                set
                {
                    this._I_T_C_A = value;
                }
            }
            #endregion properties
            #endregion for Marine

            #region for Miscellaneous
            #region private variables
            private Enum_Class_Misc _Professional_Indemnity = Enum_Class_Misc.Professional_Indemnity;
            private Enum_Class_Misc _Personal_Domiciliary_Hospitalization = Enum_Class_Misc.Personal_Domiciliary_Hospitalization;
            private Enum_Class_Misc _Personal_Accident = Enum_Class_Misc.Personal_Accident;
            private Enum_Class_Misc _Burglary_N_House_Breaking = Enum_Class_Misc.Burglary_N_House_Breaking;
            private Enum_Class_Misc _Fidelity_Guarantee = Enum_Class_Misc.Fidelity_Guarantee;
            private Enum_Class_Misc _Public_Liability = Enum_Class_Misc.Public_Liability;
            private Enum_Class_Misc _Workman_Compensation = Enum_Class_Misc.Workman_Compensation;
            private Enum_Class_Misc _Group_Personal_Accident = Enum_Class_Misc.Group_Personal_Accident;
            private Enum_Class_Misc _Group_Domiciliary_Hospitalization_Mediclaim = Enum_Class_Misc.Group_Domiciliary_Hospitalization_Mediclaim;
            private Enum_Class_Misc _Bankers_Blanket = Enum_Class_Misc.Bankers_Blanket;
            private Enum_Class_Misc _All_Risk = Enum_Class_Misc.All_Risk;
            private Enum_Class_Misc _Travel_Overseas_Medical_Insurance = Enum_Class_Misc.Travel_Overseas_Medical_Insurance;
            private Enum_Class_Misc _Cash_in_Transit_others = Enum_Class_Misc.Cash_in_Transit_others;
            private Enum_Class_Misc _Cash_in_Transit = Enum_Class_Misc.Cash_in_Transit;
            private Enum_Class_Misc _Product_Liability = Enum_Class_Misc.Product_Liability;
            private Enum_Class_Misc _Baggage_Insurance = Enum_Class_Misc.Baggage_Insurance;
            private Enum_Class_Misc _Trekking = Enum_Class_Misc.Trekking;
            private Enum_Class_Misc _Money = Enum_Class_Misc.Money;
            private Enum_Class_Misc _Misc_Duty_Insurance = Enum_Class_Misc.Duty_Insurance;
            private Enum_Class_Misc _Cover_Note = Enum_Class_Misc.Cover_Note;
            private Enum_Class_Misc _Gold = Enum_Class_Misc.Gold;
            private Enum_Class_Misc _Strong_Room_Burglary = Enum_Class_Misc.Strong_Room_Burglary;
            private Enum_Class_Misc _Press_Accident = Enum_Class_Misc.Press_Accident;
            private Enum_Class_Misc _Strong_Room_Fire = Enum_Class_Misc.Strong_Room_Fire;
            private Enum_Class_Misc _Cash_Counter = Enum_Class_Misc.Cash_Counter;
            private Enum_Class_Misc _Vehicle_Personal_Accident = Enum_Class_Misc.Vehicle_Personal_Accident;
            private Enum_Class_Misc _Directors_and_Officers_Liability = Enum_Class_Misc.Directors_and_Officers_Liability;
            private Enum_Class_Misc _Householder_Insurance = Enum_Class_Misc.Householder_Insurance;
            private Enum_Class_Misc _Individual_And_Group_Mobile = Enum_Class_Misc.Individual_And_Group_Mobile;
            private Enum_Class_Misc _Pedal_Cycle = Enum_Class_Misc.Pedal_Cycle;
            private Enum_Class_Misc _Student_Safety_Insurance = Enum_Class_Misc.Student_Safety_Insurance;
            #endregion private variables
            #region properties
            public Enum_Class_Misc Professional_Indemnity
            {
                get
                {
                    return this._Professional_Indemnity;
                }
                set
                {
                    this._Professional_Indemnity = value;
                }
            }
            public Enum_Class_Misc Personal_Domiciliary_Hospitalization
            {
                get
                {
                    return this._Personal_Domiciliary_Hospitalization;
                }
                set
                {
                    this._Personal_Domiciliary_Hospitalization = value;
                }
            }
            public Enum_Class_Misc Personal_Accident
            {
                get
                {
                    return this._Personal_Accident;
                }
                set
                {
                    this._Personal_Accident = value;
                }
            }
            public Enum_Class_Misc Burglary_N_House_Breaking
            {
                get
                {
                    return this._Burglary_N_House_Breaking;
                }
                set
                {
                    this._Burglary_N_House_Breaking = value;
                }
            }
            public Enum_Class_Misc Fidelity_Guarantee
            {
                get
                {
                    return this._Fidelity_Guarantee;
                }
                set
                {
                    this._Fidelity_Guarantee = value;
                }
            }
            public Enum_Class_Misc Public_Liability
            {
                get
                {
                    return this._Public_Liability;
                }
                set
                {
                    this._Public_Liability = value;
                }
            }
            public Enum_Class_Misc Workman_Compensation
            {
                get
                {
                    return this._Workman_Compensation;
                }
                set
                {
                    this._Workman_Compensation = value;
                }
            }
            public Enum_Class_Misc Group_Personal_Accident
            {
                get
                {
                    return this._Group_Personal_Accident;
                }
                set
                {
                    this._Group_Personal_Accident = value;
                }
            }
            public Enum_Class_Misc Group_Domiciliary_Hospitalization_Mediclaim
            {
                get
                {
                    return this._Group_Domiciliary_Hospitalization_Mediclaim;
                }
                set
                {
                    this._Group_Domiciliary_Hospitalization_Mediclaim = value;
                }
            }
            public Enum_Class_Misc Bankers_Blanket
            {
                get
                {
                    return this._Bankers_Blanket;
                }
                set
                {
                    this._Bankers_Blanket = value;
                }
            }
            public Enum_Class_Misc All_Risk
            {
                get
                {
                    return this._All_Risk;
                }
                set
                {
                    this._All_Risk = value;
                }
            }
            public Enum_Class_Misc Travel_Overseas_Medical_Insurance
            {
                get
                {
                    return this._Travel_Overseas_Medical_Insurance;
                }
                set
                {
                    this._Travel_Overseas_Medical_Insurance = value;
                }
            }
            public Enum_Class_Misc Cash_in_Transit_others
            {
                get
                {
                    return this._Cash_in_Transit_others;
                }
                set
                {
                    this._Cash_in_Transit_others = value;
                }
            }
            public Enum_Class_Misc Cash_in_Transit
            {
                get
                {
                    return this._Cash_in_Transit;
                }
                set
                {
                    this._Cash_in_Transit = value;
                }
            }
            public Enum_Class_Misc Product_Liability
            {
                get
                {
                    return this._Product_Liability;
                }
                set
                {
                    this._Product_Liability = value;
                }
            }
            public Enum_Class_Misc Baggage_Insurance
            {
                get
                {
                    return this._Baggage_Insurance;
                }
                set
                {
                    this._Baggage_Insurance = value;
                }
            }
            public Enum_Class_Misc Trekking
            {
                get
                {
                    return this._Trekking;
                }
                set
                {
                    this._Trekking = value;
                }
            }
            public Enum_Class_Misc Money
            {
                get
                {
                    return this._Money;
                }
                set
                {
                    this._Money = value;
                }
            }
            public Enum_Class_Misc Misc_Duty_Insurance
            {
                get
                {
                    return this._Misc_Duty_Insurance;
                }
                set
                {
                    this._Misc_Duty_Insurance = value;
                }
            }
            public Enum_Class_Misc Cover_Note
            {
                get
                {
                    return this._Cover_Note;
                }
                set
                {
                    this._Cover_Note = value;
                }
            }
            public Enum_Class_Misc Gold
            {
                get
                {
                    return this._Gold;
                }
                set
                {
                    this._Gold = value;
                }
            }
            public Enum_Class_Misc Strong_Room_Burglary
            {
                get
                {
                    return this._Strong_Room_Burglary;
                }
                set
                {
                    this._Strong_Room_Burglary = value;
                }
            }
            public Enum_Class_Misc Press_Accident
            {
                get
                {
                    return this._Press_Accident;
                }
                set
                {
                    this._Press_Accident = value;
                }
            }
            public Enum_Class_Misc Strong_Room_Fire
            {
                get
                {
                    return this._Strong_Room_Fire;
                }
                set
                {
                    this._Strong_Room_Fire = value;
                }
            }
            public Enum_Class_Misc Cash_Counter
            {
                get
                {
                    return this._Cash_Counter;
                }
                set
                {
                    this._Cash_Counter = value;
                }
            }
            public Enum_Class_Misc Vehicle_Personal_Accident
            {
                get
                {
                    return this._Vehicle_Personal_Accident;
                }
                set
                {
                    this._Vehicle_Personal_Accident = value;
                }
            }
            public Enum_Class_Misc Directors_and_Officers_Liability
            {
                get
                {
                    return this._Directors_and_Officers_Liability;
                }
                set
                {
                    this._Directors_and_Officers_Liability = value;
                }
            }
            public Enum_Class_Misc Householder_Insurance
            {
                get
                {
                    return this._Householder_Insurance;
                }
                set
                {
                    this._Householder_Insurance = value;
                }
            }
            public Enum_Class_Misc Individual_And_Group_Mobile
            {
                get
                {
                    return this._Individual_And_Group_Mobile;
                }
                set
                {
                    this._Individual_And_Group_Mobile = value;
                }
            }
            public Enum_Class_Misc Pedal_Cycle
            {
                get
                {
                    return this._Pedal_Cycle;
                }
                set
                {
                    this._Pedal_Cycle = value;
                }
            }
            public Enum_Class_Misc Student_Safety_Insurance
            {
                get
                {
                    return this._Student_Safety_Insurance;
                }
                set
                {
                    this._Student_Safety_Insurance = value;
                }
            }
            #endregion properties
            #endregion for Miscellaneous

            #region for Engineering
            #region private variables
            private Enum_Class_Engg _Contractors_All_Risk = Enum_Class_Engg.Contractors_All_Risk;
            private Enum_Class_Engg _Machinery_Breakdown_Insurance = Enum_Class_Engg.Machinery_Breakdown_Insurance;
            private Enum_Class_Engg _Erection_All_Risk = Enum_Class_Engg.Erection_All_Risk;
            private Enum_Class_Engg _Contractors_Plant_and_Machinary = Enum_Class_Engg.Contractors_Plant_and_Machinary;
            private Enum_Class_Engg _Electronic_Equipment_Insurance = Enum_Class_Engg.Electronic_Equipment_Insurance;
            private Enum_Class_Engg _Boiler_and_Pressure_Plant = Enum_Class_Engg.Boiler_and_Pressure_Plant;
            private Enum_Class_Engg _Marine_cum_Erection = Enum_Class_Engg.Marine_cum_Erection;
            private Enum_Class_Engg _Loss_Of_Profit_or_Consequential_loss = Enum_Class_Engg.Loss_Of_Profit_or_Consequential_loss;
            private Enum_Class_Engg _Consequential_Loss = Enum_Class_Engg.Consequential_Loss;
            private Enum_Class_Engg _Electronic_Equipments = Enum_Class_Engg.Electronic_Equipments;
            private Enum_Class_Engg _Industrial_All_Risk = Enum_Class_Engg.Industrial_All_Risk;
            private Enum_Class_Engg _Deterioration_of_Stock = Enum_Class_Engg.Deterioration_of_Stock;
            private Enum_Class_Engg _Storage_cum_Erection = Enum_Class_Engg.Storage_cum_Erection;
            #endregion private variables
            #region properties
            public Enum_Class_Engg Contractors_All_Risk
            {
                get
                {
                    return this._Contractors_All_Risk;
                }
                set
                {
                    this._Contractors_All_Risk = value;
                }
            }
            public Enum_Class_Engg Machinery_Breakdown_Insurance
            {
                get
                {
                    return this._Machinery_Breakdown_Insurance;
                }
                set
                {
                    this._Machinery_Breakdown_Insurance = value;
                }
            }
            public Enum_Class_Engg Erection_All_Risk
            {
                get
                {
                    return this._Erection_All_Risk;
                }
                set
                {
                    this._Erection_All_Risk = value;
                }
            }
            public Enum_Class_Engg Contractors_Plant_and_Machinary
            {
                get
                {
                    return this._Contractors_Plant_and_Machinary;
                }
                set
                {
                    this._Contractors_Plant_and_Machinary = value;
                }
            }
            public Enum_Class_Engg Electronic_Equipment_Insurance
            {
                get
                {
                    return this._Electronic_Equipment_Insurance;
                }
                set
                {
                    this._Electronic_Equipment_Insurance = value;
                }
            }
            public Enum_Class_Engg Boiler_and_Pressure_Plant
            {
                get
                {
                    return this._Boiler_and_Pressure_Plant;
                }
                set
                {
                    this._Boiler_and_Pressure_Plant = value;
                }
            }
            public Enum_Class_Engg Marine_cum_Erection
            {
                get
                {
                    return this._Marine_cum_Erection;
                }
                set
                {
                    this._Marine_cum_Erection = value;
                }
            }
            public Enum_Class_Engg Loss_Of_Profit_or_Consequential_loss
            {
                get
                {
                    return this._Loss_Of_Profit_or_Consequential_loss;
                }
                set
                {
                    this._Loss_Of_Profit_or_Consequential_loss = value;
                }
            }
            public Enum_Class_Engg Consequential_Loss
            {
                get
                {
                    return this._Consequential_Loss;
                }
                set
                {
                    this._Consequential_Loss = value;
                }
            }
            public Enum_Class_Engg Electronic_Equipments
            {
                get
                {
                    return this._Electronic_Equipments;
                }
                set
                {
                    this._Electronic_Equipments = value;
                }
            }
            public Enum_Class_Engg Industrial_All_Risk
            {
                get
                {
                    return this._Industrial_All_Risk;
                }
                set
                {
                    this._Industrial_All_Risk = value;
                }
            }
            public Enum_Class_Engg Deterioration_of_Stock
            {
                get
                {
                    return this._Deterioration_of_Stock;
                }
                set
                {
                    this._Deterioration_of_Stock = value;
                }
            }
            public Enum_Class_Engg Storage_cum_Erection
            {
                get
                {
                    return this._Storage_cum_Erection;
                }
                set
                {
                    this._Storage_cum_Erection = value;
                }
            }
            #endregion properties
            #endregion for Engineering

            #region for Aviation
            #region private variables
            private Enum_Class_Aviation _Aviation = Enum_Class_Aviation.Aviation;
            private Enum_Class_Aviation _Loss_of_Lisence = Enum_Class_Aviation.Loss_of_Lisence;
            #endregion private variables
            #region properties
            public Enum_Class_Aviation Aviation
            {
                get
                {
                    return this._Aviation;
                }
                set
                {
                    this._Aviation = value;
                }
            }
            public Enum_Class_Aviation Loss_of_Lisence
            {
                get
                {
                    return this._Loss_of_Lisence;
                }
                set
                {
                    this._Loss_of_Lisence = value;
                }
            }
            #endregion properties
            #endregion for Aviation

            #region for Micro
            #region private variables
            private Enum_Class_Agriculture _Fruit = Enum_Class_Agriculture.Fruit;
            private Enum_Class_Agriculture _Tarkari_Bari = Enum_Class_Agriculture.Tarkari_Bari;
            private Enum_Class_Agriculture _Potato = Enum_Class_Agriculture.Potato;
            private Enum_Class_Agriculture _Crop = Enum_Class_Agriculture.Crop;
            private Enum_Class_Agriculture _Cattle = Enum_Class_Agriculture.Cattle;
            private Enum_Class_Agriculture _Birds = Enum_Class_Agriculture.Birds;
            private Enum_Class_Agriculture _Fish = Enum_Class_Agriculture.Fish;
            #endregion private variables
            #region properties
            public Enum_Class_Agriculture Fruit
            {
                get
                {
                    return this._Fruit;
                }
                set
                {
                    this._Fruit = value;
                }
            }
            public Enum_Class_Agriculture Tarkari_Bari
            {
                get
                {
                    return this._Tarkari_Bari;
                }
                set
                {
                    this._Tarkari_Bari = value;
                }
            }
            public Enum_Class_Agriculture Potato
            {
                get
                {
                    return this._Potato;
                }
                set
                {
                    this._Potato = value;
                }
            }
            public Enum_Class_Agriculture Crop
            {
                get
                {
                    return this._Crop;
                }
                set
                {
                    this._Crop = value;
                }
            }
            public Enum_Class_Agriculture Cattle
            {
                get
                {
                    return this._Cattle;
                }
                set
                {
                    this._Cattle = value;
                }
            }
            public Enum_Class_Agriculture Birds
            {
                get
                {
                    return this._Birds;
                }
                set
                {
                    this._Birds = value;
                }
            }
            public Enum_Class_Agriculture Fish
            {
                get
                {
                    return this._Fish;
                }
                set
                {
                    this._Fish = value;
                }
            }
            #endregion properties
            #endregion for Micro

            #endregion for classes
        }

        public class DocType
        {
            #region for Doc Type
            #region private variables
            private Enum_DocType _Fresh = Enum_DocType.Fresh;
            private Enum_DocType _Endoresment = Enum_DocType.Endoresment;
            private Enum_DocType _Renewal = Enum_DocType.Renewal;
            #endregion private variables
            #region properties
            public Enum_DocType Fresh
            {
                get
                {
                    return this._Fresh;
                }
                set
                {
                    this._Fresh = value;
                }
            }
            public Enum_DocType Endoresment
            {
                get
                {
                    return this._Endoresment;
                }
                set
                {
                    this._Endoresment = value;
                }
            }
            public Enum_DocType Renewal
            {
                get
                {
                    return this._Renewal;
                }
                set
                {
                    this._Renewal = value;
                }
            }
            #endregion properties
            #endregion for Doc Type
        }

        public class EndorseType
        {
            #region for Endorse type
            #region private variables
            private Enum_EndorseType _Additional = Enum_EndorseType.Additional;
            private Enum_EndorseType _Refund = Enum_EndorseType.Refund;
            private Enum_EndorseType _Nil = Enum_EndorseType.Nil;
            private Enum_EndorseType _Cancellation = Enum_EndorseType.Cancellation;
            private Enum_EndorseType _Name_Transfer = Enum_EndorseType.Name_Transfer;
            #endregion private variables
            #region properties
            public Enum_EndorseType Additional
            {
                get
                {
                    return this._Additional;
                }
                set
                {
                    this._Additional = value;
                }
            }
            public Enum_EndorseType Refund
            {
                get
                {
                    return this._Refund;
                }
                set
                {
                    this._Refund = value;
                }
            }
            public Enum_EndorseType Nil
            {
                get
                {
                    return this._Nil;
                }
                set
                {
                    this._Nil = value;
                }
            }
            public Enum_EndorseType Cancellation
            {
                get
                {
                    return this._Cancellation;
                }
                set
                {
                    this._Cancellation = value;
                }
            }
            public Enum_EndorseType Name_Transfer
            {
                get
                {
                    return this._Name_Transfer;
                }
                set
                {
                    this._Name_Transfer = value;
                }
            }
            #endregion properties
            #endregion for Endorse type
        }

        public class BusiType
        {
            #region for Business type
            #region private variables
            private Enum_BusiType _New_Business = Enum_BusiType.New_Business;
            private Enum_BusiType _Outward_CoInsurance = Enum_BusiType.Outward_CoInsurance;
            private Enum_BusiType _Inward_CoInsurance = Enum_BusiType.Inward_CoInsurance;
            private Enum_BusiType _Declaration_Policy = Enum_BusiType.Declaration_Policy;
            private Enum_BusiType _Inward_Policy = Enum_BusiType.Inward_Policy;
            private Enum_BusiType _Inward_Coinsurance_Declaration = Enum_BusiType.Inward_CoInsurance_Declaration;
            private Enum_BusiType _Outward_Coinsurance_Declaration = Enum_BusiType.Outward_CoInsurance_Declaration;
            #endregion private variables
            #region properties
            public Enum_BusiType New_Business
            {
                get
                {
                    return this._New_Business;
                }
                set
                {
                    this._New_Business = value;
                }
            }
            public Enum_BusiType Outward_CoInsurance
            {
                get
                {
                    return this._Outward_CoInsurance;
                }
                set
                {
                    this._Outward_CoInsurance = value;
                }
            }
            public Enum_BusiType Inward_CoInsurance
            {
                get
                {
                    return this._Inward_CoInsurance;
                }
                set
                {
                    this._Inward_CoInsurance = value;
                }
            }
            public Enum_BusiType Declaration_Policy
            {
                get
                {
                    return this._Declaration_Policy;
                }
                set
                {
                    this._Declaration_Policy = value;
                }
            }
            public Enum_BusiType Inward_Policy
            {
                get
                {
                    return this._Inward_Policy;
                }
                set
                {
                    this._Inward_Policy = value;
                }
            }
            public Enum_BusiType Inward_Coinsurance_Declaration
            {
                get
                {
                    return this._Inward_Coinsurance_Declaration;
                }
                set
                {
                    this._Inward_Coinsurance_Declaration = value;
                }
            }
            public Enum_BusiType Outward_Coinsurance_Declaration
            {
                get
                {
                    return this._Outward_Coinsurance_Declaration;
                }
                set
                {
                    this._Outward_Coinsurance_Declaration = value;
                }
            }
            #endregion properties
            #endregion for Business type
        }

        public class ClaimStatus
        {
            #region for ClaimStatus
            #region private variables
            private Enum_ClaimStatus _REGISTERED = Enum_ClaimStatus.REGISTERED;
            private Enum_ClaimStatus _SURVEYOR_DEPUTED = Enum_ClaimStatus.SURVEYOR_DEPUTED;
            private Enum_ClaimStatus _CLAIM_PROCESSING = Enum_ClaimStatus.CLAIM_PROCESSING;
            private Enum_ClaimStatus _APPROVED = Enum_ClaimStatus.APPROVED;
            private Enum_ClaimStatus _DV_SENT_TO_CLIENT = Enum_ClaimStatus.DV_SENT_TO_CLIENT;
            private Enum_ClaimStatus _DV_SIGNED_FROM_CLIENT = Enum_ClaimStatus.DV_SIGNED_FROM_CLIENT;
            private Enum_ClaimStatus _FORWARDED_TO_RI = Enum_ClaimStatus.FORWARDED_TO_RI;
            private Enum_ClaimStatus _FORWARDED_TO_ACCOUNT = Enum_ClaimStatus.FORWARDED_TO_ACCOUNT;
            //private Enum_ClaimStatus _PARTLY_SETTLED = Enum_ClaimStatus.PARTLY_SETTLED;
            private Enum_ClaimStatus _SETTLED = Enum_ClaimStatus.SETTLED;
            private Enum_ClaimStatus _WITHDRAWN = Enum_ClaimStatus.WITHDRAWN;
            private Enum_ClaimStatus _SETTLED_SF_ONLY = Enum_ClaimStatus.SETTLED_SF_APPROVAL;
            #endregion private variables
            #region properties
            public Enum_ClaimStatus REGISTERED
            {
                get
                {
                    return this._REGISTERED;
                }
                set
                {
                    this._REGISTERED = value;
                }
            }
            public Enum_ClaimStatus SURVEYOR_DEPUTED
            {
                get
                {
                    return this._SURVEYOR_DEPUTED;
                }
                set
                {
                    this._SURVEYOR_DEPUTED = value;
                }
            }
            public Enum_ClaimStatus CLAIM_PROCESSING
            {
                get
                {
                    return this._CLAIM_PROCESSING;
                }
                set
                {
                    this._CLAIM_PROCESSING = value;
                }
            }
            public Enum_ClaimStatus APPROVED
            {
                get
                {
                    return this._APPROVED;
                }
                set
                {
                    this._APPROVED = value;
                }
            }
            public Enum_ClaimStatus DV_SENT_TO_CLIENT
            {
                get
                {
                    return this._DV_SENT_TO_CLIENT;
                }
                set
                {
                    this._DV_SENT_TO_CLIENT = value;
                }
            }
            public Enum_ClaimStatus DV_SIGNED_FROM_CLIENT
            {
                get
                {
                    return this._DV_SIGNED_FROM_CLIENT;
                }
                set
                {
                    this._DV_SIGNED_FROM_CLIENT = value;
                }
            }
            public Enum_ClaimStatus FORWARDED_TO_RI
            {
                get
                {
                    return this._FORWARDED_TO_RI;
                }
                set
                {
                    this._FORWARDED_TO_RI = value;
                }
            }
            public Enum_ClaimStatus FORWARDED_TO_ACCOUNT
            {
                get
                {
                    return this._FORWARDED_TO_ACCOUNT;
                }
                set
                {
                    this._FORWARDED_TO_ACCOUNT = value;
                }
            }

            public Enum_ClaimStatus SETTLED
            {
                get
                {
                    return this._SETTLED;
                }
                set
                {
                    this._SETTLED = value;
                }
            }
            public Enum_ClaimStatus WITHDRAWN
            {
                get
                {
                    return this._WITHDRAWN;
                }
                set
                {
                    this._WITHDRAWN = value;
                }
            }
            public Enum_ClaimStatus SETTLED_SF_ONLY
            {
                get
                {
                    return this._SETTLED_SF_ONLY;
                }
                set
                {
                    this._SETTLED_SF_ONLY = value;
                }
            }
            #endregion properties
            #endregion for ClaimStatus
        }

        public class RiTypes
        {
            #region for RiTypes
            #region private variables
            private Enum_RiTypes _RETENTION = Enum_RiTypes.RETENTION;
            private Enum_RiTypes _QUOTA = Enum_RiTypes.QUOTA;
            private Enum_RiTypes _SURPLUS_I = Enum_RiTypes.SURPLUS_I;
            private Enum_RiTypes _SURPLUS_II = Enum_RiTypes.SURPLUS_II;
            private Enum_RiTypes _AUTO_FAC = Enum_RiTypes.AUTO_FAC;
            private Enum_RiTypes _FACULTATIVE = Enum_RiTypes.FACULTATIVE;
            private Enum_RiTypes _MKT_POOL = Enum_RiTypes.MKT_POOL;
            //private Enum_RiTypes _Micro = Enum_RiTypes.Micro;
            #endregion private variables
            #region properties
            public Enum_RiTypes RETENTION
            {
                get
                {
                    return this._RETENTION;
                }
                set
                {
                    this._RETENTION = value;
                }
            }
            public Enum_RiTypes QUOTA
            {
                get
                {
                    return this._QUOTA;
                }
                set
                {
                    this._QUOTA = value;
                }
            }
            public Enum_RiTypes SURPLUS_I
            {
                get
                {
                    return this._SURPLUS_I;
                }
                set
                {
                    this._SURPLUS_I = value;
                }
            }
            public Enum_RiTypes SURPLUS_II
            {
                get
                {
                    return this._SURPLUS_II;
                }
                set
                {
                    this._SURPLUS_II = value;
                }
            }
            public Enum_RiTypes AUTO_FAC
            {
                get
                {
                    return this._AUTO_FAC;
                }
                set
                {
                    this._AUTO_FAC = value;
                }
            }
            public Enum_RiTypes FACULTATIVE
            {
                get
                {
                    return this._FACULTATIVE;
                }
                set
                {
                    this._FACULTATIVE = value;
                }
            }
            public Enum_RiTypes MKT_POOL
            {
                get
                {
                    return this._MKT_POOL;
                }
                set
                {
                    this._MKT_POOL = value;
                }
            }
            //public Enum_RiTypes Micro
            //{
            //    get
            //    {
            //        return this._Micro;
            //    }
            //    set
            //    {
            //        this._Micro = value;
            //    }
            //}
            #endregion properties
            #endregion for RiTypes
        }

        public class PremiumPaid
        {
            #region for Endorse type
            #region private variables
            private Enum_PremiumPaid _UNPAID = Enum_PremiumPaid.UNPAID;
            private Enum_PremiumPaid _PAID = Enum_PremiumPaid.PAID;
            private Enum_PremiumPaid _PAID_VIA_CREDITNOTE = Enum_PremiumPaid.PAID_VIA_CREDITNOTE;
            private Enum_PremiumPaid _PARTIALLY_PAID = Enum_PremiumPaid.PARTIALLY_PAID;
            #endregion private variables
            #region properties
            public Enum_PremiumPaid UNPAID
            {
                get
                {
                    return this._UNPAID;
                }
                set
                {
                    this._UNPAID = value;
                }
            }
            public Enum_PremiumPaid PAID
            {
                get
                {
                    return this._PAID;
                }
                set
                {
                    this._PAID = value;
                }
            }
            public Enum_PremiumPaid PAID_VIA_CREDITNOTE
            {
                get
                {
                    return this._PAID_VIA_CREDITNOTE;
                }
                set
                {
                    this._PAID_VIA_CREDITNOTE = value;
                }
            }
            public Enum_PremiumPaid PARTIALLY_PAID
            {
                get
                {
                    return this._PARTIALLY_PAID;
                }
                set
                {
                    this._PARTIALLY_PAID = value;
                }
            }
            #endregion properties
            #endregion for Endorse type
        }

        public class ModuleName
        {
            #region private variables
            private Enum_ModuleName _GENERAL_REPORT = Enum_ModuleName.GENERAL_REPORT;
            private Enum_ModuleName _CLAIM_REPORT = Enum_ModuleName.CLAIM_REPORT;
            private Enum_ModuleName _RI_REPORT = Enum_ModuleName.RI_REPORT;
            #endregion

            #region properties
            public Enum_ModuleName GENERAL_REPORT
            {
                get
                {
                    return this._GENERAL_REPORT;
                }
                set
                {
                    this._GENERAL_REPORT = value;
                }
            }
            public Enum_ModuleName CLAIM_REPORT
            {
                get
                {
                    return this._CLAIM_REPORT;
                }
                set
                {
                    this._CLAIM_REPORT = value;
                }
            }
            public Enum_ModuleName RI_REPORT
            {
                get
                {
                    return this._RI_REPORT;
                }
                set
                {
                    this.RI_REPORT = value;
                }
            }
            #endregion
        }

        public class Motor_Risk_SN
        {
            #region private variables
            private Enum_Mot_Risk_SN _Basic_Premium = Enum_Mot_Risk_SN.Basic_Premium;
            private Enum_Mot_Risk_SN _Additional_Premium = Enum_Mot_Risk_SN.Additional_Premium;
            private Enum_Mot_Risk_SN _Trailor = Enum_Mot_Risk_SN.Trailor;
            private Enum_Mot_Risk_SN _Manufacture_Yr = Enum_Mot_Risk_SN.Manufacture_Year;
            private Enum_Mot_Risk_SN _Own_goods_carrying = Enum_Mot_Risk_SN.Own_Goods_Carrying;
            private Enum_Mot_Risk_SN _Rent_for_private_use = Enum_Mot_Risk_SN.Rent_for_private_use;

            private Enum_Mot_Risk_SN _Excess_own_damage = Enum_Mot_Risk_SN.Excess_own_damage;
            private Enum_Mot_Risk_SN _Fleet_Discount = Enum_Mot_Risk_SN.Fleet_Discount;
            private Enum_Mot_Risk_SN _PA_to_Driver = Enum_Mot_Risk_SN.PA_to_Driver;
            private Enum_Mot_Risk_SN _PA_to_Driver_Rsd = Enum_Mot_Risk_SN.PA_to_Driver_Rsd;
            private Enum_Mot_Risk_SN _PA_to_Conductor = Enum_Mot_Risk_SN.PA_to_Conductor;
            private Enum_Mot_Risk_SN _PA_to_Conductor_RSD = Enum_Mot_Risk_SN.PA_to_Conductor_RSD;
            private Enum_Mot_Risk_SN _PA_to_Cleaner = Enum_Mot_Risk_SN.PA_to_Cleaner;
            private Enum_Mot_Risk_SN _PA_to_Cleaner_RSD = Enum_Mot_Risk_SN.PA_to_Cleaner_RSD;
            private Enum_Mot_Risk_SN _Other_SI = Enum_Mot_Risk_SN.Other_SI;
            private Enum_Mot_Risk_SN _Other_SI_RSD = Enum_Mot_Risk_SN.Other_SI_RSD;


            private Enum_Mot_Risk_SN _PA_Passenger = Enum_Mot_Risk_SN.PA_Passenger;
            private Enum_Mot_Risk_SN _PA_Passenger_RSD = Enum_Mot_Risk_SN.PA_Passenger_RSD;
            private Enum_Mot_Risk_SN _No_Claim_Discount = Enum_Mot_Risk_SN.No_Claim_Discount;
            private Enum_Mot_Risk_SN _RSD = Enum_Mot_Risk_SN.RSD;
            private Enum_Mot_Risk_SN _Terrorism = Enum_Mot_Risk_SN.Terrorism;
            private Enum_Mot_Risk_SN _Government_Discount = Enum_Mot_Risk_SN.Government_Discount;
            private Enum_Mot_Risk_SN _Third_Party = Enum_Mot_Risk_SN.Third_Party;
            private Enum_Mot_Risk_SN _Third_Party_NCD = Enum_Mot_Risk_SN.Third_Party_NCD;

            private Enum_Mot_Risk_SN _Discount_as_per_CC = Enum_Mot_Risk_SN.Discount_as_per_CC;
            private Enum_Mot_Risk_SN _Corporate_or_Special_Discount = Enum_Mot_Risk_SN.Corporate_or_Special_Discount;
            private Enum_Mot_Risk_SN _Towing_Charge = Enum_Mot_Risk_SN.Towing_Charge;
            private Enum_Mot_Risk_SN _Trailor_Capacity_Discount = Enum_Mot_Risk_SN.Trailor_Capacity_Discount;
            private Enum_Mot_Risk_SN _Trailor_Third_Party = Enum_Mot_Risk_SN.Trailor_Third_Party;
            private Enum_Mot_Risk_SN _Discount_on_Suminsured = Enum_Mot_Risk_SN.Discount_on_Suminsured;
            private Enum_Mot_Risk_SN _Capacity_Loading = Enum_Mot_Risk_SN.Capacity_Loading;
            private Enum_Mot_Risk_SN _Staff_Discount = Enum_Mot_Risk_SN.Staff_Discount;
            private Enum_Mot_Risk_SN _Transfer_Fee = Enum_Mot_Risk_SN.Transfer_Fee;
            private Enum_Mot_Risk_SN _Pound_Premium = Enum_Mot_Risk_SN.Pound_Premium;
            private Enum_Mot_Risk_SN _Minimum_Premium = Enum_Mot_Risk_SN.Minimum_Premium;

            #endregion private variables
            #region properties
            public Enum_Mot_Risk_SN Basic_premium
            {
                get
                {
                    return this._Basic_Premium;
                }
                set
                {
                    this._Basic_Premium = value;
                }
            }
            public Enum_Mot_Risk_SN Additional_premium
            {
                get
                {
                    return this._Additional_Premium;
                }
                set
                {
                    this._Additional_Premium = value;
                }
            }
            public Enum_Mot_Risk_SN Trailor
            {
                get
                {
                    return this._Trailor;
                }
                set
                {
                    this._Trailor = value;
                }
            }
            public Enum_Mot_Risk_SN Manufacture_Year
            {
                get
                {
                    return this._Manufacture_Yr;
                }
                set
                {
                    this._Manufacture_Yr = value;
                }
            }
            public Enum_Mot_Risk_SN Own_Goods_Carrying
            {
                get
                {
                    return this._Own_goods_carrying;
                }
                set
                {
                    this._Own_goods_carrying = value;
                }
            }
            public Enum_Mot_Risk_SN Rent_for_private_use
            {
                get
                {
                    return this._Rent_for_private_use;
                }
                set
                {
                    this._Rent_for_private_use = value;
                }
            }
            public Enum_Mot_Risk_SN Excess_own_damage
            {
                get
                {
                    return this._Excess_own_damage;
                }
                set
                {
                    this._Excess_own_damage = value;
                }
            }
            public Enum_Mot_Risk_SN Fleet_Discount
            {
                get
                {
                    return this._Fleet_Discount;
                }
                set
                {
                    this._Fleet_Discount = value;
                }
            }
            public Enum_Mot_Risk_SN PA_to_Driver
            {
                get
                {
                    return this._PA_to_Driver;
                }
                set
                {
                    this._PA_to_Driver = value;
                }
            }
            public Enum_Mot_Risk_SN PA_to_Driver_Rsd
            {
                get
                {
                    return this._PA_to_Driver_Rsd;
                }
                set
                {
                    this._PA_to_Driver_Rsd = value;
                }
            }
            public Enum_Mot_Risk_SN PA_to_Conductor
            {
                get
                {
                    return this._PA_to_Conductor;
                }
                set
                {
                    this._PA_to_Conductor = value;
                }
            }
            public Enum_Mot_Risk_SN PA_to_Conductor_RSD
            {
                get
                {
                    return this._PA_to_Conductor_RSD;
                }
                set
                {
                    this._PA_to_Conductor_RSD = value;
                }
            }
            public Enum_Mot_Risk_SN PA_to_Cleaner
            {
                get
                {
                    return this._PA_to_Cleaner;
                }
                set
                {
                    this._PA_to_Cleaner = value;
                }
            }
            public Enum_Mot_Risk_SN PA_to_Cleaner_RSD
            {
                get
                {
                    return this._PA_to_Cleaner_RSD;
                }
                set
                {
                    this._PA_to_Cleaner_RSD = value;
                }
            }
            public Enum_Mot_Risk_SN Other_SI
            {
                get
                {
                    return this._Other_SI;
                }
                set
                {
                    this._Other_SI = value;
                }
            }
            public Enum_Mot_Risk_SN Other_SI_RSD
            {
                get
                {
                    return this._Other_SI_RSD;
                }
                set
                {
                    this._Other_SI_RSD = value;
                }
            }
            public Enum_Mot_Risk_SN PA_Passenger
            {
                get
                {
                    return this._PA_Passenger;
                }
                set
                {
                    this._PA_Passenger = value;
                }
            }
            public Enum_Mot_Risk_SN PA_Passenger_RSD
            {
                get
                {
                    return this._PA_Passenger_RSD;
                }
                set
                {
                    this._PA_Passenger_RSD = value;
                }
            }
            public Enum_Mot_Risk_SN No_Claim_Discount
            {
                get
                {
                    return this._No_Claim_Discount;
                }
                set
                {
                    this._No_Claim_Discount = value;
                }
            }
            public Enum_Mot_Risk_SN RSD
            {
                get
                {
                    return this._RSD;
                }
                set
                {
                    this._RSD = value;
                }
            }
            public Enum_Mot_Risk_SN Terrorism
            {
                get
                {
                    return this._Terrorism;
                }
                set
                {
                    this._Terrorism = value;
                }
            }
            public Enum_Mot_Risk_SN Government_Discount
            {
                get
                {
                    return this._Government_Discount;
                }
                set
                {
                    this._Government_Discount = value;
                }
            }
            public Enum_Mot_Risk_SN Third_Party
            {
                get
                {
                    return this._Third_Party;
                }
                set
                {
                    this._Third_Party = value;
                }
            }
            public Enum_Mot_Risk_SN Third_Party_NCD
            {
                get
                {
                    return this._Third_Party_NCD;
                }
                set
                {
                    this._Third_Party_NCD = value;
                }
            }
            public Enum_Mot_Risk_SN Discount_as_per_CC
            {
                get
                {
                    return this._Discount_as_per_CC;
                }
                set
                {
                    this._Discount_as_per_CC = value;
                }
            }
            public Enum_Mot_Risk_SN Corporate_or_Special_Discount
            {
                get
                {
                    return this._Corporate_or_Special_Discount;
                }
                set
                {
                    this._Corporate_or_Special_Discount = value;
                }
            }
            public Enum_Mot_Risk_SN Towing_Charge
            {
                get
                {
                    return this._Towing_Charge;
                }
                set
                {
                    this._Towing_Charge = value;
                }
            }
            public Enum_Mot_Risk_SN Trailor_Capacity_Discount
            {
                get
                {
                    return this._Trailor_Capacity_Discount;
                }
                set
                {
                    this._Trailor_Capacity_Discount = value;
                }
            }
            public Enum_Mot_Risk_SN Trailor_Third_Party
            {
                get
                {
                    return this._Trailor_Third_Party;
                }
                set
                {
                    this._Trailor_Third_Party = value;
                }
            }
            public Enum_Mot_Risk_SN Discount_on_Suminsured
            {
                get
                {
                    return this._Discount_on_Suminsured;
                }
                set
                {
                    this._Discount_on_Suminsured = value;
                }
            }
            public Enum_Mot_Risk_SN Capacity_Loading
            {
                get
                {
                    return this._Capacity_Loading;
                }
                set
                {
                    this._Capacity_Loading = value;
                }
            }
            public Enum_Mot_Risk_SN Staff_Discount
            {
                get
                {
                    return this._Staff_Discount;
                }
                set
                {
                    this._Staff_Discount = value;
                }
            }


            public Enum_Mot_Risk_SN Transfer_Fee
            {
                get
                {
                    return this._Transfer_Fee;
                }
                set
                {
                    this._Transfer_Fee = value;
                }
            }
            public Enum_Mot_Risk_SN Pound_Premium
            {
                get
                {
                    return this._Pound_Premium;
                }
                set
                {
                    this._Pound_Premium = value;
                }
            }
            public Enum_Mot_Risk_SN Minimum_Premium
            {
                get
                {
                    return this._Minimum_Premium;
                }
                set
                {
                    this._Minimum_Premium = value;
                }
            }

            #endregion properties

        }


    }




}