﻿namespace WebApp.Services
{
    public interface IEmailGoogle
    {
        string SendMailChangePassWord(string fullName, string email, string newPass);
    }
}
