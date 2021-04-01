Imports Flurl.Http
Imports Newtonsoft.Json

Public Class Form1

    Private Property SClient As New FlurlClient

    Private Async Function GetData(wallet As String, Optional pass As String = "nopass") As Task(Of PoolData)
        Try
            Dim url As String = "https://api.pool.rplant.xyz/api/poolminer2/sugarchain/" & wallet
            Dim resp = Await url.WithClient(SClient).PostJsonAsync(New With {Key .password = pass})
            Dim strResp = Await resp.GetStringAsync()
            Dim jResp = JsonConvert.DeserializeObject(Of PoolData)(strResp)
            Return jResp

        Catch ex As Exception

        End Try

        Return Nothing

    End Function

    Private Async Function ButtonCheck_ClickAsync(sender As Object, e As EventArgs) As Task Handles ButtonCheck.Click

        FlatStatusBar1.Text = "Status: Retrieving pool stats..."

        Dim data = Await GetData(TextWallet.Text)

        If data IsNot Nothing Then
            LabelWorkers.Text = data.Miner.Wc
            LabelPaid.Text = data.Miner.Paid
            LabelHashrate.Text = data.Miner.Hr
            LabelCurrBalance.Text = data.Miner.Balance
            FlatStatusBar1.Text = "Status: Stats recieved!"

        Else
            FlatStatusBar1.Text = "Status: Failed to retrieve stats."
        End If

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
    
        TextWallet.Text = My.Settings.Wallet
        TextPass.Text = My.Settings.Password

        Dim headers As New Dictionary(Of String, String) From {
            {"Connection", "keep-alive"},
            {"Accept", "application/json, text/javascript, */*; q=0.01"},
            {"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36"},
            {"Content-Type", "application/json"}
        }

        SClient.WithHeaders(headers)

    End Sub

    Private Sub FlatTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FlatTabControl1.SelectedIndexChanged
        My.Settings.Wallet = TextWallet.Text
        My.Settings.Password = TextPass.Text
        My.Settings.Save()
    End Sub

End Class