Public Class Form1
    Dim WithEvents w_timer As New Timer
    Dim w_tick As Integer
    Dim check As Integer = 1
    Public Row = 1
    Public Col = 1
    Public Bo = (Row + 1) * (Col + 1)
    Public BB = 30
    Public BOT(Row, Col) As Button
    Public Open As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Open = 0
        Me.Width = 300
        Me.Height = 300
        For i = 0 To Row
            For j = 0 To Col
                BOT(i, j) = New Button
                Me.Controls.Add(BOT(i, j))
                BOT(i, j).Image = My.Resources.ResourceManager.GetObject("box")
                BOT(i, j).Width = BB
                BOT(i, j).Height = BB
                BOT(i, j).BackgroundImageLayout = ImageLayout.Stretch
                BOT(i, j).Top = 35 + i * BB
                BOT(i, j).Left = 10 + j * BB
                BOT(i, j).Tag = 0
                AddHandler BOT(i, j).MouseUp, AddressOf ABC_MouseUp

            Next
        Next
        Randomize()
        Getnumber(Bo)
    End Sub

    Private Sub ABC_MouseUp(sender As Object, e As MouseEventArgs)
        Dim B = CType(sender, Button)

        If B.Tag = check Then
            B.Image = Nothing
            B.Text = B.Tag
            B.Enabled = False
            check += 1
        Else
            B.Image = Nothing
            B.Enabled = False
            B.Text = B.Tag
            wait(1)
            B.Text = Nothing
            B.Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
            B.Enabled = True
        End If

    End Sub

    Sub Getnumber(BoomNumber As Integer)
        Dim r As New Random
        Dim Number, No1, No2, temp1, temp2 As Integer
        Dim n As Integer = 1

        For i = 0 To Row
            For j = 0 To Col
                BOT(i, j).Tag = n
                n += 1
            Next
        Next

        For i = 0 To Row
            For j = 0 To Col
                Number = r.Next((Row + 1) * (Col + 1) - 1)
                No1 = Number \ (Row + 1)
                No2 = Number Mod (Col + 1)

                temp1 = BOT(i, j).Tag
                temp2 = BOT(No1, No2).Tag
                BOT(i, j).Tag = temp2
                BOT(No1, No2).Tag = temp1
            Next
        Next

    End Sub

    Private Sub wait(ByVal second As Integer)
        w_tick = 0
        w_timer.Interval = second * 1000
        w_timer.Enabled = True
        Do Until w_tick >= 1
            Application.DoEvents()
        Loop
        w_timer.Enabled = False
        w_timer.Interval = 1
    End Sub

    Private Sub w_timer_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles w_timer.Tick
        w_tick += 1
    End Sub


End Class
