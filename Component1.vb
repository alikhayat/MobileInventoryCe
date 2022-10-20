
Public Class Component1

    Private Sub StatusTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusTimer.Tick
        Try
            If TimeSynced <> "OLD" Or TimeSynced <> String.Empty Then
                TimeSynced = CDate(TimeSynced).ToShortTimeString
            End If
        Catch ex As Exception

        End Try
        Try
            StatusBar1.Text = String.Format("{0} | User: {1} | Last Sync:{2} | {3}", Store, Login.UserId, TimeSynced, DateTime.Now.ToShortTimeString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StatusBar1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBar1.ParentChanged

    End Sub
End Class
