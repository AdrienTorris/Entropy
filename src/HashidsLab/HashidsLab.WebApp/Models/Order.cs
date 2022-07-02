namespace HashidsLab.WebApp.Models
{
    public class Order
    {
        public int Id { get; init; }
        public Guid PublicKey { get; init; }
        public string Article { get; init; }

        public Order(int id, Guid publicKey, string article)
        {
            Id = id;
            PublicKey = publicKey;
            Article = article;
        }
    }
}
