using Newtonsoft.Json;

namespace DrRobo.Modules.Access.Services.Request
{
    public class MessageRequestDto
    {
        [JsonProperty("messageOrder")]
        public int MessageOrder { get; set; }

        [JsonProperty("next")]
        public int Next { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
