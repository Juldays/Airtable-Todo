using AirtableApiClient;
using System.Collections.Generic;
using Todo.Models;

namespace Todo.Services
{
    public interface IAirtableService
    {
        int Create(RecordCreateRequest req);
        //List<Record> GetAll();
        AirtableRecord GetById(int id);
    }
}