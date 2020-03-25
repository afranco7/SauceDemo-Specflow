Feature: Validate the Checkout your information fields
	In order to test required fields
	As a performance_glitch_user
	I want to Validate the Checkout your information fields

@mytag
Scenario: Validate fieldName is required Error Message
	Given I am on checkout-step-one page with items added on cart
	When I press continue button without information on <field>
	Then Error message is shown
Examples: 
| field            |
| First Name |
| Last Name |
| Postal Code |
