using FluentValidation;
using ISFPStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Base
{
    public interface IBaseServices<TEntity> where TEntity : IBaseEntity
    {
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        void Delete(int id);

        IEnumerable<TOutputModel> Get<TOutputModel>(IList<string>? includes = null)
            where TOutputModel : class;

        TOutputModel GetById<TOutputModel>(int id, IList<string>? includes = null)
            where TOutputModel : class;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
                where TInputModel : class
                where TOutputModel : class;
    }
}
