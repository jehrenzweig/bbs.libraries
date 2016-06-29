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

namespace BBS.Libraries.UnitTests.General
{
    public class Data
    {
        public enum People
        {
            [BBS.Libraries.Enums.Attributes.Info(Categories = new string[] { "Developer" }, Name = "Brenton Lamar")]
            brenton,
            [BBS.Libraries.Enums.Attributes.Info(Categories = new string[] { "Developer" }, Active = false)]
            edward,
            [BBS.Libraries.Enums.Attributes.Info(Active = false, Value = "The Best", Name = "Jay")]
            jason,
            [BBS.Libraries.Enums.Attributes.Info(Active = true)]
            jesse
        }

        // Used to test the "Abbreviation" portions of the Enums
        public enum Cities
        {
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "NYC")]
            NewYorkCity = 0,
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "CHC", Code = "CHIC")]
            Chicago,
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "TUP")]
            Tupelo,
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "NA")]
            NewAlbany,
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "BOS")]
            Boston,
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "LA")]
            LosAngelas,
            [BBS.Libraries.Enums.Attributes.Info(Abbreviation = "DEN")]
            Denver
        }

        public enum Things
        {
            [BBS.Libraries.Enums.Attributes.Description("Thing One")]
            [BBS.Libraries.Enums.Attributes.Info(Active = true)]
            ThingOne,
            [BBS.Libraries.Enums.Attributes.Description("Thing Two")]
            [BBS.Libraries.Enums.Attributes.Info(Active = true)]
            ThingTwo,
            [BBS.Libraries.Enums.Attributes.Info(Active = true)]
            ThingRed,
            [BBS.Libraries.Enums.Attributes.Info(Active = true)]
            ThingBlue,
            [BBS.Libraries.Enums.Attributes.Info(Active = false)]
            ThingGreen
        }

        public enum ThingsThatHaveNoMetadata
        {
            ThingOne,
            ThingTwo,
            ThingThree,
            ThingFour
        }
    }
}
