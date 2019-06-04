﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ServiceLayer.Core.UnitTests.Internal.Factories.ActionResultFactory.Create.WhenGivenIDataServiceResult.WithHttpServiceResultType
{
    public class WhenResultTypeIsOk : GivenAnHttpServiceResultType
    {
        public WhenResultTypeIsOk() : base(HttpServiceResultTypes.Ok)
        {
        }

        [Test]
        public void Should_Return_OkObjectResult()
        {
            ActionResult.Should().BeOfType<OkObjectResult>(); 
        }

        [Test]
        public void Should_Have_Data_Matching_Given_Data()
        {
            OkObjectResult okObjectResult = (OkObjectResult)ActionResult;
            okObjectResult.Value.Should().BeSameAs(Data);
        }
    }
}