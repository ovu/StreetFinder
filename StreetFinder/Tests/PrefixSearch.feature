Feature: PrefixSearch
	In order to enter my address information
	As a user from an internet portal
	I want to be told suggestions about possible streets
	when the text I entered matches with the prefix of a street name

#Background: 
#	Given in the repository is stored the street
#	| name              | pobox |
#	| S-Bahnhof Isartor | 86161 |


Scenario: Search an street that matches with the prefix of a given street name
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name | pobox |
	| isar | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the name of the street when the street is compound
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name | pobox |
	| bahn isar | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the name of the street when the street is compound case Insensitive
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name | pobox |
	| Bahn Isar | 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the street is compound and searching in a different word position
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name | pobox |
	| Isar Bahn| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has more than one space
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the following street
	| name			| pobox |
	| Isar      Bahn| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has more than one space at the end
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the street "Isar        "  with the pobox "86161"
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has more than one space at the beginning
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the street "    Isar"  with the pobox "86161"
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has a minus at the end
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the street "Isar-"  with the pobox "86161"
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has a minus at the beginning
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
    And the user enters the street "-Isar"  with the pobox "86161"
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has several minus
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the street "Bahn-----Isar"  with the pobox "86161"
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |

Scenario: Search an street using the prefix of the street name when the searched street name has several minus and spaces
	Given in the repository is stored the street
	| name              | pobox |
	| S-Bahnhof Isartor | 86161 |
	And the user enters the street "Bahn-- -- -Isar"  with the pobox "86161"
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

Scenario: Search a duplicate street that matches with the prefix of a given street name
	Given in the repository is stored the street
	| name				  | pobox |
	| Saarbrücker | 86161 |
	| Saarbrücker | 86161 |
	And the user enters the following street
	| name        | pobox |
	| saarbrü	| 86161 |
	When the portal search for streets
	Then the user should have the following autocomplete suggestions
	| name                | pobox |
	| Saarbrücker | 86161 |
