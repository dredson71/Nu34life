Feature: StateCreate
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: CreateState
	Given I have specified patient selected
	And I register all the information needed
	When I press create state
	Then It should be redirected to the state index page
