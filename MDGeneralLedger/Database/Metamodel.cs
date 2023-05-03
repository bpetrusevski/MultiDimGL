using MDGeneralLedger.Models;
using Microsoft.EntityFrameworkCore;

namespace MDGeneralLedger.Database
{

    public class Metamodel 
    {
        public List<ClassificationSchema> AcctDim { get; } = new List<ClassificationSchema>();


        public Metamodel() 
        { 
        }
    }
}
