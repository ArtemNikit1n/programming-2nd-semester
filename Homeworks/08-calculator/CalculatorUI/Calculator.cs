namespace CalculatorUI;

using CalculatorCore;

public partial class Calculator : Form
{
    private readonly CalculatorEngine calculator;

    public Calculator()
    {
        this.InitializeComponent();
        this.calculator = new CalculatorEngine();
        this.calculator.DisplayChanged += (_, _) => this.UpdateDisplay();

        this.SetupEventHandlers();
        this.UpdateDisplay();
    }

    private void SetupEventHandlers()
    {
        this.Zero.Click += this.ButtonClick;
        this.One.Click += this.ButtonClick;
        this.Two.Click += this.ButtonClick;
        this.Three.Click += this.ButtonClick;
        this.Four.Click += this.ButtonClick;
        this.Five.Click += this.ButtonClick;
        this.Six.Click += this.ButtonClick;
        this.Seven.Click += this.ButtonClick;
        this.Eight.Click += this.ButtonClick;
        this.Nine.Click += this.ButtonClick;

        this.Division.Click += this.ButtonClick;
        this.Multiply.Click += this.ButtonClick;
        this.Subtraction.Click += this.ButtonClick;
        this.Amount.Click += this.ButtonClick;
        this.Equality.Click += this.ButtonClick;

        this.Clear.Click += this.SpecialButtonClick;
        this.ClearElement.Click += this.SpecialButtonClick;
        this.Backspase.Click += this.SpecialButtonClick;
        this.ChangeSign.Click += this.SpecialButtonClick;
    }

    private void UpdateDisplay()
    {
        this.CalculatorScreen.Text = this.calculator.DisplayValue;
    }

    private void ButtonClick(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        this.calculator.ProcessInput(button.Text);
        this.UpdateDisplay();
    }

    private void SpecialButtonClick(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            this.calculator.ProcessSpecialInput(button.Text);
        }
    }
}