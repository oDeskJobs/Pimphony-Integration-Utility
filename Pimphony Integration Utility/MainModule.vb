Module MainModule
    Public Sub main()
        Dim s() As String = System.Environment.GetCommandLineArgs()

        For Each v As String In s
            Console.WriteLine(v)
        Next

    End Sub
End Module
