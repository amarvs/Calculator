using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace XamarinPrismMyCalculator.ViewModels
{
    public class MainCalculatorViewModel : ViewModelBase
    {
        public MainCalculatorViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "My Calculator";
        }

        private string _expression = string.Empty;
        public string Expression
        {
            get { return _expression; }
            set { SetProperty(ref _expression, value); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private DelegateCommand<string> _keyPressed;
        public DelegateCommand<string> KeyPressed =>
            _keyPressed ?? (_keyPressed = new DelegateCommand<string>(ExecuteKeyPressed));

        void ExecuteKeyPressed(string key)
        {
            ErrorMessage = string.Empty;
            switch (key)
            {
                case "AC":
                    Expression = string.Empty;
                    break;
                case "+/-":
                    ErrorMessage = "Not Supported yet!";
                    break;
                case "=":
                    EvaluateExpression();
                    break;
                default:
                    Expression += key;
                    break;
            }

        }

        private void EvaluateExpression()
        {
            try
            {
                Expression = Convert.ToDouble(new DataTable().Compute(Expression, null)).ToString();
            }
            catch
            {
                ErrorMessage = "Error";
            }
        }
    }
}
