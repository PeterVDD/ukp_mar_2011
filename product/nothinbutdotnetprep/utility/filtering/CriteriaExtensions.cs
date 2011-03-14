namespace nothinbutdotnetprep.utility.filtering
{
    public static class CriteriaExtensions
    {

        public static Criteria<ItemToMatch> as_criteria<ItemToMatch>(this MatchingCondition<ItemToMatch> condition)
        {
            return new ConditionalCriteria<ItemToMatch>(condition);
        }

        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                            Criteria<ItemToMatch> right)
        {
            return new OrCriteria<ItemToMatch>(left, right);
        }

        public static Criteria<ItemToMatch> and<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                    Criteria<ItemToMatch> right)
        {
            return new AndCriteria<ItemToMatch>(left, right);
        }

        public static Criteria<ItemToMatch> not<ItemToMatch>(this Criteria<ItemToMatch> toNegate)
        {
            return new NotCriteria<ItemToMatch>(toNegate);
        }

        public static Criteria<ItemToMatch> xor<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                    Criteria<ItemToMatch> right)
        {
            return new XorCriteria<ItemToMatch>(left, right);
        }

    }
}