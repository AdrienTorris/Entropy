using HashidsLab.WebApp.Models;

namespace HashidsLab.WebApp.Services
{
    public class OrderService
    {
        private static Order[] orders = new Order[3]
        {
            new Order(1, new Guid("795817f5-ad1c-486d-93ed-70107222ef7d"), "Dell PC"),
            new Order(2, new Guid("e3941adb-8731-4f74-93d6-e1bc3b1da5b5"), "Thinkpad PC"),
            new Order(3, new Guid("bf4bdb9d-25ad-48a1-9258-f52790afa39c"), "MacBook pro")
        };

        public Order Get(int id) => orders.SingleOrDefault(u => u.Id == id);

        public Order Get(Guid publicKey) => orders.SingleOrDefault(u => u.PublicKey == publicKey);
    }
}
