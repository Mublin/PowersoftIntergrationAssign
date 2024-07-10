using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.exp1;

internal class Math
{
    public static class MathTest
    {
       
        
        public static double MakeCalc(double firstNumber, string sign, double secondNumber) 
        {
            switch(sign)
            {
                case "+":
                    return  firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                default:
                    return 0d;
            }    
            
        }


    }
}
