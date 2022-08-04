using System.Collections.Generic;

namespace Refugio.WebApi.Models.Output
{
    public class OutEvolucoesPaginacao
    {
        public IEnumerable<OutEvolucao> Evolucoes { get; set; }
        public OutPaginacao Paginacao { get; set; }
    }
}
