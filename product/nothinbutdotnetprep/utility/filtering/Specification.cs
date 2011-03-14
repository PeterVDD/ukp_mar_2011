namespace nothinbutdotnetprep.utility.filtering
{
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