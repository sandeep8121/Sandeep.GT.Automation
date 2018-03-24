Feature: GT Login, Navigation and Search
	

Scenario Outline: GameTwist Registration
	Given A browser is on Game twist HomePage
	And   User clicks on Register and completes the Registration with "<Email>" and "<NickName>"
	And   User navigates through the pages Slots,Bingo,Casino and Poker
	When  A search is done for a "<Game>" and confirmed that a right game is selected
	Then  User changes the "<Language>" and does a successful logout	 

	@Dev
	Examples:
	   | Email                           | NickName | Language | Game |
	   |  xyz                            | wqfdg2   | Deutsch  | slot |	


Scenario Outline: GameTwist Login,Navigation,Search and Logout
	Given A browser is on Game twist HomePage
	And   User does a successful Login with "<NickName>"
	And   User navigates through the pages Slots,Bingo,Casino and Poker
	When  A search is done for a "<Game>" and confirmed that a right game is selected
	Then  User changes the "<Language>" and does a successful logout	 

	@Dev
	Examples:
	   | Game | NickName    | Language |
	   | slot | sande45     | Deutsch  |	

