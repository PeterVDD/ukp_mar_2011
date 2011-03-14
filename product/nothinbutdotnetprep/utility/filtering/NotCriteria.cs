namespace nothinbutdotnetprep.utility.filtering
{
    public class NotCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        private Criteria<ItemToMatch> negate;

        public NotCriteria(Criteria<ItemToMatch> negate)
        {
            this.negate = negate;
        }

        public bool matches(ItemToMatch item)
        {
            return negate == null || !negate.matches(item);
        }
    }
}