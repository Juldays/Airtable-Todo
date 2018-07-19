using AirtableApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Todo.Models;

namespace Todo.Services
{
    public class AirtableService : IAirtableService
    {
        readonly string baseId = "apptngNOIUAm2X5aG";
        readonly string appKey = "keyq16rBcDGdUCSsh";
        string errorMessage = null;
        //List<AirtableRecord> records = new List<AirtableRecord>();
        string tableName = "Assignments";

        public AirtableService()
        {
            
        }

        public AirtableRecord GetById(int id)
        {
            var tableRecord = new AirtableRecord();
            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                AirtableRecord record = new AirtableRecord();
                Task<AirtableRetrieveRecordResponse> retrieveTask = airtableBase.RetrieveRecord(tableName, id.ToString());
                var retrieveResponse = retrieveTask.Result;
                if (!retrieveResponse.Success)
                {
                    if (retrieveResponse.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = retrieveResponse.AirtableApiError.ErrorMessage;
                    }
                    else
                    {
                        errorMessage = "Unknown error";
                    }
                }
                else
                {
                    tableRecord = retrieveResponse.Record;
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.WriteLine("Error message");
                    // Error reporting
                }
                else
                {
                    Console.WriteLine("Else message");
                    // Do something with the retrieved 'records' and the 'offset'
                    // for the next page of the record list.
                }
            }
            return tableRecord;
        }

        public int Create(RecordCreateRequest req)
        {
            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                var fields = new Fields();
                fields.AddField("Title", req.Title);
                fields.AddField("Priority", req.Priority);
                fields.AddField("Status", req.Status);
                fields.AddField("Due Date", req.DueDate);

                Task<AirtableCreateUpdateReplaceRecordResponse> createTask = airtableBase.CreateRecord(tableName, fields, true);
                var response = createTask.Result;
                var id = createTask.Id;

                if (!response.Success)
                {
                    if (response.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = response.AirtableApiError.ErrorMessage;
                    }
                    else
                    {
                        errorMessage = "Unknown error";
                    }
                    // Report errorMessage
                }
                else
                {
                    var record = response.Record;
                    // Do something with your created record.
                }
                return id;
            }
        }
    }
}