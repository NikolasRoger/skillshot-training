using System;

namespace UsersDTO
{
    [Serializable]
    public class CreateUserRequest
    {
        public string email;

        public string name;

        public string password;
    }

    [Serializable]
    public class CreateUserError
    {
        public string message;
    }
}

