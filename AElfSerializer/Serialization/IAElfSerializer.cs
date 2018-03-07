using System;

namespace AElfSerializer
{
    public interface IAElfSerializer
    {
        byte[] Serialize(object obj);
        
        T Deserialize<T>(byte[] bytes);
        object Deserialize(byte[] bytes, Type type);
    }
}