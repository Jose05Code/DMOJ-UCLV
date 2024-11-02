using System;
using System.Collections.Generic;

namespace DMOJ
{
    class Multiplo_de_2_3_y_5
    {
        static void Main(string[] args)
        {
            // Leer la cantidad de d�gitos
            int n = Convert.ToInt32(Console.ReadLine()); // digitos

            // Leer los d�gitos
            string[] problem_input = Console.ReadLine().Split(); // array de d�gitos

            // Ordenar los d�gitos en orden ascendente
            Array.Sort(problem_input);

            // Verificar si el d�gito m�s peque�o es "0"
            if (problem_input[0] != "0")
            {
                Console.WriteLine("-1");
                return;
            }

            // Invertir el arreglo para obtener el n�mero m�s grande posible
            Array.Reverse(problem_input);
            string result = Div3(problem_input);

            // Verificar que el resultado no est� vac�o o solo contenga ceros
            if (result.Length == 0 || (result.Length == 1 && result[0] == '0'))
            {
                Console.WriteLine(0);
            }
            else
            {
                if (result[0] == '0')
                    Console.WriteLine(0);
                else
                    Console.WriteLine(result);
            }
        }

        static string Div3(string[] digits)
        {
            ulong sum = 0;

            // Calcular la suma de los d�gitos
            foreach (var digit in digits)
            {
                sum += Convert.ToUInt32(digit);
            }

            // Verificar el residuo de la suma al dividir por 3
            byte remainder = Convert.ToByte(sum % 3);

            // Caso cuando la suma es divisible por 3
            if (remainder == 0)
            {
                return string.Join("", digits);
            }

            // Arreglos de casos para el residuo 1 y 2
            string[] Case_for_1 = { "1", "4", "7" };
            string[] Case_for_2 = { "2", "5", "8" };

            List<string> digitsList = new List<string>(digits);

            if (remainder == 1)
            {
                // Intentar eliminar un d�gito con resto 1
                foreach (var caseDigit in Case_for_1)
                {
                    int index = digitsList.IndexOf(caseDigit);
                    if (index != -1)
                    {
                        digitsList.RemoveAt(index);
                        return string.Join("", digitsList);
                    }
                }

                // Intentar eliminar dos d�gitos con resto 2
                int count = 0;
                foreach (var caseDigit in Case_for_2)
                {
                    while (digitsList.Remove(caseDigit) && ++count < 2)
                    {
                        // Contin�a hasta eliminar dos d�gitos
                    }
                    if (count == 2)
                    {
                        return string.Join("", digitsList);
                    }
                }
            }
            else if (remainder == 2)
            {
                // Intentar eliminar un d�gito con resto 2
                foreach (var caseDigit in Case_for_2)
                {
                    int index = digitsList.IndexOf(caseDigit);
                    if (index != -1)
                    {
                        digitsList.RemoveAt(index);
                        return string.Join("", digitsList);
                    }
                }

                // Intentar eliminar dos d�gitos con resto 1
                int count = 0;
                foreach (var caseDigit in Case_for_1)
                {
                    while (digitsList.Remove(caseDigit) && ++count < 2)
                    {
                        // Contin�a hasta eliminar dos d�gitos
                    }
                    if (count == 2)
                    {
                        return string.Join("", digitsList);
                    }
                }
            }

            // Si no se encontr� una combinaci�n adecuada para ajustar el resto, retornar -1
            return "-1";
        }
    }
}