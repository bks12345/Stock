using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CBMSBillPosting
{
    class BillViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string seller_pan { get; set; }
        public string buyer_pan { get; set; }
        public string fiscal_year { get; set; }
        public string buyer_name { get; set; }
        public string invoice_number { get; set; }
        public string invoice_date { get; set; }
        public double total_sales { get; set; }
        public double taxable_sales_vat { get; set; }
        public double vat { get; set; }
        public double excisable_amount { get; set; }
        public double excise { get; set; }
        public double taxable_sales_hst { get; set; }
        public double hst { get; set; }
        public double amount_for_esf { get; set; }
        public double esf { get; set; }
        public double export_sales { get; set; }
        public double tax_exempted_sales { get; set; }

        public bool isrealtime { get; set; }

        public DateTime datetimeclient { get; set; }

        
        public  static string FxsubmitBillData(BillViewModel pp)
        {
            using (var client = new HttpClient())
            {

                BillViewModel p = new BillViewModel
                {
                    username = pp.username,
                    password = pp.password,
                    seller_pan = pp.seller_pan,
                    buyer_pan = pp.buyer_pan,
                    buyer_name = pp.buyer_name,
                    fiscal_year = pp.fiscal_year,
                    invoice_number = pp.invoice_number,
                    invoice_date = pp.invoice_date,
                    total_sales = pp.total_sales,
                    taxable_sales_vat = pp.taxable_sales_vat,
                    vat = pp.vat,
                    excisable_amount = pp.excisable_amount,
                    excise = pp.excise,
                    taxable_sales_hst = pp.taxable_sales_hst,
                    hst = pp.hst,
                    amount_for_esf = pp.amount_for_esf,
                    esf = pp.esf,
                    export_sales = pp.export_sales,
                    tax_exempted_sales = pp.tax_exempted_sales,
                    isrealtime = pp.isrealtime,
                    datetimeclient = pp.datetimeclient
                };
                //BillViewModel p = new BillViewModel
                //{
                //    username = "Test_CBMS",
                //    password = "test@321",
                //    seller_pan = "999999999",
                //    buyer_pan = "222222222",
                //    buyer_name = "buyer_name",
                //    fiscal_year = "17/18",
                //    invoice_number = "002417",
                //    invoice_date = "2074.12.28",
                //    total_sales = 1000,
                //    taxable_sales_vat = 1130,
                //    vat = 130,
                //    excisable_amount = 0,
                //    excise = 0,
                //    taxable_sales_hst = 0,
                //    hst = 0,
                //    amount_for_esf = 0,
                //    esf = 0,
                //    export_sales = 0,
                //    tax_exempted_sales = 0,
                //    isrealtime = true,
                //    datetimeclient = DateTime.Now
                //};

                client.BaseAddress = new Uri("http://202.166.207.75:9050");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("api/bill", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseCode = response.Content.ReadAsStringAsync();
                    responseCode.Wait();
                    if (responseCode.Result == "200")
                    {
                        //Console.Write(responseCode.Result);
                        //Console.ReadLine();
                        return responseCode.Result;

                    }
                    else
                    {
                        //Console.Write("Error code" + responseCode.Result);
                        //Console.ReadLine();
                        return "Error code" + responseCode.Result;
                    }
                }
                else
                {
                    //Console.Write("Error");
                    //Console.ReadLine();
                    return "Error";
                }
            }
        }


    }
    class BillReturnViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string seller_pan { get; set; }
        public string buyer_pan { get; set; }
        public string fiscal_year { get; set; }
        public string buyer_name { get; set; }
        public string ref_invoice_number { get; set; }
        public string credit_note_number { get; set; }
        public string credit_note_date { get; set; }
        public string reason_for_return { get; set; }
        public double total_sales { get; set; }
        public double taxable_sales_vat { get; set; }
        public double vat { get; set; }
        public double excisable_amount { get; set; }
        public double excise { get; set; }
        public double taxable_sales_hst { get; set; }
        public double hst { get; set; }
        public double amount_for_esf { get; set; }
        public double esf { get; set; }
        public double export_sales { get; set; }
        public double tax_exempted_sales { get; set; }
        public bool isrealtime { get; set; }
        public DateTime datetimeclient { get; set; }
        public static string FxPostingBill(BillReturnViewModel pp)
        {
            using (var client = new HttpClient())
            {
                BillReturnViewModel p = new BillReturnViewModel
                {
                    username = pp.username,
                    password = pp.password,
                    seller_pan = pp.seller_pan,
                    buyer_pan = pp.buyer_pan,
                    buyer_name = pp.buyer_name,
                    fiscal_year = pp.fiscal_year,
                    ref_invoice_number = pp.ref_invoice_number,
                    credit_note_date = pp.credit_note_date,
                    credit_note_number = pp.credit_note_number,
                    reason_for_return = pp.reason_for_return,


                    total_sales = pp.total_sales,
                    taxable_sales_vat = pp.taxable_sales_vat,
                    vat = pp.vat,
                    excisable_amount = pp.excisable_amount,
                    excise = pp.excise,
                    taxable_sales_hst = pp.taxable_sales_hst,
                    hst = pp.hst,
                    amount_for_esf = pp.amount_for_esf,
                    esf = pp.esf,
                    export_sales = pp.export_sales,
                    tax_exempted_sales = pp.tax_exempted_sales,
                    isrealtime = pp.isrealtime,
                    datetimeclient = pp.datetimeclient
                };

                client.BaseAddress = new Uri("http://202.166.207.75:9050");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("api/billreturn", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseCode = response.Content.ReadAsStringAsync();
                    if (responseCode.Result == "200")
                    {
                        //Console.Write(responseCode.Result);
                        //Console.ReadLine();
                        return responseCode.Result;

                    }
                    else
                    {
                        //Console.Write("Error code" + responseCode.Result);
                        //Console.ReadLine();
                        return "Error code" + responseCode.Result;
                    }
                }
                else
                {
                    //Console.Write("Error");
                    //Console.ReadLine();
                    return "Error";
                }
            }
        }
    }
    
}
