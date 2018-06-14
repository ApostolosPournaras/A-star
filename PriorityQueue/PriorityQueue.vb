Public Class PriorityQueue(Of T)

    ' The items and priorities.
    Private Items As New List(Of Tuple(Of Integer, T))

    ' Return the number of items in the queue.
    Public ReadOnly Property Count() As Integer
        Get
            Return Items.Count
        End Get
    End Property

    ' Add an item to the queue.
    Public Sub add(priority As Integer, value As T)
        Items.Add(New Tuple(Of Integer, T)(priority, value))
        Items.Sort(Function(x, y) x.Item1.CompareTo(y.Item1))
    End Sub

    ' Remove the item with the largest priority from the queue.
    Public Function pop() As T

        If Items.Count > 0 Then

            Dim value As T = Items.Last.Item2

            ' Remove the item from the lists.
            Items.RemoveAt(Items.Count - 1)

            ' Return the corresponding item.
            Return value
        Else
            'Throw New Exception("PriorityQueue is EMPTY")
        End If

    End Function

    Public Function isEmpty() As Boolean
        Return (Items.Count = 0)
    End Function

    Public Overrides Function ToString() As String

        If Items.Count > 0 Then
            Dim s As String = "Priority" & vbTab & "Value" & vbNewLine

            For Each item In Items
                s += item.Item1.ToString() & vbTab & item.Item2.ToString() & vbNewLine
            Next

            Return s
        Else
            Return "PriorityQueue is EMPTY"
        End If
    End Function


End Class