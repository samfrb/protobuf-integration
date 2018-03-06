using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AElf.Kernel;
using Google.Protobuf;
using Mapster;

namespace AElfSerializer
{
    public class ProtobufSerializer : IAElfSerializer
    {
        private readonly Dictionary<Type, MessageParser> _registeredTypes 
            = new Dictionary<Type, MessageParser>();
            
        public ProtobufSerializer()
        {
            // Todo : maybe move this somewhere appropriate
            /*TypeAdapterConfig<IAccount, ProtoAccount>
                .NewConfig()
                .Map(dest => dest.PAddress,
                     src => ByteString.CopyFrom(src.Address));*/
        }
        
        public void RegisterTypes<T>(Type protobufType)
        {
            
        }

        // returns the proto data structures
        public T Deserialize<T>(byte[] bytes)
        {
            // Get the parser
            IMessage msg = Activator.CreateInstance(typeof(T)) as IMessage;

            if (msg == null)
                return (T)null;

            msg.Descriptor.Parser.ParseFrom(bytes);
            
            return (T);
        }

        private byte[] SerializeAccount(IAccount account)
        {
            ProtoAccount protoAccount = account.Adapt<ProtoAccount>();
            return protoAccount.ToByteArray();
        }
        
        public byte[] SerializeTransaction(ITransaction t)
        {
            /* Build the protobuf data structure */
            ProtoTransaction pt = new ProtoTransaction();
            
            /* From account */
            pt.From = BuildProtoAccount(t.From);
            
            return pt.ToByteArray();
        }

        private ProtoAccount BuildProtoAccount(IAccount a)
        {
            /*ProtoAccount acc = new ProtoAccount();
            acc.PAddress = ByteString.CopyFrom(a.Address);*/
            
            return null;
        }
        
        /******** Deserialization ********/

        public ITransaction DeserializeTransaction(byte[] transaction)
        {
            // NOTE : the parser is in the generated C# classes
            ProtoTransaction pt = ProtoTransaction.Parser.ParseFrom(transaction);

            // Map to Transaction.cs

            return null;
        }

        public IAccount DeserializeAccount(byte[] data)
        {
            ProtoAccount a = ProtoAccount.Parser.ParseFrom(data);

            return null;
        }

    }
}