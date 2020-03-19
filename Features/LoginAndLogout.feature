Feature: LoginAndLogout
	In order to avoid silly mistakes
	As different users
	I want to Login and Logout to check web app

Scenario Outline: Login and Logout of the web portal
	Given I am on the Login Page
	When I fill the form with <username> and <password>
	And I press Login button
	Then I Should Be Correctly Logged In
	When I Select Logout Option
	Then I Should Be Logged Out
	
Examples: 
| username | password | 
|standard_user|secret_sauce|
|problem_user|secret_sauce|
|performance_glitch_user|secret_sauce|


Scenario: Login with locked_out_user
	Given I am on the Login Page
	When I fill the form with <username> and <password>
	And I press Login button
	Then An Error Message is displayed	

Examples: 
| username | password | 
|locked_out_user|secret_sauce|