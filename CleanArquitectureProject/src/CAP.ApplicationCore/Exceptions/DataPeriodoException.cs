using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Exceptions
{
    [Serializable]
    public class DataPeriodoException : Exception
    {
        public DataPeriodoException()
        {
        }

        public DataPeriodoException(string message) : base(message)
        {
        }

        public DataPeriodoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
