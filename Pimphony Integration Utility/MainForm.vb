Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Public Class MainForm
    Dim RegKey As String = "SOFTWARE\\Swdev Bali\\PIMPhony Integration Utility\\1.0"
    Dim dbFileName As String = Nothing
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim s() As String = System.Environment.GetCommandLineArgs()

        'PIMPhony will send 4 argument. But VB.NET will insert *.exe as the first argument 
        If s.Length < 5 Then
            MessageBox.Show("I am sorry, this application must be called by Pimphony")
            End
        End If
        txtArgument1.Text = s(1)
        txtArgument2.Text = s(2)
        txtArgument3.Text = s(3)
        txtArgument4.Text = s(4)

        'Open Registry 
        Dim AppKey As RegistryKey
        AppKey = Registry.CurrentUser.OpenSubKey(RegKey, True)
        If AppKey Is Nothing Then
            AppKey = Registry.CurrentUser.CreateSubKey(RegKey)
        End If

        'try to get db path

        If (Not AppKey Is Nothing) Then
            dbFileName = AppKey.GetValue("DB Filename")
            If dbFileName Is Nothing Then
                MessageBox.Show("Path to Database file not found in registry. Please specify it now" & vbCrLf & "You can change it later any time using the Configuration Window", Application.ProductName & " " & Application.ProductVersion)
                dbFileName = GetDbFilename()
            End If
            AppKey.SetValue("DB Filename", dbFileName)

            'check existence of that file name
            While Not System.IO.File.Exists(dbFileName)
                MessageBox.Show("The database file is not found!" & vbCrLf & "Please specify the correct database file", Application.ProductName & " " & Application.ProductVersion)
                dbFileName = GetDbFilename()
                AppKey.SetValue("DB Filename", dbFileName)
            End While
            AppKey.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub btnOpenForm_Click(sender As Object, e As EventArgs) Handles btnOpenForm.Click
        Dim oAccess As Access.Application

        ' Start a new instance of Access for Automation:
        oAccess = New Access.ApplicationClass()
        oAccess.Visible = True
        ' Open a database in exclusive mode:
        oAccess.OpenCurrentDatabase(filepath:=dbFileName, Exclusive:=False)

        ' Show a form named Employees:
        oAccess.DoCmd.OpenForm(FormName:="NewCall", View:=Access.AcFormView.acNormal)
    End Sub

    Private Function GetDbFilename() As String
        Dim result As String
        OpenFileDialog.Title = "Select the database file"
        OpenFileDialog.FileName = ""
        OpenFileDialog.ShowDialog()
        result = OpenFileDialog.FileName
        GetDbFilename = result
    End Function

End Class
