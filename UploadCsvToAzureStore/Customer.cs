namespace UploadCsvToAzureStore
{
    public class Customer
    {
        public Customer(string[] row)
        {
            int i = -1;
            Qualification = row[++i];
            Exam = row[++i];
            ExamVersion = row[++i];
            Keycode = row[++i];
            Score = row[++i];
            OriginalScore = row[++i];
            Moderated = row[++i];
            Percentage = row[++i];
            Status = row[++i];
            Submitted = row[++i];
            Imported = row[++i];
            Flagged = row[++i];
            VIP = row[++i];
            Country = row[++i];
            CandidateFullName = row[++i];
            CandidateRef = row[++i];
            CentreName = row[++i];
            CentreCode = row[++i];

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