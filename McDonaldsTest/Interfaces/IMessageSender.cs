using McDonaldsTest.Models;

namespace McDonaldsTest.Interfaces
{
    public interface IMessageSender
    {
        void SendOrder(Order order);
    }
}
