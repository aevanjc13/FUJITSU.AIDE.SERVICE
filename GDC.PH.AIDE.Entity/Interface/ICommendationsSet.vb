﻿Imports GDC.PH.AIDE.BusinessLayer
Public Interface ICommendationsSet
    Property COMMEND_ID As Integer
    Property DEPT_ID As Integer
    Property EMPLOYEE As String
    Property PROJECT As String
    Property DATE_SENT As Date
    Property SENT_BY As String
    Property REASON As String

    Function GetAllCoCommendations(ByVal deptID As Integer) As List(Of CommendationsSet)
    Function InsertCommendations(ByVal commendations As CommendationsSet) As Boolean
    Function UpdateCommendations(ByVal commendations As CommendationsSet) As Boolean

End Interface
