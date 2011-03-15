using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultFilteringExtensionPoint<ItemToFilter, ReturnType> : FilteringExtensionPoint<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public DefaultFilteringExtensionPoint(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public FilteringExtensionPoint<ItemToFilter, ReturnType> not
        {
            get
            {
                return new NegatingFilteringExtensionPoint<ItemToFilter, ReturnType>(this);
            }
        }
        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return new PropertyCriteria<ItemToFilter, ReturnType>(property_accessor,
                                                                          property_criteria);
        }
    }

    public class DefaultIEnumerableExtensionPoint<ItemToFilter, ReturnType> : IEnumerableExtensionPoint<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;
        private System.Collections.Generic.IEnumerable<ItemToFilter> items;

        public DefaultIEnumerableExtensionPoint(IEnumerable<ItemToFilter> items, PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            this.items = items;
            this.property_accessor = property_accessor;
        }

        public IEnumerableExtensionPoint<ItemToFilter, ReturnType> not
        {
            get
            {
                return new NegatingIEnumerableExtensionPoint<ItemToFilter, ReturnType>(this);
            }
        }

        public IEnumerable<ItemToFilter> execute(Criteria<ReturnType> property_criteria)
        {

            var criteria = new PropertyCriteria<ItemToFilter, ReturnType>(property_accessor,
                                                                         property_criteria);
            return items.all_items_matching(criteria);
        }
    }

    public class NegatingIEnumerableExtensionPoint<ItemToFilter, ReturnType>:IEnumerableExtensionPoint<ItemToFilter, ReturnType>
    {
        private IEnumerableExtensionPoint<ItemToFilter, ReturnType> original;

        public NegatingIEnumerableExtensionPoint(IEnumerableExtensionPoint<ItemToFilter, ReturnType> enumerableExtensionPoint)
        {
            this.original = enumerableExtensionPoint;
        }

        public IEnumerable<ItemToFilter> execute(Criteria<ReturnType> property_criteria)
        {
            return original.execute(property_criteria.not());
        }
    }
}