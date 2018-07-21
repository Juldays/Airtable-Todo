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
        string tableName = "Assignments";

        public AirtableService()
        {
            
        }

        //============================== GET ALL ===============================
        public async Task<AirtableListRecordsResponse> GetAll()
        {
            string offset = null;
            IEnumerable<string> fields = null;
            string filterByFormula = null;
            int? maxRecords = 100;
            int? pageSize = 100;
            IEnumerable<Sort> sort = null;
            string view = null;

            var records = new List<AirtableRecord>();

            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                Task<AirtableListRecordsResponse> task = airtableBase.ListRecords(
                        tableName,
                        offset,
                        fields,
                        filterByFormula,
                        maxRecords,
                        pageSize,
                        sort,
                        view);

                AirtableListRecordsResponse response = await task;
                if (response.Success)
                {
                    records.AddRange(response.Records.ToList());
                    offset = response.Offset;
                }
                else if (response.AirtableApiError is AirtableApiException)
                {
                    errorMessage = response.AirtableApiError.ErrorMessage;
                }
                else
                {
                    errorMessage = "Unknown error";
                }
                return response;
            }
        }

        //==================== GET BY ID ============================
        public async Task<AirtableRecord> GetById(string id)
        {
            var tableRecord = new AirtableRecord();

            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                AirtableRecord record = new AirtableRecord();
                var retrieveResponse = await airtableBase.RetrieveRecord(tableName, id.ToString());
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

        //=========================== CREATE/POST ===========================================
        public async Task<AirtableCreateUpdateReplaceRecordResponse> Create(RecordCreateRequest req)
        {
            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                var fields = new Fields();
                fields.AddField("Title", req.Title);
                fields.AddField("Priority", req.Priority);
                fields.AddField("Status", req.Status);
                fields.AddField("Due Date", req.DueDate);

                AirtableCreateUpdateReplaceRecordResponse response = await airtableBase.CreateRecord(tableName, fields, true);

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
                    // Do something with your created record.
                    Console.WriteLine("ok");
                }
                return response;
            }
        }

        public async Task<AirtableCreateUpdateReplaceRecordResponse> UpdateRecord(RecordUpdateRequest req)
        {
            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                var fields = new Fields();
                fields.AddField("Title", req.Title);
                fields.AddField("Priority", req.Priority);
                fields.AddField("Status", req.Status);
                fields.AddField("Due Date", req.DueDate);

                AirtableCreateUpdateReplaceRecordResponse response = await airtableBase.UpdateRecord(tableName, fields, req.Id.ToString());
                //var response = await task;

                if (!response.Success)
                {
                    string errorMessage = null;
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
                    // Do something with your updated record.
                }
                return response;
            }
        }

    }
}