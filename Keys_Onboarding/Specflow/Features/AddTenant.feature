Feature: AddTenant
	

@mytag
Scenario: Add Tenant
	Given Go to property Owner Page
	And I Click add tenant by input proerty name
	When I fill all the form of each page : AddTenantDashboard,liabilitiesDetailsPage,summaryPage and I submit 
	Then the tenant is added
