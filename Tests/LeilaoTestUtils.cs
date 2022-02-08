using Alura.LeilaoOnline.Core;

namespace Tests
{
    public class LeilaoTestUtils
    {
        public static void realizaLancesIntercaladosComDoisInteressados(Leilao leilao, double[] valores)
        {
            Interessada fulano = new Interessada("Fulano", leilao);
            Interessada ciclano = new Interessada("Ciclano", leilao);

            for (int i = 0; i < valores.Length; i++)
            {
                realizaLance(leilao, fulano, ciclano, valores[i], i);
            }
        }

        private static void realizaLance(Leilao leilao, Interessada cliente1, Interessada cliente2, double valor,
            int indice)
        {
            if (indice % 2 == 0)
            {
                leilao.RecebeLance(cliente1, valor);
                return;
            }

            leilao.RecebeLance(cliente2, valor);
        }
    }
}