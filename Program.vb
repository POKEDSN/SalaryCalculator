Imports System

Module Program

    Sub Main()

        Dim item As New Calculations()
        Dim freq As String = Menu(item)

        item.CalcSalaryDetails(item.Salary)

        Dim deductions As Decimal = item.MedicareLevy + item.BudgetLevy + item.IncomeTax
        Dim netIncome As Decimal = item.Salary - item.Super - Math.Ceiling(deductions)

        Console.WriteLine("Gross Package: {0}", item.Salary)
        Console.WriteLine("Super: {0:C2}" + vbCrLf, item.Super)
        Console.WriteLine("Taxable income: {0:C2}" + vbCrLf, item.TI)
        Console.WriteLine("Deductions:")
        Console.WriteLine("Medicare Levy: {0:C2}", Math.Ceiling(item.MedicareLevy))
        Console.WriteLine("Budget Repair Levy: {0:C2}", Math.Ceiling(item.BudgetLevy))
        Console.WriteLine("Income Tax: {0:C2}" + vbCrLf, Math.Round(item.IncomeTax))
        Console.WriteLine("Net income: {0:C2}", netIncome)
        Select Case freq
            Case "Week"
                netIncome /= 52
            Case "Fortnight"
                netIncome /= 26
            Case "Month"
                netIncome /= 12
        End Select

        Dim PayAmount As String = "Pay packet = " + netIncome.ToString("C") + " per " + freq
        Console.WriteLine(PayAmount + vbCrLf + vbCrLf + "Press any key to end...")
        Console.ReadKey()


    End Sub
    Private Function Menu(myItem As Calculations) As String

        Dim valid As Boolean = False

        Do While Not valid
            Console.Write("Enter your salary package amount: $")
            Try
                myItem.Salary = Console.ReadLine.Trim
                valid = True

            Catch ex As InvalidCastException
                Console.WriteLine("Salary must be numeric only")
                Exit Try
            Catch ex As Exception
                Console.WriteLine(ex.Message + " : please enter a valid salary amount.")
                Exit Try
            End Try
        Loop
        valid = False

        Dim MessageFreq As String = "Enter your pay frequency (W for weekly, F for Fortnightly, M for Monthly): "
        Dim Frequency As String = ""
        Console.Write(MessageFreq)

        Do While Not valid
            valid = True
            Frequency = Console.ReadLine.Trim.ToUpper
            Select Case Frequency
                Case "W"
                    Frequency = "Week"
                Case "M"
                    Frequency = "Month"
                Case "F"
                    Frequency = "Fortnight"
                Case Else
                    valid = False
                    Console.Write(MessageFreq)
            End Select

        Loop

        Console.WriteLine(vbCrLf + "Calculating salary details...." + vbCrLf)
        Return Frequency

    End Function

End Module
