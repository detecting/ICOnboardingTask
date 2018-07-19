Feature: AddTenant
	

@mytag
Scenario: Check if the Owner can Add Tenant successfully
	Given I navigate to property Owner Page
	And I Click add tenant by input proerty name
	When I fill all the form of each page : AddTenantDashboard,liabilitiesDetailsPage,summaryPage and I submit 
	Then the tenant is added
