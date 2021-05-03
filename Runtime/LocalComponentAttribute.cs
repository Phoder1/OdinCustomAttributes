using UnityEngine;
namespace CustomAttributes
{
    public class LocalComponentAttribute : PropertyAttribute
    {
        public readonly bool getComponentFromChildrens;
        public readonly bool hideProperty;
        public readonly string parentObject;
        public readonly bool lockProperty;
        /// <summary>
        /// An "Auto-Hook" components attribute, will try to use GetComponent during inspector update, and can help reduce runtime hooking or manual grabbing.
        /// </summary>
        /// <param name="hideProperty">
        /// If true the property will be hidden if assigned.
        /// </param>
        /// <param name="getComponentFromChildrens">
        /// If true, will try to find the component in child objects.
        /// </param>
        /// <param name="parentObject">
        /// A string with a gameobject name can be assigned. will try to look for components in that gameobject.
        /// </param>
        /// <param name="lockProperty">
        /// If true the property will be unassignable manually. 
        /// </param>
        public LocalComponentAttribute(bool hideProperty = false, bool getComponentFromChildrens = false, string parentObject = "", bool lockProperty = true)
        {
            this.getComponentFromChildrens = getComponentFromChildrens;
            this.hideProperty = hideProperty;
            this.parentObject = parentObject;
            this.lockProperty = lockProperty;
        }
    }
}