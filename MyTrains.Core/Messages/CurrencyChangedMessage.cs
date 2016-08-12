using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Model;

namespace MyTrains.Core.Messages
{
    public class CurrencyChangedMessage: MvxMessage
    {
        public CurrencyChangedMessage(object sender) : base(sender)
        {
        }

        public Currency NewCurrency { get; set; }
    }
}