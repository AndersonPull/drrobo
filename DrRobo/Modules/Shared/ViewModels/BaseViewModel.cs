using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DrRobo.Modules.Shared.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        private bool isBusy;
        public bool IsBusy { get { return isBusy; } set { Set("IsBusy", ref isBusy, value); } }
    }
}
