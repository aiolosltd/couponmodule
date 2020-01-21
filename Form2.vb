Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.ComponentModel

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddatagrid1()
    End Sub
    Private Sub loaddatagrid1()
        DataGridView1.Columns.Clear()

        Dim mysqlcon As New MySqlConnection(cs2)
        Dim dt As New DataTable
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource

        Try
            mysqlcon.Open()
            command = New MySqlCommand("SELECT * FROM tbproduct", mysqlcon)

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.AutoGenerateColumns = False

            Dim index As Integer
            index = DataGridView1.Columns.Add("ID", "ID")
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "ProductID_"

            index = DataGridView1.Columns.Add("Product", "Product")
            DataGridView1.Columns(index).DataPropertyName = "Productname_"

            index = DataGridView1.Columns.Add("Category", "Category")
            '  DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "Category_"

            index = DataGridView1.Columns.Add("Price", "Price")
            'DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "Price_"




            sda.SelectCommand = command
            sda.Fill(dt)
            bsource.DataSource = dt
            DataGridView1.DataSource = bsource
            sda.Update(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        save()
    End Sub

    Private Sub save()
        mysqlcon = New MySqlConnection
        mysqlcon.ConnectionString = cs2

        If TextBox1.Text = Trim(String.Empty) Then
            TextBox1.Focus()
            Exit Sub
        ElseIf ComboBox1.Text = Trim(String.Empty) Then
            ComboBox1.Focus()
            Exit Sub
        ElseIf TextBox2.Text = Trim(String.Empty) Then
            TextBox2.Focus()
            Exit Sub
        Else
            If Label4.Text = "0" Then

                mysqlcon.Open()

                Dim command As New MySqlCommand
                command.Connection = mysqlcon
                command.CommandText = "INSERT INTO tbproduct (productname_,category_,price_) Values
                                    ('" & Trim(TextBox1.Text) & "',
                                     '" & Trim(ComboBox1.Text) & "',
                                     '" & Trim(TextBox2.Text) & "')"

                command.ExecuteReader()
                mysqlcon.Close()
                loaddatagrid1()
            Else

                mysqlcon.Open()
                Dim command As New MySqlCommand
                command.Connection = mysqlcon
                command.CommandText = "Update tbproduct Set productname_='" & Trim(TextBox1.Text) & "',category_='" & Trim(ComboBox1.Text) & "',price_= '" & Trim(TextBox2.Text) & "' where productID_ ='" & Label4.Text & "'"
                command.ExecuteReader()
                mysqlcon.Close()
                loaddatagrid1()
            End If
        End If
    End Sub
    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()
        Form1.Enabled = True
        Form1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        loaddatagrid1()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.TextBox1.Text = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentRow.Index).Value
        Me.TextBox2.Text = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentRow.Index).Value
        Me.ComboBox1.Text = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentRow.Index).Value
        Label4.Text = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentRow.Index).Value
    End Sub
End Class