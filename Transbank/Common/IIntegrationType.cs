using System;

namespace Transbank.Common
{
    public interface IIntegrationType
    {
        string Key { get; }
        string ApiBase { get; }
    }
}
