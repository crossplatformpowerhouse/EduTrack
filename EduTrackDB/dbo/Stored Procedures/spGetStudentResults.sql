
-- Get Student Results
CREATE   PROCEDURE spGetStudentResults
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        u.Username,
        u.FirstName,
        u.LastName,
        u.Email,
        sc.Description AS School,
        c.Code AS CourseCode,
        c.Description AS CourseDescription,
        ct.Description AS CourseType,
        s.Code AS SubjectCode,
        s.Description AS SubjectDescription,
        s.AcademicYear,
        s.PassMark,
        a.Code AS AssessmentCode,
        a.Description AS AssessmentDescription,
        r.Mark,
        r.FinalMark,
        r.Predicate
    FROM tResult r
    JOIN tUser u ON r.UserId = u.Id
    JOIN tCourse c ON r.CourseId = c.Id
    JOIN tCourseType ct ON c.CourseTypeId = ct.Id
    JOIN tSubject s ON r.SubjectId = s.Id
    JOIN tAssessment a ON r.AssessmentId = a.Id
    JOIN tSchool sc ON u.SchoolId = sc.Id
    WHERE r.UserId = @UserId AND r.IsDeleted = 0;
END;