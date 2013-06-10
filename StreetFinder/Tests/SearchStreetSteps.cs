using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FluentAssertions;
using StreetFinderInterface;
using StreetFinderLucene;
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

            if (repository.ExistStreetRepository())
            {
                repository.DeleteStreetRepository();
            }
            repository.CreateStreetRepository();
        }

        [Given(@"the repository is initialized")]
        public void GivenTheRepositoryIsInitialized()
        {
        }

        [Given(@"in the repository is stored the street")]
        public void GivenInTheRepositoryIsStoredTheStreet(Table table)
        {
            foreach (var row in table.Rows)
            {
                var street = new Street {Name = row["name"], Pobox = int.Parse(row["pobox"])};

                repository.InsertStreet(street);
            }
        }

        [Given(@"the user enters the following street")]
        public void GivenTheUserEntersTheFollowingStreet(Table table)
        {
            foreach (var row in table.Rows)
            {
                var streetToBeSearch = new Street { Name = row["name"], Pobox = int.Parse(row["pobox"]) };

                ScenarioContext.Current.Add("StreetToBeSearch", streetToBeSearch);
            }
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
                var streetToBeFound = new Street {Name = row["name"], Pobox = int.Parse(row["pobox"])};

                searchResultList.Should()
                            .Contain(s => s.Name.Equals(streetToBeFound.Name) && s.Pobox.Equals(streetToBeFound.Pobox));
            }
        }
    }
}
