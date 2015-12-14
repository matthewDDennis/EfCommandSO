using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCommandSO.Models.ApiDoc
{
    /// <summary>
    /// This class defines the structure of a code Code Sample.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A code snippet will contain one or more items which have text which is the code
    /// and a language specified. The multiple items are necessary as some examples
    /// require more than one part. It also include the general DocParts.
    /// </para>
    /// <para>
    /// An example of this would be some JavaScript that manipulates a
    /// DOM element to add a class.  This example would require 3 parts, HTML code,
    /// JavaScript code, and possibly some CSS code.
    /// </para>
    /// <para>
    /// How this is rendered is up to the UI layer, but options include displaying
    /// each part one after the other, or using a tabbed interface.
    /// </para>
    /// </remarks>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.ApiDescriptionBase" />
    public class ApiCodeSample : ApiDescriptionBase, IOrdered
    {
        [NotMapped]
        public static string         DocPartName       => "Example";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Example;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.Snippet;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;

        /// <summary>
        /// Gets or sets a list of the code snippets for the sample.
        /// </summary>
        public List<ApiCodeSnippet> Snippets { get; set; }
    }

    /// <summary>
    /// This class defines a piece of code for a particular language.  A Code Sample may contain
    /// more than one CodeSnippet.
    /// </summary>
    public class ApiCodeSnippet : ApiDescriptionBase, IOrdered
    {
        [NotMapped]
        public static string         DocPartName       => "Snippet";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Snippet;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.None;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;

        /// <summary>
        /// Gets or sets the language of the code snippet.
        /// </summary>
        [Required]
        public string Language { get; set; }
    }
}
