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