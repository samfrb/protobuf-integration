namespace WrapperClass
{
    /// <summary>
    /// Simplified version of the kernels account data structure interface
    /// </summary>
    public interface ITransaction
    {
        IAccount From { get; set; }
    }
}