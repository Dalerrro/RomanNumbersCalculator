using Avalonia.Controls;
using Avalonia.VisualTree;
using RomanNumbersCalculator.Views;
using UITestsRomanNumbersCalculator;

namespace UITestsForRomanNumbersCalculator
{
    public class UnitTests
    {
        private static Dictionary<string, Button> GetConrolsButtons(MainWindow mainWindow) => new Dictionary<string, Button>
            {
                { "I", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I") },
                { "V", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "V") },
                { "X", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "X") },
                { "L", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "L") },
                { "C", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "C") },
                { "D", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "D") },
                { "M", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "M") },
                { "CE", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "CE") },
                { "+", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Plus") },
                { "-", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Minus") },
                { "*", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Multiply") },
                { "/", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Divide") },
                { "=", mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Equal") },
            };
        private static string getErrorMessage(string expectedValue, string resultValue) => String.Format("Expected '{0}', however got '{1}'", expectedValue, resultValue);
        [Fact]
        public async void TestPlus()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            await Task.Delay(100);

            string actual;
            string expected;

            var resultTextBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(textBox => textBox.Name == "ResultTextBox");
            Dictionary<string, Button> buttons = GetConrolsButtons(mainWindow);

            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["+"].Command.Execute(buttons["+"].CommandParameter);
            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "VI";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["+"].Command.Execute(buttons["+"].CommandParameter);
            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "X";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async void TestMinus()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            await Task.Delay(100);

            string actual;
            string expected;

            var resultTextBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(textBox => textBox.Name == "ResultTextBox");
            Dictionary<string, Button> buttons = GetConrolsButtons(mainWindow);

            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["-"].Command.Execute(buttons["-"].CommandParameter);
            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "IV";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["-"].Command.Execute(buttons["+"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "I";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void TestMultiply()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            await Task.Delay(100);

            string actual;
            string expected;

            var resultTextBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(textBox => textBox.Name == "ResultTextBox");
            Dictionary<string, Button> buttons = GetConrolsButtons(mainWindow);

            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["*"].Command.Execute(buttons["*"].CommandParameter);
            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "XXV";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["*"].Command.Execute(buttons["*"].CommandParameter);
            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["I"].Command.Execute(buttons["I"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "MM";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void TestDivide()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            await Task.Delay(100);

            string actual;
            string expected;

            var resultTextBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(textBox => textBox.Name == "ResultTextBox");
            Dictionary<string, Button> buttons = GetConrolsButtons(mainWindow);

            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["/"].Command.Execute(buttons["/"].CommandParameter);
            buttons["V"].Command.Execute(buttons["V"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "I";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["/"].Command.Execute(buttons["/"].CommandParameter);
            buttons["C"].Command.Execute(buttons["C"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "X";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void TestGetError()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            await Task.Delay(100);

            string actual;
            string expected;

            var resultTextBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(textBox => textBox.Name == "ResultTextBox");
            Dictionary<string, Button> buttons = GetConrolsButtons(mainWindow);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["+"].Command.Execute(buttons["+"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "#ERROR";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["-"].Command.Execute(buttons["+"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "#ERROR";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["*"].Command.Execute(buttons["*"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "#ERROR";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);

            buttons["X"].Command.Execute(buttons["X"].CommandParameter);
            buttons["/"].Command.Execute(buttons["/"].CommandParameter);
            buttons["M"].Command.Execute(buttons["M"].CommandParameter);
            buttons["="].Command.Execute(buttons["="].CommandParameter);

            await Task.Delay(50);
            actual = resultTextBox.Text;
            expected = "#ERROR";
            buttons["CE"].Command.Execute(buttons["CE"].CommandParameter);
            Assert.Equal(expected, actual);
        }
    };
}
