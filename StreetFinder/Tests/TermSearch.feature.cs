﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18051
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
    [NUnit.Framework.DescriptionAttribute("TermSeach")]
    public partial class TermSeachFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TermSearch.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TermSeach", "In order to enter my address information\r\nAs a user from an internet portal\r\nI wa" +
                    "nt to be told suggestions about possible streets\r\nWhen the terms I entered match" +
                    " with the name of the streets", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a street that matches with the term of a given street name")]
        public virtual void SearchAStreetThatMatchesWithTheTermOfAGivenStreetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a street that matches with the term of a given street name", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table1.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 8
    testRunner.Given("in the repository is stored the street", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table2.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 11
 testRunner.And("the user enters the following street", ((string)(null)), table2, "And ");
#line 14
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table3.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 15
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a new street, similar to an existing one but with different Pobox")]
        public virtual void SearchANewStreetSimilarToAnExistingOneButWithDifferentPobox()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a new street, similar to an existing one but with different Pobox", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table4.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
            table4.AddRow(new string[] {
                        "Bahnhof",
                        "123"});
#line 20
 testRunner.Given("in the repository is stored the street", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table5.AddRow(new string[] {
                        "Bahnhof",
                        "123"});
#line 24
 testRunner.And("the user enters the following street", ((string)(null)), table5, "And ");
#line 27
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table6.AddRow(new string[] {
                        "Bahnhof",
                        "123"});
#line 28
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table6, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table7.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 31
  testRunner.And("the user should not have the following autocomplete suggestions", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a street when the Pobox starts with 0")]
        public virtual void SearchAStreetWhenThePoboxStartsWith0()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a street when the Pobox starts with 0", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table8.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
            table8.AddRow(new string[] {
                        "Street pobox0",
                        "06161"});
#line 38
 testRunner.Given("in the repository is stored the street", ((string)(null)), table8, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table9.AddRow(new string[] {
                        "Street pobox0",
                        "06161"});
#line 42
 testRunner.And("the user enters the following street", ((string)(null)), table9, "And ");
#line 45
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table10.AddRow(new string[] {
                        "Street pobox0",
                        "06161"});
#line 46
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a street when the name contains numbers")]
        public virtual void SearchAStreetWhenTheNameContainsNumbers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a street when the name contains numbers", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table11.AddRow(new string[] {
                        "U12345 station",
                        "86161"});
#line 52
 testRunner.Given("in the repository is stored the street", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table12.AddRow(new string[] {
                        "U12345",
                        "86161"});
#line 55
 testRunner.And("the user enters the following street", ((string)(null)), table12, "And ");
#line 58
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table13.AddRow(new string[] {
                        "U12345 station",
                        "86161"});
#line 59
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a duplicated street by term should return just one street")]
        public virtual void SearchADuplicatedStreetByTermShouldReturnJustOneStreet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a duplicated street by term should return just one street", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table14.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
            table14.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 65
 testRunner.Given("in the repository is stored the street", ((string)(null)), table14, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table15.AddRow(new string[] {
                        "S-Bahnhof",
                        "86161"});
#line 69
 testRunner.And("the user enters the following street", ((string)(null)), table15, "And ");
#line 72
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table16.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 73
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a street when the term is short")]
        public virtual void SearchAStreetWhenTheTermIsShort()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a street when the term is short", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table17.AddRow(new string[] {
                        "An Ufer",
                        "86111"});
#line 79
 testRunner.Given("in the repository is stored the street", ((string)(null)), table17, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table18.AddRow(new string[] {
                        "an",
                        "86111"});
#line 82
 testRunner.And("the user enters the following street", ((string)(null)), table18, "And ");
#line 85
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table19.AddRow(new string[] {
                        "An Ufer",
                        "86111"});
#line 86
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table19, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a street when the term is short an starts with st")]
        public virtual void SearchAStreetWhenTheTermIsShortAnStartsWithSt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a street when the term is short an starts with st", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table20.AddRow(new string[] {
                        "St.-Michael-Weg",
                        "86476"});
#line 91
 testRunner.Given("in the repository is stored the street", ((string)(null)), table20, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table21.AddRow(new string[] {
                        "st",
                        "86476"});
#line 94
 testRunner.And("the user enters the following street", ((string)(null)), table21, "And ");
#line 97
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table22.AddRow(new string[] {
                        "St.-Michael-Weg",
                        "86476"});
#line 98
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table22, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search a street has a one word when the term is short")]
        public virtual void SearchAStreetHasAOneWordWhenTheTermIsShort()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search a street has a one word when the term is short", ((string[])(null)));
#line 102
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table23.AddRow(new string[] {
                        "Nr.",
                        "82067"});
#line 103
 testRunner.Given("in the repository is stored the street", ((string)(null)), table23, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table24.AddRow(new string[] {
                        "Nr",
                        "82067"});
#line 106
 testRunner.And("the user enters the following street", ((string)(null)), table24, "And ");
#line 109
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table25.AddRow(new string[] {
                        "Nr.",
                        "82067"});
#line 110
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table25, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search combining terms should find the street")]
        public virtual void SearchCombiningTermsShouldFindTheStreet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search combining terms should find the street", ((string[])(null)));
#line 115
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table26.AddRow(new string[] {
                        "Johann-Baptist-Zimmermann-Str.",
                        "82069"});
#line 116
 testRunner.Given("in the repository is stored the street", ((string)(null)), table26, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table27.AddRow(new string[] {
                        "JohannBaptist",
                        "82069"});
#line 119
 testRunner.And("the user enters the following street", ((string)(null)), table27, "And ");
#line 122
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table28.AddRow(new string[] {
                        "Johann-Baptist-Zimmermann-Str.",
                        "82069"});
#line 123
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table28, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
