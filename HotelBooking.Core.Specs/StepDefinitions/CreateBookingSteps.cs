
namespace HotelBooking.Core.Specs.StepDefinitions
{
    [Binding]
    public class CreateBookingSteps
    {
        private Booking booking;
        private bool bookingResult;
        private HotelBookingCore hotelBooking;

        public CreateBookingSteps()
        {
            // Set up any necessary context here
            hotelBooking = new HotelBookingCore();
        }

        [Given("I have selected a valid start date")]
        public void GivenIHaveSelectedAValidStartDate()
        {
            booking = new Booking
            {
                StartDate = DateTime.Now.AddDays(1), // Set a valid start date
                EndDate = DateTime.Now.AddDays(3)    // Set a valid end date
            };
        }

        [When("I request to create a booking")]
        public void WhenIRequestToCreateABooking()
        {
            bookingResult = hotelBooking.CreateBooking(booking);
        }

        [Then("the booking should be created successfully")]
        public void ThenTheBookingShouldBeCreatedSuccessfully()
        {
            Assert.IsTrue(bookingResult, "Booking should be created successfully");
        }

        // Implement similar step definitions for the other scenarios
    }
}
