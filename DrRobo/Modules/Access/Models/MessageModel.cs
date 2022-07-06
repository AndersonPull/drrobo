namespace DrRobo.Modules.Access.Models
{
    public class MessageModel
    {
        public int MessageOrder { get; set; }

        public int Next { get; set; }

        public string Message { get; set; }

        public string CPF { get; set; }

        public string Type { get; set; }

        public bool DialogTypeOne { get; set; }

        public bool DialogTypeTwo { get; set; }
    }
}
