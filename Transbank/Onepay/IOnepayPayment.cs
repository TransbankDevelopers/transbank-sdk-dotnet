using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;


namespace Transbank.Onepay
{
    public interface IOnepayPayment
    {
        int Ticket { get; }
        int Total { get; }
        string ExternalUniqueNumber { get; }
        string Occ { get; }
        string Ott { get; }

        void Connected();
        void NewMessage(string payload);
        void Disconnected();
    }

}
