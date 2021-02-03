using UnityEngine;

namespace BFyre.Common.Attributes
{
    /// <summary>
    /// Serialized fields decorated with this attribute will be set as readonly - visible in Unity inspector, but not modifiable.
    /// Requires a drawer: <see cref="BFyre.Common.Editor.ReadOnlyDrawer"/>
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute { }
}