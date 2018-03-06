using System;
using System.Security.Cryptography.X509Certificates;
using Google.Protobuf;
using Xunit;

namespace AElfSerializer.Tests
{
    public class AElfSerializerTest
    {
        [Fact]
        public void DeserializeAccount()
        {
            IAElfSerializer serializer = new ProtobufSerializer();
            
            /* Create account and print adress */
            IAccount account = new Account();
            account.Address = GetRandomBytes(10);
            PrintBytes(account.Address);
            
            /* Serialize and print */
            byte[] serializedAccount = serializer.Serialize(account);
            PrintBytes(serializedAccount);
            
            /* Deserialize and check adress */
            IAccount deserializedAcc = serializer.DeserializeAccount(serializedAccount);
            PrintBytes(deserializedAcc.Address);
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