﻿namespace BookIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookIt.Data;
    using BookIt.Data.Models;
    using BookIt.Services.Data.Contracts;
    using BookIt.Data.Common.Repositories;

    public class AppointmentsService : IAppointmentsService
    {
        private readonly IBookItData data;

        public AppointmentsService(IBookItData data)
        {
            this.data = data;
        }

        public IQueryable<Appointment> All()
        {
            return this.data.Appointments.All();
        }

        public IQueryable<Appointment> Get(int locationId, DateTime dateTime)
        {
            return this.data.Appointments.All()
                .Where(a => a.LocationId == locationId && a.Start.Date == dateTime.Date);
        }

        public async Task<Appointment> AddNewAsync(Appointment appointment)
        {
            this.data.Appointments.Add(appointment);
            this.data.Appointments.SaveChanges();
            return appointment;
        }
    }
}