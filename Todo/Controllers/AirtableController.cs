﻿using AirtableApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    public class AirtableController : ApiController
    {
        readonly IAirtableService airtableService;

        public AirtableController(IAirtableService airtableService)
        {
            this.airtableService = airtableService;
        }

        [Route("api/airtable"), HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            AirtableListRecordsResponse records = await airtableService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, records);
        }

        [Route("api/airtable/{id}"), HttpGet]
        public async Task<HttpResponseMessage> GetById(string id)
        {
            AirtableRecord record = await airtableService.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, record);
        }

        [Route("api/airtable"), HttpPost]
        public async Task<HttpResponseMessage> Create(RecordCreateRequest req)
        {
            if (req == null)
            {
                ModelState.AddModelError("", "You did not add any body data");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            AirtableCreateUpdateReplaceRecordResponse id = await airtableService.Create(req);
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }

        [Route("api/airtable/{id}"), HttpPut]
        public async Task<HttpResponseMessage> UpdateRecord(RecordUpdateRequest req)
        {
            if (req == null)
            {
                ModelState.AddModelError("", "You did not add any body data");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            await airtableService.UpdateRecord(req);
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }
    }
}
