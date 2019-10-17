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
        void Connected();
        void NewMessage(string payload);
        void Disconnected();
    }

}
