using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class PropertyMemberDetails : MemberDetails
    {
        private readonly PropertyInfo _propertyInfo;

        public PropertyMemberDetails(Expression expression) : base(expression)
        {
            var memberExpression = expression as MemberExpression;

            _propertyInfo = (PropertyInfo)memberExpression.Member;
        }

        public override object GetValue(object parent)
        {
            return _propertyInfo.GetValue(parent);
        }
    }
}
