Feature: BuyTwoProducts
	In order to understand the process of buying products
	As a performance_glitch_user
	I want to buy two products

@mytag
Scenario: test to buy two products
	Given I am logged in as a performance_glitch_user
	When I press addtocart button for two products
	And I select shopping cart link
	Then The Cart page is opened
	When I click checkout button
	And I fill the information Form
	And I click continue Button
	And I click Finish Button
	Then Sucessfull message is displayed


