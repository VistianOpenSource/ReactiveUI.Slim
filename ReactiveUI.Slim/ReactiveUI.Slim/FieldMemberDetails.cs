using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Represents a field type 
    /// </summary>
    public class FieldMemberDetails : MemberDetails
    {
        private readonly FieldInfo _fieldInfo;

        public FieldMemberDetails(Expression expression) : base(expression)
        {
            var memberExpression = expression as MemberExpression;

            _fieldInfo = (FieldInfo)memberExpression.Member;
        }

        /// <summary>
        /// Get the current value of the field.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override object GetValue(object parent)
        {
            return _fieldInfo.GetValue(parent);
        }
    }
}
