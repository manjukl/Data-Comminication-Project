using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuition
{
   abstract class  Command
   {
      public abstract void Execute();
      public abstract void Unexecute();
   }
}
