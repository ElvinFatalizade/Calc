using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP2JSON.Interface
{
    public interface Incount
    {
        Task<int> AddAsync(int Num1, int Num2);
        Task<int> SubtractAsync(int Num1, int Num2);
        Task<int> MultiplyAsync(int Num1, int Num2);
        Task<int> DivideAsync(int Num1, int Num2);
    }
}
