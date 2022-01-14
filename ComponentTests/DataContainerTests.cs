using BlazorServer.Data;
using BlazorServer.Shared;
using NSubstitute;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Bunit;
using System.Linq;

namespace ComponentTests
{
    public class DataContainerTests
    {
        private IDataRepository dataRepository;

        [SetUp]
        public void Setup()
        {
            dataRepository = Substitute.For<IDataRepository>();
        }

        [Test]
        public void DataIsShownInTable()
        {
            const int dataRows = 1;
            Guid dataValue = Guid.NewGuid();
            
            using var context = new Bunit.TestContext();
            context.Services.AddSingleton(dataRepository);
            dataRepository.GetData(dataRows).Returns(new List<Guid> { dataValue });

            var sut = context.RenderComponent<DataContainer>(parameters => 
                parameters.Add(p => p.SuggestedNewDataRows, dataRows));
            sut.Find("button").Click();

            var tableCells = sut.FindAll("td");
            Assert.That(tableCells.Single().TextContent, Is.EqualTo(dataValue.ToString()));
        }
    }
}