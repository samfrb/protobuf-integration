using AElf.Kernel;
using Google.Protobuf;

namespace WrapperClass
{
    public class Account : IAccount
    {
        private ProtoAccount _protoAccount;
        
        public Account()
        {
           
        }

        public byte[] Address
        {
            get { return _protoAccount.PAddress.ToByteArray(); }
            set { _protoAccount.PAddress = ByteString.CopyFrom(value); }
        }
    }
}