namespace Leatn.Framework.Mapper
{
    using SharpArch.Core.DomainModel;

    public interface IMapper<TInput, TOutput>
    {
        TOutput MapFrom(TInput input);
    }

    public interface IMapper<TInput1, TInput2, TOutput>
    {
        TOutput MapFrom(TInput1 input1, TInput2 input2);
    }

    public interface IMapper<TInput1, TInput2, TInput3, TOutput>
    {
        TOutput MapFrom(TInput1 input1, TInput2 input2, TInput3 input3);
    }

    public interface IEntityMapper<TEntitySource, TEntityDestination>
        where TEntityDestination : Entity, new()
    {
        TEntityDestination MapFrom(TEntitySource blogPostSaveDetails, TEntityDestination existingEntity);
    }
}