Public Class Graph(Of T)

    Private VerticiesValue As New Dictionary(Of Integer, Vertex(Of T))
    Public ReadOnly Property Verticies() As Dictionary(Of Integer, Vertex(Of T))
        Get
            Return VerticiesValue
        End Get
    End Property

    Private EdgesValue As New Dictionary(Of Tuple(Of Integer, Integer), Edge)
    Public ReadOnly Property Edges() As Dictionary(Of Tuple(Of Integer, Integer), Edge)
        Get
            Return EdgesValue
        End Get
    End Property

    Public Sub addVertex(value As T)
        VerticiesValue.Add(VerticiesValue.Count, New Vertex(Of T)(VerticiesValue.Count, value))
    End Sub

    Public Sub addEdge(vertexIDOne As Integer, VertexIdTwo As Integer, weight As Integer)
        EdgesValue.Add(New Tuple(Of Integer, Integer)(vertexIDOne, VertexIdTwo), New Edge(vertexIDOne, VertexIdTwo, weight))
        VerticiesValue(vertexIDOne).Neighbors.Add(VerticiesValue(VertexIdTwo))
    End Sub

    Public Function WeightBetween(vertexIDOne As Integer, VertexIdTwo As Integer) As Integer

        Try
            Return Edges(New Tuple(Of Integer, Integer)(vertexIDOne, VertexIdTwo)).Weight
        Catch ex As Exception
            Return Integer.MaxValue
        End Try

    End Function

    Public Function FindSortestPath(startID As Integer, endID As Integer) As List(Of T)

        Dim optimalSolution As Path(Of T) = AStar(Of T).FindSortestPath(Me, startID, endID)

        'MsgBox(optimalSolution.toString())

        Return optimalSolution.toList

    End Function

    Public Sub Save(ByVal fileName As String)

        ' Create XmlWriterSettings.
        Dim settings As System.Xml.XmlWriterSettings = New System.Xml.XmlWriterSettings()
        settings.Indent = True

        ' Create XmlWriter.
        Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(fileName, settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("Graph") ' Root.
            writer.WriteAttributeString("Verticies", Me.Verticies.Count)
            writer.WriteAttributeString("Edges", Me.Edges.Count)

            writer.WriteStartElement("Verticies") ' Root.


            For Each vertex As Vertex(Of T) In Me.VerticiesValue.Values
                writer.WriteStartElement("vertex")
                writer.WriteElementString("ID", vertex.ID)
                writer.WriteElementString("Value", vertex.Value.ToString())
                writer.WriteEndElement()

            Next
            writer.WriteEndElement()

            writer.WriteStartElement("Edges") ' Root.
            For Each edge As Edge In Me.Edges.Values
                writer.WriteStartElement("edge")
                writer.WriteElementString("IDOne", Verticies(edge.IDOne).ID)
                writer.WriteElementString("IDOne", Verticies(edge.IDTwo).ID)
                writer.WriteElementString("Weight", edge.Weight)
                writer.WriteEndElement()

            Next
            writer.WriteEndElement()

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using

    End Sub

    Public Function getAllVerticesValues() As List(Of T)

        Dim alist As New List(Of T)

        For Each vertex As Vertex(Of T) In Me.VerticiesValue.Values
            alist.Add(vertex.Value)
        Next

        Return alist
    End Function

End Class
