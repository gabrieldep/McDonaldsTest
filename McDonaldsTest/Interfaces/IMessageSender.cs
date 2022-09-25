using McDonaldsTest.Models;

namespace McDonaldsTest.Interfaces
{
    public interface IMessageSender
    {
        void SendMessage(Order order);
    }
}
