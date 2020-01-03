using Microsoft.Azure.Cosmos.Table;
//using Microsoft.WindowsAzure.Storage.Table; -- Depricated Version

namespace UploadCsvToAzureStore
{
    public class CustomerTableEtntity : TableEntity
    {
        public CustomerTableEtntity()
        {

        }
        public CustomerTableEtntity(string partitionKey, int id)
        {
            PartitionKey = partitionKey;
            RowKey = id.ToString("00000000");
        }

        public int Id { get; set; }
        public string Qualification { get; set; }
        public string Exam { get; set; }
        public string ExamVersion { get; set; }
        public string Keycode { get; set; }
        public string Score { get; set; }
        public string OriginalScore { get; set; }
        public string Moderated { get; set; }
        public string Percentage { get; set; }
        public string Status { get; set; }
        public string Submitted { get; set; }
        public string Imported { get; set; }
        public string Flagged { get; set; }
        public string VIP { get; set; }
        public string Country { get; set; }
        public string CandidateFullName { get; set; }
        public string CandidateRef { get; set; }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
    }
}
