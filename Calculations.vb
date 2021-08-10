Public Class Calculations
    Private _mlevy As Decimal
    Private _itax As Decimal
    Private _budget As Decimal
    Private _salary As Decimal
    Private _super As Decimal
    Private _taxableInc As Decimal
    Private Const budgetExcess1 As Integer = 3572, budgetExcess2 As Integer = 19822, budgetExcess3 As Integer = 54232
    Private Const superPercent As Decimal = 0.095

    Public Sub CalcSalaryDetails(value As Decimal)

        Dim percentage As Decimal

        'Calculate Super Amount & Taxable Income (TI) Amount
        Super = (superPercent / (1 + superPercent)) * value
        TI = value - Super

        ' Calculate Income Tax based on Taxable Income (TI) Amount
        Select Case TI
            Case 0 To 18200
                IncomeTax = 0
            Case 18201 To 37000
                percentage = 19 / 100
                IncomeTax = (TI - 18200) * percentage
            Case 37001 To 87000
                percentage = 32.5 / 100
                IncomeTax = budgetExcess1 + ((TI - 37000) * percentage)
            Case 87001 To 180000
                percentage = 37 / 100
                IncomeTax = budgetExcess2 + ((TI - 87000) * percentage)
            Case Else
                percentage = 47 / 100
                IncomeTax = budgetExcess3 + ((TI - 180000) * percentage)
        End Select


        ' Deductions:
        ' Determine Medicare Levy based on Taxable Income (TI) Amount
        Select Case TI
            Case 21336 To 26668
                percentage = 10 / 100
                MedicareLevy = (TI - 21335) * percentage
            Case > 26668
                percentage = 2 / 100
                MedicareLevy = TI * percentage
            Case Else
                MedicareLevy = 0
        End Select

        ' Determine Budget Repair level based on Taxable Income (TI) Amount
        Select Case TI
            Case 0 To 180000
                BudgetLevy = 0
            Case Else
                percentage = 2 / 100
                BudgetLevy = (TI - 180000) * percentage
        End Select


    End Sub

    Public Property Salary As Decimal
        Set(value As Decimal)
            _salary = value
        End Set
        Get
            Return _salary
        End Get
    End Property

    Public Property MedicareLevy As Decimal
        Set(value As Decimal)
            _mlevy = value
        End Set
        Get
            Return _mlevy
        End Get
    End Property

    Public Property BudgetLevy As Decimal

        Set(value As Decimal)
            _budget = value
        End Set
        Get
            Return _budget
        End Get
    End Property
    Public Property TI As Decimal

        Set(value As Decimal)
            _taxableInc = value
        End Set
        Get
            Return _taxableInc
        End Get
    End Property

    Public Property IncomeTax As Decimal
        Set(value As Decimal)
            _itax = value
        End Set
        Get
            Return _itax
        End Get
    End Property

    Public Property Super As Decimal
        Set(value As Decimal)
            _super = value
        End Set
        Get
            Return _super
        End Get
    End Property


End Class
