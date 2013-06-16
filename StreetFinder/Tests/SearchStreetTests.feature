﻿Feature: SearchStreetTests
	In order to enter my address information
	As a user from an internet portal
	I want to be told suggestions about possible streetss

Background: 
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

# Term Search
Scenario: Search an street that matches with the term of a given street name
	Given the user enters the following street
	| name | pobox |
	| S-Bahnhof Isartor | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an new street, similar to an existing one but with different Pobox
	Given in the repository is stored the street
	| name              | pobox |
	| Bahnhof | 123 |
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

# Prefix Search

Scenario: Search an street that matches with the prefix of a given street name
	Given the user enters the following street
	| name | pobox |
	| isar | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |


Scenario: Search an street that matches with the prefix of a given street name with umlaut
	Given in the repository is stored the street
	| name				  | pobox |
	| Saarbrücker | 86161 |
	And the user enters the following street
	| name        | pobox |
	| saarbrü	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| Saarbrücker | 86161 |