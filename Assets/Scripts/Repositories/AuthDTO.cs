using System;

namespace AuthDTO
{
    [Serializable]
    public class LoginRequest
    {
        public string email;
        
        public string password;
    }

    [Serializable]
    public class LoginResponse
    {
        public string token;
    }

    [Serializable]
    public class LoginError
    {
        public string message;
    }
}

