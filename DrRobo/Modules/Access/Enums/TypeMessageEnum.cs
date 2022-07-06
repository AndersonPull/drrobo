using System.ComponentModel;
using System.Runtime.Serialization;

namespace DrRobo.Modules.Access.Enums
{
    public enum TypeMessageEnum
    {
        [EnumMember(Value = "CPF"), Description("Digite seu CPF")]
        CPF,

        [EnumMember(Value = "NAME"), Description("Digite seu Nome")]
        NAME,

        [EnumMember(Value = "PASSWORD"), Description("Escolha sua Senha")]
        PASSWORD,

        [EnumMember(Value = "EMAIL"), Description("Digite seu Email")]
        EMAIL,

        [EnumMember(Value = "ERROR"), Description("Erro")]
        ERROR,

        [EnumMember(Value = "CPF_INVALID"), Description("CPF invalido!")]
        CPF_INVALID,

        [EnumMember(Value = "CONCLUED"), Description("Processo concluido!")]
        CONCLUED,
    }
}
