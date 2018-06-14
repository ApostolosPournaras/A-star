Public Class Vertex(Of T)

    Private IDValue As Integer
    Public ReadOnly Property ID() As Integer
        Get
            Return IDValue
        End Get
    End Property

    Private ValueValue As T
    Public ReadOnly Property Value() As T
        Get
            Return ValueValue
        End Get
    End Property

    Private NeighborsValue As New List(Of Vertex(Of T))
    Public ReadOnly Property Neighbors() As List(Of Vertex(Of T))
        Get
            Return NeighborsValue
        End Get
    End Property


    Sub New(id As Integer, value As T)
        Me.IDValue = id
        Me.ValueValue = value
    End Sub


End Class
