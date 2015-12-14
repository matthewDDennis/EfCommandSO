using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCommandSO.Models.ApiDoc
{
    /// <summary>
    /// A marker interface to indicate the description should be ordered by the Order value
    /// rather than alphabetically by name.
    /// </summary>
    public interface IOrdered
    {
    }

    public interface IPostedAndModified
    {
        /// <summary>
        /// Gets or sets the Modified DateTime for the record. Use for optimistic concurrency.
        /// </summary>
        DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the Posted DateTime for the described api item.
        /// </summary>
        DateTime Posted { get; set; }
    }

    /// <summary>
    /// This class defines the common properties for parts of an API document or page.
    /// </summary>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.IPostedAndModified" />
    public class ApiDescriptionBase : IPostedAndModified
    {
        /// <summary>
        /// Gets or sets the ID for the described api item.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary> Gets or sets the parent group identifier. </summary>
        public int? ParentId { get; set; }

        /// <summary> Gets or sets the parent group. </summary>
        [ForeignKey("ParentId")]
        public ApiDescriptionBase Parent { get; set; }

        /// <summary> Gets or sets the child groups of the Object or Group. </summary>
        [InverseProperty("Parent")]
        public List<ApiDescriptionBase> Children { get; set; }

        /// <summary>
        /// Gets or sets the Modified DateTime for the record. Use for optimistic concurrency.
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the Posted DateTime for the described api item.
        /// </summary>
        public DateTime Posted { get; set; }

        /// <summary>
        /// Gets or sets the Title of the DocPart.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Type of the described api item.
        /// </summary>
        /// <remarks>
        /// This should be a hierarchical name starting from the root Description.  It will be used to 
        /// create links to the Type.
        /// </remarks>
        /// <example>Number</example>
        /// <example>window.location</example>
        public string Type {get; set;}

        /// <summary>
        /// Gets or sets the Abstract of the described api item.
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        /// <summary>
        /// Gets or sets the Description of the described api item.
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>Gets or sets the order that the item is displayed in its containing 
        /// list (optional).</summary>
        /// <remarks>
        /// Will only be used by classes that inherit from the IOrdered marker interface.
        /// </remarks>
        public int? Order { get; set; }

        [NotMapped]
        public virtual string Fragment { get; } 

        [NotMapped]
        public virtual DocPartTypes DocType { get; }

        [NotMapped]
        public virtual DocPartTypes AllowedChildren { get; }
    }

    [Flags]
    public enum DocPartTypes
    {
        None      = 0x00,
        Book      = 0x01,
        Group     = 0x04,
        Method    = 0x08,
        Property  = 0x10,
        Parameter = 0x11,
        Example   = 0x12,
        Snippet   = 0x14,
        Exception = 0x18
    }
}
