using DrRobo.Modules.Access.Services;
using Refit;

namespace DrRobo.Utils.Constants
{
    public partial struct Constant
    {
        public static readonly IAccessService BaseAutAPI = RestService.For<IAccessService>("https://dr-robo-auth.herokuapp.com");
        public const string LabelBreakLine = "\n";
    }
}
