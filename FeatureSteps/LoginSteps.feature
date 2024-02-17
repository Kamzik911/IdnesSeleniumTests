Feature: UserLogin

User login successfuly

@UserLogin
Scenario: User login success
	Given User go to login page
	And User set valid email
	And User click on continue button
	And User set valid password
	When User click on login button
	Then User should by able to login