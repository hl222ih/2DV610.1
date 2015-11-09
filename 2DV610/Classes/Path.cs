using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610.Classes
{
    public abstract class Path
    {
        private PathType pathType;
        
        public Path(PathType pathType, String path)
        {
            this.pathType = PathType.Unspecified;
        }

        public PathType GetPathType()
        {
            return pathType;
        }
    }
}
