﻿namespace ServiceLayer
{
    public class SuccessAttribute : ResultTypeAttribute
    {
        public SuccessAttribute() : base(ServiceResultTypes.Success)
        {
        }
    }
}
