using MvvmCross.Plugin.Messenger;

namespace MobileTestApp.Messages
{
    public class NotesUpdatedMessage : MvxMessage
    {
        public NotesUpdatedMessage(object sender) : base(sender)
        {
        }
    }
}