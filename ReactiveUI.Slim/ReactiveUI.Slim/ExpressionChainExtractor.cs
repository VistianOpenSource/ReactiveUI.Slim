using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Breakdown expressions into a sequence of <see cref="MemberDetails"/> instances.
    /// </summary>
    public class ExpressionChainExtractor
    {
        private readonly ConcurrentDictionary<Expression, List<MemberDetails>> _memberDetailsCache = new ConcurrentDictionary<Expression, List<MemberDetails>>();
        public static ExpressionChainExtractor Default => new ExpressionChainExtractor();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="This"></param>
        /// <returns></returns>
        public IEnumerable<MemberDetails> Decode(Expression This)
        {
            List<MemberDetails> chain;

            if (!_memberDetailsCache.TryGetValue(This, out chain))
            {
                chain = new List<MemberDetails>();

                var node = This;

                while (node.NodeType != ExpressionType.Parameter)
                {
                    switch (node.NodeType)
                    {
                        case ExpressionType.Index:
                            var indexExpr = (IndexExpression)node;
                            if (indexExpr.Object.NodeType != ExpressionType.Parameter)
                            {
                                indexExpr.Update(Expression.Parameter(indexExpr.GetParent().Type), indexExpr.Arguments);
                            }

                            chain.Add(new IndexMemberDetails(indexExpr));

                            node = indexExpr.Object;
                            break;
                        case ExpressionType.MemberAccess:
                            var memberExpr = (MemberExpression)node;

                            if (memberExpr.Expression.NodeType != ExpressionType.Parameter)
                            {

                                memberExpr.Update(Expression.Parameter(memberExpr.GetParent().Type));
                            }

                            if (memberExpr.Member is PropertyInfo)
                            {
                                chain.Add(new PropertyMemberDetails(memberExpr));
                            }
                            else
                            {
                                chain.Add(new FieldMemberDetails(memberExpr));
                            }

                            node = memberExpr.Expression;

                            break;
                        default:
                            throw new NotSupportedException($"Unsupported expression type: '{node.NodeType}'");
                    }
                }

                chain.Reverse();

                _memberDetailsCache[This] = chain;
            }
            return chain;
        }

    }
}
