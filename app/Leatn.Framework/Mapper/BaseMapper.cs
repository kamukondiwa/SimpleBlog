namespace Leatn.Framework.Mapper
{
    #region Using Directives

    using System;

    using AutoMapper;

    using SharpArch.Core.DomainModel;

    #endregion

    public abstract class BaseMapper<TInput, TOutput> : IMapper<TInput, TOutput>
    {
        protected BaseMapper()
        {
            this.CreateMap();
        }

        public virtual TOutput MapFrom(TInput input)
        {
            return Mapper.Map<TInput, TOutput>(input);
        }

        protected virtual void CreateMap()
        {
            Mapper.CreateMap<TInput, TOutput>();
        }
    }

    public abstract class BaseMapper<TInput1, TInput2, TOutput> : IMapper<TInput1, TInput2, TOutput>
    {
        protected BaseMapper()
        {
            this.CreateMap();
        }

        public virtual TOutput MapFrom(
            TInput1 input1,
            TInput2 input2)
        {
            var result = Mapper.Map<TInput1, TOutput>(input1);
            Mapper.Map(input2, result);

            return result;
        }

        protected virtual void CreateMap()
        {
            Mapper.CreateMap<TInput1, TOutput>();
            Mapper.CreateMap<TInput2, TOutput>();
        }
    }

    public abstract class BaseMapper<TInput1, TInput2, TInput3, TOutput> : IMapper<TInput1, TInput2, TInput3, TOutput>
    {
        protected BaseMapper()
        {
            this.CreateMap();
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="input1">The input 1.</param>
        /// <param name="input2">The input 2.</param>
        /// <param name="input3">The input 3.</param>
        /// <returns>The mapped object.</returns>
        public virtual TOutput MapFrom(TInput1 input1, TInput2 input2, TInput3 input3)
        {
            var result = Mapper.Map<TInput1, TOutput>(input1);
            result = Mapper.Map(input2, result);
            Mapper.Map(input3, result);
            return result;
        }

        /// <summary>
        /// The create map.
        /// </summary>
        protected virtual void CreateMap()
        {
            Mapper.CreateMap<TInput1, TOutput>();
            Mapper.CreateMap<TInput2, TOutput>();
            Mapper.CreateMap<TInput3, TOutput>();
        }

    }

    public abstract class BaseEntityMapper<TEntitySource, TEntityDestination> : BaseMapper<TEntitySource, TEntityDestination>,
        IEntityMapper<TEntitySource, TEntityDestination>
        where TEntityDestination : Entity, new()
    {
        public virtual TEntityDestination MapFrom(TEntitySource blogPostSaveDetails, TEntityDestination existingEntity)
        {
            return Mapper.Map(blogPostSaveDetails, existingEntity);
        }
    }
}