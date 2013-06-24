Feature: LevenshteinDistance
	In order to enter my address information
	As a user from an internet portal
	I want to be told suggestions about possible streets
	even when the text I entered is not completely correct

Background: 
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street when the name was not written correctly
	Given the user enters the following street
	| name              | pobox |
	| wahnhof isator	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |


Scenario: Search an street when the name is very different from the original one
	Given the user enters the following street
	| name              | pobox |
	| wahnof iseerdor	| 86161 |
	When the portal search for streets
	Then the user should not have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street when the text entered has less than three characters
	Given the user enters the following street
	| name  | pobox |
	| wa	| 86161 |
	When the portal search for streets
	Then the user should not have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search case insensitive an street
	Given the user enters the following street
	| name  | pobox |
	| BAHNHOF Isertor	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street when the name of the street contains numbers
	Given in the repository is stored the street
	| name              | pobox |
	| U12345 Isartor | 86165 |
	And the user enters the following street
	| name  | pobox |
	| U1245	| 86165 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name           | pobox |
	| U12345 Isartor | 86165 |