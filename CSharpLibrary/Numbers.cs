using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary
{
    public class Numbers
    {
        public int FirstCountingNumbers() => 1;
    }

    public interface ICanAddNumbers
    {
        int Add(int a, int b);
    }
}
