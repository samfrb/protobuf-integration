using System;
using AElf.Kernel;
using Google.Protobuf;
using Mapster;
using Xunit;

namespace AElfSerializer.Testing
{
    public class AElfSerializerTest
    {
        private void SetupMapper()
        {
            TypeAdapterConfig<IAccount, ProtoAccount>
                .NewConfig()
                .Map(dest => dest.PAddress,
                    src => ByteString.CopyFrom(src.Address));
        }
        
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
            
            /* Deserialize and check address */
            //IAccount deserializedAcc = serializer.DeserializeAccount(serializedAccount);
            //PrintBytes(deserializedAcc.Address);
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