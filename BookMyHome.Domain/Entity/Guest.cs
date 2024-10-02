namespace BookMyHome.Domain.Entity
{
    public class Guest : DomainEntity
    {
        protected Guest () {}

        public static Guest Create()
        {
            return new Guest();
        }
    }
}
