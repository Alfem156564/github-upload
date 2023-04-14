namespace Data.Helper
{
    using System;
    using System.Linq.Expressions;

    public static class CombineExpressions<T>
    {
        public static Expression<Func<T, bool>> CombineExpressionsAnd(Expression<Func<T, bool>> exp, Expression<Func<T, bool>> expAux)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(exp.Parameters[0], parameter);
            var left = leftVisitor.Visit(exp.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expAux.Parameters[0], parameter);
            var right = rightVisitor.Visit(expAux.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        public static Expression<Func<T, bool>> CombineExpressionsOr(Expression<Func<T, bool>> exp, Expression<Func<T, bool>> expAux)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(exp.Parameters[0], parameter);
            var left = leftVisitor.Visit(exp.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expAux.Parameters[0], parameter);
            var right = rightVisitor.Visit(expAux.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.Or(left, right), parameter);
        }
    }
}
