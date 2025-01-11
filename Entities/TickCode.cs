using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicksCode.Entities
{
    class TickCode
    {
        // O intuito é criar um código que use o Ticks para criar um código "único"
        // Pensei em dividir em 2 posições, fazer a divisão entre elas, e pegar o inteiro relacionado
        // Dessa forma eu teria um código numérico com metade do tamanho

        private string Tick { get; set; }

        public TickCode()
        {
            Tick = DateTime.Now.Ticks.ToString();
            DivideTickMeio();
        }

        private void DivideTickMeio()
        {
            // Vou fazer um loop pelo tick, ir cortando a cada 2 dígitos
            // Dividir os dois, e adicionar ele no novo tick
            string novoTick = "";
            string antigoTick = Tick;
            Random random = new Random();
            string randomUpperLetter, randomLowerLetter;

            int antigoLength = antigoTick.Length;
            for (int i = 0; i != antigoTick.Length;)
            {
                // Verifico se o tick é ímpar
                if (Tick.Length % 2 == 1)
                {
                    // Se for ímpar eu removo o primeiro número e trabalho com o restante
                    antigoTick.Remove(0, 1);
                }



                novoTick += DivideValores(antigoTick[0].ToString(), antigoTick[1].ToString());
                antigoTick = antigoTick.Remove(0, 1);
                // Deixo 0 porque o índice 1 vira 0 depois que o de cima é apagado
                antigoTick = antigoTick.Remove(0, 1);

                if (antigoTick.Length == 2)
                {

                    randomUpperLetter = ((char)random.Next(65, 90)).ToString();
                    randomLowerLetter = ((char)random.Next(97, 122)).ToString();

                    novoTick = novoTick.Remove(0, 4);
                    novoTick = novoTick.Insert(0, (randomUpperLetter + randomLowerLetter));
                    randomLowerLetter = ((char)random.Next(97, 122)).ToString();
                    randomUpperLetter = ((char)random.Next(65, 90)).ToString();
                    novoTick = novoTick.Insert(3, randomUpperLetter);
                    novoTick = novoTick.Insert(5, randomLowerLetter);
                }
            }

            Tick = novoTick.ToString();

        }

        private string DivideValores(string stringZero, string stringUm)
        {
            int valorZero;
            int valorUm;
            Int32.TryParse(stringZero, out valorZero);
            Int32.TryParse(stringUm, out valorUm);

            if(valorZero > valorUm && valorZero != 0 && valorUm != 0)
            {
                return (valorZero / valorUm).ToString();
            }
            if(valorZero == 0 || valorUm == 0)
            {
                return (valorUm + valorZero).ToString();
            }

            return (valorUm / valorZero).ToString();
        }


        public override string ToString()
        {
            
            return Convert.ToString(Tick);
        }

    }
}
