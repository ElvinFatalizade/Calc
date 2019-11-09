using ServiceReference1;
using SOAP2JSON.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP2JSON
{
    public class Count:Incount
    {

        private CalculatorSoap calculatorSoap;

        public Count(CalculatorSoap calculator)
        {
            calculatorSoap = calculator;
        }

        public async Task<int> AddAsync(int Num1, int Num2)
        {
            return await calculatorSoap.AddAsync(Num1, Num2);
        }

        public async Task<int> SubtractAsync(int Num1, int Num2)
        {
            return await calculatorSoap.SubtractAsync(Num1, Num2);
        }

        public async Task<int> MultiplyAsync(int Num1, int Num2)
        {
            return await calculatorSoap.MultiplyAsync(Num1, Num2);
        }

        public async Task<int> DivideAsync(int Num1, int Num2)
        {
            return await calculatorSoap.DivideAsync(Num1, Num2);
        }
    }
}
