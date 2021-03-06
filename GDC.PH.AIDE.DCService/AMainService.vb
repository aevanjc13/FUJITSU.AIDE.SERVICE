﻿


Public MustInherit Class AMainService

    ''' <summary>
    ''' By Jester Sanchez
    ''' </summary>
#Region "Action List Method"
    MustOverride Function InsertActionLst(ByVal _Action As Action) As Boolean
    MustOverride Function GetActionLstByMessage(ByVal _Message As String, ByVal email As String, ByRef objResult As List(Of Action)) As Boolean
    MustOverride Function GetActionSummry(ByVal email As String, ByRef objResult As List(Of Action)) As Boolean
    MustOverride Function UpdateActionLst(ByVal _Action As Action) As Boolean
#End Region

#Region "Profile methods"
    ''' <summary>
    ''' - GIANN CARLO CAMILO 
    ''' </summary>
    ''' <param name="emailAddress"></param>
    ''' <param name="objResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetMyProfile(ByVal emailAddress As String, ByRef objResult As Profile) As Boolean
    MustOverride Function GetProfile(ByVal emailAddress As String, ByRef objResult As Profile) As Boolean
    'MustOverride Function UpdateProfile(ByVal profile As Profile) As Boolean
#End Region

#Region "Contacts method"
    MustOverride Function GetContact(ByVal empID As Integer, ByRef objResult As Contact) As Boolean
    MustOverride Function GetContactsList(ByRef objResult As List(Of Contact)) As Boolean
    MustOverride Function UpdateContact(ByVal contact As Contact) As Boolean
#End Region

#Region "Attendance methods"
    MustOverride Function GetAttendanceAll(ByVal Month As Integer, ByVal Year As Integer, ByRef objResult As List(Of AttendanceSummary)) As Boolean
    MustOverride Function GetAttendanceEmployee(ByVal empId As Integer, ByVal WeekOf As Date, ByRef objResult As MyAttendance) As Boolean
    MustOverride Function UpdateAttendanceByEmp(ByVal _Attendance As AttendanceSummary) As Boolean
    MustOverride Function InsertAttendanceByEmp(ByVal _Attendance As AttendanceSummary) As Boolean
    MustOverride Function UpdateAttendanceByEmp(ByVal empid As Integer, ByVal day As Integer, ByVal attstatus As Integer) As Boolean
    MustOverride Function GetAttendanceToday(ByVal email As String) As List(Of MyAttendance)
#End Region

#Region "Employee methods"

    MustOverride Function GetAllEmployees(ByRef objResult As List(Of Employee)) As Boolean
    MustOverride Function GetNicknameByDeptID(ByVal email As String, ByRef objResult As List(Of Employee)) As Boolean
    MustOverride Function GetEmployee(ByVal empId As Integer, ByRef objResult As Employee) As Boolean
    MustOverride Function UpdateEmployee(ByVal emp As Employee) As Boolean
#End Region

#Region "Projects method"
    ''' <summary>
    ''' GIANN CARLO CAMILO , HYACINTH AMARLES , HAVEY SANCHEZ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetAllListOfProject() As List(Of Project)
    MustOverride Function CreateNewProject(ByVal project As Project) As Boolean
    ''' <summary>
    ''' GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="assignProject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function CreateNewAssignedProject(ByVal assignProject As List(Of AssignedProject)) As Boolean
    MustOverride Function ViewProjectList(ByRef objResult As List(Of ViewProject)) As Boolean
    MustOverride Function GetProjectByProjID(ByVal projID As Integer, ByRef objResult As Project) As Boolean
    MustOverride Function GetProjectsList(ByRef objResult As List(Of Project)) As Boolean
    MustOverride Function UpdateAssignedProject(ByVal project As Project) As Boolean
    ''' <summary>
    ''' GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="Project"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function AssignProjectToEmployee(ByVal Project As AssignedProject) As Boolean
    ''' <summary>
    ''' GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="objResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function ViewProjectListofEmployee(ByRef objResult As List(Of ViewProject)) As Boolean

    'List of Employee per Project For Combobox
    MustOverride Function GetEmployeePerProject(ByVal empID As Integer, ByVal projID As Integer) As List(Of Nickname)

#End Region

#Region "Tasks methods"
    MustOverride Function CreateNewTask(ByVal task As Tasks) As Boolean
    MustOverride Function ViewMyTasks(ByVal empId As Integer, ByRef objResult As List(Of Tasks)) As Boolean
    MustOverride Function ViewEmployeeTaskSummry(ByVal empId As Integer, Current_Date As Date, ByRef objResult As List(Of TaskSummary)) As Boolean
    MustOverride Function ViewTasksSummaryAll(ByVal Current_Date As Date, ByVal email As String, ByRef objResult As List(Of TaskSummary)) As Boolean
    MustOverride Function GetTasksAll(ByRef objResult As List(Of Tasks)) As Boolean
    MustOverride Function UpdateEmployeeTask(ByVal Task As Tasks) As Boolean
    MustOverride Function GetTaskDetailByIncidentId(ByVal empID As Integer) As List(Of Tasks)
#End Region

#Region "Commendations methods"
    MustOverride Function InsertCommendations(ByVal commendations As Commendations) As Boolean
    MustOverride Function GetCommendations(ByVal deptID As Integer) As List(Of Commendations)
    MustOverride Function UpdateCommendations(ByVal commendations As Commendations) As Boolean
#End Region

#Region "Status List methods"
    MustOverride Function GetAttendanceStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
    MustOverride Function GetCivilStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
    MustOverride Function GetTaskStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
    MustOverride Function GetTaskCategoriesList(ByRef objResult As List(Of StatusGroup)) As Boolean
    MustOverride Function GetPhaseStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
    MustOverride Function GetReworkStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
#End Region

    ''' <summary>
    ''' By John Harvey Sanchez
    ''' </summary>
#Region "Lesson Learnt Methods"
    MustOverride Function GetAllLessonLearntList(ByRef email As String, ByRef objResult As List(Of LessonLearnt)) As Boolean
    MustOverride Function GetLessonLearntByProblems(ByRef searchProblem As String, ByRef email As String, ByRef objResult As List(Of LessonLearnt)) As Boolean
    MustOverride Function UpdateLessonLearnt(ByRef lessonLearnt As LessonLearnt) As Boolean
    MustOverride Function CreateNewLessonLearnt(ByRef lessonLearnt As LessonLearnt) As Boolean
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Success Register Methods"
    MustOverride Function CreateSuccessRegister(success As SuccessRegister) As Boolean
    MustOverride Function GetSuccessRegisterAll(email As String) As List(Of SuccessRegister)
    MustOverride Function GetSuccessRegisterByEmpID(email As String) As List(Of SuccessRegister)
    MustOverride Function GetSuccessRegisterBySearch(input As String, email As String) As List(Of SuccessRegister)
    MustOverride Function UpdateSuccessRegister(success As SuccessRegister) As Boolean
    MustOverride Function DeleteSuccessRegister(successID As Integer) As Boolean
    'List of Nickname For Combobox
    MustOverride Function GetNicknameByDeptID(email As String) As List(Of Nickname)
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Contact List Methods"
    MustOverride Function GetContactListAll(email As String) As List(Of ContactList)
    MustOverride Function UpdateContactList(contacts As ContactList) As Boolean
    MustOverride Function CreateContact(contacts As ContactList) As Boolean
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Birthday List Methods"
    MustOverride Function GetBirthdayListAll(email As String) As List(Of BirthdayList)
    MustOverride Function GetBirthdayListByMonth(email As String) As List(Of BirthdayList)
#End Region

#Region "Concern Learnt Methods"

    ''' <summary>
    ''' - GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <param name="email"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function InsertIntoConcerns(ByVal concern As Concern, ByVal email As String) As Boolean

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="objResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetGeneratedRefNo(ByRef objResult As Concern) As Boolean

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="searchKeyWord"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetResultSearch(email As String, searchKeyWord As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern)

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function selectAllConcern(email As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern)

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetListOfACtion(Ref_id As String, email As String) As List(Of Concern)

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetListOfACtionsReferences(Ref_id As String) As List(Of Concern)

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function insertAndDeleteSelectedAction(ByVal concern As Concern) As Boolean

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function UpdateSelectedConcern(ByVal concern As Concern) As Boolean

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <param name="date1"></param>
    ''' <param name="date2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetBetweenSearchConcern(email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As List(Of Concern)

    ''' <summary>
    ''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="_KeywordAction"></param>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    MustOverride Function GetSearchAction(_KeywordAction As String, Ref_id As String, email As String) As List(Of Concern)

#End Region

#Region "Skills Matrix Methods"
    ''' <summary>
    ''' By Jhunell G. Barcenas
    ''' </summary>
    ''' <remarks></remarks>
    MustOverride Function GetSkillsList() As List(Of Skills)
    MustOverride Function ViewEmpSkills(ByVal empID As Integer) As List(Of Skills)
    MustOverride Function GetProfLvlByEmpIDSkillID(ByVal id As Integer, ByVal empID As Integer, ByRef objResult As Skills) As Boolean
    MustOverride Function GetSkillsLastReviewByEmpIDSkillID(ByVal id As Integer, ByVal empID As Integer, ByRef objResult As Skills) As Boolean
#End Region

#Region "Resource Planner Methods"
    ''' <summary>
    ''' By Jhunell G. Barcenas
    ''' </summary>
    ''' <remarks></remarks
    MustOverride Function ViewEmpResourcePlanner(ByVal email As String) As List(Of ResourcePlanner)
    MustOverride Function GetStatusResourcePlanner() As List(Of ResourcePlanner)
    MustOverride Function GetResourcePlannerByEmpID(ByVal empID As Integer, ByVal deptID As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlanner)
    MustOverride Function GetAllEmpResourcePlanner(ByVal email As String, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlanner)
    MustOverride Function GetAllEmpResourcePlannerByStatus(ByVal email As String, ByVal month As Integer, ByVal year As Integer, ByVal status As Integer) As List(Of ResourcePlanner)
    MustOverride Function GetAllStatusResourcePlanner() As List(Of ResourcePlanner)
    MustOverride Function GetResourcePlanner(ByVal email As String, ByVal status As Integer, ByVal toBeDisplayed As Integer) As List(Of ResourcePlanner)

#End Region

#Region "Assets methods"
    MustOverride Function InsertAssets(ByVal assets As Assets) As Boolean
    MustOverride Function GetMyAssets(ByVal empID As Integer) As List(Of Assets)
    MustOverride Function GetAllAssetsByEmpID(ByVal empID As Integer) As List(Of Assets)
    MustOverride Function GetAllAssetsBySearch(ByVal empID As Integer, ByVal input As String) As List(Of Assets)
    MustOverride Function UpdateAssets(ByVal assets As Assets) As Boolean
    MustOverride Function InsertAssetsInventory(ByVal assets As Assets) As Boolean
    MustOverride Function UpdateAssetsInventory(ByVal assets As Assets) As Boolean
    MustOverride Function UpdateAssetsInventoryApproval(ByVal assets As Assets) As Boolean
    MustOverride Function UpdateAssetsInventoryCancel(ByVal assets As Assets) As Boolean
    MustOverride Function GetAllAssetsInventoryByEmpID(ByVal empID As Integer) As List(Of Assets)
    MustOverride Function GetAllAssetsInventoryUnApproved(ByVal empID As Integer) As List(Of Assets)
    MustOverride Function GetAllAssetsUnAssigned(ByVal empID As Integer) As List(Of Assets)
    MustOverride Function GetAllManagers(ByVal empID As Integer) As List(Of Nickname)
    MustOverride Function GetAllAssetsHistory(ByVal empID As Integer) As List(Of Assets)
    MustOverride Function GetAllAssetsHistoryBySearch(ByVal empID As Integer, ByVal input As String) As List(Of Assets)
#End Region

End Class
