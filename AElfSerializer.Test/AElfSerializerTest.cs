using System;
using AElf.Kernel;
using Google.Protobuf;
using Xunit;

namespace AElfSerializer.Test
{
    public class AElfSerializerTest
    {
        /// <summary>
        /// Usage for serializing and deserializing an account
        /// </summary>
        [Fact]
        public void DeserializeAccount()
        {
            IAElfSerializer serializer = new ProtobufSerializer();
            
            /* Create account and print adress */
            ProtoAccount account = new ProtoAccount();
            account.PAddress = ByteString.CopyFrom(GetRandomBytes(10));
            PrintBytes(account.PAddress.ToByteArray());
            
            /* Serialize and print */
            byte[] serializedAccount = serializer.Serialize(account);
            PrintBytes(serializedAccount);
            
            /* Deserialize and check address */
            ProtoAccount deserializedAcc = serializer.Deserialize<ProtoAccount>(serializedAccount);
            PrintBytes(deserializedAcc.PAddress.ToByteArray());
        }

        private void PrintBytes(byte[] bytes)
        {
            Console.WriteLine(BitConverter.ToString(bytes));
        }

        private byte[] GetRandomBytes(int count)
        {
            byte[] bArray = new byte[count];
            new Random().NextBytes(bArray);

            return bArray;
        }
    }
}