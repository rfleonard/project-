using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OOPenaltyPoints.BLL;
using OOPenaltyPoints.DAL;
using OOPenaltyPoints.Models;

namespace OOPenaltyPoints.SOAService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ListedOffences" in code, svc and config file together.
    public class ListedOffences : IListedOffences
    {
        public List<ListedOffence> DoWork()
        {
            List<ListedOffence> llo = new List<ListedOffence>();
            OOPenaltyPoints.BLL.ListedOffenceBLL lobll = new ListedOffenceBLL();
            llo = lobll.GetOffences();
            //ListedOffenceDAL lodal = new ListedOffenceDAL();
            //llo = lodal.ListOfListedOffences().Cast<List<OOPenaltyPoints.SOAService.ListedOffences>>();
            return llo;
        }
    }
}
