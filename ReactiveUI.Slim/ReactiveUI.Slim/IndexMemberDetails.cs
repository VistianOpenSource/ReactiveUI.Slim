using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class IndexMemberDetails : MemberDetails
    {
        public override object GetValue(object parent)
        {
            throw new NotImplementedException();
        }

        public IndexMemberDetails(Expression expression) : base(expression)
        {
        }
    }
}
