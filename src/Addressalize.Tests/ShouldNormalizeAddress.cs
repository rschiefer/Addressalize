using Addressalize;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Tests
{
    public class Tests
    {
        private Addressalizer addressalizer;
        private Stopwatch stopWatch;

        [SetUp]
        public void Setup()
        {
            this.addressalizer = new Addressalizer();
            this.stopWatch = new Stopwatch();
            this.stopWatch.Start();
        }
        [TearDown]
        public void Teardown()
        {
            this.stopWatch.Stop();
            TestContext.WriteLine($"Elapsed ticks: {this.stopWatch.ElapsedTicks}");            
        }

        [TestCase("123 First Ave", "123 1ST AVE")]
        [TestCase("123 Second Ave", "123 2ND AVE")]
        [TestCase("123 Third Ave", "123 3RD AVE")]
        [TestCase("123 Fourth Ave", "123 4TH AVE")]
        [TestCase("123 Forty Fifth Ave", "123 45TH AVE")]
        [TestCase("123 Hundredth Ave", "123 100TH AVE")]
        public void ShouldNormalizeWordNumbers(string source, string expectedResult)
        {
            var result = this.addressalizer.NormalizeAddress(source);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("123 Main St North", "123 MAIN ST N")]
        [TestCase("123 Main St East", "123 MAIN ST E")]
        [TestCase("123 Main St South", "123 MAIN ST S")]
        [TestCase("123 Main St West", "123 MAIN ST W")]
        [TestCase("123 Main St Northeast", "123 MAIN ST NE")]
        [TestCase("123 Main St Northwest", "123 MAIN ST NW")]
        [TestCase("123 Main St Southeast", "123 MAIN ST SE")]
        [TestCase("123 Main St Southwest", "123 MAIN ST SW")]
        [TestCase("123 Mallard North West", "123 MALLARD N W")]
        public void ShouldNormalizeDirections(string source, string expectedResult)
        {
            var result = this.addressalizer.NormalizeAddress(source);
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestCase("4217 Olympus View Drive", "4217 OLYMPUS VW DR")]
        [TestCase("4217 Olympus View Drive NE", "4217 OLYMPUS VW DR NE")]
        [TestCase("123 Point W", "123 POINT W")]
        public void ShouldReplaceStreetSuffixAfterFirstStreetWord(string source, string expectedResult)
        {
            var result = this.addressalizer.NormalizeAddress(source);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("4217 Olympus Dr.", "4217 OLYMPUS DR")]
        [TestCase("4217 Olympus Dr.,", "4217 OLYMPUS DR")]
        [TestCase("4217 Olympus.,Dr", "4217 OLYMPUS DR")]
        [TestCase("4217 Olympus  Dr.,", "4217 OLYMPUS DR")]
        public void ShouldRemovePunctuation(string source, string expectedResult)
        {
            var result = this.addressalizer.NormalizeAddress(source);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldNormalizeSampleAddresses()
        {
            var addresses = new[] { "600 Broadway suite 400", "Los Angeles CA 90001", "1900 South Boulevard", "4217 Olympus View Dr.", "1472 Serene Road", "Colombia", "1647 8th Avenue", "New York City", "Chicago,IL", "720 Glenns farm Way", "PO Box 637", "Canada", "Chicago IL", "6662 S. Peoria", "Room 4", "931 Monroe Drive", "PO Box 5956", "6742 Forest Hill Blvd.,Ste 292", "332 East 3300 South", "Ashburn VA", "12826 197th Place NE", "NJ", "Thailand", "Melbourne FL 32903", "London United Kingdom", "1901 S. Meyers Rd.", "2511 SE Belmont Street", "Toronto Canada", "261 Cottage Circle", "Auckland", "P. O Box 79146", "2863 St. Rose Pkwy", "MO 65037", "Marina del Rey CA 90292", "Austin TX", "Toronto Canada", "PO Box 607171", "From Venice to Salem", "Sherman Oaks CA 91413", "4505 Las Virgenes Rd.", "4712 Admiralty Way #373", "UT", "Greensboro GA 30642", "please contact via email", "Candelinintie 5 c", "1900 E. Golf Rd.", "2603 NW 12th St", "20 Broadwick Street", "448 Central Avenue", "315 S. Beverly Drive", "CG-208,Sector-2,Salt Lake", "P.O. Box #373", "3002 Commerce,Deep Ellum", "CA", "Italy", "NY", "1240 East 2100 South,Suite 300", "Manchester United Kingdom", "P.O. Box 105", "The Studio 3", "PO Box 31112", "94 North High Street", "5832 Wheelhouse Lane", "315 S. Coast Hwy 101,U175", "United Kingdom", "330 W. Bridge St. #320", "161 First Street", "155 Fleet Street", "The Jersey Shore", "NYC / SF", "Bryanston", "10950 Moorpark St", "3756 Pimlico Drive", "Las Vegas NV 89169", "1301 Oak Hollow", "calle 62 no. 4-25", "2952 E Somerset Vlg Way", "Post Office Box 14881", "2 The Court", "30 Park Road", "Douridos 8", "Serving", "10818 Jasper Avenue", "1012 W Beardsley Pl", "405 S. Dale Mabry Hwy.", "Malaysia", "Irving TX 75063", "1259 N. 100 E.", "8 East Broadway", "930 Steiner Street", "UT 84112", "1530 North Technology Way", "Las Vegas NV 89113", "Los Angeles CA", "Salt Lake City UT", "Ithaca NY", "P.O. Box 32513", "Paris", "Askrigg", "1403 South 600 West", "Oldham", "St Louis MO 63026", "Yorkshire United Kingdom", "520 Reynolds drive", "3335 South 900 East", "7518-F Fullerton Road", "11 N Fulton St.", "PO BOX 630", "1905 West 4700 South", "SL/UT/Counties UT", "Utah Valley UT 84604" };
            foreach(var address in addresses)
            {
                Console.WriteLine(address);
                Console.WriteLine(this.addressalizer.NormalizeAddress(address));

            }
        }

        [TestCase("123 Main St Suite 15", "123 MAIN ST STE 15")]
        public void ShouldAbbreviateUnitDesignators(string source, string expectedResult)
        {
            var result = this.addressalizer.NormalizeAddress(source);
            Assert.AreEqual(expectedResult, result);
        }

        // POSSIBLE FUTURE FEATURES

    }
}