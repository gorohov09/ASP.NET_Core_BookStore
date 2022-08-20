using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order Create();

        Order GetById(int id);

        void Update(Order order);
    }
}
