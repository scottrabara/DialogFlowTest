using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowTest.Contracts
{
    public interface IQueryInputBuilder<T> : IRequestBuilder<T>
    {
        ITextInputBuilder<T> TextInput { get; }
    }
}
