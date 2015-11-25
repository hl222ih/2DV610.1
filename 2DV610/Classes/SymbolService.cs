using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public class SymbolService
    {
        private ISymbolRepository repo;

        public SymbolService(ISymbolRepository repo)
        {
            if (repo == null) throw new ArgumentNullException();

            this.repo = repo;
        }
    }
}
