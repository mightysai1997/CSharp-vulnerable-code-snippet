string userInput = Request.Params["userInput"];

// This code is vulnerable to code injection because it does not properly validate the user input.
// An attacker could send malicious code in the userInput parameter, which would then be executed by the server.

int number;

try
{
    number = int.Parse(userInput);
}
catch (Exception e)
{
    // The user input is not a valid number.
    return;
}

// Do something with the number.
