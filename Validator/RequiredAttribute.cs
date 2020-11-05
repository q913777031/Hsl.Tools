using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hsl.Tools
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        //public RequiredAttribute()
        //{
        //    ErrorMessage = "必填";
        //}

        public string DisplayName { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var attributes = validationContext.ObjectType.GetProperty(validationContext.MemberName)
                ?.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (attributes != null && attributes.Length > 0)
                DisplayName = (attributes[0] as DisplayNameAttribute)?.DisplayName;
            else
                DisplayName = validationContext.DisplayName;

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
                return base.IsValid(value, validationContext);


            var validationResult = new ValidationResult(DisplayName + "不能为空值！");
            return validationResult;
        }

        //public override string FormatErrorMessage(string name)
        //{
        //    return string.Format(this.ErrorMessageString, DisplayName);
        //}
    }
}