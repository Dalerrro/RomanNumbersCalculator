using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;
using RomanNumbersCalculator.Models;


namespace RomanNumbersCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string currentOperationStringRepresentation = "";
        private string currentNumberStringRepresentation = "";
        private Stack<RomanNumberExtend> stackRomanNumbers = new Stack<RomanNumberExtend>();

        public string CurrentNumberStringRepresentation
        {
            get => currentNumberStringRepresentation;
            set
            {
                this.RaiseAndSetIfChanged(ref currentNumberStringRepresentation, value);
            }
        }
        public ReactiveCommand<string, Unit> AddNumber { get; }
        public ReactiveCommand<Unit, Unit> PlusCommand { get; }
        public ReactiveCommand<Unit, Unit> SubCommand { get; }
        public ReactiveCommand<Unit, Unit> MulCommand { get; }
        public ReactiveCommand<Unit, Unit> DivCommand { get; }
        public ReactiveCommand<Unit, Unit> CalculateCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetCommand { get; }

        public MainWindowViewModel()
        {
            AddNumber = ReactiveCommand.Create<string>(str =>
            {
                if (currentNumberStringRepresentation == "#ERROR")
                {
                    return;
                }

                if (currentOperationStringRepresentation == "=")
                {
                    Clear();
                }

                CurrentNumberStringRepresentation += str;
            });

            ResetCommand = ReactiveCommand.Create(() => Clear());
            PlusCommand = ReactiveCommand.Create(() => calculateNumberByOperationType("+"));
            SubCommand = ReactiveCommand.Create(() => calculateNumberByOperationType("-"));
            MulCommand = ReactiveCommand.Create(() => calculateNumberByOperationType("*"));
            DivCommand = ReactiveCommand.Create(() => calculateNumberByOperationType("/"));

            CalculateCommand = ReactiveCommand.Create(() =>
            {
                if (stackRomanNumbers.Count != 1
                    || currentNumberStringRepresentation == ""
                    || currentNumberStringRepresentation == "#ERROR")
                {
                    return;
                }

                try
                {
                    RomanNumberExtend newNumber = new(currentNumberStringRepresentation);

                    switch (currentOperationStringRepresentation)
                    {
                        case "+":
                            stackRomanNumbers.Push(stackRomanNumbers.Pop() + newNumber);
                            break;
                        case "-":
                            stackRomanNumbers.Push(stackRomanNumbers.Pop() - newNumber);
                            break;
                        case "*":
                            stackRomanNumbers.Push(stackRomanNumbers.Pop() * newNumber);
                            break;
                        case "/":
                            stackRomanNumbers.Push(stackRomanNumbers.Pop() / newNumber);
                            break;
                        default:
                            break;
                    }
                    currentOperationStringRepresentation = "=";
                    CurrentNumberStringRepresentation = stackRomanNumbers.Peek().ToString();
                }
                catch (RomanNumberException exception)
                {
                    CurrentNumberStringRepresentation = exception.Message;
                }
            });
        }

        private void Clear()
        {
            CurrentNumberStringRepresentation = "";
            currentOperationStringRepresentation = "";
            stackRomanNumbers.Clear();
        }

        private bool IsCalculationRequired(string operationSymbol)
        {
            if (currentNumberStringRepresentation == "#ERROR")
            {
                return false;
            }

            if (currentNumberStringRepresentation == "")
            {
                if(currentOperationStringRepresentation != "") currentOperationStringRepresentation = operationSymbol;
                return false;
            }

            if (currentOperationStringRepresentation == "=")
            {
                currentOperationStringRepresentation = operationSymbol;
                CurrentNumberStringRepresentation = "";
                return false;
            }

            return true;
        }

        private void calculateNumberByOperationType(string operationSymbol)
        {
            if (!IsCalculationRequired(operationSymbol))
            {
                return;
            }

            try
            {
                switch (currentOperationStringRepresentation)
                {
                    case "":
                        {
                            currentOperationStringRepresentation = operationSymbol;
                            RomanNumberExtend newNumber = new(currentNumberStringRepresentation);
                            stackRomanNumbers.Push(newNumber);
                            CurrentNumberStringRepresentation = "";
                            break;
                        }

                    default:
                        {
                            RomanNumberExtend newNumber = new(currentNumberStringRepresentation);
                            switch (currentOperationStringRepresentation)
                            {
                                case "+":
                                    stackRomanNumbers.Push(stackRomanNumbers.Pop() + newNumber);
                                    break;
                                case "-":
                                    stackRomanNumbers.Push(stackRomanNumbers.Pop() - newNumber);
                                    break;
                                case "*":
                                    stackRomanNumbers.Push(stackRomanNumbers.Pop() * newNumber);
                                    break;
                                case "/":
                                    stackRomanNumbers.Push(stackRomanNumbers.Pop() / newNumber);
                                    break;
                                default:
                                    break;
                            }
                            currentOperationStringRepresentation = operationSymbol;
                            CurrentNumberStringRepresentation = "";
                            break;
                        }
                }
            }
            catch (RomanNumberException exception)
            {
                CurrentNumberStringRepresentation = exception.Message;
            }
        }
    }
}