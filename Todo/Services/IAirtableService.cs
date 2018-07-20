using AirtableApiClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface IAirtableService
    {
        Task<AirtableCreateUpdateReplaceRecordResponse> Create(RecordCreateRequest req);
        //List<Record> GetAll();
        Task<AirtableRecord> GetById(int id);
    }
}