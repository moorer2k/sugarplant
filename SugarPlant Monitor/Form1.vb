Imports System.IO
Imports System.Net
Imports Flurl.Http
Imports Newtonsoft.Json

Public Class Form1

    Private Property SClient As New FlurlClient

    Private Async Function GetData(wallet As String, Optional pass As String = "nopass") As Task(Of PoolData)

        Try
            Dim encoded = Base64Encode($"{wallet}|{pass}")

            Dim url As String = "https://pool.rplant.xyz/api2/poolminer2/sugarchain/" & wallet & "/" & encoded
            Dim str = Await url.WithClient(SClient).GetStreamAsync(completionOption:=Http.HttpCompletionOption.ResponseHeadersRead)

            Using reader = New StreamReader(str)

                Do While Not reader.EndOfStream
                    Dim sbdata = reader.ReadLine()
                    If sbdata <> "" Then
                        Dim sbjson = sbdata.Substring(6)
                        If sbjson.StartsWith("{" & Chr(34) & "miner") Then
                            Dim pData = JsonConvert.DeserializeObject(Of PoolData)(sbjson)
                            Return pData
                        End If
                    End If

                Loop

            End Using

        Catch ex As Exception

        End Try

        Return Nothing

    End Function
    Public Shared Function Base64Encode(ByVal plainText As String) As String
        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)
        Return System.Convert.ToBase64String(plainTextBytes)
    End Function

    Private Async Function ButtonCheck_ClickAsync(sender As Object, e As EventArgs) As Task Handles ButtonCheck.Click

        FlatStatusBar1.Text = "Status: Retrieving pool stats..."

        Dim threadGet As New Threading.Thread(Async Sub()

                                                  Dim data = Await GetData(TextWallet.Text)

                                                  If data IsNot Nothing Then
                                                      SetText(Me, LabelWorkers, data.Miner.Wc)
                                                      SetText(Me, LabelPaid, data.Miner.Paid)
                                                      SetText(Me, LabelHashrate, data.Miner.Hr)
                                                      SetText(Me, LabelCurrBalance, data.Miner.Balance)
                                                      SetText(Me, FlatStatusBar1, "Status: Stats recieved!")
                                                  Else
                                                      SetText(Me, FlatStatusBar1, "Status: Failed to retrieve stats.")
                                                  End If
                                              End Sub)

        threadGet.Start()

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ServicePointManager.Expect100Continue = True
        TextWallet.Text = My.Settings.Wallet
        TextPass.Text = My.Settings.Password

        Dim headers As New Dictionary(Of String, String) From {
            {"Connection", "keep-alive"},
            {"Accept", "text/event-stream"},
            {"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36"}
        }

        SClient.WithHeaders(headers)

    End Sub

    Private Sub FlatTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FlatTabControl1.SelectedIndexChanged
        My.Settings.Wallet = TextWallet.Text
        My.Settings.Password = TextPass.Text
        My.Settings.Save()
    End Sub

    Delegate Sub SetText_Delegate(Of T As {New, Control})([Form] As Form, [Control] As T, [Text] As String)
    Public Sub SetText(Of T As {New, Control})([Form] As Form, [Control] As T, [Text] As String)
        If [Control].InvokeRequired Then
            Dim MyDelegate As New SetText_Delegate(Of T)(AddressOf SetText)
            [Form].Invoke(MyDelegate, New Object() {[Form], [Control], [Text]})
        Else
            [Control].Text = [Text]
        End If
    End Sub

End Class
