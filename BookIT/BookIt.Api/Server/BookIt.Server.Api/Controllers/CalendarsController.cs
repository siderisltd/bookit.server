﻿namespace BookIt.Server.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using BookIt.Server.DataTransferModels.Calendars;
    using Data.Common;
    using Data.Models;
    using Services.Data.Contracts;

    [Authorize(Roles = ConstantRoles.CLIENT_ROLE)]
    [RoutePrefix("api/Calendars")]
    public class CalendarsController : ApiController
    {
        private readonly IAppointmentsService appointmentsService;
        private readonly ILocationsService locationsService;

        public CalendarsController(IAppointmentsService appointmentsService, ILocationsService locationsService)
        {
            this.appointmentsService = appointmentsService;
            this.locationsService = locationsService;
        }

        /// <summary>
        /// Get calendar for particular business on given date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="businessId"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int year, int month, int day, [FromBody]int businessId)
        {
            var date = new DateTime(year, month, day);
            var model = this.appointmentsService.All().ToList();

            return this.Ok(model);
        }

        /// <summary>
        /// Add appointment in business's calendar
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="locationId"></param>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(int year, int month, int day, [FromBody]int locationId, [FromBody]TimeFrame timeFrame)
        {
            var startDate = new DateTime(year, month, day, timeFrame.Start.Hour, timeFrame.Start.Minute, 0);
            var endtDate = new DateTime(year, month, day, timeFrame.End.Hour, timeFrame.End.Minute, 0);
            var newAppointment = new Appointment()
            {
                Location = this.locationsService.GetById(locationId),
                Start = startDate,
                End = endtDate,
            };

            var model = await appointmentsService.AddNewAsync(newAppointment);
            return this.Ok(model);
        }
    }
}