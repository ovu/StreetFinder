Feature: TermSeach
	In order to enter my address information
	As a user from an internet portal
	I want to be told suggestions about possible streets
	When the terms I entered match with the name of the streets

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

# Shorts terms
Scenario: Search a street when the term is short
	Given in the repository is stored the street
	| name    | pobox |
	| An Ufer | 86111 |
	And the user enters the following street
	| name | pobox |
	| an | 86111 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name    | pobox |
	| An Ufer | 86111 |

Scenario: Search a street has a one word when the term is short
	Given in the repository is stored the street
	| name    | pobox |
	| Nr. | 82067 |
	And the user enters the following street
	| name | pobox |
	| Nr | 82067 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name    | pobox |
	| Nr. | 82067 |

# Combined terms
Scenario: Search combining terms should find the street
	Given in the repository is stored the street
	| name                           | pobox |
	| Johann-Baptist-Zimmermann-Str. | 82069 |
	And the user enters the following street
	| name | pobox |
	| JohannBaptist | 82069 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name    | pobox |
	| Johann-Baptist-Zimmermann-Str. | 82069 |