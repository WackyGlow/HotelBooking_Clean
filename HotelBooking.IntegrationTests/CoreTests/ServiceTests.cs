using System;
using System.Collections.Generic;
using HotelBooking.Core;
using Moq;
using Xunit;

namespace HotelBooking.IntegrationTests.CoreTests;

public class ServiceTests
{
    public static IEnumerable<object[]> BookingData =>
        new List<object[]>
        {
            // Test case 1: Successful booking
            new object[] {
                DateTime.Today.AddDays(1),
                DateTime.Today.AddDays(3),
                new List<Room> { new Room { Id = 1 } },
                new List<Booking>
                {
                    new Booking
                    {
                        RoomId = 1,
                        StartDate = DateTime.Today.AddDays(5),
                        EndDate = DateTime.Today.AddDays(7),
                        IsActive = true,
                    }
                },
                true
            },

            // Test case 2: No available room
            new object[] {
                DateTime.Today.AddDays(1),
                DateTime.Today.AddDays(3),
                new List<Room>(),
                new List<Booking>(),
                false
            },
        };

    [Theory]
    [MemberData(nameof(BookingData))]
    public void CreateBooking_ReturnsExpectedResult(
        DateTime startDate,
        DateTime endDate,
        List<Room> availableRooms,
        List<Booking> existingBookings,
        bool expectedResult)
    {
        // Arrange
        var bookingRepositoryMock = new Mock<IRepository<Booking>>();
        var roomRepositoryMock = new Mock<IRepository<Room>>();
        var bookingManager = new BookingManager(bookingRepositoryMock.Object, roomRepositoryMock.Object);

        var booking = new Booking
        {
            StartDate = startDate,
            EndDate = endDate,
        };

        roomRepositoryMock.Setup(repo => repo.GetAll()).Returns(availableRooms);
        bookingRepositoryMock.Setup(repo => repo.GetAll()).Returns(existingBookings);

        if (expectedResult)
        {
            bookingRepositoryMock.Setup(repo => repo.Add(booking));
        }

        // Act
        var result = bookingManager.CreateBooking(booking);

        // Assert
        Assert.Equal(expectedResult, result);
        if (expectedResult)
        {
            bookingRepositoryMock.Verify(repo => repo.Add(booking), Times.Once);
        }
    }

}