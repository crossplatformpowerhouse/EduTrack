using EduTrack.Shared.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Services
{
	public interface IEduTrackService
	{
		// Read methods
		Task<IEnumerable<User>> GetUsersAsync();
		Task<IEnumerable<CourseType>> GetCourseTypesAsync();
		Task<IEnumerable<Course>> GetCoursesAsync();
		Task<IEnumerable<Subject>> GetSubjectsAsync();
		Task<IEnumerable<AssignmentType>> GetAssignmentTypesAsync();
		Task<IEnumerable<ExamType>> GetExamTypesAsync();
		Task<IEnumerable<Assignment>> GetAssignmentsAsync();
		Task<IEnumerable<Grade>> GetGradesAsync();
		Task<IEnumerable<Account>> GetAccountsAsync();
		Task<IEnumerable<About>> GetAboutsAsync();
		Task<IEnumerable<StudentDetailsDto>> GetStudentDetailsAsync(int userId);

		// Create methods
		Task<int> AddUserAsync(User user);
		Task<int> AddCourseTypeAsync(CourseType courseType);
		Task<int> AddCourseAsync(Course course);
		Task<int> AddSubjectAsync(Subject subject);
		Task<int> AddAssignmentTypeAsync(AssignmentType assignmentType);
		Task<int> AddExamTypeAsync(ExamType examType);
		Task<int> AddAssignmentAsync(Assignment assignment);
		Task<int> AddGradeAsync(Grade grade);
		Task<int> AddAccountAsync(Account account);
		Task<int> AddAboutAsync(About about);

		// Update methods
		Task UpdateUserAsync(User user);
		Task UpdateCourseTypeAsync(CourseType courseType);
		Task UpdateCourseAsync(Course course);
		Task UpdateSubjectAsync(Subject subject);
		Task UpdateAssignmentTypeAsync(AssignmentType assignmentType);
		Task UpdateExamTypeAsync(ExamType examType);
		Task UpdateAssignmentAsync(Assignment assignment);
		Task UpdateGradeAsync(Grade grade);
		Task UpdateAccountAsync(Account account);
		Task UpdateAboutAsync(About about);

		// Delete methods
		Task DeleteUserAsync(int id);
		Task DeleteCourseTypeAsync(int id);
		Task DeleteCourseAsync(int id);
		Task DeleteSubjectAsync(int id);
		Task DeleteAssignmentTypeAsync(int id);
		Task DeleteExamTypeAsync(int id);
		Task DeleteAssignmentAsync(int id);
		Task DeleteGradeAsync(int id);
		Task DeleteAccountAsync(int id);
		Task DeleteAboutAsync(int id);

		// New Notification methods
		Task<IEnumerable<Notification>> GetNotificationsAsync(int userId);
		Task<int> AddNotificationAsync(Notification notification);
		Task DeleteNotificationAsync(int id);
	}
}
