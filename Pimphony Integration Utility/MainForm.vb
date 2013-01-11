Imports Microsoft.Office.Interop
Imports Microsoft.Win32

Public Class MainForm
    Declare Function SetForegroundWindow Lib "User32" _
   (ByVal hWnd As Long) As Long
    Declare Function IsIconic Lib "User32" _
      (ByVal hWnd As Long) As Long
    Declare Function ShowWindow Lib "User32" _
      (ByVal hWnd As Long, ByVal nCmdShow As Long) As Long
    Const SW_NORMAL = 1     'Show window in normal size
    Const SW_MINIMIZE = 2   'Show window minimized
    Const SW_MAXIMIZE = 3   'Show window maximized
    Const SW_SHOW = 9       'Show window without changing window size

    Dim objAccess As Object 'module-level declaration

    Dim RegKey As String = "SOFTWARE\\Swdev Bali\\PIMPhony Integration Utility\\1.0"
    Dim dbFileName As String = Nothing

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Minimized
        Dim s() As String = System.Environment.GetCommandLineArgs()

        'PIMPhony will send 4 argument. But VB.NET will insert *.exe as the first argument 
        If s.Length < 5 Then
            MessageBox.Show("I am sorry, this application must be called by PIMphony")
            End
        End If
        Dim callerNumber As String = s(1)
        Clipboard.SetText("101_" & callerNumber)

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

            'open access database
            openAccessForm()
            End
        End If
    End Sub
    Sub ShowAccess(instance As Object, size As Integer)
        Dim hWnd As Long, temp As Long
        On Error Resume Next
        instance.Visible = True
        On Error GoTo 0 'turn off error handler
        hWnd = instance.hWndAccessApp
        temp = SetForegroundWindow(hWnd)

    End Sub
    Sub openAccessForm()

        'On Error Resume Next 'temporary error handling
        Try
            objAccess = GetObject(, "Access.Application")
        Catch ex As Exception
            objAccess = CreateObject("Access.Application")
        End Try
        'Dim oAccess = New Access.ApplicationClass()
        'oAccess.DoCmd.Save(Access.AcObjectType.acForm, "NewCall")
        ShowAccess(instance:=objAccess, size:=SW_SHOW)

        With objAccess
            If .DBEngine.Workspaces(0).Databases.Count = 0 Then
                .OpenCurrentDatabase(filepath:=dbFileName)
            Else
                .CloseCurrentDatabase()
                .OpenCurrentDatabase(filepath:=dbFileName)
            End If
            .DoCmd.OpenForm(FormName:="NewCall", View:=Access.AcFormView.acNormal)

        End With
    End Sub
    Private Function GetDbFilename() As String
        Dim result As String
        OpenFileDialog.Title = "Select the database file"
        OpenFileDialog.FileName = ""
        OpenFileDialog.ShowDialog()
        result = OpenFileDialog.FileName
        GetDbFilename = result
    End Function

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Hide()
    End Sub
End Class
