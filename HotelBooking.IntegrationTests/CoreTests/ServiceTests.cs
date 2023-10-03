using System;
using System.Collections.Generic;
using HotelBooking.Core;
using Moq;
using Xunit;

namespace HotelBooking.IntegrationTests.CoreTests;

public class ServiceTests
{
    [Fact]
    public void CreateBooking_SuccessfulBooking()
    {
        // Arrange
        var bookingRepositoryMock = new Mock<IRepository<Booking>>();
        var roomRepositoryMock = new Mock<IRepository<Room>>();
        var bookingManager = new BookingManager(bookingRepositoryMock.Object, roomRepositoryMock.Object);

        var booking = new Booking
        {
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(3),
        };

        var room = new Room { Id = 1 };
        roomRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Room> { room });

        bookingRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Booking>
        {
            new Booking
            {
                RoomId = 1,
                StartDate = DateTime.Today.AddDays(5),
                EndDate = DateTime.Today.AddDays(7),
                IsActive = true,
            }
        });

        bookingRepositoryMock.Setup(repo => repo.Add(booking));

        // Act
        var result = bookingManager.CreateBooking(booking);

        // Assert
        Assert.True(result);
        Assert.Equal(1, booking.RoomId);
        bookingRepositoryMock.Verify(repo => repo.Add(booking), Times.Once);
    }

    [Fact]
    public void CreateBooking_NoAvailableRoom()
    {
        // Arrange
        var bookingRepositoryMock = new Mock<IRepository<Booking>>();
        var roomRepositoryMock = new Mock<IRepository<Room>>();
        var bookingManager = new BookingManager(bookingRepositoryMock.Object, roomRepositoryMock.Object);

        var booking = new Booking
        {
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(3),
        };

        roomRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Room>());
        bookingRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Booking>());

        // Act
        var result = bookingManager.CreateBooking(booking);

        // Assert
        Assert.False(result);
    }
}