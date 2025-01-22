﻿namespace Projects.Infrastructure.Notifications
{
    public interface IEmailService
    {
        Task SendAsync(string email, string subject, string message);
    }
}
