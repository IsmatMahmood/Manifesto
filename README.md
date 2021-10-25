Manifesto Full-Stack Technical Challenge

- To start please clone repo to local directory.

* Task 1 - HTML and CSS
- To see poster navigate to ".\Manifesto\Poster\index.html" and open with Chrome.



* Task 2 - ATM CLI application
1- Open ATM-Machine.sln project file located at ".\Manifesto\ATM-Machine\ATM-Machine.sln".
2- The input test data is stored in a txt file located at ".\Manifesto\ATM-Machine\TestData.txt". This file is read in the code in Program.cs on line 15.
	- The correct filepath will need to be updated here before the project can be run. 
3- Build project will result in a console opening up with the example data outputs shown. 

Unit Tests - unfortunately I was not able to implement any unit tests because I could get my test project to reference my main project correctly.



* Task 3 - Writing a user story

	As a user
		• given I have entered the correct pin,
		• when I attempt to check my balance,
		• then the balance should display without warning or error.

	As a user
		• given I have entered the correct pin and my account is in credit and there is money in the ATM,
		• when I attempt to withdraw an amount up to or less than the amount of my balance and withdrawl limit combined,
		• then the withdrawal should complete without error or warning. 
