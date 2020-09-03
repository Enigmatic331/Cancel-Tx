Imports Nethereum.Hex.HexTypes
Imports Nethereum.Web3
Imports Nethereum.Hex.HexConvertors.Extensions.HexByteConvertorExtensions
Imports Nethereum.Signer.EthereumMessageSigner
Imports Nethereum.Util
Imports Nethereum.HdWallet
Imports NBitcoin
Imports Nethereum.Hex.HexConvertors.Extensions
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions


Public Class MainForm
    Private Async Sub testContract()

        Dim privateKey As New Nethereum.Signer.EthECKey(TextBox1.Text)
        Dim nonce As Integer = TextBox2.Text
        Dim gasPrice = TextBox3.Text
        Dim account = New Nethereum.Web3.Accounts.Account(privateKey)

        Dim iweb3 = New Web3(account, "")


        Dim signer = New Nethereum.Signer.TransactionSigner
        Dim signedTx = signer.SignTransaction(account.PrivateKey, account.Address, 0, New System.Numerics.BigInteger(nonce), System.Numerics.BigInteger.Parse(gasPrice), New System.Numerics.BigInteger(21000))

        Try
            Dim transactionHash = Await iweb3.Eth.Transactions.SendRawTransaction.SendRequestAsync(signedTx)
            MessageBox.Show(transactionHash)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        Call testContract()
    End Sub

End Class