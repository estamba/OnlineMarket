using System;

namespace OnlineMarket.Common.Models
{
    enum AttributeValueType : byte
    {
        Integer = 1,
        String,
        Boolean,
        Decimal,
        Double,
        Date,
        SingleSelection,
        MultipleSelection
    }
}
