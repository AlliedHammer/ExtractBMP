'|--------------------------------------------------------------------------|
'|--------------------------------------------------------------------------|
'|-Project: ExtractBMP   ---------------------------------------------------|
'|-Programmer: Allen Hurtig   ----------------------------------------------|
'|-Incept Date: 11/12/2018   -----------------------------------------------|
'|-Purpose: Extract BMP files from a DAT file.   ---------------------------|
'|--------------------------------------------------------------------------|
'|-------------------------Revision History---------------------------------|
'|-REV 0.1 11/12/2018 :         --------------------------------------------|
'|--Created program to do extraction of multiple BMP files from a single    |
'|---.dat file.     --------------------------------------------------------|
'|------------------------END Revision History------------------------------|
'|--------------------------------------------------------------------------|
'|--------------------------------------------------------------------------|

Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Path

Public Class ExtractBMP
'Form's default size is 760 x 220.
'Form's converted size is 760 x 715.
Dim loadSize As New Size(760, 220)
Dim convertSize As New Size(760, 715)
Dim bmpList As New List(Of List(Of Byte))
'Dim byteBitmapList As New List(Of Byte)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Size the form on loading.
        HideInfoBox()

    End Sub

    Private Sub InputButton_Click(sender As Object, e As EventArgs) Handles InputButton.Click

        'Load in the .dat file.
        Dim fileDiag As OpenFileDialog = New OpenFileDialog()
        Dim fileName As String

        'Setup the file dialog window.
        fileDiag.Title = "Select a valid DAT file."
        fileDiag.InitialDirectory = "C:\"
        fileDiag.Filter = "DAT Files (*.dat)|*.dat"
        fileDiag.FilterIndex = 1
        fileDiag.RestoreDirectory = True

        'Check if there is an existing path or not.
        If InputTextBox.Text <> Nothing Then

            fileDiag.InitialDirectory = GetDirectoryName(InputTextBox.Text.ToString)

        End If

        'Check for a valid file.
        If fileDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'File was found.
            fileName = fileDiag.FileName

            'Clear input box and set its text to equal the file path.
            InputTextBox.Text = fileName.ToString()

            'Setup the output file path.
            With OutputTextBox

                .Clear()
                .Text = GetDirectoryName(fileName) & "\" & GetFileNameWithoutExtension(fileName) & ".bmp"

            End With

        End If

        'Hide the info box.
        HideInfoBox()

    End Sub

    Private Sub OutputButton_Click(sender As Object, e As EventArgs) Handles OutputButton.Click

        'Browse for the location to save the BMP file.
        Dim fileDiag As SaveFileDialog = New SaveFileDialog()
        Dim fileName As String

        'Setup the file dialog window.
        fileDiag.Title = "Select a location to save the DAT file."
        fileDiag.InitialDirectory = "C:\"
        fileDiag.Filter = "BMP File (*.bmp)|*.bmp"
        fileDiag.FilterIndex = 1
        fileDiag.RestoreDirectory = True
        fileDiag.FileName = GetFileNameWithoutExtension(InputTextBox.Text.ToString) & ".bmp"

        'Check if there is an existing path or not.
        If OutputTextBox.Text <> Nothing Then

            fileDiag.InitialDirectory = GetDirectoryName(OutputTextBox.Text.ToString)

        End If

        'Check for a valid file.
        If fileDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'File was found.
            fileName = fileDiag.FileName

            'Clear input box and set its text to equal the file path.
            OutputTextBox.Text = fileName.ToString()

        End If

        'Hide the info box.
        HideInfoBox()

    End Sub

    Private Sub ConvertButton_Click(sender As Object, e As EventArgs) Handles ConvertButton.Click

        'Show the info box.
        ShowInfoBox()

        'Clear the info box.
        InfoBox.Clear()

        'Read in the dat file and extract any bitmaps.
        GetDATFileData(InputTextBox.Text)

        'Write the bitmaps.
        WriteBMPFile(OutputTextBox.Text)

        'Clear any data that is left over at this point.
        bmpList.Clear()

    End Sub

    Private Sub GetDATFileData(ByVal inputFilePath As String)

        'Show the current status in the info box.
        InfoBox.Text = InfoBox.Text & "-------------------------BEGIN DAT FILE READ-------------------------" & vbCrLf

        'Open the specified DAT file and collect the number of attributes.
        Try

            Dim binaryReader As New BinaryReader(File.Open(inputFilePath, FileMode.Open))
            'If the file is not good.
            If Not File.Exists(inputFilePath) Then

                'Display error message.
                Dim badFileDiag As DialogResult = MessageBox.Show("Bad or no file detected!", _
                                                                  "Error!", _
                                                                  MessageBoxButtons.OK)
            Else

                'Read in the file.

                'Setup a byte list.
                Dim byteList As New List(Of Byte)
                Dim BMPHeader As New List(Of Byte)
                Dim foundBitmap As Boolean = False
                Dim bitmapCount As Integer = 0
                'Dim debugLimit As Integer = 0

                ''Setup a new DO WHILE loop.
                Do While binaryReader.BaseStream.Position <> binaryReader.BaseStream.Length
                ' ''Do While debugLimit < 1

                    'Read in the next value.
                    Dim nextByte As Byte = binaryReader.ReadByte

                    'Add the byte to the list if a bitmap was already found.
                    If foundBitmap = True Then

                        'Add the byte.
                        byteList.Add(nextByte)
                        'byteBitmapList.Add(nextByte)

                    End If

                    'Check if there is a found bitmap.
                    If nextByte = 66 And BMPHeader.Count = 0 Then

                        'Add the byte to the header.
                        BMPHeader.Add(nextByte)

                    'Check if there is a second value in the header found.
                    ElseIf nextByte = 77 And BMPHeader.Count = 1 Then

                        'Add the byte to the header.
                        BMPHeader.Add(nextByte)

                    'Check if there is a third value in the header found.
                    ElseIf nextByte = 112 And BMPHeader.Count = 2 Then

                        'Add the byte to the header.
                        BMPHeader.Add(nextByte)

                    'Check if there is a fourth value in the header found.
                    ElseIf nextByte = 49 And BMPHeader.Count = 3 Then

                        'Add the byte to the header.
                        BMPHeader.Add(nextByte)

                        'Do this if a previous bitmap was found, otherwise this is the first bitmap found.
                        If foundBitmap = True Then

                            'Add the list.
                            Dim tempList As New List(Of Byte)

                            'Copy the list.
                            For i As Integer = 0 To byteList.Count - 5 Step 1

                                tempList.Add(byteList.Item(i))

                            Next

                            bmpList.Add(tempList)

                            'Clear the list.
                            byteList.Clear()
                            'byteBitmapList.Clear()

                        End If

                        'Add the header.
                        For Each headerByte As Byte In BMPHeader

                            'Add the header to the list.
                            byteList.Add(headerByte)
                            'byteBitmapList.Add(headerByte)

                        Next

                        'Clear the header.
                        BMPHeader.Clear()

                        'Set the bitmap flag.
                        foundBitmap = True

                        'debugLimit += 1

                    'Clear the header if the consecutive path isn't followed.
                    Else

                        BMPHeader.Clear()

                    End If

                Loop

                'Close the file.
                binaryReader.Close()

            End If

            'Display how many bitmaps were found.
            InfoBox.Text = InfoBox.Text & bmpList.Count.ToString & " bitmap images found!" & vbCrLf

        Catch ex As Exception

            InfoBox.Text = InfoBox.Text & ex.ToString & vbCrLf

        End Try

    End Sub

    Private Sub WriteBMPFile(ByVal outputFilePath As String)

        'Show the current process in the info box.
        InfoBox.Text = InfoBox.Text & "-------------------------BEGIN BMP FILE WRITE-------------------------" & vbCrLf

        'Setup the correct output path for each bitmap.
        Dim baseBMPFilePath As String = outputFilePath.Substring(0, outputFilePath.Length - 4)

            'Begin writing the file.
            For i As Integer = 0 To bmpList.Count - 1 Step 1

                'Create the new bitmap.
                Dim BMPFileWriter As New BinaryWriter(File.Open(baseBMPFilePath & i.ToString & ".bmp", FileMode.OpenOrCreate))

                'Get the bytes and write them.
                For j As Integer = 0 To bmpList(i).Count - 1 Step 1

                    'Write the byte.
                    BMPFileWriter.Write(bmpList(i).Item(j))

                Next

                'Close the file.
                BMPFileWriter.Close()

                'Show the written file path.
                InfoBox.Text = InfoBox.Text & baseBMPFilePath & i.ToString & ".bmp" & vbCrLf

            Next

    End Sub

    Private Sub HideInfoBox()

        'Clear and hide the info box.
        InfoBox.Clear()
        Me.Size = loadSize

    End Sub

    Private Sub ShowInfoBox()

        'Show the info box and file info.
        Me.Size = convertSize

    End Sub

End Class