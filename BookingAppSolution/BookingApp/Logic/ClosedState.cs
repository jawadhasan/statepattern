using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Logic
{
    class ClosedState : BookingState
    {
        private string _reason;

        public ClosedState(string reason)
        {
            _reason = reason;
        }
        public override void EnterState(BookingContext booking)
        {
            booking.ShowState($"Closed: {_reason}");
        }

        public override void Cancel(BookingContext booking)
        {
            booking.ShowError($"Invalid action for this state: ClosedState");
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.ShowError($"Invalid action for this state: ClosedState");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.ShowError($"Invalid action for this state: ClosedState");
        }
    }
}
