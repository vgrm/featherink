using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Services
{
    public interface ICryptographicService
    {
        string GenerateSalt(int length = 32);
        string GenerateHash(string password, string saltInBase64);
    }
}
