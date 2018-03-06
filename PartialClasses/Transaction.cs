using System.Runtime.InteropServices.WindowsRuntime;

namespace WrapperClass
{
    public partial class Transaction : ITransaction
    {
        /*private IAccount _from;
        public IAccount From
        {
            get { return _from; }
            set
            {
                _from = value; 

                if (PFrom != null) 
                {
                    PFrom = new Account(value); 
                }
            }
        }*/
        
        public IAccount From
        {
            get { return PFrom; }
            set
            {
                PFrom = value;
            }
        }
    }
}