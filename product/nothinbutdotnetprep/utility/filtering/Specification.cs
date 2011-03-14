namespace nothinbutdotnetprep.utility.filtering
{
    public class Specification<ItemToFilter, ReturnType>
    {
        private readonly PropertyAccessor<ItemToFilter, ReturnType> accessor;

        public Specification(PropertyAccessor<ItemToFilter, ReturnType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType studio)
        {
            return new ConditionalCriteria<ItemToFilter>(m => accessor(m).Equals(studio));
        }
    }
}