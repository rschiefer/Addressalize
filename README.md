# Addressalize - Free/simple address normalization

Addressalize is a free address normalization tool.  It is intended to normalize as many address formats as possible with the least amount of effort/upkeep.  There are many paid options for address normalization/validation if correctness/completeness is more important than cost.

Feel free to share improvements or ideas to make the framework better.  Preferably in the form of a PR with unit tests.

# Build Status

[![Build Status](https://dev.azure.com/rschiefer/Addressalizer/_apis/build/status/rschiefer.Addressalize)](https://dev.azure.com/rschiefer/Addressalizer/_build/latest?definitionId=1)

# Basic usage

	var addressalizer = new Addressalizer();
	addressalizer.Normalize("123 Forty Fifth Avenue Northwest Suite A101");
	// Outputs: 123 45TH AVE NW STE A101

# Currently Supported Normalizations

-Ordinal Number Word Conversion to Numbers (Forty Fifth => 45TH)
-Street Suffix Abbreviation (Avenue => AVE)
-Directional Abbreviations (Northwest => NW)
-Unit Designation Abbreviation (Suite => STE)

# Found an issue?

You can consult the [Documents Index](Documentation/README.md) to find out the current issues and to see the workarounds.

If you don't find your issue, please file one! However, this isn't my main gig so any help/code you can provide is more likely to get more timely action.

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community.
