using System;
using Alura.LeilaoOnline.Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 700);
            leilao.RecebeLance(maria, 800);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            leilao.TerminaPregao();
            
            Console.WriteLine(leilao.Ganhador.Valor);
        }
    }
}