namespace CalculatorUI;

partial class Calculator
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        CalculatorScreen = new System.Windows.Forms.Label();
        FormWithButtons = new System.Windows.Forms.TableLayoutPanel();
        Division = new System.Windows.Forms.Button();
        Zero = new System.Windows.Forms.Button();
        ChangeSign = new System.Windows.Forms.Button();
        Amount = new System.Windows.Forms.Button();
        Three = new System.Windows.Forms.Button();
        Two = new System.Windows.Forms.Button();
        One = new System.Windows.Forms.Button();
        Subtraction = new System.Windows.Forms.Button();
        Six = new System.Windows.Forms.Button();
        Five = new System.Windows.Forms.Button();
        Four = new System.Windows.Forms.Button();
        Multiply = new System.Windows.Forms.Button();
        Nine = new System.Windows.Forms.Button();
        Eight = new System.Windows.Forms.Button();
        Seven = new System.Windows.Forms.Button();
        Backspase = new System.Windows.Forms.Button();
        Clear = new System.Windows.Forms.Button();
        ClearElement = new System.Windows.Forms.Button();
        Empty = new System.Windows.Forms.Button();
        Equality = new System.Windows.Forms.Button();
        FormWithButtons.SuspendLayout();
        SuspendLayout();
        // 
        // CalculatorScreen
        // 
        CalculatorScreen.BackColor = System.Drawing.Color.SkyBlue;
        CalculatorScreen.Dock = System.Windows.Forms.DockStyle.Top;
        CalculatorScreen.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        CalculatorScreen.Location = new System.Drawing.Point(0, 0);
        CalculatorScreen.Name = "CalculatorScreen";
        CalculatorScreen.Size = new System.Drawing.Size(484, 65);
        CalculatorScreen.TabIndex = 0;
        CalculatorScreen.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // FormWithButtons
        // 
        FormWithButtons.BackColor = System.Drawing.Color.SkyBlue;
        FormWithButtons.ColumnCount = 4;
        FormWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        FormWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        FormWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        FormWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        FormWithButtons.Controls.Add(Division, 2, 4);
        FormWithButtons.Controls.Add(Zero, 1, 4);
        FormWithButtons.Controls.Add(ChangeSign, 0, 4);
        FormWithButtons.Controls.Add(Amount, 3, 3);
        FormWithButtons.Controls.Add(Three, 2, 3);
        FormWithButtons.Controls.Add(Two, 1, 3);
        FormWithButtons.Controls.Add(One, 0, 3);
        FormWithButtons.Controls.Add(Subtraction, 3, 2);
        FormWithButtons.Controls.Add(Six, 2, 2);
        FormWithButtons.Controls.Add(Five, 1, 2);
        FormWithButtons.Controls.Add(Four, 0, 2);
        FormWithButtons.Controls.Add(Multiply, 3, 1);
        FormWithButtons.Controls.Add(Nine, 2, 1);
        FormWithButtons.Controls.Add(Eight, 1, 1);
        FormWithButtons.Controls.Add(Seven, 0, 1);
        FormWithButtons.Controls.Add(Backspase, 3, 0);
        FormWithButtons.Controls.Add(Clear, 2, 0);
        FormWithButtons.Controls.Add(ClearElement, 1, 0);
        FormWithButtons.Controls.Add(Empty, 0, 0);
        FormWithButtons.Controls.Add(Equality, 3, 4);
        FormWithButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        FormWithButtons.Location = new System.Drawing.Point(0, 65);
        FormWithButtons.Name = "FormWithButtons";
        FormWithButtons.RowCount = 5;
        FormWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        FormWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        FormWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        FormWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        FormWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        FormWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        FormWithButtons.Size = new System.Drawing.Size(484, 596);
        FormWithButtons.TabIndex = 0;
        // 
        // Division
        // 
        Division.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Division.Dock = System.Windows.Forms.DockStyle.Fill;
        Division.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Division.FlatAppearance.BorderSize = 2;
        Division.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Division.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Division.Location = new System.Drawing.Point(245, 479);
        Division.Name = "Division";
        Division.Size = new System.Drawing.Size(115, 114);
        Division.TabIndex = 18;
        Division.Text = "/";
        Division.UseVisualStyleBackColor = false;
        // 
        // Zero
        // 
        Zero.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Zero.Dock = System.Windows.Forms.DockStyle.Fill;
        Zero.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Zero.FlatAppearance.BorderSize = 2;
        Zero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Zero.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Zero.Location = new System.Drawing.Point(124, 479);
        Zero.Name = "Zero";
        Zero.RightToLeft = System.Windows.Forms.RightToLeft.No;
        Zero.Size = new System.Drawing.Size(115, 114);
        Zero.TabIndex = 17;
        Zero.Text = "0";
        Zero.UseVisualStyleBackColor = false;
        // 
        // ChangeSign
        // 
        ChangeSign.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        ChangeSign.Dock = System.Windows.Forms.DockStyle.Fill;
        ChangeSign.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        ChangeSign.FlatAppearance.BorderSize = 2;
        ChangeSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        ChangeSign.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        ChangeSign.Location = new System.Drawing.Point(3, 479);
        ChangeSign.Name = "ChangeSign";
        ChangeSign.Size = new System.Drawing.Size(115, 114);
        ChangeSign.TabIndex = 16;
        ChangeSign.Text = "+/-";
        ChangeSign.UseVisualStyleBackColor = false;
        // 
        // Amount
        // 
        Amount.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Amount.Dock = System.Windows.Forms.DockStyle.Fill;
        Amount.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Amount.FlatAppearance.BorderSize = 2;
        Amount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Amount.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Amount.Location = new System.Drawing.Point(366, 360);
        Amount.Name = "Amount";
        Amount.Size = new System.Drawing.Size(115, 113);
        Amount.TabIndex = 15;
        Amount.Text = "+";
        Amount.UseVisualStyleBackColor = false;
        // 
        // Three
        // 
        Three.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Three.Dock = System.Windows.Forms.DockStyle.Fill;
        Three.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Three.FlatAppearance.BorderSize = 2;
        Three.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Three.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Three.Location = new System.Drawing.Point(245, 360);
        Three.Name = "Three";
        Three.Size = new System.Drawing.Size(115, 113);
        Three.TabIndex = 14;
        Three.Text = "3";
        Three.UseVisualStyleBackColor = false;
        // 
        // Two
        // 
        Two.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Two.Dock = System.Windows.Forms.DockStyle.Fill;
        Two.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Two.FlatAppearance.BorderSize = 2;
        Two.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Two.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Two.Location = new System.Drawing.Point(124, 360);
        Two.Name = "Two";
        Two.Size = new System.Drawing.Size(115, 113);
        Two.TabIndex = 13;
        Two.Text = "2";
        Two.UseVisualStyleBackColor = false;
        // 
        // One
        // 
        One.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        One.Dock = System.Windows.Forms.DockStyle.Fill;
        One.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        One.FlatAppearance.BorderSize = 2;
        One.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        One.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        One.Location = new System.Drawing.Point(3, 360);
        One.Name = "One";
        One.Size = new System.Drawing.Size(115, 113);
        One.TabIndex = 12;
        One.Text = "1";
        One.UseVisualStyleBackColor = false;
        // 
        // Subtraction
        // 
        Subtraction.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Subtraction.Dock = System.Windows.Forms.DockStyle.Fill;
        Subtraction.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Subtraction.FlatAppearance.BorderSize = 2;
        Subtraction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Subtraction.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Subtraction.Location = new System.Drawing.Point(366, 241);
        Subtraction.Name = "Subtraction";
        Subtraction.Size = new System.Drawing.Size(115, 113);
        Subtraction.TabIndex = 11;
        Subtraction.Text = "-";
        Subtraction.UseVisualStyleBackColor = false;
        // 
        // Six
        // 
        Six.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Six.Dock = System.Windows.Forms.DockStyle.Fill;
        Six.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Six.FlatAppearance.BorderSize = 2;
        Six.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Six.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Six.Location = new System.Drawing.Point(245, 241);
        Six.Name = "Six";
        Six.Size = new System.Drawing.Size(115, 113);
        Six.TabIndex = 10;
        Six.Text = "6";
        Six.UseVisualStyleBackColor = false;
        // 
        // Five
        // 
        Five.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Five.Dock = System.Windows.Forms.DockStyle.Fill;
        Five.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Five.FlatAppearance.BorderSize = 2;
        Five.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Five.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Five.Location = new System.Drawing.Point(124, 241);
        Five.Name = "Five";
        Five.Size = new System.Drawing.Size(115, 113);
        Five.TabIndex = 9;
        Five.Text = "5";
        Five.UseVisualStyleBackColor = false;
        // 
        // Four
        // 
        Four.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Four.Dock = System.Windows.Forms.DockStyle.Fill;
        Four.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Four.FlatAppearance.BorderSize = 2;
        Four.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Four.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Four.Location = new System.Drawing.Point(3, 241);
        Four.Name = "Four";
        Four.Size = new System.Drawing.Size(115, 113);
        Four.TabIndex = 8;
        Four.Text = "4";
        Four.UseVisualStyleBackColor = false;
        // 
        // Multiply
        // 
        Multiply.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Multiply.Dock = System.Windows.Forms.DockStyle.Fill;
        Multiply.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Multiply.FlatAppearance.BorderSize = 2;
        Multiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Multiply.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Multiply.Location = new System.Drawing.Point(366, 122);
        Multiply.Name = "Multiply";
        Multiply.Size = new System.Drawing.Size(115, 113);
        Multiply.TabIndex = 7;
        Multiply.Text = "*";
        Multiply.UseVisualStyleBackColor = false;
        // 
        // Nine
        // 
        Nine.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Nine.Dock = System.Windows.Forms.DockStyle.Fill;
        Nine.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Nine.FlatAppearance.BorderSize = 2;
        Nine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Nine.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Nine.Location = new System.Drawing.Point(245, 122);
        Nine.Name = "Nine";
        Nine.Size = new System.Drawing.Size(115, 113);
        Nine.TabIndex = 6;
        Nine.Text = "9";
        Nine.UseVisualStyleBackColor = false;
        // 
        // Eight
        // 
        Eight.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Eight.Dock = System.Windows.Forms.DockStyle.Fill;
        Eight.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Eight.FlatAppearance.BorderSize = 2;
        Eight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Eight.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Eight.Location = new System.Drawing.Point(124, 122);
        Eight.Name = "Eight";
        Eight.RightToLeft = System.Windows.Forms.RightToLeft.No;
        Eight.Size = new System.Drawing.Size(115, 113);
        Eight.TabIndex = 5;
        Eight.Text = "8";
        Eight.UseVisualStyleBackColor = false;
        // 
        // Seven
        // 
        Seven.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Seven.Dock = System.Windows.Forms.DockStyle.Fill;
        Seven.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Seven.FlatAppearance.BorderSize = 2;
        Seven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Seven.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Seven.Location = new System.Drawing.Point(3, 122);
        Seven.Name = "Seven";
        Seven.Size = new System.Drawing.Size(115, 113);
        Seven.TabIndex = 4;
        Seven.Text = "7";
        Seven.UseVisualStyleBackColor = false;
        // 
        // Backspase
        // 
        Backspase.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Backspase.Dock = System.Windows.Forms.DockStyle.Fill;
        Backspase.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Backspase.FlatAppearance.BorderSize = 2;
        Backspase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Backspase.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Backspase.Location = new System.Drawing.Point(366, 3);
        Backspase.Name = "Backspase";
        Backspase.Size = new System.Drawing.Size(115, 113);
        Backspase.TabIndex = 3;
        Backspase.Text = "⌫";
        Backspase.UseVisualStyleBackColor = false;
        // 
        // Clear
        // 
        Clear.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Clear.Dock = System.Windows.Forms.DockStyle.Fill;
        Clear.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Clear.FlatAppearance.BorderSize = 2;
        Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Clear.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        Clear.Location = new System.Drawing.Point(245, 3);
        Clear.Name = "Clear";
        Clear.Size = new System.Drawing.Size(115, 113);
        Clear.TabIndex = 2;
        Clear.Text = "C";
        Clear.UseVisualStyleBackColor = false;
        // 
        // ClearElement
        // 
        ClearElement.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        ClearElement.Dock = System.Windows.Forms.DockStyle.Fill;
        ClearElement.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Clear.FlatAppearance.BorderSize = 2;
        ClearElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        ClearElement.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold);
        ClearElement.Location = new System.Drawing.Point(124, 3);
        ClearElement.Name = "ClearElement";
        ClearElement.Size = new System.Drawing.Size(115, 113);
        ClearElement.TabIndex = 1;
        ClearElement.Text = "CE";
        ClearElement.UseVisualStyleBackColor = false;
        // 
        // Empty
        // 
        Empty.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)192)));
        Empty.Dock = System.Windows.Forms.DockStyle.Fill;
        Empty.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
        Empty.FlatAppearance.BorderSize = 2;
        Empty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Empty.Font = new System.Drawing.Font("Segoe UI", 9F);
        Empty.Location = new System.Drawing.Point(3, 3);
        Empty.Name = "Empty";
        Empty.Size = new System.Drawing.Size(115, 113);
        Empty.TabIndex = 0;
        Empty.UseVisualStyleBackColor = false;
        // 
        // Equality
        // 
        Equality.BackColor = System.Drawing.Color.LightCoral;
        Equality.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        Equality.Dock = System.Windows.Forms.DockStyle.Fill;
        Equality.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
        Equality.FlatAppearance.BorderSize = 2;
        Equality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        Equality.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        Equality.Location = new System.Drawing.Point(366, 479);
        Equality.Name = "Equality";
        Equality.Size = new System.Drawing.Size(115, 114);
        Equality.TabIndex = 19;
        Equality.Text = "=";
        Equality.UseVisualStyleBackColor = false;
        // 
        // Calculator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(484, 661);
        Controls.Add(FormWithButtons);
        Controls.Add(CalculatorScreen);
        MaximumSize = new System.Drawing.Size(500, 700);
        MinimumSize = new System.Drawing.Size(350, 400);
        Text = "Calculator";
        FormWithButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button Seven;
    private System.Windows.Forms.Button Eight;
    private System.Windows.Forms.Button Backspase;
    private System.Windows.Forms.Button Empty;
    private System.Windows.Forms.Button ClearElement;
    private System.Windows.Forms.Button Clear;
    private System.Windows.Forms.Button Nine;
    private System.Windows.Forms.Button Multiply;
    private System.Windows.Forms.Button Four;
    private System.Windows.Forms.Button Five;
    private System.Windows.Forms.Button Six;
    private System.Windows.Forms.Button Subtraction;
    private System.Windows.Forms.Button One;
    private System.Windows.Forms.Button Two;
    private System.Windows.Forms.Button Three;
    private System.Windows.Forms.Button Amount;
    private System.Windows.Forms.Button ChangeSign;
    private System.Windows.Forms.Button Zero;
    private System.Windows.Forms.Button Division;
    private System.Windows.Forms.Button Equality;

    private System.Windows.Forms.TableLayoutPanel FormWithButtons;

    private System.Windows.Forms.Label CalculatorScreen;

    #endregion
}