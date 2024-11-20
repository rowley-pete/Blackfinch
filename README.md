# Part 1 (took about 90 minutes)

Got carried away, once I'd started I needed to finish and I wrote the tests so I could be sure I'd hit brief.

Not happy with the result, used Chain of Responsibility pattern but I'm not fond of the nested handlers in constructors looks more complicated than I want it to be.

It works, so...

# Part 2 (took about 10 minutes)

Then decided to change from Chain of Responsibility to a Rules Design Pattern which the test help me do it short time to ensure the refactor was successful. (this part took about 10 minutes)

I prefer this pattern, need to ensure the rules are added to the rules collection in the correct order.