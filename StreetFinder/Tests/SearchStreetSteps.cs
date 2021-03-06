﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using StreetFinder;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class SearchStreetSteps
    {
        private static StreetRepositoryLucene repository;

        [BeforeFeature]
        public static void PrepareRepository()
        {
            repository = new StreetRepositoryLucene();
        }

        [Given(@"the repository is initialized")]
        public void GivenTheRepositoryIsInitialized()
        {
        }

        [Given(@"in the repository is stored the street")]
        public void GivenInTheRepositoryIsStoredTheStreet(Table table)
        {
            if (repository.ExistStreetRepository())
            {
                repository.DeleteStreetRepository();
            }
            repository.CreateStreetRepository();

            foreach (var row in table.Rows)
            {
                var street = new Street {Name = row["name"], Pobox = row["pobox"]};

                repository.InsertStreet(street);
            }
        }

        [Given(@"the user enters the following street")]
        public void GivenTheUserEntersTheFollowingStreet(Table table)
        {
            foreach (var row in table.Rows)
            {
                var streetToBeSearch = new Street { Name = row["name"], Pobox = row["pobox"] };

                ScenarioContext.Current.Add("StreetToBeSearch", streetToBeSearch);
            }
        }

        [Given(@"the user enters the street ""(.*)""  with the pobox ""(.*)""")]
        public void GivenTheUserEntersTheStreetWithThePobox(string streetName, string pobox)
        {
            var streetToBeSearch = new Street { Name = streetName, Pobox = pobox };

            ScenarioContext.Current.Add("StreetToBeSearch", streetToBeSearch);
        }

        [When(@"the portal search for streets")]
        public void WhenThePortalSearchForStreets()
        {
            var streetToBeSearch = ScenarioContext.Current.Get<Street>("StreetToBeSearch");
            var searchResult = repository.SearchForStreets(streetToBeSearch.Pobox, streetToBeSearch.Name);
            ScenarioContext.Current.Add("SearchResult", searchResult);
        }

        [Then(@"the user should have the following autocomplete suggestions")]
        public void ThenTheUserShouldHaveTheFollowingAutocompleteSuggestions(Table table)
        {
            var searchResult = ScenarioContext.Current.Get<IEnumerable<Street>>("SearchResult");
            var searchResultList = searchResult.ToList();
            foreach (var row in table.Rows)
            {
                var streetToBeFound = new Street {Name = row["name"], Pobox = row["pobox"]};

                searchResultList.Should()
                            .Contain(s => s.Name.Equals(streetToBeFound.Name) && s.Pobox.Equals(streetToBeFound.Pobox));
            }

            Assert.AreEqual(table.Rows.Count, searchResultList.Count);
        }

        [Then(@"the user should not have the following autocomplete suggestions")]
        public void ThenTheUserShouldNotHaveTheFollowingAutocompleteSuggestions(Table table)
        {
            var searchResult = ScenarioContext.Current.Get<IEnumerable<Street>>("SearchResult");
            var searchResultList = searchResult.ToList();
            foreach (var row in table.Rows)
            {
                var streetToBeFound = new Street { Name = row["name"], Pobox = row["pobox"] };

                searchResultList.Should().NotContain(s => s.Name.Equals(streetToBeFound.Name) && s.Pobox.Equals(streetToBeFound.Pobox));
            }
        }
    }
}
