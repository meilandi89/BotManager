Imports System.Xml

Namespace UserInterface

    Public Class Test
        Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create("C:\Users\Chancey\Desktop\Maclone\user.xml", New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)
            Dim oldTable As DataTable = ds.Tables(0) 
            Dim newTable As New DataTable

            newTable.Columns.Add("Field Name")
	        newTable.Columns.Add("Value")

            For i As Integer = 0 To oldTable.Columns.Count - 1
	            Dim newRow As DataRow = newTable.NewRow()

	            newRow(0) = oldTable.Columns(i).Caption
	            For j As Integer = 0 To oldTable.Rows.Count - 1
		            newRow(j + 1) = oldTable.Rows(j)(i)
	            Next
	            newTable.Rows.Add(newRow)
            Next

            DataGridView1.DataSource = newTable
        End Sub
    End Class
End NameSpace