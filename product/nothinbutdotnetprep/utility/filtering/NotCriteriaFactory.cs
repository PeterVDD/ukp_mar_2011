namespace nothinbutdotnetprep.utility.filtering
{
    public class NotCriteriaFactory<ItemToFilter, ReturnType> : CriteriaFactory<ItemToFilter, ReturnType>
    {
        private readonly CriteriaFactory<ItemToFilter, ReturnType> original_factory;

        public NotCriteriaFactory(CriteriaFactory<ItemToFilter, ReturnType> originalFactory)
        {
            original_factory = originalFactory;
        }

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return original_factory.create_from(property_criteria).not();
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return original_factory.equal_to(value_to_equal).not();
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return original_factory.equal_to_any(values).not();
        }
    }
}