using AutoMapper;
using FluentValidation;
using IFSPStore.Domain.Base;
using ISFPStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPSotore.Service.Services
{
    public class BaseService<TEntity> : IBaseServices<TEntity> where TEntity : IBaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository; //<> = tipo passado como parametro
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }


        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(entity);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IEnumerable<TOutputModel> Get<TOutputModel>(IList<string>? includes = null) where TOutputModel : class
        {
            var entities = _baseRepository.Select(includes);
            var outpuModel = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return outpuModel;
        }

        public TOutputModel GetById<TOutputModel>(int id, IList<string>? includes = null) where TOutputModel : class
        {
            var entity = _baseRepository.Select(id, includes);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Objeto inválido");

            validator.ValidateAndThrow(obj);


        }
    }
}
