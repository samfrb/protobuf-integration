using System.Runtime.InteropServices.WindowsRuntime;
using AElf.Kernel;
using Google.Protobuf;

namespace WrapperClass
{
    /// <summary>
    /// This file contains the different possible implementations of Transaction
    /// with the "Wrapper class" pattern, basically encapsulating the deserialized
    /// data.
    /// </summary>
    public class Transaction : ITransaction
    {
        // ITransaction implementation
        private IAccount _account { get; set; }

        /// <summary>
        /// Constructor used to build this Transaction with the deserialized
        /// protobuf object.
        /// </summary>
        /// <param name="proto"></param>
        public Transaction(ProtoTransaction proto)
        {
            _account = new Account();
        }

        public IMessage GetProtoObject()
        {
            IMessage m = new ProtoTransaction();

            m.ToByteArray();
        }
    }
}