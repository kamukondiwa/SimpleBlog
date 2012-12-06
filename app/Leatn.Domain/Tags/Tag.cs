namespace Leatn.Domain.Tags
{
    #region Using Directives

    using System.Collections.Generic;

    using Contracts;

    using Gentax.Bricks;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The tag node.
    /// </summary>
    public class Tag : Entity, IReferenceData, IElement<Tag>
    {
        public virtual IList<Tag> Children { get; set; }

        public virtual bool IsRoot
        {
            get
            {
                return this.Parent == null;
            }
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets Parent.
        /// </summary>
        public virtual Tag Parent { get; set; }

        public virtual void Accept(IElementVisitor<Tag> visitor)
        {
            visitor.Visit(this);
        }
    }
}