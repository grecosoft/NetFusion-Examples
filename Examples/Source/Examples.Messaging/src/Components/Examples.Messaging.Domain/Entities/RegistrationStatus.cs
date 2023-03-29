using System;

namespace Examples.Messaging.Domain.Entities;

public class RegistrationStatus
{
    public string ReferenceNumber { get; }
    public bool IsSuccess { get; }
    public DateTime DateProcessed { get; }

    public RegistrationStatus(string referenceNumber, bool isSuccess, DateTime dateProcessed)
    {
        ReferenceNumber = referenceNumber;
        IsSuccess = isSuccess;
        DateProcessed = dateProcessed;
    }
}