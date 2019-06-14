using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowTest.Contracts
{
    public interface IRequestBuilder<T>
    {
        IQueryInputBuilder<T> QueryInput { get; }
        T Build();
    }
}
