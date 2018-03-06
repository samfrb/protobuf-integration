using Google.Protobuf;

namespace AElfSerializer
{
    public interface IAElfSerializer
    {
        byte[] Serialize(object obj);
        
        /*ITransaction DeserializeTransaction(byte[] serializedData);
        IAccount DeserializeAccount(byte[] accountData);*/

        T Deserialize<T>(byte[] bytes);
    }
    
    //public abstract 
}