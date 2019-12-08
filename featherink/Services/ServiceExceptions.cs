﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Services
{
    public class UsernameTakenException : Exception
    {
    }

    public class UsernameOrPasswordInvalidException : Exception
    {
    }

    public class RegistrationException : Exception
    {
    }

    public class ConfigurationMissingException : Exception
    {
    }
}
