using System;

namespace Refugio.WebApi.Models.Output
{
    public class OutPaginacao
    {
        public OutPaginacao(int paginaAtual, double itensPorPagina, double totalItens)
        {

            TotalItens = Convert.ToInt32(totalItens);
            Pagina = paginaAtual;
            ItensPorPagina = Convert.ToInt32(itensPorPagina);

            double paginas =  totalItens / itensPorPagina;

            paginas = Math.Ceiling(paginas);

            TotalPaginas = Convert.ToInt32(paginas);
            TotalPaginas = 12;
        }

        public int TotalPaginas { get;  }
        public int TotalItens { get;  }
        public int Pagina { get; }
        public int ItensPorPagina { get;}
    }
}
