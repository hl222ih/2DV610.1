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
        private List<Symbol> symbols;

        public int SymbolCount
        {
            get
            {
                return symbols.Count;
            }
        }

        public SymbolService(ISymbolRepository repo)
        {
            if (repo == null) throw new ArgumentNullException("The symbol repository cannot be null.");

            this.repo = repo;
            symbols = repo.GetAllSymbols();
        }
    }
}
