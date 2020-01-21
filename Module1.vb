Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Module Module1
    Public cs2 As String = "server= localhost" &
                       ";userid= root" &
                       ";password= " & ";port=3306" &
                       ";database=fbwcoupon"
    Public mysqlcon As MySqlConnection = Nothing
    Public command As MySqlCommand
End Module
