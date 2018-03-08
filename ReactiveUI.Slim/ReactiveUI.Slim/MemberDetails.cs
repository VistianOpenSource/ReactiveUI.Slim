using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Base class representing a member of a expression.
    /// </summary>
    public abstract class MemberDetails
    {
        protected MemberDetails(Expression expression)
        {
            Expression = expression;
        }

        /// <summary>
        /// Get the expression associated with the member.
        /// </summary>
        public Expression Expression { get; private set; }

        public abstract object GetValue(object parent);
    }
}
