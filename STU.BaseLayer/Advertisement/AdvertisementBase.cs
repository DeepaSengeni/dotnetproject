using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.BaseLayer.Advertisement
{
    public class AdvertisementBase
    {
        public int userId { get; set; }
        public int adId { get; set; }
        public int Id { get; set; }
        public string Response { get; set; }
        public string OrderId { get; set; }
        public int uploadtype { get; set; }
        public string headline { get; set; }
        public string Features { get; set; }
        public string description { get; set; }
        public string urladdress { get; set; }
        public string price { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string Checkstartdate { get; set; }
        public string Checkenddate { get; set; }
        public DataTable fileuploadTable { get; set; }

        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string MultiplecityId { get; set; }
        public string CategoryIds { get; set; }
        public string IFSCCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal AmountToBePaid { get; set; }
        public decimal AmountRequested { get; set; }
        public int Status { get; set; }

        public int ClicksCount { get; set; }

        public string AccountHolderName { get; set; }

        public int BookId { get; set; }

        public string start;
        public string end;

        public decimal amount { get; set; }
        public string Add_Creation_ID { get; set; }
        public decimal ExchangeRate { get; set; }
        public string paymentId { get; set; }
        public string totalammount { get; set; }
        public string Currency { get; set; }
        public string Payer_id { get; set; }
        public string intent { get; set; }
        public string state { get; set; }
        public string sender_batch_id { get; set; }
        public string response_Status { get; set; }
        public string payout_batch_id { get; set; }
        public string BankAccountHolderName { get; set; }
        public string UPIId { get; set; }
        public string MobileNumberUPI { get; set; }
        public string BankAccountNumber { get; set; }

        public string BankIFSCCode { get; set; }

    }

    public class AdvertisementUploadingBase
    {
        public int adcreationId { get; set; }
        public string FileUploadedPath { get; set; }
    }
}
