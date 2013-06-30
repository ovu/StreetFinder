Feature: SearchStreetTests
	In order to enter my address information
	As a user from an internet portal
	I want to be told suggestions about possible streets

# Term Search

Scenario: Search a street that matches with the term of a given street name
    Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name | pobox |
	| S-Bahnhof Isartor | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search a new street, similar to an existing one but with different Pobox
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	| Bahnhof           | 123   |
	And the user enters the following street
	| name | pobox |
	| Bahnhof | 123 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
		| name              | pobox |
		| Bahnhof | 123 |
		And the user should not have the following autocomplete suggestions
		| name              | pobox |
		| S-Bahnhof Isartor | 86161 |

# Pobox Validations

Scenario: Search a street when the Pobox starts with 0
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	| Street pobox 0    | 06161 |
	And the user enters the following street
	| name   | pobox |
	| Street pobox 0 | 06161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name           | pobox |
	| Street pobox 0 | 06161 |

# Numbers in the name of the street
Scenario: Search a street when the name contains numbers
	Given in the repository is stored the street
	| name				  | pobox |
	| U12345 station | 86161 |
	And the user enters the following street
	| name        | pobox |
	| U12345	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| U12345 station | 86161 |

# Duplicate streets
Scenario: Search a duplicated street by term should return just one street
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name | pobox |
	| S-Bahnhof | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |