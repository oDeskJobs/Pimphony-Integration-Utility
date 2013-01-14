Imports Microsoft.Win32

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Minimized
        Dim isRelocate As Boolean = False
        Dim isSetting As Boolean = False
        Dim s() As String = System.Environment.GetCommandLineArgs()

        'Open Registry, create if it didn't exists
        OpenRegistry()
        LoadRegistryValue()

        'PIMPhony will send 4 argument. But VB.NET will insert *.exe as the first argument 
        If s.Length = 2 Then
            isrelocate = s(1).Equals("-relocate")
            If isRelocate Then
                'clear db
                If (Not AppKey Is Nothing) Then
                    AppKey.SetValue("DB Filename", "")
                End If
            End If

            isSetting = s(1).Equals("-setting")
            If isSetting Then
                SettingForm.ShowDialog()
                Me.Close()
                Exit Sub
            End If
        ElseIf s.Length < 5 Then
            MessageBox.Show("I am sorry, this application must be called by PIMphony")
            End
        End If

        'now handle the rest of the argument
        'only accept INT call if told to
        If s(4).Equals("INT") And Not isAcceptInternalCall Then
            End
        End If

        Dim callerNumber As String = s(1)
        Clipboard.SetText("101_" & callerNumber)

       

        If dbFileName = "" Then
            If Not isRelocate Then MessageBox.Show("Path to Database file not found in registry. Please specify it now" & vbCrLf & "You can change it later any time using the Configuration Window", Application.ProductName & " " & Application.ProductVersion)
            While Not System.IO.File.Exists(dbFileName)
                dbFileName = GetDbFilename()
            End While
        End If
        AppKey.SetValue("DB Filename", dbFileName)

        'check existence of that file name
        While Not System.IO.File.Exists(dbFileName)
            If Not isRelocate Then MessageBox.Show("The database file is not found!" & vbCrLf & "Please specify the correct database file", Application.ProductName & " " & Application.ProductVersion)
            dbFileName = GetDbFilename()
            AppKey.SetValue("DB Filename", dbFileName)
        End While
        AppKey.Close()

        'open access database
        If Not isRelocate Then openAccessForm()
        End
    End Sub
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Hide()
    End Sub
End Class
