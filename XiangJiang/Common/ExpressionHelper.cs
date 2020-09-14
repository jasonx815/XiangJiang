using System;
using System.Linq.Expressions;

namespace XiangJiang.Common
{
    public static class ExpressionHelper
    {
        public static string GetMemberName(this Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression) expression;
                    var superName = GetMemberName(memberExpression.Expression);
                    return string.IsNullOrEmpty(superName) ? memberExpression.Member.Name : string.Concat(superName, '.', memberExpression.Member.Name);

                case ExpressionType.Call:
                    var callExpression = (MethodCallExpression) expression;
                    return callExpression.Method.Name;

                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression) expression;
                    return GetMemberName(unaryExpression.Operand);

                case ExpressionType.Parameter:
                case ExpressionType.Constant:
                    return string.Empty;

                default:
                    throw new ArgumentException("The expression is not a member access or method call expression");
            }
        }
    }
}