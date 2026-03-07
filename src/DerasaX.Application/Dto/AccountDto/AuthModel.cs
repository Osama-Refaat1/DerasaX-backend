using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.AccountDto
{
    public class AuthModel
    {
        public string Id { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; } = false;
        public List<string> Errors { get; set; }
        public string UserName { get; set; }
        public string? Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
