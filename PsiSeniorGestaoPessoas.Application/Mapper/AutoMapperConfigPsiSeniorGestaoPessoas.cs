using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PsiSeniorGestaoPessoas.Application.Dto.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;

namespace PsiSeniorGestaoPessoas.Application.Mapper
{
    public class AutoMapperConfigPsiSeniorGestaoPessoas
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(x =>
            {

                #region DomainToDto

                x.CreateMap<Empregado, EmpregadoDto>();

                x.CreateMap<Coordenacao, CoordenacaoDatatableDto>();


                #endregion

                #region DtoToDomain


                #endregion

            });

            return config.CreateMapper();
        }
    }
}
