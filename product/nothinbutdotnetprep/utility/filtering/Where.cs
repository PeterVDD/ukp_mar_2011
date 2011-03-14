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

    public class Specification<ItemToFilter, ReturnType>
    {
        private readonly PropertyAccessor<ItemToFilter, ReturnType> pp;

        public Specification(PropertyAccessor<ItemToFilter, ReturnType> pp)
        {
            this.pp = pp;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType studio)
        {
            return new ConditionalCriteria<ItemToFilter>(m => pp(m).Equals(studio));
        }
    }
}