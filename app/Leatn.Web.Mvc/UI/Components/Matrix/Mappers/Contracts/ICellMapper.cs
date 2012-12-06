namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts
{
    using Framework.Mapper;

    using Models;

    /// <summary>
    /// The cell mapper contract.
    /// </summary>
    /// <typeparam name="T">
    /// The model type.
    /// </typeparam>
    public interface ICellMapper<T> : IMapper<T, Cell<T>>
    {
    }
}