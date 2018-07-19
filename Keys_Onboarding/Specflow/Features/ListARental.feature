Feature: List A Rental


@mytag
Scenario: Check if the Owner can List A Rental
	Given I navigate to the property Owner Page
	And I click List Rental
	When I fill the detail of ListRental Page and Click Save And Accept List Rental
	Then The Rental should be listed
