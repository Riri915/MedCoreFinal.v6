Imports System.Data

Module SharedData
    ' Current doctor in charge
    Public CurrentDoctor As DoctorInfo = Nothing

    ' Consultation session (persistent)
    Public ConsultationSession As New Dictionary(Of String, Object)

    ' Load doctor in charge from database
    Public Sub LoadDoctorInCharge()
        Dim sql As String = "
        SELECT id, username, 
               CONCAT(first_name, ' ', last_name) AS full_name, 
               account_type AS role
        FROM users
        WHERE account_type = 'Doctor'
        LIMIT 1"

        Dim dt As DataTable = DatabaseHelper.ExecuteQuery(sql)

        If dt.Rows.Count > 0 Then
            CurrentDoctor = New DoctorInfo With {
            .ID = Convert.ToInt32(dt.Rows(0)("id")),
            .Username = dt.Rows(0)("username").ToString(),
            .FullName = dt.Rows(0)("full_name").ToString(),
            .Role = dt.Rows(0)("role").ToString()
        }
        Else
            CurrentDoctor = New DoctorInfo With {
            .ID = 0,
            .Username = "",
            .FullName = "Doctor",
            .Role = "Doctor"
        }
        End If
    End Sub

    ' Save consultation data
    Public Sub SaveConsultationToSession(queueNumber As String, patientName As String,
                                     concern As String, gender As String, age As String,
                                     diagnosis As String, prescription As String,
                                     amount As String, transNo As String, status As String,
                                     Optional serviceCode As String = "",
                                     Optional serviceName As String = "")
        ConsultationSession("QueueNumber") = queueNumber
        ConsultationSession("PatientName") = patientName
        ConsultationSession("Concern") = concern
        ConsultationSession("Gender") = gender
        ConsultationSession("Age") = age
        ConsultationSession("Diagnosis") = diagnosis
        ConsultationSession("Prescription") = prescription
        ConsultationSession("Amount") = amount
        ConsultationSession("TransactionNumber") = transNo
        ConsultationSession("Status") = status
        ConsultationSession("ServiceCode") = serviceCode
        ConsultationSession("ServiceName") = serviceName
        ConsultationSession("IsActive") = Not String.IsNullOrEmpty(queueNumber)
    End Sub
    Public Sub ClearConsultationSession()
        ConsultationSession.Clear()
        ConsultationSession("IsActive") = False
    End Sub
End Module

Public Class DoctorInfo
    Public Property ID As Integer
    Public Property Username As String
    Public Property FullName As String
    Public Property Role As String
End Class