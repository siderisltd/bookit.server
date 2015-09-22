﻿namespace BookIt.Server.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Models;
    using Services.Data.Contracts;
    using Data.Models;

    public class CalendarsController : ApiController
    {
        private readonly Data.IBookItData data;
        private readonly IAppointmentsService appointmentsService;
        private readonly ILocationsService locatoinsService;

        // TODO: remove after configing Ninject
        public CalendarsController()
        {
            this.data = new Data.BookItData();
            this.appointmentsService = new Services.Data.AppointmentsService(this.data);
            this.locatoinsService = new Services.Data.LocationsService(this.data);
        }

        public CalendarsController(IAppointmentsService appointmentsService, ILocationsService locationsService)
        {
            this.appointmentsService = appointmentsService;
            this.locatoinsService = locatoinsService;
        }

        // GET: Calendar
        public IHttpActionResult Get(int year, int month, int day, [FromBody]int businessId)
        {
            var date = new DateTime(year, month, day);
            var model = this.appointmentsService.All()
                .ToList();

            return this.Ok(model);
        }

        // [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> Post(int year, int month, int day, [FromBody]int locationId, [FromBody]TimeFrame timeFrame)
        {
            var startDate = new DateTime(year, month, day, timeFrame.Start.Hour, timeFrame.Start.Minute, 0);
            var endtDate = new DateTime(year, month, day, timeFrame.End.Hour, timeFrame.End.Minute, 0);
            var newAppointment = new Appointment()
            {
                Location = this.locatoinsService.GetById(locationId),
                Start = startDate,
                End = endtDate,
            };

            var model = await appointmentsService.AddNewAsync(newAppointment);
            return this.Ok(model);
        }
    }
}