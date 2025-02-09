using System.Linq.Expressions;

namespace MedGestor.Core.Application.Utils;

public static class ExpressionExtension
{
    /// <summary>
    ///     Basic Rule for Linq Expressions
    /// </summary>
    /// <typeparam name="T">Type of Object</typeparam>
    /// <returns>Returns True</returns>
    public static Expression<Func<T, bool>> Query<T>() { return f => true; }
 
    /// <summary>
    ///     Extension for AND query operations.
    /// </summary>
    /// <remarks>http://www.albahari.com/nutshell/predicatebuilder.aspx</remarks>
    /// <param name="expr1">Expression base for operation</param>
    /// <param name="expr2">Expression for operation AND</param>
    /// <typeparam name="T">Type of Object</typeparam>
    /// <returns>Expression Merged</returns>
    public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    }
}