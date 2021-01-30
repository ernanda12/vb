Imports System.Data.Odbc
Public Class FormMasterAdmin
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button1.Text = "Input"
        Button2.Text = "Edit"
        Button3.Text = "Hapus"
        Button4.Text = "Tutup"
        Call Koneksi()
        da = New OdbcDataAdapter("Select KodeAdmin,NamaAdmin,LevelAdmin From tbl_admin", Conn)
        Ds = New DataSet
        Ds.Clear()
        da.Fill(Ds, "tbl_admin")
        DataGridView1.DataSource = (Ds.Tables("tbl_admin"))
        DataGridView1.ReadOnly = True


    End Sub
    Sub SiapIsi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox1.Items.Add("ADMIN")
        ComboBox1.Items.Add("User")
        Call Koneksi()
    End Sub

    Private Sub FormMasterAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan isi semua field")
            Else
                Call Koneksi()
                Dim InputData As String = "Insert into  tbl_admin values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "', '" & ComboBox1.Text & "')"
                Cmd = New OdbcCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub DaFill(ByVal Ds As DataSet, ByVal p2 As String)
        Throw New NotImplementedException
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Jika button 2 textnya = edit 
        If Button2.Text = "Edit" Then
            Button2.Text = "Simpan"
            'button 2 nya true
            Button2.Enabled = True
            Button1.Enabled = False
            'button 3 juga false
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan isi semua field")
            Else
                Call Koneksi()
                'password Amin terus kurang sama dengan
                Dim UpdateData As String = "Update tbl_admin set namaadmin ='" & TextBox2.Text & "',passwordadmin ='" & TextBox3.Text & "',leveladmin='" & ComboBox1.Text & "' where kodeadmin ='" & TextBox1.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Update Data Berhasil")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            Cmd = New OdbcCommand("Select * From tbl_admin where kodeadmin='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            If Not Rd.HasRows Then
                MsgBox("Kode Admin tidak ada")
            Else
                TextBox1.Text = Rd.Item("KodeAdmin")
                TextBox2.Text = Rd.Item("NamaAdmin")
                TextBox3.Text = Rd.Item("PasswordAdmin")
                ComboBox1.Text = Rd.Item("LevelAdmin")
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Tutup" Then
            Me.Close()
        Else
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "Hapus" Then
            Button3.Text = "Delete"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan isi semua field")
            Else
                Call Koneksi()
                'ga ada koding / query yang "|" kurang sama dengan
                Dim HapusData As String = "Delete from  tbl_admin where kodeadmin = '" & TextBox1.Text & "'"
                Cmd = New OdbcCommand(HapusData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Hapus Data Berhasil")
                Call KondisiAwal()
            End If
        End If
    End Sub
End Class