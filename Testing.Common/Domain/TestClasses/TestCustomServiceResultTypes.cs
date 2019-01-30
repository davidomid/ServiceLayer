﻿using ServiceLayer.Attributes;

namespace Testing.Common.Domain.TestClasses
{
    public enum TestCustomServiceResultTypes
    {
        TestValueWithNoAttribute,
        [Success]
        TestValueWithSuccessAttribute
    }
}