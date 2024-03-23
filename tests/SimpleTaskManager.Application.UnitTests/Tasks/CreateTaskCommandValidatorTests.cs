using FluentAssertions;
using FluentValidation.Results;
using SimpleTaskManager.Application.Tasks.CreateTask;
using SimpleTaskManager.Domain.Tasks;

namespace SimpleTaskManager.Application.UnitTests.Tasks;

public class CreateTaskCommandValidatorTests
{
    private readonly CreateTaskCommandValidator _sut = new();

    [Fact]
    public void Validates_ValidCommand_Successfully()
    {
        // Arrange
        var command = new CreateTaskCommand(
            "Valid Title",
            "Valid description",
            TaskPriority.Low,
            DateTime.UtcNow);

        // Act
        ValidationResult result = _sut.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("sh")]
    [InlineData("khywsxzwwoifookcteabugqncvqaetijmkutwqjaitdknveieahudxhqbqxyzpqgzhnqlcwcdzlpwnodorcnuramzhwavhpublbczhkttpunidohyafbqapdytgmrcuieqpukjptcjqvtjctoihvzfbwbdjrwuvafghqcbmjxgdjmmytdjgvkyzbvdhuvxsjcumifcxjmybldfgeyeirokcelmjijkmsmtdyfdtjrjzvpeuouxytdhxtdloyyvdty")]

    public void Validates_InvalidTitleLength_Fails(string title)
    {
        // Arrange
        var command = new CreateTaskCommand(
            title,
            "Valid description",
            TaskPriority.Low,
            DateTime.UtcNow);

        // Act
        ValidationResult result = _sut.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
