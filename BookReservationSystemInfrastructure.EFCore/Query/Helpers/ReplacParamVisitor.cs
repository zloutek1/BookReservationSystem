using System.Linq.Expressions;

namespace BookReservationSystemInfrastructure.EFCore.Query.Helpers;

public class ReplaceParamVisitor : ExpressionVisitor
{
    private readonly ParameterExpression _param;
    private readonly Expression _replacement;

    public ReplaceParamVisitor(ParameterExpression param, Expression replacement)
    {
        this._param = param;
        this._replacement = replacement;
    }

    protected override Expression VisitParameter(ParameterExpression node) => node == _param ? _replacement : node;
}