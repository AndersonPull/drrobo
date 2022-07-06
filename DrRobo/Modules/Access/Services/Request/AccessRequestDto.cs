using Newtonsoft.Json;

namespace DrRobo.Modules.Access.Services.Request
{
    public class AccessRequestDto
    {
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}