using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class SymbolService
    {
        ISymbolRepository repo;

        public SymbolService(ISymbolRepository repo)
        {
            this.repo = repo;
        }
    }
}
