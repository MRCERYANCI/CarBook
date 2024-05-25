using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudiance = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "u3Y8kG7lM1qV4zN9tX6rB0pW2jL5dF3mQ1yK8nS7vR4cZ9xP6wT0hJ2bU5gH3aL1oV8eM7fQ4pN9tX6yK3zB0nR5jL2qV8rG1mW9dF4pS6xP7cZ0bT3uH2wJ5aL9oN6fY8gM1vQ7tK4pB0";
        public const int Expire = 3;
    }
}
