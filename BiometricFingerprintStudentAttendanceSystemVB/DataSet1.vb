Partial Class DataSet1
    Partial Public Class AttendanceDataTable
        Private Sub AttendanceDataTable_AttendanceRowChanging(sender As Object, e As AttendanceRowChangeEvent) Handles Me.AttendanceRowChanging

        End Sub

        Private Sub AttendanceDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.StudentIdColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

Namespace DataSet1TableAdapters

    Partial Public Class AttendanceTableAdapter
    End Class
End Namespace
