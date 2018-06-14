Public NotInheritable Class AStar(Of T)


    Public Shared Function FindSortestPath(graph As Graph(Of T), start As Integer, goal As Integer) As Path(Of T)
        Dim frontier As New PriorityQueue(Of Vertex(Of T))
        Dim came_from As New Dictionary(Of Integer, Integer)
        Dim cost_so_far As New Dictionary(Of Integer, Integer)
        Dim new_cost As Integer
        Dim currentV As Vertex(Of T)
        Dim priority As Integer
        Dim proceed As Boolean = True

        frontier.add(0, graph.Verticies.Item(start))

        came_from.Add(start, -1)

        cost_so_far(start) = 0

        While Not frontier.isEmpty()
            currentV = frontier.pop()

            If currentV.ID = goal Then
                Exit While
            End If

            For Each nextV As Vertex(Of T) In currentV.Neighbors
                new_cost = cost_so_far(currentV.ID) + graph.Edges(New Tuple(Of Integer, Integer)(currentV.ID, nextV.ID)).Weight

                If Not cost_so_far.ContainsKey(nextV.ID) Then
                    cost_so_far.Add(nextV.ID, new_cost)
                    proceed = True
                Else
                    proceed = False
                End If

                If new_cost < cost_so_far(nextV.ID) Then
                    cost_so_far(nextV.ID) = new_cost
                    proceed = proceed Or True
                Else
                    proceed = proceed Or False
                End If

                If proceed Then

                    Dim goalValue, nextVertexValue, optimisticDistToGoal As Integer

                    If Not Integer.TryParse(graph.Verticies.Item(goal).Value.ToString(), goalValue) Then
                        goalValue = 0
                    End If

                    If Not Integer.TryParse(nextV.Value.ToString(), nextVertexValue) Then
                        nextVertexValue = 0
                    End If

                    optimisticDistToGoal = Math.Max(goalValue - nextVertexValue, 0)

                    priority = new_cost + optimisticDistToGoal
                    frontier.add(priority, nextV)
                    came_from.Add(nextV.ID, currentV.ID)
                End If
            Next
        End While


        Dim optimalPath As New Path(Of T)

        If came_from.Last.Key = goal Then

            Dim vID As Integer = came_from.Last.Key

            Do Until vID = -1
                optimalPath.addVertex(graph.Verticies(vID))
                vID = came_from(vID)
            Loop

        End If

        Return optimalPath

    End Function

End Class
