using System;
using Newtonsoft.Json;

namespace DrRobo.Modules.Access.Services.Response
{
    public class MessageResponseDto
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

        [JsonProperty("dialogTypeOne")]
        public bool DialogTypeOne { get; set; }

        [JsonProperty("dialogTypeTwo")]
        public bool DialogTypeTwo { get; set; }
    }
}
