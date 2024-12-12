using AutoMapper;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Utilities.Extensions
{
    public static class EntityExtension
    {
        public static T ToDTO<T>(this IEntity entity, IMapper mapper)
        {
            return mapper.Map<T>(entity);
        }

        public static IEnumerable<T> ToDTOCollection<T>(this IQueryable<IEntity> entities, IMapper mapper)
        {
            return entities.Select(entity => mapper.Map<T>(entity));
        }
    }
}
