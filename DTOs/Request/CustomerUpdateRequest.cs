﻿namespace webapi_mediatr_cqrs_example.DTOs.Request
{
    public class CustomerUpdateRequest
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
