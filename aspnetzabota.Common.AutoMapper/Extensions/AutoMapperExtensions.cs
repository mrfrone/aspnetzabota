using AutoMapper;

namespace aspnetzabota.Common.AutoMapper.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreOther<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllOtherMembers(opt => opt.Ignore());
            return expression;
        }
    }
}