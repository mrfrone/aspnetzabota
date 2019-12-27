using AutoMapper;
using aspnetzabota.Common.Result;
using aspnetzabota.Common.Result.ErrorCodes;

namespace aspnetzabota.Common.AutoMapper.Extensions
{
    public static class AutoMapperExtensions
    {
        public static ZabotaResult<TModel> MapIfExist<TModel>(this IMapper mapper, object obj, ZabotaErrorCodes codeIfNotExist)
        {
            if (obj == null)
                return codeIfNotExist;

            var model = mapper.Map<TModel>(obj);
            return new ZabotaResult<TModel>(model);
        }

        public static IMappingExpression<TSource, TDest> IgnoreOther<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllOtherMembers(opt => opt.Ignore());
            return expression;
        }
    }
}