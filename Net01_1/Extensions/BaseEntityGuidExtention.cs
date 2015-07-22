using System;
using Net01_1.Model;

namespace Net01_1.Extensions
{
    public static class BaseEntityGuidExtention
    {
        public static void CreateEntityGuid(this BaseEntity entity)
        {
            entity.Id =  Guid.NewGuid();
        }
    }
}
