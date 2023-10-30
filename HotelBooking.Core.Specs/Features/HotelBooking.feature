@CreateBooking
Feature: Creating a Booking
        In order to book a room
        As a hotel guest
        I want to create a booking

Scenario: Successful booking creation
        Given I have selected a valid start date
        And I have selected a valid end date
        When I request to create a booking
        Then the booking should be created successfully

@InvalidStartDate
Scenario: Booking with an invalid start date
        Given I have selected an invalid start date
        And I have selected a valid end date
        When I request to create a booking
        Then the booking should not be created

@InvalidEndDate
Scenario: Booking with an invalid end date
        Given I have selected a valid start date
        And I have selected an invalid end date
        When I request to create a booking
        Then the booking should not be created

@NoRoomsAvailable
Scenario: Booking when no rooms are available
        Given there are no available rooms
        And I have selected a valid start date
        And I have selected a valid end date
        When I request to create a booking
        Then the booking should not be created