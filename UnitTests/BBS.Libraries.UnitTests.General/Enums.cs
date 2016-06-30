//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) Wednesday, June 29, 2016 1:15:39 PM Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------

using NUnit.Framework;

namespace BBS.Libraries.UnitTests.General
{
    [TestFixture]
    public class Enums
    {
        [Test]
        public void Enums_Invalid_Abbreviation_Resolves_As_Default()
        {
            // ARRANGE
            var newYorkCityAbbreviation = "INVALID";

            // ACT
            var city = BBS.Libraries.Enums.OfType<Data.Cities>.ParseAbbreviation(newYorkCityAbbreviation);

            // ASSERT
            Assert.That(city, Is.EqualTo(Data.Cities.NewYorkCity));
        }

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
        public void Enums_Can_Be_Resolved_With_Code()
        {
            // ARRANGE
            var chicagoCode = "CHIC";

            // ACT
            var city = BBS.Libraries.Enums.OfType<Data.Cities>.ParseCode(chicagoCode);

            // ASSERT
            Assert.That(city, Is.EqualTo(Data.Cities.Chicago));
        }
        [Test]
        public void Enums_Invalid_Code_Resolves_As_Default()
        {
            // ARRANGE
            var chicagoCode = "CHICAGO";

            // ACT
            var city = BBS.Libraries.Enums.OfType<Data.Cities>.ParseCode(chicagoCode);

            // ASSERT
            Assert.That(city, Is.EqualTo(Data.Cities.NewYorkCity));
        }
        [Test]
        public void Enums_Can_Be_Resolved_With_Name()
        {
            // ARRANGE
            var value = "Jay";

            // ACT
            var resolvedValue = BBS.Libraries.Enums.OfType<Data.People>.ParseName(value);

            // ASSERT
            Assert.That(resolvedValue, Is.EqualTo(Data.People.jason));
        }
        [Test]
        public void Enums_Invalid_Name_Resolves_As_Default()
        {
            // ARRANGE
            var value = "JAz";

            // ACT
            var resolvedValue = BBS.Libraries.Enums.OfType<Data.People>.ParseName(value);

            // ASSERT
            Assert.That(resolvedValue, Is.EqualTo(Data.People.brenton));
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

        [Test]
        public void Enum_Can_Be_Derived_From_Name()
        {
            // Arrange
            var valueToTest = "Jay";

            // Act
            var value = BBS.Libraries.Enums.OfType<Data.People>.ParseName(valueToTest);

            // Assert
            Assert.That(value, Is.EqualTo(Data.People.jason));
        }

        [Test]
        public void Enum_Can_Be_Derived_From_Description()
        {
            // Arrange
            var valueToTest = "Thing Two";

            // Act
            var value = BBS.Libraries.Enums.OfType<Data.Things>.ParseDescription(valueToTest);

            // Assert
            Assert.That(value, Is.EqualTo(Data.Things.ThingTwo));
        }

        [Test]
        public void Enum_To_List_Multi_Attributes_Respect_Active_Flag()
        {
            // Arrange
            var activeThings = BBS.Libraries.Enums.OfType<Data.Things>.ToList(true);

            // Assert
            Assert.That(activeThings, Has.Member(Data.Things.ThingOne));
            Assert.That(activeThings, Has.Member(Data.Things.ThingTwo));
            Assert.That(activeThings, Has.Member(Data.Things.ThingRed));
            Assert.That(activeThings, Has.Member(Data.Things.ThingBlue));
            Assert.That(activeThings, !Has.Member(Data.Things.ThingGreen));
        }

        [Test]
        public void Enum_To_List_Multi_Attributes_ToList_NoBool_Gets_All_Values()
        {
            // Arrange
            var activeThings = BBS.Libraries.Enums.OfType<Data.Things>.ToList();

            // Assert
            Assert.That(activeThings, Has.Member(Data.Things.ThingOne));
            Assert.That(activeThings, Has.Member(Data.Things.ThingTwo));
            Assert.That(activeThings, Has.Member(Data.Things.ThingRed));
            Assert.That(activeThings, Has.Member(Data.Things.ThingBlue));
            Assert.That(activeThings, Has.Member(Data.Things.ThingGreen));
        }

        [Test]
        public void Enum_To_List_Multi_Attributes_ToList_NoBool_No_Attributes_Gets_All_Values()
        {
            // Arrange
            var activeThings = BBS.Libraries.Enums.OfType<Data.ThingsThatHaveNoMetadata>.ToList();

            // Assert
            Assert.That(activeThings, Has.Member(Data.ThingsThatHaveNoMetadata.ThingOne));
            Assert.That(activeThings, Has.Member(Data.ThingsThatHaveNoMetadata.ThingTwo));
            Assert.That(activeThings, Has.Member(Data.ThingsThatHaveNoMetadata.ThingThree));
            Assert.That(activeThings, Has.Member(Data.ThingsThatHaveNoMetadata.ThingFour));
        }

        [Test]
        public void Enum_To_List_Multi_Attributes_ToList_Bool_No_Attributes_Gets_No_Value()
        {
            // Arrange
            var activeThings = BBS.Libraries.Enums.OfType<Data.ThingsThatHaveNoMetadata>.ToList(true);

            // Assert
            Assert.That(activeThings, !Has.Member(Data.ThingsThatHaveNoMetadata.ThingOne));
            Assert.That(activeThings, !Has.Member(Data.ThingsThatHaveNoMetadata.ThingTwo));
            Assert.That(activeThings, !Has.Member(Data.ThingsThatHaveNoMetadata.ThingThree));
            Assert.That(activeThings, !Has.Member(Data.ThingsThatHaveNoMetadata.ThingFour));
        }
    }
}
