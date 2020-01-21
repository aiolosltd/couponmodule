Imports MySql.Data.MySqlClient

Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddatagrid2()
    End Sub
    Private Sub loaddatagrid2()
        DataGridView2.Columns.Clear()

        Dim mysqlcon As New MySqlConnection(cs2)
        Dim dt As New DataTable
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource

        Try
            mysqlcon.Open()
            command = New MySqlCommand("SELECT * FROM tbcoupon", mysqlcon)

            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            DataGridView2.AutoGenerateColumns = False

            Dim index As Integer
            index = DataGridView2.Columns.Add("ID", "ID")
            DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            DataGridView2.Columns(0).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "ID"

            index = DataGridView2.Columns.Add("Coupon", "Coupon")
            DataGridView2.Columns(1).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Couponname_"

            index = DataGridView2.Columns.Add("Description", "Description")
            DataGridView2.Columns(2).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Desc_"

            index = DataGridView2.Columns.Add("Discount", "Discount")
            DataGridView2.Columns(3).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Discountvalue_"

            index = DataGridView2.Columns.Add("Minimum", "Minimum")
            DataGridView2.Columns(4).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Referencevalue_"

            index = DataGridView2.Columns.Add("Coupon Type", "Coupon Type")
            DataGridView2.Columns(5).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Type"

            index = DataGridView2.Columns.Add("Bundle Reference", "Bundle Reference")
            DataGridView2.Columns(6).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Bundlebase_"

            index = DataGridView2.Columns.Add("Bundle Value", "Bundle Value")
            DataGridView2.Columns(7).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "BBValue_"

            index = DataGridView2.Columns.Add("Bundle Promo Item", "Bundle Promo Item")
            DataGridView2.Columns(8).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Bundlepromo_"

            index = DataGridView2.Columns.Add("Bundle Promo Qty", "Bundle Promo Qty")
            DataGridView2.Columns(9).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "BPValue_"

            index = DataGridView2.Columns.Add("Effective", "Effective")
            DataGridView2.Columns(10).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Effectivedate"

            index = DataGridView2.Columns.Add("Expiry", "Expiry")
            DataGridView2.Columns(11).Visible = True
            DataGridView2.Columns(index).DataPropertyName = "Expirydate"

            sda.SelectCommand = command
            sda.Fill(dt)
            bsource.DataSource = dt
            DataGridView2.DataSource = bsource
            sda.Update(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Enabled = True
        Form1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Form1.DataGridView2.RowCount < 2 Then
                MsgBox("Cannot apply coupon, no product found!", vbInformation)
                Exit Sub
            ElseIf Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString = "Percentage" Then
                MsgBox("Coupon is " & Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value)
                couponpercentage()
                Exit Sub

            ElseIf Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString = "Fix-1" Then
                MsgBox("Coupon is " & Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value)
                couponfix1()
                Exit Sub
            ElseIf Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString = "Fix-2" Then
                MsgBox("Coupon is " & Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value)
                couponfix2()
                Exit Sub
            ElseIf Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString = "Bundle-1(Fix)" Then
                MsgBox("Coupon is " & Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value)
                couponbundle1()
                Exit Sub
            ElseIf Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString = "Bundle-2(Fix)" Then
                MsgBox("Coupon is " & Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value)
                Exit Sub
            ElseIf Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString = "Bundle-3(%)" Then
                MsgBox("Coupon is " & Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value)
                couponbundle3()
                Exit Sub
            End If


        Catch ex As Exception

        End Try


    End Sub
    Private Sub couponpercentage()
        Dim total As Integer = 0
        Dim tax As String = Me.DataGridView2.Item(3, Me.DataGridView2.CurrentRow.Index).Value.ToString

        For index As Integer = 0 To DataGridView2.RowCount - 1
            total += Convert.ToInt32(Form1.DataGridView2.Rows(index).Cells(3).Value)
            Form1.Label9.Text = Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString
            Form1.Label10.Text = total * ("0." & Val(tax))
            Form1.Label14.Text = total - Val(Form1.Label10.Text)
        Next
    End Sub

    Private Sub couponfix1()
        Dim total As Integer = 0
        Dim tax As String = Me.DataGridView2.Item(3, Me.DataGridView2.CurrentRow.Index).Value.ToString

        For index As Integer = 0 To DataGridView2.RowCount - 1
            total += Convert.ToInt32(Form1.DataGridView2.Rows(index).Cells(3).Value)
            Form1.Label9.Text = Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString
            Form1.Label10.Text = tax
            Form1.Label14.Text = total - Val(Form1.Label10.Text)
        Next
    End Sub

    Private Sub couponfix2()
        Dim total As Integer = 0
        Dim tax As String = Me.DataGridView2.Item(3, Me.DataGridView2.CurrentRow.Index).Value.ToString

        For index As Integer = 0 To DataGridView2.RowCount - 1
            total += Convert.ToInt32(Form1.DataGridView2.Rows(index).Cells(3).Value)
            Form1.Label9.Text = Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString
            If CInt(Form1.Label8.Text) < CInt(Me.DataGridView2.Item(4, Me.DataGridView2.CurrentRow.Index).Value) Then
                MsgBox(Form1.Label8.Text & " " & CInt(Me.DataGridView2.Item(4, Me.DataGridView2.CurrentRow.Index).Value))
                Exit Sub
            Else
                Form1.Label10.Text = tax
                Form1.Label14.Text = Val(Form1.Label8.Text) - Val(tax)
            End If
        Next
    End Sub

    Private Sub couponbundle1()

        For index As Integer = 0 To DataGridView2.RowCount - 1


            Form1.Label9.Text = Me.DataGridView2.Item(5, Me.DataGridView2.CurrentRow.Index).Value.ToString
            If Form1.DataGridView2.Rows(index).Cells(0).Value.ToString.Contains(Me.DataGridView2.Item(6, Me.DataGridView2.CurrentRow.Index).Value.ToString) = True Then
                MsgBox(Form1.DataGridView2.Rows(index).Cells(0).Value.ToString & " " & Me.DataGridView2.Item(6, Me.DataGridView2.CurrentRow.Index).Value.ToString)
                MessageBox.Show("Data Exist!")

                Dim count = (From row As DataGridViewRow In Form1.DataGridView2.Rows
                             Where row.Cells("ID").Value = "1" And row.Cells("ID").Value IsNot DBNull.Value
                             Select row.Cells("ID").Value).Count()
                Exit Sub


                If Me.DataGridView2.Item(3, Me.DataGridView2.CurrentRow.Index).Value.ToString = Trim(String.Empty) Then
                    Form1.Label10.Text = "FREE"
                End If
            End If

        Next

    End Sub

    Private Sub couponbundle3()
        Dim count = (From row As DataGridViewRow In Form1.DataGridView2.Rows
                     Where row.Cells("ID").Value = Me.DataGridView2.Item(6, Me.DataGridView2.CurrentRow.Index).Value.ToString And row.Cells("ID").Value IsNot DBNull.Value
                     Select row.Cells("ID").Value).Count()

        For index As Integer = 0 To DataGridView2.RowCount - 1
            If Form1.DataGridView2.Rows(index).Cells(0).Value.ToString.Contains(Me.DataGridView2.Item(6, Me.DataGridView2.CurrentRow.Index).Value.ToString) = True Then





            End If
            If count = 2 Then
                Form1.Label10.Text = count
                MsgBox("MET TRUE")
            End If
        Next


    End Sub

End Class