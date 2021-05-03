using UnityEngine;
namespace CustomAttributes
{
    public enum ErrorLogType { HighlightOnly, Warning, Error }
    public class RequiredFieldAttribute : PropertyAttribute
    {
        public readonly ErrorLogType errorLogType;

        public RequiredFieldAttribute(ErrorLogType errorLogType)
        {
            this.errorLogType = errorLogType;
        }
    }
}
