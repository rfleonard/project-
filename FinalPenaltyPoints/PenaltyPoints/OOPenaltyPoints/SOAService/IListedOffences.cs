using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using OOPenaltyPoints.Models;
using System.Text;

namespace OOPenaltyPoints.SOAService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IListedOffences" in both code and config file together.
    [ServiceContract]
    public interface IListedOffences
    {
        [OperationContract]
       
       
        List<ListedOffence> DoWork();
    }
}
