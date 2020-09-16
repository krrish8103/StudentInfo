CREATE PROCEDURE sprocInsertStudentInfo
(
 @StudentID          INT,
 @Provider 		     VARCHAR(30),
 @FacultyID 	     INT,
 @CourseCode 	     CHAR(11),
 @CourseCredit 	     DECIMAL(3,2),
 @oRetVal            INT OUTPUT,
 @oMasterScheduleId  INT OUTPUT,
 @oStudentScheduleId INT OUTPUT
)

AS
BEGIN 
  SET @oRetVal = -501 -- Error Occured
  SET @oMasterScheduleId = -1;
  SET @oStudentScheduleId = -1; -- DEFAULT VALUE
  IF NOT EXISTS(SELECT 1 FROM lea.students WHERE StudentID = @StudentID)
  BEGIN
    SET @oRetVal = -101 -- STUDENT DOESNOT EXISTS
  END

  SET @oMasterScheduleId = 1;
  SET @oStudentScheduleId = 1;
  RETURN
END