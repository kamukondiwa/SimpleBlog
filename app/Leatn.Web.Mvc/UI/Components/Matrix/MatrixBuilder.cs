namespace Leatn.Web.Mvc.UI.Components.Matrix
{
    #region Using Directives

    using Leatn.Web.Mvc.UI.Components.Matrix.Mappers.Contracts;

    using Renderers.Contracts;

    #endregion

    /// <summary>
    /// The matrix builder.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the element.
    /// </typeparam>
    public class MatrixBuilder<T>
        where T : class
    {
        /// <summary>
        /// The matrix model mapper.
        /// </summary>
        private readonly IMatrixModelMapper<T> matrixModelMapper;

        /// <summary>
        /// The grid markup renderer.
        /// </summary>
        private readonly IMatrixRenderer<T> matrixRenderer;

        /// <summary>
        /// The matrix source.
        /// </summary>
        private readonly MatrixSource<T> matrixSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixBuilder{T}"/> class. 
        /// </summary>
        /// <param name="matrixRenderer">
        /// The grid markup renderer.
        /// </param>
        /// <param name="matrixModelMapper">
        /// The matrix Model Mapper.
        /// </param>
        /// <param name="matrixSource">
        /// The matrix Source.
        /// </param>
        public MatrixBuilder(IMatrixRenderer<T> matrixRenderer, IMatrixModelMapper<T> matrixModelMapper, MatrixSource<T> matrixSource)
        {
            this.matrixRenderer = matrixRenderer;
            this.matrixSource = matrixSource;
            this.matrixModelMapper = matrixModelMapper;
        }

        /// <summary>
        /// The build.
        /// </summary>
        public void Build()
        {
            this.matrixRenderer.RenderStartTag();
            this.BuildMatrix();
            this.matrixRenderer.RenderEndTag();
        }

        /// <summary>
        /// The build matrix.
        /// </summary>
        private void BuildMatrix()
        {
            var matrixModel = this.matrixModelMapper.MapFrom(this.matrixSource);
            this.matrixRenderer.RenderMatrix(matrixModel);
        }
    }
}