using Microsoft.VisualBasic.FileIO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace UploadCsvToAzureStore
{
    class Program
    {
        //https://gist.github.com/miso-soup/7028c89165de4652cb50
        private static readonly CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
        static void Main(string[] args)
        {
            string[] csvFileList = new string[]
           {
                @"C:\temp\ScriptReview.csv",
           };
            int customerId = 0;

            foreach (var csvFile in csvFileList)
            {
                var parser = new TextFieldParser(csvFile, Encoding.UTF8);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                parser.TrimWhiteSpace = true;

                var customerList = new List<Customer>();

                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    bool isHeader = (row[0] == "Qualification");
                    if (isHeader)
                        continue;

                    var customer = new Customer(row);
                    customer.Id = ++customerId;
                    customerList.Add(customer);
                }
                Insert(customerList, Path.GetFileNameWithoutExtension(csvFile));
            }
        }

        static void Insert(IEnumerable<Customer> customerList, string partitionKey)
        {
            Insert(customerList.Select(customer =>
            {
                var entity = new CustomerTableEtntity(partitionKey, customer.Id);
                entity.Qualification = customer.Qualification;
                entity.Exam = customer.Exam;
                entity.ExamVersion = customer.ExamVersion;
                entity.Keycode = customer.Keycode;
                entity.Score = customer.Score;
                entity.OriginalScore = customer.OriginalScore;
                entity.Moderated = customer.Moderated;
                entity.Percentage = customer.Percentage;
                entity.Status = customer.Status;
                entity.Submitted = customer.Submitted;
                entity.Imported = customer.Imported;
                entity.Flagged = customer.Flagged;
                entity.VIP = customer.VIP;
                entity.Country = customer.Country;
                entity.CandidateFullName = customer.CandidateFullName;
                entity.CandidateRef = customer.CandidateRef;
                entity.CentreName = customer.CentreName;
                entity.CentreCode = customer.CentreCode;
                return entity;
            }));
        }

        static void Insert(IEnumerable<ITableEntity> entities)
        {
            var tableClient = cloudStorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("CustomerTable");
            table.CreateIfNotExists();

            var batchOperations = new TableBatchOperation();

            foreach (var entityGroup in entities.GroupBy(f => f.PartitionKey))
            {
                foreach (var entity in entityGroup)
                {
                    if (batchOperations.Count < 100)
                    {
                        batchOperations.Add(TableOperation.Insert(entity));
                    }
                    else
                    {
                        table.ExecuteBatch(batchOperations);
                        batchOperations = new TableBatchOperation { TableOperation.Insert(entity) };
                    }
                }
                table.ExecuteBatch(batchOperations);
                batchOperations = new TableBatchOperation();
            }

            if (batchOperations.Count > 0)
            {
                table.ExecuteBatch(batchOperations);
            }
        }

        public class CustomerTableEtntity : TableEntity
        {
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
}

