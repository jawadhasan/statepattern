﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Logic
{
    public class NewState : BookingState
    {
        public override void EnterState(BookingContext booking)
        {
           booking.BookingId = new Random().Next();
           booking.ShowState("New");
           //show entry page goes here....
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Cancelled."));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Expired"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.Attendee = attendee;
            booking.TicketCount = ticketCount;
            booking.TransitionToState(new PendingState());
        }
    }
}
