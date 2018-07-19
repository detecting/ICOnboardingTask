Feature: CreateNewProperty


@mytag
Scenario: Check if the owner can Create New Property
	Given I navigate to propertyOwner Page
	And Click Add New Property button
	When I Fill all the forms of Property Details page, Finance details page and  tenant Details Page and click Save button
	Then A new property should be created
