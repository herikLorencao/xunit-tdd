using System;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionQuandoValorNegativo()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Lance(null, -100));
            Assert.Equal("Informe um valor positivo", exception.Message);
        }
    }
}