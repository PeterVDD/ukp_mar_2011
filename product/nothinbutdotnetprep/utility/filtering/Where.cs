using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class Where<ItemToFilter>
    {
        public static Specification<ItemToFilter, ReturnType> has_a<ReturnType>(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            return new Specification<ItemToFilter, ReturnType>(property_accessor);
        }
    }
}