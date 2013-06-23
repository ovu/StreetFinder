﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18046
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SearchStreetTests")]
    public partial class SearchStreetTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SearchStreetTests.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SearchStreetTests", "In order to enter my address information\r\nAs a user from an internet portal\r\nI wa" +
                    "nt to be told suggestions about possible streets", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table1.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 7
 testRunner.Given("in the repository is stored the street", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street that matches with the term of a given street name")]
        public virtual void SearchAnStreetThatMatchesWithTheTermOfAGivenStreetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street that matches with the term of a given street name", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table2.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 14
 testRunner.Given("the user enters the following street", ((string)(null)), table2, "Given ");
#line 17
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table3.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 18
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an new street, similar to an existing one but with different Pobox")]
        public virtual void SearchAnNewStreetSimilarToAnExistingOneButWithDifferentPobox()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an new street, similar to an existing one but with different Pobox", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table4.AddRow(new string[] {
                        "Bahnhof",
                        "123"});
#line 23
 testRunner.Given("in the repository is stored the street", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table5.AddRow(new string[] {
                        "Bahnhof",
                        "123"});
#line 26
  testRunner.And("the user enters the following street", ((string)(null)), table5, "And ");
#line 29
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table6.AddRow(new string[] {
                        "Bahnhof",
                        "123"});
#line 30
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table6, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table7.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 33
  testRunner.And("the user should not have the following autocomplete suggestions", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street that matches with the prefix of a given street name")]
        public virtual void SearchAnStreetThatMatchesWithThePrefixOfAGivenStreetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street that matches with the prefix of a given street name", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table8.AddRow(new string[] {
                        "isar",
                        "86161"});
#line 40
 testRunner.Given("the user enters the following street", ((string)(null)), table8, "Given ");
#line 43
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table9.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 44
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the name of the street when the street is co" +
            "mpound")]
        public virtual void SearchAnStreetUsingThePrefixOfTheNameOfTheStreetWhenTheStreetIsCompound()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the name of the street when the street is co" +
                    "mpound", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table10.AddRow(new string[] {
                        "bahn isar",
                        "86161"});
#line 49
 testRunner.Given("the user enters the following street", ((string)(null)), table10, "Given ");
#line 52
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table11.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 53
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the name of the street when the street is co" +
            "mpound case Insensitive")]
        public virtual void SearchAnStreetUsingThePrefixOfTheNameOfTheStreetWhenTheStreetIsCompoundCaseInsensitive()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the name of the street when the street is co" +
                    "mpound case Insensitive", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table12.AddRow(new string[] {
                        "Bahn Isar",
                        "86161"});
#line 58
 testRunner.Given("the user enters the following street", ((string)(null)), table12, "Given ");
#line 61
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table13.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 62
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the street is compound " +
            "and searching in a different word position")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheStreetIsCompoundAndSearchingInADifferentWordPosition()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the street is compound " +
                    "and searching in a different word position", ((string[])(null)));
#line 66
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table14.AddRow(new string[] {
                        "Isar Bahn",
                        "86161"});
#line 67
 testRunner.Given("the user enters the following street", ((string)(null)), table14, "Given ");
#line 70
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table15.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 71
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table15, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has more than one space")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasMoreThanOneSpace()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has more than one space", ((string[])(null)));
#line 75
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table16.AddRow(new string[] {
                        "Isar      Bahn",
                        "86161"});
#line 76
 testRunner.Given("the user enters the following street", ((string)(null)), table16, "Given ");
#line 79
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table17.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 80
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table17, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has more than one space at the end")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasMoreThanOneSpaceAtTheEnd()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has more than one space at the end", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 85
 testRunner.Given("the user enters the street \"Isar        \"  with the pobox \"86161\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table18.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 87
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table18, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has more than one space at the beginning")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasMoreThanOneSpaceAtTheBeginning()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has more than one space at the beginning", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 92
 testRunner.Given("the user enters the street \"    Isar\"  with the pobox \"86161\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table19.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 94
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table19, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has a minus at the end")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasAMinusAtTheEnd()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has a minus at the end", ((string[])(null)));
#line 98
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 99
 testRunner.Given("the user enters the street \"Isar-\"  with the pobox \"86161\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 100
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table20.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 101
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table20, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has a minus at the beginning")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasAMinusAtTheBeginning()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has a minus at the beginning", ((string[])(null)));
#line 105
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 106
 testRunner.Given("the user enters the street \"-Isar\"  with the pobox \"86161\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 107
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table21.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 108
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table21, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has several minus")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasSeveralMinus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has several minus", ((string[])(null)));
#line 112
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 113
 testRunner.Given("the user enters the street \"Bahn-----Isar\"  with the pobox \"86161\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 114
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table22.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 115
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table22, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street using the prefix of the street name when the searched street nam" +
            "e has several minus and spaces")]
        public virtual void SearchAnStreetUsingThePrefixOfTheStreetNameWhenTheSearchedStreetNameHasSeveralMinusAndSpaces()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street using the prefix of the street name when the searched street nam" +
                    "e has several minus and spaces", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 120
 testRunner.Given("the user enters the street \"Bahn-- -- -Isar\"  with the pobox \"86161\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table23.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 122
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table23, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street that matches with the prefix of a given street name with umlaut")]
        public virtual void SearchAnStreetThatMatchesWithThePrefixOfAGivenStreetNameWithUmlaut()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street that matches with the prefix of a given street name with umlaut", ((string[])(null)));
#line 126
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table24.AddRow(new string[] {
                        "Saarbrücker",
                        "86161"});
#line 127
 testRunner.Given("in the repository is stored the street", ((string)(null)), table24, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table25.AddRow(new string[] {
                        "saarbrü",
                        "86161"});
#line 130
 testRunner.And("the user enters the following street", ((string)(null)), table25, "And ");
#line 133
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table26.AddRow(new string[] {
                        "Saarbrücker",
                        "86161"});
#line 134
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table26, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street when the Pobox starts with 0")]
        public virtual void SearchAnStreetWhenThePoboxStartsWith0()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street when the Pobox starts with 0", ((string[])(null)));
#line 140
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table27.AddRow(new string[] {
                        "Street pobox 0",
                        "06161"});
#line 141
 testRunner.Given("in the repository is stored the street", ((string)(null)), table27, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table28.AddRow(new string[] {
                        "Street pobox 0",
                        "06161"});
#line 144
 testRunner.And("the user enters the following street", ((string)(null)), table28, "And ");
#line 147
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table29.AddRow(new string[] {
                        "Street pobox 0",
                        "06161"});
#line 148
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table29, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street when the name contains numbers")]
        public virtual void SearchAnStreetWhenTheNameContainsNumbers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street when the name contains numbers", ((string[])(null)));
#line 153
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table30.AddRow(new string[] {
                        "U12345 station",
                        "86161"});
#line 154
 testRunner.Given("in the repository is stored the street", ((string)(null)), table30, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table31.AddRow(new string[] {
                        "U12345",
                        "86161"});
#line 157
 testRunner.And("the user enters the following street", ((string)(null)), table31, "And ");
#line 160
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table32.AddRow(new string[] {
                        "U12345 station",
                        "86161"});
#line 161
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table32, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
