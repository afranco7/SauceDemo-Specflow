Feature: AddAndRemoveItemsFromCart
	In order to test add and remove items functionality
	As a performance_glitch_user
	I want to add and then remove an item from the cart

@mytag
Scenario: Add and remove item from cart
	Given I am logged in as a performance_glitch_user
	When I press add to cart button for <item>	
	Then the item is correctly added
	When I press remove button for item added
	Then the items is correctly removed
	
Examples: 
| item            |
| Sauce Labs Onesie |
| Sauce Labs Bike Light |
