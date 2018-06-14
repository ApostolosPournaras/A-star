Public Class Edge

    Private IDOneValue As Integer
    Public ReadOnly Property IDOne() As Integer
        Get
            Return IDOneValue
        End Get
    End Property

    Private IDTwoValue As Integer
    Public ReadOnly Property IDTwo() As Integer
        Get
            Return IDTwoValue
        End Get
    End Property

    Private WeightValue As Integer
    Public ReadOnly Property Weight() As Integer
        Get
            Return WeightValue
        End Get
    End Property

    Sub New(vertexIDOne As Integer, vertexIDTwo As Integer, weight As Integer)
        Me.IDOneValue = vertexIDOne
        Me.IDTwoValue = vertexIDTwo
        Me.WeightValue = weight
    End Sub

End Class
