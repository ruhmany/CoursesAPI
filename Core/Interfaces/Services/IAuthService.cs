﻿using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Interfaces.Services
{
    public interface IAuthService
    {
        void CreateHashPassword(string password, out byte[] passwordhash, out byte[] passwordsalt);
        bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt);
        string DcryptPassword(string encryptedText);
        string CreateToken(User user); 
        RefreshToken CreateRefreshToken();

    }
}
