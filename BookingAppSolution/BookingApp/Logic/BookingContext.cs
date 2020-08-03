using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Logic
{
    public class BookingContext
    {
        private BookingState _currentState;
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingId { get; set; }

        //ctor
        public BookingContext()
        {
            //initial state
            TransitionToState(new NewState());
        }

        public void SubmitDetails(string attendeeName, int ticketCount)
        {
            this._currentState.EnterDetails(this, attendeeName, ticketCount);
        }

        public void Cancel()
        {
            this._currentState.Cancel(this);
        }

        public void DatePassed()
        {
            this._currentState.DatePassed(this);
        }

        public void TransitionToState(BookingState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
        public void ShowState(string stateName)
        {
            Console.WriteLine(stateName);
        }

        public void ShowError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
