
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Partial Class Default3
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    ' This method is used to convert datatable to json string
    Public Function ConvertDataTabletoString() As String
        Dim dt As New DataTable()
        Dim conn As SqlConnection = New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SvsMaps;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        Dim ds As New DataTable
        Dim sql As New SqlCommand("SELECT * FROM GoogleMap")
        Dim da As New SqlDataAdapter(sql)
        da.Fill(dt)

        conn.Open()
        Dim sdr As SqlDataReader = sql.ExecuteReader
        While sdr.Read = True
        End While
        conn.Close()

        '    Using con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SvsMaps;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        '        Using cmd As New SqlCommand("SELECT * FROM GoogleMap", con)
        '            If con.State = ConnectionState.Open Then
        '                con.Close()
        '            End If
        '            con.Open()
        '            Dim da As New SqlDataAdapter(cmd)
        '            da.Fill(dt)
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            Row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                Row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(Row)
        Next
        Return serializer.Serialize(rows)
        '        End Using
        '    End Using
    End Function
End Class