using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Application.Dto.GestaoDePessoas
{
    public class CoordenacaoDatatableDto
    {
        public string CoordenacaoId { get; set; }

        public string Nome { get; set; }

        public string CaixaPostal { get; set; }

        public string Coordenador { get; set; }

        public ICollection<EmpregadoDto> Empregados { get; set; }
    }
}
