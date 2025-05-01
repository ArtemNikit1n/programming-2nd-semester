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
        label1 = new System.Windows.Forms.Label();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        Equality = new System.Windows.Forms.Button();
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
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(-8, -1);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(816, 153);
        label1.TabIndex = 0;
        label1.Text = "label1";
        label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel1.Controls.Add(Equality, 3, 4);
        tableLayoutPanel1.Controls.Add(Division, 2, 4);
        tableLayoutPanel1.Controls.Add(Zero, 1, 4);
        tableLayoutPanel1.Controls.Add(ChangeSign, 0, 4);
        tableLayoutPanel1.Controls.Add(Amount, 3, 3);
        tableLayoutPanel1.Controls.Add(Three, 2, 3);
        tableLayoutPanel1.Controls.Add(Two, 1, 3);
        tableLayoutPanel1.Controls.Add(One, 0, 3);
        tableLayoutPanel1.Controls.Add(Subtraction, 3, 2);
        tableLayoutPanel1.Controls.Add(Six, 2, 2);
        tableLayoutPanel1.Controls.Add(Five, 1, 2);
        tableLayoutPanel1.Controls.Add(Four, 0, 2);
        tableLayoutPanel1.Controls.Add(Multiply, 3, 1);
        tableLayoutPanel1.Controls.Add(Nine, 2, 1);
        tableLayoutPanel1.Controls.Add(Eight, 1, 1);
        tableLayoutPanel1.Controls.Add(Seven, 0, 1);
        tableLayoutPanel1.Controls.Add(Backspase, 3, 0);
        tableLayoutPanel1.Controls.Add(Clear, 2, 0);
        tableLayoutPanel1.Controls.Add(ClearElement, 1, 0);
        tableLayoutPanel1.Controls.Add(Empty, 0, 0);
        tableLayoutPanel1.Location = new System.Drawing.Point(-8, 155);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 5;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.Size = new System.Drawing.Size(816, 303);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // Equality
        // 
        Equality.Location = new System.Drawing.Point(615, 243);
        Equality.Name = "Equality";
        Equality.Size = new System.Drawing.Size(198, 54);
        Equality.TabIndex = 19;
        Equality.Text = "=";
        Equality.UseVisualStyleBackColor = true;
        // 
        // Division
        // 
        Division.Location = new System.Drawing.Point(411, 243);
        Division.Name = "Division";
        Division.Size = new System.Drawing.Size(198, 54);
        Division.TabIndex = 18;
        Division.Text = "/";
        Division.UseVisualStyleBackColor = true;
        // 
        // Zero
        // 
        Zero.Location = new System.Drawing.Point(207, 243);
        Zero.Name = "Zero";
        Zero.RightToLeft = System.Windows.Forms.RightToLeft.No;
        Zero.Size = new System.Drawing.Size(198, 54);
        Zero.TabIndex = 17;
        Zero.Text = "0";
        Zero.UseVisualStyleBackColor = true;
        // 
        // ChangeSign
        // 
        ChangeSign.Location = new System.Drawing.Point(3, 243);
        ChangeSign.Name = "ChangeSign";
        ChangeSign.Size = new System.Drawing.Size(198, 54);
        ChangeSign.TabIndex = 16;
        ChangeSign.Text = "+/-";
        ChangeSign.UseVisualStyleBackColor = true;
        // 
        // Amount
        // 
        Amount.Location = new System.Drawing.Point(615, 183);
        Amount.Name = "Amount";
        Amount.Size = new System.Drawing.Size(198, 54);
        Amount.TabIndex = 15;
        Amount.Text = "+";
        Amount.UseVisualStyleBackColor = true;
        // 
        // Three
        // 
        Three.Location = new System.Drawing.Point(411, 183);
        Three.Name = "Three";
        Three.Size = new System.Drawing.Size(198, 54);
        Three.TabIndex = 14;
        Three.Text = "3";
        Three.UseVisualStyleBackColor = true;
        // 
        // Two
        // 
        Two.Location = new System.Drawing.Point(207, 183);
        Two.Name = "Two";
        Two.Size = new System.Drawing.Size(198, 54);
        Two.TabIndex = 13;
        Two.Text = "2";
        Two.UseVisualStyleBackColor = true;
        // 
        // One
        // 
        One.Location = new System.Drawing.Point(3, 183);
        One.Name = "One";
        One.Size = new System.Drawing.Size(198, 54);
        One.TabIndex = 12;
        One.Text = "1";
        One.UseVisualStyleBackColor = true;
        // 
        // Subtraction
        // 
        Subtraction.Location = new System.Drawing.Point(615, 123);
        Subtraction.Name = "Subtraction";
        Subtraction.Size = new System.Drawing.Size(198, 54);
        Subtraction.TabIndex = 11;
        Subtraction.Text = "-";
        Subtraction.UseVisualStyleBackColor = true;
        // 
        // Six
        // 
        Six.Location = new System.Drawing.Point(411, 123);
        Six.Name = "Six";
        Six.Size = new System.Drawing.Size(198, 54);
        Six.TabIndex = 10;
        Six.Text = "6";
        Six.UseVisualStyleBackColor = true;
        // 
        // Five
        // 
        Five.Location = new System.Drawing.Point(207, 123);
        Five.Name = "Five";
        Five.Size = new System.Drawing.Size(198, 54);
        Five.TabIndex = 9;
        Five.Text = "5";
        Five.UseVisualStyleBackColor = true;
        // 
        // Four
        // 
        Four.Location = new System.Drawing.Point(3, 123);
        Four.Name = "Four";
        Four.Size = new System.Drawing.Size(198, 54);
        Four.TabIndex = 8;
        Four.Text = "4";
        Four.UseVisualStyleBackColor = true;
        // 
        // Multiply
        // 
        Multiply.Location = new System.Drawing.Point(615, 63);
        Multiply.Name = "Multiply";
        Multiply.Size = new System.Drawing.Size(198, 54);
        Multiply.TabIndex = 7;
        Multiply.Text = "*";
        Multiply.UseVisualStyleBackColor = true;
        // 
        // Nine
        // 
        Nine.Location = new System.Drawing.Point(411, 63);
        Nine.Name = "Nine";
        Nine.Size = new System.Drawing.Size(198, 54);
        Nine.TabIndex = 6;
        Nine.Text = "9";
        Nine.UseVisualStyleBackColor = true;
        // 
        // Eight
        // 
        Eight.Location = new System.Drawing.Point(207, 63);
        Eight.Name = "Eight";
        Eight.RightToLeft = System.Windows.Forms.RightToLeft.No;
        Eight.Size = new System.Drawing.Size(198, 54);
        Eight.TabIndex = 5;
        Eight.Text = "8";
        Eight.UseVisualStyleBackColor = true;
        // 
        // Seven
        // 
        Seven.Location = new System.Drawing.Point(3, 63);
        Seven.Name = "Seven";
        Seven.Size = new System.Drawing.Size(198, 54);
        Seven.TabIndex = 4;
        Seven.Text = "7";
        Seven.UseVisualStyleBackColor = true;
        // 
        // Backspase
        // 
        Backspase.Location = new System.Drawing.Point(615, 3);
        Backspase.Name = "Backspase";
        Backspase.Size = new System.Drawing.Size(198, 54);
        Backspase.TabIndex = 3;
        Backspase.Text = "⌫";
        Backspase.UseVisualStyleBackColor = true;
        // 
        // Clear
        // 
        Clear.Location = new System.Drawing.Point(411, 3);
        Clear.Name = "Clear";
        Clear.Size = new System.Drawing.Size(198, 54);
        Clear.TabIndex = 2;
        Clear.Text = "C";
        Clear.UseVisualStyleBackColor = true;
        // 
        // ClearElement
        // 
        ClearElement.Location = new System.Drawing.Point(207, 3);
        ClearElement.Name = "ClearElement";
        ClearElement.Size = new System.Drawing.Size(198, 54);
        ClearElement.TabIndex = 1;
        ClearElement.Text = "CE";
        ClearElement.UseVisualStyleBackColor = true;
        // 
        // Empty
        // 
        Empty.Location = new System.Drawing.Point(3, 3);
        Empty.Name = "Empty";
        Empty.Size = new System.Drawing.Size(198, 54);
        Empty.TabIndex = 0;
        Empty.UseVisualStyleBackColor = true;
        // 
        // Calculator
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(label1);
        Text = "Calculator";
        tableLayoutPanel1.ResumeLayout(false);
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

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.Label label1;

    #endregion
}