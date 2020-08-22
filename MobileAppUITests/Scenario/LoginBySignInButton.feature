Feature: LoginBySigInButton

Scenario: User Login By Sign In Button
Given User is on  welcome View
When Click "Sign In" Button
Then Login Page displays
When User Entered Correct Credential
Then Main Page displays