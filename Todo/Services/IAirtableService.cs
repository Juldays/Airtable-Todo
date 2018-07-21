using AirtableApiClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface IAirtableService
    {
        Task<AirtableCreateUpdateReplaceRecordResponse> Create(RecordCreateRequest req);
        Task<AirtableListRecordsResponse> GetAll();
        Task<AirtableRecord> GetById(string id);
        Task<AirtableCreateUpdateReplaceRecordResponse> UpdateRecord(RecordUpdateRequest req);
    }
}