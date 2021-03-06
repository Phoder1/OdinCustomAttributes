using UnityEngine;

namespace CustomAttributes
{
    public class SuffixAttribute : PropertyAttribute
    {
        public readonly string suffix;
        public readonly float padding;
        public readonly string toolTip;

        public SuffixAttribute(string suffix, float padding = 3, string toolTip = "")
        {
            this.suffix = suffix;
            this.padding = padding;
            this.toolTip = toolTip;
        }
    }
}
