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
    [NUnit.Framework.DescriptionAttribute("LevenshteinDistance")]
    public partial class LevenshteinDistanceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LevenshteinDistance.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "LevenshteinDistance", "In order to enter my address information\r\nAs a user from an internet portal\r\nI wa" +
                    "nt to be told suggestions about possible streets\r\neven when the text I entered i" +
                    "s not completely correct", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 7
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
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street when the name was not written correctly")]
        public virtual void SearchAnStreetWhenTheNameWasNotWrittenCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street when the name was not written correctly", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table2.AddRow(new string[] {
                        "wahnhof isator",
                        "86161"});
#line 13
 testRunner.Given("the user enters the following street", ((string)(null)), table2, "Given ");
#line 16
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table3.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 17
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street when the name is very different from the original one")]
        public virtual void SearchAnStreetWhenTheNameIsVeryDifferentFromTheOriginalOne()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street when the name is very different from the original one", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table4.AddRow(new string[] {
                        "wahnof iseerdor",
                        "86161"});
#line 23
 testRunner.Given("the user enters the following street", ((string)(null)), table4, "Given ");
#line 26
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table5.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 27
 testRunner.Then("the user should not have the following autocomplete suggestions", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street when the text entered has less than three characters")]
        public virtual void SearchAnStreetWhenTheTextEnteredHasLessThanThreeCharacters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street when the text entered has less than three characters", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table6.AddRow(new string[] {
                        "wa",
                        "86161"});
#line 32
 testRunner.Given("the user enters the following street", ((string)(null)), table6, "Given ");
#line 35
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table7.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 36
 testRunner.Then("the user should not have the following autocomplete suggestions", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search case insensitive an street")]
        public virtual void SearchCaseInsensitiveAnStreet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search case insensitive an street", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table8.AddRow(new string[] {
                        "BAHNHOF Isertor",
                        "86161"});
#line 41
 testRunner.Given("the user enters the following street", ((string)(null)), table8, "Given ");
#line 44
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table9.AddRow(new string[] {
                        "S-Bahnhof Isartor",
                        "86161"});
#line 45
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search an street when the name of the street contains numbers")]
        public virtual void SearchAnStreetWhenTheNameOfTheStreetContainsNumbers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search an street when the name of the street contains numbers", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table10.AddRow(new string[] {
                        "U12345 Isartor",
                        "86165"});
#line 50
 testRunner.Given("in the repository is stored the street", ((string)(null)), table10, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table11.AddRow(new string[] {
                        "U1245",
                        "86165"});
#line 53
 testRunner.And("the user enters the following street", ((string)(null)), table11, "And ");
#line 56
 testRunner.When("the portal search for streets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "pobox"});
            table12.AddRow(new string[] {
                        "U12345 Isartor",
                        "86165"});
#line 57
 testRunner.Then("the user should have the following autocomplete suggestions", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
