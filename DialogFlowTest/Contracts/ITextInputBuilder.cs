using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlowTest.Contracts
{
    public interface ITextInputBuilder<T> : IQueryInputBuilder<T>
    {
        ITextInputBuilder<T> WithText(string text);
        ITextInputBuilder<T> WithLanguageCode(string languageCode);
    }
}
