﻿using OnionArch.Application.Bases;

namespace OnionArch.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var !") { }
    }
}
