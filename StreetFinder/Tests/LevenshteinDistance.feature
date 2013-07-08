Feature: LevenshteinDistance
	In order to enter my address information
	As a user from an internet portal
	I want to be told suggestions about possible streets
	even when the text I entered is not completely correct

Scenario: Search a street when the name was not written correctly
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name              | pobox |
	| wahnhof isator	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search a street when the name is very different from the original one
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name              | pobox |
	| wahnof iseerdor	| 86161 |
	When the portal search for streets
	Then the user should not have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search a street when the text entered has less than three characters
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name  | pobox |
	| wa	| 86161 |
	When the portal search for streets
	Then the user should not have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search a street case insensitive
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name  | pobox |
	| BAHNHOF Isertor	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search a street when the name of the street contains numbers
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

Scenario: Fuzzi search a duplicated street should return just one street
	Given in the repository is stored the street
	| name              | pobox |
	| U12345 Isartor | 86165 |
	| U12345 Isartor | 86165 |
	And the user enters the following street
	| name  | pobox |
	| U1245	| 86165 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name           | pobox |
	| U12345 Isartor | 86165 |

# Synonym
Scenario: Search for a street using the word strase instead of the synonym strasse
	Given in the repository is stored the street
	| name				  | pobox |
	| Burgstr.            | 80331 |
	And the user enters the following street
	| name          | pobox |
	| burg strase	| 80331 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name      | pobox |
	| Burgstr.  | 80331 |

Scenario: Search for a street using the word strae instead of synonym strasse or straße
	Given in the repository is stored the street
	| name				  | pobox |
	| Burgstr.            | 80331 |
	And the user enters the following street
	| name          | pobox |
	| burg strae	| 80331 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name      | pobox |
	| Burgstr.  | 80331 |