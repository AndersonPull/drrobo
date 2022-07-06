using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using DrRobo.Modules.Access.Models;
using DrRobo.Modules.Access.Services.Request;
using DrRobo.Modules.Home.ViewModels;
using DrRobo.Modules.Shared.Services.Navigation;
using DrRobo.Modules.Shared.ViewModels;
using DrRobo.Utils;
using DrRobo.Utils.Constants;
using DrRobo.Utils.Mapper;
using Xamarin.Forms;

namespace DrRobo.Modules.Access.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private INavigationService _serviceNavigation;
        private readonly IMapper _mapper = AccessMapper.CreateMapper();

        string Cpf = string.Empty;

        public ICommand SendMessageCommand => new Command(async () => await SendMessageAsync());

        public RegisterViewModel(INavigationService serviceNavigation)
        {
            _serviceNavigation = serviceNavigation;
            FirstMessage();
        }

        private void FirstMessage()
        {
            var firstMessage = new MessageModel()
            {
                Message = "Sejá bem vindo vamos iniciar seu cadastro! digite seu cpf para iniciarmos",
                DialogTypeTwo = true,
                Type = "CPF",
                MessageOrder = 1,
                Next = 2
            };

            MessageList.Add(firstMessage);
        }

        private async Task SendMessageAsync()
        {
            var currentMessage = MessageList.LastOrDefault();
            if (MessageList.Count == 1)
                Cpf = textMessage;
                
            var message = new MessageModel()
            {
                Message = textMessage,
                DialogTypeOne = true,
            };


            var messagePost = new MessageModel()
            {
                CPF = Cpf,
                Message = textMessage,
                Type = currentMessage.Type,
                MessageOrder = currentMessage.MessageOrder,
                Next = currentMessage.Next
            };

            TextMessage = string.Empty;

            if (messagePost.Type == Enums.TypeMessageEnum.PASSWORD.Value())
            {
                message.Message = "****";
                //TODO Criptografar senha
            }
                
            MessageList.Add(message);
            await GetNewMessage(messagePost);
        }

        private async Task GetNewMessage(MessageModel message)
        {            
            var response = await Constant.BaseAutAPI.PostMessage(_mapper.Map<MessageRequestDto>(message));

            var newMessage = _mapper.Map<MessageModel>(response);
            newMessage.DialogTypeTwo = true;

            MessageList.Add(newMessage);

            if(messageList.LastOrDefault().Type == Enums.TypeMessageEnum.CPF_INVALID.Value())
                IsErrorMessage = true;
            else if(messageList.LastOrDefault().Type == Enums.TypeMessageEnum.ERROR.Value())
                IsErrorMessage = true;
            else if (messageList.LastOrDefault().Type == Enums.TypeMessageEnum.CONCLUED.Value())
            {
                await Task.Delay(3000);
                await _serviceNavigation.NavigateToAsync<TabbedPageViewModel>();
            }
        }

        private ObservableCollection<MessageModel> messageList = new ObservableCollection<MessageModel>();
        public ObservableCollection<MessageModel> MessageList { get { return messageList; } set { Set("MessageList", ref messageList, value); } }

        private string textMessage = string.Empty;
        public string TextMessage { get { return textMessage; } set { Set("TextMessage", ref textMessage, value); } }

        private bool isErrorMessage = false;
        public bool IsErrorMessage { get { return isErrorMessage; } set { Set("IsErrorMessage", ref isErrorMessage, value); } }
    }
}