using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCalculadora2D
{
    class Numero
    {
         private double _numero;
        double _valor;

        /// <summary>
        /// Retorna el valor del atributo _numero
        /// </summary>
        /// <returns></returns>
        public double GetNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Inicializa el atributo _numero en 0
        /// </summary>
        public Numero():this(0)
        {
            
        }

        /// <summary>
        /// Inicializa el atributo _numero con el valor del parametro recibido
        /// </summary>
        /// <param name="numero">Valor para inicializar el atributo _numero</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// Inicializa el atributo _numero con el valor del parametro recibido
        /// </summary>
        /// <param name="numero">String para inicializar el atributo _numero</param>
        public Numero(string numero)
        {
            this.SetNumero(numero);
        }

        /// <summary>
        /// convertirá un número binario a decimal, en caso de ser posible. Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string aux;
            double numeroFinalDecimal=0;
            
            int j = 0;
            for (int i = binario.Length-1; i >=0; i--, j++)
            {
                aux = binario.Substring(i,1);
                if (aux == "1")
                {
                    numeroFinalDecimal += Math.Pow(2,j);
                }
            }
            return "Valor Invalido";
        }

        /// <summary>
        /// convertirán un número decimal a binario, en caso de ser posible. Caso contrario retornará "Valor inválido
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string cadena = numero.ToString(), auxCociente = " ", numeroFinal = " ";
            int flag = 0, j;
            int residuo, cociente;
            char[] numeroParametro = cadena.ToCharArray();
            for (j = 0; j < numeroParametro.Length; j++)
            {
                if (numeroParametro[j] == 46)
                {
                    break;
                }
            }
            for (int i = 0; i < j; i++)
            {
                if (flag == 0)
                {
                    flag = 1;
                    auxCociente = numeroParametro[i].ToString();
                }
                else
                {
                    auxCociente = auxCociente + numeroParametro[i].ToString();
                }
            }
            flag = 0;
            cociente = int.Parse(auxCociente);
            while (cociente >= 1)
            {
                residuo = cociente % 2;
                cociente = cociente / 2;
                if (flag == 0)
                {
                    flag = 1;
                    numeroFinal = residuo.ToString();
                }
                else
                {
                    numeroFinal = residuo.ToString() + numeroFinal;
                }
            }
            return "Valor Invalido";
        }



        public static string DecimalBinario(string numero)
        {
            int exponente = numero.Length - 1;
            int num_decimal = 0;

            for (int i = 0; i < numero.Length; i++)
            {
                if (int.Parse(numero.Substring(i, 1)) == 1)
                {
                    num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                }
                exponente--;
            }
            return "Valor Invalido";
        }
          



        /// <summary>
        /// Recibe un string y lo asigna al atributo _numero de la instancia
        /// </summary>
        /// <param name="numero">String a ser asignado en _numero</param>
        private void SetNumero(string numero)
        {
            this._numero = ValidarNumero(numero);
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1 - n2;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return (n2._valor * n1._valor);
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return (n2._valor / n1._valor);
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._valor + n2._valor;

        }


        /// <summary>
        /// Recibe un string y lo parsea a double
        /// </summary>
        /// <param name="numeroString">String a parsear</param>
        /// <returns> Devuelve el valor del string recibido en forma de double, si no lo puede parsear devuelve 0</returns>
        private double ValidarNumero(string numeroString)
        {
            double value = 0;

            double.TryParse(numeroString, out value);

            return value;
        }
       
    }
}
