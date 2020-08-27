using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.Common
{
    public class clsCommonEnum
    {
        #region Department_and_class
        public enum Enum_Department
        {
            Fire = 1,
            Motor = 2,
            Marine = 3,
            Miscellaneous = 4,
            Engineering = 5,
            Aviation = 6,
            Micro = 7
        }
        public enum Enum_Class_Fire
        {
            Industrial_Risk = 1,
            Commercial_Risk = 2,
            Lop_Industrial_or_Commercial_Risk = 3,
            Non_Industrial_N_Non_Commercial_Risk = 4,
            Traders_Comprehensive = 5,
            HouseHold_Insurance = 6,
            Fire = 7,
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
            Private = 23
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
            Sweet_Home = 82
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
            Storage_cum_Erection = 103
        }
        public enum Enum_Class_Aviation
        {
            Aviation = 111,
            Loss_of_Lisence = 112
        }
        public enum Enum_Class_Micro
        {
            Fruit = 121,
            Tarkari_Bari = 122,
            Potato = 123,
            Crop = 124,
            Cattle = 125,
            Birds = 126,
            Fish = 127,
            Bee=128,
            Ostrich=129,
            Mushroom=130,
            PA = 131,
            MD=132,
            HH=133
        }
        #endregion Department_and_class
    }
}