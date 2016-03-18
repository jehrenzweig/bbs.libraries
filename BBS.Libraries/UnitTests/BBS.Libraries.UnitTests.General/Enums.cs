using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BBS.Libraries.UnitTests.General
{
    [TestFixture]
    public class Enums
    {
        [Test]
        public void Enums_Can_Be_Resolved_With_Abbreviation()
        {
            // ARRANGE
            var newYorkCityAbbreviation = "BOS";

            // ACT
            var city = BBS.Libraries.Enums.OfType<Data.Cities>.ParseAbbreviation(newYorkCityAbbreviation);

            // ASSERT
            Assert.That(city, Is.EqualTo(Data.Cities.Boston));
        }

        [Test]
        public void Enums_Name_Value_Can_Be_Retreived()
        {
            // ARRANGE
            var enumToTest = Data.People.brenton;

            // ACT
            var value = BBS.Libraries.Enums.Attributes.Info.GetName(enumToTest);

            // ASSERT
            Assert.That(value, Is.EqualTo("Brenton Lamar"));
        }

        [Test]
        public void Enum_Categories_Are_Honored()
        {
            // Arrange
            var categoryToCheck = "Developer";

            // Act
            var value = BBS.Libraries.Enums.OfType<Data.People>.ParseCategory(categoryToCheck);

            // Assert
            Assert.That(value, Has.Member(Data.People.brenton));
            Assert.That(value, Has.Member(Data.People.edward));
            Assert.That(value, !Has.Member(Data.People.jason));
            Assert.That(value, !Has.Member(Data.People.jesse));
        }

        [Test]
        public void Enum_IsActive_Is_Honored()
        {
            // Arrange
            
            // Act
            var value = BBS.Libraries.Enums.OfType<Data.People>.ToList(true);

            // Assert

            Assert.That(value, Has.Member(Data.People.brenton));
            Assert.That(value, !Has.Member(Data.People.edward));
            Assert.That(value, !Has.Member(Data.People.jason));
            Assert.That(value, Has.Member(Data.People.jesse));
        }

        [Test]
        public void Enum_Can_Be_Derived_From_Value()
        {
            // Arrange
            var valueToTest = "The Best";

            // Act
            var value = BBS.Libraries.Enums.OfType<Data.People>.Parse(valueToTest);

            // Assert
            Assert.That(value, Is.EqualTo(Data.People.jason));
        }
    }
}
