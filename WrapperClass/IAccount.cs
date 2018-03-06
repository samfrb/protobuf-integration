using AElf.Kernel;

namespace WrapperClass
{
    /// <summary>
    /// Simplified version of the kernels account data structure interface
    /// </summary>
    public interface IAccount
    {
        IHash<IAccount> GetAddress();
    }
}