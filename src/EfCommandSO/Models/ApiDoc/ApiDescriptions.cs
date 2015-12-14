using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EfCommandSO.Models.ApiDoc
{
    /// <summary>
    /// This class allows API descriptions to be partitioned into a hierarchy of Groups.
    /// A top level Group would have no Parent Group
    /// </summary>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.ApiDescriptionBase" />
    public class ApiGroupDescription : ApiDescriptionBase
    {
        [NotMapped]
        public static string         DocPartName       => "Group";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Group;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.Group  | DocPartTypes.Property
                                                        | DocPartTypes.Method | DocPartTypes.Example;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;
    }

    /// <summary>
    /// This class describes a Method Signature (Overload).
    /// </summary>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.ApiDescriptionBase" />
    public class ApiMethodSignatureDescription : ApiDescriptionBase
    {
        [NotMapped]
        public static string         DocPartName       => "Method";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Method;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.Parameter | DocPartTypes.Example;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;
    }

    /// <summary>
    /// This class describes an Exception that can be thrown by a method.
    /// </summary>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.ApiDescriptionBase" />
    public class ApiExceptionDescription : ApiDescriptionBase
    {
        [NotMapped]
        public static string         DocPartName       => "Exception";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Exception;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.Example;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;
    }

    /// <summary>
    /// This class describes a Parameter for a Method.
    /// </summary>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.ApiDescriptionBase" />
    public class ApiParameterDescription : ApiDescriptionBase, IOrdered
    {
        [NotMapped]
        public static string         DocPartName       => "Parameter";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Parameter;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.Example;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;
    }

    /// <summary>
    /// This class describes a Propery on an Object.
    /// </summary>
    /// <seealso cref="EfCommandSO.Models.ApiDoc.ApiDescriptionBase" />
    public class ApiPropertyDescription : ApiDescriptionBase
    {
        [NotMapped]
        public static string         DocPartName       => "Property";

        [NotMapped]
        public static DocPartTypes   DocPartType       => DocPartTypes.Property;

        [NotMapped]
        public static DocPartTypes   PermittedChildren => DocPartTypes.Example;

        [NotMapped]
        public override DocPartTypes AllowedChildren   => PermittedChildren;

        [NotMapped]
        public override DocPartTypes DocType           => DocPartType;

        [NotMapped]
        public override string       Fragment          => DocPartName;
    }
}
