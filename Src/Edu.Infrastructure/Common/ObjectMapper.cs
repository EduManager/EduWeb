using System.Collections.Generic;
using EmitMapper;

namespace Edu.Infrastructure.Common
{
    public class ObjectMapper<TSource, TTarget>
    {
        private static readonly ObjectsMapper<TSource, TTarget> Mapper =
            EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<TSource, TTarget>();

        public static TTarget MapObject(TSource from)
        {
            return Mapper.Map(from);
        }

        public static List<TTarget> MapListObject(List<TSource> listFrom)
        {
            List<TTarget> result = new List<TTarget>();
            foreach (var item in listFrom)
            {
                result.Add(MapObject(item));
            }
            return result;
        }
    }
}
