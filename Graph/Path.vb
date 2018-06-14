Public Class Path(Of T)

    Private VerticiesValue As New List(Of Vertex(Of T))
    Public ReadOnly Property Verticies() As List(Of Vertex(Of T))
        Get
            Return VerticiesValue
        End Get
    End Property


    Sub New()

    End Sub


    Public Sub addVertex(value As Vertex(Of T))
        VerticiesValue.Add(value)
    End Sub


    Public Overrides Function toString() As String

        If VerticiesValue.Count = 0 Then
            Return "Κενό Μονοπάτι!"
        End If

        Dim s As String = ""

        For i = Verticies.Count - 1 To 0 Step -1
            s += Verticies.Count - i & " ) " & Verticies(i).Value.ToString()

            If i < Verticies.Count - 1 Then
                s += vbTab & " diff: " & Integer.Parse(Verticies(i).Value.ToString()) - Integer.Parse(Verticies(i + 1).Value.ToString())
            End If

            s += vbNewLine

        Next

        Return s
    End Function

    Public Function toList() As List(Of T)
        Dim lst As New List(Of T)

        For i = Verticies.Count - 1 To 0 Step -1
            lst.Add(Verticies(i).Value)
        Next

        Return lst
    End Function

End Class
