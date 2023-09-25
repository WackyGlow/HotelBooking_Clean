namespace HotelBooking.IntegrationTests.CoreTests;
using System;
using HotelBooking.Core;
using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class EntitiesTests
{   
    //booking Tests
    [Fact]
    public void Booking_StartDateSetAndGet()
    {
        // Arrange
        var booking = new Booking();
        DateTime startDate = new DateTime(2023, 9, 1);

        // Act
        booking.StartDate = startDate;
        DateTime retrievedStartDate = booking.StartDate;

        // Assert
        Assert.Equal(startDate, retrievedStartDate);
    }

    [Fact]
    public void Booking_EndDateSetAndGet()
    {
        // Arrange
        var booking = new Booking();
        DateTime endDate = new DateTime(2023, 9, 5);

        // Act
        booking.EndDate = endDate;
        DateTime retrievedEndDate = booking.EndDate;

        // Assert
        Assert.Equal(endDate, retrievedEndDate);
    }

    [Fact]
    public void Booking_IsActiveSetAndGet()
    {
        // Arrange
        var booking = new Booking();
        bool isActive = true;

        // Act
        booking.IsActive = isActive;
        bool retrievedIsActive = booking.IsActive;

        // Assert
        Assert.Equal(isActive, retrievedIsActive);
    }

    [Fact]
    public void Booking_CustomerIdSetAndGet()
    {
        // Arrange
        var booking = new Booking();
        int customerId = 42;

        // Act
        booking.CustomerId = customerId;
        int retrievedCustomerId = booking.CustomerId;

        // Assert
        Assert.Equal(customerId, retrievedCustomerId);
    }

    [Fact]
    public void Booking_RoomIdSetAndGet()
    {
        // Arrange
        var booking = new Booking();
        int roomId = 101;

        // Act
        booking.RoomId = roomId;
        int retrievedRoomId = booking.RoomId;

        // Assert
        Assert.Equal(roomId, retrievedRoomId);
    }

    [Fact]
    public void Booking_CustomerPropertyNotNull()
    {
        // Arrange
        var booking = new Booking();

        // Act

        // Assert
        Assert.NotNull(booking.Customer);
    }

    [Fact]
    public void Booking_RoomPropertyNotNull()
    {
        // Arrange
        var booking = new Booking();

        // Act

        // Assert
        Assert.NotNull(booking.Room);
    }
    
    
    //Costumer Tests
    [Fact]
    public void Customer_IdSetAndGet()
    {
        // Arrange
        var customer = new Customer();
        int id = 123;

        // Act
        customer.Id = id;
        int retrievedId = customer.Id;

        // Assert
        Assert.Equal(id, retrievedId);
    }

    [Fact]
    public void Customer_NameSetAndGet()
    {
        // Arrange
        var customer = new Customer();
        string name = "John Doe";

        // Act
        customer.Name = name;
        string retrievedName = customer.Name;

        // Assert
        Assert.Equal(name, retrievedName);
    }

    [Fact]
    public void Customer_EmailSetAndGet()
    {
        // Arrange
        var customer = new Customer();
        string email = "john@example.com";

        // Act
        customer.Email = email;
        string retrievedEmail = customer.Email;

        // Assert
        Assert.Equal(email, retrievedEmail);
    }
    //Room Tests
    [Fact]
    public void Room_IdSetAndGet()
    {
        // Arrange
        var room = new Room();
        int id = 456;

        // Act
        room.Id = id;
        int retrievedId = room.Id;

        // Assert
        Assert.Equal(id, retrievedId);
    }

    [Fact]
    public void Room_DescriptionSetAndGet()
    {
        // Arrange
        var room = new Room();
        string description = "Suite with a view";

        // Act
        room.Description = description;
        string retrievedDescription = room.Description;

        // Assert
        Assert.Equal(description, retrievedDescription);
    }
    
}