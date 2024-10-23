# Unit testing with xUnit
Unit testing is a software testing technique where individual units or components of a program are tested to ensure that each one functions as expected. 
A unit typically refers to the smallest part of an application, such as a function, method, or class. 
Unit tests are usually written by developers to verify that each unit performs its function correctly in isolation. This is important because it allows developers to catch bugs early in the development process, before they make their way into the final product.

## Importance of Unit Testing
- **Early Detection of Bugs**: Unit tests help in identifying bugs early in the development cycle before they become complex and costly to fix.
- **Ensures Code Quality**: Writing unit tests forces developers to think about edge cases and proper handling of inputs, leading to better-designed and more robust code.
- **Reduces Future Maintenance Costs**: Tests serve as a safety net when making changes or refactoring code, ensuring that new code changes don’t break existing functionality.
- **Provides Documentation**: Unit tests act as documentation by showing how functions or modules are expected to behave with various inputs.
- **Facilitates Code Refactoring**: With unit tests in place, developers can confidently refactor code to improve structure without worrying about breaking existing features.

## Limitations or Drawbacks of Unit Testing
While unit testing is an important practice in software development, it has certain limitations and drawbacks that need to be understood:
- Does Not Catch All Bugs
- Time-Consuming to Write
- Can Give a False Sense of Security
- Limited to Small Units
- May Lead to Over-Engineering

## How Far to Go with Unit Testing
- Aim for High Code Coverage, But Don’t Obsess Over 100%
- Focus on Core Business Logic
- Test Edge Cases and Boundaries
- Balance Between Positive and Negative Tests
- Consider the Cost of Testing vs. Benefit
- Adopt TDD for Critical or Complex Features

> **Edge cases** in unit testing refer to situations where a program's behavior might be tested with inputs or conditions that are at the extreme ends of the range of possible values. These are scenarios that test the boundaries or limits of an application’s functionality. 
> Edge cases often involve: Minimum or Maximum Values, Empty Inputs, Boundary Values, Special Characters, Unusual or Unexpected Input etc.
> **Boundary conditions** in testing refer to the scenarios that test the behavior of a system at the edges of its defined input ranges.
> **Positive Tests**: Verify that your code behaves correctly with expected, valid inputs.
> **Negative Tests**: Ensure that your code handles invalid inputs, exceptions, and error cases gracefully.

## Test Method Naming Convention
A clear naming convention for test methods is crucial because it makes it easier to understand the purpose and expected behavior of each test.
Common naming convention consist of three parts:
1. The name of the method being tested.
2. The scenario under which it’s being tested.
3. The expected behaviour when the scenario is invoked.

Example : CalculateSquareRoot_NegativeNumber_ThrowsArgumentException()

## Test Attributes in xUnit
[Fact]
- **Purpose**: Marks a method as a unit test that should be executed by the xUnit test runner.
- **Usage**: Use this when you have a test method that doesn’t need parameters and represents a single test case.

[Theory]
- **Purpose**: Marks a method as a parameterized test that can be run with multiple sets of data.
- **Usage**: Use this when you want to run the same test logic with different inputs.

### Data Attributes for [Theory] in xUnit
[InlineData]
- **Purpose**: Provides specific values for a [Theory] test.
- **Usage**: Use when you have a few simple sets of data that you can write directly in the attribute.

[MemberData]
- **Purpose**: Supplies data to a [Theory] test from a property, method, or field.
- **Usage**: Use this when you need more complex or dynamic data that isn’t easily specified inline.

[ClassData]
- **Purpose**: Uses a class to provide data for a [Theory] test.
- **Usage**: Use this when you want to encapsulate data generation in a separate class. This is useful when you want to manage the data separately, potentially across multiple classes or assemblies.

### Fixture Attributes in xUnit
[Collection] and [CollectionDefinition]
- **Purpose**: Groups test classes that share a common setup or require shared context. Useful for tests that need to share resources or need to avoid running in parallel.

[Trait]
The [Trait] attribute allows you to add metadata to your tests. This metadata is often used to categorize or filter tests when running them.

[!NOTE]
>There are other Attributes which are not mention here.

## Moq and AAA

### Mocking
Mocking is a technique used in unit testing where you create fake versions of external dependencies or objects that your code interacts with. These fake versions, called mocks, simulate the behavior of real objects, allowing you to test your code in isolation without relying on the actual dependencies.

**Purpose**: The main purpose of mocking is to test a unit of code without needing to access real databases, services, or APIs, which can be slow, expensive, or unavailable during testing.


### AAA Pattern (Arrange, Act, Assert)
The AAA pattern is a common structure for organizing unit tests, making them easy to understand and follow. It stands for:
*Arrange*: Set up the initial state of your test, including creating necessary objects, mocks, and input data.
*Act*: Perform the action or behavior that you want to test.
*Assert*: Verify the outcome, checking if the result matches the expected behavior.

**Purpose**: This pattern ensures that unit tests are clear and logically structured, making it easy for others (or yourself later) to understand what is being tested and why.

## Is it best to write unit test before or after coding?
Unit tests can be written both before and after coding, depending on the development approach.

In Test-Driven Development (TDD), unit tests are written before writing the actual code. 
This process encourages developers to focus on the requirements and functionality from the start, ensuring that the code is designed to pass specific tests. 
It helps in clear, focused, and simpler design but requires that the requirements be well-understood before starting.

When following a more traditional development approach, unit tests are typically written after the code is developed. 
This method is often used when requirements are unclear or evolving, allowing developers to adjust the tests based on the finalized functionality. 
It can be more flexible when changes are frequent but might miss the early design benefits of TDD.