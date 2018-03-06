

namespace WrapperClass
{
    public partial class Account : IAccount
    {
        public byte[] Address { get; set; }

        public Account(IAccount a)
        {
            
        }
    }
}