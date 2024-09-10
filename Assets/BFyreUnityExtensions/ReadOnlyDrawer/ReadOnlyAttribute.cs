using UnityEngine;

namespace BFyre.ReadOnlyDrawer
{
    /// <summary>
    /// Serialized fields decorated with this attribute will be set as readonly in Unity inspector.
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute { }
}