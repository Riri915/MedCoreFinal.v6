Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class DatabaseHelper
    Private Shared ReadOnly Property ConnectionString As String
        Get
            Try
                Dim connStr As String = ConfigurationManager.ConnectionStrings("MedCoreDB")?.ConnectionString
                If Not String.IsNullOrEmpty(connStr) Then
                    Return connStr
                End If
                Return "Server=localhost;Database=medcoredb;User Id=root;Password=;"
            Catch
                Return "Server=localhost;Database=medcoredb;User Id=root;Password=;"
            End Try
        End Get
    End Property

    ' ==================== EXECUTION FUNCTIONS ====================

    Public Shared Function ExecuteQuery(sqlQuery As String, Optional parameters As List(Of MySqlParameter) = Nothing) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(ConnectionString)
                Using cmd As New MySqlCommand(sqlQuery, conn)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    Public Shared Function ExecuteNonQuery(sqlQuery As String, Optional parameters As List(Of MySqlParameter) = Nothing) As Boolean
        Try
            Using conn As New MySqlConnection(ConnectionString)
                Using cmd As New MySqlCommand(sqlQuery, conn)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Shared Function ExecuteScalar(sqlQuery As String, Optional parameters As List(Of MySqlParameter) = Nothing) As Object
        Try
            Using conn As New MySqlConnection(ConnectionString)
                Using cmd As New MySqlCommand(sqlQuery, conn)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    conn.Open()
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ' ==================== QUEUE FUNCTIONS ====================

    Public Shared Function GetWaitingPatients() As DataTable
        Dim sql As String = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, status " &
                           "FROM patient_queue WHERE status = 'Waiting' ORDER BY created_at"
        Return ExecuteQuery(sql)
    End Function

    Public Shared Function GetAllPatients() As DataTable
        Dim sql As String = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, status, " &
                           "gender, age, diagnosis, prescription, created_at FROM patient_queue ORDER BY created_at DESC"
        Return ExecuteQuery(sql)
    End Function

    Public Shared Function GetPatientByQueueNumber(queueNumber As String) As DataTable
        Dim sql As String = "SELECT * FROM patient_queue WHERE queue_number = @QueueNumber"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@QueueNumber", queueNumber)}
        Return ExecuteQuery(sql, params)
    End Function

    Public Shared Function UpdatePatientStatus(queueNumber As String, newStatus As String) As Boolean
        Dim sql As String = "UPDATE patient_queue SET status = @Status WHERE queue_number = @QueueNumber"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@Status", newStatus),
            New MySqlParameter("@QueueNumber", queueNumber)
        }
        Return ExecuteNonQuery(sql, params)
    End Function

    Public Shared Function UpdatePatientDetails(queueNumber As String, gender As String, age As Integer,
                                               birthday As String, address As String, phone As String,
                                               emergencyContact As String, diagnosis As String,
                                               prescription As String) As Boolean
        Dim sql As String = "UPDATE patient_queue SET gender = @Gender, age = @Age, birthday = @Birthday, " &
                           "address = @Address, phone = @Phone, emergency_contact = @Emergency, " &
                           "diagnosis = @Diagnosis, prescription = @Prescription " &
                           "WHERE queue_number = @QueueNumber"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@Gender", gender),
            New MySqlParameter("@Age", age),
            New MySqlParameter("@Birthday", birthday),
            New MySqlParameter("@Address", address),
            New MySqlParameter("@Phone", phone),
            New MySqlParameter("@Emergency", emergencyContact),
            New MySqlParameter("@Diagnosis", diagnosis),
            New MySqlParameter("@Prescription", prescription),
            New MySqlParameter("@QueueNumber", queueNumber)
        }
        Return ExecuteNonQuery(sql, params)
    End Function

    ' ADD THIS MISSING FUNCTION
    Public Shared Function GetNextWaitingPatient() As DataTable
        Dim sql As String = "SELECT queue_number as ID, patient_name as Name, service_type as Concern " &
                           "FROM patient_queue WHERE status = 'Waiting' ORDER BY created_at LIMIT 1"
        Return ExecuteQuery(sql)
    End Function

    ' ==================== DASHBOARD FUNCTIONS ====================

    Public Shared Function GetWaitingCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM patient_queue WHERE status = 'Waiting'"
        Dim result As Object = ExecuteScalar(sql)
        Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
    End Function

    Public Shared Function GetServingCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM patient_queue WHERE status = 'In progress'"
        Dim result As Object = ExecuteScalar(sql)
        Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
    End Function

    Public Shared Function GetDoneCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM patient_queue WHERE status = 'Done'"
        Dim result As Object = ExecuteScalar(sql)
        Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
    End Function

    Public Shared Function GetTotalPatients() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM patient_queue"
        Dim result As Object = ExecuteScalar(sql)
        Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
    End Function

    Public Shared Function GetCountByServiceType(serviceType As String) As Integer
        Dim sql As String = "SELECT COUNT(*) FROM patient_queue WHERE service_type LIKE @ServiceType"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@ServiceType", "%" & serviceType & "%")}
        Dim result As Object = ExecuteScalar(sql, params)
        Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
    End Function

    Public Shared Function GetAverageConsultationTime() As Double
        Dim sql As String = "SELECT AVG(TIMESTAMPDIFF(MINUTE, created_at, updated_at)) FROM patient_queue " &
                           "WHERE updated_at IS NOT NULL AND status = 'Done'"
        Dim result As Object = ExecuteScalar(sql)
        Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, Math.Round(Convert.ToDouble(result), 1), 0)
    End Function

    ' ==================== BILLING FUNCTIONS ====================

    Public Shared Function CreateTransaction(queueNumber As String, patientName As String,
                                           serviceType As String, amount As Decimal) As String
        Dim transNo As String = "TRX-" & DateTime.Now.ToString("yyyyMMdd") & "-" & DateTime.Now.ToString("HHmmss")

        Dim sql As String = "INSERT INTO billing_transactions (transaction_number, queue_number, patient_name, " &
                           "service_type, amount) VALUES (@TransNo, @QueueNo, @Name, @Service, @Amount)"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@TransNo", transNo),
            New MySqlParameter("@QueueNo", queueNumber),
            New MySqlParameter("@Name", patientName),
            New MySqlParameter("@Service", serviceType),
            New MySqlParameter("@Amount", amount)
        }

        If ExecuteNonQuery(sql, params) Then
            Dim updateSql As String = "UPDATE patient_queue SET transaction_number = @TransNo, amount = @Amount " &
                                     "WHERE queue_number = @QueueNo"
            Dim updateParams As New List(Of MySqlParameter) From {
                New MySqlParameter("@TransNo", transNo),
                New MySqlParameter("@Amount", amount),
                New MySqlParameter("@QueueNo", queueNumber)
            }
            ExecuteNonQuery(updateSql, updateParams)
            Return transNo
        End If
        Return ""
    End Function

    Public Shared Function UpdatePaymentStatus(transactionNumber As String, status As String) As Boolean
        Dim sql As String = "UPDATE billing_transactions SET payment_status = @Status, payment_date = NOW() " &
                           "WHERE transaction_number = @TransNo"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@Status", status),
            New MySqlParameter("@TransNo", transactionNumber)
        }

        If ExecuteNonQuery(sql, params) Then
            Dim updateSql As String = "UPDATE patient_queue SET payment_status = @Status WHERE transaction_number = @TransNo"
            Dim updateParams As New List(Of MySqlParameter) From {
                New MySqlParameter("@Status", status),
                New MySqlParameter("@TransNo", transactionNumber)
            }
            ExecuteNonQuery(updateSql, updateParams)
            Return True
        End If
        Return False
    End Function

    Public Shared Function GetTransactionByQueueNumber(queueNumber As String) As DataTable
        Dim sql As String = "SELECT * FROM billing_transactions WHERE queue_number = @QueueNo"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@QueueNo", queueNumber)}
        Return ExecuteQuery(sql, params)
    End Function

    ' ==================== RECORDS FUNCTIONS ====================

    Public Shared Function GetAllRecords() As DataTable
        Dim sql As String = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, " &
                           "DATE_FORMAT(created_at, '%Y-%m-%d') as Date, status " &
                           "FROM patient_queue ORDER BY created_at DESC"
        Return ExecuteQuery(sql)
    End Function

    Public Shared Function SearchRecords(searchTerm As String, searchBy As String) As DataTable
        Dim sql As String = ""
        Dim params As New List(Of MySqlParameter)

        Select Case searchBy
            Case "All"
                sql = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, " &
                      "DATE_FORMAT(created_at, '%Y-%m-%d') as Date, status " &
                      "FROM patient_queue WHERE patient_name LIKE @Search OR queue_number LIKE @Search " &
                      "OR service_type LIKE @Search ORDER BY created_at DESC"
                params.Add(New MySqlParameter("@Search", "%" & searchTerm & "%"))
            Case "Queue #"
                sql = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, " &
                      "DATE_FORMAT(created_at, '%Y-%m-%d') as Date, status " &
                      "FROM patient_queue WHERE queue_number LIKE @Search ORDER BY created_at DESC"
                params.Add(New MySqlParameter("@Search", "%" & searchTerm & "%"))
            Case "Patient Name"
                sql = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, " &
                      "DATE_FORMAT(created_at, '%Y-%m-%d') as Date, status " &
                      "FROM patient_queue WHERE patient_name LIKE @Search ORDER BY created_at DESC"
                params.Add(New MySqlParameter("@Search", "%" & searchTerm & "%"))
            Case "Date"
                sql = "SELECT queue_number as ID, patient_name as Name, service_type as Concern, " &
                      "DATE_FORMAT(created_at, '%Y-%m-%d') as Date, status " &
                      "FROM patient_queue WHERE DATE(created_at) = @Date ORDER BY created_at DESC"
                params.Add(New MySqlParameter("@Date", searchTerm))
        End Select

        Return ExecuteQuery(sql, params)
    End Function



    ' Add these functions to DatabaseHelper.vb

    ' Get service price by service code
    Public Shared Function GetServicePrice(serviceCode As String) As Decimal
        Dim sql As String = "SELECT price FROM service_codes WHERE service_code = @ServiceCode AND is_active = TRUE"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@ServiceCode", serviceCode)}
        Dim result As Object = ExecuteScalar(sql, params)
        Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, Convert.ToDecimal(result), 0)
    End Function

    ' Get service name by service code
    Public Shared Function GetServiceName(serviceCode As String) As String
        Dim sql As String = "SELECT service_name FROM service_codes WHERE service_code = @ServiceCode AND is_active = TRUE"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@ServiceCode", serviceCode)}
        Dim result As Object = ExecuteScalar(sql, params)
        Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, result.ToString(), "")
    End Function

    ' Get all service codes (for dropdown)
    Public Shared Function GetAllServiceCodes() As DataTable
        Dim sql As String = "SELECT service_code, service_name, price FROM service_codes WHERE is_active = TRUE ORDER BY service_name"
        Return ExecuteQuery(sql)
    End Function

    ' Generate transaction with service code
    Public Shared Function GenerateTransaction(queueNumber As String, patientName As String,
                                             serviceCode As String, serviceType As String, amount As Decimal) As String
        Dim transNo As String = "TRX-" & DateTime.Now.ToString("yyyyMMdd") & "-" & DateTime.Now.ToString("HHmmss")

        Dim sql As String = "INSERT INTO billing_transactions (transaction_number, queue_number, patient_name, " &
                           "service_type, service_code, amount) VALUES (@TransNo, @QueueNo, @Name, @Service, @Code, @Amount)"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@TransNo", transNo),
            New MySqlParameter("@QueueNo", queueNumber),
            New MySqlParameter("@Name", patientName),
            New MySqlParameter("@Service", serviceType),
            New MySqlParameter("@Code", serviceCode),
            New MySqlParameter("@Amount", amount)
        }

        If ExecuteNonQuery(sql, params) Then
            Dim updateSql As String = "UPDATE patient_queue SET transaction_number = @TransNo, amount = @Amount " &
                                     "WHERE queue_number = @QueueNo"
            Dim updateParams As New List(Of MySqlParameter) From {
                New MySqlParameter("@TransNo", transNo),
                New MySqlParameter("@Amount", amount),
                New MySqlParameter("@QueueNo", queueNumber)
            }
            ExecuteNonQuery(updateSql, updateParams)
            Return transNo
        End If
        Return ""
    End Function

    ' Get transaction by number (for printing)
    Public Shared Function GetTransactionByNumber(transNo As String) As DataTable
        Dim sql As String = "SELECT * FROM billing_transactions WHERE transaction_number = @TransNo"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@TransNo", transNo)}
        Return ExecuteQuery(sql, params)
    End Function






    ' Add these functions to DatabaseHelper.vb

    ' Get service code by concern
    Public Shared Function GetServiceCodeByConcern(concern As String) As String
        Dim sql As String = "SELECT service_code FROM service_codes " &
                           "WHERE service_name LIKE @Concern OR service_code LIKE @Concern LIMIT 1"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@Concern", "%" & concern & "%")}
        Dim result As Object = ExecuteScalar(sql, params)
        Return If(result IsNot Nothing, result.ToString(), "")
    End Function

    ' Get service details by code
    Public Shared Function GetServiceByCode(serviceCode As String) As DataTable
        Dim sql As String = "SELECT * FROM service_codes WHERE service_code = @Code AND is_active = TRUE"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@Code", serviceCode)}
        Return ExecuteQuery(sql, params)
    End Function

    ' Generate transaction using service code as transaction number
    Public Shared Function GenerateTransactionWithServiceCode(queueNumber As String, patientName As String,
                                                              serviceCode As String, concern As String) As Boolean
        ' Use service code as transaction number
        Dim transNo As String = serviceCode

        ' Check if transaction already exists
        Dim checkSql As String = "SELECT COUNT(*) FROM billing_transactions WHERE transaction_number = @TransNo"
        Dim checkParams As New List(Of MySqlParameter) From {New MySqlParameter("@TransNo", transNo)}
        Dim exists As Integer = Convert.ToInt32(ExecuteScalar(checkSql, checkParams))

        If exists > 0 Then
            ' If exists, add suffix
            transNo = serviceCode & "-" & DateTime.Now.ToString("HHmmss")
        End If

        Dim sql As String = "INSERT INTO billing_transactions (transaction_number, queue_number, patient_name, " &
                           "service_type, service_code) VALUES (@TransNo, @QueueNo, @Name, @Service, @Code)"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@TransNo", transNo),
            New MySqlParameter("@QueueNo", queueNumber),
            New MySqlParameter("@Name", patientName),
            New MySqlParameter("@Service", concern),
            New MySqlParameter("@Code", serviceCode)
        }

        If ExecuteNonQuery(sql, params) Then
            Dim updateSql As String = "UPDATE patient_queue SET transaction_number = @TransNo, service_code = @Code " &
                                     "WHERE queue_number = @QueueNo"
            Dim updateParams As New List(Of MySqlParameter) From {
                New MySqlParameter("@TransNo", transNo),
                New MySqlParameter("@Code", serviceCode),
                New MySqlParameter("@QueueNo", queueNumber)
            }
            ExecuteNonQuery(updateSql, updateParams)
            Return True
        End If
        Return False
    End Function

    ' Get transaction by service code (for POS)
    Public Shared Function GetTransactionByServiceCode(serviceCode As String) As DataTable
        Dim sql As String = "SELECT bt.*, pq.patient_name, pq.service_type " &
                           "FROM billing_transactions bt " &
                           "LEFT JOIN patient_queue pq ON bt.queue_number = pq.queue_number " &
                           "WHERE bt.service_code = @Code AND bt.payment_status = 'Pending' " &
                           "ORDER BY bt.created_at DESC LIMIT 1"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@Code", serviceCode)}
        Return ExecuteQuery(sql, params)
    End Function

    ' Add this function to DatabaseHelper.vb

    ' Delete patient record
    Public Shared Function DeletePatientRecord(patientID As String) As Boolean
        Dim sql As String = "DELETE FROM patient_queue WHERE queue_number = @PatientID"
        Dim params As New List(Of MySqlParameter) From {New MySqlParameter("@PatientID", patientID)}
        Return ExecuteNonQuery(sql, params)
    End Function
End Class




